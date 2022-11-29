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
    public partial class FormOrder : Form
    {
        //データベース受注テーブルアクセス用クラスのインスタンス化
        OrderDataAccess orderDataAccess = new OrderDataAccess();
        //データベース営業所テーブルアクセス用クラスのインスタンス化
        SalesOfficeDataAccess salesOfficeDataAccess = new SalesOfficeDataAccess();
        //データベース顧客テーブルアクセス用クラスのインスタンス化
        ClientDataAccess clientDataAccess = new ClientDataAccess();
        //データベース社員テーブルアクセス用クラスのインスタンス化
       EmployeeDataAccess employeeDataAccess = new EmployeeDataAccess();

        //入力形式チェック用クラスのインスタンス化
        DataInputFormCheck dataInputFormCheck = new DataInputFormCheck();
        //データグリッドビュー用の受注データ
        private static List<T_OrderDsp> Order;
        //コンボボックス用の営業所データ
        private static List<M_SalesOffice> SalesOffice;

        public FormOrder()
        {
            InitializeComponent();
        }

        private void FormOrder_Load(object sender, EventArgs e)
        {
            userControlOrderDetail1.Visible = false;
            //日時の表示
            labelDay.Text = DateTime.Now.ToString("yyyy/MM/dd/(ddd)");
            labelTime.Text = DateTime.Now.ToString("HH:mm");
            //panelHeaderに表示するログインデータ
            labelUserName.Text = "ユーザー名：" + FormMain.loginName;
            labelPosition.Text = "権限:" + FormMain.loginPoName;
            labelSalesOffice.Text = FormMain.loginSoName;
            labelUserID.Text = "ユーザーID：" + FormMain.loginEmID.ToString();

            //入力項目に営業所と社員IDを入力
            comboBoxSoID.Text = FormMain.loginSoName;
            textBoxEmID.Text = FormMain.loginEmID.ToString();
            //非表示理由タブ選択不可、入力不可
            textBoxOrHidden.TabStop = false;
            textBoxOrHidden.ReadOnly = true;
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
        ///////////////受注情報登録////////////////////

        private void buttonRegist_Click(object sender, EventArgs e)
        {
            //8.1.1.1 妥当な受注データ取得
            if (!GetValidDataAtRegistration())
                return;

            //8.1.1.2 受注情報作成
            var regOrder = GenerateDataAtRegistration();

            //8.1.1.3  受注情報登録
            RegistrationOrder(regOrder);

        }
        ///////////////////////////////
        //　8.1.1.1  妥当な受注データ取得
        //メソッド名：GetValidDataAtRegistration()
        //引　数   ：なし
        //戻り値   ：true or false
        //機　能   ：入力データの形式チェック
        //          ：エラーがない場合True
        //          ：エラーがある場合False
        ///////////////////////////////
        private bool GetValidDataAtRegistration()
        {
            //受注IDの適否
            if (!String.IsNullOrEmpty(textBoxOrID.Text.Trim()))
            {
                //受注IDは入力不要です
                MessageBox.Show("受注IDは入力不要です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxOrID.Focus();
                return false;
            }

            //営業所名の選択チェック
            if (comboBoxSoID.SelectedIndex == -1)
            {
                //営業所名が選択されていません
                MessageBox.Show("営業所名が選択されていません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);

                comboBoxSoID.Focus();
                return false;
            }
            //社員IDの適否
            if (!String.IsNullOrEmpty(textBoxEmID.Text.Trim()))
            {
                //社員IDの半角数値チェック
                if (!dataInputFormCheck.CheckNumeric(textBoxEmID.Text.Trim()))
                {
                    MessageBox.Show("社員IDは半角数値入力です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxEmID.Focus();
                    return false;
                }
                //文字数
                if (textBoxEmID.TextLength > 6)
                {
                    MessageBox.Show("顧客IDは6文字以下です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxEmID.Focus();
                    return false;
                }

                // 社員IDの存在チェック
                if (!employeeDataAccess.CheckEmIDExistence(int.Parse(textBoxEmID.Text.Trim())))
                {
                    MessageBox.Show("入力された社員IDは存在しません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxEmID.Focus();
                    return false;
                }

            }
            else
            {
                MessageBox.Show("社員ID が入力されていません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxEmID.Focus();
                return false;
            }
            //顧客IDの適否
            if (!String.IsNullOrEmpty(textBoxClID.Text.Trim()))
            {
                //顧客IDの半角数値チェック
                if (!dataInputFormCheck.CheckNumeric(textBoxClID.Text.Trim()))
                {
                    MessageBox.Show("顧客IDは半角数値入力です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxClID.Focus();
                    return false;
                }
                //文字数
                if (textBoxClID.TextLength > 6)
                {
                    MessageBox.Show("顧客IDは6文字以下です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxClID.Focus();
                    return false;
                }

                // 顧客IDの存在チェック
                if (!clientDataAccess.CheckClIDExistence(int.Parse(textBoxClID.Text.Trim())))
                {
                    MessageBox.Show("入力された顧客IDは存在しません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxClID.Focus();
                    return false;
                }

            }
            else
            {
                MessageBox.Show("顧客ID が入力されていません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxClID.Focus();
                return false;
            }
            //顧客担当者名の適否
            if (!String.IsNullOrEmpty(textBoxClCharge.Text.Trim()))
            {
                if (textBoxClCharge.TextLength > 50)
                {
                    MessageBox.Show("顧客担当者名は50文字以下です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxClCharge.Focus();
                    return false;
                }
            }
            else
            {
                MessageBox.Show("顧客担当者名が入力されていません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxClCharge.Focus();
                return false;

            }
            //受注日の選択チェック
            if (DateTimePickerOrDate.Checked == false)
            {
                //受注日が選択されていません
                MessageBox.Show("受注日が選択されていません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);

               　DateTimePickerOrDate.Focus();
                return false;
            }
            //フラグの適否
            if (checkBoxOrFlag.CheckState == CheckState.Indeterminate)
            {
                MessageBox.Show("非表示フラグが不確定の状態です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);

                checkBoxOrFlag.Focus();
                return false;
            }
            if (checkBoxOrFlag.Checked == true)
            {
                MessageBox.Show("非表示フラグがチェックされています", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                checkBoxOrFlag.Focus();
                return false;
            }
            //非表示理由の適否
            if (!String.IsNullOrEmpty(textBoxOrHidden.Text.Trim()))
            {
                MessageBox.Show("非表示理由は登録できません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxOrHidden.Focus();
                return false;
            }
            //受注確定フラグの適否
            if (checkBoxStateFlag.CheckState == CheckState.Indeterminate)
            {
                MessageBox.Show("受注確定フラグが不確定の状態です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);

                checkBoxStateFlag.Focus();
                return false;

            }
            if (checkBoxStateFlag.Checked == true)
            {
                MessageBox.Show("受注確定フラグがチェックされています", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                checkBoxStateFlag.Focus();
                return false;
            }


            return true;
        }
        ///////////////////////////////
        //　8.1.1.2 受注情報作成
        //メソッド名：GenerateDataAtRegistration()
        //引　数   ：なし
        //戻り値   ：受注登録情報
        //機　能   ：登録データのセット
        ///////////////////////////////
        private T_Order GenerateDataAtRegistration()
        {
            
            return new T_Order
            {
                
                SoID= int.Parse(comboBoxSoID.SelectedValue.ToString()),
                EmID =int.Parse(textBoxEmID.Text.Trim()),
                ClID= int.Parse(textBoxClID.Text.Trim()),
                ClCharge=textBoxClCharge.Text.Trim(),
                OrDate=DateTimePickerOrDate.Value,
                OrFlag=0,
                OrHidden=textBoxOrHidden.Text.Trim(),
                OrStateFlag=0
            };
        }
        ///////////////////////////////
        //　8.1.1.3 受注情報登録
        //メソッド名：RegistrationOrder()
        //引　数   ：受注情報
        //戻り値   ：なし
        //機　能   ：受注情報の登録
        ///////////////////////////////
        private void RegistrationOrder(T_Order regOrder)
        {
            // 登録確認メッセージ
            DialogResult result = MessageBox.Show("受注データを登録してよろしいですか?", "追加確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Cancel)
                return;
            // 受注情報の登録
            bool flg = orderDataAccess.AddOrderData(regOrder);
            if (flg == true)
                MessageBox.Show("データを登録しました","追加確認", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("データの登録に失敗しました", "追加確認", MessageBoxButtons.OK, MessageBoxIcon.Error);

            textBoxOrID.Focus();

            //入力エリアのクリア
            //ClearInput();
            //データグリッドビューの表示
            GetDataGridView();
            //受注詳細画面に移動

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
            textBoxPageSize.Text = "20";
            //dataGridViewのページ番号指定
            textBoxPage.Text = "1";
            //読み取り専用に指定
            dataGridViewOrder.ReadOnly = true;
            //直接のサイズの変更を不可
            dataGridViewOrder.AllowUserToResizeRows = false;
            dataGridViewOrder.AllowUserToResizeColumns = false;
            //直接の登録を不可にする
            dataGridViewOrder.AllowUserToAddRows = false;
            //行内をクリックすることで行を選択
            dataGridViewOrder.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //奇数行の色を変更
            dataGridViewOrder.AlternatingRowsDefaultCellStyle.BackColor = Color.Honeydew;
            //ヘッダー位置の指定
            dataGridViewOrder.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

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
            // 受注データの取得
            Order = orderDataAccess.GetOrderData();

            // DataGridViewに表示するデータを指定
            SetDataGridView();

        }
        ///////////////////////////////
        //メソッド名：GetHiddenDataGridView()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：データグリッドビューに表示する非表示データの取得
        ///////////////////////////////
        private void GetHiddenDataGridView()
        {
            Order = orderDataAccess.GetOrderHiddenData();

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
            dataGridViewOrder.DataSource = Order.Skip(pageSize * pageNo).Take(pageSize).ToList();
            //各列幅の指定 //1500
            dataGridViewOrder.Columns[0].Width = 100;
            dataGridViewOrder.Columns[1].Width = 100;
            dataGridViewOrder.Columns[2].Width = 100;
            dataGridViewOrder.Columns[3].Width = 100;
            dataGridViewOrder.Columns[4].Width = 100;
            dataGridViewOrder.Columns[5].Width = 100;
            dataGridViewOrder.Columns[6].Width = 100;
            dataGridViewOrder.Columns[7].Width = 100;
            dataGridViewOrder.Columns[8].Width = 100;
            dataGridViewOrder.Columns[9].Width = 100;
            dataGridViewOrder.Columns[10].Width = 100;
            dataGridViewOrder.Columns[11].Width = 100;

            //各列の文字位置の指定
            dataGridViewOrder.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewOrder.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewOrder.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewOrder.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewOrder.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewOrder.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewOrder.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewOrder.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewOrder.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewOrder.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewOrder.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewOrder.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            //dataGridViewの総ページ数
            labelPage.Text = "/" + ((int)Math.Ceiling(Order.Count / (double)pageSize)) + "ページ";




            dataGridViewOrder.Refresh();

        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            //ボタン確定処理

        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {

        }

        private void buttonList_Click(object sender, EventArgs e)
        {

        }

        private void buttonSaisyou_Click(object sender, EventArgs e)
        {

        }

        private void buttonFormDel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            FormLogin formLogin = new FormLogin();
            FormMain formMain = new FormMain();
            formLogin.Show();
            this.Visible = false;
            formMain.Close();
        }

        private void textBoxPrName_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonDetail_Click(object sender, EventArgs e)
        {
            if(labelOrder.Text == "受注管理")
            {
                labelOrder.Text = "受注詳細管理";
                buttonDetail.Text = "受注管理";
                userControlOrderDetail1.Visible = true;
                panelOrder.Visible = false;
                return;
            }
            if (labelOrder.Text == "受注詳細管理")
            {
                labelOrder.Text = "受注管理";
                buttonDetail.Text = "受注詳細";
                panelOrder.Visible = true;
                userControlOrderDetail1.Visible = false;
            }



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
        //メソッド名：buttonLastPage_Click()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：データグリッドビューの最終ページ表示
        ///////////////////////////////

        private void buttonLastPage_Click(object sender, EventArgs e)
        {
            int pageSize = int.Parse(textBoxPageSize.Text);
            //最終ページの計算
            int pageNo = (int)Math.Ceiling(Order.Count / (double)pageSize) - 1;
            dataGridViewOrder.DataSource = Order.Skip(pageSize * pageNo).Take(pageSize).ToList();

            // DataGridViewを更新
            dataGridViewOrder.Refresh();
            //ページ番号の設定
            textBoxPage.Text = (pageNo + 1).ToString();

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
            int lastNo = (int)Math.Ceiling(Order.Count / (double)pageSize) - 1;
            //最終ページでなければ
            if (pageNo <= lastNo)
                dataGridViewOrder.DataSource = Order.Skip(pageSize * pageNo).Take(pageSize).ToList();

            // DataGridViewを更新
            dataGridViewOrder.Refresh();
            //ページ番号の設定
            int lastPage = (int)Math.Ceiling(Order.Count / (double)pageSize);
            if (pageNo >= lastPage)
                textBoxPage.Text = lastPage.ToString();
            else
                textBoxPage.Text = (pageNo + 1).ToString();

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
            dataGridViewOrder.DataSource = Order.Skip(pageSize * pageNo).Take(pageSize).ToList();

            // DataGridViewを更新
            dataGridViewOrder.Refresh();
            //ページ番号の設定
            if (pageNo + 1 > 1)
                textBoxPage.Text = (pageNo + 1).ToString();
            else
                textBoxPage.Text = "1";

        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            //日時更新
            labelDay.Text = DateTime.Now.ToString("yyyy/MM/dd/(ddd)");
            labelTime.Text = DateTime.Now.ToString("HH:mm");
        }

        private void buttonHidden_Click(object sender, EventArgs e)
        {

        }




        private void userControlOrderDetail1_Load(object sender, EventArgs e)
        {

        }


        private void checkBoxOrFlag_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxOrFlag.Checked == true)
            {
                textBoxOrHidden.TabStop = true;
                textBoxOrHidden.ReadOnly = false;
            }
            else
            {
                textBoxOrHidden.Text = "";
                textBoxOrHidden.TabStop = false;
                textBoxOrHidden.ReadOnly = true;

            }

        }
        ///////////////////////////////
        //メソッド名：buttonFirstPage_Click()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：データグリッドビューの先頭ページ表示
        ///////////////////////////////

        private void buttonFirstPage_Click(object sender, EventArgs e)
        {
            int pageSize = int.Parse(textBoxPageSize.Text);
            dataGridViewOrder.DataSource = Order.Take(pageSize).ToList();

            // DataGridViewを更新
            dataGridViewOrder.Refresh();
            //ページ番号の設定
            textBoxPage.Text = "1";

        }
    }
}
