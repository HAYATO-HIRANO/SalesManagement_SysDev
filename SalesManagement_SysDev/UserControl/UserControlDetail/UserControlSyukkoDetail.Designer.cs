﻿
namespace SalesManagement_SysDev
{
    partial class UserControlSyukkoDetail
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
            this.panelLeft = new System.Windows.Forms.Panel();
            this.buttonList = new System.Windows.Forms.Button();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.panelInput = new System.Windows.Forms.Panel();
            this.labelStateFlag = new System.Windows.Forms.Label();
            this.labelSyState = new System.Windows.Forms.Label();
            this.labelSyID = new System.Windows.Forms.Label();
            this.textBoxSyID = new System.Windows.Forms.TextBox();
            this.labelPrice = new System.Windows.Forms.Label();
            this.textBoxPrice = new System.Windows.Forms.TextBox();
            this.textBoxSyDetailID = new System.Windows.Forms.TextBox();
            this.labelSyDetailID = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.labelPrID = new System.Windows.Forms.Label();
            this.textBoxPrName = new System.Windows.Forms.TextBox();
            this.textBoxPrID = new System.Windows.Forms.TextBox();
            this.labelOrQuantity = new System.Windows.Forms.Label();
            this.labelPrName = new System.Windows.Forms.Label();
            this.textBoxSyQuantity = new System.Windows.Forms.TextBox();
            this.labelOrTotalPrice = new System.Windows.Forms.Label();
            this.textBoxOrTotalPrice = new System.Windows.Forms.TextBox();
            this.buttonPageSizeChange = new System.Windows.Forms.Button();
            this.textBoxPageSize = new System.Windows.Forms.TextBox();
            this.dataGridViewSyukkoDetail = new System.Windows.Forms.DataGridView();
            this.labelPageSize = new System.Windows.Forms.Label();
            this.textBoxPage = new System.Windows.Forms.TextBox();
            this.buttonLastPage = new System.Windows.Forms.Button();
            this.labelPage = new System.Windows.Forms.Label();
            this.buttonNextPage = new System.Windows.Forms.Button();
            this.buttonFirstPage = new System.Windows.Forms.Button();
            this.buttonPreviousPage = new System.Windows.Forms.Button();
            this.panelLeft.SuspendLayout();
            this.panelInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSyukkoDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // panelLeft
            // 
            this.panelLeft.BackColor = System.Drawing.Color.Honeydew;
            this.panelLeft.Controls.Add(this.buttonList);
            this.panelLeft.Controls.Add(this.buttonSearch);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Margin = new System.Windows.Forms.Padding(2);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(250, 980);
            this.panelLeft.TabIndex = 7;
            // 
            // buttonList
            // 
            this.buttonList.BackColor = System.Drawing.Color.White;
            this.buttonList.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.buttonList.FlatAppearance.BorderSize = 4;
            this.buttonList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonList.Font = new System.Drawing.Font("MS UI Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonList.Location = new System.Drawing.Point(25, 120);
            this.buttonList.Name = "buttonList";
            this.buttonList.Size = new System.Drawing.Size(200, 80);
            this.buttonList.TabIndex = 8;
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
            this.buttonSearch.Location = new System.Drawing.Point(25, 15);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(200, 80);
            this.buttonSearch.TabIndex = 1;
            this.buttonSearch.Text = "検索";
            this.buttonSearch.UseVisualStyleBackColor = false;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // panelInput
            // 
            this.panelInput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.panelInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelInput.Controls.Add(this.labelStateFlag);
            this.panelInput.Controls.Add(this.labelSyState);
            this.panelInput.Controls.Add(this.labelSyID);
            this.panelInput.Controls.Add(this.textBoxSyID);
            this.panelInput.Controls.Add(this.labelPrice);
            this.panelInput.Controls.Add(this.textBoxPrice);
            this.panelInput.Controls.Add(this.textBoxSyDetailID);
            this.panelInput.Controls.Add(this.labelSyDetailID);
            this.panelInput.Controls.Add(this.button1);
            this.panelInput.Controls.Add(this.labelPrID);
            this.panelInput.Controls.Add(this.textBoxPrName);
            this.panelInput.Controls.Add(this.textBoxPrID);
            this.panelInput.Controls.Add(this.labelOrQuantity);
            this.panelInput.Controls.Add(this.labelPrName);
            this.panelInput.Controls.Add(this.textBoxSyQuantity);
            this.panelInput.Controls.Add(this.labelOrTotalPrice);
            this.panelInput.Controls.Add(this.textBoxOrTotalPrice);
            this.panelInput.Location = new System.Drawing.Point(293, 52);
            this.panelInput.Name = "panelInput";
            this.panelInput.Size = new System.Drawing.Size(1552, 173);
            this.panelInput.TabIndex = 50;
            // 
            // labelStateFlag
            // 
            this.labelStateFlag.AutoSize = true;
            this.labelStateFlag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.labelStateFlag.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelStateFlag.ForeColor = System.Drawing.Color.Red;
            this.labelStateFlag.Location = new System.Drawing.Point(126, 96);
            this.labelStateFlag.Name = "labelStateFlag";
            this.labelStateFlag.Size = new System.Drawing.Size(0, 24);
            this.labelStateFlag.TabIndex = 45;
            // 
            // labelSyState
            // 
            this.labelSyState.AutoSize = true;
            this.labelSyState.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.labelSyState.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelSyState.Location = new System.Drawing.Point(15, 96);
            this.labelSyState.Name = "labelSyState";
            this.labelSyState.Size = new System.Drawing.Size(118, 24);
            this.labelSyState.TabIndex = 44;
            this.labelSyState.Text = "出庫状態：";
            // 
            // labelSyID
            // 
            this.labelSyID.AutoSize = true;
            this.labelSyID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.labelSyID.Font = new System.Drawing.Font("MS UI Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelSyID.Location = new System.Drawing.Point(13, 18);
            this.labelSyID.Name = "labelSyID";
            this.labelSyID.Size = new System.Drawing.Size(108, 33);
            this.labelSyID.TabIndex = 42;
            this.labelSyID.Text = "出庫ID";
            // 
            // textBoxSyID
            // 
            this.textBoxSyID.Font = new System.Drawing.Font("MS UI Gothic", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBoxSyID.Location = new System.Drawing.Point(127, 16);
            this.textBoxSyID.Name = "textBoxSyID";
            this.textBoxSyID.Size = new System.Drawing.Size(102, 36);
            this.textBoxSyID.TabIndex = 43;
            this.textBoxSyID.TextChanged += new System.EventHandler(this.textBoxSyID_TextChanged);
            // 
            // labelPrice
            // 
            this.labelPrice.AutoSize = true;
            this.labelPrice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.labelPrice.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelPrice.Location = new System.Drawing.Point(361, 99);
            this.labelPrice.Name = "labelPrice";
            this.labelPrice.Size = new System.Drawing.Size(52, 21);
            this.labelPrice.TabIndex = 40;
            this.labelPrice.Text = "価格";
            // 
            // textBoxPrice
            // 
            this.textBoxPrice.BackColor = System.Drawing.Color.DarkGray;
            this.textBoxPrice.Enabled = false;
            this.textBoxPrice.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBoxPrice.Location = new System.Drawing.Point(431, 94);
            this.textBoxPrice.Name = "textBoxPrice";
            this.textBoxPrice.Size = new System.Drawing.Size(114, 28);
            this.textBoxPrice.TabIndex = 41;
            // 
            // textBoxSyDetailID
            // 
            this.textBoxSyDetailID.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBoxSyDetailID.Location = new System.Drawing.Point(434, 21);
            this.textBoxSyDetailID.Name = "textBoxSyDetailID";
            this.textBoxSyDetailID.Size = new System.Drawing.Size(77, 28);
            this.textBoxSyDetailID.TabIndex = 37;
            // 
            // labelSyDetailID
            // 
            this.labelSyDetailID.AutoSize = true;
            this.labelSyDetailID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.labelSyDetailID.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelSyDetailID.Location = new System.Drawing.Point(300, 23);
            this.labelSyDetailID.Name = "labelSyDetailID";
            this.labelSyDetailID.Size = new System.Drawing.Size(128, 24);
            this.labelSyDetailID.TabIndex = 36;
            this.labelSyDetailID.Text = "出庫詳細ID";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button1.Location = new System.Drawing.Point(1447, 140);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(102, 30);
            this.button1.TabIndex = 28;
            this.button1.Text = "入力クリア";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // labelPrID
            // 
            this.labelPrID.AutoSize = true;
            this.labelPrID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.labelPrID.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelPrID.Location = new System.Drawing.Point(604, 25);
            this.labelPrID.Name = "labelPrID";
            this.labelPrID.Size = new System.Drawing.Size(80, 24);
            this.labelPrID.TabIndex = 28;
            this.labelPrID.Text = "商品ID";
            // 
            // textBoxPrName
            // 
            this.textBoxPrName.BackColor = System.Drawing.Color.DarkGray;
            this.textBoxPrName.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBoxPrName.Location = new System.Drawing.Point(918, 23);
            this.textBoxPrName.Name = "textBoxPrName";
            this.textBoxPrName.ReadOnly = true;
            this.textBoxPrName.Size = new System.Drawing.Size(348, 28);
            this.textBoxPrName.TabIndex = 35;
            // 
            // textBoxPrID
            // 
            this.textBoxPrID.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBoxPrID.Location = new System.Drawing.Point(690, 23);
            this.textBoxPrID.Name = "textBoxPrID";
            this.textBoxPrID.Size = new System.Drawing.Size(77, 28);
            this.textBoxPrID.TabIndex = 29;
            this.textBoxPrID.TextChanged += new System.EventHandler(this.textBoxPrID_TextChanged);
            // 
            // labelOrQuantity
            // 
            this.labelOrQuantity.AutoSize = true;
            this.labelOrQuantity.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.labelOrQuantity.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelOrQuantity.Location = new System.Drawing.Point(626, 96);
            this.labelOrQuantity.Name = "labelOrQuantity";
            this.labelOrQuantity.Size = new System.Drawing.Size(58, 24);
            this.labelOrQuantity.TabIndex = 30;
            this.labelOrQuantity.Text = "数量";
            // 
            // labelPrName
            // 
            this.labelPrName.AutoSize = true;
            this.labelPrName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.labelPrName.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelPrName.Location = new System.Drawing.Point(839, 26);
            this.labelPrName.Name = "labelPrName";
            this.labelPrName.Size = new System.Drawing.Size(73, 21);
            this.labelPrName.TabIndex = 34;
            this.labelPrName.Text = "商品名";
            // 
            // textBoxSyQuantity
            // 
            this.textBoxSyQuantity.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBoxSyQuantity.Location = new System.Drawing.Point(690, 94);
            this.textBoxSyQuantity.Name = "textBoxSyQuantity";
            this.textBoxSyQuantity.Size = new System.Drawing.Size(57, 28);
            this.textBoxSyQuantity.TabIndex = 31;
            this.textBoxSyQuantity.TextChanged += new System.EventHandler(this.textBoxOrQuantity_TextChanged);
            // 
            // labelOrTotalPrice
            // 
            this.labelOrTotalPrice.AutoSize = true;
            this.labelOrTotalPrice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.labelOrTotalPrice.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelOrTotalPrice.Location = new System.Drawing.Point(818, 99);
            this.labelOrTotalPrice.Name = "labelOrTotalPrice";
            this.labelOrTotalPrice.Size = new System.Drawing.Size(94, 21);
            this.labelOrTotalPrice.TabIndex = 32;
            this.labelOrTotalPrice.Text = "合計金額";
            // 
            // textBoxOrTotalPrice
            // 
            this.textBoxOrTotalPrice.BackColor = System.Drawing.Color.DarkGray;
            this.textBoxOrTotalPrice.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBoxOrTotalPrice.Location = new System.Drawing.Point(918, 92);
            this.textBoxOrTotalPrice.Name = "textBoxOrTotalPrice";
            this.textBoxOrTotalPrice.ReadOnly = true;
            this.textBoxOrTotalPrice.Size = new System.Drawing.Size(127, 28);
            this.textBoxOrTotalPrice.TabIndex = 33;
            // 
            // buttonPageSizeChange
            // 
            this.buttonPageSizeChange.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonPageSizeChange.Location = new System.Drawing.Point(1733, 266);
            this.buttonPageSizeChange.Name = "buttonPageSizeChange";
            this.buttonPageSizeChange.Size = new System.Drawing.Size(99, 28);
            this.buttonPageSizeChange.TabIndex = 78;
            this.buttonPageSizeChange.Text = "行数変更";
            this.buttonPageSizeChange.UseVisualStyleBackColor = true;
            this.buttonPageSizeChange.Click += new System.EventHandler(this.buttonPageSizeChange_Click);
            // 
            // textBoxPageSize
            // 
            this.textBoxPageSize.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBoxPageSize.Location = new System.Drawing.Point(1694, 268);
            this.textBoxPageSize.Name = "textBoxPageSize";
            this.textBoxPageSize.Size = new System.Drawing.Size(33, 26);
            this.textBoxPageSize.TabIndex = 77;
            this.textBoxPageSize.Text = "20";
            // 
            // dataGridViewSyukkoDetail
            // 
            this.dataGridViewSyukkoDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSyukkoDetail.Location = new System.Drawing.Point(293, 296);
            this.dataGridViewSyukkoDetail.Name = "dataGridViewSyukkoDetail";
            this.dataGridViewSyukkoDetail.RowTemplate.Height = 21;
            this.dataGridViewSyukkoDetail.Size = new System.Drawing.Size(1552, 605);
            this.dataGridViewSyukkoDetail.TabIndex = 69;
            // 
            // labelPageSize
            // 
            this.labelPageSize.AutoSize = true;
            this.labelPageSize.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelPageSize.Location = new System.Drawing.Point(1583, 273);
            this.labelPageSize.Name = "labelPageSize";
            this.labelPageSize.Size = new System.Drawing.Size(105, 19);
            this.labelPageSize.TabIndex = 76;
            this.labelPageSize.Text = "1ページ行数";
            // 
            // textBoxPage
            // 
            this.textBoxPage.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBoxPage.Location = new System.Drawing.Point(295, 263);
            this.textBoxPage.Name = "textBoxPage";
            this.textBoxPage.Size = new System.Drawing.Size(45, 31);
            this.textBoxPage.TabIndex = 70;
            this.textBoxPage.Text = "1";
            this.textBoxPage.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // buttonLastPage
            // 
            this.buttonLastPage.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonLastPage.Location = new System.Drawing.Point(1155, 263);
            this.buttonLastPage.Name = "buttonLastPage";
            this.buttonLastPage.Size = new System.Drawing.Size(50, 30);
            this.buttonLastPage.TabIndex = 75;
            this.buttonLastPage.Text = "▶l";
            this.buttonLastPage.UseVisualStyleBackColor = true;
            this.buttonLastPage.Click += new System.EventHandler(this.buttonLastPage_Click);
            // 
            // labelPage
            // 
            this.labelPage.AutoSize = true;
            this.labelPage.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelPage.Location = new System.Drawing.Point(345, 270);
            this.labelPage.Name = "labelPage";
            this.labelPage.Size = new System.Drawing.Size(70, 24);
            this.labelPage.TabIndex = 71;
            this.labelPage.Text = "ページ";
            // 
            // buttonNextPage
            // 
            this.buttonNextPage.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonNextPage.Location = new System.Drawing.Point(1087, 263);
            this.buttonNextPage.Name = "buttonNextPage";
            this.buttonNextPage.Size = new System.Drawing.Size(50, 30);
            this.buttonNextPage.TabIndex = 74;
            this.buttonNextPage.Text = "▶";
            this.buttonNextPage.UseVisualStyleBackColor = true;
            this.buttonNextPage.Click += new System.EventHandler(this.buttonNextPage_Click);
            // 
            // buttonFirstPage
            // 
            this.buttonFirstPage.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonFirstPage.Location = new System.Drawing.Point(940, 263);
            this.buttonFirstPage.Name = "buttonFirstPage";
            this.buttonFirstPage.Size = new System.Drawing.Size(50, 30);
            this.buttonFirstPage.TabIndex = 72;
            this.buttonFirstPage.Text = "l◀";
            this.buttonFirstPage.UseVisualStyleBackColor = true;
            this.buttonFirstPage.Click += new System.EventHandler(this.buttonFirstPage_Click);
            // 
            // buttonPreviousPage
            // 
            this.buttonPreviousPage.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonPreviousPage.Location = new System.Drawing.Point(1007, 263);
            this.buttonPreviousPage.Name = "buttonPreviousPage";
            this.buttonPreviousPage.Size = new System.Drawing.Size(50, 31);
            this.buttonPreviousPage.TabIndex = 73;
            this.buttonPreviousPage.Text = "◀";
            this.buttonPreviousPage.UseVisualStyleBackColor = true;
            this.buttonPreviousPage.Click += new System.EventHandler(this.buttonPreviousPage_Click);
            // 
            // UserControlSyukkoDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Honeydew;
            this.Controls.Add(this.buttonPageSizeChange);
            this.Controls.Add(this.textBoxPageSize);
            this.Controls.Add(this.dataGridViewSyukkoDetail);
            this.Controls.Add(this.labelPageSize);
            this.Controls.Add(this.textBoxPage);
            this.Controls.Add(this.buttonLastPage);
            this.Controls.Add(this.labelPage);
            this.Controls.Add(this.buttonNextPage);
            this.Controls.Add(this.buttonFirstPage);
            this.Controls.Add(this.buttonPreviousPage);
            this.Controls.Add(this.panelInput);
            this.Controls.Add(this.panelLeft);
            this.Name = "UserControlSyukkoDetail";
            this.Size = new System.Drawing.Size(1920, 980);
            this.Load += new System.EventHandler(this.UserControlSyukkoDetail_Load);
            this.panelLeft.ResumeLayout(false);
            this.panelInput.ResumeLayout(false);
            this.panelInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSyukkoDetail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Button buttonList;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.Panel panelInput;
        private System.Windows.Forms.Label labelStateFlag;
        private System.Windows.Forms.Label labelSyState;
        private System.Windows.Forms.Label labelSyID;
        private System.Windows.Forms.TextBox textBoxSyID;
        private System.Windows.Forms.Label labelPrice;
        private System.Windows.Forms.TextBox textBoxPrice;
        private System.Windows.Forms.TextBox textBoxSyDetailID;
        private System.Windows.Forms.Label labelSyDetailID;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label labelPrID;
        private System.Windows.Forms.TextBox textBoxPrName;
        private System.Windows.Forms.TextBox textBoxPrID;
        private System.Windows.Forms.Label labelOrQuantity;
        private System.Windows.Forms.Label labelPrName;
        private System.Windows.Forms.TextBox textBoxSyQuantity;
        private System.Windows.Forms.Label labelOrTotalPrice;
        private System.Windows.Forms.TextBox textBoxOrTotalPrice;
        private System.Windows.Forms.Button buttonPageSizeChange;
        private System.Windows.Forms.TextBox textBoxPageSize;
        private System.Windows.Forms.DataGridView dataGridViewSyukkoDetail;
        private System.Windows.Forms.Label labelPageSize;
        private System.Windows.Forms.TextBox textBoxPage;
        private System.Windows.Forms.Button buttonLastPage;
        private System.Windows.Forms.Label labelPage;
        private System.Windows.Forms.Button buttonNextPage;
        private System.Windows.Forms.Button buttonFirstPage;
        private System.Windows.Forms.Button buttonPreviousPage;
    }
}
