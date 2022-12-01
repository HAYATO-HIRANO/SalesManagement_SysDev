
namespace SalesManagement_SysDev
{
    partial class UserControlSalesOffice
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
            this.textBoxSoAddress = new System.Windows.Forms.TextBox();
            this.labelSoAdress = new System.Windows.Forms.Label();
            this.textBoxMaHidden = new System.Windows.Forms.TextBox();
            this.checkBoxMaFlag = new System.Windows.Forms.CheckBox();
            this.textBoxSoPostal = new System.Windows.Forms.TextBox();
            this.labelSoPostal = new System.Windows.Forms.Label();
            this.textBoxSoFAX = new System.Windows.Forms.TextBox();
            this.labelSoFAX = new System.Windows.Forms.Label();
            this.textBoxSoPhone = new System.Windows.Forms.TextBox();
            this.labelSoPhone = new System.Windows.Forms.Label();
            this.textBoxSoName = new System.Windows.Forms.TextBox();
            this.labelSoName = new System.Windows.Forms.Label();
            this.textBoxSoID = new System.Windows.Forms.TextBox();
            this.labelSaID = new System.Windows.Forms.Label();
            this.buttonPageSizeChange = new System.Windows.Forms.Button();
            this.textBoxPageSize = new System.Windows.Forms.TextBox();
            this.labelPageSize = new System.Windows.Forms.Label();
            this.buttonLastPage = new System.Windows.Forms.Button();
            this.buttonNextPage = new System.Windows.Forms.Button();
            this.buttonPreviousPage = new System.Windows.Forms.Button();
            this.buttonFirstPage = new System.Windows.Forms.Button();
            this.labelPage = new System.Windows.Forms.Label();
            this.textBoxPage = new System.Windows.Forms.TextBox();
            this.dataGridViewSalesOffice = new System.Windows.Forms.DataGridView();
            this.panelHeader2.SuspendLayout();
            this.panelInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSalesOffice)).BeginInit();
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
            this.panelHeader2.TabIndex = 2;
            // 
            // buttonNotList
            // 
            this.buttonNotList.BackColor = System.Drawing.Color.White;
            this.buttonNotList.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.buttonNotList.FlatAppearance.BorderSize = 4;
            this.buttonNotList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNotList.Font = new System.Drawing.Font("MS UI Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonNotList.Location = new System.Drawing.Point(1295, 22);
            this.buttonNotList.Name = "buttonNotList";
            this.buttonNotList.Size = new System.Drawing.Size(205, 80);
            this.buttonNotList.TabIndex = 4;
            this.buttonNotList.Text = "非表示リスト";
            this.buttonNotList.UseVisualStyleBackColor = false;
            this.buttonNotList.Click += new System.EventHandler(this.buttonNotList_Click);
            // 
            // buttonList
            // 
            this.buttonList.BackColor = System.Drawing.Color.White;
            this.buttonList.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.buttonList.FlatAppearance.BorderSize = 4;
            this.buttonList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonList.Font = new System.Drawing.Font("MS UI Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonList.Location = new System.Drawing.Point(1007, 22);
            this.buttonList.Name = "buttonList";
            this.buttonList.Size = new System.Drawing.Size(205, 80);
            this.buttonList.TabIndex = 3;
            this.buttonList.Text = "一覧表示";
            this.buttonList.UseVisualStyleBackColor = false;
            this.buttonList.Click += new System.EventHandler(this.buttonList_Click);
            // 
            // buttonSearch
            // 
            this.buttonSearch.BackColor = System.Drawing.Color.White;
            this.buttonSearch.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.buttonSearch.FlatAppearance.BorderSize = 4;
            this.buttonSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSearch.Font = new System.Drawing.Font("MS UI Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonSearch.Location = new System.Drawing.Point(721, 22);
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
            this.buttonUpdate.Location = new System.Drawing.Point(425, 22);
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
            this.buttonResist.Location = new System.Drawing.Point(122, 22);
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
            this.panelInput.Controls.Add(this.textBoxSoAddress);
            this.panelInput.Controls.Add(this.labelSoAdress);
            this.panelInput.Controls.Add(this.textBoxMaHidden);
            this.panelInput.Controls.Add(this.checkBoxMaFlag);
            this.panelInput.Controls.Add(this.textBoxSoPostal);
            this.panelInput.Controls.Add(this.labelSoPostal);
            this.panelInput.Controls.Add(this.textBoxSoFAX);
            this.panelInput.Controls.Add(this.labelSoFAX);
            this.panelInput.Controls.Add(this.textBoxSoPhone);
            this.panelInput.Controls.Add(this.labelSoPhone);
            this.panelInput.Controls.Add(this.textBoxSoName);
            this.panelInput.Controls.Add(this.labelSoName);
            this.panelInput.Controls.Add(this.textBoxSoID);
            this.panelInput.Controls.Add(this.labelSaID);
            this.panelInput.Location = new System.Drawing.Point(270, 150);
            this.panelInput.Name = "panelInput";
            this.panelInput.Size = new System.Drawing.Size(1110, 192);
            this.panelInput.TabIndex = 8;
            // 
            // buttonClear
            // 
            this.buttonClear.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonClear.Location = new System.Drawing.Point(1005, 159);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(102, 30);
            this.buttonClear.TabIndex = 32;
            this.buttonClear.Text = "入力クリア";
            this.buttonClear.UseVisualStyleBackColor = true;
            // 
            // textBoxSoAddress
            // 
            this.textBoxSoAddress.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBoxSoAddress.Location = new System.Drawing.Point(304, 64);
            this.textBoxSoAddress.Name = "textBoxSoAddress";
            this.textBoxSoAddress.Size = new System.Drawing.Size(573, 28);
            this.textBoxSoAddress.TabIndex = 31;
            // 
            // labelSoAdress
            // 
            this.labelSoAdress.AutoSize = true;
            this.labelSoAdress.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.labelSoAdress.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelSoAdress.Location = new System.Drawing.Point(240, 66);
            this.labelSoAdress.Name = "labelSoAdress";
            this.labelSoAdress.Size = new System.Drawing.Size(58, 24);
            this.labelSoAdress.TabIndex = 30;
            this.labelSoAdress.Text = "住所";
            // 
            // textBoxMaHidden
            // 
            this.textBoxMaHidden.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBoxMaHidden.Location = new System.Drawing.Point(174, 109);
            this.textBoxMaHidden.Multiline = true;
            this.textBoxMaHidden.Name = "textBoxMaHidden";
            this.textBoxMaHidden.Size = new System.Drawing.Size(703, 75);
            this.textBoxMaHidden.TabIndex = 20;
            // 
            // checkBoxMaFlag
            // 
            this.checkBoxMaFlag.AutoSize = true;
            this.checkBoxMaFlag.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.checkBoxMaFlag.Location = new System.Drawing.Point(16, 113);
            this.checkBoxMaFlag.Name = "checkBoxMaFlag";
            this.checkBoxMaFlag.Size = new System.Drawing.Size(152, 28);
            this.checkBoxMaFlag.TabIndex = 18;
            this.checkBoxMaFlag.Text = "非表示フラグ";
            this.checkBoxMaFlag.UseVisualStyleBackColor = true;
            this.checkBoxMaFlag.CheckedChanged += new System.EventHandler(this.checkBoxMaFlag_CheckedChanged);
            // 
            // textBoxSoPostal
            // 
            this.textBoxSoPostal.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBoxSoPostal.Location = new System.Drawing.Point(124, 62);
            this.textBoxSoPostal.Name = "textBoxSoPostal";
            this.textBoxSoPostal.Size = new System.Drawing.Size(91, 28);
            this.textBoxSoPostal.TabIndex = 29;
            // 
            // labelSoPostal
            // 
            this.labelSoPostal.AutoSize = true;
            this.labelSoPostal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.labelSoPostal.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelSoPostal.Location = new System.Drawing.Point(12, 64);
            this.labelSoPostal.Name = "labelSoPostal";
            this.labelSoPostal.Size = new System.Drawing.Size(106, 24);
            this.labelSoPostal.TabIndex = 28;
            this.labelSoPostal.Text = "郵便番号";
            // 
            // textBoxSoFAX
            // 
            this.textBoxSoFAX.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBoxSoFAX.Location = new System.Drawing.Point(921, 10);
            this.textBoxSoFAX.Name = "textBoxSoFAX";
            this.textBoxSoFAX.Size = new System.Drawing.Size(154, 28);
            this.textBoxSoFAX.TabIndex = 27;
            // 
            // labelSoFAX
            // 
            this.labelSoFAX.AutoSize = true;
            this.labelSoFAX.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.labelSoFAX.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelSoFAX.Location = new System.Drawing.Point(863, 14);
            this.labelSoFAX.Name = "labelSoFAX";
            this.labelSoFAX.Size = new System.Drawing.Size(52, 24);
            this.labelSoFAX.TabIndex = 26;
            this.labelSoFAX.Text = "FAX";
            // 
            // textBoxSoPhone
            // 
            this.textBoxSoPhone.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBoxSoPhone.Location = new System.Drawing.Point(662, 12);
            this.textBoxSoPhone.Name = "textBoxSoPhone";
            this.textBoxSoPhone.Size = new System.Drawing.Size(154, 28);
            this.textBoxSoPhone.TabIndex = 25;
            // 
            // labelSoPhone
            // 
            this.labelSoPhone.AutoSize = true;
            this.labelSoPhone.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.labelSoPhone.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelSoPhone.Location = new System.Drawing.Point(550, 14);
            this.labelSoPhone.Name = "labelSoPhone";
            this.labelSoPhone.Size = new System.Drawing.Size(106, 24);
            this.labelSoPhone.TabIndex = 24;
            this.labelSoPhone.Text = "電話番号";
            // 
            // textBoxSoName
            // 
            this.textBoxSoName.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBoxSoName.Location = new System.Drawing.Point(284, 14);
            this.textBoxSoName.Name = "textBoxSoName";
            this.textBoxSoName.Size = new System.Drawing.Size(222, 28);
            this.textBoxSoName.TabIndex = 23;
            // 
            // labelSoName
            // 
            this.labelSoName.AutoSize = true;
            this.labelSoName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.labelSoName.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelSoName.Location = new System.Drawing.Point(172, 16);
            this.labelSoName.Name = "labelSoName";
            this.labelSoName.Size = new System.Drawing.Size(106, 24);
            this.labelSoName.TabIndex = 22;
            this.labelSoName.Text = "営業所名";
            // 
            // textBoxSoID
            // 
            this.textBoxSoID.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBoxSoID.Location = new System.Drawing.Point(122, 14);
            this.textBoxSoID.Name = "textBoxSoID";
            this.textBoxSoID.Size = new System.Drawing.Size(34, 28);
            this.textBoxSoID.TabIndex = 15;
            // 
            // labelSaID
            // 
            this.labelSaID.AutoSize = true;
            this.labelSaID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.labelSaID.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelSaID.Location = new System.Drawing.Point(12, 16);
            this.labelSaID.Name = "labelSaID";
            this.labelSaID.Size = new System.Drawing.Size(104, 24);
            this.labelSaID.TabIndex = 4;
            this.labelSaID.Text = "営業所ID";
            // 
            // buttonPageSizeChange
            // 
            this.buttonPageSizeChange.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonPageSizeChange.Location = new System.Drawing.Point(1449, 366);
            this.buttonPageSizeChange.Name = "buttonPageSizeChange";
            this.buttonPageSizeChange.Size = new System.Drawing.Size(99, 28);
            this.buttonPageSizeChange.TabIndex = 54;
            this.buttonPageSizeChange.Text = "行数変更";
            this.buttonPageSizeChange.UseVisualStyleBackColor = true;
            // 
            // textBoxPageSize
            // 
            this.textBoxPageSize.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBoxPageSize.Location = new System.Drawing.Point(1402, 368);
            this.textBoxPageSize.Name = "textBoxPageSize";
            this.textBoxPageSize.Size = new System.Drawing.Size(29, 26);
            this.textBoxPageSize.TabIndex = 53;
            this.textBoxPageSize.Text = "20";
            // 
            // labelPageSize
            // 
            this.labelPageSize.AutoSize = true;
            this.labelPageSize.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelPageSize.Location = new System.Drawing.Point(1291, 373);
            this.labelPageSize.Name = "labelPageSize";
            this.labelPageSize.Size = new System.Drawing.Size(105, 19);
            this.labelPageSize.TabIndex = 52;
            this.labelPageSize.Text = "1ページ行数";
            // 
            // buttonLastPage
            // 
            this.buttonLastPage.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonLastPage.Location = new System.Drawing.Point(904, 361);
            this.buttonLastPage.Name = "buttonLastPage";
            this.buttonLastPage.Size = new System.Drawing.Size(50, 30);
            this.buttonLastPage.TabIndex = 51;
            this.buttonLastPage.Text = "▶l";
            this.buttonLastPage.UseVisualStyleBackColor = true;
            // 
            // buttonNextPage
            // 
            this.buttonNextPage.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonNextPage.Location = new System.Drawing.Point(836, 361);
            this.buttonNextPage.Name = "buttonNextPage";
            this.buttonNextPage.Size = new System.Drawing.Size(50, 30);
            this.buttonNextPage.TabIndex = 50;
            this.buttonNextPage.Text = "▶";
            this.buttonNextPage.UseVisualStyleBackColor = true;
            // 
            // buttonPreviousPage
            // 
            this.buttonPreviousPage.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonPreviousPage.Location = new System.Drawing.Point(756, 361);
            this.buttonPreviousPage.Name = "buttonPreviousPage";
            this.buttonPreviousPage.Size = new System.Drawing.Size(50, 31);
            this.buttonPreviousPage.TabIndex = 49;
            this.buttonPreviousPage.Text = "◀";
            this.buttonPreviousPage.UseVisualStyleBackColor = true;
            // 
            // buttonFirstPage
            // 
            this.buttonFirstPage.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonFirstPage.Location = new System.Drawing.Point(689, 361);
            this.buttonFirstPage.Name = "buttonFirstPage";
            this.buttonFirstPage.Size = new System.Drawing.Size(50, 30);
            this.buttonFirstPage.TabIndex = 48;
            this.buttonFirstPage.Text = "l◀";
            this.buttonFirstPage.UseVisualStyleBackColor = true;
            // 
            // labelPage
            // 
            this.labelPage.AutoSize = true;
            this.labelPage.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelPage.Location = new System.Drawing.Point(152, 368);
            this.labelPage.Name = "labelPage";
            this.labelPage.Size = new System.Drawing.Size(70, 24);
            this.labelPage.TabIndex = 47;
            this.labelPage.Text = "ページ";
            // 
            // textBoxPage
            // 
            this.textBoxPage.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBoxPage.Location = new System.Drawing.Point(102, 362);
            this.textBoxPage.Name = "textBoxPage";
            this.textBoxPage.Size = new System.Drawing.Size(45, 31);
            this.textBoxPage.TabIndex = 46;
            this.textBoxPage.Text = "100";
            this.textBoxPage.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // dataGridViewSalesOffice
            // 
            this.dataGridViewSalesOffice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSalesOffice.Location = new System.Drawing.Point(102, 396);
            this.dataGridViewSalesOffice.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.dataGridViewSalesOffice.Name = "dataGridViewSalesOffice";
            this.dataGridViewSalesOffice.RowHeadersWidth = 62;
            this.dataGridViewSalesOffice.RowTemplate.Height = 21;
            this.dataGridViewSalesOffice.Size = new System.Drawing.Size(1442, 543);
            this.dataGridViewSalesOffice.TabIndex = 45;
            this.dataGridViewSalesOffice.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewSalesOffice_CellContentClick);
            // 
            // UserControlSalesOffice
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
            this.Controls.Add(this.dataGridViewSalesOffice);
            this.Controls.Add(this.panelInput);
            this.Controls.Add(this.panelHeader2);
            this.Name = "UserControlSalesOffice";
            this.Size = new System.Drawing.Size(1670, 980);
            this.Load += new System.EventHandler(this.UserControlSalesOffice_Load);
            this.panelHeader2.ResumeLayout(false);
            this.panelInput.ResumeLayout(false);
            this.panelInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSalesOffice)).EndInit();
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
        private System.Windows.Forms.TextBox textBoxSoAddress;
        private System.Windows.Forms.Label labelSoAdress;
        private System.Windows.Forms.TextBox textBoxMaHidden;
        private System.Windows.Forms.CheckBox checkBoxMaFlag;
        private System.Windows.Forms.TextBox textBoxSoPostal;
        private System.Windows.Forms.Label labelSoPostal;
        private System.Windows.Forms.TextBox textBoxSoFAX;
        private System.Windows.Forms.Label labelSoFAX;
        private System.Windows.Forms.TextBox textBoxSoPhone;
        private System.Windows.Forms.Label labelSoPhone;
        private System.Windows.Forms.TextBox textBoxSoName;
        private System.Windows.Forms.Label labelSoName;
        private System.Windows.Forms.TextBox textBoxSoID;
        private System.Windows.Forms.Label labelSaID;
        private System.Windows.Forms.Button buttonPageSizeChange;
        private System.Windows.Forms.TextBox textBoxPageSize;
        private System.Windows.Forms.Label labelPageSize;
        private System.Windows.Forms.Button buttonLastPage;
        private System.Windows.Forms.Button buttonNextPage;
        private System.Windows.Forms.Button buttonPreviousPage;
        private System.Windows.Forms.Button buttonFirstPage;
        private System.Windows.Forms.Label labelPage;
        private System.Windows.Forms.TextBox textBoxPage;
        private System.Windows.Forms.DataGridView dataGridViewSalesOffice;
    }
}
