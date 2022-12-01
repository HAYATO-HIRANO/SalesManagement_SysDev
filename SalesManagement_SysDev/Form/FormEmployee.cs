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
            textBoxPageSize.Text = "10";
            //dataGridViewのページ番号指定
            textBoxPage.Text = "1";
            //読み取り専用に指定
            dataGridViewEmployee.ReadOnly = true;
            //行内をクリックすることで行を選択
            dataGridViewEmployee.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
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
                // 社員IDの半角英数字チェック
                if (!dataInputFormCheck.CheckHalfAlphabetNumeric(textBoxEmID.Text.Trim()))
                {
                    MessageBox.Show("社員IDは全て半角英数字入力です");
                    //messageDsp.DspMsg("");
                    textBoxEmID.Focus();
                    return false;
                }
                // 社員IDの文字数チェック
                if (textBoxEmID.TextLength > 6)
                {
                    MessageBox.Show("社員IDは6文字以下です");
                    //messageDsp.DspMsg("");
                    textBoxEmID.Focus();
                    return false;
                }

                // 社員IDの重複チェック
                if (employeeDataAccess.CheckEmIDExistence(int.Parse(textBoxEmID.Text.Trim())))
                {
                    MessageBox.Show("入力された社員IDは既に存在します");
                    //messageDsp.DspMsg("");
                    textBoxEmID.Focus();
                    return false;
                }
            }
            else
            {
                MessageBox.Show("社員IDが入力されていません");
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
                    MessageBox.Show("社員名は全て全角入力です");
                    //messageDsp.DspMsg("");
                    textBoxEmName.Focus();
                    return false;
                }
                // 社員名の文字数チェック
                if (textBoxEmName.TextLength > 15)
                {
                    MessageBox.Show("社員名は15文字以下です");
                    //messageDsp.DspMsg("");
                    textBoxEmName.Focus();
                    return false;
                }
            }
            else
            {
                MessageBox.Show("社員名が入力されていません");
                //messageDsp.DspMsg("");
                textBoxEmName.Focus();
                return false;
            }
            //営業所の選択チェック
            if (comboBoxPoID.SelectedIndex == -1)
            {
                MessageBox.Show("営業所が選択されていません");
                comboBoxPoID.Focus();
                return false;
            }
            //役職の選択チェック
            if (comboBoxSoID.SelectedIndex == -1)
            {
                MessageBox.Show("役職が選択されていません");
                comboBoxSoID.Focus();
                return false;
            }
            // 電話番号の半角数値チェック
            if (!String.IsNullOrEmpty(textBoxEmPhone.Text.Trim()))
            {
                if (!dataInputFormCheck.CheckNumeric(textBoxEmPhone.Text.Trim()))
                {
                    MessageBox.Show("電話番号は半角数値です");
                    //messageDsp.DspMsg("M3030");
                    textBoxEmPhone.Focus();
                    return false;
                }
                // 電話番号の文字数チェック
                if (textBoxEmPhone.TextLength > 12)
                {
                    MessageBox.Show("電話番号は12文字以下です");
                    //messageDsp.DspMsg("M3031");
                    textBoxEmPhone.Focus();
                    return false;
                }
            }
            // パスワードの未入力チェック
            if (!String.IsNullOrEmpty(textBoxEmPassword.Text.Trim()))
            {
                // パスワードの半角英数字チェック
                if (!dataInputFormCheck.CheckHalfAlphabetNumeric(textBoxEmPassword.Text.Trim()))
                {
                    MessageBox.Show("パスワードは全て半角英数字入力です");
                    //messageDsp.DspMsg("M3044");
                    textBoxEmPassword.Focus();
                    return false;
                }
                // パスワードの文字数チェック
                if (textBoxEmPassword.TextLength > 10)
                {
                    MessageBox.Show("パスワードは10文字以下です");
                    //messageDsp.DspMsg("M3045");
                    textBoxEmPassword.Focus();
                    return false;
                }
            }
            else
            {
                MessageBox.Show("ログインPWが入力されていません");
                //messageDsp.DspMsg("M3046");
                textBoxEmPassword.Focus();
                return false;
            }

            // 削除フラグの適否
            if (checkBoxEmFlag.CheckState == CheckState.Indeterminate)
            {
                MessageBox.Show("削除フラグが不確定の状態です");
                //messageDsp.DspMsg("M3008");
                checkBoxEmFlag.Focus();
                return false;
            }

            // 備考の適否
            if (!String.IsNullOrEmpty(textBoxEmHidden.Text.Trim()))
            {
                if (textBoxEmHidden.TextLength > 100)
                {
                    //MessageBox.Show("備考は100文字以下です");
                    messageDsp.DspMsg("M3009");
                    textBoxEmHidden.Focus();
                    return false;
                }
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
            DateTime? mHireDate;
            if (dateTimePickerHiredate.Checked == false)
                mHireDate = null;
            else
                mHireDate = DateTime.Parse(dateTimePickerHiredate.Text);
            // パスワードハッシュ化
            string pw = passwordHash.CreatePasswordHash(textBoxEmPassword.Text.Trim());

            return new M_Employee
            {
                EmID = int.Parse(textBoxEmID.Text.Trim()),
                EmName = textBoxEmName.Text.Trim(),
                SoID = int.Parse(comboBoxSoID.SelectedValue.ToString()),
                PoID = int.Parse(comboBoxPoID.SelectedValue.ToString()),
                EmHiredate = (DateTime)mHireDate,
                EmPassword = pw,
                EmPhone = textBoxEmPhone.Text.Trim(),               
                EmFlag = Convert.ToInt32(checkBoxEmFlag.Checked),
                EmHidden = textBoxEmHidden.Text.Trim()

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
            DialogResult result = messageDsp.DspMsg("M3010");
            if (result == DialogResult.Cancel)
                return;

            // スタッフ情報の登録
            bool flg = employeeDataAccess.AddEmployeeData(regEmployee);
            if (flg == true)
                MessageBox.Show("データを登録しました。");
                //messageDsp.DspMsg("");
            else
                MessageBox.Show("データの登録に失敗しました。");
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
            /*
            int pageSize = int.Parse(textBoxPageSize.Text);
            int pageNo = int.Parse(textBoxPage.Text) - 1;
            dataGridViewEmployee.DataSource = Employee.Skip(pageSize * pageNo).Take(pageSize).ToList();
            //各列幅の指定
            dataGridViewEmployee.Columns[0].Width = 80;
            dataGridViewEmployee.Columns[1].Width = 130;
            dataGridViewEmployee.Columns[2].Width = 130;
            dataGridViewEmployee.Columns[3].Width = 70;
            dataGridViewEmployee.Columns[3].Visible = false;
            dataGridViewEmployee.Columns[4].Width = 130;
            dataGridViewEmployee.Columns[4].Visible = false;
            dataGridViewEmployee.Columns[5].Width = 130;
            dataGridViewEmployee.Columns[5].Visible = false;
            dataGridViewEmployee.Columns[6].Width = 130;
            dataGridViewEmployee.Columns[6].Visible = false;
            dataGridViewEmployee.Columns[7].Width = 130;
            dataGridViewEmployee.Columns[7].Visible = false;
            dataGridViewEmployee.Columns[8].Width = 130;
            dataGridViewEmployee.Columns[8].Visible = false;
            dataGridViewEmployee.Columns[9].Width = 130;
            dataGridViewEmployee.Columns[9].Visible = false;
            dataGridViewEmployee.Columns[10].Width = 130;
            dataGridViewEmployee.Columns[10].Visible = false;
            dataGridViewEmployee.Columns[11].Width = 50;
            dataGridViewEmployee.Columns[11].Visible = false;
            dataGridViewEmployee.Columns[12].Width = 100;
            dataGridViewEmployee.Columns[13].Width = 50;
            dataGridViewEmployee.Columns[13].Visible = false;
            dataGridViewEmployee.Columns[14].Width = 100;
            dataGridViewEmployee.Columns[15].Width = 50;
            dataGridViewEmployee.Columns[15].Visible = false;
            dataGridViewEmployee.Columns[16].Width = 100;
            dataGridViewEmployee.Columns[17].Width = 50;
            dataGridViewEmployee.Columns[17].Visible = false;
            dataGridViewEmployee.Columns[18].Width = 100;
            dataGridViewEmployee.Columns[19].Width = 100;
            dataGridViewEmployee.Columns[20].Width = 130;
            dataGridViewEmployee.Columns[20].Visible = false;
            dataGridViewEmployee.Columns[21].Width = 80;
            dataGridViewEmployee.Columns[22].Width = 250;

            //各列の文字位置の指定
            dataGridViewEmployee.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewEmployee.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewEmployee.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewEmployee.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewEmployee.Columns[14].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewEmployee.Columns[16].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewEmployee.Columns[18].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewEmployee.Columns[19].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewEmployee.Columns[21].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewEmployee.Columns[22].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            //dataGridViewの総ページ数
            labelPage.Text = "/" + ((int)Math.Ceiling(Employee.Count / (double)pageSize)) + "ページ";

            dataGridViewEmployee.Refresh();
            */
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            //日時更新
            labelDay.Text = DateTime.Now.ToString("yyyy/MM/dd/(ddd)");
            labelTime.Text = DateTime.Now.ToString("HH:mm");
        }

        private void buttonHiddenList_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridViewEmployee_CellContentClick(object sender, DataGridViewCellEventArgs e)
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
                // 社員IDの半角英数字チェック
                if (!dataInputFormCheck.CheckHalfAlphabetNumeric(textBoxEmID.Text.Trim()))
                {
                    MessageBox.Show("社員IDは全て半角英数字入力です");
                    //messageDsp.DspMsg("");
                    textBoxEmID.Focus();
                    return false;
                }
                // 社員IDの文字数チェック
                if (textBoxEmID.TextLength > 6)
                {
                    MessageBox.Show("社員IDは6文字以下です");
                    //messageDsp.DspMsg("");
                    textBoxEmID.Focus();
                    return false;
                }

                // 社員IDの重複チェック
                if (employeeDataAccess.CheckEmIDExistence(int.Parse(textBoxEmID.Text.Trim())))
                {
                    MessageBox.Show("入力された社員IDは既に存在します");
                    //messageDsp.DspMsg("");
                    textBoxEmID.Focus();
                    return false;
                }
            }
            else
            {
                MessageBox.Show("社員IDが入力されていません");
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
                    MessageBox.Show("社員名は全て全角入力です");
                    //messageDsp.DspMsg("");
                    textBoxEmName.Focus();
                    return false;
                }
                // 社員名の文字数チェック
                if (textBoxEmName.TextLength > 15)
                {
                    MessageBox.Show("社員名は15文字以下です");
                    //messageDsp.DspMsg("");
                    textBoxEmName.Focus();
                    return false;
                }
            }
            else
            {
                //MessageBox.Show("社員名が入力されていません");
                messageDsp.DspMsg("");
                textBoxEmName.Focus();
                return false;
            }
            //営業所の選択チェック
            if (comboBoxPoID.SelectedIndex == -1)
            {
                MessageBox.Show("営業所が選択されていません");
                comboBoxPoID.Focus();
                return false;
            }
            //役職の選択チェック
            if (comboBoxSoID.SelectedIndex == -1)
            {
                MessageBox.Show("役職が選択されていません");
                comboBoxSoID.Focus();
                return false;
            }
            // 電話番号の半角数値チェック
            if (!String.IsNullOrEmpty(textBoxEmPhone.Text.Trim()))
            {
                if (!dataInputFormCheck.CheckNumeric(textBoxEmPhone.Text.Trim()))
                {
                    MessageBox.Show("電話番号は半角数値です");
                    //messageDsp.DspMsg("M3030");
                    textBoxEmPhone.Focus();
                    return false;
                }
                // 電話番号の文字数チェック
                if (textBoxEmPhone.TextLength > 12)
                {
                    MessageBox.Show("電話番号は12文字以下です");
                    //messageDsp.DspMsg("M3031");
                    textBoxEmPhone.Focus();
                    return false;
                }
            }
            // パスワードの未入力チェック
            if (!String.IsNullOrEmpty(textBoxEmPassword.Text.Trim()))
            {
                // パスワードの半角英数字チェック
                if (!dataInputFormCheck.CheckHalfAlphabetNumeric(textBoxEmPassword.Text.Trim()))
                {
                    MessageBox.Show("パスワードは全て半角英数字入力です");
                    //messageDsp.DspMsg("M3044");
                    textBoxEmPassword.Focus();
                    return false;
                }
                // パスワードの文字数チェック
                if (textBoxEmPassword.TextLength > 10)
                {
                    MessageBox.Show("パスワードは10文字以下です");
                    //messageDsp.DspMsg("M3045");
                    textBoxEmPassword.Focus();
                    return false;
                }
            }
            else
            {
                MessageBox.Show("ログインPWが入力されていません");
                //messageDsp.DspMsg("M3046");
                textBoxEmPassword.Focus();
                return false;
            }

            // 削除フラグの適否
            if (checkBoxEmFlag.CheckState == CheckState.Indeterminate)
            {
                MessageBox.Show("削除フラグが不確定の状態です");
                //messageDsp.DspMsg("M3008");
                checkBoxEmFlag.Focus();
                return false;
            }

            // 備考の適否
            if (!String.IsNullOrEmpty(textBoxEmHidden.Text.Trim()))
            {
                if (textBoxEmHidden.TextLength > 100)
                {
                    MessageBox.Show("備考は100文字以下です");
                    //messageDsp.DspMsg("M3009");
                    textBoxEmHidden.Focus();
                    return false;
                }
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
            // パスワード入力時、パスワードハッシュ化
            string pw = "";
            if (!String.IsNullOrEmpty(textBoxEmPassword.Text.Trim()))
                pw = passwordHash.CreatePasswordHash(textBoxEmPassword.Text.Trim());

            return new M_Employee
            {
                EmID = int.Parse(textBoxEmID.Text.Trim()),
                EmName = textBoxEmName.Text.Trim(),
                SoID = int.Parse(comboBoxSoID.SelectedValue.ToString()),
                PoID = int.Parse(comboBoxPoID.SelectedValue.ToString()),
                EmHiredate = (DateTime)mHireDate,
                EmPassword = pw,
                EmPhone = textBoxEmPhone.Text.Trim(),
                EmFlag = Convert.ToInt32(checkBoxEmFlag.Checked),
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
            DialogResult result = messageDsp.DspMsg("M3014");
            if (result == DialogResult.Cancel)
                return;

            // 社員情報の更新
            bool flg = employeeDataAccess.UpdateEmployeeData(updEmployee);
            if (flg == true)
                MessageBox.Show("データを更新しました。");
                //messageDsp.DspMsg("M3015");
            else
                MessageBox.Show("データの更新に失敗しました。");
                //messageDsp.DspMsg("M3016");

            textBoxEmID.Focus();

            // 入力エリアのクリア
            ClearInput();

            // データグリッドビューの表示
            GetDataGridView();

        }
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            // 8.3.4.1 妥当なスタッフデータ取得
            if (!GetValidDataAtSelect())
                return;

            // 8.3.4.2 スタッフ情報抽出
            GenerateDataAtSelect();

            // 8.3.4.3 スタッフ抽出結果表示
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
            // コンボボックスが未選択の場合Emptyを設定
            string cPoID = "";
            string cSoID = "";

            if (comboBoxPoID.SelectedIndex != -1)
                cPoID = comboBoxPoID.SelectedValue.ToString();
            if (comboBoxSoID.SelectedIndex != -1)
                cSoID = comboBoxSoID.SelectedValue.ToString();

            // 検索条件のセット
            M_EmployeeDsp selectCondition = new M_EmployeeDsp()
            {
                EmID = int.Parse(textBoxEmID.Text),
                EmName = textBoxEmName.Text,
                PoID = int.Parse(cPoID),
                SoID = int.Parse(cSoID),
            };
            // 社員データの抽出
            Employee = employeeDataAccess.GetEmployeeData(selectCondition);

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
            // ログアウト確認メッセージ
            DialogResult result = MessageBox.Show("ログアウトしてもよろしいですか？");

            if (result == DialogResult.OK)
            {
                // OKの時の処理
                FormMain.loginName = "";
                Dispose();
            }
            else
            {
                // キャンセルの時の処理
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
    }
}
