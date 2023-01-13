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
    public partial class FormEmployee : Form
    {
        //メッセージ表示用クラスのインスタンス化
        MessageDsp messageDsp = new MessageDsp();
        //データベース社員テーブルアクセス用クラスのインスタンス化
        EmployeeDataAccess employeeDataAccess = new EmployeeDataAccess();
        //データベース営業所テーブルアクセス用クラスのインスタンス化
        SalesOfficeDataAccess salesOfficeDataAccess = new SalesOfficeDataAccess();
        //データベース役職テーブルアクセス用クラスのインスタンス化
        PositionDataAccess positionDataAccess = new PositionDataAccess();
        //パスワードハッシュ用クラスのインスタンス化
        PasswordHash passwordHash = new PasswordHash();
        //入力形式チェック用クラスのインスタンス化
        DataInputFormCheck dataInputFormCheck = new DataInputFormCheck();
        //データグリッドビュー用の社員データ
        private static List<M_EmployeeDsp> Employee;
        //コンボボックス用の営業所データ
        private static List<M_SalesOffice> SalesOffice;
        //コンボボックス用の役職データ
        private static List<M_Position> Position;
        public FormEmployee()
        {
            InitializeComponent();
        }

        private void FormEmployee_Load(object sender, EventArgs e)
        {
            //日時の表示
            labelDay.Text = DateTime.Now.ToString("yyyy/MM/dd/(ddd)");
            labelTime.Text = DateTime.Now.ToString("HH:mm");
            //panelHeaderに表示するログインデータ
            labelUserName.Text = "ユーザー名：" + FormMain.loginName;
            labelPosition.Text = "権限:" + FormMain.loginPoName;
            labelSalesOffice.Text = FormMain.loginSoName;
            labelUserID.Text = "ユーザーID：" + FormMain.loginEmID.ToString();
            panel2.Visible = true;
            panelSetting.Visible = false;
            userControlPosition1.Visible = false;
            userControlSalesOffice1.Visible = false;
            //デートタイムピッカの設定
            SetFormDateTimePiker();
            //コンボボックスの設定
            SetFormComboBox();
            //データグリッドビューの表示
            SetFormDataGridView();


        }
        private void SetFormDateTimePiker()
        {
            dateTimePickerHiredate.Value = DateTime.Now;
            dateTimePickerHiredate.Checked = false;
        }
        ///////////////////////////////
        //メソッド名：SetFormComboBox()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：コンボボックスのデータ設定
        ///////////////////////////////
        private void SetFormComboBox()
        {
            // 役職データの取得
            Position = positionDataAccess.GetPositionDspData();
            comboBoxPoID.DataSource = Position;
            comboBoxPoID.DisplayMember = "PoName";
            comboBoxPoID.ValueMember = "PoID";
            // コンボボックスを読み取り専用
            comboBoxPoID.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxPoID.SelectedIndex = -1;

            // 部署データの取得
            SalesOffice = salesOfficeDataAccess.GetSalesOfficeDspData();
            comboBoxSoID.DataSource = SalesOffice;
            comboBoxSoID.DisplayMember = "SoName";
            comboBoxSoID.ValueMember = "SoID";
            // コンボボックスを読み取り専用
            comboBoxSoID.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxSoID.SelectedIndex = -1;

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
            dataGridViewEmployee.ReadOnly = true;
            //直接のサイズの変更を不可
            dataGridViewEmployee.AllowUserToResizeRows = false;
            dataGridViewEmployee.AllowUserToResizeColumns = false;
            //直接の登録を不可にする
            dataGridViewEmployee.AllowUserToAddRows = false;
            //行内をクリックすることで行を選択
            dataGridViewEmployee.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //奇数行の色を変更
            dataGridViewEmployee.AlternatingRowsDefaultCellStyle.BackColor = Color.Honeydew;
            //ヘッダー位置の指定
            dataGridViewEmployee.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //データグリッドビューのデータ取得
            GetDataGridView();
        }

        private void buttonFirstPage_Click(object sender, EventArgs e)
        {

        }

        private void buttonNextPage_Click(object sender, EventArgs e)
        {

        }

        private void buttonPreviousPage_Click(object sender, EventArgs e)
        {

        }

        private void buttonLastPage_Click(object sender, EventArgs e)
        {

        }

        private void buttonPageSizeChange_Click(object sender, EventArgs e)
        {

        }

        private void textBoxPageSize_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonSetting_Click(object sender, EventArgs e)
        {
            if (buttonSetting.Text == "社員管理")
            {
                labelEmployee.Text = "社員管理";
                panelLeft.Visible = true;
                panelSetting.Visible = false;
                userControlPosition1.Visible = false;
                userControlSalesOffice1.Visible = false;
                panelEmployee.Visible = true;
                buttonSetting.Text = "設定";
                return;
            }
            if(buttonSetting.Text == "設定")
            {
                panelSetting.Visible = true;
                panelLeft.Visible = false;
                buttonSetting.Text = "社員管理";
                return;
            }
            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panelSetting.Visible = false;
            panel2.Visible = true;
            userControlPosition1.Visible = false;
            userControlSalesOffice1.Visible = false;
            labelEmployee.Text = "社員管理";
        }

        private void buttonFormDel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonPosition_Click(object sender, EventArgs e)
        {
            userControlPosition1.Visible = true;
            userControlSalesOffice1.Visible = false;
            panelEmployee.Visible = false;
            labelEmployee.Text = "役職管理";
        }

        private void userControlPosition1_Load(object sender, EventArgs e)
        {

        }

        private void buttonFormDel_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panelSetting_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buttonSalesOffice_Click(object sender, EventArgs e)
        {
            userControlPosition1.Visible = false;
            userControlSalesOffice1.Visible = true;
            panelEmployee.Visible = false;
            labelEmployee.Text = "営業所管理";
        }

        private void buttonRegist_Click(object sender, EventArgs e)
        {
            // 8.3.1.1 妥当な社員データ取得
            if (!GetValidDataAtRegistration())
                return;

            // 8.3.1.2 社員情報作成
            var regStaff = GenerateDataAtRegistration();

            // 8.3.1.3 社員情報登録
            RegistrationStaff(regStaff);
        }
        ///////////////////////////////
        //　8.3.1.1 妥当なスタッフデータ取得
        //メソッド名：GetValidDataAtRegistration()
        //引　数   ：なし
        //戻り値   ：true or false
        //機　能   ：入力データの形式チェック
        //          ：エラーがない場合True
        //          ：エラーがある場合False
        ///////////////////////////////
        private bool GetValidDataAtRegistration()
        {

            // 社員IDの適否
            if (!String.IsNullOrEmpty(textBoxEmID.Text.Trim()))
            {
                MessageBox.Show("社員IDは入力不要です","入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //messageDsp.DspMsg("");
                textBoxEmID.Focus();
                return false;
            }

            // 社員名の適否
            if (!String.IsNullOrEmpty(textBoxEmName.Text.Trim()))
            {
                // 社員名の全角チェック
                if (!dataInputFormCheck.CheckFullWidth(textBoxEmName.Text.Trim()))
                {
                    MessageBox.Show("社員名は全て全角入力です","入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //messageDsp.DspMsg("");
                    textBoxEmName.Focus();
                    return false;
                }
                // 社員名の文字数チェック
                if (textBoxEmName.TextLength > 15)
                {
                    MessageBox.Show("社員名は15文字以下です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //messageDsp.DspMsg("");
                    textBoxEmName.Focus();
                    return false;
                }
            }
            else
            {
                MessageBox.Show("社員名が入力されていません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //messageDsp.DspMsg("");
                textBoxEmName.Focus();
                return false;
            }
            //営業所の選択チェック
            if (comboBoxSoID.SelectedIndex == -1)
            {
                MessageBox.Show("営業所が選択されていません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBoxSoID.Focus();
                return false;
            }
            //役職の選択チェック
            if (comboBoxPoID.SelectedIndex == -1)
            {
                MessageBox.Show("役職が選択されていません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBoxPoID.Focus();
                return false;
            }
            // 電話番号の半角数値チェック
            if (!String.IsNullOrEmpty(textBoxEmPhone.Text.Trim()))
            {
                if (!dataInputFormCheck.CheckNumericHyphen(textBoxEmPhone.Text.Trim()))
                {
                    MessageBox.Show("電話番号は半角数値です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //messageDsp.DspMsg("M3030");
                    textBoxEmPhone.Focus();
                    return false;
                }
                // 電話番号の文字数チェック
                if (textBoxEmPhone.TextLength > 13)
                {
                    MessageBox.Show("電話番号は13文字以下です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //messageDsp.DspMsg("M3031");
                    textBoxEmPhone.Focus();
                    return false;
                }
            }
            else
            {
                MessageBox.Show("電話番号が入力されていません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //messageDsp.DspMsg("");
                textBoxEmPhone.Focus();
                return false;
            }
            // パスワードの未入力チェック
            if (!String.IsNullOrEmpty(textBoxEmPassword.Text.Trim()))
            {
                // パスワードの半角英数字チェック
                if (!dataInputFormCheck.CheckHalfAlphabetNumeric(textBoxEmPassword.Text.Trim()))
                {
                    MessageBox.Show("パスワードは全て半角英数字入力です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //messageDsp.DspMsg("M3044");
                    textBoxEmPassword.Focus();
                    return false;
                }
                // パスワードの文字数チェック
                if (textBoxEmPassword.TextLength > 10)
                {
                    MessageBox.Show("パスワードは10文字以下です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //messageDsp.DspMsg("M3045");
                    textBoxEmPassword.Focus();
                    return false;
                }
            }
            else
            {
                MessageBox.Show("ログインPWが入力されていません","入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //messageDsp.DspMsg("M3046");
                textBoxEmPassword.Focus();
                return false;
            }

            // 削除フラグの適否
            if (checkBoxEmFlag.CheckState == CheckState.Indeterminate)
            {
                MessageBox.Show("削除フラグが不確定の状態です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //messageDsp.DspMsg("M3008");
                checkBoxEmFlag.Focus();
                return false;
            }
            if (checkBoxEmFlag.Checked == true)
            {
                MessageBox.Show("非表示フラグがチェックされています", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                checkBoxEmFlag.Focus();
                return false;
            }

            return true;
        }
        ///////////////////////////////
        //　8.3.1.2 社員情報作成
        //メソッド名：GenerateDataAtRegistration()
        //引　数   ：なし
        //戻り値   ：スタッフ登録情報
        //機　能   ：登録データのセット
        ///////////////////////////////
        private M_Employee GenerateDataAtRegistration()
        {
            //DateTime? mHireDate;
            //if (dateTimePickerHiredate.Checked == false)
            //    mHireDate = null;
            //else
            //    mHireDate = DateTime.Parse(dateTimePickerHiredate.Text);
            // パスワードハッシュ化
            //string pw = passwordHash.CreatePasswordHash(textBoxEmPassword.Text.Trim());

            return new M_Employee
            {
                //EmID = int.Parse(textBoxEmID.Text.Trim()),
                EmName = textBoxEmName.Text.Trim(),
                SoID = int.Parse(comboBoxSoID.SelectedValue.ToString()),
                PoID = int.Parse(comboBoxPoID.SelectedValue.ToString()),
                EmHiredate = DateTime.Parse(dateTimePickerHiredate.Text),
                EmPassword = textBoxEmPassword.Text.Trim(),
                EmPhone = textBoxEmPhone.Text.Trim(),               
                EmFlag = 0,
                EmHidden = String.Empty

            };
        }
        ///////////////////////////////
        //　8.3.1.3 社員情報登録
        //メソッド名：RegistrationStaff()
        //引　数   ：スタッフ情報
        //戻り値   ：なし
        //機　能   ：スタッフ情報の登録
        ///////////////////////////////
        private void RegistrationStaff(M_Employee regEmployee)
        {
            // 登録確認メッセージ
            DialogResult result = MessageBox.Show("社員データを登録してよろしいですか?", "追加確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Cancel)
                return;

            // スタッフ情報の登録
            bool flg = employeeDataAccess.AddEmployeeData(regEmployee);
            if (flg == true)
                MessageBox.Show("データを登録しました。","追加確認", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //messageDsp.DspMsg("");
            else
                MessageBox.Show("データの登録に失敗しました。", "追加確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //messageDsp.DspMsg("");

            textBoxEmID.Focus();

            // 入力エリアのクリア
            ClearInput();

            // データグリッドビューの表示
            GetDataGridView();

        }
        private void GetDataGridView()
        {
            // 社員データの取得
            Employee = employeeDataAccess.GetEmployeeData();

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
            if (!String.IsNullOrEmpty(textBoxPageSize.Text.Trim()))
            {
                if (!dataInputFormCheck.CheckNumeric(textBoxPageSize.Text.Trim()))
                {
                    MessageBox.Show("ページ行数は半角数値のみです", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxPageSize.Focus();
                    return;
                }
                if (int.Parse(textBoxPageSize.Text) <= 0)
                {
                    MessageBox.Show("ページ行数は1以上です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxPageSize.Focus();
                    return;

                }
            }
            else
            {
                MessageBox.Show("ページ行数が入力されていません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxPageSize.Focus();
                return;

            }
            
            int pageSize = int.Parse(textBoxPageSize.Text);
            int pageNo = int.Parse(textBoxPage.Text) - 1;
            dataGridViewEmployee.DataSource = Employee.Skip(pageSize * pageNo).Take(pageSize).ToList();
            //各列幅の指定
            dataGridViewEmployee.Columns[0].Width = 100;
            dataGridViewEmployee.Columns[1].Width = 180;
            dataGridViewEmployee.Columns[2].Visible = false;
            dataGridViewEmployee.Columns[3].Width = 150;
            dataGridViewEmployee.Columns[4].Visible = false;
            dataGridViewEmployee.Columns[5].Width = 150;
            dataGridViewEmployee.Columns[6].Width = 180;
            dataGridViewEmployee.Columns[7].Visible = false;
            dataGridViewEmployee.Columns[8].Width = 180;
            dataGridViewEmployee.Columns[9].Visible = false;
            dataGridViewEmployee.Columns[10].Width = 569;

            //各列の文字位置の指定
            dataGridViewEmployee.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewEmployee.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewEmployee.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewEmployee.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewEmployee.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewEmployee.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewEmployee.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            //dataGridViewの総ページ数
            labelPage.Text = "/" + ((int)Math.Ceiling(Employee.Count / (double)pageSize)) + "ページ";

            dataGridViewEmployee.Refresh();
            
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            //日時更新
            labelDay.Text = DateTime.Now.ToString("yyyy/MM/dd/(ddd)");
            labelTime.Text = DateTime.Now.ToString("HH:mm");
        }

        private void buttonHiddenList_Click(object sender, EventArgs e)
        {
            ClearInput();
            GetHiddenDataGridView();
            
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void labelPassword_Click(object sender, EventArgs e)
        {

        }

        private void textBoxEmPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            // 8.3.2.1 妥当な社員データ取得
            if (!GetValidDataAtUpdate())
                return;

            // 8.3.2.2 社員情報作成
            var updEmployee = GenerateDataAtUpdate();

            // 8.3.2.3 社員情報更新
            UpdateEmployee(updEmployee);
        }
        ///////////////////////////////
        //8.3.2.1 妥当なスタッフデータ取得
        //メソッド名：GetValidDataAtUpdate()
        //引　数   ：なし
        //戻り値   ：true or false
        //機　能   ：入力データの形式チェック
        //          ：エラーがない場合True
        //          ：エラーがある場合False
        ///////////////////////////////
        private bool GetValidDataAtUpdate()
        {

            // 社員IDの適否
            if (!String.IsNullOrEmpty(textBoxEmID.Text.Trim()))
            {
                // 社員IDの半角数字チェック
                if (!dataInputFormCheck.CheckNumeric(textBoxEmID.Text.Trim()))
                {
                    MessageBox.Show("社員IDは全て半角数字入力です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //messageDsp.DspMsg("");
                    textBoxEmID.Focus();
                    return false;
                }
                // 社員IDの文字数チェック
                if (textBoxEmID.TextLength > 6)
                {
                    MessageBox.Show("社員IDは6文字以下です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //messageDsp.DspMsg("");
                    textBoxEmID.Focus();
                    return false;
                }

                // 社員IDの存在チェック
                if (!employeeDataAccess.CheckEmIDExistence(int.Parse(textBoxEmID.Text.Trim())))
                {
                    MessageBox.Show("入力された社員IDは存在しません","入力確認",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    //messageDsp.DspMsg("");
                    textBoxEmID.Focus();
                    return false;
                }
            }
            else
            {
                MessageBox.Show("社員IDが入力されていません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //messageDsp.DspMsg("");
                textBoxEmID.Focus();
                return false;
            }

            // 社員名の適否
            if (!String.IsNullOrEmpty(textBoxEmName.Text.Trim()))
            {
                // 社員名の全角チェック
                if (!dataInputFormCheck.CheckFullWidth(textBoxEmName.Text.Trim()))
                {
                    MessageBox.Show("社員名は全て全角入力です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //messageDsp.DspMsg("");
                    textBoxEmName.Focus();
                    return false;
                }
                // 社員名の文字数チェック
                if (textBoxEmName.TextLength > 15)
                {
                    MessageBox.Show("社員名は15文字以下です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //messageDsp.DspMsg("");
                    textBoxEmName.Focus();
                    return false;
                }
            }
            else
            {
                MessageBox.Show("社員名が入力されていません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxEmName.Focus();
                return false;
            }
            //営業所の選択チェック
            if (comboBoxSoID.SelectedIndex == -1)
            {
                MessageBox.Show("営業所が選択されていません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBoxSoID.Focus();
                return false;
            }
            //役職の選択チェック
            if (comboBoxPoID.SelectedIndex == -1)
            {
                MessageBox.Show("役職が選択されていません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBoxPoID.Focus();
                return false;
            }
            // 電話番号の適否
            if (!String.IsNullOrEmpty(textBoxEmPhone.Text.Trim()))
            {
                // 電話番号の半角数値チェック
                if (!dataInputFormCheck.CheckNumericHyphen(textBoxEmPhone.Text.Trim()))
                {
                    MessageBox.Show("電話番号は半角数値です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //messageDsp.DspMsg("M3030");
                    textBoxEmPhone.Focus();
                    return false;
                }
                // 電話番号の文字数チェック
                if (textBoxEmPhone.TextLength > 13)
                {
                    MessageBox.Show("電話番号は13文字以下です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //messageDsp.DspMsg("M3031");
                    textBoxEmPhone.Focus();
                    return false;
                }
            }
            else
            {
                MessageBox.Show("電話番号が入力されていません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxEmPhone.Focus();
                return false;
            }

            // パスワードの未入力チェック
            if (!String.IsNullOrEmpty(textBoxEmPassword.Text.Trim()))
            {
                // パスワードの半角英数字チェック
                if (!dataInputFormCheck.CheckHalfAlphabetNumeric(textBoxEmPassword.Text.Trim()))
                {
                    MessageBox.Show("パスワードは全て半角英数字入力です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //messageDsp.DspMsg("M3044");
                    textBoxEmPassword.Focus();
                    return false;
                }
                // パスワードの文字数チェック
                if (textBoxEmPassword.TextLength > 10)
                {
                    MessageBox.Show("パスワードは10文字以下です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //messageDsp.DspMsg("M3045");
                    textBoxEmPassword.Focus();
                    return false;
                }
            }
            else
            {
                MessageBox.Show("ログインPWが入力されていません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //messageDsp.DspMsg("M3046");
                textBoxEmPassword.Focus();
                return false;
            }

            // 非表示フラグの適否
            if (checkBoxEmFlag.CheckState == CheckState.Indeterminate)
            {
                MessageBox.Show("非表示フラグが不確定の状態です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //messageDsp.DspMsg("M3008");
                checkBoxEmFlag.Focus();
                return false;
            }

            // 非表示理由の適否
            if (checkBoxEmFlag.Checked == true && String.IsNullOrEmpty(textBoxEmHidden.Text.Trim()))
            {
                MessageBox.Show("非表示理由が入力されていません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxEmHidden.Focus();
                return false;
            }
            return true;
        }
        ///////////////////////////////
        //　8.3.2.2 スタッフ情報作成
        //メソッド名：GenerateDataAtUpdate()
        //引　数   ：なし
        //戻り値   ：スタッフ更新情報
        //機　能   ：更新データのセット
        ///////////////////////////////
        private M_Employee GenerateDataAtUpdate()
        {
            DateTime? mHireDate;
            if (dateTimePickerHiredate.Checked == false)
                mHireDate = null;
            else
                mHireDate = DateTime.Parse(dateTimePickerHiredate.Text);

            int EmFlag = 0;
            if (checkBoxEmFlag.Checked == true)
            {
                EmFlag = 2;
            }

            // パスワード入力時、パスワードハッシュ化
            //string pw = "";
            //if (!String.IsNullOrEmpty(textBoxEmPassword.Text.Trim()))
            //    pw = passwordHash.CreatePasswordHash(textBoxEmPassword.Text.Trim());

            return new M_Employee
            {
                EmID = int.Parse(textBoxEmID.Text.Trim()),
                EmName = textBoxEmName.Text.Trim(),
                SoID = int.Parse(comboBoxSoID.SelectedValue.ToString()),
                PoID = int.Parse(comboBoxPoID.SelectedValue.ToString()),
                EmHiredate = DateTime.Parse(dateTimePickerHiredate.Text),
                EmPhone = textBoxEmPhone.Text.Trim(),
                EmPassword = textBoxEmPassword.Text.Trim(),
                EmFlag = EmFlag,
                EmHidden = textBoxEmHidden.Text.Trim()

            };
        }
        ///////////////////////////////
        //　8.3.2.3 スタッフ情報更新
        //メソッド名：UpdateStaff()
        //引　数   ：スタッフ情報
        //戻り値   ：なし
        //機　能   ：スタッフ情報の更新
        ///////////////////////////////
        private void UpdateEmployee(M_Employee updEmployee)
        {
            // 更新確認メッセージ
            DialogResult result = MessageBox.Show("データを更新してよろしいですか?", "追加確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (result == DialogResult.Cancel)
                return;

            // 社員情報の更新
            bool flg = employeeDataAccess.UpdateEmployeeData(updEmployee);
            if (flg == true)
                MessageBox.Show("データを更新しました", "追加確認", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("データの更新に失敗しました", "追加確認", MessageBoxButtons.OK, MessageBoxIcon.Error);

            textBoxEmID.Focus();

            // 入力エリアのクリア
            ClearInput();

            // データグリッドビューの表示
            GetDataGridView();

        }
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            // 8.3.4.1 妥当な社員データ取得
            if (!GetValidDataAtSelect())
                return;

            // 8.3.4.2 社員情報抽出
            GenerateDataAtSelect();

            // 8.3.4.3 社員抽出結果表示
            SetSelectData();

        }
        ///////////////////////////////
        //　8.3.4.1 妥当なスタッフデータ取得
        //メソッド名：GetValidDataAtSlect()
        //引　数   ：なし
        //戻り値   ：true or false
        //機　能   ：入力データの形式チェック
        //          ：エラーがない場合True
        //          ：エラーがある場合False
        ///////////////////////////////
        private bool GetValidDataAtSelect()
        {

            // 社員ID入力時チェック
            if (!String.IsNullOrEmpty(textBoxEmID.Text.Trim()))
            {
                // 社員IDの半角英数字チェック
                if (!dataInputFormCheck.CheckHalfAlphabetNumeric(textBoxEmID.Text.Trim()))
                {
                    MessageBox.Show("社員IDは全て半角英数字入力です");
                    //messageDsp.DspMsg("M3001");
                    textBoxEmID.Focus();
                    return false;
                }
                // 社員IDの文字数チェック
                if (textBoxEmID.TextLength > 6)
                {
                    MessageBox.Show("社員IDは6文字までです");
                    //messageDsp.DspMsg("M3002");
                    textBoxEmID.Focus();
                    return false;
                }
            }

            //社員名入力時のチェック
            if (!String.IsNullOrEmpty(textBoxEmName.Text.Trim()))
            {
                // 社員名の全角チェック
                if (!dataInputFormCheck.CheckFullWidth(textBoxEmName.Text.Trim()))
                {
                    MessageBox.Show("社員名は全て全角入力です");
                    //messageDsp.DspMsg("M3005");
                    textBoxEmName.Focus();
                    return false;
                }
                // 社員名の文字数チェック
                if (textBoxEmName.TextLength > 20)
                {
                    MessageBox.Show("社員名は15文字以下です");
                    //messageDsp.DspMsg("M3006");
                    textBoxEmName.Focus();
                    return false;
                }
                // 社員IDの存在チェック
                if (!employeeDataAccess.CheckEmIDExistence(int.Parse(textBoxEmID.Text.Trim())))
                {
                    MessageBox.Show("入力された社員IDは存在しません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //messageDsp.DspMsg("");
                    textBoxEmID.Focus();
                    return false;
                }
            }
            return true;
        }
        ///////////////////////////////
        //　8.3.4.2 社員情報抽出
        //メソッド名：GenerateDataAtSelect()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：検索データの取得
        ///////////////////////////////
        private void GenerateDataAtSelect()
        {
            //int Pass = 0;
             
            // コンボボックスが未選択の場合Emptyを設定
            string cPoID = "";
            string cSoID = "";

            int Pdflg = 0;
            if (checkBoxEmFlag.Checked == true)
            {
                Pdflg = 2;
            }

            if (comboBoxPoID.SelectedIndex != -1)
                cPoID = comboBoxPoID.SelectedValue.ToString();
            if (comboBoxSoID.SelectedIndex != -1)
                cSoID = comboBoxSoID.SelectedValue.ToString();

            if(!String.IsNullOrEmpty(textBoxEmID.Text.Trim()) && cPoID != "" && cSoID != "")
            {
                M_EmployeeDsp selectCondition = new M_EmployeeDsp()
                {
                    EmID = int.Parse(textBoxEmID.Text),
                    EmName = textBoxEmName.Text,
                    PoID = int.Parse(cPoID),
                    SoID = int.Parse(cSoID),
                    //EmPhone = textBoxEmPhone.Text,
                    //EmPassword=
                    EmFlag = Pdflg,
                    EmHidden=textBoxEmHidden.Text,
                };
                // 社員データの抽出
                Employee = employeeDataAccess.GetEmployeeData(1,selectCondition);
            }

            else if (!String.IsNullOrEmpty(textBoxEmID.Text.Trim()) && cPoID !="" && cSoID == "")
            {
                M_EmployeeDsp selectCondition = new M_EmployeeDsp()
                {
                    EmID = int.Parse(textBoxEmID.Text),
                    EmName = textBoxEmName.Text,
                    PoID = int.Parse(cPoID),
                    //SoID = int.Parse(cSoID),
                    EmFlag = Pdflg,
                    EmHidden = textBoxEmHidden.Text,
                };
                // 社員データの抽出
                Employee = employeeDataAccess.GetEmployeeData(2,selectCondition);
            }
            else if (!String.IsNullOrEmpty(textBoxEmID.Text.Trim()) && cPoID == "" && cSoID != "")
            {
                M_EmployeeDsp selectCondition = new M_EmployeeDsp()
                {
                    EmID = int.Parse(textBoxEmID.Text),
                    EmName = textBoxEmName.Text,
                    //PoID = int.Parse(cPoID),
                    SoID = int.Parse(cSoID),
                    EmFlag = Pdflg,
                    EmHidden = textBoxEmHidden.Text,
                };
                // 社員データの抽出
                Employee = employeeDataAccess.GetEmployeeData(3, selectCondition);
            }
            else if (!String.IsNullOrEmpty(textBoxEmID.Text.Trim()) && cPoID == "" && cSoID == "")
            {
                M_EmployeeDsp selectCondition = new M_EmployeeDsp()
                {
                    EmID = int.Parse(textBoxEmID.Text),
                    EmName = textBoxEmName.Text,
                    //PoID = int.Parse(cPoID),
                    //SoID = int.Parse(cSoID),
                    EmFlag = Pdflg,
                    EmHidden = textBoxEmHidden.Text,
                };
                // 社員データの抽出
                Employee = employeeDataAccess.GetEmployeeData(4, selectCondition);
            }
            else if (String.IsNullOrEmpty(textBoxEmID.Text.Trim()) && cPoID != "" && cSoID != "")
            {
                M_EmployeeDsp selectCondition = new M_EmployeeDsp()
                {
                    //EmID = int.Parse(textBoxEmID.Text),
                    EmName = textBoxEmName.Text,
                    PoID = int.Parse(cPoID),
                    SoID = int.Parse(cSoID),
                    EmFlag = Pdflg,
                    EmHidden = textBoxEmHidden.Text,
                };
                // 社員データの抽出
                Employee = employeeDataAccess.GetEmployeeData(5, selectCondition);
            }
            else if (String.IsNullOrEmpty(textBoxEmID.Text.Trim()) && cPoID != "" && cSoID == "")
            {
                M_EmployeeDsp selectCondition = new M_EmployeeDsp()
                {
                    //EmID = int.Parse(textBoxEmID.Text),
                    EmName = textBoxEmName.Text,
                    PoID = int.Parse(cPoID),
                    //SoID = int.Parse(cSoID),
                    //EmPhone = textBoxEmPhone.Text,
                    //EmPassword = textBoxEmPassword.Text,
                    //EmHiredate= DateTime.Parse(dateTimePickerHiredate.Text),
                    EmFlag = Pdflg,
                    EmHidden = textBoxEmHidden.Text,
                };
                // 社員データの抽出
                Employee = employeeDataAccess.GetEmployeeData(6, selectCondition);
            }
            else if (String.IsNullOrEmpty(textBoxEmID.Text.Trim()) && cPoID == "" && cSoID != "")
            {
                M_EmployeeDsp selectCondition = new M_EmployeeDsp()
                {
                    //EmID = int.Parse(textBoxEmID.Text),
                    EmName = textBoxEmName.Text,
                    //PoID = int.Parse(cPoID),
                    SoID = int.Parse(cSoID),
                    EmFlag = Pdflg,
                    EmHidden = textBoxEmHidden.Text,
                };
                // 社員データの抽出
                Employee = employeeDataAccess.GetEmployeeData(7, selectCondition);
            }
            else //(String.IsNullOrEmpty(textBoxEmID.Text.Trim()) && cPoID == "" && cSoID == "")
            {
                M_EmployeeDsp selectCondition = new M_EmployeeDsp()
                {
                    //EmID = int.Parse(textBoxEmID.Text),
                    EmName = textBoxEmName.Text,
                    //PoID = int.Parse(cPoID),
                    //SoID = int.Parse(cSoID),
                    EmFlag = Pdflg,
                    EmHidden = textBoxEmHidden.Text,
                };
                // 社員データの抽出
                Employee = employeeDataAccess.GetEmployeeData(8, selectCondition);
            }



        }
        ///////////////////////////////
        //　8.3.4.3 スタッフ抽出結果表示
        //メソッド名：SetSelectData()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：スタッフ情報の表示
        ///////////////////////////////
        private void SetSelectData()
        {
            textBoxPage.Text = "1";

            int pageSize = int.Parse(textBoxPageSize.Text);

            dataGridViewEmployee.DataSource = Employee;

            labelPage.Text = "/" + ((int)Math.Ceiling(Employee.Count / (double)pageSize)) + "ページ";
            dataGridViewEmployee.Refresh();
        }
        private void buttonLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("ログアウトしてよろしいですか？", "ログアウト確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (result == DialogResult.OK)
            {
                //OK時の処理
                FormMain.loginName = "";
                Dispose();
            }
        }
        ///////////////////////////////
        //メソッド名：dataGridViewEmpoloyee_CellClick()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：データグリッドビューから選択された情報を各入力エリアにセット
        ///////////////////////////////
        private void dataGridViewEmployee_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //データグリッドビューからクリックされたデータを各入力エリアへ
            textBoxEmID.Text = dataGridViewEmployee.Rows[dataGridViewEmployee.CurrentRow.Index].Cells[0].Value.ToString();
            textBoxEmName.Text = dataGridViewEmployee.Rows[dataGridViewEmployee.CurrentRow.Index].Cells[1].Value.ToString();
            comboBoxSoID.Text = dataGridViewEmployee.Rows[dataGridViewEmployee.CurrentRow.Index].Cells[15].Value.ToString();
            comboBoxPoID.Text = dataGridViewEmployee.Rows[dataGridViewEmployee.CurrentRow.Index].Cells[15].Value.ToString();
            textBoxEmPhone.Text = dataGridViewEmployee.Rows[dataGridViewEmployee.CurrentRow.Index].Cells[6].Value.ToString();
            textBoxEmPassword.Text = dataGridViewEmployee.Rows[dataGridViewEmployee.CurrentRow.Index].Cells[10].Value.ToString();
            if (dataGridViewEmployee.Rows[dataGridViewEmployee.CurrentRow.Index].Cells[10].Value == null)
            {
                dateTimePickerHiredate.Value = DateTime.Now;
                dateTimePickerHiredate.Checked = false;
            }
            else
                dateTimePickerHiredate.Text = dataGridViewEmployee.Rows[dataGridViewEmployee.CurrentRow.Index].Cells[10].Value.ToString();

            checkBoxEmFlag.Checked = (bool)dataGridViewEmployee.Rows[dataGridViewEmployee.CurrentRow.Index].Cells[21].Value;
            textBoxEmHidden.Text = dataGridViewEmployee.Rows[dataGridViewEmployee.CurrentRow.Index].Cells[22].Value.ToString();
        }
        ///////////////////////////////
        //メソッド名：ClearInput()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：入力エリアをクリア
        ///////////////////////////////
        private void ClearInput()
        {
            // デートタイムピッカの設定
            SetFormDateTimePiker();
            textBoxEmID.Text = "";
            textBoxEmName.Text = "";
            comboBoxSoID.SelectedIndex = -1;
            comboBoxPoID.SelectedIndex = -1;
            textBoxEmPassword.Text = "";
            textBoxEmPhone.Text = "";
            checkBoxEmFlag.Checked = false;
            textBoxEmHidden.Text = "";
        }

        private void buttonList_Click(object sender, EventArgs e)
        {
            ClearInput();
            GetDataGridView();
        }

        private void checkBoxEmFlag_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxEmFlag.Checked == true)
            {
                textBoxEmHidden.TabStop = true;
                textBoxEmHidden.ReadOnly = false;
                textBoxEmHidden.Enabled = true;
            }
            else
            {
                textBoxEmHidden.Text = "";
                textBoxEmHidden.TabStop = false;
                textBoxEmHidden.ReadOnly = true;
                textBoxEmHidden.Enabled = false;

            }
        }

        private void dataGridViewEmployee_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            textBoxEmID.Text = dataGridViewEmployee.Rows[dataGridViewEmployee.CurrentRow.Index].Cells[0].Value.ToString();
            textBoxEmName.Text = dataGridViewEmployee.Rows[dataGridViewEmployee.CurrentRow.Index].Cells[1].Value.ToString();
            comboBoxSoID.Text = dataGridViewEmployee.Rows[dataGridViewEmployee.CurrentRow.Index].Cells[3].Value.ToString();
            comboBoxPoID.Text = dataGridViewEmployee.Rows[dataGridViewEmployee.CurrentRow.Index].Cells[5].Value.ToString();
            dateTimePickerHiredate.Value = DateTime.Parse(dataGridViewEmployee.Rows[dataGridViewEmployee.CurrentRow.Index].Cells[6].Value.ToString());
            textBoxEmPhone.Text = dataGridViewEmployee.Rows[dataGridViewEmployee.CurrentRow.Index].Cells[8].Value.ToString();


            if (dataGridViewEmployee.Rows[dataGridViewEmployee.CurrentRow.Index].Cells[9].Value.ToString() != 2.ToString())
            {
                checkBoxEmFlag.Checked = false;
            }
            else
            {
                checkBoxEmFlag.Checked = true;
            }
            //非表示理由がnullではない場合テキストボックスに表示させる
            if (dataGridViewEmployee.Rows[dataGridViewEmployee.CurrentRow.Index].Cells[10].Value != null)
            {
                textBoxEmHidden.Text = dataGridViewEmployee.Rows[dataGridViewEmployee.CurrentRow.Index].Cells[10].Value.ToString();
            }
        }

        private void buttonClear2_Click(object sender, EventArgs e)
        {
            ClearInput();
        }

        ///////////////////////////////
        //メソッド名：GetHiddenDataGridView()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：データグリッドビューに表示する非表示データの取得
        ///////////////////////////////
        private void GetHiddenDataGridView()
        {
            // 受注データの取得
            Employee = employeeDataAccess.GetEmployeeHiddenData();

            // DataGridViewに表示するデータを指定
            SetDataGridView();

        }
    }

}
