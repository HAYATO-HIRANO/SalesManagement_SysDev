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
    public partial class FormSyukko : Form
    {
        //データベース出庫テーブルアクセス用クラスのインスタンス化
        SyukkoDataAccess syukkoDataAccess = new SyukkoDataAccess();
        //データベース出庫詳細テーブルアクセス用クラスのインスタンス化
        SyukkoDetailDataAccess syukkoDetailDataAccess = new SyukkoDetailDataAccess();
        //データベース入荷テーブルアクセス用クラスのインスタンス化
        ArrivalDataAccess arrivalDataAccess = new ArrivalDataAccess();
        //データベース入荷詳細テーブルアクセス用クラスのインスタンス化
        ArrivalDetailDataAccess arrivalDetailDataAccess = new ArrivalDetailDataAccess();
        //データベース顧客テーブルアクセス用クラスのインスタンス化
        ClientDataAccess clientDataAccess = new ClientDataAccess();
        //入力形式チェック用クラスのインスタンス化
        DataInputFormCheck dataInputFormCheck = new DataInputFormCheck();
        //データグリッドビュー用の出庫データ
        private static List<T_SyukkoDsp> Syukko;
        private TSyukko tSyukko = new TSyukko();

        public FormSyukko()
        {
            InitializeComponent();
            userControlSyukkoDetail1.addTSyukko(tSyukko);
        }

        private void FormSyukko_Load(object sender, EventArgs e)
        {
            //日時の表示
            labelDay.Text = DateTime.Now.ToString("yyyy/MM/dd/(ddd)");
            labelTime.Text = DateTime.Now.ToString("HH:mm");
            //panelHeaderに表示するログインデータ
            labelUserName.Text = "ユーザー名：" + FormMain.loginName;
            labelPosition.Text = "権限:" + FormMain.loginPoName;
            labelSalesOffice.Text = FormMain.loginSoName;
            labelUserID.Text = "ユーザーID：" + FormMain.loginEmID.ToString();
            //非表示理由タブ選択不可、入力不可
            textBoxSyHidden.TabStop = false;
            textBoxSyHidden.ReadOnly = true;


            //データグリッドビューの設定
            SetFormDataGridView();

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
            textBoxOrID.Text = "";
            textBoxClID.Text = "";
            textBoxClName.Text = "";
            checkBox1Hidden.Checked = false;
            checkBoxStateFlag.Checked = false;
            textBoxSyHidden.Text = "";
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
            dataGridViewSyukko.ReadOnly = true;
            //直接のサイズの変更を不可
            dataGridViewSyukko.AllowUserToResizeRows = false;
            dataGridViewSyukko.AllowUserToResizeColumns = false;
            //直接の登録を不可にする
            dataGridViewSyukko.AllowUserToAddRows = false;
            //行内をクリックすることで行を選択
            dataGridViewSyukko.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //奇数行の色を変更
            dataGridViewSyukko.AlternatingRowsDefaultCellStyle.BackColor = Color.Honeydew;
            //ヘッダー位置の指定
            dataGridViewSyukko.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

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
            Syukko = syukkoDataAccess.GetSyukkoData();

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
            // 受注データの取得
            Syukko = syukkoDataAccess.GetSyukkoHiddenData();

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
            dataGridViewSyukko.DataSource = Syukko.Skip(pageSize * pageNo).Take(pageSize).ToList();
            //各列幅の指定 //1510
            dataGridViewSyukko.Columns[0].Width = 100;
            dataGridViewSyukko.Columns[1].Width = 100;
            dataGridViewSyukko.Columns[2].Width = 100;
            dataGridViewSyukko.Columns[3].Width = 100;
            dataGridViewSyukko.Columns[4].Width = 200;
            dataGridViewSyukko.Columns[5].Width = 100;
            dataGridViewSyukko.Columns[6].Width = 200;
            dataGridViewSyukko.Columns[7].Width = 175;
            dataGridViewSyukko.Columns[8].Width = 200;
            dataGridViewSyukko.Columns[9].Visible = false;
            dataGridViewSyukko.Columns[10].Visible = false;
            dataGridViewSyukko.Columns[11].Width = 250;

            //各列の文字位置の指定
            dataGridViewSyukko.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewSyukko.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewSyukko.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewSyukko.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewSyukko.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewSyukko.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewSyukko.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewSyukko.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewSyukko.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            //dataGridViewの総ページ数
            labelPage.Text = "/" + ((int)Math.Ceiling(Syukko.Count / (double)pageSize)) + "ページ";

            dataGridViewSyukko.Refresh();
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
            if (labelSyukko.Text == "出庫管理")
            {
                if (!String.IsNullOrEmpty(textBoxSyID.Text.Trim()))
                {
                    tSyukko.SyID = int.Parse(textBoxSyID.Text.Trim());
                    userControlSyukkoDetail1.addTSyukko(tSyukko);
                }

                labelSyukko.Text = "出庫詳細管理";
                buttonDetail.Text = "出庫管理";
                userControlSyukkoDetail1.Visible = true;
                panelSyukko.Visible = false;
                return;
            }
            if (labelSyukko.Text == "出庫詳細管理")
            {
                labelSyukko.Text = "出庫管理";
                buttonDetail.Text = "出庫詳細";
                panelSyukko.Visible = true;
                userControlSyukkoDetail1.Visible = false;
                return;
            }
        }
        //////12.1.1.1 一覧表示//////
        private void buttonList_Click(object sender, EventArgs e)
        {
            ClearInput();
            GetDataGridView();

        }
        //12.1.2 出庫確定機能
        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            // 12.1.2.1 妥当な出庫データ取得
            if (!GetValidDataAtConfirm())
                return;
            // 12.1.2.2　入荷情報作成
            var conArrival = GenerateDataAtConfirm();
            // 12.1.2.3 入荷詳細情報作成
            var conArrivalDetail = GenerateDetailDataAtConfirm();

            // 12.1.2.4 出庫情報確定
            ConfirmSyukko(conArrival, conArrivalDetail);

        }
        ///////////////////////////////
        //  12.1.2.1 妥当な出庫データ取得
        //メソッド名：GetValidDataAtConfirm()
        //引　数   ：なし
        //戻り値   ：true or false
        //機　能   ：入力データの形式チェック
        //          ：エラーがない場合True
        //          ：エラーがある場合False
        ///////////////////////////////
        private bool GetValidDataAtConfirm()
        {
            //出庫IDの適否
            if (!String.IsNullOrEmpty(textBoxSyID.Text.Trim()))
            {
                //文字チェック
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
            else
            {
                MessageBox.Show("出庫ID が入力されていません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxSyID.Focus();
                return false;
            }
            //出庫確定状態の判定
            var syukko = syukkoDataAccess.GetSyIDData(int.Parse(textBoxSyID.Text.Trim()));
            if (syukko.SyStateFlag == 1)
            {
                MessageBox.Show("入力された出庫IDはすでに確定されています", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxSyID.Focus();
                return false;

            }
            //出庫状態フラグ
            if (checkBoxStateFlag.CheckState == CheckState.Indeterminate)
            {
                MessageBox.Show("出庫確定が不確定な状態です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                checkBoxStateFlag.Focus();
                return false;
            }
            if (checkBoxStateFlag.Checked == false)
            {
                MessageBox.Show("出庫確定がチェックされていません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                checkBoxStateFlag.Focus();
                return false;
            }
            //詳細情報の件数チェック
            var syukkoDetail = syukkoDetailDataAccess.GetSyIDDetailData(int.Parse(textBoxSyID.Text.Trim()));
            if (syukkoDetail.Count == 0)
            {
                MessageBox.Show("詳細情報が登録されていません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;

            }
            return true;
        }
        ///////////////////////////////
        //　12.1.2.2　入荷情報作成
        //メソッド名：GenerateDataAtConfirm()
        //引　数   ：なし
        //戻り値   ：出庫確定情報
        //機　能   ：確定データのセット
        ///////////////////////////////
        private T_Arrival GenerateDataAtConfirm()
        {
            T_Syukko syukko = syukkoDataAccess.GetSyIDData(int.Parse(textBoxSyID.Text.Trim()));

            return new T_Arrival
            {
                
                OrID = int.Parse(syukko.OrID.ToString()),
                EmID = int.Parse(syukko.EmID.ToString()),
                SoID = int.Parse(syukko.SoID.ToString()),
                ClID = int.Parse(syukko.ClID.ToString()),
                ArDate = null,
                ArStateFlag = 0,
                ArFlag = 0,
                ArHidden = String.Empty
            };


        }
        ///////////////////////////////
        //　12.1.2.3 入庫詳細情報作成
        //メソッド名：GenerateDetailDataAtConfirm()
        //引　数   ：なし
        //戻り値   ：出庫詳細確定情報
        //機　能   ：確定データのセット
        ///////////////////////////////
        private List<T_ArrivalDetail> GenerateDetailDataAtConfirm()
        {
            List<T_SyukkoDetail> syukkoDetail = syukkoDetailDataAccess.GetSyIDDetailData(int.Parse(textBoxSyID.Text.Trim()));

            List<T_ArrivalDetail> arrivalDetail = new List<T_ArrivalDetail>();
            foreach (var p in syukkoDetail)
            {
                arrivalDetail.Add(new T_ArrivalDetail()
                {
                     
                    PrID = p.PrID,
                    ArQuantity = p.SyQuantity
                });
            }
            return arrivalDetail;


        }

        ///////////////////////////////
        //　12.1.2.4 出庫情報確定
        //メソッド名：ConfirmSyukko()
        //引　数   ：入荷情報,入荷詳細情報
        //戻り値   ：なし
        //機　能   ：出庫情報の確定
        ///////////////////////////////
        private void ConfirmSyukko(T_Arrival conArrival, List<T_ArrivalDetail> conArrivalDetail)
        {
            // 確定確認メッセージ
            DialogResult result = MessageBox.Show("データを確定してよろしいですか?", "確定確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (result == DialogResult.Cancel)
                return;

            // 出庫情報の確定
            //入荷テーブルにデータ登録
            bool addFlg = arrivalDataAccess.AddArrivalData(conArrival);
            //入荷IDの取得
            T_Syukko  syukko = syukkoDataAccess.GetSyIDData(int.Parse(textBoxSyID.Text.Trim()));
            T_Arrival arrival = arrivalDataAccess.GetOrIDData(syukko.OrID);
            //入荷詳細テーブルにデータ登録/
            ///成功か失敗の判定は未完成
            foreach (var p in conArrivalDetail)
            {
                T_ArrivalDetail AddAr = new T_ArrivalDetail();
                AddAr.ArID = arrival.ArID;
                AddAr.PrID = p.PrID;
                AddAr.ArQuantity = p.ArQuantity;
                arrivalDetailDataAccess.AddArDetailData(AddAr);
            }
            //出庫状態フラグの更新
            bool conFlg = syukkoDataAccess.UpdateStateFlag(int.Parse(textBoxSyID.Text.Trim()));
            //全ての登録,更新が成功
            if (addFlg == true && conFlg == true)
            {

                MessageBox.Show("データを確定しました", "追加確認", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("データの確定に失敗しました", "追加確認", MessageBoxButtons.OK, MessageBoxIcon.Error);

            textBoxSyID.Focus();

            // 入力エリアのクリア
            ClearInput();

            // データグリッドビューの表示
            GetDataGridView();

        }

        ///////////////////////////////
        //メソッド名：buttonFirstPage_Click()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：データグリッドビューの先頭ページ表示
        ///////////////////////////////

        private void buttonFirstPage_Click(object sender, EventArgs e)
        {
            int pageSize = int.Parse(textBoxPageSize.Text);
            dataGridViewSyukko.DataSource = Syukko.Take(pageSize).ToList();

            // DataGridViewを更新
            dataGridViewSyukko.Refresh();
            //ページ番号の設定
            textBoxPage.Text = "1";

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
        //メソッド名：buttonPreviousPage_Click()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：データグリッドビューの前ページ表示
        ///////////////////////////////


        private void buttonPreviousPage_Click(object sender, EventArgs e)
        {
            int pageSize = int.Parse(textBoxPageSize.Text);
            int pageNo = int.Parse(textBoxPage.Text) - 2;
            dataGridViewSyukko.DataSource = Syukko.Skip(pageSize * pageNo).Take(pageSize).ToList();

            // DataGridViewを更新
            dataGridViewSyukko.Refresh();
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
            int lastNo = (int)Math.Ceiling(Syukko.Count / (double)pageSize) - 1;
            //最終ページでなければ
            if (pageNo <= lastNo)
                dataGridViewSyukko.DataSource = Syukko.Skip(pageSize * pageNo).Take(pageSize).ToList();

            // DataGridViewを更新
            dataGridViewSyukko.Refresh();
            //ページ番号の設定
            int lastPage = (int)Math.Ceiling(Syukko.Count / (double)pageSize);
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
            int pageNo = (int)Math.Ceiling(Syukko.Count / (double)pageSize) - 1;
            dataGridViewSyukko.DataSource = Syukko.Skip(pageSize * pageNo).Take(pageSize).ToList();

            // DataGridViewを更新
            dataGridViewSyukko.Refresh();
            //ページ番号の設定
            textBoxPage.Text = (pageNo + 1).ToString();

        }
        //////入力クリア///////
        private void buttonClear2_Click(object sender, EventArgs e)
        {
            ClearInput();
        }
        //12.1.3 非表示機能
        private void buttonHidden_Click(object sender, EventArgs e)
        {
            // 12.1.3.1 妥当な出庫データ取得
            if (!GetValidDataAtHidden())
                return;

            // 12.1.3.2　出庫情報作成
            var hidSyukko = GenerateDataAtHidden();

            // 12.1.3.3 出庫情報非表示
            HiddenSyukko(hidSyukko);

        }
        ///////////////////////////////
        //  12.1.3.1 妥当な受注データ取得
        //メソッド名：GetValidDataAtHidden()
        //引　数   ：なし
        //戻り値   ：true or false
        //機　能   ：入力データの形式チェック
        //          ：エラーがない場合True
        //          ：エラーがある場合False
        ///////////////////////////////
        private bool GetValidDataAtHidden()
        {
            //出庫IDの適否
            if (!String.IsNullOrEmpty(textBoxSyID.Text.Trim()))
            {
                //文字チェック
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
            else
            {
                MessageBox.Show("出庫ID が入力されていません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxSyID.Focus();
                return false;
            }
            //非表示フラグの適否
            if (checkBox1Hidden.Checked == false)
            {
                MessageBox.Show("非表示理由が入力されていません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                checkBox1Hidden.Checked = true;
                textBoxSyHidden.Focus();
                return false;

            }
            //非表示理由の適否
            if (checkBox1Hidden.Checked == true && String.IsNullOrEmpty(textBoxSyHidden.Text.Trim()))
            {
                MessageBox.Show("非表示理由が入力されていません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxSyHidden.Focus();
                return false;
            }

            return true;
        }
        ///////////////////////////////
        //　12.1.3.2 出庫情報作成
        //メソッド名：GenerateDataAtHidden()
        //引　数   ：なし
        //戻り値   ：出庫非表示情報
        //機　能   ：非表示データのセット
        ///////////////////////////////
        private T_Syukko GenerateDataAtHidden()
        {
            int hidFlag = 0;
            if (checkBox1Hidden.Checked == true)
            {
                hidFlag = 2;
            }

            return new T_Syukko
            {
                SyID = int.Parse(textBoxSyID.Text.Trim()),
                SyFlag = hidFlag,
                SyHidden = textBoxSyHidden.Text.Trim()
            };
        }
        ///////////////////////////////
        //　12.1.3.3 出庫情報非表示
        //メソッド名：HiddenSyukko()
        //引　数   ：出庫情報
        //戻り値   ：なし
        //機　能   ：出庫情報の非表示
        ///////////////////////////////
        private void HiddenSyukko(T_Syukko hidSyukko)
        {
            // 非表示確認メッセージ
            DialogResult result = MessageBox.Show("データを非表示にしてよろしいですか?", "非表示確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (result == DialogResult.Cancel)
                return;

            // 出庫情報の非表示(フラグの更新)
            bool flg = syukkoDataAccess.UpdateHiddenFlag(hidSyukko);
            if (flg == true)
                MessageBox.Show("データを非表示にしました", "非表示確認", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("データの非表示に失敗しました", "非表示確認", MessageBoxButtons.OK, MessageBoxIcon.Error);

            textBoxSyID.Focus();

            // 入力エリアのクリア
            ClearInput();

            // データグリッドビューの表示
            GetDataGridView();
        }

        //12.1.4 非表示リスト表示機能
        private void buttonHiddenList_Click(object sender, EventArgs e)
        {
            ClearInput();

            GetHiddenDataGridView();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {

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
    }
}
