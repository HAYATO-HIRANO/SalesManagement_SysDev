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
    public partial class FormProduct : Form
    {
        //メッセージ表示用クラスのインスタンス化
        MessageDsp messageDsp = new MessageDsp();
        //データベース商品テーブルアクセス用クラスのインスタンス化
        ProductDataAccess ProductDataAccess = new ProductDataAccess();
        //データベース大分類テーブルアクセス用クラスのインスタンス化
        MajorClassificationDataAccess majorClassificationDataAccess = new MajorClassificationDataAccess();
        //データベース小分類テーブルアクセス用クラスのインスタンス化
        SmallClassification smallClassification = new SmallClassification();
        //データベースメーカーテーブルアクセス用クラスのインスタンス化
        MakerDataAccess makerDataAccess = new MakerDataAccess();
        //入力形式チェック用クラスのインスタンス化
        DataInputFormCheck dataInputFormCheck = new DataInputFormCheck();
        //データグリッドビュー用の商品データ
        private static List<M_Product> Product;
        //コンボボックス用のメーカーデータ
        private static List<M_Maker> Maker;
        //コンボボックス用のメーカーデータ
        private static List<M_MajorCassification> MajorCassifications;
        //コンボボックス用のメーカーデータ
        private static List<M_SmallClassification> SmallClassifications;
        public FormProduct()
        {
            InitializeComponent();
        }

        private void textBoxClFAX_TextChanged(object sender, EventArgs e)
        {

        }

        private void FormProduct_Load(object sender, EventArgs e)
        {
            panelSetting.Visible = false;
            userControlMaker1.Visible = false;
            userControlMajorClassification1.Visible = false;
            userControlSmallClassification1.Visible = false;
            //日時の表示
            labelDay.Text = DateTime.Now.ToString("yyyy/MM/dd/(ddd)");
            labelTime.Text = DateTime.Now.ToString("HH:mm");
            //panelHeaderに表示するログインデータ
            labelUserName.Text = "ユーザー名：" + FormMain.loginName;
            labelPosition.Text = "権限:" + FormMain.loginPoName;
            labelSalesOffice.Text = FormMain.loginSoName;
            labelUserID.Text = "ユーザーID：" + FormMain.loginEmID.ToString();
        }

        private void panelSetting_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buttonSetting_Click(object sender, EventArgs e)
        {
            panelSetting.Visible = true;
        }

        private void buttonMaker_Click(object sender, EventArgs e)
        {
            labelProduct.Text = "メーカー管理";
            userControlMaker1.Visible = true;
            //userControlMajorClassification1.Visible = false;
            //userControlSmallClassification1.Visible = false;
        }

        private void buttonEmployee_Click(object sender, EventArgs e)
        {
            //商品管理ボタン
            labelProduct.Text = "商品管理";
            panelSetting.Visible = false;
            userControlMaker1.Visible = false;
            userControlMajorClassification1.Visible = false;
            userControlSmallClassification1.Visible = false;
        }

        private void buttonFormDel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonMajorClassification_Click(object sender, EventArgs e)
        {
            labelProduct.Text = "大分類管理";
            userControlMaker1.Visible = false;
            userControlMajorClassification1.Visible = true;
            userControlSmallClassification1.Visible = false;
        }

        private void buttonSmallClassification_Click(object sender, EventArgs e)
        {
            labelProduct.Text = "小分類管理";
            userControlMaker1.Visible = false;
            userControlMajorClassification1.Visible = false;
            userControlSmallClassification1.Visible = true;
        }

        private void comboBoxSc_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void labelSc_Click(object sender, EventArgs e)
        {

        }

        private void buttonClear_Click(object sender, EventArgs e)
        {

        }

        private void panel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
