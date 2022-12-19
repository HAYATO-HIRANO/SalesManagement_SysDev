
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
    public partial class UserControlOrderDetail : UserControl
    {
        //データベース受注テーブルアクセス用クラスのインスタンス化
        OrderDataAccess orderDataAccess = new OrderDataAccess();
        //データベース受注テーブルアクセス用クラスのインスタンス化
        OrderDetailDataAccess orderDetailDataAccess = new OrderDetailDataAccess();
        //データベース商品テーブルアクセス用クラスのインスタンス化
        ProductDataAccess productDataAccess = new ProductDataAccess();
        //入力形式チェック用クラスのインスタンス化
        DataInputFormCheck dataInputFormCheck = new DataInputFormCheck();
        //データグリッドビュー用の受注データ
        private static List<T_OrderDetailDsp> OrderDetail;
        //受注管理から受注IDを取得するためのクラス
        private TOrder tOrder;
        public UserControlOrderDetail()
        {
            InitializeComponent();
        }
        //受注管理で入力された受注ID取得
        public void addTOrder(TOrder tOrder)
        {
            this.tOrder = tOrder;
        }
        //受注詳細に切り替わった時に発生するイベント
        protected override void OnVisibleChanged(EventArgs e)
        {
            if (tOrder != null&&tOrder.OrID!=0)
            {
                textBoxOrID.Text = tOrder.OrID.ToString();
                GetOrIDDataGridView();
            }

        }

        private void UserControlOrderDetail_Load(object sender, EventArgs e)
        {
            //商品名名選択不可、入力不可
            textBoxPrName.TabStop = false;
            textBoxPrName.ReadOnly = true;
            
            //データグリッドビューの設定
            SetFormDataGridView();
            
        }
        //入力された商品IDの商品名、価格を表示
        private void textBoxPrID_TextChanged(object sender, EventArgs e)
        {
            textBoxPrName.Text = "";
            textBoxPrice.Text = "";
            if (dataInputFormCheck.CheckNumeric(textBoxPrID.Text.Trim()))
            {
                if (textBoxPrID.TextLength < 6)
                {
                    if (productDataAccess.CheckPrIDExistence(int.Parse(textBoxPrID.Text.Trim())))
                    {
                        M_Product product = productDataAccess.GetPrIDData(int.Parse(textBoxPrID.Text.Trim()));
                        textBoxPrName.Text = product.PrName.ToString();
                        textBoxPrice.Text = product.Price.ToString();
                    }


                }
            }

        }

        //価格×数量の結果を合計金額に表示
        private void textBoxOrQuantity_TextChanged(object sender, EventArgs e)
        {
            textBoxOrTotalPrice.Text = "";
            if (!String.IsNullOrEmpty(textBoxPrice.Text.Trim()))
            {
                if (dataInputFormCheck.CheckNumeric(textBoxOrQuantity.Text.Trim()))
                {
                    if (textBoxOrQuantity.TextLength < 4)
                    {
                        textBoxOrTotalPrice.Text = (int.Parse(textBoxPrice.Text.Trim()) * int.Parse(textBoxOrQuantity.Text.Trim())).ToString();
                    }

                }
            }

        }
        //受注IDの受注確定状態を取得して表示
        private void textBoxOrID_TextChanged(object sender, EventArgs e)
        {
            labelStateFlag.Text = "";
            if (dataInputFormCheck.CheckNumeric(textBoxOrID.Text.Trim()))
            {
                if (textBoxOrID.TextLength < 6)
                {
                    if (orderDataAccess.CheckOrIDExistence(int.Parse(textBoxOrID.Text.Trim())))
                    {
                        T_Order order = orderDataAccess.GetOrIDData(int.Parse(textBoxOrID.Text.Trim()));
                        if (order.OrStateFlag == 1)
                        
                            labelStateFlag.Text = "確定済";

                        else
                            labelStateFlag.Text = "未確定";

                    }

                }
            }

        }

        
        ///////////////受注詳細情報登録////////////////////

        private void buttonRegist_Click(object sender, EventArgs e)
        {
            //8.2.1.1 妥当な受注詳細データ取得
            if (!GetValidDataAtRegistration())
                return;

            //8.2.1.2 受注情報作成
            var regOrDetail = GenerateDataAtRegistration();

            //8.2.1.3  受注情報登録
            RegistrationOrDetail(regOrDetail);

        }
        ///////////////////////////////
        //　8.2.1.1  妥当な受注詳細データ取得
        //メソッド名：GetValidDataAtRegistration()
        //引　数   ：なし
        //戻り値   ：true or false
        //機　能   ：入力データの形式チェック
        //          ：エラーがない場合True
        //          ：エラーがある場合False
        ///////////////////////////////
        private bool GetValidDataAtRegistration()
        {
            //受注IDの適否
            if (!String.IsNullOrEmpty(textBoxOrID.Text.Trim()))
            {
                //受注IDの半角数値チェック
                if (!dataInputFormCheck.CheckNumeric(textBoxOrID.Text.Trim()))
                {
                    MessageBox.Show("受注IDは半角数値入力です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxOrID.Focus();
                    return false;
                }
                //文字数
                if (textBoxOrID.TextLength > 6)
                {
                    MessageBox.Show("受注IDは6文字以下です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxOrID.Focus();
                    return false;
                }

                // 受注IDの存在チェック
                if (!orderDataAccess.CheckOrIDExistence(int.Parse(textBoxOrID.Text.Trim())))
                {
                    MessageBox.Show("入力された受注IDは存在しません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxOrID.Focus();
                    return false;
                }

            }
            else
            {
                MessageBox.Show("受注ID が入力されていません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxOrID.Focus();
                return false;
            }
            //受注詳細IDの適否
            if (!String.IsNullOrEmpty(textBoxOrDetailID.Text.Trim()))
            {
                //受注詳細IDは入力不要です
                MessageBox.Show("受注詳細IDは入力不要です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxOrDetailID.Focus();
                return false;
            }
            //商品IDの適否
            if (!String.IsNullOrEmpty(textBoxPrID.Text.Trim()))
            {
                //商品IDの半角数値チェック
                if (!dataInputFormCheck.CheckNumeric(textBoxPrID.Text.Trim()))
                {
                    MessageBox.Show("商品IDは半角数値入力です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxPrID.Focus();
                    return false;
                }
                //文字数
                if (textBoxPrID.TextLength > 6)
                {
                    MessageBox.Show("商品IDは6文字以下です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxPrID.Focus();
                    return false;
                }

                // 商品IDの存在チェック
                if (!productDataAccess.CheckPrIDExistence(int.Parse(textBoxPrID.Text.Trim())))
                {
                    MessageBox.Show("入力された商品IDは存在しません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxPrID.Focus();
                    return false;
                }

            }
            else
            {
                MessageBox.Show("商品ID が入力されていません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxPrID.Focus();
                return false;
            }
            //数量の適否
            if (!String.IsNullOrEmpty(textBoxOrQuantity.Text.Trim()))
            {
                //数量の半角数値チェック
                if (!dataInputFormCheck.CheckNumeric(textBoxOrQuantity.Text.Trim()))
                {
                    MessageBox.Show("数量は半角数値入力です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxOrQuantity.Focus();
                    return false;
                }
                //文字数
                if (textBoxOrQuantity.TextLength > 4)
                {
                    MessageBox.Show("数量は4文字以下です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxOrQuantity.Focus();
                    return false;
                }

            }
            else
            {
                MessageBox.Show("数量が入力されていません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxOrQuantity.Focus();
                return false;
            }
            if (textBoxOrTotalPrice.TextLength > 10)
            {
                MessageBox.Show("合計金額が最大値を超えています", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxOrTotalPrice.Focus();
                return false;

            }

            return true;
        }
        ///////////////////////////////
        //　8.2.1.2 受注詳細情報作成
        //メソッド名：GenerateDataAtRegistration()
        //引　数   ：なし
        //戻り値   ：受注詳細登録情報
        //機　能   ：登録データのセット
        ///////////////////////////////
        private T_OrderDetail GenerateDataAtRegistration()
        {

            return new T_OrderDetail
            {
                OrID = int.Parse(textBoxOrID.Text.Trim()),
                PrID = int.Parse(textBoxPrID.Text.Trim()),
                OrQuantity= int.Parse(textBoxOrQuantity.Text.Trim()),
                OrTotalPrice = int.Parse(textBoxOrTotalPrice.Text.Trim()),
            };
        }
        ///////////////////////////////
        //　8.2.1.3 受注詳細情報登録
        //メソッド名：RegistrationOrder()
        //引　数   ：受注詳細情報
        //戻り値   ：なし
        //機　能   ：受注詳細情報の登録
        ///////////////////////////////
        private void RegistrationOrDetail(T_OrderDetail regOrDetail)
        {
            // 登録確認メッセージ
            DialogResult result = MessageBox.Show("受注詳細データを登録してよろしいですか?", "追加確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Cancel)
                return;
            // 受注詳細情報の登録
            bool flg = orderDetailDataAccess.AddOrderDetailData(regOrDetail);
            if (flg == true)
            
                MessageBox.Show("データを登録しました", "追加確認", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            else
                MessageBox.Show("データの登録に失敗しました", "追加確認", MessageBoxButtons.OK, MessageBoxIcon.Error);

            textBoxPrID.Text = "";
            textBoxOrQuantity.Text = "";
            textBoxPrID.Focus();

            
            //データグリッドビューの表示
            GetOrIDDataGridView();

        }
        ///////////////////////////////
        //メソッド名：ClearInput()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：入力エリアをクリア
        ///////////////////////////////
        private void ClearInput()
        {
            textBoxOrID.Text = "";
            textBoxOrDetailID.Text = "";
            textBoxPrID.Text = "";
            textBoxPrName.Text = "";
            textBoxOrQuantity.Text = "";
            textBoxPrice.Text = "";
            textBoxOrTotalPrice.Text = "";
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
            dataGridViewOrderDetail.ReadOnly = true;
            //直接のサイズの変更を不可
            dataGridViewOrderDetail.AllowUserToResizeRows = false;
            dataGridViewOrderDetail.AllowUserToResizeColumns = false;
            //直接の登録を不可にする
            dataGridViewOrderDetail.AllowUserToAddRows = false;
            //行内をクリックすることで行を選択
            dataGridViewOrderDetail.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //奇数行の色を変更
            dataGridViewOrderDetail.AlternatingRowsDefaultCellStyle.BackColor = Color.Honeydew;
            //ヘッダー位置の指定
            dataGridViewOrderDetail.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

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
            // 受注データの取得
            OrderDetail = orderDetailDataAccess.GetOrDetailData();

            // DataGridViewに表示するデータを指定
            SetDataGridView();

        }
        ///////////////////////////////
        //メソッド名：GetOrIDDataGridView()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：データグリッドビューに表示するデータの取得
        ///////////////////////////////
        private void GetOrIDDataGridView()
        {
            // 受注データの取得
            OrderDetail = orderDetailDataAccess.GetOrIDDetailDspData(int.Parse(textBoxOrID.Text.Trim()));

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
            dataGridViewOrderDetail.DataSource = OrderDetail.Skip(pageSize * pageNo).Take(pageSize).ToList();
            //各列幅の指定 
            dataGridViewOrderDetail.Columns[0].Width = 175;
            dataGridViewOrderDetail.Columns[1].Width = 175;
            dataGridViewOrderDetail.Columns[2].Width = 175;
            dataGridViewOrderDetail.Columns[3].Width = 400;
            dataGridViewOrderDetail.Columns[4].Width = 200;
            dataGridViewOrderDetail.Columns[5].Width = 150;
            dataGridViewOrderDetail.Columns[6].Width = 235;


            //各列の文字位置の指定
            dataGridViewOrderDetail.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewOrderDetail.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewOrderDetail.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewOrderDetail.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewOrderDetail.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewOrderDetail.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewOrderDetail.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            //dataGridViewの総ページ数
            labelPage.Text = "/" + ((int)Math.Ceiling(OrderDetail.Count / (double)pageSize)) + "ページ";

            dataGridViewOrderDetail.Refresh();
        }
        //////////////受注詳細更新機能///////////////
        private void buttonUpdate_Click(object sender, EventArgs e)
        {

            //8.2.2.1  妥当な受注詳細データ取得
            if (!GetValidDataAtUpdate())
                return;

            //8.2.2.2 受注詳細情報作成
            var updOrDetail = GenerateDataAtUpdate();

            //8.2.2.3 受注詳細情報更新
            UpdateOrDetail(updOrDetail);

        }
        ///////////////////////////////
        //　8.2.2.1 妥当な受注詳細データ取得
        //メソッド名：GetValidDataAtUpdate()
        //引　数   ：なし
        //戻り値   ：true or false
        //機　能   ：入力データの形式チェック
        //          ：エラーがない場合True
        //          ：エラーがある場合False
        ///////////////////////////////
        private bool GetValidDataAtUpdate()
        {
            //受注IDの適否
            if (!String.IsNullOrEmpty(textBoxOrID.Text.Trim()))
            {
                //受注IDの半角数値チェック
                if (!dataInputFormCheck.CheckNumeric(textBoxOrID.Text.Trim()))
                {
                    MessageBox.Show("受注IDは半角数値入力です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxOrID.Focus();
                    return false;
                }
                //文字数
                if (textBoxOrID.TextLength > 6)
                {
                    MessageBox.Show("受注IDは6文字以下です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxOrID.Focus();
                    return false;
                }

                // 受注IDの存在チェック
                if (!orderDataAccess.CheckOrIDExistence(int.Parse(textBoxOrID.Text.Trim())))
                {
                    MessageBox.Show("入力された受注IDは存在しません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxOrID.Focus();
                    return false;
                }
                //確定状態の適否
                T_Order order = orderDataAccess.GetOrIDData(int.Parse(textBoxOrID.Text.Trim()));
                if (order.OrStateFlag == 1)
                {
                    MessageBox.Show("入力された受注IDは受注が確定されているため更新できません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxOrID.Focus();
                    return false;

                }

            }
            else
            {
                MessageBox.Show("受注ID が入力されていません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxOrID.Focus();
                return false;
            }
            //受注詳細IDの適否
            if (!String.IsNullOrEmpty(textBoxOrDetailID.Text.Trim()))
            {
                //受注詳細IDの半角数値チェック
                if (!dataInputFormCheck.CheckNumeric(textBoxOrDetailID.Text.Trim()))
                {
                    MessageBox.Show("受注詳細IDは半角数値入力です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxOrDetailID.Focus();
                    return false;
                }
                //文字数
                if (textBoxOrDetailID.TextLength > 6)
                {
                    MessageBox.Show("受注詳細IDは6文字以下です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxOrDetailID.Focus();
                    return false;
                }

                // 受注IDの存在チェック
                if (!orderDetailDataAccess.CheckOrDetailIDExistence(int.Parse(textBoxOrDetailID.Text.Trim())))
                {
                    MessageBox.Show("入力された受注詳細IDは存在しません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxOrDetailID.Focus();
                    return false;
                }

            }
            else
            {
                MessageBox.Show("受注詳細ID が入力されていません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxOrDetailID.Focus();
                return false;
            }
            //商品IDの適否
            if (!String.IsNullOrEmpty(textBoxPrID.Text.Trim()))
            {
                //商品IDの半角数値チェック
                if (!dataInputFormCheck.CheckNumeric(textBoxPrID.Text.Trim()))
                {
                    MessageBox.Show("商品IDは半角数値入力です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxPrID.Focus();
                    return false;
                }
                //文字数
                if (textBoxPrID.TextLength > 6)
                {
                    MessageBox.Show("商品IDは6文字以下です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxPrID.Focus();
                    return false;
                }

                // 商品IDの存在チェック
                if (!productDataAccess.CheckPrIDExistence(int.Parse(textBoxPrID.Text.Trim())))
                {
                    MessageBox.Show("入力された商品IDは存在しません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxPrID.Focus();
                    return false;
                }

            }
            else
            {
                MessageBox.Show("商品ID が入力されていません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxPrID.Focus();
                return false;
            }
            //数量の適否
            if (!String.IsNullOrEmpty(textBoxOrQuantity.Text.Trim()))
            {
                //数量の半角数値チェック
                if (!dataInputFormCheck.CheckNumeric(textBoxOrQuantity.Text.Trim()))
                {
                    MessageBox.Show("数量は半角数値入力です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxOrQuantity.Focus();
                    return false;
                }
                //文字数
                if (textBoxOrQuantity.TextLength > 4)
                {
                    MessageBox.Show("数量は4文字以下です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxOrQuantity.Focus();
                    return false;
                }

            }
            else
            {
                MessageBox.Show("数量が入力されていません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxOrQuantity.Focus();
                return false;
            }
            if (textBoxOrTotalPrice.TextLength > 10)
            {
                MessageBox.Show("合計金額が最大値を超えています", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxOrTotalPrice.Focus();
                return false;

            }

            return true;
        }
        ///////////////////////////////
        //　8.2.2.2 受注詳細情報作成
        //メソッド名：GenerateDataAtUpdate()
        //引　数   ：なし
        //戻り値   ：受注詳細更新情報
        //機　能   ：更新データのセット
        ///////////////////////////////
        private T_OrderDetail GenerateDataAtUpdate()
        {
            return new T_OrderDetail
            {          
                OrID = int.Parse(textBoxOrID.Text.Trim()),
                PrID = int.Parse(textBoxPrID.Text.Trim()),
                OrQuantity= int.Parse(textBoxOrQuantity.Text.Trim()),
                OrTotalPrice = int.Parse(textBoxOrTotalPrice.Text.Trim()),

            };
        }
        ///////////////////////////////
        //　8.3.2.3 受注詳細情報更新
        //メソッド名：UpdateSalesOffice()
        //引　数   ：受注詳細情報
        //戻り値   ：なし
        //機　能   ：受注詳細情報の更新
        ///////////////////////////////
        private void UpdateOrDetail(T_OrderDetail updOrDetail)
        {
            //更新確認メッセージ
            DialogResult result = MessageBox.Show("データを更新しますか？", "更新確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Cancel)
                return;

            //営業所情報の更新
            bool flg = orderDetailDataAccess.UpdateOrderDetailData(updOrDetail);
            if (flg == true)
                MessageBox.Show("データを更新しました", "更新確認", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("データの更新に失敗しました", "更新確認", MessageBoxButtons.OK, MessageBoxIcon.Error);

            textBoxOrID.Focus();

            // 入力エリアのクリア
            ClearInput();

            // データグリッドビューの表示
            GetOrIDDataGridView();

        }
        //検索機能
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            //8.2.3.1妥当な受注詳細データ取得
            if (!GetValidDataAtSelect())
                return;

            //8.2.3.2受注詳細情報抽出
            GenerateDataAtSelect();

            // 8.2.3.3 受注詳細抽出結果表示
            SetSelectData();

        }
        ///////////////////////////////
        //　8.2.3.1 妥当な受注詳細データ取得
        //メソッド名：GetValidDataAtSlect()
        //引　数   ：なし
        //戻り値   ：true or false
        //機　能   ：入力データの形式チェック
        //          ：エラーがない場合True
        //          ：エラーがある場合False
        ///////////////////////////////
        private bool GetValidDataAtSelect()
        {
            if (String.IsNullOrEmpty(textBoxOrID.Text.Trim()) && String.IsNullOrEmpty(textBoxOrDetailID.Text.Trim()) && String.IsNullOrEmpty(textBoxPrID.Text.Trim()))
            {
                MessageBox.Show("検索条件が入力されていません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxOrID.Focus();
                return false;

            }

            //受注IDの適否
            if (!String.IsNullOrEmpty(textBoxOrID.Text.Trim()))
            {
                //受注IDの半角数値チェック
                if (!dataInputFormCheck.CheckNumeric(textBoxOrID.Text.Trim()))
                {
                    MessageBox.Show("受注IDは半角数値入力です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxOrID.Focus();
                    return false;
                }
                //文字数
                if (textBoxOrID.TextLength > 6)
                {
                    MessageBox.Show("受注IDは6文字以下です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxOrID.Focus();
                    return false;
                }

                // 受注IDの存在チェック
                if (!orderDataAccess.CheckOrIDExistence(int.Parse(textBoxOrID.Text.Trim())))
                {
                    MessageBox.Show("入力された受注IDは存在しません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxOrID.Focus();
                    return false;
                }

            }
            //受注詳細IDの適否
            if (!String.IsNullOrEmpty(textBoxOrDetailID.Text.Trim()))
            {
                //受注詳細IDの半角数値チェック
                if (!dataInputFormCheck.CheckNumeric(textBoxOrDetailID.Text.Trim()))
                {
                    MessageBox.Show("受注詳細IDは半角数値入力です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxOrDetailID.Focus();
                    return false;
                }
                //文字数
                if (textBoxOrDetailID.TextLength > 6)
                {
                    MessageBox.Show("受注詳細IDは6文字以下です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxOrDetailID.Focus();
                    return false;
                }

                // 受注詳細IDの存在チェック
                if (!orderDetailDataAccess.CheckOrDetailIDExistence(int.Parse(textBoxOrDetailID.Text.Trim())))
                {
                    MessageBox.Show("入力された受注詳細IDは存在しません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxOrDetailID.Focus();
                    return false;
                }

            }
            //商品IDの適否
            if (!String.IsNullOrEmpty(textBoxPrID.Text.Trim()))
            {
                //商品IDの半角数値チェック
                if (!dataInputFormCheck.CheckNumeric(textBoxPrID.Text.Trim()))
                {
                    MessageBox.Show("商品IDは半角数値入力です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxPrID.Focus();
                    return false;
                }
                //文字数
                if (textBoxPrID.TextLength > 6)
                {
                    MessageBox.Show("商品IDは6文字以下です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxPrID.Focus();
                    return false;
                }

                // 商品IDの存在チェック
                if (!productDataAccess.CheckPrIDExistence(int.Parse(textBoxPrID.Text.Trim())))
                {
                    MessageBox.Show("入力された商品IDは存在しません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxPrID.Focus();
                    return false;
                }

            }
            //数量の適否
            if (!String.IsNullOrEmpty(textBoxOrQuantity.Text.Trim()))
            {
                MessageBox.Show("数量での検索はできません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxOrQuantity.Focus();
                return false;

            }
            return true;

        }
        ///////////////////////////////
        //　8.2.3.2 受注情報抽出
        //メソッド名：GenerateDataAtSelect()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：検索データの取得
        ///////////////////////////////
        private void GenerateDataAtSelect()
        {

            //検索条件のセット
            //全部
            if (!String.IsNullOrEmpty(textBoxOrID.Text.Trim()) && !String.IsNullOrEmpty(textBoxOrDetailID.Text.Trim())&& !String.IsNullOrEmpty(textBoxPrID.Text.Trim()))
            {
                T_OrderDetailDsp selectCondition = new T_OrderDetailDsp()
                {
                    OrID=int.Parse(textBoxOrID.Text.Trim()),
                    OrDetailID = int.Parse(textBoxOrDetailID.Text.Trim()),
                    PrID = int.Parse(textBoxPrID.Text.Trim()),
                };
                OrderDetail = orderDetailDataAccess.GetOrDetailData(1,selectCondition);

            }
            //受注ID≠空白
            if (!String.IsNullOrEmpty(textBoxOrID.Text.Trim()))
            {

                //詳細ID≠空白,商品ID=空白　
                if (!String.IsNullOrEmpty(textBoxOrDetailID.Text.Trim()) && String.IsNullOrEmpty(textBoxPrID.Text.Trim()))
                {
                    T_OrderDetailDsp selectCondition = new T_OrderDetailDsp()
                    {
                        OrID = int.Parse(textBoxOrID.Text.Trim()),
                        OrDetailID = int.Parse(textBoxOrDetailID.Text.Trim()),

                    };
                    OrderDetail = orderDetailDataAccess.GetOrDetailData(2, selectCondition);

                }
                //詳細ID=空白,商品ID≠空白　
                else if (String.IsNullOrEmpty(textBoxOrDetailID.Text.Trim()) && !String.IsNullOrEmpty(textBoxPrID.Text.Trim()))
                {
                    T_OrderDetailDsp selectCondition = new T_OrderDetailDsp()
                    {
                        OrID = int.Parse(textBoxOrID.Text.Trim()),
                        PrID = int.Parse(textBoxPrID.Text.Trim()),

                    };
                    OrderDetail = orderDetailDataAccess.GetOrDetailData(3, selectCondition);

                }
                //詳細ID=空白,商品ID=空白　
                else if (String.IsNullOrEmpty(textBoxOrDetailID.Text.Trim()) && String.IsNullOrEmpty(textBoxPrID.Text.Trim()))
                {
                    T_OrderDetailDsp selectCondition = new T_OrderDetailDsp()
                    {
                        OrID = int.Parse(textBoxOrID.Text.Trim()),

                    };
                    OrderDetail = orderDetailDataAccess.GetOrDetailData(4, selectCondition);

                }

            }
            //受注=空白
            //詳細ID≠空白
            else if (!String.IsNullOrEmpty(textBoxOrDetailID.Text.Trim()))
            {
                //商品ID≠空白
                if (!String.IsNullOrEmpty(textBoxPrID.Text.Trim()))
                {
                    T_OrderDetailDsp selectCondition = new T_OrderDetailDsp()
                    {
                        OrDetailID = int.Parse(textBoxOrDetailID.Text.Trim()),
                        PrID = int.Parse(textBoxPrID.Text.Trim()),

                    };
                    OrderDetail = orderDetailDataAccess.GetOrDetailData(5, selectCondition);

                }
                //商品=空白
                else if (String.IsNullOrEmpty(textBoxPrID.Text.Trim()))
                {
                    T_OrderDetailDsp selectCondition = new T_OrderDetailDsp()
                    {
                        OrDetailID = int.Parse(textBoxOrDetailID.Text.Trim()),

                    };
                    OrderDetail = orderDetailDataAccess.GetOrDetailData(6, selectCondition);

                }
            }
            //受注ID=空白,詳細ID=空白
            //商品ID≠空白
            else if (!String.IsNullOrEmpty(textBoxPrID.Text.Trim()))
                {
                    T_OrderDetailDsp selectCondition = new T_OrderDetailDsp()
                    {
                        PrID = int.Parse(textBoxPrID.Text.Trim()),
                    };
                OrderDetail = orderDetailDataAccess.GetOrDetailData(7, selectCondition);

            }
        }
        ///////////////////////////////
        //　8.2.3.3 受注詳細抽出結果表示
        //メソッド名：SetSelectData()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：受注詳細情報の表示
        ///////////////////////////////
        private void SetSelectData()
        {
            textBoxPage.Text = "1";

            int pageSize = int.Parse(textBoxPageSize.Text);

            dataGridViewOrderDetail.DataSource = OrderDetail;
            if (OrderDetail.Count == 0)
            {
                MessageBox.Show("該当データが存在しません", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            labelPage.Text = "/" + ((int)Math.Ceiling(OrderDetail.Count / (double)pageSize)) + "ページ";
            dataGridViewOrderDetail.Refresh();


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
            dataGridViewOrderDetail.DataSource = OrderDetail.Take(pageSize).ToList();

            // DataGridViewを更新
            dataGridViewOrderDetail.Refresh();
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
            dataGridViewOrderDetail.DataSource = OrderDetail.Skip(pageSize * pageNo).Take(pageSize).ToList();

            // DataGridViewを更新
            dataGridViewOrderDetail.Refresh();
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
            int lastNo = (int)Math.Ceiling(OrderDetail.Count / (double)pageSize) - 1;
            //最終ページでなければ
            if (pageNo <= lastNo)
                dataGridViewOrderDetail.DataSource = OrderDetail.Skip(pageSize * pageNo).Take(pageSize).ToList();

            // DataGridViewを更新
            dataGridViewOrderDetail.Refresh();
            //ページ番号の設定
            int lastPage = (int)Math.Ceiling(OrderDetail.Count / (double)pageSize);
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
            int pageNo = (int)Math.Ceiling(OrderDetail.Count / (double)pageSize) - 1;
            dataGridViewOrderDetail.DataSource = OrderDetail.Skip(pageSize * pageNo).Take(pageSize).ToList();

            // DataGridViewを更新
            dataGridViewOrderDetail.Refresh();
            //ページ番号の設定
            textBoxPage.Text = (pageNo + 1).ToString();

        }
        //詳細情報削除
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            //8.3.4.1 妥当な受注詳細データ取得
            if (!GetValidDataAtDelete())
                return;
            //8.3.4.2 受注詳細情報削除
            DeleteOrDetail();

        }
        ///////////////////////////////
        //  8.3.4.1 妥当な受注詳細データ取得
        //メソッド名：GetValidDataAtDelete()
        //引　数   ：なし
        //戻り値   ：true or false
        //機　能   ：入力データの形式チェック
        //          ：エラーがない場合True
        //          ：エラーがある場合False
        ///////////////////////////////
        private bool GetValidDataAtDelete()
        {
            //受注詳細IDの適否
            if (!String.IsNullOrEmpty(textBoxOrDetailID.Text.Trim()))
            {
                //受注詳細IDの半角数値チェック
                if (!dataInputFormCheck.CheckNumeric(textBoxOrDetailID.Text.Trim()))
                {
                    MessageBox.Show("受注詳細IDは半角数値入力です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxOrDetailID.Focus();
                    return false;
                }
                //文字数
                if (textBoxOrDetailID.TextLength > 6)
                {
                    MessageBox.Show("受注詳細IDは6文字以下です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxOrDetailID.Focus();
                    return false;
                }

                // 受注IDの存在チェック
                if (!orderDetailDataAccess.CheckOrDetailIDExistence(int.Parse(textBoxOrDetailID.Text.Trim())))
                {
                    MessageBox.Show("入力された受注詳細IDは存在しません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxOrDetailID.Focus();
                    return false;
                }

            }
            else
            {
                MessageBox.Show("受注詳細IDが入力されていません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxOrDetailID.Focus();
                return false;
            }

            return true;
        }
        ///////////////////////////////
        //　8.3.4.2  受注詳細情報削除
        //メソッド名：DeleteOrDetail()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：受注詳細情報の削除
        ///////////////////////////////
        private void DeleteOrDetail()
        {
            // 削除確認メッセージ
            DialogResult result = MessageBox.Show("データを削除しますか？", "削除確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);          

            if (result == DialogResult.Cancel)
                return;

            // 受注詳細情報の削除
            bool flg = orderDetailDataAccess.DeleteOrDetailData(int.Parse(textBoxOrDetailID.Text.Trim()));
            if (flg == true)
                MessageBox.Show("データを削除しました", "削除確認", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("データの削除に失敗しました", "削除確認", MessageBoxButtons.OK, MessageBoxIcon.Error);

            textBoxOrDetailID.Focus();

            // 入力エリアのクリア
            ClearInput();

            // データグリッドビューの表示
            GetDataGridView();

        }
        ///////8.2.5.1 一覧表示////////
        private void buttonList_Click(object sender, EventArgs e)
        {
            ClearInput();
            GetDataGridView();
        }
        //入力クリア
        private void buttonClear_Click(object sender, EventArgs e)
        {
            ClearInput();
        }

        //セルクリック
        private void dataGridViewOrderDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //データグリッドビューからクリックされたデータを各入力エリアへ
            textBoxOrID.Text = dataGridViewOrderDetail.Rows[dataGridViewOrderDetail.CurrentRow.Index].Cells[0].Value.ToString();
            textBoxOrDetailID.Text = dataGridViewOrderDetail.Rows[dataGridViewOrderDetail.CurrentRow.Index].Cells[1].Value.ToString();
            textBoxPrID.Text = dataGridViewOrderDetail.Rows[dataGridViewOrderDetail.CurrentRow.Index].Cells[2].Value.ToString();
            textBoxPrName.Text = dataGridViewOrderDetail.Rows[dataGridViewOrderDetail.CurrentRow.Index].Cells[3].Value.ToString();
            textBoxPrice.Text = dataGridViewOrderDetail.Rows[dataGridViewOrderDetail.CurrentRow.Index].Cells[4].Value.ToString();
            textBoxOrQuantity.Text = dataGridViewOrderDetail.Rows[dataGridViewOrderDetail.CurrentRow.Index].Cells[5].Value.ToString();
            textBoxOrTotalPrice.Text=dataGridViewOrderDetail.Rows[dataGridViewOrderDetail.CurrentRow.Index].Cells[6].Value.ToString();
        }
    }
}
