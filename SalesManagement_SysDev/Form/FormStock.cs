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
    public partial class FormStock : Form
    {
        public FormStock()
        {
            InitializeComponent();
        }

        private void labelClient_Click(object sender, EventArgs e)
        {
            
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

        private void FormStock_Load(object sender, EventArgs e)
        {
            //日時設定
            labelDay.Text = DateTime.Now.ToString("yyyy/MM/dd/(ddd)");
            labelTime.Text = DateTime.Now.ToString("HH:mm");
            //ログインユーザーの情報を表示
            labelUserName.Text = "ユーザー名：" + FormMain.loginName;
            labelPosition.Text = "権限:" + FormMain.loginPoName;
            labelSalesOffice.Text = FormMain.loginSoName;
            labelUserID.Text = "ユーザーID：" + FormMain.loginEmID.ToString();
        }
    }
}
