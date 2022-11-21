
namespace SalesManagement_SysDev
{
    partial class UserControlMaker
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
            this.buttonClear = new System.Windows.Forms.Button();
            this.textBoxMaAddress = new System.Windows.Forms.TextBox();
            this.labelMaAdress = new System.Windows.Forms.Label();
            this.textBoxMaHidden = new System.Windows.Forms.TextBox();
            this.checkBoxMaFlag = new System.Windows.Forms.CheckBox();
            this.textBoxMaPostal = new System.Windows.Forms.TextBox();
            this.labelMaPostal = new System.Windows.Forms.Label();
            this.textBoxMaFAX = new System.Windows.Forms.TextBox();
            this.labelMaFAX = new System.Windows.Forms.Label();
            this.textBoxMaPhone = new System.Windows.Forms.TextBox();
            this.labelMaPhone = new System.Windows.Forms.Label();
            this.textBoxMaName = new System.Windows.Forms.TextBox();
            this.labelMaName = new System.Windows.Forms.Label();
            this.textBoxMaID = new System.Windows.Forms.TextBox();
            this.labelMaID = new System.Windows.Forms.Label();
            this.dataGridViewMaker = new System.Windows.Forms.DataGridView();
            this.buttonPageSizeChange = new System.Windows.Forms.Button();
            this.textBoxPageSize = new System.Windows.Forms.TextBox();
            this.labelPageSize = new System.Windows.Forms.Label();
            this.buttonLastPage = new System.Windows.Forms.Button();
            this.buttonNextPage = new System.Windows.Forms.Button();
            this.buttonPreviousPage = new System.Windows.Forms.Button();
            this.buttonFirstPage = new System.Windows.Forms.Button();
            this.labelPage = new System.Windows.Forms.Label();
            this.textBoxPage = new System.Windows.Forms.TextBox();
            this.panelHeader2.SuspendLayout();
            this.panelInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMaker)).BeginInit();
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
            this.panelHeader2.TabIndex = 1;
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
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
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
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // buttonResist
            // 
            this.buttonResist.BackColor = System.Drawing.Color.White;
            this.buttonResist.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.buttonResist.FlatAppearance.BorderSize = 4;
            this.buttonResist.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonResist.Font = new System.Drawing.Font("MS UI Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonResist.Location = new System.Drawing.Point(103, 22);
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
            this.panelInput.Controls.Add(this.buttonClear);
            this.panelInput.Controls.Add(this.textBoxMaAddress);
            this.panelInput.Controls.Add(this.labelMaAdress);
            this.panelInput.Controls.Add(this.textBoxMaHidden);
            this.panelInput.Controls.Add(this.checkBoxMaFlag);
            this.panelInput.Controls.Add(this.textBoxMaPostal);
            this.panelInput.Controls.Add(this.labelMaPostal);
            this.panelInput.Controls.Add(this.textBoxMaFAX);
            this.panelInput.Controls.Add(this.labelMaFAX);
            this.panelInput.Controls.Add(this.textBoxMaPhone);
            this.panelInput.Controls.Add(this.labelMaPhone);
            this.panelInput.Controls.Add(this.textBoxMaName);
            this.panelInput.Controls.Add(this.labelMaName);
            this.panelInput.Controls.Add(this.textBoxMaID);
            this.panelInput.Controls.Add(this.labelMaID);
            this.panelInput.Location = new System.Drawing.Point(32, 137);
            this.panelInput.Name = "panelInput";
            this.panelInput.Size = new System.Drawing.Size(1607, 192);
            this.panelInput.TabIndex = 7;
            // 
            // buttonClear
            // 
            this.buttonClear.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonClear.Location = new System.Drawing.Point(1502, 159);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(102, 30);
            this.buttonClear.TabIndex = 32;
            this.buttonClear.Text = "入力クリア";
            this.buttonClear.UseVisualStyleBackColor = true;
            // 
            // textBoxMaAddress
            // 
            this.textBoxMaAddress.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBoxMaAddress.Location = new System.Drawing.Point(302, 66);
            this.textBoxMaAddress.Name = "textBoxMaAddress";
            this.textBoxMaAddress.Size = new System.Drawing.Size(573, 28);
            this.textBoxMaAddress.TabIndex = 31;
            // 
            // labelMaAdress
            // 
            this.labelMaAdress.AutoSize = true;
            this.labelMaAdress.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.labelMaAdress.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelMaAdress.Location = new System.Drawing.Point(238, 68);
            this.labelMaAdress.Name = "labelMaAdress";
            this.labelMaAdress.Size = new System.Drawing.Size(58, 24);
            this.labelMaAdress.TabIndex = 30;
            this.labelMaAdress.Text = "住所";
            // 
            // textBoxMaHidden
            // 
            this.textBoxMaHidden.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBoxMaHidden.Location = new System.Drawing.Point(172, 111);
            this.textBoxMaHidden.Multiline = true;
            this.textBoxMaHidden.Name = "textBoxMaHidden";
            this.textBoxMaHidden.Size = new System.Drawing.Size(703, 75);
            this.textBoxMaHidden.TabIndex = 20;
            // 
            // checkBoxMaFlag
            // 
            this.checkBoxMaFlag.AutoSize = true;
            this.checkBoxMaFlag.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.checkBoxMaFlag.Location = new System.Drawing.Point(14, 115);
            this.checkBoxMaFlag.Name = "checkBoxMaFlag";
            this.checkBoxMaFlag.Size = new System.Drawing.Size(152, 28);
            this.checkBoxMaFlag.TabIndex = 18;
            this.checkBoxMaFlag.Text = "非表示フラグ";
            this.checkBoxMaFlag.UseVisualStyleBackColor = true;
            // 
            // textBoxMaPostal
            // 
            this.textBoxMaPostal.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBoxMaPostal.Location = new System.Drawing.Point(122, 64);
            this.textBoxMaPostal.Name = "textBoxMaPostal";
            this.textBoxMaPostal.Size = new System.Drawing.Size(91, 28);
            this.textBoxMaPostal.TabIndex = 29;
            // 
            // labelMaPostal
            // 
            this.labelMaPostal.AutoSize = true;
            this.labelMaPostal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.labelMaPostal.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelMaPostal.Location = new System.Drawing.Point(10, 66);
            this.labelMaPostal.Name = "labelMaPostal";
            this.labelMaPostal.Size = new System.Drawing.Size(106, 24);
            this.labelMaPostal.TabIndex = 28;
            this.labelMaPostal.Text = "郵便番号";
            // 
            // textBoxMaFAX
            // 
            this.textBoxMaFAX.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBoxMaFAX.Location = new System.Drawing.Point(1150, 12);
            this.textBoxMaFAX.Name = "textBoxMaFAX";
            this.textBoxMaFAX.Size = new System.Drawing.Size(154, 28);
            this.textBoxMaFAX.TabIndex = 27;
            // 
            // labelMaFAX
            // 
            this.labelMaFAX.AutoSize = true;
            this.labelMaFAX.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.labelMaFAX.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelMaFAX.Location = new System.Drawing.Point(1092, 16);
            this.labelMaFAX.Name = "labelMaFAX";
            this.labelMaFAX.Size = new System.Drawing.Size(52, 24);
            this.labelMaFAX.TabIndex = 26;
            this.labelMaFAX.Text = "FAX";
            // 
            // textBoxMaPhone
            // 
            this.textBoxMaPhone.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBoxMaPhone.Location = new System.Drawing.Point(891, 14);
            this.textBoxMaPhone.Name = "textBoxMaPhone";
            this.textBoxMaPhone.Size = new System.Drawing.Size(154, 28);
            this.textBoxMaPhone.TabIndex = 25;
            // 
            // labelMaPhone
            // 
            this.labelMaPhone.AutoSize = true;
            this.labelMaPhone.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.labelMaPhone.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelMaPhone.Location = new System.Drawing.Point(779, 16);
            this.labelMaPhone.Name = "labelMaPhone";
            this.labelMaPhone.Size = new System.Drawing.Size(106, 24);
            this.labelMaPhone.TabIndex = 24;
            this.labelMaPhone.Text = "電話番号";
            // 
            // textBoxMaName
            // 
            this.textBoxMaName.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBoxMaName.Location = new System.Drawing.Point(302, 16);
            this.textBoxMaName.Name = "textBoxMaName";
            this.textBoxMaName.Size = new System.Drawing.Size(450, 28);
            this.textBoxMaName.TabIndex = 23;
            // 
            // labelMaName
            // 
            this.labelMaName.AutoSize = true;
            this.labelMaName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.labelMaName.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelMaName.Location = new System.Drawing.Point(208, 18);
            this.labelMaName.Name = "labelMaName";
            this.labelMaName.Size = new System.Drawing.Size(88, 24);
            this.labelMaName.TabIndex = 22;
            this.labelMaName.Text = "メーカ名";
            // 
            // textBoxMaID
            // 
            this.textBoxMaID.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBoxMaID.Location = new System.Drawing.Point(102, 16);
            this.textBoxMaID.Name = "textBoxMaID";
            this.textBoxMaID.Size = new System.Drawing.Size(78, 28);
            this.textBoxMaID.TabIndex = 15;
            // 
            // labelMaID
            // 
            this.labelMaID.AutoSize = true;
            this.labelMaID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.labelMaID.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelMaID.Location = new System.Drawing.Point(10, 18);
            this.labelMaID.Name = "labelMaID";
            this.labelMaID.Size = new System.Drawing.Size(86, 24);
            this.labelMaID.TabIndex = 4;
            this.labelMaID.Text = "メーカID";
            // 
            // dataGridViewMaker
            // 
            this.dataGridViewMaker.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMaker.Location = new System.Drawing.Point(32, 386);
            this.dataGridViewMaker.Name = "dataGridViewMaker";
            this.dataGridViewMaker.RowTemplate.Height = 21;
            this.dataGridViewMaker.Size = new System.Drawing.Size(1607, 569);
            this.dataGridViewMaker.TabIndex = 8;
            // 
            // buttonPageSizeChange
            // 
            this.buttonPageSizeChange.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonPageSizeChange.Location = new System.Drawing.Point(1534, 357);
            this.buttonPageSizeChange.Name = "buttonPageSizeChange";
            this.buttonPageSizeChange.Size = new System.Drawing.Size(99, 28);
            this.buttonPageSizeChange.TabIndex = 44;
            this.buttonPageSizeChange.Text = "行数変更";
            this.buttonPageSizeChange.UseVisualStyleBackColor = true;
            this.buttonPageSizeChange.Click += new System.EventHandler(this.buttonPageSizeChange_Click);
            // 
            // textBoxPageSize
            // 
            this.textBoxPageSize.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBoxPageSize.Location = new System.Drawing.Point(1487, 359);
            this.textBoxPageSize.Name = "textBoxPageSize";
            this.textBoxPageSize.Size = new System.Drawing.Size(41, 26);
            this.textBoxPageSize.TabIndex = 43;
            this.textBoxPageSize.Text = "100";
            // 
            // labelPageSize
            // 
            this.labelPageSize.AutoSize = true;
            this.labelPageSize.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelPageSize.Location = new System.Drawing.Point(1376, 364);
            this.labelPageSize.Name = "labelPageSize";
            this.labelPageSize.Size = new System.Drawing.Size(105, 19);
            this.labelPageSize.TabIndex = 42;
            this.labelPageSize.Text = "1ページ行数";
            // 
            // buttonLastPage
            // 
            this.buttonLastPage.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonLastPage.Location = new System.Drawing.Point(916, 349);
            this.buttonLastPage.Name = "buttonLastPage";
            this.buttonLastPage.Size = new System.Drawing.Size(50, 30);
            this.buttonLastPage.TabIndex = 41;
            this.buttonLastPage.Text = "▶l";
            this.buttonLastPage.UseVisualStyleBackColor = true;
            this.buttonLastPage.Click += new System.EventHandler(this.buttonLastPage_Click);
            // 
            // buttonNextPage
            // 
            this.buttonNextPage.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonNextPage.Location = new System.Drawing.Point(848, 349);
            this.buttonNextPage.Name = "buttonNextPage";
            this.buttonNextPage.Size = new System.Drawing.Size(50, 30);
            this.buttonNextPage.TabIndex = 40;
            this.buttonNextPage.Text = "▶";
            this.buttonNextPage.UseVisualStyleBackColor = true;
            this.buttonNextPage.Click += new System.EventHandler(this.buttonNextPage_Click);
            // 
            // buttonPreviousPage
            // 
            this.buttonPreviousPage.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonPreviousPage.Location = new System.Drawing.Point(768, 349);
            this.buttonPreviousPage.Name = "buttonPreviousPage";
            this.buttonPreviousPage.Size = new System.Drawing.Size(50, 31);
            this.buttonPreviousPage.TabIndex = 39;
            this.buttonPreviousPage.Text = "◀";
            this.buttonPreviousPage.UseVisualStyleBackColor = true;
            this.buttonPreviousPage.Click += new System.EventHandler(this.buttonPreviousPage_Click);
            // 
            // buttonFirstPage
            // 
            this.buttonFirstPage.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonFirstPage.Location = new System.Drawing.Point(701, 349);
            this.buttonFirstPage.Name = "buttonFirstPage";
            this.buttonFirstPage.Size = new System.Drawing.Size(50, 30);
            this.buttonFirstPage.TabIndex = 38;
            this.buttonFirstPage.Text = "l◀";
            this.buttonFirstPage.UseVisualStyleBackColor = true;
            this.buttonFirstPage.Click += new System.EventHandler(this.buttonFirstPage_Click);
            // 
            // labelPage
            // 
            this.labelPage.AutoSize = true;
            this.labelPage.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelPage.Location = new System.Drawing.Point(82, 356);
            this.labelPage.Name = "labelPage";
            this.labelPage.Size = new System.Drawing.Size(70, 24);
            this.labelPage.TabIndex = 37;
            this.labelPage.Text = "ページ";
            // 
            // textBoxPage
            // 
            this.textBoxPage.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBoxPage.Location = new System.Drawing.Point(32, 350);
            this.textBoxPage.Name = "textBoxPage";
            this.textBoxPage.Size = new System.Drawing.Size(45, 31);
            this.textBoxPage.TabIndex = 36;
            this.textBoxPage.Text = "100";
            this.textBoxPage.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // UserControlMaker
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
            this.Controls.Add(this.dataGridViewMaker);
            this.Controls.Add(this.panelInput);
            this.Controls.Add(this.panelHeader2);
            this.Name = "UserControlMaker";
            this.Size = new System.Drawing.Size(1670, 980);
            this.Load += new System.EventHandler(this.UserControlMaker_Load);
            this.panelHeader2.ResumeLayout(false);
            this.panelInput.ResumeLayout(false);
            this.panelInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMaker)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader2;
        private System.Windows.Forms.Button buttonList;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Button buttonResist;
        private System.Windows.Forms.Button buttonNotList;
        private System.Windows.Forms.Panel panelInput;
        private System.Windows.Forms.TextBox textBoxMaName;
        private System.Windows.Forms.Label labelMaName;
        private System.Windows.Forms.TextBox textBoxMaHidden;
        private System.Windows.Forms.CheckBox checkBoxMaFlag;
        private System.Windows.Forms.TextBox textBoxMaID;
        private System.Windows.Forms.Label labelMaID;
        private System.Windows.Forms.TextBox textBoxMaPhone;
        private System.Windows.Forms.Label labelMaPhone;
        private System.Windows.Forms.TextBox textBoxMaFAX;
        private System.Windows.Forms.Label labelMaFAX;
        private System.Windows.Forms.TextBox textBoxMaAddress;
        private System.Windows.Forms.Label labelMaAdress;
        private System.Windows.Forms.TextBox textBoxMaPostal;
        private System.Windows.Forms.Label labelMaPostal;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.DataGridView dataGridViewMaker;
        private System.Windows.Forms.Button buttonPageSizeChange;
        private System.Windows.Forms.TextBox textBoxPageSize;
        private System.Windows.Forms.Label labelPageSize;
        private System.Windows.Forms.Button buttonLastPage;
        private System.Windows.Forms.Button buttonNextPage;
        private System.Windows.Forms.Button buttonPreviousPage;
        private System.Windows.Forms.Button buttonFirstPage;
        private System.Windows.Forms.Label labelPage;
        private System.Windows.Forms.TextBox textBoxPage;
    }
}
