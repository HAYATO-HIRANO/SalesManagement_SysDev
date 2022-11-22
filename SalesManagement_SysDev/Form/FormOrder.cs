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
    public partial class FormOrder : Form
    {
        public FormOrder()
        {
            InitializeComponent();
        }

        private void FormOrder_Load(object sender, EventArgs e)
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void buttonRegist_Click(object sender, EventArgs e)
        {

        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            //ボタン確定処理

        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {

        }

        private void buttonList_Click(object sender, EventArgs e)
        {

        }

        private void buttonSaisyou_Click(object sender, EventArgs e)
        {

        }

        private void buttonFormDel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            FormLogin formLogin = new FormLogin();
            FormMain formMain = new FormMain();
            formLogin.Show();
            this.Visible = false;
            formMain.Close();
        }

        private void textBoxPrName_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxPageSize_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonDetail_Click(object sender, EventArgs e)
        {
            if(buttonDetail.Text == "受注詳細")
            {
                labelOrder.Text = "受注詳細管理";
                buttonRegist.Enabled = false;
                buttonRegist.BackColor = Color.Gray;
                buttonUpdateKakutei.Enabled = false;
                buttonUpdateKakutei.BackColor = Color.Gray;
                buttonDetail.Text = "受注管理";
                return;
            }
            if (buttonDetail.Text == "受注管理")
            {
                labelOrder.Text = "受注管理";
                buttonRegist.Enabled = true;
                buttonRegist.BackColor = Color.White;
                buttonUpdateKakutei.Enabled = true;
                buttonUpdateKakutei.BackColor = Color.White;
                buttonDetail.Text = "受注詳細";
                return;
            }
            

        }

        private void panelInput_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBoxOrHidden_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBoxClFlag_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void DateTimePickerOrDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void labelOrDate_Click(object sender, EventArgs e)
        {

        }

        private void buttonPageSizeChange_Click(object sender, EventArgs e)
        {

        }

        private void labelPageSize_Click(object sender, EventArgs e)
        {

        }

        private void buttonLastPage_Click(object sender, EventArgs e)
        {

        }

        private void buttonNextPage_Click(object sender, EventArgs e)
        {

        }

        private void buttonPreviousPage_Click(object sender, EventArgs e)
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

        private void labelOrQuantity_Click(object sender, EventArgs e)
        {

        }

        private void textBoxOrQuantity_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelOrTotalPrice_Click(object sender, EventArgs e)
        {

        }

        private void checkBoxStateFlag_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //日時更新
            labelDay.Text = DateTime.Now.ToString("yyyy/MM/dd/(ddd)");
            labelTime.Text = DateTime.Now.ToString("HH:mm");
        }

        private void buttonHidden_Click(object sender, EventArgs e)
        {

        }

        private void labelClCharge_Click(object sender, EventArgs e)
        {

        }
    }
}
