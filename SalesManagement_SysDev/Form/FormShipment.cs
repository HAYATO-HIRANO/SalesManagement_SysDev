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
    }
}
