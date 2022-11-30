
namespace SalesManagement_SysDev.UserControlMain
{
    partial class UserControlSales
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
            this.buttonShipment = new System.Windows.Forms.Button();
            this.buttonArrival = new System.Windows.Forms.Button();
            this.buttonOrder = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonShipment
            // 
            this.buttonShipment.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.buttonShipment.Font = new System.Drawing.Font("MS UI Gothic", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonShipment.Location = new System.Drawing.Point(175, 704);
            this.buttonShipment.Name = "buttonShipment";
            this.buttonShipment.Size = new System.Drawing.Size(1331, 206);
            this.buttonShipment.TabIndex = 5;
            this.buttonShipment.Text = "出荷管理";
            this.buttonShipment.UseVisualStyleBackColor = false;
            // 
            // buttonArrival
            // 
            this.buttonArrival.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.buttonArrival.Font = new System.Drawing.Font("MS UI Gothic", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonArrival.Location = new System.Drawing.Point(175, 397);
            this.buttonArrival.Name = "buttonArrival";
            this.buttonArrival.Size = new System.Drawing.Size(1331, 206);
            this.buttonArrival.TabIndex = 4;
            this.buttonArrival.Text = "入荷管理";
            this.buttonArrival.UseVisualStyleBackColor = false;
            this.buttonArrival.Click += new System.EventHandler(this.buttonArrival_Click);
            // 
            // buttonOrder
            // 
            this.buttonOrder.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.buttonOrder.Font = new System.Drawing.Font("MS UI Gothic", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonOrder.Location = new System.Drawing.Point(175, 104);
            this.buttonOrder.Name = "buttonOrder";
            this.buttonOrder.Size = new System.Drawing.Size(1331, 206);
            this.buttonOrder.TabIndex = 3;
            this.buttonOrder.Text = "受注管理";
            this.buttonOrder.UseVisualStyleBackColor = false;
            this.buttonOrder.Click += new System.EventHandler(this.buttonOrder_Click);
            // 
            // UserControlSales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Honeydew;
            this.Controls.Add(this.buttonShipment);
            this.Controls.Add(this.buttonArrival);
            this.Controls.Add(this.buttonOrder);
            this.Name = "UserControlSales";
            this.Size = new System.Drawing.Size(1670, 980);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonShipment;
        private System.Windows.Forms.Button buttonArrival;
        private System.Windows.Forms.Button buttonOrder;
    }
}
