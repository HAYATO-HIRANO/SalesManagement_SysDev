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
        //データベース役職テーブルアクセス用クラスのインスタンス化
        PositionDataAccess positionDataAccess = new PositionDataAccess();
        //パスワードハッシュ用クラスのインスタンス化
        PasswordHash passwordHash = new PasswordHash();
        //入力形式チェック用クラスのインスタンス化
        DataInputFormCheck dataInputFormCheck = new DataInputFormCheck();
        //データグリッドビュー用のスタッフデータ
        private static List<M_Employee> Employee;
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
            panelSetting.Visible = false;
            userControlPosition1.Visible = false;
            userControlSalesOffice1.Visible = false;
        }

        private void buttonFirstPage_Click(object sender, EventArgs e)
        {

        }

        private void labelPageSize_Click(object sender, EventArgs e)
        {

        }

        private void buttonNextPage_Click(object sender, EventArgs e)
        {

        }

        private void labelPage_Click(object sender, EventArgs e)
        {

        }

        private void textBoxPage_TextChanged(object sender, EventArgs e)
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
            panelSetting.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panelSetting.Visible = false;
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
            userControlSalesOffice1.Visible = false;
            userControlPosition1.Visible = true;
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
                    //MessageBox.Show("社員IDは全て半角英数字入力です");
                    messageDsp.DspMsg("");
                    textBoxEmID.Focus();
                    return false;
                }
                // 社員IDの文字数チェック
                if (textBoxEmID.TextLength > 6)
                {
                    //MessageBox.Show("社員IDは6文字以下です");
                    messageDsp.DspMsg("");
                    textBoxEmID.Focus();
                    return false;
                }

                // 社員IDの重複チェック
                if (employeeDataAccess.CheckEmIDExistence(int.Parse(textBoxEmID.Text.Trim())))
                {
                    //MessageBox.Show("入力された社員IDは既に存在します");
                    messageDsp.DspMsg("");
                    textBoxEmID.Focus();
                    return false;
                }
            }
            else
            {
                //MessageBox.Show("社員IDが入力されていません");
                messageDsp.DspMsg("");
                textBoxEmID.Focus();
                return false;
            }

            // 社員名の適否
            if (!String.IsNullOrEmpty(textBoxEmName.Text.Trim()))
            {
                // 社員名の全角チェック
                if (!dataInputFormCheck.CheckFullWidth(textBoxEmName.Text.Trim()))
                {
                    //MessageBox.Show("社員名は全て全角入力です");
                    messageDsp.DspMsg("");
                    textBoxEmName.Focus();
                    return false;
                }
                // 社員名の文字数チェック
                if (textBoxEmName.TextLength > 50)
                {
                    //MessageBox.Show("社員名は50文字以下です");
                    messageDsp.DspMsg("");
                    textBoxEmName.Focus();
                    return false;
                }
            }
            else
            {
                //MessageBox.Show("社員名が入力されていません");
                messageDsp.DspMsg("M3007");
                textBoxEmName.Focus();
                return false;
            }
            // 電話番号の半角数値チェック
            if (!String.IsNullOrEmpty(textBoxEmPhone.Text.Trim()))
            {
                if (!dataInputFormCheck.CheckNumeric(textBoxEmPhone.Text.Trim()))
                {
                    //MessageBox.Show("電話番号は半角数値です");
                    messageDsp.DspMsg("M3030");
                    textBoxEmPhone.Focus();
                    return false;
                }
                // 電話番号の文字数チェック
                if (textBoxEmPhone.TextLength > 12)
                {
                    //MessageBox.Show("電話番号は12文字以下です");
                    messageDsp.DspMsg("M3031");
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
                    //MessageBox.Show("パスワードは全て半角英数字入力です");
                    messageDsp.DspMsg("M3044");
                    textBoxEmPassword.Focus();
                    return false;
                }
                // パスワードの文字数チェック
                if (textBoxEmPassword.TextLength > 10)
                {
                    //MessageBox.Show("パスワードは10文字以下です");
                    messageDsp.DspMsg("M3045");
                    textBoxEmPassword.Focus();
                    return false;
                }
            }
            else
            {
                //MessageBox.Show("ログインPWが入力されていません");
                messageDsp.DspMsg("M3046");
                textBoxEmPassword.Focus();
                return false;
            }

            // 削除フラグの適否
            if (checkBoxEmFlag.CheckState == CheckState.Indeterminate)
            {
                //MessageBox.Show("削除フラグが不確定の状態です");
                messageDsp.DspMsg("M3008");
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
        //　8.3.1.2 スタッフ情報作成
        //メソッド名：GenerateDataAtRegistration()
        //引　数   ：なし
        //戻り値   ：スタッフ登録情報
        //機　能   ：登録データのセット
        ///////////////////////////////
        private M_Employee GenerateDataAtRegistration()
        {
            // パスワードハッシュ化
            string pw = passwordHash.CreatePasswordHash(textBoxEmPassword.Text.Trim());

            return new M_Employee
            {
                EmID = int.Parse(textBoxEmID.Text.Trim()),
                EmName = textBoxEmName.Text.Trim(),
                EmPhone = textBoxEmPhone.Text.Trim(),
                EmPassword = pw,
                EmFlag = Convert.ToInt32(checkBoxEmFlag.Checked),
                EmHidden = textBoxEmHidden.Text.Trim()

            };
        }
        ///////////////////////////////
        //　8.3.1.3 スタッフ情報登録
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
                //MessageBox.Show("データを登録しました。");
                messageDsp.DspMsg("");
            else
                //MessageBox.Show("データの登録に失敗しました。");
                messageDsp.DspMsg("");

            textBoxEmID.Focus();

            // 入力エリアのクリア
            ClearInput();

            // データグリッドビューの表示
            GetDataGridView();

        }
        private void dataGridViewDsp_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //データグリッドビューからクリックされたデータを各入力エリアへ
            textBoxEmID.Text = dataGridViewEmployee.Rows[dataGridViewEmployee.CurrentRow.Index].Cells[0].Value.ToString();
            textBoxEmName.Text = dataGridViewEmployee.Rows[dataGridViewEmployee.CurrentRow.Index].Cells[1].Value.ToString();
            textBoxEmPhone.Text = dataGridViewEmployee.Rows[dataGridViewEmployee.CurrentRow.Index].Cells[6].Value.ToString();
            textBoxEmPassword.Text = dataGridViewEmployee.Rows[dataGridViewEmployee.CurrentRow.Index].Cells[10].Value.ToString();
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
            textBoxEmID.Text = "";
            textBoxEmName.Text = "";
            textBoxEmPhone.Text = "";
            textBoxEmPassword.Text = "";
            checkBoxEmFlag.Checked = false;
            textBoxEmHidden.Text = "";
        }
        private void GetDataGridView()
        {

        }
    }
}
