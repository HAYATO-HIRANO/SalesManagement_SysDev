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
    public partial class UserControlArrivalDetail : UserControl
    {
        //データベース入荷テーブルアクセス用クラスのインスタンス化
        ArrivalDataAccess arrivalDataAccess = new ArrivalDataAccess();
        //データベース入荷詳細テーブルアクセス用クラスのインスタンス化
        ArrivalDetailDataAccess arrivalDetailDataAccess = new ArrivalDetailDataAccess();
        //データベース商品テーブルアクセス用クラスのインスタンス化
        ProductDataAccess productDataAccess = new ProductDataAccess();
        //入力形式チェック用クラスのインスタンス化
        DataInputFormCheck dataInputFormCheck = new DataInputFormCheck();
        //データグリッドビュー用の入荷データ
        private static List<T_ArrivalDetailDsp> ArrivalDetail;
        //入荷ID参照用クラス
        private TArrival tArrival;


        public UserControlArrivalDetail()
        {
            InitializeComponent();
        }
        public void addTArrival(TArrival tArrival)
        {
            this.tArrival = tArrival;
        }
        protected override void OnVisibleChanged(EventArgs e)
        {
            if (tArrival != null&&tArrival.ArID!=0)
            {
                textBoxArID.Text = tArrival.ArID.ToString();
                GetArIDDataGridView();
            }

        }

        private void UserControlArrivalDetail_Load(object sender, EventArgs e)
        {
            SetFormDataGridView();
        }

        //13.2.1  検索機能  
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            //13.2.1.1妥当な入荷詳細データ取得
            if (!GetValidDataAtSelect())
                return;

            //13.2.2.2入荷詳細情報抽出
            GenerateDataAtSelect();

            // 13.2.2.3 入荷詳細抽出結果表示
            SetSelectData();
        }
        ///////////////////////////////
        //　13.2.1.1 妥当な入荷詳細データ取得
        //メソッド名：GetValidDataAtSlect()
        //引　数   ：なし
        //戻り値   ：true or false
        //機　能   ：入力データの形式チェック
        //          ：エラーがない場合True
        //          ：エラーがある場合False
        ///////////////////////////////
        private bool GetValidDataAtSelect()
        {
            if (String.IsNullOrEmpty(textBoxArID.Text.Trim()) && String.IsNullOrEmpty(textBoxArDetailID.Text.Trim()) && String.IsNullOrEmpty(textBoxPrID.Text.Trim()))
            {
                MessageBox.Show("検索条件が入力されていません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxArID.Focus();
                return false;
            }
            //入荷IDの適否
            if (!String.IsNullOrEmpty(textBoxArID.Text.Trim()))
            {
                //入荷IDの半角数値チェック
                if (!dataInputFormCheck.CheckNumeric(textBoxArID.Text.Trim()))
                {
                    MessageBox.Show("入荷IDは半角数値入力です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxArID.Focus();
                    return false;
                }
                //文字数
                if (textBoxArID.TextLength > 6)
                {
                    MessageBox.Show("入荷IDは6文字以下です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxArID.Focus();
                    return false;
                }
                // 入荷IDの存在チェック
                if (!arrivalDataAccess.CheckArIDExistence(int.Parse(textBoxArID.Text.Trim())))
                {
                    MessageBox.Show("入力された入荷IDは存在しません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxArID.Focus();
                    return false;
                }

            }

            //入荷詳細IDの適否
            if (!String.IsNullOrEmpty(textBoxArDetailID.Text.Trim()))
            {
                //入荷詳細IDの半角数値チェック
                if (!dataInputFormCheck.CheckNumeric(textBoxArDetailID.Text.Trim()))
                {
                    MessageBox.Show("入荷詳細IDは半角数値入力です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxArDetailID.Focus();
                    return false;
                }
                //文字数
                if (textBoxArDetailID.TextLength > 6)
                {
                    MessageBox.Show("入荷詳細IDは6文字以下です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxArDetailID.Focus();
                    return false;
                }

                // 入荷詳細IDの存在チェック
                if (!arrivalDetailDataAccess.CheckArDetailIDExistence(int.Parse(textBoxArDetailID.Text.Trim())))
                {
                    MessageBox.Show("入力された入荷詳細IDは存在しません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxArDetailID.Focus();
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
        //　13.2.1.2 入荷情報抽出
        //メソッド名：GenerateDataAtSelect()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：検索データの取得
        ///////////////////////////////
        private void GenerateDataAtSelect()
        {
            //検索条件のセット
            //全部
            if (!String.IsNullOrEmpty(textBoxArID.Text.Trim()) && !String.IsNullOrEmpty(textBoxArDetailID.Text.Trim()) && !String.IsNullOrEmpty(textBoxPrID.Text.Trim()))
            {
                T_ArrivalDetailDsp selectCondition = new T_ArrivalDetailDsp()
                {

                    ArID = int.Parse(textBoxArID.Text.Trim()),
                    ArDetailID = int.Parse(textBoxArDetailID.Text.Trim()),
                    PrID = int.Parse(textBoxPrID.Text.Trim()),
                };
                ArrivalDetail = arrivalDetailDataAccess.GetArDetailData(1, selectCondition);

            }
            //入荷ID≠空白
            if (!String.IsNullOrEmpty(textBoxArID.Text.Trim()))
            {
                //詳細ID≠空白,商品ID=空白　
                if (!String.IsNullOrEmpty(textBoxArDetailID.Text.Trim()) && String.IsNullOrEmpty(textBoxPrID.Text.Trim()))
                {
                    T_ArrivalDetailDsp selectCondition = new T_ArrivalDetailDsp()
                    {
                        ArID = int.Parse(textBoxArID.Text.Trim()),
                        ArDetailID = int.Parse(textBoxArDetailID.Text.Trim()),

                    };
                    ArrivalDetail = arrivalDetailDataAccess.GetArDetailData(2, selectCondition);
                }
                //詳細ID=空白,商品ID≠空白
                else if (String.IsNullOrEmpty(textBoxArDetailID.Text.Trim()) && !String.IsNullOrEmpty(textBoxPrID.Text.Trim()))
                {
                    T_ArrivalDetailDsp selectCondition = new T_ArrivalDetailDsp()
                    {
                        ArID = int.Parse(textBoxArID.Text.Trim()),
                        ArDetailID = int.Parse(textBoxArDetailID.Text.Trim()),

                    };
                    ArrivalDetail = arrivalDetailDataAccess.GetArDetailData(3, selectCondition);

                }
                //詳細ID=空白,商品ID=空白　
                else if (String.IsNullOrEmpty(textBoxArDetailID.Text.Trim()) && !String.IsNullOrEmpty(textBoxPrID.Text.Trim()))
                {
                    T_ArrivalDetailDsp selectCondition = new T_ArrivalDetailDsp()
                    {
                        ArID = int.Parse(textBoxArID.Text.Trim()),

                    };
                    ArrivalDetail = arrivalDetailDataAccess.GetArDetailData(4, selectCondition);

                }
                //入荷ID=空白
                //詳細ID≠空白
                else if (!String.IsNullOrEmpty(textBoxArDetailID.Text.Trim()))
                {
                    //商品ID≠空白
                    if (!String.IsNullOrEmpty(textBoxPrID.Text.Trim()))
                    {
                        T_ArrivalDetailDsp selectCondition = new T_ArrivalDetailDsp()
                        {
                            ArDetailID = int.Parse(textBoxArDetailID.Text.Trim()),
                            PrID = int.Parse(textBoxPrID.Text.Trim()),
                        };
                        ArrivalDetail = arrivalDetailDataAccess.GetArDetailData(5, selectCondition);

                    }
                    //商品=空白
                    else if (String.IsNullOrEmpty(textBoxPrID.Text.Trim()))
                    {
                        T_ArrivalDetailDsp selectCondition = new T_ArrivalDetailDsp()
                        {
                            ArDetailID = int.Parse(textBoxArDetailID.Text.Trim()),
                        };
                        ArrivalDetail = arrivalDetailDataAccess.GetArDetailData(6, selectCondition);
                    }
                }
            }
            //入荷ID=空白,詳細ID=空白
            //商品ID≠空白
            else if (!String.IsNullOrEmpty(textBoxPrID.Text.Trim()))
            {
                T_ArrivalDetailDsp selectCondition = new T_ArrivalDetailDsp()
                {
                    PrID = int.Parse(textBoxPrID.Text.Trim()),
                };
                ArrivalDetail = arrivalDetailDataAccess.GetArDetailData(7, selectCondition);

            }
        }

        ///////////////////////////////
        //　13.2.1.3 入荷詳細抽出結果表示
        //メソッド名：SetSelectData()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：入荷詳細情報の表示
        ////////////////////////////////
        private void SetSelectData()
        {
            textBoxPage.Text = "1";

            int pageSize = int.Parse(textBoxPageSize.Text);

            dataGridViewOrderDetail.DataSource = ArrivalDetail;
            if (ArrivalDetail.Count == 0)
            {
                MessageBox.Show("該当データが存在しません", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            labelPage.Text = "/" + ((int)Math.Ceiling(ArrivalDetail.Count / (double)pageSize)) + "ページ";
            dataGridViewOrderDetail.Refresh();
        }

        //13.2.2 一覧表示機能
        private void buttonList_Click(object sender, EventArgs e)
        {
            ClearInput();
            GetDataGridView();
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

        //入荷IDの入荷確定状態を取得して表示
        private void textBoxArID_TextChanged(object sender, EventArgs e)
        {
            labelStateFlag.Text = "";
            if (dataInputFormCheck.CheckNumeric(textBoxArID.Text.Trim()))
            {
                if (textBoxArID.TextLength < 6)
                {
                    if (arrivalDataAccess.CheckArIDExistence(int.Parse(textBoxArID.Text.Trim())))
                    {
                        T_Arrival arrival = arrivalDataAccess.GetArIDData(int.Parse(textBoxArID.Text.Trim()));
                        {
                            if (arrival.ArStateFlag == 1)
                                labelStateFlag.Text = "確定済";
                            else
                                labelStateFlag.Text = "未確定";
                        }
                    }
                }
            }
        }
        ///////////////////////////////
        //メソッド名：ClearInput()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：入力エリアをクリア
        ///////////////////////////////
        private void ClearInput()
        {
            textBoxArID.Text = "";
            textBoxArDetailID.Text = "";
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
            //入荷詳細データの取得
            ArrivalDetail = arrivalDetailDataAccess.GetArDetailData();

            //DataGridViewに表示するデータを指定
            SetDataGridView();
        }
        ///////////////////////////////
        //メソッド名：GetArIDDataGridView()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：データグリッドビューに表示するデータの取得
        ///////////////////////////////
        private void GetArIDDataGridView()
        {
            // 入荷詳細データの取得
            ArrivalDetail = arrivalDetailDataAccess.GetArIDDetailDspData(int.Parse(textBoxArID.Text.Trim()));

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
            dataGridViewOrderDetail.DataSource = ArrivalDetail.Skip(pageSize * pageNo).Take(pageSize).ToList();
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
            labelPage.Text = "/" + ((int)Math.Ceiling(ArrivalDetail.Count / (double)pageSize)) + "ページ";

            dataGridViewOrderDetail.Refresh();

        }

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
            dataGridViewOrderDetail.DataSource = ArrivalDetail.Take(pageSize).ToList();

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
            dataGridViewOrderDetail.DataSource = ArrivalDetail.Skip(pageSize * pageNo).Take(pageSize).ToList();

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
            int lastNo = (int)Math.Ceiling(ArrivalDetail.Count / (double)pageSize) - 1;
            //最終ページでなければ
            if (pageNo <= lastNo)
                dataGridViewOrderDetail.DataSource = ArrivalDetail.Skip(pageSize * pageNo).Take(pageSize).ToList();

            // DataGridViewを更新
            dataGridViewOrderDetail.Refresh();
            //ページ番号の設定
            int lastPage = (int)Math.Ceiling(ArrivalDetail.Count / (double)pageSize);
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
            int pageNo = (int)Math.Ceiling(ArrivalDetail.Count / (double)pageSize) - 1;
            dataGridViewOrderDetail.DataSource = ArrivalDetail.Skip(pageSize * pageNo).Take(pageSize).ToList();

            // DataGridViewを更新
            dataGridViewOrderDetail.Refresh();
            //ページ番号の設定
            textBoxPage.Text = (pageNo + 1).ToString();

        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            ClearInput();
        }
    }
}