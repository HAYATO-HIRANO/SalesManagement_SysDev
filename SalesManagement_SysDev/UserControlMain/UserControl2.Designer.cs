
namespace SalesManagement_SysDev.UserControlMain
{
    partial class UserControl2
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
            this.buttonSale = new System.Windows.Forms.Button();
            this.buttonClient = new System.Windows.Forms.Button();
            this.buttonEmployee = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonSale
            // 
            this.buttonSale.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.buttonSale.Font = new System.Drawing.Font("MS UI Gothic", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonSale.Location = new System.Drawing.Point(175, 704);
            this.buttonSale.Name = "buttonSale";
            this.buttonSale.Size = new System.Drawing.Size(1331, 206);
            this.buttonSale.TabIndex = 5;
            this.buttonSale.Text = "出荷管理";
            this.buttonSale.UseVisualStyleBackColor = false;
            // 
            // buttonClient
            // 
            this.buttonClient.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.buttonClient.Font = new System.Drawing.Font("MS UI Gothic", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonClient.Location = new System.Drawing.Point(175, 397);
            this.buttonClient.Name = "buttonClient";
            this.buttonClient.Size = new System.Drawing.Size(1331, 206);
            this.buttonClient.TabIndex = 4;
            this.buttonClient.Text = "入荷管理";
            this.buttonClient.UseVisualStyleBackColor = false;
            // 
            // buttonEmployee
            // 
            this.buttonEmployee.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.buttonEmployee.Font = new System.Drawing.Font("MS UI Gothic", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonEmployee.Location = new System.Drawing.Point(175, 104);
            this.buttonEmployee.Name = "buttonEmployee";
            this.buttonEmployee.Size = new System.Drawing.Size(1331, 206);
            this.buttonEmployee.TabIndex = 3;
            this.buttonEmployee.Text = "受注管理";
            this.buttonEmployee.UseVisualStyleBackColor = false;
            // 
            // UserControl2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Honeydew;
            this.Controls.Add(this.buttonSale);
            this.Controls.Add(this.buttonClient);
            this.Controls.Add(this.buttonEmployee);
            this.Name = "UserControl2";
            this.Size = new System.Drawing.Size(1670, 980);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonSale;
        private System.Windows.Forms.Button buttonClient;
        private System.Windows.Forms.Button buttonEmployee;
    }
}
