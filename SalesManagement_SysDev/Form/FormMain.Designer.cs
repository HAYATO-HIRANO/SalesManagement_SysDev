
namespace SalesManagement_SysDev
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelHeader = new System.Windows.Forms.Panel();
            this.labelPosition = new System.Windows.Forms.Label();
            this.labelUserName = new System.Windows.Forms.Label();
            this.labelDay = new System.Windows.Forms.Label();
            this.labelTime = new System.Windows.Forms.Label();
            this.buttonSaisyou = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonFormDel = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonLogout = new System.Windows.Forms.Button();
            this.buttonHinagata = new System.Windows.Forms.Button();
            this.buttonEigyou = new System.Windows.Forms.Button();
            this.buttonButuryu = new System.Windows.Forms.Button();
            this.buttonHonbu = new System.Windows.Forms.Button();
            this.userControl11 = new SalesManagement_SysDev.UserControlMain.UserControlHQ();
            this.userControl21 = new SalesManagement_SysDev.UserControlMain.UserControlSales();
            this.userControl31 = new SalesManagement_SysDev.UserControlMain.UserControlLogistics();
            this.panelHeader.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.DarkGreen;
            this.panelHeader.Controls.Add(this.labelPosition);
            this.panelHeader.Controls.Add(this.labelUserName);
            this.panelHeader.Controls.Add(this.labelDay);
            this.panelHeader.Controls.Add(this.labelTime);
            this.panelHeader.Controls.Add(this.buttonSaisyou);
            this.panelHeader.Controls.Add(this.label1);
            this.panelHeader.Controls.Add(this.buttonFormDel);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Margin = new System.Windows.Forms.Padding(2);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1920, 100);
            this.panelHeader.TabIndex = 1;
            // 
            // labelPosition
            // 
            this.labelPosition.AutoSize = true;
            this.labelPosition.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelPosition.ForeColor = System.Drawing.Color.White;
            this.labelPosition.Location = new System.Drawing.Point(914, 59);
            this.labelPosition.Name = "labelPosition";
            this.labelPosition.Size = new System.Drawing.Size(51, 16);
            this.labelPosition.TabIndex = 11;
            this.labelPosition.Text = "権限：";
            // 
            // labelUserName
            // 
            this.labelUserName.AutoSize = true;
            this.labelUserName.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelUserName.ForeColor = System.Drawing.Color.White;
            this.labelUserName.Location = new System.Drawing.Point(875, 21);
            this.labelUserName.Name = "labelUserName";
            this.labelUserName.Size = new System.Drawing.Size(90, 16);
            this.labelUserName.TabIndex = 10;
            this.labelUserName.Text = "ユーザー名：";
            // 
            // labelDay
            // 
            this.labelDay.AutoSize = true;
            this.labelDay.Font = new System.Drawing.Font("MS UI Gothic", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelDay.ForeColor = System.Drawing.Color.White;
            this.labelDay.Location = new System.Drawing.Point(1344, 2);
            this.labelDay.Name = "labelDay";
            this.labelDay.Size = new System.Drawing.Size(252, 35);
            this.labelDay.TabIndex = 9;
            this.labelDay.Text = "2022/10/10(月)";
            this.labelDay.Click += new System.EventHandler(this.labelDay_Click);
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.BackColor = System.Drawing.Color.DarkGreen;
            this.labelTime.Font = new System.Drawing.Font("MS UI Gothic", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelTime.ForeColor = System.Drawing.Color.White;
            this.labelTime.Location = new System.Drawing.Point(1384, 36);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(174, 64);
            this.labelTime.TabIndex = 8;
            this.labelTime.Text = "12:00";
            // 
            // buttonSaisyou
            // 
            this.buttonSaisyou.BackColor = System.Drawing.Color.DarkGreen;
            this.buttonSaisyou.Font = new System.Drawing.Font("MS UI Gothic", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonSaisyou.ForeColor = System.Drawing.Color.White;
            this.buttonSaisyou.Location = new System.Drawing.Point(1773, 0);
            this.buttonSaisyou.Name = "buttonSaisyou";
            this.buttonSaisyou.Size = new System.Drawing.Size(75, 75);
            this.buttonSaisyou.TabIndex = 7;
            this.buttonSaisyou.Text = "ー";
            this.buttonSaisyou.UseVisualStyleBackColor = false;
            this.buttonSaisyou.Click += new System.EventHandler(this.buttonSaisyou_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("HGSｺﾞｼｯｸE", 39.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(297, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(447, 53);
            this.label1.TabIndex = 1;
            this.label1.Text = "販売管理システム";
            // 
            // buttonFormDel
            // 
            this.buttonFormDel.BackColor = System.Drawing.Color.DarkGreen;
            this.buttonFormDel.Font = new System.Drawing.Font("MS UI Gothic", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonFormDel.ForeColor = System.Drawing.Color.White;
            this.buttonFormDel.Location = new System.Drawing.Point(1845, 0);
            this.buttonFormDel.Name = "buttonFormDel";
            this.buttonFormDel.Size = new System.Drawing.Size(75, 75);
            this.buttonFormDel.TabIndex = 0;
            this.buttonFormDel.Text = "✕";
            this.buttonFormDel.UseVisualStyleBackColor = false;
            this.buttonFormDel.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.panel2.Controls.Add(this.buttonLogout);
            this.panel2.Controls.Add(this.buttonHinagata);
            this.panel2.Controls.Add(this.buttonEigyou);
            this.panel2.Controls.Add(this.buttonButuryu);
            this.panel2.Controls.Add(this.buttonHonbu);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 100);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(250, 980);
            this.panel2.TabIndex = 2;
            // 
            // buttonLogout
            // 
            this.buttonLogout.BackColor = System.Drawing.Color.DarkGreen;
            this.buttonLogout.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonLogout.Font = new System.Drawing.Font("MS UI Gothic", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonLogout.ForeColor = System.Drawing.Color.White;
            this.buttonLogout.Location = new System.Drawing.Point(0, 900);
            this.buttonLogout.Name = "buttonLogout";
            this.buttonLogout.Size = new System.Drawing.Size(250, 80);
            this.buttonLogout.TabIndex = 4;
            this.buttonLogout.Text = "ログアウト";
            this.buttonLogout.UseVisualStyleBackColor = false;
            this.buttonLogout.Click += new System.EventHandler(this.buttonLogout_Click);
            // 
            // buttonHinagata
            // 
            this.buttonHinagata.Location = new System.Drawing.Point(29, 477);
            this.buttonHinagata.Name = "buttonHinagata";
            this.buttonHinagata.Size = new System.Drawing.Size(176, 86);
            this.buttonHinagata.TabIndex = 3;
            this.buttonHinagata.Text = "ひな形";
            this.buttonHinagata.UseVisualStyleBackColor = true;
            this.buttonHinagata.Click += new System.EventHandler(this.buttonHinagata_Click);
            // 
            // buttonEigyou
            // 
            this.buttonEigyou.BackColor = System.Drawing.Color.LightGreen;
            this.buttonEigyou.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEigyou.Font = new System.Drawing.Font("MS UI Gothic", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonEigyou.Location = new System.Drawing.Point(0, 129);
            this.buttonEigyou.Name = "buttonEigyou";
            this.buttonEigyou.Size = new System.Drawing.Size(250, 130);
            this.buttonEigyou.TabIndex = 2;
            this.buttonEigyou.Text = "営業";
            this.buttonEigyou.UseVisualStyleBackColor = false;
            this.buttonEigyou.Click += new System.EventHandler(this.buttonEigyou_Click);
            // 
            // buttonButuryu
            // 
            this.buttonButuryu.BackColor = System.Drawing.Color.LightGreen;
            this.buttonButuryu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonButuryu.Font = new System.Drawing.Font("MS UI Gothic", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonButuryu.Location = new System.Drawing.Point(0, 258);
            this.buttonButuryu.Name = "buttonButuryu";
            this.buttonButuryu.Size = new System.Drawing.Size(250, 130);
            this.buttonButuryu.TabIndex = 1;
            this.buttonButuryu.Text = "物流";
            this.buttonButuryu.UseVisualStyleBackColor = false;
            this.buttonButuryu.Click += new System.EventHandler(this.buttonButuryu_Click);
            // 
            // buttonHonbu
            // 
            this.buttonHonbu.BackColor = System.Drawing.Color.LightGreen;
            this.buttonHonbu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonHonbu.Font = new System.Drawing.Font("MS UI Gothic", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonHonbu.Location = new System.Drawing.Point(0, 0);
            this.buttonHonbu.Name = "buttonHonbu";
            this.buttonHonbu.Size = new System.Drawing.Size(250, 130);
            this.buttonHonbu.TabIndex = 0;
            this.buttonHonbu.Text = "本部";
            this.buttonHonbu.UseVisualStyleBackColor = false;
            this.buttonHonbu.Click += new System.EventHandler(this.buttonHonbu_Click);
            // 
            // userControl11
            // 
            this.userControl11.BackColor = System.Drawing.Color.Honeydew;
            this.userControl11.Location = new System.Drawing.Point(250, 100);
            this.userControl11.Name = "userControl11";
            this.userControl11.Size = new System.Drawing.Size(1670, 980);
            this.userControl11.TabIndex = 3;
            this.userControl11.Load += new System.EventHandler(this.userControl11_Load);
            // 
            // userControl21
            // 
            this.userControl21.BackColor = System.Drawing.Color.Honeydew;
            this.userControl21.Location = new System.Drawing.Point(250, 100);
            this.userControl21.Name = "userControl21";
            this.userControl21.Size = new System.Drawing.Size(1670, 980);
            this.userControl21.TabIndex = 4;
            // 
            // userControl31
            // 
            this.userControl31.BackColor = System.Drawing.Color.Honeydew;
            this.userControl31.Location = new System.Drawing.Point(250, 100);
            this.userControl31.Name = "userControl31";
            this.userControl31.Size = new System.Drawing.Size(1670, 980);
            this.userControl31.TabIndex = 5;
            // 
            // FormMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Honeydew;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.userControl11);
            this.Controls.Add(this.userControl21);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.userControl31);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormMain";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label labelPosition;
        private System.Windows.Forms.Label labelUserName;
        private System.Windows.Forms.Label labelDay;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.Button buttonSaisyou;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonFormDel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonEigyou;
        private System.Windows.Forms.Button buttonButuryu;
        private System.Windows.Forms.Button buttonHonbu;
        private UserControlMain.UserControlHQ userControl11;
        private UserControlMain.UserControlSales userControl21;
        private UserControlMain.UserControlLogistics userControl31;
        private System.Windows.Forms.Button buttonHinagata;
        private System.Windows.Forms.Button buttonLogout;
    }
}