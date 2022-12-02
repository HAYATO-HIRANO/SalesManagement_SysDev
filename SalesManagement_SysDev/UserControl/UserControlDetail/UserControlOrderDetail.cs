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
        //データベース商品テーブルアクセス用クラスのインスタンス化
        ProductDataAccess productDataAccess = new ProductDataAccess();
        //データベース注文テーブルアクセス用クラスのインスタンス化
        ChumonDataAccess chumonDataAccess = new ChumonDataAccess();
        //入力形式チェック用クラスのインスタンス化
        DataInputFormCheck dataInputFormCheck = new DataInputFormCheck();
        //データグリッドビュー用の受注データ
        private static List<T_OrderDetailDsp> OrderDetail;

        public UserControlOrderDetail()
        {
            InitializeComponent();
        }

        private void UserControlOrderDetail_Load(object sender, EventArgs e)
        {
            //商品名名選択不可、入力不可
            textBoxPrName.TabStop = false;
            textBoxPrName.ReadOnly = true;
            

            //データグリッドビューの設定
            SetFormDataGridView();

        }

        private void buttonList_Click(object sender, EventArgs e)
        {

            GetDataGridView();
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
            bool flg = orderDataAccess.AddOrderDetailData(regOrDetail);
            if (flg == true)
            
                MessageBox.Show("データを登録しました", "追加確認", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            else
                MessageBox.Show("データの登録に失敗しました", "追加確認", MessageBoxButtons.OK, MessageBoxIcon.Error);

            textBoxPrID.Focus();

            //入力エリアのクリア
            //ClearInput();
            //データグリッドビューの表示
            GetOrIDDataGridView();

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
            OrderDetail = orderDataAccess.GetOrDetailData();

            // DataGridViewに表示するデータを指定
            SetDataGridView();

        }
        ///////////////////////////////
        //メソッド名：GetDataGridView()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：データグリッドビューに表示するデータの取得
        ///////////////////////////////
        private void GetOrIDDataGridView()
        {
            // 受注データの取得
            OrderDetail = orderDataAccess.GetOrIDDetailData(int.Parse(textBoxOrID.Text.Trim()));

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
            int pageSize = int.Parse(textBoxPageSize.Text);
            int pageNo = int.Parse(textBoxPage.Text) - 1;
            dataGridViewOrderDetail.DataSource = OrderDetail.Skip(pageSize * pageNo).Take(pageSize).ToList();
            //各列幅の指定 
            dataGridViewOrderDetail.Columns[0].Width = 100;
            dataGridViewOrderDetail.Columns[1].Width = 100;
            dataGridViewOrderDetail.Columns[2].Width = 100;
            dataGridViewOrderDetail.Columns[3].Width = 200;
            dataGridViewOrderDetail.Columns[4].Width = 100;
            dataGridViewOrderDetail.Columns[5].Width = 100;
            dataGridViewOrderDetail.Columns[6].Width = 150;


            //各列の文字位置の指定
            dataGridViewOrderDetail.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewOrderDetail.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewOrderDetail.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewOrderDetail.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewOrderDetail.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewOrderDetail.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewOrderDetail.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            //dataGridViewの総ページ数
            labelPage.Text = "/" + ((int)Math.Ceiling(OrderDetail.Count / (double)pageSize)) + "ページ";

            dataGridViewOrderDetail.Refresh();
        }


        private void buttonOrder_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGridViewOrderDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void labelPrID_Click(object sender, EventArgs e)
        {

        }

        private void textBoxPrID_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelPrName_Click(object sender, EventArgs e)
        {

        }

        private void textBoxPrName_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelPrice_Click(object sender, EventArgs e)
        {

        }

        private void textBoxPrice_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelOrQuantity_Click(object sender, EventArgs e)
        {

        }

        private void textBoxOrQuantity_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelOrTotalPrice_Click(object sender, EventArgs e)
        {

        }

        private void textBoxOrTotalPrice_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxOrDetailID_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelOrDetailID_Click(object sender, EventArgs e)
        {

        }

        private void textBoxOrderID_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {

        }

        private void labelOrderID_Click(object sender, EventArgs e)
        {

        }
    }
}
