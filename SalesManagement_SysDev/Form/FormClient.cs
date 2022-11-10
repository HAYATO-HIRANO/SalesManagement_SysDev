using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesManagement_SysDev
{
    public partial class FormClient : Form
    {
        //メッセージ表示用クラスのインスタンス化
        MessageDsp messageDsp = new MessageDsp();
        //データベース顧客テーブルアクセス用クラスのインスタンス化
        ClientDataAccess clientDataAccess = new ClientDataAccess();
        //データベース営業所テーブルアクセス用クラスのインスタンス化
        SalesOfficeDataAccess salesOfficeDataAccess = new SalesOfficeDataAccess();
        //入力形式チェック用クラスのインスタンス化
        DataInputFormCheck dataInputFormCheck = new DataInputFormCheck();
        //データグリッドビュー用の顧客データ
        private static List<M_ClientDsp> Client;
        //コンボボックス用の営業所データ
        private static List<M_SalesOffice> SalesOffice;


        public FormClient()
        {
            InitializeComponent();
        }

        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void FormClient_Load(object sender, EventArgs e)
        {

            //コンボボックスの設定
            SetFormComboBox();

            //データグリッドビューの設定
            SetFormDataGridView();
        }

        ///////////////////////////////
        //メソッド名：SetFormComboBox()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：コンボボックスのデータ設定
        ///////////////////////////////
        private void SetFormComboBox()
        {
            //営業所データの取得
            SalesOffice = salesOfficeDataAccess.GetSalesOfficeDspData();
            comboBoxSoID.DataSource = SalesOffice;
            comboBoxSoID.DisplayMember = "SoName";
            comboBoxSoID.ValueMember = "SoID";
            //コンボボックスを読み取り専用
            comboBoxSoID.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxSoID.SelectedIndex = -1;
        }

        private void buttonFormDel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonRegist_Click(object sender, EventArgs e)
        {
            // 8.3.1.1 妥当なスタッフデータ取得
            if (!GetValidDataAtRegistration())
                return;

            // 8.3.1.2 スタッフ情報作成
            var regStaff = GenerateDataAtRegistration();

            // 8.3.1.3 スタッフ情報登録
            RegistrationStaff(regStaff);

        }
        ///////////////////////////////
        //　3.1.1.1 妥当な顧客データ取得
        //メソッド名：GetValidDataAtRegistration()
        //引　数   ：なし
        //戻り値   ：true or false
        //機　能   ：入力データの形式チェック
        //          ：エラーがない場合True
        //          ：エラーがある場合False
        ///////////////////////////////
        private bool GetValidDataAtRegistration()
        {
            //営業所名の選択チェック
           if(comboBoxSoID.SelectedIndex == -1)
            {
                //営業所名が選択されていません
                messageDsp.DspMsg("M0307");
                comboBoxSoID.Focus();
                return false;

            }
           //顧客名の適否
           if(!String.IsNullOrEmpty(textBoxClName.Text.Trim()))
            {
                if (textBoxClName.TextLength > 50)
                {
                    //顧客名は50文字以下です
                    messageDsp.DspMsg("M0309");
                    textBoxClName.Focus();
                    return false;
                }
            }
            else
            {
                //顧客名が入力されていません
                messageDsp.DspMsg("M0310");
                textBoxClName.Focus();
                return false;

            }
            //住所の適否
            if (!String.IsNullOrEmpty(textBoxClAddres.Text.Trim()))
            {
                if (textBoxClAddres.TextLength > 50)
                {
                    messageDsp.DspMsg("M0318");
                    textBoxClAddres.Focus();
                    return false;
                }
            }
            else
            {
               MessageBox.Show("住所が入力されていません");
                
                textBoxClAddres.Focus();
                return false;

            }
            //電話番号の適否
            if (!String.IsNullOrEmpty(textBoxClPhone.Text.Trim()))
            {
                //電話番号の半角チェック
                if (!dataInputFormCheck.CheckNumericHyphen(textBoxClPhone.Text.Trim()))
                {
                    MessageBox.Show("電話番号は数字とハイフンのみです");
                    textBoxClPhone.Focus();
                    return false;
                }
                //文字数
                if (textBoxClPhone.TextLength > 13)
                {
                    MessageBox.Show("電話番号は13文字以下です");
                    textBoxClPhone.Focus();
                    return false;
                }
            }
            else
            {
                MessageBox.Show("電話番号が入力されていません");
                textBoxClPhone.Focus();
                return false;
            }
            //郵便番号の適否
            if (!String.IsNullOrEmpty(textBoxClPostal.Text.Trim()))
            {
                //郵便番号の半角英数字チェック
                if (!dataInputFormCheck.CheckNumeric(textBoxClPostal.Text.Trim()))
                {
                    MessageBox.Show("郵便番号は数字入力です");
                   // messageDsp.DspMsg("M0321");
                    textBoxClPostal.Focus();
                    return false;
                }
                //文字数
                if (textBoxClPostal.TextLength > 7)
                {
                    MessageBox.Show("郵便番号は7文字以下です");
                    textBoxClPostal.Focus();
                    return false;
                }
                
            }
            else
            {
                //郵便番号を入力してください
                messageDsp.DspMsg("M0322");
                textBoxClPostal.Focus();
                return false;
            }
            //FAXの適否
            if (!String.IsNullOrEmpty(textBoxClFAX.Text.Trim()))
            {
                //FAXの半角英数字チェック
                if (!dataInputFormCheck.CheckNumericHyphen(textBoxClFAX.Text.Trim()))
                {
                    MessageBox.Show("FAXは数字とハイフンのみです");
                    textBoxClFAX.Focus();
                    return false;
                }
                //文字数
                if (textBoxClFAX.TextLength > 13)
                {
                    MessageBox.Show("FAXは13文字以下です");
                    textBoxClFAX.Focus();
                    return false;
                }
            }
            else
            {
                //FAXを入力してください
                messageDsp.DspMsg("M0324");
                textBoxClFAX.Focus();
                return false;
            }
            //フラグの適否
            if (checkBoxClFlag.CheckState == CheckState.Indeterminate)
            {
                MessageBox.Show("非表示フラグが不確定の状態です");
                checkBoxClFlag.Focus();
                return false;
            }
            //非表示理由の適否
            if(checkBoxClFlag.Checked==true && String.IsNullOrEmpty(textBoxClHidden.Text.Trim()))
            {
                MessageBox.Show("非表示理由を入力してください");
                textBoxClHidden.Focus();
                return false;
            }
            return true;
        }

        ///////////////////////////////
        //　3.1.1.2 顧客情報作成
        //メソッド名：GenerateDataAtRegistration()
        //引　数   ：なし
        //戻り値   ：顧客登録情報
        //機　能   ：登録データのセット
        ///////////////////////////////
        private M_Client GenerateDataAtRegistration()
        {
            int ClFlag = 0;
            if (checkBoxClFlag.Checked == true)
            {
                ClFlag = 2;
            }

            return new M_Client
            {
                ClName = textBoxClName.Text.Trim(),
                SoID = int.Parse(comboBoxSoID.SelectedValue.ToString()),
                ClAddress=textBoxClAddres.Text.Trim(),
                ClPhone=textBoxClPhone.Text.Trim(),
                ClPostal=textBoxClPostal.Text.Trim(),
                ClFAX=textBoxClFAX.Text.Trim(),
                ClFlag=ClFlag,
                ClHidden=textBoxClHidden.Text.Trim()
            };
        }

        ///////////////////////////////
        //　3.1.1.3 顧客情報登録
        //メソッド名：RegistrationStaff()
        //引　数   ：顧客情報
        //戻り値   ：なし
        //機　能   ：顧客情報の登録
        ///////////////////////////////
        private void RegistrationStaff(M_Client regClient)
        {
            // 登録確認メッセージ
            DialogResult result = messageDsp.DspMsg("M0311");
            if (result == DialogResult.Cancel)
                return;
            // 顧客情報の登録
            bool flg = clientDataAccess.AddClientData(regClient);
            if (flg == true)
                //MessageBox.Show("データを登録しました。");
                messageDsp.DspMsg("M0312");
            else
                //MessageBox.Show("データの登録に失敗しました。");
                messageDsp.DspMsg("M0313");

            textBoxClID.Focus();

            //入力エリアのクリア

            //データグリッドビューの表示


        }

        ///////////////////////////////
        //メソッド名：SetFormDataGridView()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：データグリッドビューの設定
        ///////////////////////////////
        private void SetFormDataGridView()
        {
            //dataGridViewのページサイズ指定
            textBoxPageSize.Text = "10";
            //dataGridViewのページ番号指定
            textBoxPage.Text = "1";
            //読み取り専用に指定
            dataGridViewClient.ReadOnly = true;
            //行内をクリックすることで行を選択
            dataGridViewClient.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            //ヘッダー位置の指定
            dataGridViewClient.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //データグリッドビューのデータ取得
            GetDataGridView();

        }

        ///////////////////////////////
        //メソッド名：GetDataGridView()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：データグリッドビューに表示するデータの取得
        ///////////////////////////////
        private void GetDataGridView()
        {
            // 顧客データの取得
            Client = clientDataAccess.GetClientData();

            // DataGridViewに表示するデータを指定
            SetDataGridView();
        }

        ///////////////////////////////
        //メソッド名：SetDataGridView()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：データグリッドビューへの表示
        ///////////////////////////////
        private void SetDataGridView()
        {
            int pageSize = int.Parse(textBoxPageSize.Text);
            int pageNo = int.Parse(textBoxPage.Text) - 1;
            dataGridViewClient.DataSource = Client.Skip(pageSize * pageNo).Take(pageSize).ToList();

            //各列幅の指定 //1500
            dataGridViewClient.Columns[0].Width = 100;
            dataGridViewClient.Columns[1].Visible = false;
            dataGridViewClient.Columns[2].Width = 180;
            dataGridViewClient.Columns[3].Width = 180;
            dataGridViewClient.Columns[4].Width = 280;
            dataGridViewClient.Columns[5].Width = 110;
            dataGridViewClient.Columns[6].Width = 110;
            dataGridViewClient.Columns[7].Width = 110;
            dataGridViewClient.Columns[8].Width = 80;
            dataGridViewClient.Columns[9].Width = 360;

            //各列の文字位置の指定
            dataGridViewClient.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewClient.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewClient.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewClient.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewClient.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewClient.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewClient.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewClient.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewClient.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            //dataGridViewの総ページ数
            labelPage.Text = "/" + ((int)Math.Ceiling(Client.Count / (double)pageSize)) + "ページ";

            dataGridViewClient.Refresh();

        }
        ///////////////////////////////
        //メソッド名：buttonPageSizeChange_Click()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：データグリッドビューの表示件数変更
        ///////////////////////////////
        private void buttonPageSizeChange_Click(object sender, EventArgs e)
        {
            SetDataGridView();
        }

        ///////////////////////////////
        //メソッド名：buttonFirstPage_Click()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：データグリッドビューの先頭ページ表示
        ///////////////////////////////
        

        private void buttonFirstPage_Click_1(object sender, EventArgs e)
        {
            int pageSize = int.Parse(textBoxPageSize.Text);
            dataGridViewClient.DataSource = Client.Take(pageSize).ToList();

            // DataGridViewを更新
            dataGridViewClient.Refresh();
            //ページ番号の設定
            textBoxPage.Text = "1";
        }


        ///////////////////////////////
        //メソッド名：buttonPreviousPage_Click()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：データグリッドビューの前ページ表示
        ///////////////////////////////
        private void buttonPreviousPage_Click(object sender, EventArgs e)
        {
            int pageSize = int.Parse(textBoxPageSize.Text);
            int pageNo = int.Parse(textBoxPage.Text) - 2;
            dataGridViewClient.DataSource = Client.Skip(pageSize * pageNo).Take(pageSize).ToList();

            // DataGridViewを更新
            dataGridViewClient.Refresh();
            //ページ番号の設定
            if (pageNo + 1 > 1)
                textBoxPage.Text = (pageNo + 1).ToString();
            else
                textBoxPage.Text = "1";
        }

        ///////////////////////////////
        //メソッド名：buttonNextPage_Click()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：データグリッドビューの次ページ表示
        ///////////////////////////////

        private void buttonNextPage_Click(object sender, EventArgs e)
        {
            int pageSize = int.Parse(textBoxPageSize.Text);
            int pageNo = int.Parse(textBoxPage.Text);
            //最終ページの計算
            int lastNo = (int)Math.Ceiling(Client.Count / (double)pageSize) - 1;
            //最終ページでなければ
            if (pageNo <= lastNo)
                dataGridViewClient.DataSource = Client.Skip(pageSize * pageNo).Take(pageSize).ToList();

            // DataGridViewを更新
            dataGridViewClient.Refresh();
            //ページ番号の設定
            int lastPage = (int)Math.Ceiling(Client.Count / (double)pageSize);
            if (pageNo >= lastPage)
                textBoxPage.Text = lastPage.ToString();
            else
                textBoxPage.Text = (pageNo + 1).ToString();
        }
        ///////////////////////////////
        //メソッド名：buttonLastPage_Click()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：データグリッドビューの最終ページ表示
        ///////////////////////////////
        private void buttonLastPage_Click(object sender, EventArgs e)
        {
            int pageSize = int.Parse(textBoxPageSize.Text);
            //最終ページの計算
            int pageNo = (int)Math.Ceiling(Client.Count / (double)pageSize) - 1;
            dataGridViewClient.DataSource = Client.Skip(pageSize * pageNo).Take(pageSize).ToList();

            // DataGridViewを更新
            dataGridViewClient.Refresh();
            //ページ番号の設定
            textBoxPage.Text = (pageNo + 1).ToString();
        }
    }
}
