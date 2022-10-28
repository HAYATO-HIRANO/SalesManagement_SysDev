﻿
namespace SalesManagement_SysDev
{
    partial class FormStock
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
            this.label = new System.Windows.Forms.Label();
            this.labelUserName = new System.Windows.Forms.Label();
            this.labelDay = new System.Windows.Forms.Label();
            this.labelTime = new System.Windows.Forms.Label();
            this.buttonSaisyou = new System.Windows.Forms.Button();
            this.labelClient = new System.Windows.Forms.Label();
            this.buttonFormDel = new System.Windows.Forms.Button();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.buttonLogout = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.buttonRegist = new System.Windows.Forms.Button();
            this.dataGridViewSt = new System.Windows.Forms.DataGridView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.labelStID = new System.Windows.Forms.Label();
            this.labelPrID = new System.Windows.Forms.Label();
            this.labelStQuantity = new System.Windows.Forms.Label();
            this.checkBoxStFlag = new System.Windows.Forms.CheckBox();
            this.textBoxStID = new System.Windows.Forms.TextBox();
            this.textBoxPrID = new System.Windows.Forms.TextBox();
            this.textBoxStQuantity = new System.Windows.Forms.TextBox();
            this.panelHeader.SuspendLayout();
            this.panelLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSt)).BeginInit();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.DarkGreen;
            this.panelHeader.Controls.Add(this.label);
            this.panelHeader.Controls.Add(this.labelUserName);
            this.panelHeader.Controls.Add(this.labelDay);
            this.panelHeader.Controls.Add(this.labelTime);
            this.panelHeader.Controls.Add(this.buttonSaisyou);
            this.panelHeader.Controls.Add(this.labelClient);
            this.panelHeader.Controls.Add(this.buttonFormDel);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Margin = new System.Windows.Forms.Padding(2);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1920, 100);
            this.panelHeader.TabIndex = 26;
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label.ForeColor = System.Drawing.Color.White;
            this.label.Location = new System.Drawing.Point(914, 59);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(51, 16);
            this.label.TabIndex = 11;
            this.label.Text = "権限：";
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
            // 
            // labelClient
            // 
            this.labelClient.AutoSize = true;
            this.labelClient.Font = new System.Drawing.Font("HGSｺﾞｼｯｸE", 39.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelClient.ForeColor = System.Drawing.Color.White;
            this.labelClient.Location = new System.Drawing.Point(297, 20);
            this.labelClient.Name = "labelClient";
            this.labelClient.Size = new System.Drawing.Size(235, 53);
            this.labelClient.TabIndex = 1;
            this.labelClient.Text = "在庫管理";
            this.labelClient.Click += new System.EventHandler(this.labelClient_Click);
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
            // 
            // panelLeft
            // 
            this.panelLeft.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.panelLeft.Controls.Add(this.buttonLogout);
            this.panelLeft.Controls.Add(this.button1);
            this.panelLeft.Controls.Add(this.buttonSearch);
            this.panelLeft.Controls.Add(this.buttonRegist);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 100);
            this.panelLeft.Margin = new System.Windows.Forms.Padding(2);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(250, 980);
            this.panelLeft.TabIndex = 27;
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
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LightGreen;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("MS UI Gothic", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button1.Location = new System.Drawing.Point(0, 129);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(250, 130);
            this.button1.TabIndex = 2;
            this.button1.Text = "更新";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // buttonSearch
            // 
            this.buttonSearch.BackColor = System.Drawing.Color.LightGreen;
            this.buttonSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSearch.Font = new System.Drawing.Font("MS UI Gothic", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonSearch.Location = new System.Drawing.Point(0, 258);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(250, 130);
            this.buttonSearch.TabIndex = 1;
            this.buttonSearch.Text = "検索";
            this.buttonSearch.UseVisualStyleBackColor = false;
            // 
            // buttonRegist
            // 
            this.buttonRegist.BackColor = System.Drawing.Color.LightGreen;
            this.buttonRegist.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRegist.Font = new System.Drawing.Font("MS UI Gothic", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonRegist.Location = new System.Drawing.Point(0, 0);
            this.buttonRegist.Name = "buttonRegist";
            this.buttonRegist.Size = new System.Drawing.Size(250, 130);
            this.buttonRegist.TabIndex = 0;
            this.buttonRegist.Text = "登録";
            this.buttonRegist.UseVisualStyleBackColor = false;
            // 
            // dataGridViewSt
            // 
            this.dataGridViewSt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSt.Location = new System.Drawing.Point(306, 411);
            this.dataGridViewSt.Name = "dataGridViewSt";
            this.dataGridViewSt.RowTemplate.Height = 21;
            this.dataGridViewSt.Size = new System.Drawing.Size(1549, 630);
            this.dataGridViewSt.TabIndex = 29;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.panel4.Controls.Add(this.textBoxStQuantity);
            this.panel4.Controls.Add(this.textBoxPrID);
            this.panel4.Controls.Add(this.textBoxStID);
            this.panel4.Controls.Add(this.checkBoxStFlag);
            this.panel4.Controls.Add(this.labelStQuantity);
            this.panel4.Controls.Add(this.labelPrID);
            this.panel4.Controls.Add(this.labelStID);
            this.panel4.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.panel4.Location = new System.Drawing.Point(306, 129);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1552, 230);
            this.panel4.TabIndex = 30;
            // 
            // labelStID
            // 
            this.labelStID.AutoSize = true;
            this.labelStID.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelStID.Location = new System.Drawing.Point(82, 111);
            this.labelStID.Name = "labelStID";
            this.labelStID.Size = new System.Drawing.Size(80, 24);
            this.labelStID.TabIndex = 0;
            this.labelStID.Text = "在庫ID";
            // 
            // labelPrID
            // 
            this.labelPrID.AutoSize = true;
            this.labelPrID.Location = new System.Drawing.Point(526, 111);
            this.labelPrID.Name = "labelPrID";
            this.labelPrID.Size = new System.Drawing.Size(80, 24);
            this.labelPrID.TabIndex = 1;
            this.labelPrID.Text = "商品ID";
            // 
            // labelStQuantity
            // 
            this.labelStQuantity.AutoSize = true;
            this.labelStQuantity.Location = new System.Drawing.Point(984, 111);
            this.labelStQuantity.Name = "labelStQuantity";
            this.labelStQuantity.Size = new System.Drawing.Size(82, 24);
            this.labelStQuantity.TabIndex = 2;
            this.labelStQuantity.Text = "在庫数";
            // 
            // checkBoxStFlag
            // 
            this.checkBoxStFlag.AutoSize = true;
            this.checkBoxStFlag.Location = new System.Drawing.Point(1342, 111);
            this.checkBoxStFlag.Name = "checkBoxStFlag";
            this.checkBoxStFlag.Size = new System.Drawing.Size(176, 28);
            this.checkBoxStFlag.TabIndex = 3;
            this.checkBoxStFlag.Text = "在庫管理フラグ";
            this.checkBoxStFlag.UseVisualStyleBackColor = true;
            // 
            // textBoxStID
            // 
            this.textBoxStID.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBoxStID.Location = new System.Drawing.Point(182, 108);
            this.textBoxStID.Name = "textBoxStID";
            this.textBoxStID.Size = new System.Drawing.Size(251, 28);
            this.textBoxStID.TabIndex = 4;
            // 
            // textBoxPrID
            // 
            this.textBoxPrID.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBoxPrID.Location = new System.Drawing.Point(625, 109);
            this.textBoxPrID.Name = "textBoxPrID";
            this.textBoxPrID.Size = new System.Drawing.Size(251, 28);
            this.textBoxPrID.TabIndex = 5;
            // 
            // textBoxStQuantity
            // 
            this.textBoxStQuantity.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBoxStQuantity.Location = new System.Drawing.Point(1089, 109);
            this.textBoxStQuantity.Name = "textBoxStQuantity";
            this.textBoxStQuantity.Size = new System.Drawing.Size(163, 28);
            this.textBoxStQuantity.TabIndex = 6;
            // 
            // FormStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.dataGridViewSt);
            this.Controls.Add(this.panelLeft);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FormStock";
            this.Text = "FormStock";
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSt)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Label labelUserName;
        private System.Windows.Forms.Label labelDay;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.Button buttonSaisyou;
        private System.Windows.Forms.Label labelClient;
        private System.Windows.Forms.Button buttonFormDel;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Button buttonLogout;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.Button buttonRegist;
        private System.Windows.Forms.DataGridView dataGridViewSt;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox textBoxStQuantity;
        private System.Windows.Forms.TextBox textBoxPrID;
        private System.Windows.Forms.TextBox textBoxStID;
        private System.Windows.Forms.CheckBox checkBoxStFlag;
        private System.Windows.Forms.Label labelStQuantity;
        private System.Windows.Forms.Label labelPrID;
        private System.Windows.Forms.Label labelStID;
    }
}