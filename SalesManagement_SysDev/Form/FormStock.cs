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
    public partial class FormStock : Form
    {
        //private int SelectedPrID = 0;
        //メッセージ表示用クラスのインスタンス化
        MessageDsp messageDsp = new MessageDsp();
        //データベース在庫テーブルアクセス用クラスのインスタンス化
        StockDataAccess StockDataAccess = new StockDataAccess();
        //データベース商品テーブルアクセス用クラスのインスタンス化
        ProductDataAccess ProductDataAccess = new ProductDataAccess();
        //入力形式チェック用クラスのインスタンス化
        DataInputFormCheck dataInputFormCheck = new DataInputFormCheck();
        //データグリッドビュー用の商品データ
        private static List<T_StockDsp> Stock;
        


        public FormStock()
        {
            InitializeComponent();
        }

        private void labelClient_Click(object sender, EventArgs e)
        {

        }

        private void timer_Tick(object sender, EventArgs e)
        {
            //日時更新
            labelDay.Text = DateTime.Now.ToString("yyyy/MM/dd/(ddd)");
            labelTime.Text = DateTime.Now.ToString("HH:mm");
        }

        private void buttonFormDel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormStock_Load(object sender, EventArgs e)
        {
            //日時設定
            labelDay.Text = DateTime.Now.ToString("yyyy/MM/dd/(ddd)");
            labelTime.Text = DateTime.Now.ToString("HH:mm");
            //ログインユーザーの情報を表示
            labelUserName.Text = "ユーザー名：" + FormMain.loginName;
            labelPosition.Text = "権限:" + FormMain.loginPoName;
            labelSalesOffice.Text = FormMain.loginSoName;
            labelUserID.Text = "ユーザーID：" + FormMain.loginEmID.ToString();

            // データグリッドビューの表示
            SetFormDataGridView();

        }
        private void GetDataGridView()
        {
            // 在庫データの取得
            Stock = StockDataAccess.GetStockData();

            // DataGridViewに表示するデータを指定
            SetDataGridView();
        }
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


        private void SetDataGridView()
        {
            if (!PageSizeCheck())
            {
                return;
            }
            int pageSize = int.Parse(textBoxPageSize.Text);
            int pageNo = int.Parse(textBoxPage.Text) - 1;
            dataGridViewStock.DataSource = Stock.Skip(pageSize * pageNo).Take(pageSize).ToList();

            //各列幅の指定
            dataGridViewStock.Columns[0].Width = 170;
            dataGridViewStock.Columns[1].Width = 170;
            // dataGridViewStock.Columns[1].Visible = false;
            dataGridViewStock.Columns[2].Width = 474;
            dataGridViewStock.Columns[3].Width = 420;
            dataGridViewStock.Columns[4].Visible = false;


            //各列の文字位置の指定
            dataGridViewStock.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewStock.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewStock.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewStock.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;


            labelPage.Text = "/" + ((int)Math.Ceiling(Stock.Count / (double)pageSize)) + "ページ";

            dataGridViewStock.Refresh();
        }
        private void SetFormDataGridView()
        {
            //dataGridViewのページサイズ指定
            textBoxPageSize.Text = "20";
            //dataGridViewのページ番号指定
            textBoxPage.Text = "1";
            //読み取り専用に指定
            dataGridViewStock.ReadOnly = true;
            //直接のサイズの変更を不可
            dataGridViewStock.AllowUserToResizeRows = false;
            dataGridViewStock.AllowUserToResizeColumns = false;
            //直接の登録を不可にする
            dataGridViewStock.AllowUserToAddRows = false;
            //奇数行の色を変更
            dataGridViewStock.AlternatingRowsDefaultCellStyle.BackColor = Color.Honeydew;
            //行内をクリックすることで行を選択
            dataGridViewStock.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //ヘッダー位置の指定
            dataGridViewStock.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //データグリッドビューのデータ取得
            GetDataGridView();
        }
        private void ClearInput()
        {
            textBoxStID.Text = "";
            textBoxPrID.Text = "";
            textBoxPrName.Text = "";
            textBoxStQuantity.Text = "";
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            // 妥当な在庫データ取得
            if (!GetValidDataAtUpdate())
            {
                return;
            }

            // 在庫情報作成
            var upStock = StockDataAtUpdate();

            //在庫情報更新
            UpdateStock(upStock);
        }

        private bool GetValidDataAtUpdate()
        {
            //在庫IDの適否
            if (!String.IsNullOrEmpty(textBoxStID.Text.Trim()))
            {
                //在庫IDの半角数値チェック
                if (!dataInputFormCheck.CheckNumeric(textBoxStID.Text.Trim()))
                {
                    MessageBox.Show("在庫IDは半角数値入力です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxStID.Focus();
                    return false;
                }
                if (textBoxStID.TextLength > 6)
                {
                    //在庫IDは6文字です
                    messageDsp.DspMsg("M0502");
                    textBoxStID.Focus();
                    return false;
                }

                if (!StockDataAccess.CheckStIDExistence(int.Parse(textBoxStID.Text.Trim())))
                {
                    //入力された在庫IDは存在していません
                    messageDsp.DspMsg("M0504");
                    textBoxStID.Focus();
                    return false;
                }

            }
            else
            {
                //在庫IDが入力されていません
                messageDsp.DspMsg("M0503");
                textBoxStID.Focus();
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
                if (textBoxPrID.TextLength > 6)
                {
                    //商品IDは6文字です
                    messageDsp.DspMsg("M0506");
                    textBoxPrID.Focus();
                    return false;
                }

                if (!ProductDataAccess.CheckPrIDExistence(int.Parse(textBoxPrID.Text.Trim())))
                {
                    //入力された商品IDは存在していません
                    messageDsp.DspMsg("M0511");
                    textBoxPrID.Focus();
                    return false;
                }
            }
            else
            {
                //商品IDが入力されていません
                messageDsp.DspMsg("M0507");
                textBoxPrID.Focus();
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

            if (!String.IsNullOrEmpty(textBoxStQuantity.Text.Trim()))
            {
                if (!dataInputFormCheck.CheckNumeric(textBoxStQuantity.Text.Trim()))
                {
                    MessageBox.Show("在庫数は半角数値入力です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxStQuantity.Focus();
                    return false;
                }
                if (textBoxStQuantity.TextLength > 4)
                {
                    //在庫数は4桁以下です
                    messageDsp.DspMsg("M0509");
                    textBoxStQuantity.Focus();
                    return false;
                }

            }
            else
            {
                //在庫数が入力されていません
                messageDsp.DspMsg("M0510");
                textBoxStQuantity.Focus();
                return false;
            }

            return true;
        }

        private T_Stock StockDataAtUpdate()
        {
            return new T_Stock
            {
                StID = int.Parse(textBoxStID.Text.Trim()),
                PrID = int.Parse(textBoxPrID.Text.Trim()),
                StQuantity = int.Parse(textBoxStQuantity.Text.Trim())
            };
        }

        private void UpdateStock(T_Stock upStock)
        {
            //在庫データを更新してよろしいですか？
            DialogResult result = messageDsp.DspMsg("M0428");
            if (result == DialogResult.Cancel)
            {
                return;
            }
            bool flg = StockDataAccess.UpdateStockData(upStock);
            if (flg == true)
            {
                //商品データを更新しました
                messageDsp.DspMsg("M0429");
            }
            else
            {
                //商品データ更新に失敗しました
                messageDsp.DspMsg("M0429");
            }
            textBoxStID.Focus();
            //入力エリアのクリア
            ClearInput();

            // データグリッドビューの表示
            GetDataGridView();
        }






        private void textBoxPrID_TextChanged(object sender, EventArgs e)
        {
            //object selectedItem = textBoxPrID.Text;

            //if (selectedItem != null && selectedItem is M_Product)
            //{
            //    SelectedPrID = ((M_Product)selectedItem).PrID;


            //}
            //M_Product product = ProductDataAccess.GetPrIDData(SelectedPrID);
            //textBoxPrName.Text = product.PrName.ToString();
            textBoxPrName.Text = "";
            if (dataInputFormCheck.CheckNumeric(textBoxPrID.Text.Trim()))
            {
                if (textBoxPrID.TextLength < 6)
                {
                    if (ProductDataAccess.CheckPrIDExistence(int.Parse(textBoxPrID.Text.Trim())))
                    {
                        M_Product product = ProductDataAccess.GetPrIDData(int.Parse(textBoxPrID.Text.Trim()));
                        textBoxPrName.Text = product.PrName.ToString();
                    }

                }
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            // 妥当な在庫カテゴリデータ取得
            if (!GetValidDataAtSelect())
            {
                return;
            }

            //  在庫カテゴリ情報抽出
            GenerateDataAtSelect();

            // 在庫カテゴリ抽出結果表示
            SetSelectData();
        }
        private bool GetValidDataAtSelect()
        {
            //在庫IDの適否
            if (!String.IsNullOrEmpty(textBoxStID.Text.Trim()))
            {
                if (!dataInputFormCheck.CheckNumeric(textBoxStID.Text.Trim()))
                {
                    MessageBox.Show("在庫IDは半角数値入力です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxStID.Focus();
                    
                }
                if (textBoxStID.TextLength > 6)
                {
                    //在庫IDは6文字です
                    messageDsp.DspMsg("M0502");
                    textBoxStID.Focus();

                }

                if (!StockDataAccess.CheckStIDExistence(int.Parse(textBoxStID.Text.Trim())))
                {
                    //入力された在庫IDは存在していません
                    messageDsp.DspMsg("M0504");
                    textBoxStID.Focus();

                }

            }

            //商品IDの適否
            if (!String.IsNullOrEmpty(textBoxPrID.Text.Trim()))
            {
                if (!dataInputFormCheck.CheckNumeric(textBoxPrID.Text.Trim()))
                {
                    MessageBox.Show("商品IDは半角数値入力です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxPrID.Focus();
                    
                }
                if (textBoxPrID.TextLength > 6)
                {
                    //商品IDは6文字です
                    messageDsp.DspMsg("M0506");
                    textBoxPrID.Focus();

                }

                if (!ProductDataAccess.CheckPrIDExistence(int.Parse(textBoxPrID.Text.Trim())))
                {
                    //入力された商品IDは存在していません
                    messageDsp.DspMsg("M0511");
                    textBoxPrID.Focus();

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

                }

            }


            if (!String.IsNullOrEmpty(textBoxStQuantity.Text.Trim()))
            {
                if (!dataInputFormCheck.CheckNumeric(textBoxStQuantity.Text.Trim()))
                {
                    MessageBox.Show("在庫数は半角数値入力です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxStQuantity.Focus();
                    
                }
                if (textBoxStQuantity.TextLength > 4)
                {
                    //在庫数は4桁以下です
                    messageDsp.DspMsg("M0509");
                    textBoxStQuantity.Focus();

                }

            }



            return true;
        }

        private void GenerateDataAtSelect()
        {
            int StQ = 0;

            if (!String.IsNullOrEmpty(textBoxStID.Text.Trim()) && !String.IsNullOrEmpty(textBoxPrID.Text.Trim()))
            {
                T_StockDsp selectCondition = new T_StockDsp()
                {
                    StID = int.Parse(textBoxStID.Text.Trim()),
                    PrID = int.Parse(textBoxPrID.Text.Trim()),
                    StQuantity = StQ
                };
                Stock = StockDataAccess.GetStockData(1, selectCondition);
            }
            else if (!String.IsNullOrEmpty(textBoxStID.Text.Trim()))
            {
                T_StockDsp selectCondition = new T_StockDsp()
                {
                    StID = int.Parse(textBoxStID.Text.Trim()),
                    //PrID = int.Parse(textBoxPrID.Text.Trim()),
                    StQuantity = StQ
                };
                Stock = StockDataAccess.GetStockData(2, selectCondition);
            }
            else if (!String.IsNullOrEmpty(textBoxPrID.Text.Trim()))
            {
                T_StockDsp selectCondition = new T_StockDsp()
                {
                    //StID = int.Parse(textBoxStID.Text.Trim()),
                    PrID = int.Parse(textBoxPrID.Text.Trim()),
                    StQuantity = StQ
                };
                Stock = StockDataAccess.GetStockData(3, selectCondition);
            }
            else
            {
                T_StockDsp selectCondition = new T_StockDsp()
                {
                    //StID = int.Parse(textBoxStID.Text.Trim()),
                    //PrID = int.Parse(textBoxPrID.Text.Trim()),
                    StQuantity = StQ
                };
                Stock = StockDataAccess.GetStockData(4, selectCondition);
            }


        }
        private void SetSelectData()
        {
            textBoxPage.Text = "1";

            int pageSize = int.Parse(textBoxPageSize.Text);

            dataGridViewStock.DataSource = Stock;

            labelPage.Text = "/" + ((int)Math.Ceiling(Stock.Count / (double)pageSize)) + "ページ";
            dataGridViewStock.Refresh();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            ClearInput();
        }

        private void buttonPageSizeChange_Click(object sender, EventArgs e)
        {
            textBoxPage.Text = 1.ToString();
            SetDataGridView();
        }

        private void dataGridViewStock_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
              textBoxStID.Text = dataGridViewStock.Rows[dataGridViewStock.CurrentRow.Index].Cells[0].Value.ToString();
              textBoxPrID.Text = dataGridViewStock.Rows[dataGridViewStock.CurrentRow.Index].Cells[1].Value.ToString();
              textBoxPrName.Text = dataGridViewStock.Rows[dataGridViewStock.CurrentRow.Index].Cells[2].Value.ToString();
              textBoxStQuantity.Text = dataGridViewStock.Rows[dataGridViewStock.CurrentRow.Index].Cells[3].Value.ToString();

           
        }

        private void buttonPreviousPage_Click(object sender, EventArgs e)
        {
            if (!PageSizeCheck())
            {
                return;
            }
            if (!PageCheck())
            {
                return;
            }
            int pageSize = int.Parse(textBoxPageSize.Text);
            int pageNo = int.Parse(textBoxPage.Text) - 2;
            dataGridViewStock.DataSource = Stock.Skip(pageSize * pageNo).Take(pageSize).ToList();

            // DataGridViewを更新
            dataGridViewStock.Refresh();
            //ページ番号の設定
            if (pageNo + 1 > 1)
                textBoxPage.Text = (pageNo + 1).ToString();
            else
                textBoxPage.Text = "1";
        }

        private void buttonNextPage_Click(object sender, EventArgs e)
        {
            if (!PageSizeCheck())
            {
                return;
            }
            if (!PageCheck())
            {
                return;
            }
                
            int pageSize = int.Parse(textBoxPageSize.Text);
            int pageNo = int.Parse(textBoxPage.Text);
            //最終ページの計算
            int lastNo = (int)Math.Ceiling(Stock.Count / (double)pageSize) - 1;
            //最終ページでなければ
            if (pageNo <= lastNo)
                dataGridViewStock.DataSource = Stock.Skip(pageSize * pageNo).Take(pageSize).ToList();

            // DataGridViewを更新
            dataGridViewStock.Refresh();
            //ページ番号の設定
            int lastPage = (int)Math.Ceiling(Stock.Count / (double)pageSize);
            if (pageNo >= lastPage)
                textBoxPage.Text = lastPage.ToString();
            else
                textBoxPage.Text = (pageNo + 1).ToString();
        }

        private void buttonLastPage_Click(object sender, EventArgs e)
        {
            if (!PageSizeCheck())
            {
                return;
            }
            int pageSize = int.Parse(textBoxPageSize.Text);
            //最終ページの計算
            int pageNo = (int)Math.Ceiling(Stock.Count / (double)pageSize) - 1;
            dataGridViewStock.DataSource = Stock.Skip(pageSize * pageNo).Take(pageSize).ToList();

            // DataGridViewを更新
            dataGridViewStock.Refresh();
            //ページ番号の設定
            textBoxPage.Text = (pageNo + 1).ToString();
        }

        private void buttonFirstPage_Click(object sender, EventArgs e)
        {
            if (!PageSizeCheck())
            {
                return;
            }
            int pageSize = int.Parse(textBoxPageSize.Text);
            dataGridViewStock.DataSource = Stock.Take(pageSize).ToList();

            //DataGridViewを更新
            dataGridViewStock.Refresh();
            //ページ番号の設定
            textBoxPage.Text = "1";
        }

        private void buttonList_Click(object sender, EventArgs e)
        {
            // 入力エリアのクリア
            ClearInput();
            //データグリッドビューの表示
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
    }
}
