namespace SalesManagement_SysDev.UserControlMain
{
    partial class UserControl3
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
            this.buttonChumon = new System.Windows.Forms.Button();
            this.buttonWarehousing = new System.Windows.Forms.Button();
            this.buttonSyukko = new System.Windows.Forms.Button();
            this.buttonHattyu = new System.Windows.Forms.Button();
            this.buttonProduct = new System.Windows.Forms.Button();
            this.buttonStock = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonChumon
            // 
            this.buttonChumon.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.buttonChumon.Font = new System.Drawing.Font("MS UI Gothic", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonChumon.Location = new System.Drawing.Point(92, 68);
            this.buttonChumon.Name = "buttonChumon";
            this.buttonChumon.Size = new System.Drawing.Size(590, 210);
            this.buttonChumon.TabIndex = 0;
            this.buttonChumon.Text = "注文管理";
            this.buttonChumon.UseVisualStyleBackColor = false;
            // 
            // buttonWarehousing
            // 
            this.buttonWarehousing.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.buttonWarehousing.Font = new System.Drawing.Font("MS UI Gothic", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonWarehousing.Location = new System.Drawing.Point(835, 363);
            this.buttonWarehousing.Name = "buttonWarehousing";
            this.buttonWarehousing.Size = new System.Drawing.Size(590, 210);
            this.buttonWarehousing.TabIndex = 1;
            this.buttonWarehousing.Text = "入庫管理";
            this.buttonWarehousing.UseVisualStyleBackColor = false;
            // 
            // buttonSyukko
            // 
            this.buttonSyukko.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.buttonSyukko.Font = new System.Drawing.Font("MS UI Gothic", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonSyukko.Location = new System.Drawing.Point(835, 660);
            this.buttonSyukko.Name = "buttonSyukko";
            this.buttonSyukko.Size = new System.Drawing.Size(590, 210);
            this.buttonSyukko.TabIndex = 2;
            this.buttonSyukko.Text = "出庫管理";
            this.buttonSyukko.UseVisualStyleBackColor = false;
            // 
            // buttonHattyu
            // 
            this.buttonHattyu.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.buttonHattyu.Font = new System.Drawing.Font("MS UI Gothic", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonHattyu.Location = new System.Drawing.Point(92, 363);
            this.buttonHattyu.Name = "buttonHattyu";
            this.buttonHattyu.Size = new System.Drawing.Size(590, 210);
            this.buttonHattyu.TabIndex = 4;
            this.buttonHattyu.Text = "発注管理";
            this.buttonHattyu.UseVisualStyleBackColor = false;
            // 
            // buttonProduct
            // 
            this.buttonProduct.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.buttonProduct.Font = new System.Drawing.Font("MS UI Gothic", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonProduct.Location = new System.Drawing.Point(92, 660);
            this.buttonProduct.Name = "buttonProduct";
            this.buttonProduct.Size = new System.Drawing.Size(590, 210);
            this.buttonProduct.TabIndex = 3;
            this.buttonProduct.Text = "商品管理";
            this.buttonProduct.UseVisualStyleBackColor = false;
            this.buttonProduct.Click += new System.EventHandler(this.buttonProduct_Click);
            // 
            // buttonStock
            // 
            this.buttonStock.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.buttonStock.Font = new System.Drawing.Font("MS UI Gothic", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonStock.Location = new System.Drawing.Point(835, 68);
            this.buttonStock.Name = "buttonStock";
            this.buttonStock.Size = new System.Drawing.Size(590, 210);
            this.buttonStock.TabIndex = 5;
            this.buttonStock.Text = "在庫管理";
            this.buttonStock.UseVisualStyleBackColor = false;
            this.buttonStock.Click += new System.EventHandler(this.buttonStock_Click);
            // 
            // UserControl3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Honeydew;
            this.Controls.Add(this.buttonStock);
            this.Controls.Add(this.buttonHattyu);
            this.Controls.Add(this.buttonProduct);
            this.Controls.Add(this.buttonSyukko);
            this.Controls.Add(this.buttonWarehousing);
            this.Controls.Add(this.buttonChumon);
            this.Name = "UserControl3";
            this.Size = new System.Drawing.Size(1670, 980);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonChumon;
        private System.Windows.Forms.Button buttonWarehousing;
        private System.Windows.Forms.Button buttonSyukko;
        private System.Windows.Forms.Button buttonHattyu;
        private System.Windows.Forms.Button buttonProduct;
        private System.Windows.Forms.Button buttonStock;
    }
}
