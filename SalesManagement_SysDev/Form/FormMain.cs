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
    public partial class FormMain : Form
    {

        //他のフォームから変数の内容を共有できるように宣言
        internal static string loginName = "";
        internal static string loginSo = "";
        internal static string loginPo = "";

        public FormMain()
        {
            InitializeComponent();
            userControl11.Visible = false;

        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            userControl11.Visible = false;
            userControl21.Visible = false;
            userControl31.Visible = false;
            //日時の表示
            labelDay.Text = DateTime.Now.ToString("yyyy/MM/dd/(ddd)");
            labelTime.Text = DateTime.Now.ToString("HH:mm");
            labelUserName.Text = "ユーザー名:" + loginName;
            labelPosition.Text = "権限:" + loginPo;
            labelSalesOffice.Text = loginSo;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }

        private void userControl11_Load(object sender, EventArgs e)
        {

        }

        private void buttonHonbu_Click(object sender, EventArgs e)
        {
            userControl21.Visible = false;
            userControl31.Visible = false;
            userControl11.Visible = true;
        }

        private void buttonHinagata_Click(object sender, EventArgs e)
        {
            FormHinagata form = new FormHinagata();
            form.Show();
        }

        private void buttonSaisyou_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void labelDay_Click(object sender, EventArgs e)
        {

        }

        private void buttonEigyou_Click(object sender, EventArgs e)
        {
            userControl21.Visible = true;
            userControl31.Visible = false;
            userControl11.Visible = false;
        }

        private void buttonButuryu_Click(object sender, EventArgs e)
        {
            userControl21.Visible = false;
            userControl31.Visible = true;
            userControl11.Visible = false;
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            FormLogin formLogin = new FormLogin();
            formLogin.Show();
            this.Visible = false;
        }

        private void labelUserName_Click(object sender, EventArgs e)
        {

        }

        private void labelPosition_Click(object sender, EventArgs e)
        {

        }
    }
}
