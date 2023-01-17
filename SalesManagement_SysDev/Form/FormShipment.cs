using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SalesManagement_SysDev
{
    public partial class FormShipment : Form
    {
        //データベース出荷テーブルアクセス用クラスのインスタンス化
        ShipmentDataAccess shipmentDataAccess = new ShipmentDataAccess();
        //データベース出荷詳細テーブルアクセス用クラスのインスタンス化
        ShipmentDetailDataAccess shipmentDetailDataAccess = new ShipmentDetailDataAccess();
        //データベース顧客テーブルアクセス用クラスのインスタンス化
        ClientDataAccess clientDataAccess = new ClientDataAccess();
        //データベース社員テーブルアクセス用クラスのインスタンス化
        EmployeeDataAccess employeeDataAccess = new EmployeeDataAccess();
        //データベース商品テーブルアクセス用クラスのインスタンス化
        ProductDataAccess productDataAccess = new ProductDataAccess();
        //データベース売上テーブルアクセス用クラスのインスタンス化
        SaleDataAccess saleDataAccess = new SaleDataAccess();
        //データベース売上テーブルアクセス用クラスのインスタンス化
        SaleDetailDataAccess saleDetailDataAccess = new SaleDetailDataAccess();

        //入力形式チェック用クラスのインスタンス化
        DataInputFormCheck dataInputFormCheck = new DataInputFormCheck();
        //データグリッドビュー用の出荷データ
        private static List<T_ShipmentDsp> Shipment;
        //出荷ID参照用クラス
        private TShipment tshipment = new TShipment();

        public FormShipment()
        {
            InitializeComponent();
            userControlShipmentDetail1.addTShipment(tshipment);
        }

        private void FormShipment_Load(object sender, EventArgs e)
        {
            //日時の表示
            labelDay.Text = DateTime.Now.ToString("yyyy/MM/dd/(ddd)");
            labelTime.Text = DateTime.Now.ToString("HH:mm");
            //panelHeaderに表示するログインデータ
            labelUserName.Text = "ユーザー名：" + FormMain.loginName;
            labelPosition.Text = "権限:" + FormMain.loginPoName;
            labelSalesOffice.Text = FormMain.loginSoName;
            labelUserID.Text = "ユーザーID：" + FormMain.loginEmID.ToString();
            //データグリッドビューの設定
            SetFormDataGridView();

        }
        //入力された顧客IDの顧客名を取得
        private void textBoxClID_TextChanged(object sender, EventArgs e)
        {
            textBoxClName.Text = "";
            if (dataInputFormCheck.CheckNumeric(textBoxClID.Text.Trim()))
            {
                if (textBoxClID.TextLength < 6)
                {
                    if (clientDataAccess.CheckClIDExistence(int.Parse(textBoxClID.Text.Trim())))
                    {
                        M_Client client = clientDataAccess.GetClIDData(int.Parse(textBoxClID.Text.Trim()));
                        textBoxClName.Text = client.ClName.ToString();
                    }

                }
            }

        }

        private void buttonFormDel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //日時更新
            labelDay.Text = DateTime.Now.ToString("yyyy/MM/dd/(ddd)");
            labelTime.Text = DateTime.Now.ToString("HH:mm");
        }

        private void buttonDetail_Click(object sender, EventArgs e)
        {
            if (labelShipment.Text == "出荷管理")
            {
                labelShipment.Text = "出荷詳細管理";
                buttonDetail.Text = "出荷管理";
                userControlShipmentDetail1.Visible = true;
                panelShipment.Visible = false;
                return;
            }
            if (labelShipment.Text == "出荷詳細管理")
            {
                labelShipment.Text = "出荷管理";
                buttonDetail.Text = "出荷詳細";
                panelShipment.Visible = true;
                userControlShipmentDetail1.Visible = false;
                return;
            }
        }

        ///////////////////////////////
        //メソッド名：buttonList_Click()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：出荷データの一覧表示機能
        ///////////////////////////////
        private void buttonList_Click(object sender, EventArgs e)
        {
            // 入力エリアのクリア
            ClearInput();

            GetDataGridView();
        }

        ///////////////////////////////
        //メソッド名：buttonHiddenList_Click()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：出荷データの非表示一覧表示機能
        ///////////////////////////////
        private void buttonHiddenList_Click(object sender, EventArgs e)
        {
            // 入力エリアのクリア
            ClearInput();

            GetHiddenDataGridView();
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
            textBoxShID.Text = "";
            textBoxOrID.Text = "";
            textBoxClID.Text = "";
            textBoxClName.Text = "";
            checkBoxStateFlag.Checked = false;
            textBoxShHidden.Text = "";
            checkBoxStateFlag.Checked = false;
        }
        //データグリッドビュー設定

        ///////////////////////////////
        //メソッド名：PageSizeCheck()
        //引　数   ：なし
        //戻り値   ：true or false
        //機　能   ：入力データの形式チェック
        //          ：エラーがない場合True
        //          ：エラーがある場合False
        ///////////////////////////////
        private bool PageSizeCheck()
        {
            if (!String.IsNullOrEmpty(textBoxPageSize.Text.Trim()))
            {
                if (!dataInputFormCheck.CheckNumeric(textBoxPageSize.Text.Trim()))
                {
                    MessageBox.Show("ページ行数は半角数値のみです", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxPageSize.Focus();
                    return false;
                }
                if (int.Parse(textBoxPageSize.Text) <= 0)
                {
                    MessageBox.Show("ページ行数は1以上です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxPageSize.Focus();
                    return false;

                }
            }
            else
            {
                MessageBox.Show("ページ行数が入力されていません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxPageSize.Focus();
                return false;

            }
            return true;
        }
        ///////////////////////////////
        //メソッド名：PageCheck()
        //引　数   ：なし
        //戻り値   ：true or false
        //機　能   ：入力データの形式チェック
        //          ：エラーがない場合True
        //          ：エラーがある場合False
        ///////////////////////////////
        private bool PageCheck()
        {
            if (!String.IsNullOrEmpty(textBoxPage.Text.Trim()))
            {
                if (!dataInputFormCheck.CheckNumeric(textBoxPage.Text.Trim()))
                {
                    MessageBox.Show("ページ数は半角数値のみです", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxPage.Focus();
                    return false;
                }
                if (int.Parse(textBoxPage.Text) <= 0)
                {
                    MessageBox.Show("ページ数は1以上です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxPage.Focus();
                    return false;

                }
            }
            else
            {
                MessageBox.Show("ページ数が入力されていません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxPage.Focus();
                return false;

            }
            return true;
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
            dataGridViewSh.ReadOnly = true;
            //直接のサイズの変更を不可
            dataGridViewSh.AllowUserToResizeRows = false;
            dataGridViewSh.AllowUserToResizeColumns = false;
            //直接の登録を不可にする
            dataGridViewSh.AllowUserToAddRows = false;
            //行内をクリックすることで行を選択
            dataGridViewSh.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //奇数行の色を変更
            dataGridViewSh.AlternatingRowsDefaultCellStyle.BackColor = Color.Honeydew;
            //ヘッダー位置の指定
            dataGridViewSh.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

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
            //出荷データの取得
            Shipment = shipmentDataAccess.GetShipmentData();
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
            //出荷データの取得
            Shipment = shipmentDataAccess.GetShipmentData();
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
            if (!PageSizeCheck())
                return;

            int pageSize = int.Parse(textBoxPageSize.Text);
            int pageNo = int.Parse(textBoxPage.Text) - 1;
            dataGridViewSh.DataSource = Shipment.Skip(pageSize * pageNo).Take(pageSize).ToList();
            //各列幅の指定 //1475
            dataGridViewSh.Columns[0].Width = 100;
            dataGridViewSh.Columns[1].Width = 100;
            dataGridViewSh.Columns[2].Visible = false;
            dataGridViewSh.Columns[3].Width = 100;
            dataGridViewSh.Columns[4].Width = 100;
            dataGridViewSh.Columns[5].Width = 150;
            dataGridViewSh.Columns[6].Width = 100;
            dataGridViewSh.Columns[7].Width = 200;
            dataGridViewSh.Columns[8].Width = 200;
            dataGridViewSh.Columns[9].Visible = false;
            dataGridViewSh.Columns[10].Visible = false;
            dataGridViewSh.Columns[11].Width = 460;

            //各列の文字位置の指定
            dataGridViewSh.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewSh.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewSh.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewSh.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewSh.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewSh.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewSh.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewSh.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewSh.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewSh.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewSh.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewSh.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            //dataGridViewの総ページ数
            labelPage.Text = "/" + ((int)Math.Ceiling(Shipment.Count / (double)pageSize)) + "ページ";

            dataGridViewSh.Refresh();
        }



        ///////////////////////////////
        //メソッド名：buttonPageSizeChange_Click()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：データグリッドビューの表示件数変更
        ///////////////////////////////
        private void buttonPageSizeChange_Click(object sender, EventArgs e)
        {
            textBoxPage.Text = 1.ToString();

            SetDataGridView();
        }
        ///////////////////////////////
        //メソッド名：buttonFirstPage_Click()
        //引　数   ：なし——
        //戻り値   ：なし
        //機　能   ：データグリッドビューの先頭ページ表示
        ///////////////////////////////
        private void buttonFirstPage_Click(object sender, EventArgs e)
        {
            if (!PageSizeCheck())
                return;

            int pageSize = int.Parse(textBoxPageSize.Text);
            dataGridViewSh.DataSource = Shipment.Take(pageSize).ToList();

            // DataGridViewを更新
            dataGridViewSh.Refresh();
            //ページ番号の設定
            textBoxPage.Text = "1";
        }
        ///////////////////////////////
        //メソッド名：buttonPreviousPage_Click()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：データグリッドビューの前ページ表示
        ///////////////////////////////

        private void buttonPreviousPage_Click(object sender, EventArgs e)
        {
            if (!PageSizeCheck())
                return;
            int pageSize = int.Parse(textBoxPageSize.Text.Trim());
            if (!PageCheck())
                return;
            int pageNo = int.Parse(textBoxPage.Text) - 2;
            dataGridViewSh.DataSource = Shipment.Skip(pageSize * pageNo).Take(pageSize).ToList();

            // DataGridViewを更新
            dataGridViewSh.Refresh();
            //ページ番号の設定
            if (pageNo + 1 > 1)
                textBoxPage.Text = (pageNo + 1).ToString();
            else
                textBoxPage.Text = "1";

        }

        ///////////////////////////////
        //メソッド名：buttonNextPage_Click()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：データグリッドビューの次ページ表示
        ///////////////////////////////
        private void buttonNextPage_Click(object sender, EventArgs e)
        {
            if (!PageSizeCheck())
                return;
            int pageSize = int.Parse(textBoxPageSize.Text.Trim());
            if (!PageCheck())
                return;
            int pageNo = int.Parse(textBoxPage.Text);
            //最終ページの計算
            int lastNo = (int)Math.Ceiling(Shipment.Count / (double)pageSize) - 1;
            //最終ページでなければ
            if (pageNo <= lastNo)
                dataGridViewSh.DataSource = Shipment.Skip(pageSize * pageNo).Take(pageSize).ToList();

            // DataGridViewを更新
            dataGridViewSh.Refresh();
            //ページ番号の設定
            int lastPage = (int)Math.Ceiling(Shipment.Count / (double)pageSize);
            if (pageNo >= lastPage)
                textBoxPage.Text = lastPage.ToString();
            else
                textBoxPage.Text = (pageNo + 1).ToString();
        }

        ///////////////////////////////
        //メソッド名：buttonLastPage_Click()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：データグリッドビューの最終ページ表示
        ///////////////////////////////
        private void buttonLastPage_Click(object sender, EventArgs e)
        {
            if (!PageSizeCheck())
                return;

            int pageSize = int.Parse(textBoxPageSize.Text);
            //最終ページの計算
            int pageNo = (int)Math.Ceiling(Shipment.Count / (double)pageSize) - 1;
            dataGridViewSh.DataSource = Shipment.Skip(pageSize * pageNo).Take(pageSize).ToList();

            // DataGridViewを更新
            dataGridViewSh.Refresh();
            //ページ番号の設定
            textBoxPage.Text = (pageNo + 1).ToString();
        }
        //セルクリック
        private void dataGridViewSh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //データグリッドビューからクリックされたデータを各入力エリアへ
            textBoxShID.Text = dataGridViewSh.Rows[dataGridViewSh.CurrentRow.Index].Cells[0].Value.ToString();
            textBoxOrID.Text = dataGridViewSh.Rows[dataGridViewSh.CurrentRow.Index].Cells[1].Value.ToString();
            textBoxClID.Text = dataGridViewSh.Rows[dataGridViewSh.CurrentRow.Index].Cells[6].Value.ToString();
            textBoxClName.Text = dataGridViewSh.Rows[dataGridViewSh.CurrentRow.Index].Cells[7].Value.ToString();

            //flagの値の「0」「1」をbool型に変換してチェックボックスに表示させる
            if (dataGridViewSh.Rows[dataGridViewSh.CurrentRow.Index].Cells[9].Value.ToString() != 1.ToString())
            {
                checkBoxStateFlag.Checked = false;
            }
            else
            {
                checkBoxStateFlag.Checked = true;
            }
            //flagの値の「0」「2」をbool型に変換してチェックボックスに表示させる
            if (dataGridViewSh.Rows[dataGridViewSh.CurrentRow.Index].Cells[10].Value.ToString() != 2.ToString())
            {
                checkBox1Hidden.Checked = false;
            }
            else
            {
                checkBox1Hidden.Checked = true;
            }

            //非表示理由がnullではない場合テキストボックスに表示させる
            if (dataGridViewSh.Rows[dataGridViewSh.CurrentRow.Index].Cells[11].Value != null)
            {
                textBoxShHidden.Text = dataGridViewSh.Rows[dataGridViewSh.CurrentRow.Index].Cells[11].Value.ToString();
            }

        }

        //入力クリア
        private void buttonClear2_Click(object sender, EventArgs e)
        {
            ClearInput();
        }

        private void checkBox1Hidden_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1Hidden.Checked == true)
            {
                textBoxShHidden.TabStop = true;
                textBoxShHidden.ReadOnly = false;

            }
            else
            {
                textBoxShHidden.Text = "";
                textBoxShHidden.TabStop = false;
                textBoxShHidden.ReadOnly = true;
            }
        }
        //////////////14.1.2 出荷情報確定機能///////////////////
        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            // 14.1.2.1 妥当な出荷データ取得
            if (!GetValidDataAtConfirm())
                return;
            // 14.1.2.2　売上情報作成
            var conSale = GenerateDataAtConfirm();
            // 14.1.2.3　売上詳細情報作成
            var consaleDetail = GenerateDetailDataAtConfirm();

            // 14.1.2.4 出荷情報確定
            ConfirmShipment(conSale, consaleDetail);

        }
        ///////////////////////////////
        //  14.1.2.1 妥当な出荷データ取得
        //メソッド名：GetValidDataAtConfirm()
        //引　数   ：なし
        //戻り値   ：true or false
        //機　能   ：入力データの形式チェック
        //          ：エラーがない場合True
        //          ：エラーがある場合False
        ///////////////////////////////
        private bool GetValidDataAtConfirm()
        {
            //出荷IDの適否
            if (!String.IsNullOrEmpty(textBoxShID.Text.Trim()))
            {
                //文字チェック
                if (!dataInputFormCheck.CheckNumeric(textBoxShID.Text.Trim()))
                {
                    MessageBox.Show("出荷IDは半角数値入力です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxShID.Focus();
                    return false;
                }
                //文字数
                if (textBoxShID.TextLength > 6)
                {
                    MessageBox.Show("出荷IDは6文字以下です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxShID.Focus();
                    return false;
                }
                // 出荷IDの存在チェック
                if (!shipmentDataAccess.CheckShIDExistence(int.Parse(textBoxShID.Text.Trim())))
                {
                    MessageBox.Show("入力された出荷IDは存在しません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxShID.Focus();
                    return false;
                }

            }
            else
            {
                MessageBox.Show("出荷ID が入力されていません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxShID.Focus();
                return false;
            }
            //出荷確定状態の判定
            var shipment = shipmentDataAccess.GetShIDData(int.Parse(textBoxShID.Text.Trim()));
            if (shipment.ShStateFlag == 1)
            {
                MessageBox.Show("入力された出荷IDはすでに確定されています", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxShID.Focus();
                return false;

            }
            //出荷状態フラグ
            if (checkBoxStateFlag.CheckState == CheckState.Indeterminate)
            {
                MessageBox.Show("出荷確定が不確定な状態です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                checkBoxStateFlag.Focus();
                return false;
            }
            if (checkBoxStateFlag.Checked == false)
            {
                MessageBox.Show("出荷確定がチェックされていません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                checkBoxStateFlag.Focus();
                return false;
            }
            //詳細情報の件数チェック
            var shipmentDetail = shipmentDetailDataAccess.GetShIDDetailData(int.Parse(textBoxShID.Text.Trim()));
            if (shipmentDetail.Count == 0)
            {
                MessageBox.Show("詳細情報が登録されていません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;

            }
            return true;
        }
        ///////////////////////////////
        //　14.1.2.2　売上情報作成
        //メソッド名：GenerateDataAtConfirm()
        //引　数   ：なし
        //戻り値   ：出荷確定情報
        //機　能   ：確定データのセット
        ///////////////////////////////
        private T_Sale GenerateDataAtConfirm()
        {
            T_Shipment shipment = shipmentDataAccess.GetShIDData(int.Parse(textBoxShID.Text.Trim()));
            //ログインしている社員IDの社員情報を取得する
            M_Employee employee = employeeDataAccess.GetEmIDData(FormMain.loginEmID);

            return new T_Sale
            {


                ClID = int.Parse(shipment.ClID.ToString()),
                EmID = employee.EmID,
                SoID = int.Parse(shipment.SoID.ToString()),
                ChID = int.Parse(shipment.OrID.ToString()),
                SaDate = DateTime.Now,
                SaFlag = 0,
                SaHidden = String.Empty
            };


        }
        ///////////////////////////////
        //　14.1.2.3 売上詳細情報作成
        //メソッド名：GenerateDetailDataAtConfirm()
        //引　数   ：なし
        //戻り値   ：出荷詳細確定情報
        //機　能   ：確定データのセット
        ///////////////////////////////
        private List<T_SaleDetail> GenerateDetailDataAtConfirm()
        {
            List<T_ShipmentDetail> shipmentDetail = shipmentDetailDataAccess.GetShIDDetailData(int.Parse(textBoxShID.Text.Trim()));

            List<T_SaleDetail> saleDetail = new List<T_SaleDetail>();
            foreach (var p in shipmentDetail)
            {

                var product = productDataAccess.GetPrIDData(p.PrID);
                int totalPrice = product.Price * p.ShDquantity;
                saleDetail.Add(new T_SaleDetail()
                {

                    PrID = p.PrID,
                    SaQuantity = p.ShDquantity,
                    SaPrTotalPrice = totalPrice,
                });
            }
            return saleDetail;


        }

        ///////////////////////////////
        //　14.1.2.4 出荷情報確定
        //メソッド名：ConfirmShipment()
        //引　数   ：売上情報,売上詳細情報
        //戻り値   ：なし
        //機　能   ：出荷情報の確定
        ///////////////////////////////
        private void ConfirmShipment(T_Sale conSale, List<T_SaleDetail> conSaleDetail)
        {
            // 確定確認メッセージ
            DialogResult result = MessageBox.Show("データを確定してよろしいですか?", "確定確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (result == DialogResult.Cancel)
                return;

            // 出荷情報の確定
            //売上テーブルにデータ登録
            bool addFlg = saleDataAccess.AddSaleData(conSale);
            //売上IDの取得
            T_Shipment shipment = shipmentDataAccess.GetShIDData(int.Parse(textBoxShID.Text.Trim()));
            T_Sale sale = saleDataAccess.GetSaIDData(shipment.OrID);
            //売上詳細テーブルにデータ登録/
            ///成功か失敗の判定は未完成
            foreach (var p in conSaleDetail)
            {
                T_SaleDetail AddSh = new T_SaleDetail();
                AddSh.SaID = sale.SaID;
                AddSh.PrID = p.PrID;
                AddSh.SaQuantity = p.SaQuantity;
                AddSh.SaPrTotalPrice = p.SaPrTotalPrice;
                saleDetailDataAccess.AddSaleDetailData(AddSh);
            }
            //出荷状態フラグの更新
            bool conFlg = shipmentDataAccess.UpdateShioment(int.Parse(textBoxShID.Text.Trim()));
            //全ての登録,更新が成功
            if (addFlg == true && conFlg == true)
            {

                MessageBox.Show("データを確定しました", "追加確認", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("データの確定に失敗しました", "追加確認", MessageBoxButtons.OK, MessageBoxIcon.Error);

            textBoxShID.Focus();

            // 入力エリアのクリア
            ClearInput();

            // データグリッドビューの表示
            GetDataGridView();

        }
        ////////////14.1.3 出荷検索機能/////////////////////
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            //14.1.3.1妥当な出荷データ取得
            if (!GetValidDataAtSelect())
                return;

            //14.1.3.2 出荷情報抽出
            GenerateDataAtSelect();

            //14.1.3.3　出荷抽出結果表示
            SetSelectData();

        }
        ///////////////////////////////
        //　14.1.3.1 妥当な出荷データ取得
        //メソッド名：GetValidDataAtSlect()
        //引　数   ：なし
        //戻り値   ：true or false
        //機　能   ：入力データの形式チェック
        //          ：エラーがない場合True
        //          ：エラーがある場合False
        ///////////////////////////////
        private bool GetValidDataAtSelect()
        {
            //出荷IDの適否
            if (!String.IsNullOrEmpty(textBoxShID.Text.Trim()))
            {
                //文字チェック
                if (!dataInputFormCheck.CheckNumeric(textBoxShID.Text.Trim()))
                {
                    MessageBox.Show("出荷IDは半角数値入力です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxShID.Focus();
                    return false;
                }
                //文字数
                if (textBoxShID.TextLength > 6)
                {
                    MessageBox.Show("出荷IDは6文字以下です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxShID.Focus();
                    return false;
                }
                // 出荷IDの存在チェック
                if (!shipmentDataAccess.CheckShIDExistence(int.Parse(textBoxShID.Text.Trim())))
                {
                    MessageBox.Show("入力された出荷IDは存在しません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxShID.Focus();
                    return false;
                }

            }
            //顧客IDの適否
            if (!String.IsNullOrEmpty(textBoxClID.Text.Trim()))
            {
                //文字チェック
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
            //非表示フラグ
            if (checkBox1Hidden.CheckState == CheckState.Indeterminate)
            {
                MessageBox.Show("非表示理由が不確定な状態です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                checkBox1Hidden.Focus();
                return false;
            }
            //出荷日範囲のチェック
            if (dateTimePickerDateStart.Checked == true && dateTimePickerDateEnd.Checked == true)
            {
                if (DateTime.Parse(dateTimePickerDateStart.Text) > DateTime.Parse(dateTimePickerDateEnd.Text))
                {
                    MessageBox.Show("日付の範囲が不正です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dateTimePickerDateStart.Focus();
                    return false;
                }
            }
            else if (dateTimePickerDateStart.Checked == true && dateTimePickerDateEnd.Checked == false ||
                dateTimePickerDateStart.Checked == false && dateTimePickerDateEnd.Checked == true)
            {
                MessageBox.Show("日付の範囲が不正です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dateTimePickerDateStart.Focus();
                return false;
            }
            //出荷状態フラグ
            if (checkBoxStateFlag.CheckState == CheckState.Indeterminate)
            {
                MessageBox.Show("出荷確定が不確定な状態です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                checkBoxStateFlag.Focus();
                return false;
            }

            return true;
        }
        ///////////////////////////////
        //　14.1.3.2 出荷情報抽出
        //メソッド名：GenerateDataAtSelect()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：検索データの取得
        ///////////////////////////////
        private void GenerateDataAtSelect()
        {
            //日付範囲
            DateTime? startDay = null;
            DateTime? endDay = null;
            if (dateTimePickerDateStart.Checked)
                startDay = DateTime.Parse(dateTimePickerDateStart.Text);
            if (dateTimePickerDateEnd.Checked)
                endDay = DateTime.Parse(dateTimePickerDateEnd.Text);

            //非表示フラグ変換
            int hidFlg = 0;
            if (checkBox1Hidden.Checked == true)
            {
                hidFlg = 2;
            }
            ////出荷確定フラグ変換
            //int stateFlg = 0;
            //if (checkBoxStateFlag.Checked == true)
            //{
            //    stateFlg = 1;
            //}
            //日付範囲が選択されていない
            if (startDay == null && endDay == null)
            {
                //出荷!=null
                if (!String.IsNullOrEmpty(textBoxShID.Text.Trim()))
                {
                    //受注ID!=null
                    if (!String.IsNullOrEmpty(textBoxOrID.Text.Trim()))
                    {
                        //顧客!=null
                        if (!String.IsNullOrEmpty(textBoxClID.Text.Trim()))
                        {
                            T_ShipmentDsp selectCondition = new T_ShipmentDsp()
                            {
                                ShID = int.Parse(textBoxShID.Text.Trim()),
                                OrID = int.Parse(textBoxOrID.Text.Trim()),
                                ClID = int.Parse(textBoxClID.Text.Trim()),
                                ShFlag = hidFlg,
                                 
                                ShHidden = textBoxShHidden.Text.Trim()
                            };
                            //データの抽出
                            Shipment = shipmentDataAccess.GetShipmentData(1, selectCondition);

                        }
                        else
                        {
                            T_ShipmentDsp selectCondition = new T_ShipmentDsp()
                            {
                                ShID = int.Parse(textBoxShID.Text.Trim()),
                                OrID = int.Parse(textBoxOrID.Text.Trim()),
                                ShFlag = hidFlg,
                                 
                                ShHidden = textBoxShHidden.Text.Trim()
                            };
                            //データの抽出
                            Shipment = shipmentDataAccess.GetShipmentData(2, selectCondition);

                        }

                    }
                    else
                    {
                        //顧客!=null
                        if (!String.IsNullOrEmpty(textBoxClID.Text.Trim()))
                        {
                            T_ShipmentDsp selectCondition = new T_ShipmentDsp()
                            {
                                ShID = int.Parse(textBoxShID.Text.Trim()),
                                ClID = int.Parse(textBoxClID.Text.Trim()),
                                ShFlag = hidFlg,
                                 
                                ShHidden = textBoxShHidden.Text.Trim()
                            };
                            //データの抽出
                            Shipment = shipmentDataAccess.GetShipmentData(3, selectCondition);

                        }
                        else
                        {
                            T_ShipmentDsp selectCondition = new T_ShipmentDsp()
                            {
                                ShID = int.Parse(textBoxShID.Text.Trim()),
                                ShFlag = hidFlg,
                                 
                                ShHidden = textBoxShHidden.Text.Trim()
                            };
                            //データの抽出
                            Shipment = shipmentDataAccess.GetShipmentData(4, selectCondition);

                        }


                    }

                }
                else
                {
                    //受注ID!=null
                    if (!String.IsNullOrEmpty(textBoxOrID.Text.Trim()))
                    {
                        //顧客!=null
                        if (!String.IsNullOrEmpty(textBoxClID.Text.Trim()))
                        {
                            T_ShipmentDsp selectCondition = new T_ShipmentDsp()
                            {
                                OrID = int.Parse(textBoxOrID.Text.Trim()),
                                ClID = int.Parse(textBoxClID.Text.Trim()),
                                ShFlag = hidFlg,
                                 
                                ShHidden = textBoxShHidden.Text.Trim()
                            };
                            //データの抽出
                            Shipment = shipmentDataAccess.GetShipmentData(5, selectCondition);

                        }
                        else
                        {
                            T_ShipmentDsp selectCondition = new T_ShipmentDsp()
                            {
                                OrID = int.Parse(textBoxOrID.Text.Trim()),
                                ShFlag = hidFlg,
                                 
                                ShHidden = textBoxShHidden.Text.Trim()
                            };
                            //データの抽出
                            Shipment = shipmentDataAccess.GetShipmentData(6, selectCondition);

                        }

                    }
                    else
                    {
                        //顧客!=null
                        if (!String.IsNullOrEmpty(textBoxClID.Text.Trim()))
                        {
                            T_ShipmentDsp selectCondition = new T_ShipmentDsp()
                            {
                                ClID = int.Parse(textBoxClID.Text.Trim()),
                                ShFlag = hidFlg,
                                 
                                ShHidden = textBoxShHidden.Text.Trim()
                            };
                            //データの抽出
                            Shipment = shipmentDataAccess.GetShipmentData(7, selectCondition);

                        }
                        else
                        {
                            T_ShipmentDsp selectCondition = new T_ShipmentDsp()
                            {
                                ShFlag = hidFlg,
                                 
                                ShHidden = textBoxShHidden.Text.Trim()
                            };
                            //データの抽出
                            Shipment = shipmentDataAccess.GetShipmentData(8, selectCondition);

                        }


                    }

                }

            }
            //日付範囲が選択されている
            else if (startDay != null && endDay != null)
            {
                //出荷!=null
                if (!String.IsNullOrEmpty(textBoxShID.Text.Trim()))
                {
                    //受注ID!=null
                    if (!String.IsNullOrEmpty(textBoxOrID.Text.Trim()))
                    {
                        //顧客!=null
                        if (!String.IsNullOrEmpty(textBoxClID.Text.Trim()))
                        {
                            T_ShipmentDsp selectCondition = new T_ShipmentDsp()
                            {
                                ShID = int.Parse(textBoxShID.Text.Trim()),
                                OrID = int.Parse(textBoxOrID.Text.Trim()),
                                ClID = int.Parse(textBoxClID.Text.Trim()),
                                ShFlag = hidFlg,
                                 
                                ShHidden = textBoxShHidden.Text.Trim()
                            };
                            //データの抽出
                            Shipment = shipmentDataAccess.GetShipmentDateData(1, selectCondition, startDay, endDay);

                        }
                        else//顧客ID未入力
                        {
                            T_ShipmentDsp selectCondition = new T_ShipmentDsp()
                            {
                                ShID = int.Parse(textBoxShID.Text.Trim()),
                                OrID = int.Parse(textBoxOrID.Text.Trim()),
                                ShFlag = hidFlg,
                                 
                                ShHidden = textBoxShHidden.Text.Trim()
                            };
                            //データの抽出
                            Shipment = shipmentDataAccess.GetShipmentDateData(2, selectCondition, startDay, endDay);

                        }

                    }
                    else//受注ID未入力
                    {
                        //顧客!=null
                        if (!String.IsNullOrEmpty(textBoxClID.Text.Trim()))
                        {
                            T_ShipmentDsp selectCondition = new T_ShipmentDsp()
                            {
                                ShID = int.Parse(textBoxShID.Text.Trim()),
                                ClID = int.Parse(textBoxClID.Text.Trim()),
                                ShFlag = hidFlg,
                                 
                                ShHidden = textBoxShHidden.Text.Trim()
                            };
                            //データの抽出
                            Shipment = shipmentDataAccess.GetShipmentDateData(3, selectCondition, startDay, endDay);

                        }
                        else
                        {
                            T_ShipmentDsp selectCondition = new T_ShipmentDsp()
                            {
                                ShID = int.Parse(textBoxShID.Text.Trim()),
                                ShFlag = hidFlg,
                                 
                                ShHidden = textBoxShHidden.Text.Trim()
                            };
                            //データの抽出
                            Shipment = shipmentDataAccess.GetShipmentDateData(4, selectCondition, startDay, endDay);

                        }


                    }

                }
                else//出荷ID未入力
                {
                    //受注ID!=null
                    if (!String.IsNullOrEmpty(textBoxOrID.Text.Trim()))
                    {
                        //顧客!=null
                        if (!String.IsNullOrEmpty(textBoxClID.Text.Trim()))
                        {
                            T_ShipmentDsp selectCondition = new T_ShipmentDsp()
                            {
                                OrID = int.Parse(textBoxOrID.Text.Trim()),
                                ClID = int.Parse(textBoxClID.Text.Trim()),
                                ShFlag = hidFlg,
                                 
                                ShHidden = textBoxShHidden.Text.Trim()
                            };
                            //データの抽出
                            Shipment = shipmentDataAccess.GetShipmentDateData(5, selectCondition, startDay, endDay);

                        }
                        else//顧客ID未入力
                        {
                            T_ShipmentDsp selectCondition = new T_ShipmentDsp()
                            {
                                OrID = int.Parse(textBoxOrID.Text.Trim()),
                                ShFlag = hidFlg,
                                 
                                ShHidden = textBoxShHidden.Text.Trim()
                            };
                            //データの抽出
                            Shipment = shipmentDataAccess.GetShipmentDateData(6, selectCondition, startDay, endDay);

                        }

                    }
                    else//受注ID未入力
                    {
                        //顧客!=null
                        if (!String.IsNullOrEmpty(textBoxClID.Text.Trim()))
                        {
                            T_ShipmentDsp selectCondition = new T_ShipmentDsp()
                            {
                                ClID = int.Parse(textBoxClID.Text.Trim()),
                                ShFlag = hidFlg,
                                 
                                ShHidden = textBoxShHidden.Text.Trim()
                            };
                            //データの抽出
                            Shipment = shipmentDataAccess.GetShipmentDateData(7, selectCondition, startDay, endDay);

                        }
                        else//顧客ID未入力
                        {
                            T_ShipmentDsp selectCondition = new T_ShipmentDsp()
                            {
                                ShFlag = hidFlg,
                                 
                                ShHidden = textBoxShHidden.Text.Trim()
                            };
                            //データの抽出
                            Shipment = shipmentDataAccess.GetShipmentDateData(8, selectCondition, startDay, endDay);

                        }


                    }

                }

            }

        }
        ///////////////////////////////
        //　14.1.3.3 出荷抽出結果表示
        //メソッド名：SetSelectData()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：出荷情報の表示
        ///////////////////////////////
        private void SetSelectData()
        {
            textBoxPage.Text = "1";

            int pageSize = int.Parse(textBoxPageSize.Text);

            dataGridViewSh.DataSource = Shipment;
            if (Shipment.Count == 0)
            {
                MessageBox.Show("該当データが存在しません", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            labelPage.Text = "/" + ((int)Math.Ceiling(Shipment.Count / (double)pageSize)) + "ページ";
            dataGridViewSh.Refresh();

        }


        /////////////14.1.4 出荷非表示機能////////////////////
        private void buttonHidden_Click(object sender, EventArgs e)
        {
            // 14.1.4.1 妥当な出荷データ取得
            if (!GetValidDataAtHidden())
                return;

            // 14.1.4.2　出荷情報作成
            var hidShipment = GenerateDataAtHidden();

            // 14.1.4.3 出荷情報非表示
            HiddenShipment(hidShipment);

        }
        ///////////////////////////////
        //  14.1.4.1 妥当な出荷データ取得
        //メソッド名：GetValidDataAtHidden()
        //引　数   ：なし
        //戻り値   ：true or false
        //機　能   ：入力データの形式チェック
        //          ：エラーがない場合True
        //          ：エラーがある場合False
        ///////////////////////////////
        private bool GetValidDataAtHidden()
        {
            //出荷IDの適否
            if (!String.IsNullOrEmpty(textBoxShID.Text.Trim()))
            {
                //文字チェック
                if (!dataInputFormCheck.CheckNumeric(textBoxShID.Text.Trim()))
                {
                    MessageBox.Show("出荷IDは半角数値入力です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxShID.Focus();
                    return false;
                }
                //文字数
                if (textBoxShID.TextLength > 6)
                {
                    MessageBox.Show("出荷IDは6文字以下です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxShID.Focus();
                    return false;
                }
                // 出荷IDの存在チェック
                if (!shipmentDataAccess.CheckShIDExistence(int.Parse(textBoxShID.Text.Trim())))
                {
                    MessageBox.Show("入力された出荷IDは存在しません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxShID.Focus();
                    return false;
                }

            }
            else
            {
                MessageBox.Show("出荷ID が入力されていません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxShID.Focus();
                return false;
            }
            //非表示フラグの適否
            if (checkBox1Hidden.Checked == false)
            {
                MessageBox.Show("非表示理由が入力されていません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                checkBox1Hidden.Checked = true;
                textBoxShHidden.Focus();
                return false;

            }
            //非表示理由の適否
            if (checkBox1Hidden.Checked == true && String.IsNullOrEmpty(textBoxShHidden.Text.Trim()))
            {
                MessageBox.Show("非表示理由が入力されていません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxShHidden.Focus();
                return false;
            }

            return true;
        }
        ///////////////////////////////
        //　14.1.4.2 出荷情報作成
        //メソッド名：GenerateDataAtHidden()
        //引　数   ：なし
        //戻り値   ：出荷非表示情報
        //機　能   ：非表示データのセット
        ///////////////////////////////
        private T_Shipment GenerateDataAtHidden()
        {
            int hidFlag = 0;
            if (checkBox1Hidden.Checked == true)
            {
                hidFlag = 2;
            }

            return new T_Shipment
            {
                ShID = int.Parse(textBoxShID.Text.Trim()),
                ShFlag = hidFlag,
                ShHidden = textBoxShHidden.Text.Trim()
            };
        }
        ///////////////////////////////
        //　13.1.4.3 出荷情報非表示
        //メソッド名：HiddenArrival()
        //引　数   ：出荷情報
        //戻り値   ：なし
        //機　能   ：出荷情報の非表示
        ///////////////////////////////
        private void HiddenShipment(T_Shipment hidShipment)
        {
            // 非表示確認メッセージ
            DialogResult result = MessageBox.Show("データを非表示にしてよろしいですか?", "非表示確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (result == DialogResult.Cancel)
                return;

            // 出荷情報の非表示(フラグの更新)
            bool flg = shipmentDataAccess.UpdateHiddenFlag(hidShipment);
            if (flg == true)
                MessageBox.Show("データを非表示にしました", "非表示確認", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("データの非表示に失敗しました", "非表示確認", MessageBoxButtons.OK, MessageBoxIcon.Error);

            textBoxShID.Focus();

            // 入力エリアのクリア
            ClearInput();

            // データグリッドビューの表示
            GetDataGridView();
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

        private void textBoxClID_TextChanged_1(object sender, EventArgs e)
        {
            textBoxClName.Text = "";
            if (dataInputFormCheck.CheckNumeric(textBoxClID.Text.Trim()))
            {
                if (textBoxClID.TextLength < 6)
                {
                    if (clientDataAccess.CheckClIDExistence(int.Parse(textBoxClID.Text.Trim())))
                    {
                        M_Client client = clientDataAccess.GetClIDData(int.Parse(textBoxClID.Text.Trim()));
                        textBoxClName.Text = client.ClName.ToString();
                    }

                }
            }
        }
    }

}
