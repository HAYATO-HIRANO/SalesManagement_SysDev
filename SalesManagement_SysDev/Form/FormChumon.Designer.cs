
namespace SalesManagement_SysDev
{
    partial class FormChumon
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
            this.components = new System.ComponentModel.Container();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.labelUserID = new System.Windows.Forms.Label();
            this.labelPosition = new System.Windows.Forms.Label();
            this.labelSalesOffice = new System.Windows.Forms.Label();
            this.labelUserName = new System.Windows.Forms.Label();
            this.labelDay = new System.Windows.Forms.Label();
            this.labelTime = new System.Windows.Forms.Label();
            this.labelChumon = new System.Windows.Forms.Label();
            this.buttonFormDel = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonChumonDetail = new System.Windows.Forms.Button();
            this.buttonHiddenList = new System.Windows.Forms.Button();
            this.buttonList = new System.Windows.Forms.Button();
            this.buttonLogout = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.panelInput = new System.Windows.Forms.Panel();
            this.buttonClear = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.panelHeader.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panelInput.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.DarkGreen;
            this.panelHeader.Controls.Add(this.labelUserID);
            this.panelHeader.Controls.Add(this.labelPosition);
            this.panelHeader.Controls.Add(this.labelSalesOffice);
            this.panelHeader.Controls.Add(this.labelUserName);
            this.panelHeader.Controls.Add(this.labelDay);
            this.panelHeader.Controls.Add(this.labelTime);
            this.panelHeader.Controls.Add(this.labelChumon);
            this.panelHeader.Controls.Add(this.buttonFormDel);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Margin = new System.Windows.Forms.Padding(2);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1920, 100);
            this.panelHeader.TabIndex = 13;
            // 
            // labelUserID
            // 
            this.labelUserID.AutoSize = true;
            this.labelUserID.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelUserID.ForeColor = System.Drawing.Color.White;
            this.labelUserID.Location = new System.Drawing.Point(245, 14);
            this.labelUserID.Name = "labelUserID";
            this.labelUserID.Size = new System.Drawing.Size(146, 27);
            this.labelUserID.TabIndex = 13;
            this.labelUserID.Text = "ユーザーID：";
            // 
            // labelPosition
            // 
            this.labelPosition.AutoSize = true;
            this.labelPosition.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelPosition.ForeColor = System.Drawing.Color.White;
            this.labelPosition.Location = new System.Drawing.Point(12, 56);
            this.labelPosition.Name = "labelPosition";
            this.labelPosition.Size = new System.Drawing.Size(83, 27);
            this.labelPosition.TabIndex = 11;
            this.labelPosition.Text = "権限：";
            // 
            // labelSalesOffice
            // 
            this.labelSalesOffice.AutoSize = true;
            this.labelSalesOffice.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelSalesOffice.ForeColor = System.Drawing.Color.White;
            this.labelSalesOffice.Location = new System.Drawing.Point(12, 14);
            this.labelSalesOffice.Name = "labelSalesOffice";
            this.labelSalesOffice.Size = new System.Drawing.Size(180, 27);
            this.labelSalesOffice.TabIndex = 12;
            this.labelSalesOffice.Text = "和歌山営業所";
            // 
            // labelUserName
            // 
            this.labelUserName.AutoSize = true;
            this.labelUserName.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelUserName.ForeColor = System.Drawing.Color.White;
            this.labelUserName.Location = new System.Drawing.Point(245, 56);
            this.labelUserName.Name = "labelUserName";
            this.labelUserName.Size = new System.Drawing.Size(147, 27);
            this.labelUserName.TabIndex = 10;
            this.labelUserName.Text = "ユーザー名：";
            // 
            // labelDay
            // 
            this.labelDay.AutoSize = true;
            this.labelDay.Font = new System.Drawing.Font("MS UI Gothic", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelDay.ForeColor = System.Drawing.Color.White;
            this.labelDay.Location = new System.Drawing.Point(1382, 2);
            this.labelDay.Name = "labelDay";
            this.labelDay.Size = new System.Drawing.Size(252, 35);
            this.labelDay.TabIndex = 9;
            this.labelDay.Text = "2022/10/10(月)";
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.BackColor = System.Drawing.Color.DarkGreen;
            this.labelTime.Font = new System.Drawing.Font("MS UI Gothic", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelTime.ForeColor = System.Drawing.Color.White;
            this.labelTime.Location = new System.Drawing.Point(1422, 36);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(174, 64);
            this.labelTime.TabIndex = 8;
            this.labelTime.Text = "12:00";
            // 
            // labelChumon
            // 
            this.labelChumon.AutoSize = true;
            this.labelChumon.Font = new System.Drawing.Font("HGSｺﾞｼｯｸE", 39.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelChumon.ForeColor = System.Drawing.Color.White;
            this.labelChumon.Location = new System.Drawing.Point(694, 22);
            this.labelChumon.Name = "labelChumon";
            this.labelChumon.Size = new System.Drawing.Size(235, 53);
            this.labelChumon.TabIndex = 1;
            this.labelChumon.Text = "注文管理";
            // 
            // buttonFormDel
            // 
            this.buttonFormDel.BackColor = System.Drawing.Color.DarkGreen;
            this.buttonFormDel.Font = new System.Drawing.Font("MS UI Gothic", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonFormDel.ForeColor = System.Drawing.Color.White;
            this.buttonFormDel.Location = new System.Drawing.Point(1720, 0);
            this.buttonFormDel.Name = "buttonFormDel";
            this.buttonFormDel.Size = new System.Drawing.Size(200, 100);
            this.buttonFormDel.TabIndex = 0;
            this.buttonFormDel.Text = "✕閉じる";
            this.buttonFormDel.UseVisualStyleBackColor = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.panel2.Controls.Add(this.buttonChumonDetail);
            this.panel2.Controls.Add(this.buttonHiddenList);
            this.panel2.Controls.Add(this.buttonList);
            this.panel2.Controls.Add(this.buttonLogout);
            this.panel2.Controls.Add(this.button5);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 100);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(250, 980);
            this.panel2.TabIndex = 28;
            // 
            // buttonChumonDetail
            // 
            this.buttonChumonDetail.BackColor = System.Drawing.Color.LightGreen;
            this.buttonChumonDetail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonChumonDetail.Font = new System.Drawing.Font("MS UI Gothic", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonChumonDetail.Location = new System.Drawing.Point(0, 801);
            this.buttonChumonDetail.Name = "buttonChumonDetail";
            this.buttonChumonDetail.Size = new System.Drawing.Size(250, 100);
            this.buttonChumonDetail.TabIndex = 41;
            this.buttonChumonDetail.Text = "注文詳細";
            this.buttonChumonDetail.UseVisualStyleBackColor = false;
            // 
            // buttonHiddenList
            // 
            this.buttonHiddenList.BackColor = System.Drawing.Color.LightGreen;
            this.buttonHiddenList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonHiddenList.Font = new System.Drawing.Font("MS UI Gothic", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonHiddenList.Location = new System.Drawing.Point(0, 724);
            this.buttonHiddenList.Name = "buttonHiddenList";
            this.buttonHiddenList.Size = new System.Drawing.Size(250, 80);
            this.buttonHiddenList.TabIndex = 39;
            this.buttonHiddenList.Text = "非表示リスト";
            this.buttonHiddenList.UseVisualStyleBackColor = false;
            // 
            // buttonList
            // 
            this.buttonList.BackColor = System.Drawing.Color.LightGreen;
            this.buttonList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonList.Font = new System.Drawing.Font("MS UI Gothic", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonList.Location = new System.Drawing.Point(0, 129);
            this.buttonList.Name = "buttonList";
            this.buttonList.Size = new System.Drawing.Size(250, 130);
            this.buttonList.TabIndex = 38;
            this.buttonList.Text = "一覧表示";
            this.buttonList.UseVisualStyleBackColor = false;
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
            this.buttonLogout.TabIndex = 5;
            this.buttonLogout.Text = "ログアウト";
            this.buttonLogout.UseVisualStyleBackColor = false;
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.LightGreen;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("MS UI Gothic", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button5.Location = new System.Drawing.Point(0, 0);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(250, 130);
            this.button5.TabIndex = 1;
            this.button5.Text = "検索";
            this.button5.UseVisualStyleBackColor = false;
            // 
            // panelInput
            // 
            this.panelInput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.panelInput.Controls.Add(this.buttonClear);
            this.panelInput.Controls.Add(this.label4);
            this.panelInput.Location = new System.Drawing.Point(279, 125);
            this.panelInput.Name = "panelInput";
            this.panelInput.Size = new System.Drawing.Size(1616, 169);
            this.panelInput.TabIndex = 29;
            // 
            // buttonClear
            // 
            this.buttonClear.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonClear.Location = new System.Drawing.Point(1511, 136);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(102, 30);
            this.buttonClear.TabIndex = 28;
            this.buttonClear.Text = "入力クリア";
            this.buttonClear.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.label4.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label4.Location = new System.Drawing.Point(24, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 24);
            this.label4.TabIndex = 4;
            this.label4.Text = "label4";
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // FormChumon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Honeydew;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.panelInput);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormChumon";
            this.Text = "FormChumon";
            this.Load += new System.EventHandler(this.FormChumon_Load);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panelInput.ResumeLayout(false);
            this.panelInput.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label labelUserID;
        private System.Windows.Forms.Label labelPosition;
        private System.Windows.Forms.Label labelSalesOffice;
        private System.Windows.Forms.Label labelUserName;
        private System.Windows.Forms.Label labelDay;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.Label labelChumon;
        private System.Windows.Forms.Button buttonFormDel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonChumonDetail;
        private System.Windows.Forms.Button buttonHiddenList;
        private System.Windows.Forms.Button buttonList;
        private System.Windows.Forms.Button buttonLogout;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Panel panelInput;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Timer timer;
    }
}