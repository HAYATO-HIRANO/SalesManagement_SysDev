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
    public partial class UserControlSalesOffice : UserControl
    {
        DataInputFormCheck dataInputFormCheck = new DataInputFormCheck();
        MessageDsp messageDsp = new MessageDsp();
        SalesOfficeDataAccess salesOfficeDataAccess = new SalesOfficeDataAccess();

        private static List<M_SalesOffice> M_SalesOffices;
        public UserControlSalesOffice()
        {
            InitializeComponent();
        }

        private void UserControlSalesOffice_Load(object sender, EventArgs e)
        {

        }

        private void buttonResist_Click(object sender, EventArgs e)
        {
            //*.2.1.1 妥当な営業所データ取得
            if (!GetValidDataAtRegistration())
                return;

            //*.2.1.2 営業所情報作成
            var regSalesOffice = GenerateDataAtRegistration();

            //*.2.1.3 営業所情報登録
            RegistrationSalesOffice(regSalesOffice);
        }
        ///////////////////////////////
        //　8.2.1.1 妥当な営業所データ取得
        //メソッド名：GetValidDataAtRegistration()
        //引　数   ：なし
        //戻り値   ：true or false
        //機　能   ：入力データの形式チェック
        //          ：エラーがなbbbbbbbい場合True
        //          ：エラーがある場合False
        ///////////////////////////////
        private bool GetValidDataAtRegistration()
        {
            //営業所IDの適否
            if (!String.IsNullOrEmpty(textBoxSoID.Text.Trim()))
            {
                //営業所IDの半角英数字チェック
                if (!dataInputFormCheck.CheckHalfAlphabetNumeric(textBoxSoID.Text.Trim()))
                {
                    //MessageBox.Show("営業所IDは全て半角英数字入力です")；
                    messageDsp.DspMsg("M***");
                    textBoxSoID.Focus();
                    return false;
                }
                // 営業所IDの文字数チェック
                if (textBoxSoID.TextLength != 15) ;
                {
                    //MessageBox.Show("営業所IDは15文字です。")；
                    messageDsp.DspMsg("M***");
                    textBoxSoID.Focus();
                    return false;
                }
                //営業所ID重複チェック
                if (salesOfficeDataAccess.CheckSalesOfficeCDExistence(int.Parse(textBoxSoID.Text.Trim())))
                {
                    MessageBox.Show("入力された営業所IDは既に存在します");
                    textBoxSoID.Focus();
                    return false;
                }
            }
            else
            {
                //MessageBox.Show("営業所IDが入力されていません");
                messageDsp.DspMsg("M***");
                textBoxSoID.Focus();
                return false;
            }
            //営業所名の適否
            if (!String.IsNullOrEmpty(textBoxSoName.Text.Trim()))
            {
                //営業所名の全角チェック
                if (!dataInputFormCheck.CheckFullWidth(textBoxSoName.Text.Trim()))
                {
                    MessageBox.Show("営業所名は全て全角入力です");
                    textBoxSoName.Focus();
                    return false;
                }
                // 営業所名の文字数チェック
                if (textBoxSoName.TextLength > 50)
                {
                    //MessageBox.Show("営業所名は50文字以下です");
                    messageDsp.DspMsg("M***");
                    textBoxSoName.Focus();
                    return false;
                }
            }
            else
            {
                MessageBox.Show("営業所名が入力されていません");
                textBoxSoName.Focus();
                return false;

            }
            // 削除フラグの適否
            if (checkBoxMaFlag.CheckState == CheckState.Indeterminate)
            {
                MessageBox.Show(" 非表示フラグが不確定の状態です");
                checkBoxMaFlag.Focus();
                return false;
            }
            // 備考の適否
            if (!String.IsNullOrEmpty(textBoxMaHidden.Text.Trim()))
            {
                if (textBoxMaHidden.TextLength > 100)
                {
                    MessageBox.Show("備考は80文字以下です");
                    textBoxMaHidden.Focus();
                    return false;
                }
            }
            return false;
        }
        ///////////////////////////////
        //　8.2.1.2 営業所情報作成
        //メソッド名：GenerateDataAtRegistration()
        //引　数   ：なし
        //戻り値   ：営業所登録情報
        //機　能   ：登録データのセット
        ///////////////////////////////
        private M_SalesOffice GenerateDataAtRegistration()
        {
            return new M_SalesOffice
            {
                SoID = int.Parse(textBoxSoID.Text.Trim()),
                SoName = textBoxSoName.Text.Trim(),
                SoFlag = Convert.ToInt32(checkBoxMaFlag.Checked),
                SoHidden = textBoxMaHidden.Text.Trim(),
            };
        }

        ///////////////////////////////
        //　8.2.1.3 営業所情報登録
        //メソッド名：RegistrationSalesOffice()
        //引　数   ：営業所情報
        //戻り値   ：なし
        //機　能   ：営業所データの登録
        ///////////////////////////////
        private void RegistrationSalesOffice(M_SalesOffice regSalesOffice)
        {
            // 登録確認メッセージ
            DialogResult result = MessageBox.Show("営業所データを登録してよろしいですか?");
            if (result == DialogResult.Cancel)
                return;

            // 営業所情報の登録
            bool flg = salesOfficeDataAccess.AddSalesOfficeData(regSalesOffice);
            if (flg == true)
                MessageBox.Show("データを登録しました。");
            else
                MessageBox.Show("データの登録に失敗しました。");



        }
    }
}