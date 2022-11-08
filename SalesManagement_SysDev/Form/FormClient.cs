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
