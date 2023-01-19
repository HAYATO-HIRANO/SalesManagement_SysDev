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
        internal static string loginSoName = "";
        internal static string loginPoName = "";
        internal static int loginEmID = 0;
        //権限分割機能に使用
        internal static int loginPoID;
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
            //ログインユーザーの情報を表示
            labelUserName.Text = "ユーザー名：" + loginName;
            labelPosition.Text = "権限:" + loginPoName;
            labelSalesOffice.Text = loginSoName;
            labelUserID.Text = "ユーザーID：" + loginEmID.ToString();

            //機能分割
            //ログインしたユーザーが営業だった場合
            if (loginPoID == 2)
            {
                //本部無効化
                buttonHonbu.Enabled = false;
                buttonHonbu.BackColor = Color.Gray;
                //物流無効化
                buttonButuryu.Enabled = false;
                buttonButuryu.BackColor = Color.Gray;
            }
            //ログインしたユーザーが物流だった場合
            if (loginPoID == 3)
            {
                //本部無効化
                buttonHonbu.Enabled = false;
                buttonHonbu.BackColor = Color.Gray;
                //営業無効化
                buttonEigyou.Enabled = false;
                buttonEigyou.BackColor = Color.Gray;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("終了してよろしいですか？", "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
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

        private void timerDate_Tick(object sender, EventArgs e)
        {
            //日時更新
            labelDay.Text = DateTime.Now.ToString("yyyy/MM/dd/(ddd)");
            labelTime.Text = DateTime.Now.ToString("HH:mm");
        }

        private void FormMain_Activated(object sender, EventArgs e)
        {
            labelUserName.Text = "ユーザー名：" + loginName;
            labelPosition.Text = "権限:" + loginPoName;
            labelSalesOffice.Text = loginSoName;
            labelUserID.Text = "ユーザーID：" + loginEmID.ToString();
            //メインに戻ってきたときにLoginNameが""だったら画面を閉じる
            if(loginName == "")
            {
                this.Close();
                FormLogin formLogin = new FormLogin();
                formLogin.Show();
            }
        }
    }
}
