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
    public partial class FormShipment : Form
    {
        //メッセージ表示用クラスのインスタンス化
        MessageDsp messageDsp = new MessageDsp();
        //データベース注文テーブルアクセス用クラスのインスタンス化
        ShipmentDataAccess shipmentDataAccess = new ShipmentDataAccess();
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
        //データグリッドビュー用の出荷データ
        private static List<T_ShipmentDsp> Shipment;
        //データグリッドビュー用の社員データ
        private static List<M_EmployeeDsp> Employee;
        //コンボボックス用の営業所データ
        private static List<M_SalesOffice> SalesOffice;


        public FormShipment()
        {
            InitializeComponent();
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
            if(labelShipment.Text == "出荷管理")
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
            dataGridViewOrder.DataSource = Shipment.Take(pageSize).ToList();

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
            int lastNo = (int)Math.Ceiling(Shipment.Count / (double)pageSize) - 1;
            //最終ページでなければ
            if (pageNo <= lastNo)
                dataGridViewOrder.DataSource = Shipment.Skip(pageSize * pageNo).Take(pageSize).ToList();

            // DataGridViewを更新
            dataGridViewOrder.Refresh();
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
            int pageSize = int.Parse(textBoxPageSize.Text);
            //最終ページの計算
            int pageNo = (int)Math.Ceiling(Shipment.Count / (double)pageSize) - 1;
            dataGridViewOrder.DataSource = Shipment.Skip(pageSize * pageNo).Take(pageSize).ToList();

            // DataGridViewを更新
            dataGridViewOrder.Refresh();
            //ページ番号の設定
            textBoxPage.Text = (pageNo + 1).ToString();
        }

        //入力クリア
        private void buttonClear2_Click(object sender, EventArgs e)
        {
            ClearInput();
        }

        private void checkBox1Hidden_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1Hidden.Checked==true)
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

        //データグリッドビュー セルクリック
        private void dataGridViewOrder_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //データグリッドビューからクリックされたデータを各入力エリアへ
            textBoxShID.Text = dataGridViewOrder.Rows[dataGridViewOrder.CurrentRow.Index].Cells[0].ToString();
            textBoxOrID.Text = dataGridViewOrder.Rows[dataGridViewOrder.CurrentRow.Index].Cells[1].ToString();
            textBoxClID.Text = dataGridViewOrder.Rows[dataGridViewOrder.CurrentRow.Index].Cells[2].ToString();
            textBoxClName.Text = dataGridViewOrder.Rows[dataGridViewOrder.CurrentRow.Index].Cells[3].ToString();

            //flagの値の「0」「2」をbool型に変換してチェックボックスに表示させる
            if (dataGridViewOrder.Rows[dataGridViewOrder.CurrentRow.Index].Cells[8].Value.ToString() != 2.ToString())
            {
                 checkBox1Hidden.Checked = false;
            }
            else
            {
                checkBox1Hidden.Checked = true;
            }
            //非表示理由がnullではない場合テキストボックスに表示させる
            if (dataGridViewOrder.Rows[dataGridViewOrder.CurrentRow.Index].Cells[9].Value != null)
            {
                checkBox1Hidden.Text = dataGridViewOrder.Rows[dataGridViewOrder.CurrentRow.Index].Cells[9].Value.ToString();
            }
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
            dataGridViewOrder.DataSource = Shipment.Skip(pageSize * pageNo).Take(pageSize).ToList();
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
            labelPage.Text = "/" + ((int)Math.Ceiling(Shipment.Count / (double)pageSize)) + "ページ";

            dataGridViewOrder.Refresh();
        }
    }

}
