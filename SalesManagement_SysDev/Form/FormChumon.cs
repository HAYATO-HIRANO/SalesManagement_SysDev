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
    public partial class FormChumon : Form
    {
        //メッセージ表示用クラスのインスタンス化
        MessageDsp messageDsp = new MessageDsp();
        //データベース注文テーブルアクセス用クラスのインスタンス化
        ChumonDataAccess chumonDataAccess = new ChumonDataAccess();
        //データベース受注テーブルアクセス用クラスのインスタンス化
        OrderDataAccess orderDataAccess = new OrderDataAccess();
        //データベース社員テーブルアクセス用クラスのインスタンス化
        EmployeeDataAccess employeeDataAccess = new EmployeeDataAccess();
        //データベース営業所テーブルアクセス用クラスのインスタンス化
        SalesOfficeDataAccess salesOfficeDataAccess = new SalesOfficeDataAccess();
        //入力形式チェック用クラスのインスタンス化
        DataInputFormCheck dataInputFormCheck = new DataInputFormCheck();
        //データベース顧客テーブルアクセス用クラスのインスタンス化
        ClientDataAccess clientDataAccess = new ClientDataAccess();
        //データグリッドビュー用の注文データ
        private static List<T_ChumonDsp> Chumon;
        //データグリッドビュー用の社員データ
        private static List<M_EmployeeDsp> Employee;
        //コンボボックス用の営業所データ
        private static List<M_SalesOffice> SalesOffice;


        public FormChumon()
        {
            InitializeComponent();
        }

        private void FormChumon_Load(object sender, EventArgs e)
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
            textBoxChHidden.TabStop = false;
            textBoxChHidden.ReadOnly = true;

            SetFormDataGridView();
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
            dataGridViewOrder.ReadOnly = true;
            //直接のサイズの変更を不可
            dataGridViewOrder.AllowUserToResizeRows = false;
            dataGridViewOrder.AllowUserToResizeColumns = false;
            //直接の登録を不可にする
            dataGridViewOrder.AllowUserToAddRows = false;
            //行内をクリックすることで行を選択
            dataGridViewOrder.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //奇数行の色を変更
            dataGridViewOrder.AlternatingRowsDefaultCellStyle.BackColor = Color.Honeydew;
            //ヘッダー位置の指定
            dataGridViewOrder.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //データグリッドビューのデータ取得
            GetDataGridView();

        }
   

        private void SetDataGridView()
        {
            int pageSize = int.Parse(textBoxPageSize.Text);
            int pageNo = int.Parse(textBoxPage.Text) - 1;
            dataGridViewOrder.DataSource = Chumon.Skip(pageSize * pageNo).Take(pageSize).ToList();
            //各列幅の指定 //1475
            dataGridViewOrder.Columns[0].Width = 100;
            dataGridViewOrder.Columns[1].Width = 100;
            dataGridViewOrder.Columns[2].Visible = false;
            dataGridViewOrder.Columns[3].Width = 100;
            dataGridViewOrder.Columns[4].Width = 100;
            dataGridViewOrder.Columns[5].Width = 150;
            dataGridViewOrder.Columns[6].Width = 100;
            dataGridViewOrder.Columns[7].Width = 200;
            dataGridViewOrder.Columns[8].Width = 200;
            dataGridViewOrder.Columns[9].Visible = false;
            dataGridViewOrder.Columns[10].Visible = false;
            dataGridViewOrder.Columns[11].Width = 460;

            //各列の文字位置の指定
            dataGridViewOrder.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewOrder.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewOrder.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewOrder.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewOrder.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewOrder.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewOrder.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewOrder.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewOrder.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewOrder.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewOrder.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewOrder.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            //dataGridViewの総ページ数
            labelPage.Text = "/" + ((int)Math.Ceiling(Chumon.Count / (double)pageSize)) + "ページ";

            dataGridViewOrder.Refresh();
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

        private void buttonChumonDetail_Click(object sender, EventArgs e)
        {
            if (labelChumon.Text == "注文管理")
            {
                labelChumon.Text = "注文詳細管理";
                buttonChumonDetail.Text = "注文管理";
                userControlChumonDetail1.Visible = true;
                panelChumon.Visible = false;
                return;
            }
            if (labelChumon.Text == "注文詳細管理")
            {
                labelChumon.Text = "注文管理";
                buttonChumonDetail.Text = "注文詳細";
                panelChumon.Visible = true;
                userControlChumonDetail1.Visible = false;
                return;
            }
        }



        ////////注文情報検索///////////
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            //妥当な注文データ取得
            if (!GetValidDataAtSelect())
                return;

            // 8.3.4.2 注文情報抽出
            GenerateDataAtSelect();

            // 8.3.4.3 注文抽出結果表示
            SetSelectData();
        }

        ///////////////////////////////
        //　＊.*.*.* 妥当な注文データ取得
        //メソッド名：GetValidDataAtSlect()
        //引　数   ：なし
        //戻り値   ：true or false
        //機　能   ：入力データの形式チェック
        //          ：エラーがない場合True
        //          ：エラーがある場合False
        ///////////////////////////////
        private bool GetValidDataAtSelect()
        {
            //注文IDの適否
            if (!String.IsNullOrEmpty(textBoxChID.Text.Trim()))
            {
                //文字チェック
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
            }
            //受注IDの適否
            if (!String.IsNullOrEmpty(textBoxOrID.Text.Trim()))
            {
                //文字チェック
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
            if (checkBoxHidden.CheckState == CheckState.Indeterminate)
            {
                MessageBox.Show("非表示理由が不確定な状態です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                checkBoxHidden.Focus();
                return false;
            }

            return true;
        }
        ///////////////////////////////
        //　8.3.4.2 注文情報抽出
        //メソッド名：GenerateDataAtSelect()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：注文データの取得
        ///////////////////////////////
        private void GenerateDataAtSelect()
        {

        }
        ///////////////////////////////
        //　8.3.4.3 注文抽出結果表示
        //メソッド名：SetSelectData()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：注文情報の表示
        ///////////////////////////////
        private void SetSelectData()
        {

        }
        ///////////////////////////////
        //メソッド名：buttonList_Click()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：注文データの一覧表示機能
        ///////////////////////////////

        private void buttonList_Click(object sender, EventArgs e)
        {
            // 入力エリアのクリア
            ClearInput();

            GetDataGridView();
        }


        ///////////////////////////////
        //メソッド名：buttonNotList_Click()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：注文データの非表示一覧表示機能
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
            DateTimePickerChDate.Checked = false;
            textBoxChID.Text = "";
            textBoxOrID.Text = "";
            textBoxEmID.Text = "";
            textBoxClID.Text = "";
            textBoxClName.Text = "";
            DateTimePickerChDate.Text = "";
            checkBoxStateFlag.Checked = false;
            textBoxChHidden.Text = "";
            checkBoxStateFlag.Checked = false;
        }

        ///////////////////////////////
        //メソッド名：GetDataGridView()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：データグリッドビューに表示するデータの取得
        ///////////////////////////////
        private void GetDataGridView()
        {
            //注文データの取得
            Chumon = chumonDataAccess.GetChumonData();
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
            //注文データの取得
            Chumon = chumonDataAccess.GetChumonData();
            // DataGridViewに表示するデータを指定
            SetDataGridView();
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
            dataGridViewOrder.DataSource = Chumon.Take(pageSize).ToList();

            // DataGridViewを更新
            dataGridViewOrder.Refresh();
            //ページ番号の設定
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
            int lastNo = (int)Math.Ceiling(Chumon.Count / (double)pageSize) - 1;
            //最終ページでなければ
            if (pageNo <= lastNo)
                dataGridViewOrder.DataSource = Chumon.Skip(pageSize * pageNo).Take(pageSize).ToList();

            // DataGridViewを更新
            dataGridViewOrder.Refresh();
            //ページ番号の設定
            int lastPage = (int)Math.Ceiling(Chumon.Count / (double)pageSize);
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
            int pageNo = (int)Math.Ceiling(Chumon.Count / (double)pageSize) - 1;
            dataGridViewOrder.DataSource = Chumon.Skip(pageSize * pageNo).Take(pageSize).ToList();

            // DataGridViewを更新
            dataGridViewOrder.Refresh();
            //ページ番号の設定
            textBoxPage.Text = (pageNo + 1).ToString();
        }


        //入力クリア
        private void buttonClear_Click(object sender, EventArgs e)
        {
            ClearInput();
        }

        private void checkBoxHidden_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBoxHidden.Checked==true)
            {
                textBoxChHidden.TabStop = true;
                textBoxChHidden.ReadOnly = false;
            }
            else
            {
                textBoxChHidden.Text="";
                textBoxChHidden.TabStop = false;
                textBoxChHidden.ReadOnly = true;
            }
        }


        //データグリッドビュー セルクリック
        private void dataGridViewOrder_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //データグリッドビューからクリックされたデータを各入力エリアへ
            textBoxChID.Text = dataGridViewOrder.Rows[dataGridViewOrder.CurrentRow.Index].Cells[0].Value.ToString();
            textBoxOrID.Text = dataGridViewOrder.Rows[dataGridViewOrder.CurrentRow.Index].Cells[1].Value.ToString();
            comboBoxSoID.Text = dataGridViewOrder.Rows[dataGridViewOrder.CurrentRow.Index].Cells[2].Value.ToString();
            textBoxEmID.Text = dataGridViewOrder.Rows[dataGridViewOrder.CurrentRow.Index].Cells[3].Value.ToString();
            textBoxClID.Text = dataGridViewOrder.Rows[dataGridViewOrder.CurrentRow.Index].Cells[4].Value.ToString();
            textBoxClName.Text = dataGridViewOrder.Rows[dataGridViewOrder.CurrentRow.Index].Cells[5].Value.ToString();
            DateTimePickerChDate.Text= dataGridViewOrder.Rows[dataGridViewOrder.CurrentRow.Index].Cells[6].Value.ToString();
            //flagの値の「0」「2」をbool型に変換してチェックボックスに表示させる
            if (dataGridViewOrder.Rows[dataGridViewOrder.CurrentRow.Index].Cells[8].Value.ToString() != 2.ToString())
            {
                checkBoxHidden.Checked = false;
            }
            else
            {
                checkBoxHidden.Checked = true;
            }
            //非表示理由がnullではない場合テキストボックスに表示させる
            if (dataGridViewOrder.Rows[dataGridViewOrder.CurrentRow.Index].Cells[9].Value != null)
            {
                checkBoxHidden.Text = dataGridViewOrder.Rows[dataGridViewOrder.CurrentRow.Index].Cells[9].Value.ToString();
            }


        }


    }
}

