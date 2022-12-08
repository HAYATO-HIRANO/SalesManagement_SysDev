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
        //MessageDsp messageDsp = new MessageDsp();
        //データベース顧客テーブルアクセス用クラスのインスタンス化
        ChumonDataAccess chumonDataAccess = new ChumonDataAccess();
        //データベース営業所テーブルアクセス用クラスのインスタンス化
        SalesOfficeDataAccess salesOfficeDataAccess = new SalesOfficeDataAccess();
        //入力形式チェック用クラスのインスタンス化
        DataInputFormCheck dataInputFormCheck = new DataInputFormCheck();
        //データグリッドビュー用の顧客データ
        private static List<M_ClientDsp> Client;
        //コンボボックス用の営業所データ
        private static List<M_SalesOffice> SalesOffice;
        //データグリッドビュー用の受注データ
        private static List<T_ChumonDsp> Chumon;

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

            SetFormComboBox();

            SetFormDataGridView();
        }

        ///////////////////////////////
        //メソッド名：SetFormComboBox()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：コンボボックスのデータ設定
        ///////////////////////////////
        private void SetFormComboBox()
        {
            //営業所データの取得
            SalesOffice = salesOfficeDataAccess.GetSalesOfficeDspData();
            comboBoxSoID.DataSource = SalesOffice;
            comboBoxSoID.DisplayMember = "SoName";
            comboBoxSoID.ValueMember = "SoID";
            //コンボボックスを読み取り専用
            comboBoxSoID.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxSoID.SelectedIndex = -1;
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
        ///////////////////////////////
        //メソッド名：GetDataGridView()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：データグリッドビューに表示するデータの取得
        ///////////////////////////////
        private void GetDataGridView()
        {
            // 受注データの取得
            Chumon = chumonDataAccess.GetChumonData();

            // DataGridViewに表示するデータを指定
            SetDataGridView();

        }

        private void SetDataGridView()
        {
            int pageSize = int.Parse(textBoxPageSize.Text);
            int pageNo = int.Parse(textBoxPage.Text) - 1;
            dataGridViewOrder.DataSource = Chumon.Skip(pageSize * pageNo).Take(pageSize).ToList();
            //各列幅の指定 //1510
            dataGridViewOrder.Columns[0].Width = 100;
            dataGridViewOrder.Columns[1].Width = 100;
            dataGridViewOrder.Columns[2].Visible = false;
            dataGridViewOrder.Columns[3].Width = 100;
            dataGridViewOrder.Columns[4].Width = 175;
            dataGridViewOrder.Columns[5].Width = 100;
            dataGridViewOrder.Columns[6].Width = 175;
            dataGridViewOrder.Columns[7].Width = 175;
            dataGridViewOrder.Columns[8].Width = 175;
            dataGridViewOrder.Columns[9].Visible = false;
            dataGridViewOrder.Columns[10].Visible = false;
            dataGridViewOrder.Columns[11].Width = 250;

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
            if(labelChumon.Text == "注文管理")
            {
                labelChumon.Text = "注文詳細管理";
                buttonChumonDetail.Text = "注文管理";
                userControlChumonDetail1.Visible = true;
                panelChumon.Visible = false;
                return;
            }
            if(labelChumon.Text == "注文詳細管理")
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
            return false;
        }


        private void buttonList_Click(object sender, EventArgs e)
        {

        }
    }





}
