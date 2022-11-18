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
            //非表示理由タブ選択不可、入力不可
            textBoxClHidden.TabStop = false;
            textBoxClHidden.ReadOnly = true;
            //日時の表示
            labelDay.Text = DateTime.Now.ToString("yyyy/MM/dd/(ddd)");
            labelTime.Text = DateTime.Now.ToString("HH:mm");
            labelUserName.Text = "ユーザー名：" + FormMain.loginName;
            labelPosition.Text = "権限:" + FormMain.loginPoName;
            labelSalesOffice.Text = FormMain.loginSoName;
            labelUserID.Text = "ユーザーID：" + FormMain.loginEmID.ToString();

            
           
            //コンボボックスの設定
            SetFormComboBox();

            //データグリッドビューの設定
            SetFormDataGridView(0);
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

        //顧客情報登録
        
        private void buttonRegist_Click(object sender, EventArgs e)
        {
            //  妥当な顧客データ取得
            if (!GetValidDataAtRegistration())
                return;

            //  顧客情報作成
            var regClient = GenerateDataAtRegistration();

            // 顧客情報登録
            RegistrationStaff(regClient );

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
            //顧客IDの適否
            if (!String.IsNullOrEmpty(textBoxClID.Text.Trim()))
            {
                //顧客IDは入力不要です
                MessageBox.Show("顧客IDは入力不要です","入力確認",MessageBoxButtons.OK,MessageBoxIcon.Error);
                textBoxClID.Focus();
                return false;
            }
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
           
            //電話番号の適否
            if (!String.IsNullOrEmpty(textBoxClPhone.Text.Trim()))
            {
                //電話番号の半角数値ハイフンチェック
                if (!dataInputFormCheck.CheckNumericHyphen(textBoxClPhone.Text.Trim()))
                {
                    MessageBox.Show("電話番号の入力形式が正しくありません","入力確認",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    textBoxClPhone.Focus();
                    return false;
                }
                //文字数
                if (textBoxClPhone.TextLength > 13)
                {
                    MessageBox.Show("電話番号は13文字以下です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxClPhone.Focus();
                    return false;
                }
            }
            else
            {
                MessageBox.Show("電話番号が入力されていません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxClPhone.Focus();
                return false;
            }
            
            //FAXの適否
            if (!String.IsNullOrEmpty(textBoxClFAX.Text.Trim()))
            {
                //FAXの半角英数字チェック
                if (!dataInputFormCheck.CheckNumericHyphen(textBoxClFAX.Text.Trim()))
                {
                    MessageBox.Show("FAXの入力形式が正しくありません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxClFAX.Focus();
                    return false;
                }
                //文字数
                if (textBoxClFAX.TextLength > 13)
                {
                    MessageBox.Show("FAXは13文字以下です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            //郵便番号の適否
            if (!String.IsNullOrEmpty(textBoxClPostal.Text.Trim()))
            {
                //郵便番号の半角英数字チェック
                if (!dataInputFormCheck.CheckNumeric(textBoxClPostal.Text.Trim()))
                {
                    //MessageBox.Show("郵便番号は半角数値です");
                     messageDsp.DspMsg("M0321");
                    textBoxClPostal.Focus();
                    return false;
                }
                //文字数
                if (textBoxClPostal.TextLength !=7)
                {
                    //MessageBox.Show("郵便番号は7文字です");
                    messageDsp.DspMsg("M0320");
                    textBoxClPostal.Focus();
                    return false;
                }

            }
            else
            {
                //郵便番号が入力されていません
                messageDsp.DspMsg("M0322");
                textBoxClPostal.Focus();
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
                //MessageBox.Show("住所が入力されていません");
                messageDsp.DspMsg("M0319");
                textBoxClAddres.Focus();
                return false;

            }

            //フラグの適否
            if (checkBoxClFlag.CheckState == CheckState.Indeterminate)
            {
                //MessageBox.Show("非表示フラグが不確定の状態です");
                messageDsp.DspMsg("M0326");

                checkBoxClFlag.Focus();
                return false;
            }
            if (checkBoxClFlag.Checked == true)
            {
                MessageBox.Show("非表示フラグがチェックされています", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                checkBoxClFlag.Focus();
                return false;
            }
            //非表示理由の適否
            if (!String.IsNullOrEmpty(textBoxClHidden.Text.Trim()))
            {
                MessageBox.Show("非表示理由は登録できません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            ClearInput();
            //データグリッドビューの表示
            SetFormDataGridView(0);

        }

        ///////////////////////////////
        //メソッド名：SetFormDataGridView()
        //引　数   ：flg
        //戻り値   ：なし
        //機　能   ：データグリッドビューの設定
        ///////////////////////////////
        private void SetFormDataGridView(int flg)
        {
            //dataGridViewのページサイズ指定
            textBoxPageSize.Text = "10";
            //dataGridViewのページ番号指定
            textBoxPage.Text = "1";
            //読み取り専用に指定
            dataGridViewClient.ReadOnly = true;
            //直接のサイズの変更を不可
            dataGridViewClient.AllowUserToResizeRows = false;
            dataGridViewClient.AllowUserToResizeColumns = false;
            //直接の登録を不可にする
            dataGridViewClient.AllowUserToAddRows = false;
            //行内をクリックすることで行を選択
            dataGridViewClient.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //奇数行の色を変更
            dataGridViewClient.AlternatingRowsDefaultCellStyle.BackColor = Color.Honeydew;
            //ヘッダー位置の指定
            dataGridViewClient.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            if (flg == 0)
            {
                //データグリッドビューのデータ取得
                GetDataGridView();
            }
            else if(flg==1)
            {
                //データグリッドビューのデータ取得
                GetHiddenDataGridView();
            }

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
        //メソッド名：GetDataHiddenGridView()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：データグリッドビューに表示するデータの取得
        ///////////////////////////////
        private void GetHiddenDataGridView()
        {
            // 顧客データの取得
            Client = clientDataAccess.GetClientHiddenData();

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
            dataGridViewClient.Columns[4].Width = 110;
            dataGridViewClient.Columns[5].Width = 110;
            dataGridViewClient.Columns[6].Width = 110;
            dataGridViewClient.Columns[7].Width = 280;
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
        //メソッド名：buttonPageSizeChange_Click_1()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：データグリッドビューの表示件数変更
        ///////////////////////////////
        private void buttonPageSizeChange_Click_1(object sender, EventArgs e)
        {
            SetDataGridView();
        }
        ///////////////////////////////
        //メソッド名：buttonFirstPage_Click_1()
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
       
        ///////////////////////////////
        //メソッド名：ClearInput()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：入力エリアをクリア
        ///////////////////////////////
        private void ClearInput()
        {
            textBoxClID.Text = "";
            comboBoxSoID.SelectedIndex = -1;
            textBoxClName.Text = "";
            textBoxClAddres.Text = "";
            textBoxClPhone.Text = "";
            textBoxClPostal.Text = "";
            textBoxClFAX.Text = "";
            checkBoxClFlag.Checked = false;
            textBoxClHidden.Text = "";
        }

        //顧客情報更新
        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            // 3.2.1.1 妥当な顧客データ取得
            if (!GetValidDataAtUpdate())
                return;

            // 3.2.1.2　顧客情報作成
            var updClient = GenerateDataAtUpdate();

            // 3.2.1.3 顧客情報更新
            UpdateStaff(updClient);
        }

        ///////////////////////////////
        //  3.2.1.1 妥当な顧客データ取得
        //メソッド名：GetValidDataAtUpdate()
        //引　数   ：なし
        //戻り値   ：true or false
        //機　能   ：入力データの形式チェック
        //          ：エラーがない場合True
        //          ：エラーがある場合False
        ///////////////////////////////
        private bool GetValidDataAtUpdate()
        {
            //顧客IDの適否
            if (!String.IsNullOrEmpty(textBoxClID.Text.Trim()))
            {
                //顧客IDの半角数値チェック
                if (!dataInputFormCheck.CheckNumeric(textBoxClID.Text.Trim()))
                {
                    MessageBox.Show("顧客IDは半角数値入力です", "入力確認",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    textBoxClID.Focus();
                    return false;
                }
                //文字数
                if (textBoxClID.TextLength > 6)
                {
                    //MessageBox.Show("顧客IDは6文字以下です");
                    messageDsp.DspMsg("M0302");
                    textBoxClID.Focus();
                    return false;
                }

                // 顧客IDの存在チェック
                if (!clientDataAccess.CheckClIDExistence(int.Parse(textBoxClID.Text.Trim())))
                {
                    //MessageBox.Show("入力された顧客IDは存在しません");
                    messageDsp.DspMsg("M0314");
                    textBoxClID.Focus();
                    return false;
                }

            }
            else
            {
                //MessageBox.Show("顧客ID が入力されていません");
                messageDsp.DspMsg("M0304");
                textBoxClID.Focus();
                return false;
            }

            //営業所名の選択チェック
            if (comboBoxSoID.SelectedIndex == -1)
            {
                //営業所名が選択されていません
                messageDsp.DspMsg("M0307");
                comboBoxSoID.Focus();
                return false;

            }

            //顧客名の適否
            if (!String.IsNullOrEmpty(textBoxClName.Text.Trim()))
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
            //電話番号の適否
            if (!String.IsNullOrEmpty(textBoxClPhone.Text.Trim()))
            {
                //電話番号の半角数値ハイフンチェック
                if (!dataInputFormCheck.CheckNumericHyphen(textBoxClPhone.Text.Trim()))
                {
                    MessageBox.Show("電話番号の入力形式が正しくありません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxClPhone.Focus();
                    return false;
                }
                //文字数
                if (textBoxClPhone.TextLength > 13)
                {
                    MessageBox.Show("電話番号は13文字以下です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxClPhone.Focus();
                    return false;
                }
            }
            else
            {
                MessageBox.Show("電話番号が入力されていません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxClPhone.Focus();
                return false;
            }
            //FAXの適否
            if (!String.IsNullOrEmpty(textBoxClFAX.Text.Trim()))
            {
                //FAXの半角英数字チェック
                if (!dataInputFormCheck.CheckNumericHyphen(textBoxClFAX.Text.Trim()))
                {
                    MessageBox.Show("FAXの入力形式が正しくありません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxClFAX.Focus();
                    return false;
                }
                //文字数
                if (textBoxClFAX.TextLength > 13)
                {
                    MessageBox.Show("FAXは13文字以下です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            //郵便番号の適否
            if (!String.IsNullOrEmpty(textBoxClPostal.Text.Trim()))
            {
                //郵便番号の半角英数字チェック
                if (!dataInputFormCheck.CheckNumeric(textBoxClPostal.Text.Trim()))
                {
                    //MessageBox.Show("郵便番号は半角数値入力です");
                     messageDsp.DspMsg("M0321");
                    textBoxClPostal.Focus();
                    return false;
                }
                //文字数
                if (textBoxClPostal.TextLength != 7)
                {
                    //MessageBox.Show("郵便番号は7文字です");
                    messageDsp.DspMsg("M0320");

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
                //MessageBox.Show("住所が入力されていません");
                messageDsp.DspMsg("M0319");
                textBoxClAddres.Focus();
                return false;

            }
            //フラグの適否
            if (checkBoxClFlag.CheckState == CheckState.Indeterminate)
            {
                //MessageBox.Show("非表示フラグが不確定の状態です");
                messageDsp.DspMsg("M0326");
                checkBoxClFlag.Focus();
                return false;
            }
            //非表示理由の適否
            if (checkBoxClFlag.Checked == true && String.IsNullOrEmpty(textBoxClHidden.Text.Trim()))
            {
                MessageBox.Show("非表示理由が入力されていません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxClHidden.Focus();
                return false;
            }

            return true;
        }

        ///////////////////////////////
        //　3.2.1.2 顧客情報作成
        //メソッド名：GenerateDataAtUpdate()
        //引　数   ：なし
        //戻り値   ：顧客更新情報
        //機　能   ：更新データのセット
        ///////////////////////////////
        private M_Client GenerateDataAtUpdate()
        {
            int ClFlag = 0;
            if (checkBoxClFlag.Checked == true)
            {
                ClFlag = 2;
            }

            return new M_Client
            {
                ClID=int.Parse(textBoxClID.Text.Trim()),
                ClName = textBoxClName.Text.Trim(),
                SoID = int.Parse(comboBoxSoID.SelectedValue.ToString()),
                ClAddress = textBoxClAddres.Text.Trim(),
                ClPhone = textBoxClPhone.Text.Trim(),
                ClPostal = textBoxClPostal.Text.Trim(),
                ClFAX = textBoxClFAX.Text.Trim(),
                ClFlag = ClFlag,
                ClHidden = textBoxClHidden.Text.Trim()
            };
        }

        ///////////////////////////////
        //　3.2.1.3 顧客情報更新
        //メソッド名：UpdateStaff()
        //引　数   ：顧客情報
        //戻り値   ：なし
        //機　能   ：顧客情報の更新
        ///////////////////////////////
        private void UpdateStaff(M_Client updClient)
        {
            // 更新確認メッセージ
            DialogResult result = messageDsp.DspMsg("M0315");
            if (result == DialogResult.Cancel)
                return;

            // スタッフ情報の更新
            bool flg = clientDataAccess.UpdateClientData(updClient);
            if (flg == true)
                //MessageBox.Show("データを更新しました。");
                messageDsp.DspMsg("M0316");
            else
                //MessageBox.Show("データの更新に失敗しました。");
                messageDsp.DspMsg("M0317");

            textBoxClID.Focus();

            // 入力エリアのクリア
            ClearInput();

            // データグリッドビューの表示
            GetDataGridView();
        }


        //顧客情報検索
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            
            //妥当な顧客データ取得
            if (!GetValidDataAtSelect())
                return;

            // 顧客情報抽出
            GenerateDataAtSelect();

            //  顧客抽出結果表示
            SetSelectData();

        }

        ///////////////////////////////
        //　3.4.1.1 妥当な顧客データ取得
        //メソッド名：GetValidDataAtSlect()
        //引　数   ：なし
        //戻り値   ：true or false
        //機　能   ：入力データの形式チェック
        //          ：エラーがない場合True
        //          ：エラーがある場合False
        ///////////////////////////////
        private bool GetValidDataAtSelect()
        {
            //顧客IDの適否
            if (!String.IsNullOrEmpty(textBoxClID.Text.Trim()))
            {
                //文字チェック
                if (!dataInputFormCheck.CheckNumeric(textBoxClID.Text.Trim()))
                {
                    MessageBox.Show("顧客IDは半角数値入力です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxClID.Focus();
                    return false;
                }
                //文字数
                if (textBoxClID.TextLength > 6)
                {
                    //MessageBox.Show("顧客IDは6文字以下です");
                    messageDsp.DspMsg("M0302");
                    textBoxClID.Focus();
                    return false;
                }
                // 顧客IDの存在チェック
                if (!clientDataAccess.CheckClIDExistence(int.Parse(textBoxClID.Text.Trim())))
                {
                    //MessageBox.Show("入力された顧客IDは存在しません");
                    messageDsp.DspMsg("M0314");
                    textBoxClID.Focus();
                    return false;
                }

            }
            
            //顧客名の適否
            if (!String.IsNullOrEmpty(textBoxClName.Text.Trim()))
            {
                if (textBoxClName.TextLength > 50)
                {
                    //顧客名は50文字以下です
                    messageDsp.DspMsg("M0309");
                    textBoxClName.Focus();
                    return false;
                }
            }
            //電話番号の適否
            if (!String.IsNullOrEmpty(textBoxClPhone.Text.Trim()))
            {
                //電話番号の半角数値ハイフンチェック
                if (!dataInputFormCheck.CheckNumericHyphen(textBoxClPhone.Text.Trim()))
                {
                    MessageBox.Show("電話番号の入力形式が正しくありません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxClPhone.Focus();
                    return false;
                }
                //文字数
                if (textBoxClPhone.TextLength > 13)
                {
                    MessageBox.Show("電話番号は13文字以下です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxClPhone.Focus();
                    return false;
                }
            }
            //FAXの適否
            if (!String.IsNullOrEmpty(textBoxClFAX.Text.Trim()))
            {
                //FAXの半角英数字チェック
                if (!dataInputFormCheck.CheckNumericHyphen(textBoxClFAX.Text.Trim()))
                {
                    MessageBox.Show("FAXの入力形式が正しくありません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxClFAX.Focus();
                    return false;
                }
                //文字数
                if (textBoxClFAX.TextLength > 13)
                {
                    MessageBox.Show("FAXは13文字以下です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxClFAX.Focus();
                    return false;
                }
            }
            //郵便番号の適否
            if (!String.IsNullOrEmpty(textBoxClPostal.Text.Trim()))
            {
                //郵便番号の半角数値チェック
                if (!dataInputFormCheck.CheckNumeric(textBoxClPostal.Text.Trim()))
                {
                    MessageBox.Show("郵便番号は半角数値入力です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    // messageDsp.DspMsg("M0321");
                    textBoxClPostal.Focus();
                    return false;
                }
                //文字数
                if (textBoxClPostal.TextLength != 7)
                {
                    MessageBox.Show("郵便番号は7文字です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxClPostal.Focus();
                    return false;
                }

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

            return true;
        }

        ///////////////////////////////
        //　3.4.1.2 顧客情報抽出
        //メソッド名：GenerateDataAtSelect()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：検索データの取得
        ///////////////////////////////
        private void GenerateDataAtSelect()
        {
            // コンボボックスが未選択の場合Emptyを設定
            string cSalesOffice = "";
            if (comboBoxSoID.SelectedIndex != -1)
                cSalesOffice =comboBoxSoID.SelectedValue.ToString();

            //検索条件のセット
            //顧客IDが入力されていて、営業所も選択されている場合
            if (!String.IsNullOrEmpty(textBoxClID.Text.Trim())&&cSalesOffice!="")
            {
                M_ClientDsp selectCondition = new M_ClientDsp()
                {
                    ClID = int.Parse(textBoxClID.Text.Trim()),
                    SoID = int.Parse(cSalesOffice),
                    ClName = textBoxClName.Text,
                    ClAddress = textBoxClAddres.Text,
                    ClPhone = textBoxClPhone.Text,
                    ClPostal = textBoxClPostal.Text,
                    ClFAX = textBoxClFAX.Text,
                };

                //顧客データの抽出
               Client= clientDataAccess.GetClientData(1,selectCondition);
            }

            //顧客IDが入力されていて、営業所が未選択の場合
            else if(!String.IsNullOrEmpty(textBoxClID.Text.Trim())&&cSalesOffice =="")
            {
                M_ClientDsp selectCondition = new M_ClientDsp()
                {
                    ClID = int.Parse(textBoxClID.Text.Trim()),
                    ClName = textBoxClName.Text,
                    ClAddress = textBoxClAddres.Text,
                    ClPhone = textBoxClPhone.Text,
                    ClPostal = textBoxClPostal.Text,
                    ClFAX = textBoxClFAX.Text,
                };

                //顧客データの抽出
               Client= clientDataAccess.GetClientData(2,selectCondition);
            }

            //顧客IDが未入力で、営業所が選択されている場合
            else if(cSalesOffice != "")
            {
                M_ClientDsp selectCondition = new M_ClientDsp()
                {
                    SoID = int.Parse(cSalesOffice),
                    ClName = textBoxClName.Text,
                    ClAddress = textBoxClAddres.Text,
                    ClPhone = textBoxClPhone.Text,
                    ClPostal = textBoxClPostal.Text,
                    ClFAX = textBoxClFAX.Text,
                };

                //顧客データの抽出
               Client= clientDataAccess.GetClientData(3,selectCondition);
            }

            //顧客IDが未入力で、営業所も未選択の場合
            else 
            {
                M_ClientDsp selectCondition = new M_ClientDsp()
                {                  
                    ClName = textBoxClName.Text,
                    ClAddress = textBoxClAddres.Text,
                    ClPhone = textBoxClPhone.Text,
                    ClPostal = textBoxClPostal.Text,
                    ClFAX = textBoxClFAX.Text,
                };

                //顧客データの抽出
                Client = clientDataAccess.GetClientData(4,selectCondition);
            }

        }

        ///////////////////////////////
        //　3.4.1.3 顧客抽出結果表示
        //メソッド名：SetSelectData()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：顧客情報の表示
        ///////////////////////////////
        private void SetSelectData()
        {
            textBoxPage.Text = "1";

            int pageSize = int.Parse(textBoxPageSize.Text);

            dataGridViewClient.DataSource = Client;
            if (Client.Count == 0)
            {
                MessageBox.Show("該当データが存在しません","エラー",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

            labelPage.Text = "/" + ((int)Math.Ceiling(Client.Count / (double)pageSize)) + "ページ";
            dataGridViewClient.Refresh();

          
        }

        ///////////////////////////////
        //メソッド名：dataGridViewClient_CellClick()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：データグリッドビューから選択された情報を各入力エリアにセット
        ///////////////////////////////
        private void dataGridViewClient_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            //データグリッドビューからクリックされたデータを各入力エリアへ
            textBoxClID.Text = dataGridViewClient.Rows[dataGridViewClient.CurrentRow.Index].Cells[0].Value.ToString();
            comboBoxSoID.Text = dataGridViewClient.Rows[dataGridViewClient.CurrentRow.Index].Cells[2].Value.ToString();
            textBoxClName.Text = dataGridViewClient.Rows[dataGridViewClient.CurrentRow.Index].Cells[3].Value.ToString();
            textBoxClAddres.Text = dataGridViewClient.Rows[dataGridViewClient.CurrentRow.Index].Cells[4].Value.ToString();
            textBoxClPhone.Text = dataGridViewClient.Rows[dataGridViewClient.CurrentRow.Index].Cells[5].Value.ToString();
            textBoxClPostal.Text = dataGridViewClient.Rows[dataGridViewClient.CurrentRow.Index].Cells[6].Value.ToString();
            textBoxClFAX.Text = dataGridViewClient.Rows[dataGridViewClient.CurrentRow.Index].Cells[7].Value.ToString();
            //flagの値の「0」「2」をbool型に変換してチェックボックスに表示させる
            if (dataGridViewClient.Rows[dataGridViewClient.CurrentRow.Index].Cells[8].Value.ToString() != 2.ToString())
            {
                checkBoxClFlag.Checked = false;
            }
            else
            {
                checkBoxClFlag.Checked = true;
            }
            //非表示理由がnullではない場合テキストボックスに表示させる
            if(dataGridViewClient.Rows[dataGridViewClient.CurrentRow.Index].Cells[9].Value != null)
            {
                textBoxClHidden.Text = dataGridViewClient.Rows[dataGridViewClient.CurrentRow.Index].Cells[9].Value.ToString();
            }
        }

        ///////////////////////////////
        //メソッド名：buttonList_Click()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：顧客データの一覧表示機能
        ///////////////////////////////
        private void buttonList_Click(object sender, EventArgs e)
        {
            // 入力エリアのクリア
            ClearInput();
            //データグリッドビューの表示
            SetFormDataGridView(0);
        }

        private void buttonHinaDel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            ClearInput();
        }

        private void buttonHiddenList_Click(object sender, EventArgs e)
        {           
            //データグリッドビューの表示
            SetFormDataGridView(1);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            //日時更新
            labelDay.Text = DateTime.Now.ToString("yyyy/MM/dd/(ddd)");
            labelTime.Text = DateTime.Now.ToString("HH:mm");
        }

        private void checkBoxClFlag_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxClFlag.Checked == true)
            {
                textBoxClHidden.TabStop = true;
                textBoxClHidden.ReadOnly = false;
            }
            else
            {
                textBoxClHidden.Text = "";
                textBoxClHidden.TabStop = false;
                textBoxClHidden.ReadOnly = true;
            }
        }
    }
}
