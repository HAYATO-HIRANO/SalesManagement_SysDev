
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonSeach = new System.Windows.Forms.Button();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.textBoxStID = new System.Windows.Forms.TextBox();
            this.textBoxStQuantity = new System.Windows.Forms.TextBox();
            this.textBoxPrID = new System.Windows.Forms.TextBox();
            this.checkBoxStFlag = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkGreen;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(1, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1141, 175);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(368, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(265, 60);
            this.label1.TabIndex = 1;
            this.label1.Text = "在庫管理";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(188, 306);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "在庫ID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(635, 306);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "在庫数";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(188, 391);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "商品ID";
            // 
            // buttonSeach
            // 
            this.buttonSeach.Location = new System.Drawing.Point(191, 193);
            this.buttonSeach.Name = "buttonSeach";
            this.buttonSeach.Size = new System.Drawing.Size(151, 78);
            this.buttonSeach.TabIndex = 8;
            this.buttonSeach.Text = "在庫検索機能";
            this.buttonSeach.UseVisualStyleBackColor = true;
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Location = new System.Drawing.Point(623, 193);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(143, 78);
            this.buttonUpdate.TabIndex = 9;
            this.buttonUpdate.Text = "在庫更新機能";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            // 
            // textBoxStID
            // 
            this.textBoxStID.Location = new System.Drawing.Point(282, 303);
            this.textBoxStID.Name = "textBoxStID";
            this.textBoxStID.Size = new System.Drawing.Size(140, 22);
            this.textBoxStID.TabIndex = 10;
            // 
            // textBoxStQuantity
            // 
            this.textBoxStQuantity.Location = new System.Drawing.Point(706, 303);
            this.textBoxStQuantity.Name = "textBoxStQuantity";
            this.textBoxStQuantity.Size = new System.Drawing.Size(126, 22);
            this.textBoxStQuantity.TabIndex = 11;
            // 
            // textBoxPrID
            // 
            this.textBoxPrID.Location = new System.Drawing.Point(282, 388);
            this.textBoxPrID.Name = "textBoxPrID";
            this.textBoxPrID.Size = new System.Drawing.Size(140, 22);
            this.textBoxPrID.TabIndex = 12;
            // 
            // checkBoxStFlag
            // 
            this.checkBoxStFlag.AutoSize = true;
            this.checkBoxStFlag.Location = new System.Drawing.Point(638, 391);
            this.checkBoxStFlag.Name = "checkBoxStFlag";
            this.checkBoxStFlag.Size = new System.Drawing.Size(121, 19);
            this.checkBoxStFlag.TabIndex = 13;
            this.checkBoxStFlag.Text = "在庫管理フラグ";
            this.checkBoxStFlag.UseVisualStyleBackColor = true;
            // 
            // FormStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1061, 525);
            this.Controls.Add(this.checkBoxStFlag);
            this.Controls.Add(this.textBoxPrID);
            this.Controls.Add(this.textBoxStQuantity);
            this.Controls.Add(this.textBoxStID);
            this.Controls.Add(this.buttonUpdate);
            this.Controls.Add(this.buttonSeach);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Name = "FormStock";
            this.Text = "FormStock";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonSeach;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.TextBox textBoxStID;
        private System.Windows.Forms.TextBox textBoxStQuantity;
        private System.Windows.Forms.TextBox textBoxPrID;
        private System.Windows.Forms.CheckBox checkBoxStFlag;
    }
}