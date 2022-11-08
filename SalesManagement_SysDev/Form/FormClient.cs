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
                //電話番号の半角英数字チェック
                if (!dataInputFormCheck.CheckHalfAlphabetNumeric(textBoxClPhone.Text.Trim()))
                {
                    MessageBox.Show("電話番号は半角英数字入力です");
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
                    //郵便番号は半角英数字入力です
                    messageDsp.DspMsg("M0321");
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
                if (!dataInputFormCheck.CheckHalfAlphabetNumeric(textBoxClFAX.Text.Trim()))
                {
                    MessageBox.Show("FAXは半角英数字入力です");
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
            return new M_Client
            {

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

        }

    }
}
