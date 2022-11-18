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
            //panelSetting.Visible = false;
            //userControlMaker1.Visible = false;
            //userControlMajorClassification1.Visible = false;
            //userControlSmallClassification1.Visible = false;
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
            //labelProduct.Text = "メーカー管理";
            //userControlMaker1.Visible = true;
            //userControlMajorClassification1.Visible = false;
            //userControlSmallClassification1.Visible = false;
        }

        private void buttonEmployee_Click(object sender, EventArgs e)
        {
            //商品管理ボタン
            //labelProduct.Text = "商品管理";
            //panelSetting.Visible = false;
            //userControlMaker1.Visible = false;
            //userControlMajorClassification1.Visible = false;
            //userControlSmallClassification1.Visible = false;
        }

        private void buttonFormDel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonMajorClassification_Click(object sender, EventArgs e)
        {
            //    labelProduct.Text = "大分類管理";
            //    userControlMaker1.Visible = false;
            //    userControlMajorClassification1.Visible = true;
            //    userControlSmallClassification1.Visible = false;
        }

        private void buttonSmallClassification_Click(object sender, EventArgs e)
        {
            //labelProduct.Text = "小分類管理";
            //userControlMaker1.Visible = false;
            //userControlMajorClassification1.Visible = false;
            //userControlSmallClassification1.Visible = true;
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

        private void ClearInput()
        {
            comboBoxMaker.SelectedIndex = -1;
            textBoxPrName.Text = "";
            textBoxJCode.Text = "";
            comboBoxMc.SelectedIndex = -1;
            comboBoxSc.SelectedIndex = -1;
            textBoxColor.Text = "";
            DateTimePickerDateTimePickerPrReleaseDate.Checked = false;
            checkBoxPrFlag.Checked = false;
            textBoxPrHidden.Text = "";
        }

        private void SetFormDataGridView()
        {
            //dataGridViewのページサイズ指定
            textBoxPageSize.Text = "10";
            //dataGridViewのページ番号指定
            textBoxPage.Text = "1";
            //読み取り専用に指定
            dataGridViewProduct.ReadOnly = true;
            //行内をクリックすることで行を選択
            dataGridViewProduct.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //ヘッダー位置の指定
            dataGridViewProduct.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //データグリッドビューのデータ取得
            GetDataGridView();
        }

        private void GetDataGridView()
        {
            // 商品データの取得
            Product = ProductDataAccess.GetProductData();

            // DataGridViewに表示するデータを指定
            SetDataGridView();
        }

        private void SetDataGridView()
        {
            int pageSize = int.Parse(textBoxPageSize.Text);
            int pageNo = int.Parse(textBoxPage.Text) - 1;
            dataGridViewProduct.DataSource = Product.Skip(pageSize * pageNo).Take(pageSize).ToList();

            dataGridViewProduct.Columns[0].Width = 100;
        }

        private void buttonRegist_Click(object sender, EventArgs e)
        {
            // 8.3.1.1 妥当な商品データ取得
            if (!GetValidDataAtRegistration())
                return;

            // 8.3.1.2 商品情報作成
            var regProduct = GenerateDataAtRegistration();

            // 8.3.1.3 商品情報登録
            RegistrationProduct(regProduct);
        }

        private bool GetValidDataAtRegistration()
        {
            //メーカー名の選択チェック
            if (comboBoxMaker.SelectedIndex == -1)
            {
                //メーカーIDが選択されていません
                messageDsp.DspMsg("M0407");
                comboBoxMaker.Focus();
                return false;
            }
            if (!String.IsNullOrEmpty(textBoxPrName.Text.Trim()))
            {

                if (textBoxPrName.TextLength > 50)
                {
                    //商品名は50文字以下です
                    messageDsp.DspMsg("M0409");
                    textBoxPrName.Focus();
                    return false;
                }

            }
            else
            {
                //商品名が入力されていません
                messageDsp.DspMsg("M0410");
                textBoxPrName.Focus();
                return false;
            }

            if (comboBoxSc.SelectedIndex == -1)
            {
                DialogResult result = messageDsp.DspMsg("M0419");

                if (result == DialogResult.Cancel)
                {
                    comboBoxSc.Focus();
                    return false;
                }
            }

            //大分類IDが選択されていません
            if (comboBoxMc.SelectedIndex == -1)
            {
                DialogResult result = messageDsp.DspMsg("M0437");

                if (result == DialogResult.Cancel)
                {
                    comboBoxMc.Focus();
                    return false;
                }
            }

            if (!String.IsNullOrEmpty(textBoxJCode.Text.Trim()))
            {
                if (textBoxJCode.TextLength > 9)
                {
                    //価格は9桁以下です
                    messageDsp.DspMsg("M0412");
                    textBoxJCode.Focus();
                    return false;
                }
            }
            else
            {
                //価格が入力されていません
                messageDsp.DspMsg("M0413");
                textBoxJCode.Focus();
                return false;
            }

            if (!String.IsNullOrEmpty(textBoxColor.Text.Trim()))
            {
                if (textBoxColor.TextLength > 20)
                {
                    //色は20文字以下です
                    messageDsp.DspMsg("M0438");
                    textBoxColor.Focus();
                    return false;
                }
                if (!dataInputFormCheck.CheckFullWidth(textBoxColor.Text.Trim()))
                {
                    //色は全角入力です
                    messageDsp.DspMsg("M0439");
                    textBoxColor.Focus();
                    return false;

                }
            }
            else
            {
                //色が入力されていません
                messageDsp.DspMsg("M0423");
                textBoxColor.Focus();
                return false;
            }

            if (checkBoxPrFlag.CheckState == CheckState.Indeterminate)
            {
                //非表示フラグが未確定な状態です
                messageDsp.DspMsg("M0433");
                checkBoxPrFlag.Focus();
                return false;
            }


            if (checkBoxPrFlag.Checked==true&& String.IsNullOrEmpty(textBoxPrHidden.Text.Trim()))
            {
                //非表示理由が入力されていません
                messageDsp.DspMsg("M0440");
                textBoxPrHidden.Focus();
                return false;
            }


            return true;
        }

        private M_Product GenerateDataAtRegistration()
        {
            int Pdflg = 0;
            if (checkBoxPrFlag.Checked == true)
            {
                Pdflg = 2;
            }

            return new M_Product
            {
                PrID = int.Parse(textBoxPrID.Text.Trim()),
                MaID = int.Parse(comboBoxMaker.SelectedValue.ToString()),
                PrName = textBoxPrName.Text.Trim(),
                Price =int.Parse(textBoxJCode.Text.Trim()),
                PrSafetyStock = int.Parse(textBoxPrSafetyStock.Text.Trim()),
                ScID = int.Parse(comboBoxSc.SelectedValue.ToString()),
                PrModelNumber = textBoxPrModelNumber.Text.Trim(),
                PrColor = textBoxColor.Text.Trim(),
                PrReleaseDate = DateTime.Parse(DateTimePickerDateTimePickerPrReleaseDate.Text),//DateTimePickerDateTimePickerPrReleaseDate.Value,
                PrFlag =Pdflg,
                PrHidden=textBoxPrHidden.Text.Trim()
            };
        }

        private void RegistrationProduct(M_Product regProduct)
        {
            //商品データを登録してよろしいですか？
            DialogResult result = messageDsp.DspMsg("M0425");
            if (result == DialogResult.Cancel)
                return;

            bool flg = ProductDataAccess.AddProductData(regProduct);
            if (flg == true)
            {
                //商品データを登録しました
                messageDsp.DspMsg("M0426");
            }
            else
            {
                //商品データ登録に失敗しました
                messageDsp.DspMsg("M0427");
            }

            textBoxPrID.Focus();

            ClearInput();

            

            
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            //日時更新
            labelDay.Text = DateTime.Now.ToString("yyyy/MM/dd/(ddd)");
            labelTime.Text = DateTime.Now.ToString("HH:mm");
        }
    }


}
