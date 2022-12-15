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
    public partial class UserControlSyukkoDetail : UserControl
    {
        //データベース出庫テーブルアクセス用クラスのインスタンス化
        SyukkoDataAccess syukkoDataAccess = new SyukkoDataAccess();
        //データベース出庫詳細テーブルアクセス用クラスのインスタンス化
        SyukkoDetailDataAccess syukkoDetaiDataAccess = new SyukkoDetailDataAccess();
        //データベース商品テーブルアクセス用クラスのインスタンス化
        ProductDataAccess productDataAccess = new ProductDataAccess();
        //入力形式チェック用クラスのインスタンス化
        DataInputFormCheck dataInputFormCheck = new DataInputFormCheck();
        //データグリッドビュー用の受注データ
        private static List<T_SyukkoDetailDsp> SyukkoDetail;

        public UserControlSyukkoDetail()
        {
            InitializeComponent();
        }

        private void UserControlSyukkoDetail_Load(object sender, EventArgs e)
        {
            SetFormDataGridView();
        }
        //12.2.1　検索機能
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            //12.2.2.1妥当な出庫詳細データ取得
            if (!GetValidDataAtSelect())
                return;

            //12.2.2.2出庫詳細情報抽出
            GenerateDataAtSelect();

            // 12.2.2.3 出庫詳細抽出結果表示
            SetSelectData();

        }
        ///////////////////////////////
        //　12.2.2.1 妥当な出庫詳細データ取得
        //メソッド名：GetValidDataAtSlect()
        //引　数   ：なし
        //戻り値   ：true or false
        //機　能   ：入力データの形式チェック
        //          ：エラーがない場合True
        //          ：エラーがある場合False
        ///////////////////////////////
        private bool GetValidDataAtSelect()
        {
            if (String.IsNullOrEmpty(textBoxSyID.Text.Trim()) && String.IsNullOrEmpty(textBoxSyDetailID.Text.Trim()) && String.IsNullOrEmpty(textBoxPrID.Text.Trim()))
            {
                MessageBox.Show("検索条件が入力されていません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxSyID.Focus();
                return false;

            }

            //出庫IDの適否
            if (!String.IsNullOrEmpty(textBoxSyID.Text.Trim()))
            {
                //出庫IDの半角数値チェック
                if (!dataInputFormCheck.CheckNumeric(textBoxSyID.Text.Trim()))
                {
                    MessageBox.Show("出庫IDは半角数値入力です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxSyID.Focus();
                    return false;
                }
                //文字数
                if (textBoxSyID.TextLength > 6)
                {
                    MessageBox.Show("出庫IDは6文字以下です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxSyID.Focus();
                    return false;
                }

                // 出庫IDの存在チェック
                if (!syukkoDataAccess.CheckSyIDExistence(int.Parse(textBoxSyID.Text.Trim())))
                {
                    MessageBox.Show("入力された出庫IDは存在しません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxSyID.Focus();
                    return false;
                }

            }
            //出庫詳細IDの適否
            if (!String.IsNullOrEmpty(textBoxSyDetailID.Text.Trim()))
            {
                //出庫詳細IDの半角数値チェック
                if (!dataInputFormCheck.CheckNumeric(textBoxSyDetailID.Text.Trim()))
                {
                    MessageBox.Show("出庫詳細IDは半角数値入力です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxSyDetailID.Focus();
                    return false;
                }
                //文字数
                if (textBoxSyDetailID.TextLength > 6)
                {
                    MessageBox.Show("出庫詳細IDは6文字以下です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxSyDetailID.Focus();
                    return false;
                }

                // 出庫詳細IDの存在チェック
                if (!syukkoDetaiDataAccess.CheckSyDetailIDExistence(int.Parse(textBoxSyDetailID.Text.Trim())))
                {
                    MessageBox.Show("入力された出庫詳細IDは存在しません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxSyDetailID.Focus();
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
            if (!String.IsNullOrEmpty(textBoxSyQuantity.Text.Trim()))
            {
                MessageBox.Show("数量での検索はできません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxSyQuantity.Focus();
                return false;

            }
            return true;

        }
        ///////////////////////////////
        //　12.2.2.3 出庫情報抽出
        //メソッド名：GenerateDataAtSelect()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：検索データの取得
        ///////////////////////////////
        private void GenerateDataAtSelect()
        {
            //検索条件のセット
            //全部
            if (!String.IsNullOrEmpty(textBoxSyID.Text.Trim()) && !String.IsNullOrEmpty(textBoxSyDetailID.Text.Trim()) && !String.IsNullOrEmpty(textBoxPrID.Text.Trim()))
            {
                T_SyukkoDetailDsp selectCondition = new T_SyukkoDetailDsp()
                {
                    SyID = int.Parse(textBoxSyID.Text.Trim()),
                    SyDetailID = int.Parse(textBoxSyDetailID.Text.Trim()),
                    PrID = int.Parse(textBoxPrID.Text.Trim()),
                };
                SyukkoDetail = syukkoDetaiDataAccess.GetSyDetailData(1, selectCondition);

            }
            //出庫ID≠空白
            if (!String.IsNullOrEmpty(textBoxSyID.Text.Trim()))
            {

                //詳細ID≠空白,商品ID=空白　
                if (!String.IsNullOrEmpty(textBoxSyDetailID.Text.Trim()) && String.IsNullOrEmpty(textBoxPrID.Text.Trim()))
                {
                    T_SyukkoDetailDsp selectCondition = new T_SyukkoDetailDsp()
                    {
                        SyID = int.Parse(textBoxSyID.Text.Trim()),
                        SyDetailID = int.Parse(textBoxSyDetailID.Text.Trim()),

                    };
                    SyukkoDetail = syukkoDetaiDataAccess.GetSyDetailData(2, selectCondition);

                }
                //詳細ID=空白,商品ID≠空白　
                else if (String.IsNullOrEmpty(textBoxSyDetailID.Text.Trim()) && !String.IsNullOrEmpty(textBoxPrID.Text.Trim()))
                {
                    T_SyukkoDetailDsp selectCondition = new T_SyukkoDetailDsp()
                    {
                        SyID = int.Parse(textBoxSyID.Text.Trim()),
                        PrID = int.Parse(textBoxPrID.Text.Trim()),

                    };
                    SyukkoDetail = syukkoDetaiDataAccess.GetSyDetailData(3, selectCondition);

                }
                //詳細ID=空白,商品ID=空白　
                else if (String.IsNullOrEmpty(textBoxSyDetailID.Text.Trim()) && String.IsNullOrEmpty(textBoxPrID.Text.Trim()))
                {
                    T_SyukkoDetailDsp selectCondition = new T_SyukkoDetailDsp()
                    {
                        SyID = int.Parse(textBoxSyID.Text.Trim()),

                    };
                    SyukkoDetail = syukkoDetaiDataAccess.GetSyDetailData(4, selectCondition);

                }

            }
            //出庫ID=空白
            //詳細ID≠空白
            else if (!String.IsNullOrEmpty(textBoxSyDetailID.Text.Trim()))
            {
                //商品ID≠空白
                if (!String.IsNullOrEmpty(textBoxPrID.Text.Trim()))
                {
                    T_SyukkoDetailDsp selectCondition = new T_SyukkoDetailDsp()
                    {
                        SyDetailID = int.Parse(textBoxSyDetailID.Text.Trim()),
                        PrID = int.Parse(textBoxPrID.Text.Trim()),

                    };
                    SyukkoDetail = syukkoDetaiDataAccess.GetSyDetailData(5, selectCondition);

                }
                //商品=空白
                else if (String.IsNullOrEmpty(textBoxPrID.Text.Trim()))
                {
                    T_SyukkoDetailDsp selectCondition = new T_SyukkoDetailDsp()
                    {
                        SyDetailID = int.Parse(textBoxSyDetailID.Text.Trim()),

                    };
                    SyukkoDetail = syukkoDetaiDataAccess.GetSyDetailData(6, selectCondition);

                }
            }
            //出庫ID=空白,詳細ID=空白
            //商品ID≠空白
            else if (!String.IsNullOrEmpty(textBoxPrID.Text.Trim()))
            {
                T_SyukkoDetailDsp selectCondition = new T_SyukkoDetailDsp()
                {
                    PrID = int.Parse(textBoxPrID.Text.Trim()),
                };
                SyukkoDetail = syukkoDetaiDataAccess.GetSyDetailData(7, selectCondition);

            }

        }
        ///////////////////////////////
        //　12.2.2.3 出庫詳細抽出結果表示
        //メソッド名：SetSelectData()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：出庫詳細情報の表示
        ///////////////////////////////
        private void SetSelectData()
        {
            textBoxPage.Text = "1";

            int pageSize = int.Parse(textBoxPageSize.Text);

            dataGridViewSyukkoDetail.DataSource = SyukkoDetail;
            if (SyukkoDetail.Count == 0)
            {
                MessageBox.Show("該当データが存在しません", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            labelPage.Text = "/" + ((int)Math.Ceiling(SyukkoDetail.Count / (double)pageSize)) + "ページ";
            dataGridViewSyukkoDetail.Refresh();


        }

        //12.2.2 一覧表示機能
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
                if (dataInputFormCheck.CheckNumeric(textBoxSyQuantity.Text.Trim()))
                {
                    if (textBoxSyQuantity.TextLength < 4)
                    {
                        textBoxOrTotalPrice.Text = (int.Parse(textBoxPrice.Text.Trim()) * int.Parse(textBoxSyQuantity.Text.Trim())).ToString();
                    }

                }
            }


        }
        //受注IDの受注確定状態を取得して表示

        private void textBoxSyID_TextChanged(object sender, EventArgs e)
        {
            labelStateFlag.Text = "";
            if (dataInputFormCheck.CheckNumeric(textBoxSyID.Text.Trim()))
            {
                if (textBoxSyID.TextLength < 6)
                {
                    if (syukkoDataAccess.CheckSyIDExistence(int.Parse(textBoxSyID.Text.Trim())))
                    {
                        T_Syukko syukko = syukkoDataAccess.GetSyIDData(int.Parse(textBoxSyID.Text.Trim()));
                        if (syukko.SyStateFlag == 1)

                            labelStateFlag.Text = "確定済";

                        else
                            labelStateFlag.Text = "未確定";

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
            textBoxSyID.Text = "";
            textBoxSyDetailID.Text = "";
            textBoxPrID.Text = "";
            textBoxPrName.Text = "";
            textBoxSyQuantity.Text = "";
            textBoxPrice.Text = "";
            textBoxOrTotalPrice.Text = "";
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
            dataGridViewSyukkoDetail.ReadOnly = true;
            //直接のサイズの変更を不可
            dataGridViewSyukkoDetail.AllowUserToResizeRows = false;
            dataGridViewSyukkoDetail.AllowUserToResizeColumns = false;
            //直接の登録を不可にする
            dataGridViewSyukkoDetail.AllowUserToAddRows = false;
            //行内をクリックすることで行を選択
            dataGridViewSyukkoDetail.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //奇数行の色を変更
            dataGridViewSyukkoDetail.AlternatingRowsDefaultCellStyle.BackColor = Color.Honeydew;
            //ヘッダー位置の指定
            dataGridViewSyukkoDetail.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

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
            // 出庫詳細データの取得
            SyukkoDetail = syukkoDetaiDataAccess.GetSyDetailData();

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
            if (!String.IsNullOrEmpty(textBoxPageSize.Text.Trim()))
            {
                if (!dataInputFormCheck.CheckNumeric(textBoxPageSize.Text.Trim()))
                {
                    MessageBox.Show("ページ行数は半角数値のみです", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxPageSize.Focus();
                    return;
                }
                if (int.Parse(textBoxPageSize.Text) <= 0)
                {
                    MessageBox.Show("ページ行数は1以上です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxPageSize.Focus();
                    return;

                }
            }
            else
            {
                MessageBox.Show("ページ行数が入力されていません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxPageSize.Focus();
                return;

            }

            int pageSize = int.Parse(textBoxPageSize.Text);
            int pageNo = int.Parse(textBoxPage.Text) - 1;
            dataGridViewSyukkoDetail.DataSource = SyukkoDetail.Skip(pageSize * pageNo).Take(pageSize).ToList();
            //各列幅の指定 
            dataGridViewSyukkoDetail.Columns[0].Width = 175;
            dataGridViewSyukkoDetail.Columns[1].Width = 175;
            dataGridViewSyukkoDetail.Columns[2].Width = 175;
            dataGridViewSyukkoDetail.Columns[3].Width = 400;
            dataGridViewSyukkoDetail.Columns[4].Width = 200;
            dataGridViewSyukkoDetail.Columns[5].Width = 150;
            dataGridViewSyukkoDetail.Columns[6].Width = 235;


            //各列の文字位置の指定
            dataGridViewSyukkoDetail.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewSyukkoDetail.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewSyukkoDetail.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewSyukkoDetail.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewSyukkoDetail.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewSyukkoDetail.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewSyukkoDetail.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            //dataGridViewの総ページ数
            labelPage.Text = "/" + ((int)Math.Ceiling(SyukkoDetail.Count / (double)pageSize)) + "ページ";

            dataGridViewSyukkoDetail.Refresh();
        }

        ///////////////////////////////
        //メソッド名：buttonPageSizeChange_Click()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：データグリッドビューの表示件数変更
        ///////////////////////////////

        private void buttonPageSizeChange_Click(object sender, EventArgs e)
        {
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
            int pageSize = int.Parse(textBoxPageSize.Text);
            dataGridViewSyukkoDetail.DataSource = SyukkoDetail.Take(pageSize).ToList();

            // DataGridViewを更新
            dataGridViewSyukkoDetail.Refresh();
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
            int pageSize = int.Parse(textBoxPageSize.Text);
            int pageNo = int.Parse(textBoxPage.Text) - 2;
            dataGridViewSyukkoDetail.DataSource = SyukkoDetail.Skip(pageSize * pageNo).Take(pageSize).ToList();

            // DataGridViewを更新
            dataGridViewSyukkoDetail.Refresh();
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
            int pageSize = int.Parse(textBoxPageSize.Text);
            int pageNo = int.Parse(textBoxPage.Text);
            //最終ページの計算
            int lastNo = (int)Math.Ceiling(SyukkoDetail.Count / (double)pageSize) - 1;
            //最終ページでなければ
            if (pageNo <= lastNo)
                dataGridViewSyukkoDetail.DataSource = SyukkoDetail.Skip(pageSize * pageNo).Take(pageSize).ToList();

            // DataGridViewを更新
            dataGridViewSyukkoDetail.Refresh();
            //ページ番号の設定
            int lastPage = (int)Math.Ceiling(SyukkoDetail.Count / (double)pageSize);
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
            int pageSize = int.Parse(textBoxPageSize.Text);
            //最終ページの計算
            int pageNo = (int)Math.Ceiling(SyukkoDetail.Count / (double)pageSize) - 1;
            dataGridViewSyukkoDetail.DataSource = SyukkoDetail.Skip(pageSize * pageNo).Take(pageSize).ToList();

            // DataGridViewを更新
            dataGridViewSyukkoDetail.Refresh();
            //ページ番号の設定
            textBoxPage.Text = (pageNo + 1).ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClearInput();
        }

        

        
    }
}
