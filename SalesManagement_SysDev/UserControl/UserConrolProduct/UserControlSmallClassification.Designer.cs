
namespace SalesManagement_SysDev
{
    partial class UserControlSmallClassification
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
            this.panelHeader2 = new System.Windows.Forms.Panel();
            this.buttonNotList = new System.Windows.Forms.Button();
            this.buttonList = new System.Windows.Forms.Button();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.buttonResist = new System.Windows.Forms.Button();
            this.panelInput = new System.Windows.Forms.Panel();
            this.textBoxScName = new System.Windows.Forms.TextBox();
            this.labelScName = new System.Windows.Forms.Label();
            this.comboBoxMcID = new System.Windows.Forms.ComboBox();
            this.buttonClear = new System.Windows.Forms.Button();
            this.textBoxScHidden = new System.Windows.Forms.TextBox();
            this.checkBoxScFlag = new System.Windows.Forms.CheckBox();
            this.textBoxScID = new System.Windows.Forms.TextBox();
            this.labelScID = new System.Windows.Forms.Label();
            this.labelMcID = new System.Windows.Forms.Label();
            this.buttonPageSizeChange = new System.Windows.Forms.Button();
            this.textBoxPageSize = new System.Windows.Forms.TextBox();
            this.labelPageSize = new System.Windows.Forms.Label();
            this.buttonLastPage = new System.Windows.Forms.Button();
            this.buttonNextPage = new System.Windows.Forms.Button();
            this.buttonPreviousPage = new System.Windows.Forms.Button();
            this.buttonFirstPage = new System.Windows.Forms.Button();
            this.labelPage = new System.Windows.Forms.Label();
            this.textBoxPage = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panelHeader2.SuspendLayout();
            this.panelInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelHeader2
            // 
            this.panelHeader2.Controls.Add(this.buttonNotList);
            this.panelHeader2.Controls.Add(this.buttonList);
            this.panelHeader2.Controls.Add(this.buttonSearch);
            this.panelHeader2.Controls.Add(this.buttonUpdate);
            this.panelHeader2.Controls.Add(this.buttonResist);
            this.panelHeader2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader2.Location = new System.Drawing.Point(0, 0);
            this.panelHeader2.Name = "panelHeader2";
            this.panelHeader2.Size = new System.Drawing.Size(1670, 130);
            this.panelHeader2.TabIndex = 3;
            // 
            // buttonNotList
            // 
            this.buttonNotList.BackColor = System.Drawing.Color.White;
            this.buttonNotList.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.buttonNotList.FlatAppearance.BorderSize = 4;
            this.buttonNotList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNotList.Font = new System.Drawing.Font("MS UI Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonNotList.Location = new System.Drawing.Point(1276, 22);
            this.buttonNotList.Name = "buttonNotList";
            this.buttonNotList.Size = new System.Drawing.Size(205, 80);
            this.buttonNotList.TabIndex = 4;
            this.buttonNotList.Text = "非表示リスト";
            this.buttonNotList.UseVisualStyleBackColor = false;
            // 
            // buttonList
            // 
            this.buttonList.BackColor = System.Drawing.Color.White;
            this.buttonList.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.buttonList.FlatAppearance.BorderSize = 4;
            this.buttonList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonList.Font = new System.Drawing.Font("MS UI Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonList.Location = new System.Drawing.Point(988, 22);
            this.buttonList.Name = "buttonList";
            this.buttonList.Size = new System.Drawing.Size(205, 80);
            this.buttonList.TabIndex = 3;
            this.buttonList.Text = "一覧表示";
            this.buttonList.UseVisualStyleBackColor = false;
            // 
            // buttonSearch
            // 
            this.buttonSearch.BackColor = System.Drawing.Color.White;
            this.buttonSearch.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.buttonSearch.FlatAppearance.BorderSize = 4;
            this.buttonSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSearch.Font = new System.Drawing.Font("MS UI Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonSearch.Location = new System.Drawing.Point(702, 22);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(205, 80);
            this.buttonSearch.TabIndex = 2;
            this.buttonSearch.Text = "検索";
            this.buttonSearch.UseVisualStyleBackColor = false;
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.BackColor = System.Drawing.Color.White;
            this.buttonUpdate.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.buttonUpdate.FlatAppearance.BorderSize = 4;
            this.buttonUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonUpdate.Font = new System.Drawing.Font("MS UI Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonUpdate.Location = new System.Drawing.Point(406, 22);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(205, 80);
            this.buttonUpdate.TabIndex = 1;
            this.buttonUpdate.Text = "更新";
            this.buttonUpdate.UseVisualStyleBackColor = false;
            // 
            // buttonResist
            // 
            this.buttonResist.BackColor = System.Drawing.Color.White;
            this.buttonResist.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.buttonResist.FlatAppearance.BorderSize = 4;
            this.buttonResist.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonResist.Font = new System.Drawing.Font("MS UI Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonResist.Location = new System.Drawing.Point(83, 22);
            this.buttonResist.Name = "buttonResist";
            this.buttonResist.Size = new System.Drawing.Size(205, 80);
            this.buttonResist.TabIndex = 0;
            this.buttonResist.Text = "登録";
            this.buttonResist.UseVisualStyleBackColor = false;
            this.buttonResist.Click += new System.EventHandler(this.buttonResist_Click);
            // 
            // panelInput
            // 
            this.panelInput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.panelInput.Controls.Add(this.textBoxScName);
            this.panelInput.Controls.Add(this.labelScName);
            this.panelInput.Controls.Add(this.comboBoxMcID);
            this.panelInput.Controls.Add(this.buttonClear);
            this.panelInput.Controls.Add(this.textBoxScHidden);
            this.panelInput.Controls.Add(this.checkBoxScFlag);
            this.panelInput.Controls.Add(this.textBoxScID);
            this.panelInput.Controls.Add(this.labelScID);
            this.panelInput.Controls.Add(this.labelMcID);
            this.panelInput.Location = new System.Drawing.Point(103, 145);
            this.panelInput.Name = "panelInput";
            this.panelInput.Size = new System.Drawing.Size(1378, 192);
            this.panelInput.TabIndex = 8;
            // 
            // textBoxScName
            // 
            this.textBoxScName.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBoxScName.Location = new System.Drawing.Point(753, 17);
            this.textBoxScName.Name = "textBoxScName";
            this.textBoxScName.Size = new System.Drawing.Size(250, 34);
            this.textBoxScName.TabIndex = 36;
            // 
            // labelScName
            // 
            this.labelScName.AutoSize = true;
            this.labelScName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.labelScName.Font = new System.Drawing.Font("MS UI Gothic", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelScName.Location = new System.Drawing.Point(621, 18);
            this.labelScName.Name = "labelScName";
            this.labelScName.Size = new System.Drawing.Size(129, 29);
            this.labelScName.TabIndex = 35;
            this.labelScName.Text = "小分類名";
            // 
            // comboBoxMcID
            // 
            this.comboBoxMcID.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.comboBoxMcID.FormattingEnabled = true;
            this.comboBoxMcID.Location = new System.Drawing.Point(145, 18);
            this.comboBoxMcID.Name = "comboBoxMcID";
            this.comboBoxMcID.Size = new System.Drawing.Size(212, 32);
            this.comboBoxMcID.TabIndex = 34;
            // 
            // buttonClear
            // 
            this.buttonClear.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonClear.Location = new System.Drawing.Point(1273, 159);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(102, 30);
            this.buttonClear.TabIndex = 33;
            this.buttonClear.Text = "入力クリア";
            this.buttonClear.UseVisualStyleBackColor = true;
            // 
            // textBoxScHidden
            // 
            this.textBoxScHidden.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBoxScHidden.Location = new System.Drawing.Point(191, 79);
            this.textBoxScHidden.Multiline = true;
            this.textBoxScHidden.Name = "textBoxScHidden";
            this.textBoxScHidden.Size = new System.Drawing.Size(812, 94);
            this.textBoxScHidden.TabIndex = 20;
            // 
            // checkBoxScFlag
            // 
            this.checkBoxScFlag.AutoSize = true;
            this.checkBoxScFlag.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.checkBoxScFlag.Location = new System.Drawing.Point(15, 79);
            this.checkBoxScFlag.Name = "checkBoxScFlag";
            this.checkBoxScFlag.Size = new System.Drawing.Size(170, 31);
            this.checkBoxScFlag.TabIndex = 18;
            this.checkBoxScFlag.Text = "非表示フラグ";
            this.checkBoxScFlag.UseVisualStyleBackColor = true;
            // 
            // textBoxScID
            // 
            this.textBoxScID.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBoxScID.Location = new System.Drawing.Point(514, 17);
            this.textBoxScID.Name = "textBoxScID";
            this.textBoxScID.Size = new System.Drawing.Size(46, 34);
            this.textBoxScID.TabIndex = 17;
            // 
            // labelScID
            // 
            this.labelScID.AutoSize = true;
            this.labelScID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.labelScID.Font = new System.Drawing.Font("MS UI Gothic", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelScID.Location = new System.Drawing.Point(382, 18);
            this.labelScID.Name = "labelScID";
            this.labelScID.Size = new System.Drawing.Size(126, 29);
            this.labelScID.TabIndex = 16;
            this.labelScID.Text = "小分類ID";
            // 
            // labelMcID
            // 
            this.labelMcID.AutoSize = true;
            this.labelMcID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.labelMcID.Font = new System.Drawing.Font("MS UI Gothic", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelMcID.Location = new System.Drawing.Point(10, 18);
            this.labelMcID.Name = "labelMcID";
            this.labelMcID.Size = new System.Drawing.Size(129, 29);
            this.labelMcID.TabIndex = 4;
            this.labelMcID.Text = "大分類名";
            // 
            // buttonPageSizeChange
            // 
            this.buttonPageSizeChange.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonPageSizeChange.Location = new System.Drawing.Point(1378, 368);
            this.buttonPageSizeChange.Name = "buttonPageSizeChange";
            this.buttonPageSizeChange.Size = new System.Drawing.Size(99, 28);
            this.buttonPageSizeChange.TabIndex = 53;
            this.buttonPageSizeChange.Text = "行数変更";
            this.buttonPageSizeChange.UseVisualStyleBackColor = true;
            // 
            // textBoxPageSize
            // 
            this.textBoxPageSize.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBoxPageSize.Location = new System.Drawing.Point(1338, 370);
            this.textBoxPageSize.Name = "textBoxPageSize";
            this.textBoxPageSize.Size = new System.Drawing.Size(26, 26);
            this.textBoxPageSize.TabIndex = 52;
            this.textBoxPageSize.Text = "10";
            // 
            // labelPageSize
            // 
            this.labelPageSize.AutoSize = true;
            this.labelPageSize.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelPageSize.Location = new System.Drawing.Point(1227, 375);
            this.labelPageSize.Name = "labelPageSize";
            this.labelPageSize.Size = new System.Drawing.Size(105, 19);
            this.labelPageSize.TabIndex = 51;
            this.labelPageSize.Text = "1ページ行数";
            // 
            // buttonLastPage
            // 
            this.buttonLastPage.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonLastPage.Location = new System.Drawing.Point(884, 364);
            this.buttonLastPage.Name = "buttonLastPage";
            this.buttonLastPage.Size = new System.Drawing.Size(50, 30);
            this.buttonLastPage.TabIndex = 50;
            this.buttonLastPage.Text = "▶l";
            this.buttonLastPage.UseVisualStyleBackColor = true;
            // 
            // buttonNextPage
            // 
            this.buttonNextPage.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonNextPage.Location = new System.Drawing.Point(816, 364);
            this.buttonNextPage.Name = "buttonNextPage";
            this.buttonNextPage.Size = new System.Drawing.Size(50, 30);
            this.buttonNextPage.TabIndex = 49;
            this.buttonNextPage.Text = "▶";
            this.buttonNextPage.UseVisualStyleBackColor = true;
            // 
            // buttonPreviousPage
            // 
            this.buttonPreviousPage.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonPreviousPage.Location = new System.Drawing.Point(736, 364);
            this.buttonPreviousPage.Name = "buttonPreviousPage";
            this.buttonPreviousPage.Size = new System.Drawing.Size(50, 31);
            this.buttonPreviousPage.TabIndex = 48;
            this.buttonPreviousPage.Text = "◀";
            this.buttonPreviousPage.UseVisualStyleBackColor = true;
            // 
            // buttonFirstPage
            // 
            this.buttonFirstPage.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonFirstPage.Location = new System.Drawing.Point(669, 364);
            this.buttonFirstPage.Name = "buttonFirstPage";
            this.buttonFirstPage.Size = new System.Drawing.Size(50, 30);
            this.buttonFirstPage.TabIndex = 47;
            this.buttonFirstPage.Text = "l◀";
            this.buttonFirstPage.UseVisualStyleBackColor = true;
            // 
            // labelPage
            // 
            this.labelPage.AutoSize = true;
            this.labelPage.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelPage.Location = new System.Drawing.Point(153, 370);
            this.labelPage.Name = "labelPage";
            this.labelPage.Size = new System.Drawing.Size(70, 24);
            this.labelPage.TabIndex = 46;
            this.labelPage.Text = "ページ";
            // 
            // textBoxPage
            // 
            this.textBoxPage.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBoxPage.Location = new System.Drawing.Point(103, 363);
            this.textBoxPage.Name = "textBoxPage";
            this.textBoxPage.Size = new System.Drawing.Size(45, 31);
            this.textBoxPage.TabIndex = 45;
            this.textBoxPage.Text = "100";
            this.textBoxPage.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(103, 401);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 21;
            this.dataGridView1.Size = new System.Drawing.Size(1378, 503);
            this.dataGridView1.TabIndex = 44;
            // 
            // UserControlSmallClassification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Honeydew;
            this.Controls.Add(this.buttonPageSizeChange);
            this.Controls.Add(this.textBoxPageSize);
            this.Controls.Add(this.labelPageSize);
            this.Controls.Add(this.buttonLastPage);
            this.Controls.Add(this.buttonNextPage);
            this.Controls.Add(this.buttonPreviousPage);
            this.Controls.Add(this.buttonFirstPage);
            this.Controls.Add(this.labelPage);
            this.Controls.Add(this.textBoxPage);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panelInput);
            this.Controls.Add(this.panelHeader2);
            this.Name = "UserControlSmallClassification";
            this.Size = new System.Drawing.Size(1670, 980);
            this.Load += new System.EventHandler(this.UserControlSmallClassification_Load);
            this.panelHeader2.ResumeLayout(false);
            this.panelInput.ResumeLayout(false);
            this.panelInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader2;
        private System.Windows.Forms.Button buttonNotList;
        private System.Windows.Forms.Button buttonList;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Button buttonResist;
        private System.Windows.Forms.Panel panelInput;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.TextBox textBoxScHidden;
        private System.Windows.Forms.CheckBox checkBoxScFlag;
        private System.Windows.Forms.TextBox textBoxScID;
        private System.Windows.Forms.Label labelScID;
        private System.Windows.Forms.Label labelMcID;
        private System.Windows.Forms.ComboBox comboBoxMcID;
        private System.Windows.Forms.TextBox textBoxScName;
        private System.Windows.Forms.Label labelScName;
        private System.Windows.Forms.Button buttonPageSizeChange;
        private System.Windows.Forms.TextBox textBoxPageSize;
        private System.Windows.Forms.Label labelPageSize;
        private System.Windows.Forms.Button buttonLastPage;
        private System.Windows.Forms.Button buttonNextPage;
        private System.Windows.Forms.Button buttonPreviousPage;
        private System.Windows.Forms.Button buttonFirstPage;
        private System.Windows.Forms.Label labelPage;
        private System.Windows.Forms.TextBox textBoxPage;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}
