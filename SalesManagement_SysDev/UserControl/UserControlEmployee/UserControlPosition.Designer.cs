
namespace SalesManagement_SysDev
{
    partial class UserControlPosition
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
            this.buttonResist = new System.Windows.Forms.Button();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.buttonSaisyou = new System.Windows.Forms.Button();
            this.buttonFormDel = new System.Windows.Forms.Button();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.buttonList = new System.Windows.Forms.Button();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonResist
            // 
            this.buttonResist.BackColor = System.Drawing.Color.LightGreen;
            this.buttonResist.Font = new System.Drawing.Font("MS UI Gothic", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonResist.Location = new System.Drawing.Point(46, 24);
            this.buttonResist.Name = "buttonResist";
            this.buttonResist.Size = new System.Drawing.Size(175, 83);
            this.buttonResist.TabIndex = 0;
            this.buttonResist.Text = "登録";
            this.buttonResist.UseVisualStyleBackColor = false;
            // 
            // panelButtons
            // 
            this.panelButtons.BackColor = System.Drawing.Color.Honeydew;
            this.panelButtons.Controls.Add(this.buttonList);
            this.panelButtons.Controls.Add(this.buttonSearch);
            this.panelButtons.Controls.Add(this.buttonUpdate);
            this.panelButtons.Controls.Add(this.buttonSaisyou);
            this.panelButtons.Controls.Add(this.buttonResist);
            this.panelButtons.Controls.Add(this.buttonFormDel);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelButtons.Location = new System.Drawing.Point(0, 0);
            this.panelButtons.Margin = new System.Windows.Forms.Padding(2);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(1670, 131);
            this.panelButtons.TabIndex = 0;
            this.panelButtons.Paint += new System.Windows.Forms.PaintEventHandler(this.panelButtons_Paint);
            // 
            // buttonSaisyou
            // 
            this.buttonSaisyou.BackColor = System.Drawing.Color.Honeydew;
            this.buttonSaisyou.Font = new System.Drawing.Font("MS UI Gothic", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonSaisyou.ForeColor = System.Drawing.Color.White;
            this.buttonSaisyou.Location = new System.Drawing.Point(1773, 0);
            this.buttonSaisyou.Name = "buttonSaisyou";
            this.buttonSaisyou.Size = new System.Drawing.Size(75, 75);
            this.buttonSaisyou.TabIndex = 7;
            this.buttonSaisyou.Text = "ー";
            this.buttonSaisyou.UseVisualStyleBackColor = false;
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
            // buttonUpdate
            // 
            this.buttonUpdate.BackColor = System.Drawing.Color.LightGreen;
            this.buttonUpdate.Font = new System.Drawing.Font("MS UI Gothic", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonUpdate.Location = new System.Drawing.Point(268, 24);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(175, 83);
            this.buttonUpdate.TabIndex = 8;
            this.buttonUpdate.Text = "更新";
            this.buttonUpdate.UseVisualStyleBackColor = false;
            // 
            // buttonSearch
            // 
            this.buttonSearch.BackColor = System.Drawing.Color.LightGreen;
            this.buttonSearch.Font = new System.Drawing.Font("MS UI Gothic", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonSearch.Location = new System.Drawing.Point(502, 24);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(175, 83);
            this.buttonSearch.TabIndex = 9;
            this.buttonSearch.Text = "検索";
            this.buttonSearch.UseVisualStyleBackColor = false;
            // 
            // buttonList
            // 
            this.buttonList.BackColor = System.Drawing.Color.LightGreen;
            this.buttonList.Font = new System.Drawing.Font("MS UI Gothic", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonList.Location = new System.Drawing.Point(734, 24);
            this.buttonList.Name = "buttonList";
            this.buttonList.Size = new System.Drawing.Size(175, 83);
            this.buttonList.TabIndex = 10;
            this.buttonList.Text = "一覧表示";
            this.buttonList.UseVisualStyleBackColor = false;
            // 
            // UserControlPosition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Honeydew;
            this.Controls.Add(this.panelButtons);
            this.Name = "UserControlPosition";
            this.Size = new System.Drawing.Size(1670, 980);
            this.panelButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonResist;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button buttonSaisyou;
        private System.Windows.Forms.Button buttonFormDel;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Button buttonList;
        private System.Windows.Forms.Button buttonSearch;
    }
}
