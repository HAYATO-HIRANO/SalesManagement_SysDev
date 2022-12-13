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
        private int SelectedMcID = 0;
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
        private static List<M_ProductDsp> Product;
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

            
            // コンボボックスの設定
            SetFormComboBox();

            // データグリッドビューの表示
            SetFormDataGridView();
        }

        private void panelSetting_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buttonSetting_Click(object sender, EventArgs e)
        {
            panelSetting.Visible = true;
            panelLeft.Visible = false;
        }

        private void buttonMaker_Click(object sender, EventArgs e)
        {
            labelProduct.Text = "メーカー管理";
            panelProduct.Visible = false;
            userControlMaker1.Visible = true;
            userControlMajorClassification1.Visible = false;
            userControlSmallClassification1.Visible = false;
        }

        private void buttonEmployee_Click(object sender, EventArgs e)
        {
            //商品管理ボタン
            labelProduct.Text = "商品管理";
            panelProduct.Visible = true;
            panelLeft.Visible = true;
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
             panelProduct.Visible = false;
             userControlMaker1.Visible = false;
             userControlMajorClassification1.Visible = true;
             userControlSmallClassification1.Visible = false;
        }

        private void buttonSmallClassification_Click(object sender, EventArgs e)
        {
            labelProduct.Text = "小分類管理";
            panelProduct.Visible = false;
            userControlMaker1.Visible = false;
            userControlMajorClassification1.Visible = false;
            userControlSmallClassification1.Visible = true;
        }

        private void comboBoxSc_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (comboBoxSc.SelectedIndex == -1)
            //{
            //    return;
            //}

            
            //SmallClassifications = smallClassification.GetScDspData(int.Parse(comboBoxSc.SelectedValue.ToString()));
            //comboBoxSc.DataSource = SmallClassifications;
            //comboBoxSc.DisplayMember = "ScName";
            //comboBoxSc.ValueMember = "ScID";
            //comboBoxSc.SelectedIndex = -1;
        }
        private void comboBoxMc_SelectedIndexChanged(object sender, EventArgs e)
        {
            object selectedItem = comboBoxMc.SelectedItem;

            if (selectedItem != null && selectedItem is M_MajorCassification)
            {
                SelectedMcID = ((M_MajorCassification) selectedItem).McID;

                SmallClassifications = smallClassification.GetParentScDspData(SelectedMcID);
                comboBoxSc.DataSource = SmallClassifications;
                comboBoxSc.DisplayMember = "ScName";
                comboBoxSc.ValueMember = "ScID";

            }

        }

        private void labelSc_Click(object sender, EventArgs e)
        {

        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            // 入力エリアのクリア
            ClearInput();

           
        }

        private void panel_Paint(object sender, PaintEventArgs e)
        {

        }
        private void SetFormComboBox()
        {
            // 商品データの取得
           ;
            Maker = makerDataAccess.GetMakerDspData();
            comboBoxMaker.DataSource = Maker;
            comboBoxMaker.DisplayMember = "MaName";
            comboBoxMaker.ValueMember = "MaID";
            MajorCassifications = majorClassificationDataAccess.GetMcDspData();
            comboBoxMc.DataSource = MajorCassifications;
            comboBoxMc.DisplayMember = "McName";
            comboBoxMc.ValueMember = "McID";

            


            // コンボボックスを読み取り専用
            comboBoxMaker.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxMaker.SelectedIndex = -1;
            comboBoxMc.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxMc.SelectedIndex = -1;
            comboBoxSc.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxSc.SelectedIndex = -1;
        }

        private void ClearInput()
        {
            textBoxPrID.Text = "";
            comboBoxMaker.SelectedIndex = -1;
            textBoxPrName.Text = "";
            textBoxPrice.Text = "";
            textBoxPrSafetyStock.Text = "";
            comboBoxMc.SelectedIndex = -1;
            comboBoxSc.SelectedIndex = -1;
            textBoxColor.Text = "";
            textBoxPrModelNumber.Text = "";
            DateTimePickerDateTimePickerPrReleaseDate.Checked = false;
            checkBoxPrFlag.Checked = false;
            textBoxPrHidden.Text = "";
        }

        private void SetFormDataGridView()
        {
            //dataGridViewのページサイズ指定
            textBoxPageSize.Text = "20";
            //dataGridViewのページ番号指定
            textBoxPage.Text = "1";
            //読み取り専用に指定
            dataGridViewProduct.ReadOnly = true;
            //直接のサイズの変更を不可
            dataGridViewProduct.AllowUserToResizeRows = false;
            dataGridViewProduct.AllowUserToResizeColumns = false;
            //直接の登録を不可にする
            dataGridViewProduct.AllowUserToAddRows = false;
            //奇数行の色を変更
            dataGridViewProduct.AlternatingRowsDefaultCellStyle.BackColor = Color.Honeydew;
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

            //各列幅の指定
            dataGridViewProduct.Columns[0].Width = 100;
            dataGridViewProduct.Columns[1].Width = 100;
            dataGridViewProduct.Columns[1].Visible = false;
            dataGridViewProduct.Columns[2].Width = 110;
            dataGridViewProduct.Columns[3].Width = 170;
            dataGridViewProduct.Columns[4].Width = 90;
            dataGridViewProduct.Columns[5].Width = 70;
            dataGridViewProduct.Columns[6].Visible = false;
            dataGridViewProduct.Columns[7].Width = 170;
            dataGridViewProduct.Columns[8].Visible = false;
            dataGridViewProduct.Columns[9].Width = 100;
            //dataGridViewProduct.Columns[9].Visible = false;
            dataGridViewProduct.Columns[10].Width = 70;
            dataGridViewProduct.Columns[11].Width = 80;
            dataGridViewProduct.Columns[12].Width = 120;
            dataGridViewProduct.Columns[13].Visible=false;
            dataGridViewProduct.Columns[14].Width = 405;

            //各列の文字位置の指定
            dataGridViewProduct.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewProduct.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewProduct.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewProduct.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewProduct.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewProduct.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewProduct.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewProduct.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewProduct.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewProduct.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewProduct.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewProduct.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewProduct.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewProduct.Columns[14].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            labelPage.Text = "/" + ((int)Math.Ceiling(Product.Count / (double)pageSize)) + "ページ";

            dataGridViewProduct.Refresh();
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

        ///////////////////////////////
        //　         妥当な商品データ取得
        //メソッド名：GetValidDataAtRegistration()
        //引　数   ：なし
        //戻り値   ：true or false
        //機　能   ：入力データの形式チェック
        //          ：エラーがない場合True
        //          ：エラーがある場合False
        ///////////////////////////////

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

            // 商品名の適否
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

            //大分類IDの選択チェック
            if (comboBoxMc.SelectedIndex == -1)
            {
                //大分類IDが選択されていません
                DialogResult result = messageDsp.DspMsg("M0437");

                if (result == DialogResult.Cancel)
                {
                    comboBoxMc.Focus();
                    return false;
                }
            }
            //小分類IDの選択チェック
            if (comboBoxSc.SelectedIndex == -1)
            {
                //小分類IDが選択されていません
                DialogResult result = messageDsp.DspMsg("M0419");

                if (result == DialogResult.Cancel)
                {
                    comboBoxSc.Focus();
                    return false;
                }
            }

            //価格入力チェック
            if (!String.IsNullOrEmpty(textBoxPrice.Text.Trim()))
            {
                if (textBoxPrice.TextLength > 9)
                {
                    //価格は9桁以下です
                    messageDsp.DspMsg("M0412");
                    textBoxPrice.Focus();
                    return false;
                }
            }
            else
            {
                //価格が入力されていません
                messageDsp.DspMsg("M0413");
                textBoxPrice.Focus();
                return false;
            }
            //色の入力チェック
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
            //型番の適否
            if (!String.IsNullOrEmpty(textBoxPrModelNumber.Text.Trim()))
            {
                if (!dataInputFormCheck.CheckHalfChar(textBoxPrModelNumber.Text.Trim()))
                {
                    //型番は半角入力です
                    messageDsp.DspMsg("M0420");
                    textBoxPrModelNumber.Focus();
                    return false;
                }


                if (textBoxPrModelNumber.TextLength > 20)
                {
                    //型番は20文字以下です
                    messageDsp.DspMsg("M0421");
                    textBoxPrModelNumber.Focus();

                }

                

            }
            else
            {
                //型番が入力されていません
                messageDsp.DspMsg("M0422");
                textBoxPrModelNumber.Focus();
                return false;
            }
            //非表示フラグのチェック
            if (checkBoxPrFlag.CheckState == CheckState.Indeterminate)
            {
                //非表示フラグが未確定な状態です
                messageDsp.DspMsg("M0433");
                checkBoxPrFlag.Focus();
                return false;
            }

            //非表示理由の入力チェック
            if (checkBoxPrFlag.Checked==true&& String.IsNullOrEmpty(textBoxPrHidden.Text.Trim()))
            {
                //非表示理由が入力されていません
                messageDsp.DspMsg("M0440");
                textBoxPrHidden.Focus();
                return false;
            }


            return true;
        }

        ///////////////////////////////
        //　          商品カテゴリ情報作成
        //メソッド名：GenerateDataAtRegistration()
        //引　数   ：なし
        //戻り値   ：商品カテゴリ登録情報
        //機　能   ：登録データのセット
        ///////////////////////////////

        private M_Product GenerateDataAtRegistration()
        {
            int Pdflg = 0;
            if (checkBoxPrFlag.Checked == true)
            {
                Pdflg = 2;
            }

            return new M_Product
            {
               // PrID = int.Parse(textBoxPrID.Text.Trim()),
                MaID = int.Parse(comboBoxMaker.SelectedValue.ToString()),
                PrName = textBoxPrName.Text.Trim(),
                Price =int.Parse(textBoxPrice.Text.Trim()),
                PrSafetyStock = int.Parse(textBoxPrSafetyStock.Text.Trim()),
                ScID = int.Parse(comboBoxSc.SelectedValue.ToString()),
                PrModelNumber = textBoxPrModelNumber.Text.Trim(),
                PrColor = textBoxColor.Text.Trim(),
                PrReleaseDate = DateTime.Parse(DateTimePickerDateTimePickerPrReleaseDate.Text),//DateTimePickerDateTimePickerPrReleaseDate.Value,
                PrFlag =Pdflg,
                PrHidden=textBoxPrHidden.Text.Trim()
            };
        }

        ///////////////////////////////
        //　          商品情報登録
        //メソッド名：RegistrationCategory()
        //引　数   ：商品カテゴリ情報
        //戻り値   ：なし
        //機　能   ：商品カテゴリデータの登録

        ///////////////////////////////

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

            // 入力エリアのクリア
            ClearInput();

            // データグリッドビューの表示
            GetDataGridView();

            
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            //日時更新
            labelDay.Text = DateTime.Now.ToString("yyyy/MM/dd/(ddd)");
            labelTime.Text = DateTime.Now.ToString("HH:mm");
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            // 妥当な商品データ取得
            if (!GetValidDataAtUpdate())
            {
                return;
            }

            // 商品情報作成
            var upProduct = ProductDataAtUpdate();

            //商品情報更新
            UpdateProduct(upProduct);
        }

        ///////////////////////////////
        //　         妥当な商品データ取得
        //メソッド名：GetValidDataAtUpdate()
        //引　数   ：なし
        //戻り値   ：true or false
        //機　能   ：入力データの形式チェック
        //          ：エラーがない場合True
        //          ：エラーがある場合False
        ///////////////////////////////
        ///
        private bool GetValidDataAtUpdate()
        {
            //商品IDの適否
            if (!String.IsNullOrEmpty(textBoxPrID.Text.Trim()))
            {
                if (!dataInputFormCheck.CheckHalfAlphabetNumeric(textBoxPrID.Text.Trim()))
                {
                    //商品IDは半角英数値入力です
                    messageDsp.DspMsg("M0401");
                    textBoxPrID.Focus();
                    return false;
                }
                if (textBoxPrID.TextLength > 6)
                {
                    //商品IDは6文字です
                    messageDsp.DspMsg("M0402");
                    textBoxPrID.Focus();
                    return false;
                }

                if (!ProductDataAccess.CheckPrIDExistence(int.Parse(textBoxPrID.Text.Trim())))
                {
                    //入力された商品IDは存在していません
                    messageDsp.DspMsg("M0403");
                    textBoxPrID.Focus();
                    return false;
                }

            }
            else
            {
                //商品IDが入力されていません
                messageDsp.DspMsg("M0404");
                textBoxPrID.Focus();
                return false;
            }

            //メーカー名の選択チェック
            if (comboBoxMaker.SelectedIndex == -1)
            {
                //メーカーIDが選択されていません
                messageDsp.DspMsg("M0407");
                comboBoxMaker.Focus();
                return false;
            }

            // 商品名の適否
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

            //大分類IDの選択チェック
            if (comboBoxMc.SelectedIndex == -1)
            {
                //大分類IDが選択されていません
                DialogResult result = messageDsp.DspMsg("M0437");

                if (result == DialogResult.Cancel)
                {
                    comboBoxMc.Focus();
                    return false;
                }
            }
            //小分類IDの選択チェック
            if (comboBoxSc.SelectedIndex == -1)
            {
                //小分類IDが選択されていません
                DialogResult result = messageDsp.DspMsg("M0419");

                if (result == DialogResult.Cancel)
                {
                    comboBoxSc.Focus();
                    return false;
                }
            }

            //価格入力チェック
            if (!String.IsNullOrEmpty(textBoxPrice.Text.Trim()))
            {
                if (textBoxPrice.TextLength > 9)
                {
                    //価格は9桁以下です
                    messageDsp.DspMsg("M0412");
                    textBoxPrice.Focus();
                    return false;
                }
            }
            else
            {
                //価格が入力されていません
                messageDsp.DspMsg("M0413");
                textBoxPrice.Focus();
                return false;
            }

            //安全在庫数入力チェック
            if (!String.IsNullOrEmpty(textBoxPrSafetyStock.Text.Trim()))
            {
                //安全在庫数は半角英数値入力です
                if (!dataInputFormCheck.CheckHalfAlphabetNumeric(textBoxPrSafetyStock.Text.Trim()))
                {
                    messageDsp.DspMsg("M0414");
                    textBoxPrSafetyStock.Focus();
                    return false;
                }

                if (textBoxPrSafetyStock.TextLength > 4)
                {
                    //安全在庫数は4桁以下です
                    messageDsp.DspMsg("M0415");
                    textBoxPrSafetyStock.Focus();
                    return false;
                }
                
            }
            else
            {
                //安全在庫数が入力されていません
                messageDsp.DspMsg("M0416");
                textBoxPrSafetyStock.Focus();
                return false;
            }

            //型番の適否
            if (!String.IsNullOrEmpty(textBoxPrModelNumber.Text.Trim()))
            {
                if (!dataInputFormCheck.CheckHalfChar(textBoxPrModelNumber.Text.Trim()))
                {
                    //型番は半角入力です
                    messageDsp.DspMsg("M0420");
                    textBoxPrModelNumber.Focus();
                    return false;
                }

                
                if (textBoxPrModelNumber.TextLength >20)
                {
                    //型番は20文字以下です
                    messageDsp.DspMsg("M0421");
                    textBoxPrModelNumber.Focus();

                }

                if (!ProductDataAccess.CheckPrModelNumberExistence(textBoxPrModelNumber.Text.Trim()))
                {
                    //入力された型番は存在していません
                    messageDsp.DspMsg("M0441");
                    textBoxPrModelNumber.Focus();
                    return false;
                }

            }
            else
            {
                //型番が入力されていません
                messageDsp.DspMsg("M0422");
                textBoxPrModelNumber.Focus();
                return false;
            }

            //色の入力チェック
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
            //非表示フラグのチェック
            if (checkBoxPrFlag.CheckState == CheckState.Indeterminate)
            {
                //非表示フラグが未確定な状態です
                messageDsp.DspMsg("M0433");
                checkBoxPrFlag.Focus();
                return false;
            }

            //非表示理由の入力チェック
            if (checkBoxPrFlag.Checked == true && String.IsNullOrEmpty(textBoxPrHidden.Text.Trim()))
            {
                //非表示理由が入力されていません
                messageDsp.DspMsg("M0440");
                textBoxPrHidden.Focus();
                return false;
            }


            return true;
        }

        ///////////////////////////////
        //           商品情報作成
        //メソッド名：GenerateDataAtUpdate()
        //引　数   ：なし
        //戻り値   ：商品カテゴリ更新情報
        //機　能   ：更新データのセット
        //////////////////////////////

        private M_Product ProductDataAtUpdate()
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
                Price =int.Parse(textBoxPrice.Text.Trim()),
                PrSafetyStock = int.Parse(textBoxPrSafetyStock.Text.Trim()),
                ScID = int.Parse(comboBoxSc.SelectedValue.ToString()),
                PrModelNumber = textBoxPrModelNumber.Text.Trim(),
                PrColor = textBoxColor.Text.Trim(),
                PrReleaseDate = DateTime.Parse(DateTimePickerDateTimePickerPrReleaseDate.Text),//DateTimePickerDateTimePickerPrReleaseDate.Value,
                PrFlag =Pdflg,
                PrHidden=textBoxPrHidden.Text.Trim()
            };
        }


        ///////////////////////////////
        //　         商品情報更新
        //メソッド名：UpdateCategory()
        //引　数   ：商品情報
        //戻り値   ：なし
        //機　能   ：商品情報の更新
        ///////////////////////////////

        private void UpdateProduct(M_Product upProduct)
        {
            //在庫データを更新してよろしいですか？
            DialogResult result = messageDsp.DspMsg("M0512");
            if(result == DialogResult.Cancel)
            {
                return;
            }
            bool flg = ProductDataAccess.UpdateProductData(upProduct);
            if (flg == true)
            {
                //在庫データを更新しました
                messageDsp.DspMsg("M0513");
            }
            else
            {
                //在庫データ更新に失敗しました
                messageDsp.DspMsg("M0514");
            }
            textBoxPrID.Focus();
            //入力エリアのクリア
            ClearInput();
            // コンボボックスの設定
            SetFormComboBox();
            // データグリッドビューの表示
            GetDataGridView();

        }

        ///////////////////////////////
        //　         妥当な商品データ取得
        //メソッド名：GetValidDataAtSlect()
        //引　数   ：なし
        //戻り値   ：true or false
        //機　能   ：入力データの形式チェック
        //          ：エラーがない場合True
        //          ：エラーがある場合False
        ///////////////////////////////

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            // 妥当な商品カテゴリデータ取得
            if (!GetValidDataAtSelect())
            {
                return;
            }

            //  商品カテゴリ情報抽出
            GenerateDataAtSelect();

            // 商品カテゴリ抽出結果表示
            SetSelectData();
        }

        private bool GetValidDataAtSelect()
        {
            //商品IDの適否
            if (!String.IsNullOrEmpty(textBoxPrID.Text.Trim()))
            {
                if (!dataInputFormCheck.CheckHalfAlphabetNumeric(textBoxPrID.Text.Trim()))
                {
                    //商品IDは半角英数値入力です
                    messageDsp.DspMsg("M0401");
                    textBoxPrID.Focus();
                    return false;
                }

                if (textBoxPrID.TextLength > 6)
                {
                    //商品IDは6文字です
                    messageDsp.DspMsg("M0402");
                    textBoxPrID.Focus();
                    return false;
                }

                if (!ProductDataAccess.CheckPrIDExistence(int.Parse(textBoxPrID.Text.Trim())))
                {
                    //入力された商品IDは存在していません
                    messageDsp.DspMsg("M0403");
                    textBoxPrID.Focus();
                    return false;
                }

            }
            

            

            // 商品名の適否
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
            
            

            //価格入力チェック
            if (!String.IsNullOrEmpty(textBoxPrice.Text.Trim()))
            {
                if (textBoxPrice.TextLength > 9)
                {
                    //価格は9桁以下です
                    messageDsp.DspMsg("M0412");
                    textBoxPrice.Focus();
                    return false;
                }
                if (!dataInputFormCheck.CheckNumeric(textBoxPrice.Text.Trim()))
                {
                    messageDsp.DspMsg("M0413");
                    textBoxPrice.Focus();
                    return false;
                }
            }
            

            //安全在庫数入力チェック
            if (!String.IsNullOrEmpty(textBoxPrSafetyStock.Text.Trim()))
            {
                //安全在庫数は半角英数値入力です
                if (!dataInputFormCheck.CheckHalfAlphabetNumeric(textBoxPrSafetyStock.Text.Trim()))
                {
                    messageDsp.DspMsg("M0414");
                    textBoxPrSafetyStock.Focus();
                    return false;
                }

                if (textBoxPrSafetyStock.TextLength > 4)
                {
                    //安全在庫数は4桁以下です
                    messageDsp.DspMsg("M0415");
                    textBoxPrSafetyStock.Focus();
                    return false;
                }

            }
            

            //型番の適否
            if (!String.IsNullOrEmpty(textBoxPrModelNumber.Text.Trim()))
            {
                if (!dataInputFormCheck.CheckHalfChar(textBoxPrModelNumber.Text.Trim()))
                {
                    //型番は半角入力です
                    messageDsp.DspMsg("M0420");
                    textBoxPrModelNumber.Focus();
                    return false;
                }


                if (textBoxPrModelNumber.TextLength > 20)
                {
                    //型番は20文字以下です
                    messageDsp.DspMsg("M0421");
                    textBoxPrModelNumber.Focus();

                }

                //if (!ProductDataAccess.CheckPrModelNumberExistence(textBoxPrModelNumber.Text.Trim()))
                //{
                //    //入力された型番は存在していません
                //    messageDsp.DspMsg("M0441");
                //    textBoxPrModelNumber.Focus();
                //    return false;
                //}

            }
           

            //色の入力チェック
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
            
            //非表示フラグのチェック
            if (checkBoxPrFlag.Checked==true)
            {
                //非表示フラグがチェックされています
                messageDsp.DspMsg("M0442");
                checkBoxPrFlag.Focus();
                return false;
            }



            return true;
        }
        ///////////////////////////////
        //　         商品情報抽出
        //メソッド名：GenerateDataAtSelect()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：商品情報の取得
        ///////////////////////////////
        
        private int price=0;
        private int PrSS=0 ;

        private void GenerateDataAtSelect()
        {
            object ProID = textBoxPrID.Text;


            
            
            if ( ProID is M_ProductDsp)
            {
                price = ((M_ProductDsp)ProID).Price;
                PrSS = ((M_ProductDsp)ProID).PrSafetyStock;
                
            }


            int Pdflg = 0;
            if (checkBoxPrFlag.Checked == true)
            {
                Pdflg = 2;
            }
            // コンボボックスが未選択の場合
            string makercmb = "";
            string sccmb = "";
            if (comboBoxMaker.SelectedIndex != -1)
            {
                makercmb = comboBoxMaker.SelectedValue.ToString();
            }
            if (comboBoxSc.SelectedIndex != -1)
            {
                sccmb = comboBoxSc.SelectedValue.ToString();
            }
          
           

            //商品IDが入力されていて、なおかつメーカー名が選択されて、なおかつ小分類IDが入力されている状態  
            if (!String.IsNullOrEmpty(textBoxPrID.Text.Trim()) && makercmb != ""&&sccmb!="")
            {
                 

                M_ProductDsp selectCondition = new M_ProductDsp()
                {
                    PrID = int.Parse(textBoxPrID.Text.Trim()),
                    MaID = int.Parse(makercmb),
                    PrName = textBoxPrName.Text.Trim(),
                    Price =price,
                    PrSafetyStock = PrSS,
                    ScID = int.Parse(sccmb),
                    PrModelNumber = textBoxPrModelNumber.Text.Trim(),
                    PrColor = textBoxColor.Text.Trim(),
                    PrReleaseDate = DateTime.Parse(DateTimePickerDateTimePickerPrReleaseDate.Text),//DateTimePickerDateTimePickerPrReleaseDate.Value,
                    PrFlag = Pdflg,
                    PrHidden = textBoxPrHidden.Text.Trim()
                };
                Product = ProductDataAccess.GetProductData(1,selectCondition);
            }
            //商品IDが入力されていて、なおかつメーカー名が選択されていて、小分類ID選択されていない状態
            else if (!String.IsNullOrEmpty(textBoxPrID.Text.Trim()) && makercmb != ""&&sccmb == "")
            {
                M_ProductDsp selectCondition = new M_ProductDsp()
                {

                    PrID = int.Parse(textBoxPrID.Text.Trim()),
                    MaID = int.Parse(makercmb),
                    PrName = textBoxPrName.Text.Trim(),
                    Price = price,
                    PrSafetyStock = PrSS,
                    
                    PrModelNumber = textBoxPrModelNumber.Text.Trim(),
                    PrColor = textBoxColor.Text.Trim(),
                    PrReleaseDate = DateTime.Parse(DateTimePickerDateTimePickerPrReleaseDate.Text),//DateTimePickerDateTimePickerPrReleaseDate.Value,
                    PrFlag = Pdflg,
                    PrHidden = textBoxPrHidden.Text.Trim()
                };
                Product = ProductDataAccess.GetProductData(2, selectCondition);

            }
            //商品IDが入力されていて、メーカー名と小分類IDが選択されていない状態
            else if (!String.IsNullOrEmpty(textBoxPrID.Text))
            {
                M_ProductDsp selectCondition = new M_ProductDsp()
                {
                        PrID = int.Parse(textBoxPrID.Text.Trim()),
                        PrName = textBoxPrName.Text.Trim(),
                        //MaID=int.Parse(makercmb),
                        Price = price ,
                        PrSafetyStock = PrSS,
                        //McID=int.Parse(comboBoxMc.SelectedValue.ToString()),
                        //ScID=int.Parse(sccmb),
                        PrModelNumber = textBoxPrModelNumber.Text.Trim(),
                        PrColor = textBoxColor.Text.Trim(),
                        PrReleaseDate = DateTime.Parse(DateTimePickerDateTimePickerPrReleaseDate.Text),
                        PrFlag = Pdflg,
                        PrHidden = textBoxPrHidden.Text.Trim()
                };

                Product = ProductDataAccess.GetProductData(3, selectCondition);


            }
            //商品IDが入力されていなくて、メーカーIDと小分類IDが入力されている状態
            else if(makercmb!=""&&sccmb!="")
            {
                M_ProductDsp selectCondition = new M_ProductDsp()
                {
                    MaID=int.Parse(makercmb),
                    PrName = textBoxPrName.Text.Trim(),
                    Price = price,
                    PrSafetyStock = PrSS,
                    ScID = int.Parse(sccmb),
                    PrModelNumber = textBoxPrModelNumber.Text.Trim(),
                    PrColor = textBoxColor.Text.Trim(),
                    PrReleaseDate = DateTime.Parse(DateTimePickerDateTimePickerPrReleaseDate.Text),
                    PrFlag = Pdflg,
                    PrHidden = textBoxPrHidden.Text.Trim()
                };

                Product = ProductDataAccess.GetProductData(4, selectCondition);
            }
            //商品IDとメーカーID入力されていなくて、小分類IDが入力されている状態
            else if (makercmb==""&&sccmb != "")
            {
                M_ProductDsp selectCondition = new M_ProductDsp()
                {
                    PrName = textBoxPrName.Text.Trim(),
                    Price=price,
                    PrSafetyStock = PrSS,
                    ScID = int.Parse(sccmb),
                    PrModelNumber = textBoxPrModelNumber.Text.Trim(),
                    PrColor = textBoxColor.Text.Trim(),
                    PrReleaseDate = DateTime.Parse(DateTimePickerDateTimePickerPrReleaseDate.Text),
                    PrFlag = Pdflg,
                    PrHidden = textBoxPrHidden.Text.Trim()
                };

                Product = ProductDataAccess.GetProductData(5, selectCondition);
            }
            //商品IDと小分類ID入力されていて、メーカーIDが入力されていない状態
            else if (!String.IsNullOrEmpty(textBoxPrID.Text.Trim()) && makercmb == "" && sccmb != "")
            {
                M_ProductDsp selectCondition = new M_ProductDsp()
                {

                    PrID = int.Parse(textBoxPrID.Text.Trim()),
                    
                    PrName = textBoxPrName.Text.Trim(),
                    Price = price,
                    PrSafetyStock = PrSS,
                    ScID=int.Parse(sccmb),
                    PrModelNumber = textBoxPrModelNumber.Text.Trim(),
                    PrColor = textBoxColor.Text.Trim(),
                    PrReleaseDate = DateTime.Parse(DateTimePickerDateTimePickerPrReleaseDate.Text),//DateTimePickerDateTimePickerPrReleaseDate.Value,
                    PrFlag = Pdflg,
                    PrHidden = textBoxPrHidden.Text.Trim()
                };
                Product = ProductDataAccess.GetProductData(6, selectCondition);

            }
            //商品IDと小分類IDが入力されていなくて、メーカーIDが入力されている状態
            else if ( makercmb != "" && sccmb == "")
            {
                M_ProductDsp selectCondition = new M_ProductDsp()
                {

                    
                    MaID=int.Parse(makercmb),
                    PrName = textBoxPrName.Text.Trim(),
                    Price = price,
                    PrSafetyStock = PrSS,
                    
                    PrModelNumber = textBoxPrModelNumber.Text.Trim(),
                    PrColor = textBoxColor.Text.Trim(),
                    PrReleaseDate = DateTime.Parse(DateTimePickerDateTimePickerPrReleaseDate.Text),//DateTimePickerDateTimePickerPrReleaseDate.Value,
                    PrFlag = Pdflg,
                    PrHidden = textBoxPrHidden.Text.Trim()
                };
                Product = ProductDataAccess.GetProductData(7, selectCondition);

            }
            else
            {

                M_ProductDsp selectCondition = new M_ProductDsp()
                {
                        
                        PrName = textBoxPrName.Text.Trim(),
                        Price = price ,
                        PrSafetyStock = PrSS,
                        PrModelNumber = textBoxPrModelNumber.Text.Trim(),
                        PrColor = textBoxColor.Text.Trim(),
                        PrReleaseDate = DateTime.Parse(DateTimePickerDateTimePickerPrReleaseDate.Text),
                        PrFlag = Pdflg,
                        PrHidden = textBoxPrHidden.Text.Trim()
                };
                Product = ProductDataAccess.GetProductData(8, selectCondition);
            }

        }

        ///////////////////////////////
        //　5.2.4.3 商品カテゴリ抽出結果表示
        //メソッド名：SetSelectData()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：商品カテゴリ情報の表示
        ///////////////////////////////
       
        private void SetSelectData()
        {
            textBoxPage.Text = "1";

            int pageSize = int.Parse(textBoxPageSize.Text);

            dataGridViewProduct.DataSource = Product;

            labelPage.Text = "/" + ((int)Math.Ceiling(Product.Count / (double)pageSize)) + "ページ";
            dataGridViewProduct.Refresh();
        }

        private void userControlMajorClassification1_Load(object sender, EventArgs e)
        {

        }

        private void panelProduct_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelSetting_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void buttonNextPage_Click(object sender, EventArgs e)
        {
            int pageSize = int.Parse(textBoxPageSize.Text);
            int pageNo = int.Parse(textBoxPage.Text);
            //最終ページの計算
            int lastNo = (int)Math.Ceiling(Product.Count / (double)pageSize) - 1;
            //最終ページでなければ
            if (pageNo <= lastNo)
                dataGridViewProduct.DataSource = Product.Skip(pageSize * pageNo).Take(pageSize).ToList();

            // DataGridViewを更新
            dataGridViewProduct.Refresh();
            //ページ番号の設定
            int lastPage = (int)Math.Ceiling(Product.Count / (double)pageSize);
            if (pageNo >= lastPage)
                textBoxPage.Text = lastPage.ToString();
            else
                textBoxPage.Text = (pageNo + 1).ToString();
        }

        private void buttonPreviousPage_Click(object sender, EventArgs e)
        {
            int pageSize = int.Parse(textBoxPageSize.Text);
            int pageNo = int.Parse(textBoxPage.Text) - 2;
            dataGridViewProduct.DataSource = Product.Skip(pageSize * pageNo).Take(pageSize).ToList();

            // DataGridViewを更新
            dataGridViewProduct.Refresh();
            //ページ番号の設定
            if (pageNo + 1 > 1)
                textBoxPage.Text = (pageNo + 1).ToString();
            else
                textBoxPage.Text = "1";
        }

        private void dataGridViewProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            //クリックされた行データをテキストボックスへ
            textBoxPrID.Text = dataGridViewProduct.Rows[dataGridViewProduct.CurrentRow.Index].Cells[0].Value.ToString();
            comboBoxMaker.Text=dataGridViewProduct.Rows[dataGridViewProduct.CurrentRow.Index].Cells[2].Value.ToString();
            textBoxPrName.Text = dataGridViewProduct.Rows[dataGridViewProduct.CurrentRow.Index].Cells[3].Value.ToString();
            textBoxPrice.Text = dataGridViewProduct.Rows[dataGridViewProduct.CurrentRow.Index].Cells[4].Value.ToString();
            textBoxPrSafetyStock.Text =dataGridViewProduct.Rows[dataGridViewProduct.CurrentRow.Index].Cells[5].Value.ToString();
            comboBoxMc.Text = dataGridViewProduct.Rows[dataGridViewProduct.CurrentRow.Index].Cells[7].Value.ToString();
            comboBoxSc.Text = dataGridViewProduct.Rows[dataGridViewProduct.CurrentRow.Index].Cells[9].Value.ToString();
            textBoxPrModelNumber.Text = dataGridViewProduct.Rows[dataGridViewProduct.CurrentRow.Index].Cells[10].Value.ToString();
            textBoxColor.Text = dataGridViewProduct.Rows[dataGridViewProduct.CurrentRow.Index].Cells[11].Value.ToString();
            if (dataGridViewProduct.Rows[dataGridViewProduct.CurrentRow.Index].Cells[12].Value==null)
            {
                DateTimePickerDateTimePickerPrReleaseDate.Value = DateTime.Now;
                DateTimePickerDateTimePickerPrReleaseDate.Checked = false;
            }
            else
            {
                DateTimePickerDateTimePickerPrReleaseDate.Text = dataGridViewProduct.Rows[dataGridViewProduct.CurrentRow.Index].Cells[12].Value.ToString();
            }

            if( dataGridViewProduct.Rows[dataGridViewProduct.CurrentRow.Index].Cells[13].Value.ToString() != 2.ToString())
            {
                checkBoxPrFlag.Checked = false;
            }
            else
            {
                checkBoxPrFlag.Checked = true;
            }
            if (dataGridViewProduct.Rows[dataGridViewProduct.CurrentRow.Index].Cells[14].Value != null)
            {
                textBoxPrHidden.Text = dataGridViewProduct.Rows[dataGridViewProduct.CurrentRow.Index].Cells[14].Value.ToString();
            }

        }

        private void buttonLastPage_Click(object sender, EventArgs e)
        {
            int pageSize = int.Parse(textBoxPageSize.Text);
            //最終ページの計算
            int pageNo = (int)Math.Ceiling(Product.Count / (double)pageSize) - 1;
            dataGridViewProduct.DataSource = Product.Skip(pageSize * pageNo).Take(pageSize).ToList();

            // DataGridViewを更新
            dataGridViewProduct.Refresh();
            //ページ番号の設定
            textBoxPage.Text = (pageNo + 1).ToString();
        }

        private void buttonFirstPage_Click(object sender, EventArgs e)
        {
            int pageSize = int.Parse(textBoxPageSize.Text);
            dataGridViewProduct.DataSource = Product.Take(pageSize).ToList();

            //DataGridViewを更新
            dataGridViewProduct.Refresh();
            //ページ番号の設定
            textBoxPage.Text = "1";
        }

        private void buttonPageSizeChange_Click(object sender, EventArgs e)
        {
            SetDataGridView();
        }

       

        private void buttonList_Click(object sender, EventArgs e)
        {
            // 入力エリアのクリア
            ClearInput();
            //データグリッドビューの表示
            GetDataGridView();
        }

        private void GetHiddenListData()
        {
            Product = ProductDataAccess.GetHiddenData();

            SetDataGridView();
        }

        private void buttonHiddenList_Click(object sender, EventArgs e)
        {
            // 入力エリアのクリア
            ClearInput();

            GetHiddenListData();
        }
    }


}
