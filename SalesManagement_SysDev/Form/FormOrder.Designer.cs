﻿
namespace SalesManagement_SysDev
{
    partial class FormOrder
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
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelDay = new System.Windows.Forms.Label();
            this.labelTime = new System.Windows.Forms.Label();
            this.buttonSaisyou = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonFormDel = new System.Windows.Forms.Button();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.buttonLogout = new System.Windows.Forms.Button();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.buttonRegist = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.labelOrID = new System.Windows.Forms.Label();
            this.textBoxOrID = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panelHeader.SuspendLayout();
            this.panelLeft.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.DarkGreen;
            this.panelHeader.Controls.Add(this.label3);
            this.panelHeader.Controls.Add(this.label2);
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
            this.panelHeader.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(914, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 16);
            this.label3.TabIndex = 11;
            this.label3.Text = "権限：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(875, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 16);
            this.label2.TabIndex = 10;
            this.label2.Text = "ユーザー名：";
            // 
            // labelDay
            // 
            this.labelDay.AutoSize = true;
            this.labelDay.Font = new System.Drawing.Font("MS UI Gothic", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelDay.ForeColor = System.Drawing.Color.White;
            this.labelDay.Location = new System.Drawing.Point(1350, 2);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("HGSｺﾞｼｯｸE", 39.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(297, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(235, 53);
            this.label1.TabIndex = 1;
            this.label1.Text = "受注管理";
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
            this.panelLeft.Controls.Add(this.buttonUpdate);
            this.panelLeft.Controls.Add(this.buttonSearch);
            this.panelLeft.Controls.Add(this.buttonRegist);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 100);
            this.panelLeft.Margin = new System.Windows.Forms.Padding(2);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(250, 980);
            this.panelLeft.TabIndex = 4;
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
            this.buttonLogout.TabIndex = 7;
            this.buttonLogout.Text = "ログアウト";
            this.buttonLogout.UseVisualStyleBackColor = false;
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.BackColor = System.Drawing.Color.LightGreen;
            this.buttonUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonUpdate.Font = new System.Drawing.Font("MS UI Gothic", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonUpdate.Location = new System.Drawing.Point(0, 129);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(250, 130);
            this.buttonUpdate.TabIndex = 2;
            this.buttonUpdate.Text = "更新";
            this.buttonUpdate.UseVisualStyleBackColor = false;
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
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.textBoxOrID);
            this.panel4.Controls.Add(this.labelOrID);
            this.panel4.Location = new System.Drawing.Point(311, 143);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1552, 169);
            this.panel4.TabIndex = 6;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(311, 385);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 21;
            this.dataGridView1.Size = new System.Drawing.Size(1552, 652);
            this.dataGridView1.TabIndex = 7;
            // 
            // labelOrID
            // 
            this.labelOrID.AutoSize = true;
            this.labelOrID.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelOrID.Location = new System.Drawing.Point(13, 15);
            this.labelOrID.Name = "labelOrID";
            this.labelOrID.Size = new System.Drawing.Size(80, 24);
            this.labelOrID.TabIndex = 0;
            this.labelOrID.Text = "受注ID";
            // 
            // textBoxOrID
            // 
            this.textBoxOrID.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBoxOrID.Location = new System.Drawing.Point(99, 13);
            this.textBoxOrID.Name = "textBoxOrID";
            this.textBoxOrID.Size = new System.Drawing.Size(84, 28);
            this.textBoxOrID.TabIndex = 1;
            this.textBoxOrID.Text = "123456";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label4.Location = new System.Drawing.Point(233, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 24);
            this.label4.TabIndex = 2;
            this.label4.Text = "受注ID";
            // 
            // FormOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Honeydew;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panelLeft);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormOrder";
            this.Load += new System.EventHandler(this.FormOrder_Load);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelLeft.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelDay;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.Button buttonSaisyou;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonFormDel;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Button buttonLogout;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.Button buttonRegist;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox textBoxOrID;
        private System.Windows.Forms.Label labelOrID;
        private System.Windows.Forms.Label label4;
    }
}