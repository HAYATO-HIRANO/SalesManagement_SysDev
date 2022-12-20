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
    public partial class UserControlChumonDetail : UserControl
    {
        //データベース注文テーブルアクセス用クラスのインスタンス化
        ChumonDataAccess chumonDataAccess = new ChumonDataAccess();
        //データベース注文詳細テーブルアクセス用クラスのインスタンス化
        ChumonDetailDataAccess chumonDetailDataAccess = new ChumonDetailDataAccess();
        //データベース商品テーブルアクセス用クラスのインスタンス化
        ProductDataAccess productDataAccess = new ProductDataAccess();
        //入力形式チェック用クラスのインスタンス化
        DataInputFormCheck dataInputFormCheck = new DataInputFormCheck();
        //データグリッドビュー用の注文データ
        private static List<T_ChumonDetailDsp> ChumonDetails;
        private TChumon tChumon;

        public UserControlChumonDetail()
        {
            InitializeComponent();
        }
        //注文管理で入力された注文ID取得
        public void addTChumon(TChumon tChumon)
        {
            this.tChumon = tChumon;
        }
        //注文詳細に切り替わった時に発生するイベント
        protected override void OnVisibleChanged(EventArgs e)
        {
            if (tChumon != null && tChumon.ChID != 0)
            {
                textBoxChID.Text = tChumon.ChID.ToString();
                
            }

        }

        private void UserControlChumonDetail_Load(object sender, EventArgs e)
        {
            SetFormDataGridView();
        }

        //9.2.1 検索機能
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            //9.2.1.1妥当な注文詳細データ取得
            if (!GetValidDataAtSelect())
                return;

            //13.2.2.2注文詳細情報抽出
            GenerateDataAtSelect();

            // 13.2.2.3 注文詳細抽出結果表示
            SetSelectData();
        }
        ///////////////////////////////
        //　12.2.2.1 妥当な注文詳細データ取得
        //メソッド名：GetValidDataAtSlect()
        //引　数   ：なし
        //戻り値   ：true or false
        //機　能   ：入力データの形式チェック
        //          ：エラーがない場合True
        //          ：エラーがある場合False
        ///////////////////////////////
        private bool GetValidDataAtSelect()
        {
            if (String.IsNullOrEmpty(textBoxChID.Text.Trim()) && String.IsNullOrEmpty(textBoxChDetailID.Text.Trim()) && String.IsNullOrEmpty(textBoxPrID.Text.Trim()))
            {
                MessageBox.Show("検索条件が入力されていません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxChID.Focus();
                return false;
            }
            //注文IDの適否
            if (!String.IsNullOrEmpty(textBoxChID.Text.Trim()))
            {
                //注文IDの半角数値チェック
                if (!dataInputFormCheck.CheckNumeric(textBoxChID.Text.Trim()))
                {
                    MessageBox.Show("注文IDは半角数値入力です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxChID.Focus();
                    return false;
                }
                //文字数
                if (textBoxChID.TextLength > 6)
                {
                    MessageBox.Show("注文IDは6文字以下です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxChID.Focus();
                    return false;
                }
                // 注文IDの存在チェック
                if (!chumonDataAccess.CheckChIDExistence(int.Parse(textBoxChID.Text.Trim())))
                {
                    MessageBox.Show("入力された注文IDは存在しません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxChID.Focus();
                    return false;
                }
            }

            //注文詳細IDの適否
            if (!String.IsNullOrEmpty(textBoxChDetailID.Text.Trim()))
            {
                //注文詳細IDの半角数値チェック
                if (!dataInputFormCheck.CheckNumeric(textBoxChDetailID.Text.Trim()))
                {
                    MessageBox.Show("注文詳細IDは半角数値入力です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxChDetailID.Focus();
                    return false;
                }
                //文字数
                if (textBoxChDetailID.TextLength > 6)
                {
                    MessageBox.Show("注文詳細IDは6文字以下です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxChDetailID.Focus();
                    return false;
                }

                // 入荷詳細IDの存在チェック
                if (!chumonDetailDataAccess.CheckChDetailIDExistence(int.Parse(textBoxChDetailID.Text.Trim())))
                {
                    MessageBox.Show("入力された注文詳細IDは存在しません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxChDetailID.Focus();
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
        //　9.2.2.3 注文情報抽出
        //メソッド名：GenerateDataAtSelect()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：検索データの取得
        ///////////////////////////////
        private void GenerateDataAtSelect()
        {
            // 検索条件のセット
            //全部
            if (!string.IsNullOrEmpty(textBoxChID.Text.Trim()) && !String.IsNullOrEmpty(textBoxChDetailID.Text.Trim()) && !String.IsNullOrEmpty(textBoxPrID.Text.Trim()))
            {
                T_ChumonDetailDsp selectCondition = new T_ChumonDetailDsp()
                {
                    ChID = int.Parse(textBoxChID.Text.Trim()),
                    ChDetailID = int.Parse(textBoxChDetailID.Text.Trim()),
                    PrID = int.Parse(textBoxPrID.Text.Trim()),
                };
                ChumonDetails = chumonDetailDataAccess.GetChDetailData(1, selectCondition);
            }
            // 注文ID≠空白
            if (!String.IsNullOrEmpty(textBoxChID.Text.Trim()))
            {
                //詳細ID≠空白,商品ID=空白　
                if (!String.IsNullOrEmpty(textBoxChDetailID.Text.Trim()) && String.IsNullOrEmpty(textBoxPrID.Text.Trim()))
                {
                    T_ChumonDetailDsp selectCondition = new T_ChumonDetailDsp()
                    {
                        ChID = int.Parse(textBoxChID.Text.Trim()),
                        ChDetailID = int.Parse(textBoxChDetailID.Text.Trim()),

                    };
                    ChumonDetails = chumonDetailDataAccess.GetChDetailData(2, selectCondition);

                }
                //詳細ID=空白,商品ID≠空白
                else if (String.IsNullOrEmpty(textBoxChDetailID.Text.Trim()) && !String.IsNullOrEmpty(textBoxPrID.Text.Trim()))
                {
                    T_ChumonDetailDsp selectCondition = new T_ChumonDetailDsp()
                    {
                        ChID = int.Parse(textBoxChID.Text.Trim()),
                        ChDetailID = int.Parse(textBoxChDetailID.Text.Trim()),

                    };
                    ChumonDetails = chumonDetailDataAccess.GetChDetailData(3, selectCondition);

                }
                //詳細ID=空白,商品ID=空白　
                else if (String.IsNullOrEmpty(textBoxChDetailID.Text.Trim()) && !String.IsNullOrEmpty(textBoxPrID.Text.Trim()))
                {
                    T_ChumonDetailDsp selectCondition = new T_ChumonDetailDsp()
                    {
                        ChID = int.Parse(textBoxChID.Text.Trim()),

                    };
                    ChumonDetails = chumonDetailDataAccess.GetChDetailData(4, selectCondition);

                }
                //注文ID=空白
                //詳細ID≠空白
                else if (!String.IsNullOrEmpty(textBoxChDetailID.Text.Trim()))
                {
                    //商品ID≠空白
                    if (!String.IsNullOrEmpty(textBoxPrID.Text.Trim()))
                    {
                        T_ChumonDetailDsp selectCondition = new T_ChumonDetailDsp()
                        {
                            ChDetailID = int.Parse(textBoxChDetailID.Text.Trim()),
                            PrID = int.Parse(textBoxPrID.Text.Trim()),
                        };
                        ChumonDetails = chumonDetailDataAccess.GetChDetailData(5, selectCondition);

                    }
                    //商品=空白
                    else if (String.IsNullOrEmpty(textBoxPrID.Text.Trim()))
                    {
                        T_ChumonDetailDsp selectCondition = new T_ChumonDetailDsp()
                        {
                            ChDetailID = int.Parse(textBoxChDetailID.Text.Trim()),
                        };
                        ChumonDetails = chumonDetailDataAccess.GetChDetailData(1, selectCondition);
                    }
                }
            }
            //入荷ID=空白,詳細ID=空白
            //商品ID≠空白
            else if (!String.IsNullOrEmpty(textBoxPrID.Text.Trim()))
            {

                T_ChumonDetailDsp selectCondition = new T_ChumonDetailDsp()
                {
                    PrID = int.Parse(textBoxPrID.Text.Trim()),
                };
                ChumonDetails = chumonDetailDataAccess.GetChDetailData(7, selectCondition);
            }
        }
        ///////////////////////////////
        //　9.2.2.3 注文詳細抽出結果表示
        //メソッド名：SetSelectData()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：注文詳細情報の表示
        ////////////////////////////////
        private void SetSelectData()
        {
            textBoxPage.Text = "1";

            int pageSize = int.Parse(textBoxPageSize.Text);

            dataGridViewOrderDetail.DataSource = ChumonDetails;
            if (ChumonDetails.Count == 0)
            {
                MessageBox.Show("該当データが存在しません", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            labelPage.Text = "/" + ((int)Math.Ceiling(ChumonDetails.Count / (double)pageSize)) + "ページ";
            dataGridViewOrderDetail.Refresh();
        }


        //9.2.2一覧表示機能
        private void buttonList_Click(object sender, EventArgs e)
        {
            ClearInput();
            GetDataGridView();
        }

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

        private void textBoxChID_TextChanged(object sender, EventArgs e)
        {
            labelStateFlag.Text = "";
            if (dataInputFormCheck.CheckNumeric(textBoxChID.Text.Trim()))
            {
                if (textBoxChID.TextLength < 6)
                {
                    if (chumonDataAccess.CheckChIDExistence(int.Parse(textBoxChID.Text.Trim())))
                    {
                        T_Chumon chumon = chumonDataAccess.GetChIDData(int.Parse(textBoxChID.Text.Trim()));
                        {
                            if (chumon.ChStateFlag == 1)
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
            textBoxChID.Text = "";
            textBoxChDetailID.Text = "";
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
            //注文詳細データの取得
            ChumonDetails = chumonDetailDataAccess.GetChDetailData();

            //DataGridViewに表示するデータを指定
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
            dataGridViewOrderDetail.DataSource = ChumonDetails.Skip(pageSize * pageNo).Take(pageSize).ToList();
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
            labelPage.Text = "/" + ((int)Math.Ceiling(ChumonDetails.Count / (double)pageSize)) + "ページ";

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
            dataGridViewOrderDetail.DataSource = ChumonDetails.Take(pageSize).ToList();

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
            dataGridViewOrderDetail.DataSource = ChumonDetails.Skip(pageSize * pageNo).Take(pageSize).ToList();

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
            int lastNo = (int)Math.Ceiling(ChumonDetails.Count / (double)pageSize) - 1;
            //最終ページでなければ
            if (pageNo <= lastNo)
                dataGridViewOrderDetail.DataSource = ChumonDetails.Skip(pageSize * pageNo).Take(pageSize).ToList();

            // DataGridViewを更新
            dataGridViewOrderDetail.Refresh();
            //ページ番号の設定
            int lastPage = (int)Math.Ceiling(ChumonDetails.Count / (double)pageSize);
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
            int pageNo = (int)Math.Ceiling(ChumonDetails.Count / (double)pageSize) - 1;
            dataGridViewOrderDetail.DataSource = ChumonDetails.Skip(pageSize * pageNo).Take(pageSize).ToList();

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
