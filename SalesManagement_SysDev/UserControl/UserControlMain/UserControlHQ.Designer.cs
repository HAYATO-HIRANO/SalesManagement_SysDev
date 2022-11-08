
namespace SalesManagement_SysDev.UserControlMain
{
    partial class UserControlHQ
    {
        /// <summary> 
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region コンポーネント デザイナーで生成されたコード

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonEmployee = new System.Windows.Forms.Button();
            this.buttonClient = new System.Windows.Forms.Button();
            this.buttonSale = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonEmployee
            // 
            this.buttonEmployee.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.buttonEmployee.Font = new System.Drawing.Font("MS UI Gothic", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonEmployee.Location = new System.Drawing.Point(175, 104);
            this.buttonEmployee.Name = "buttonEmployee";
            this.buttonEmployee.Size = new System.Drawing.Size(1331, 206);
            this.buttonEmployee.TabIndex = 0;
            this.buttonEmployee.Text = "社員管理";
            this.buttonEmployee.UseVisualStyleBackColor = false;
            this.buttonEmployee.Click += new System.EventHandler(this.buttonEmployee_Click);
            // 
            // buttonClient
            // 
            this.buttonClient.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.buttonClient.Font = new System.Drawing.Font("MS UI Gothic", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonClient.Location = new System.Drawing.Point(175, 397);
            this.buttonClient.Name = "buttonClient";
            this.buttonClient.Size = new System.Drawing.Size(1331, 206);
            this.buttonClient.TabIndex = 1;
            this.buttonClient.Text = "顧客管理";
            this.buttonClient.UseVisualStyleBackColor = false;
            this.buttonClient.Click += new System.EventHandler(this.buttonClient_Click);
            // 
            // buttonSale
            // 
            this.buttonSale.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.buttonSale.Font = new System.Drawing.Font("MS UI Gothic", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonSale.Location = new System.Drawing.Point(175, 704);
            this.buttonSale.Name = "buttonSale";
            this.buttonSale.Size = new System.Drawing.Size(1331, 206);
            this.buttonSale.TabIndex = 2;
            this.buttonSale.Text = "売上管理";
            this.buttonSale.UseVisualStyleBackColor = false;
            this.buttonSale.Click += new System.EventHandler(this.buttonSale_Click);
            // 
            // UserControl1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Honeydew;
            this.Controls.Add(this.buttonSale);
            this.Controls.Add(this.buttonClient);
            this.Controls.Add(this.buttonEmployee);
            this.Name = "UserControl1";
            this.Size = new System.Drawing.Size(1670, 980);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonEmployee;
        private System.Windows.Forms.Button buttonClient;
        private System.Windows.Forms.Button buttonSale;
    }
}
