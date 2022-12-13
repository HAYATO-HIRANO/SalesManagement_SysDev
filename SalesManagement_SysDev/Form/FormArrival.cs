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
    public partial class FormArrival : Form
    {
        //データベース顧客テーブルアクセス用クラスのインスタンス化
        ClientDataAccess clientDataAccess = new ClientDataAccess();
        //データベース営業所テーブルアクセス用クラスのインスタンス化
        SalesOfficeDataAccess salesOfficeDataAccess = new SalesOfficeDataAccess();
        //入力形式チェック用クラスのインスタンス化
        DataInputFormCheck dataInputFormCheck = new DataInputFormCheck();
        //データグリッドビュー用の出庫データ
        private static List<T_SyukkoDsp> Syukko;
        //コンボボックス用の営業所データ
        private static List<M_SalesOffice> SalesOffice;

        public FormArrival()
        {
            InitializeComponent();
        }

        private void FormArrival_Load(object sender, EventArgs e)
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
            textBoxArHidden.TabStop = false;
            textBoxArHidden.ReadOnly = true;


            //データグリッドビューの設定
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
            dataGridViewAr.ReadOnly = true;
            //直接のサイズの変更を不可
            dataGridViewAr.AllowUserToResizeRows = false;
            dataGridViewAr.AllowUserToResizeColumns = false;
            //直接の登録を不可にする
            dataGridViewAr.AllowUserToAddRows = false;
            //行内をクリックすることで行を選択
            dataGridViewAr.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //奇数行の色を変更
            dataGridViewAr.AlternatingRowsDefaultCellStyle.BackColor = Color.Honeydew;
            //ヘッダー位置の指定
            dataGridViewAr.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //データグリッドビューのデータ取得
            //GetDataGridView();


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //日時更新
            labelDay.Text = DateTime.Now.ToString("yyyy/MM/dd/(ddd)");
            labelTime.Text = DateTime.Now.ToString("HH:mm");
        }
        private void buttonFormDel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonDetail_Click(object sender, EventArgs e)
        {
            if (labelArrival.Text == "入荷管理")
            {
                labelArrival.Text = "入荷詳細管理";
                buttonDetail.Text = "入荷管理";
                userControlArrivalDetail1.Visible = true;
                panelArrival.Visible = false;
                return;
            }
            if (labelArrival.Text == "入荷詳細管理")
            {
                labelArrival.Text = "入荷管理";
                buttonDetail.Text = "入荷詳細";
                panelArrival.Visible = true;
                userControlArrivalDetail1.Visible = false;  
                return;
            }
        }
    }
}
