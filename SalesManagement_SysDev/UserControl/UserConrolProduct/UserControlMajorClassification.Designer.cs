﻿
namespace SalesManagement_SysDev
{
    partial class UserControlMajorClassification
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
            this.textBoxMcHidden = new System.Windows.Forms.TextBox();
            this.checkBoxMcFlag = new System.Windows.Forms.CheckBox();
            this.textBoxMcName = new System.Windows.Forms.TextBox();
            this.labelMcName = new System.Windows.Forms.Label();
            this.textBoxMcID = new System.Windows.Forms.TextBox();
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
            this.dataGridViewMc = new System.Windows.Forms.DataGridView();
            this.panelHeader2.SuspendLayout();
            this.panelInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMc)).BeginInit();
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
            this.buttonNotList.Location = new System.Drawing.Point(1276, 22);
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
            this.buttonList.Location = new System.Drawing.Point(988, 22);
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
            this.panelInput.Controls.Add(this.textBoxMcHidden);
            this.panelInput.Controls.Add(this.checkBoxMcFlag);
            this.panelInput.Controls.Add(this.textBoxMcName);
            this.panelInput.Controls.Add(this.labelMcName);
            this.panelInput.Controls.Add(this.textBoxMcID);
            this.panelInput.Controls.Add(this.labelMcID);
            this.panelInput.Location = new System.Drawing.Point(103, 145);
            this.panelInput.Name = "panelInput";
            this.panelInput.Size = new System.Drawing.Size(1378, 192);
            this.panelInput.TabIndex = 7;
            // 
            // buttonClear
            // 
            this.buttonClear.BackColor = System.Drawing.Color.White;
            this.buttonClear.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonClear.Location = new System.Drawing.Point(1273, 159);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(102, 30);
            this.buttonClear.TabIndex = 33;
            this.buttonClear.Text = "入力クリア";
            this.buttonClear.UseVisualStyleBackColor = false;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // textBoxMcHidden
            // 
            this.textBoxMcHidden.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBoxMcHidden.Location = new System.Drawing.Point(191, 79);
            this.textBoxMcHidden.Multiline = true;
            this.textBoxMcHidden.Name = "textBoxMcHidden";
            this.textBoxMcHidden.Size = new System.Drawing.Size(812, 94);
            this.textBoxMcHidden.TabIndex = 20;
            // 
            // checkBoxMcFlag
            // 
            this.checkBoxMcFlag.AutoSize = true;
            this.checkBoxMcFlag.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.checkBoxMcFlag.Location = new System.Drawing.Point(15, 79);
            this.checkBoxMcFlag.Name = "checkBoxMcFlag";
            this.checkBoxMcFlag.Size = new System.Drawing.Size(170, 31);
            this.checkBoxMcFlag.TabIndex = 18;
            this.checkBoxMcFlag.Text = "非表示フラグ";
            this.checkBoxMcFlag.UseVisualStyleBackColor = true;
            this.checkBoxMcFlag.CheckedChanged += new System.EventHandler(this.checkBoxMcFlag_CheckedChanged);
            // 
            // textBoxMcName
            // 
            this.textBoxMcName.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBoxMcName.Location = new System.Drawing.Point(361, 13);
            this.textBoxMcName.Name = "textBoxMcName";
            this.textBoxMcName.Size = new System.Drawing.Size(642, 34);
            this.textBoxMcName.TabIndex = 17;
            // 
            // labelMcName
            // 
            this.labelMcName.AutoSize = true;
            this.labelMcName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.labelMcName.Font = new System.Drawing.Font("MS UI Gothic", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelMcName.Location = new System.Drawing.Point(226, 18);
            this.labelMcName.Name = "labelMcName";
            this.labelMcName.Size = new System.Drawing.Size(129, 29);
            this.labelMcName.TabIndex = 16;
            this.labelMcName.Text = "大分類名";
            // 
            // textBoxMcID
            // 
            this.textBoxMcID.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBoxMcID.Location = new System.Drawing.Point(132, 13);
            this.textBoxMcID.Name = "textBoxMcID";
            this.textBoxMcID.Size = new System.Drawing.Size(41, 34);
            this.textBoxMcID.TabIndex = 15;
            // 
            // labelMcID
            // 
            this.labelMcID.AutoSize = true;
            this.labelMcID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.labelMcID.Font = new System.Drawing.Font("MS UI Gothic", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelMcID.Location = new System.Drawing.Point(10, 18);
            this.labelMcID.Name = "labelMcID";
            this.labelMcID.Size = new System.Drawing.Size(126, 29);
            this.labelMcID.TabIndex = 4;
            this.labelMcID.Text = "大分類ID";
            // 
            // buttonPageSizeChange
            // 
            this.buttonPageSizeChange.BackColor = System.Drawing.Color.White;
            this.buttonPageSizeChange.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonPageSizeChange.Location = new System.Drawing.Point(1378, 368);
            this.buttonPageSizeChange.Name = "buttonPageSizeChange";
            this.buttonPageSizeChange.Size = new System.Drawing.Size(99, 28);
            this.buttonPageSizeChange.TabIndex = 43;
            this.buttonPageSizeChange.Text = "行数変更";
            this.buttonPageSizeChange.UseVisualStyleBackColor = false;
            this.buttonPageSizeChange.Click += new System.EventHandler(this.buttonPageSizeChange_Click);
            // 
            // textBoxPageSize
            // 
            this.textBoxPageSize.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBoxPageSize.Location = new System.Drawing.Point(1338, 370);
            this.textBoxPageSize.Name = "textBoxPageSize";
            this.textBoxPageSize.Size = new System.Drawing.Size(26, 26);
            this.textBoxPageSize.TabIndex = 42;
            this.textBoxPageSize.Text = "10";
            // 
            // labelPageSize
            // 
            this.labelPageSize.AutoSize = true;
            this.labelPageSize.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelPageSize.Location = new System.Drawing.Point(1227, 375);
            this.labelPageSize.Name = "labelPageSize";
            this.labelPageSize.Size = new System.Drawing.Size(105, 19);
            this.labelPageSize.TabIndex = 41;
            this.labelPageSize.Text = "1ページ行数";
            // 
            // buttonLastPage
            // 
            this.buttonLastPage.BackColor = System.Drawing.Color.White;
            this.buttonLastPage.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonLastPage.Location = new System.Drawing.Point(884, 364);
            this.buttonLastPage.Name = "buttonLastPage";
            this.buttonLastPage.Size = new System.Drawing.Size(50, 30);
            this.buttonLastPage.TabIndex = 40;
            this.buttonLastPage.Text = "▶l";
            this.buttonLastPage.UseVisualStyleBackColor = false;
            this.buttonLastPage.Click += new System.EventHandler(this.buttonLastPage_Click);
            // 
            // buttonNextPage
            // 
            this.buttonNextPage.BackColor = System.Drawing.Color.White;
            this.buttonNextPage.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonNextPage.Location = new System.Drawing.Point(816, 364);
            this.buttonNextPage.Name = "buttonNextPage";
            this.buttonNextPage.Size = new System.Drawing.Size(50, 30);
            this.buttonNextPage.TabIndex = 39;
            this.buttonNextPage.Text = "▶";
            this.buttonNextPage.UseVisualStyleBackColor = false;
            this.buttonNextPage.Click += new System.EventHandler(this.buttonNextPage_Click);
            // 
            // buttonPreviousPage
            // 
            this.buttonPreviousPage.BackColor = System.Drawing.Color.White;
            this.buttonPreviousPage.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonPreviousPage.Location = new System.Drawing.Point(736, 364);
            this.buttonPreviousPage.Name = "buttonPreviousPage";
            this.buttonPreviousPage.Size = new System.Drawing.Size(50, 31);
            this.buttonPreviousPage.TabIndex = 38;
            this.buttonPreviousPage.Text = "◀";
            this.buttonPreviousPage.UseVisualStyleBackColor = false;
            this.buttonPreviousPage.Click += new System.EventHandler(this.buttonPreviousPage_Click);
            // 
            // buttonFirstPage
            // 
            this.buttonFirstPage.BackColor = System.Drawing.Color.White;
            this.buttonFirstPage.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonFirstPage.Location = new System.Drawing.Point(669, 364);
            this.buttonFirstPage.Name = "buttonFirstPage";
            this.buttonFirstPage.Size = new System.Drawing.Size(50, 30);
            this.buttonFirstPage.TabIndex = 37;
            this.buttonFirstPage.Text = "l◀";
            this.buttonFirstPage.UseVisualStyleBackColor = false;
            this.buttonFirstPage.Click += new System.EventHandler(this.buttonFirstPage_Click);
            // 
            // labelPage
            // 
            this.labelPage.AutoSize = true;
            this.labelPage.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelPage.Location = new System.Drawing.Point(153, 370);
            this.labelPage.Name = "labelPage";
            this.labelPage.Size = new System.Drawing.Size(70, 24);
            this.labelPage.TabIndex = 36;
            this.labelPage.Text = "ページ";
            // 
            // textBoxPage
            // 
            this.textBoxPage.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBoxPage.Location = new System.Drawing.Point(103, 363);
            this.textBoxPage.Name = "textBoxPage";
            this.textBoxPage.Size = new System.Drawing.Size(45, 31);
            this.textBoxPage.TabIndex = 35;
            this.textBoxPage.Text = "100";
            this.textBoxPage.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // dataGridViewMc
            // 
            this.dataGridViewMc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMc.Location = new System.Drawing.Point(103, 401);
            this.dataGridViewMc.Name = "dataGridViewMc";
            this.dataGridViewMc.RowTemplate.Height = 21;
            this.dataGridViewMc.Size = new System.Drawing.Size(1378, 503);
            this.dataGridViewMc.TabIndex = 34;
            this.dataGridViewMc.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewMc_CellClick);
            // 
            // UserControlMajorClassification
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
            this.Controls.Add(this.dataGridViewMc);
            this.Controls.Add(this.panelInput);
            this.Controls.Add(this.panelHeader2);
            this.Name = "UserControlMajorClassification";
            this.Size = new System.Drawing.Size(1670, 980);
            this.Load += new System.EventHandler(this.UserControlMajorClassification_Load);
            this.panelHeader2.ResumeLayout(false);
            this.panelInput.ResumeLayout(false);
            this.panelInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMc)).EndInit();
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
        private System.Windows.Forms.TextBox textBoxMcHidden;
        private System.Windows.Forms.CheckBox checkBoxMcFlag;
        private System.Windows.Forms.TextBox textBoxMcName;
        private System.Windows.Forms.Label labelMcName;
        private System.Windows.Forms.TextBox textBoxMcID;
        private System.Windows.Forms.Label labelMcID;
        private System.Windows.Forms.Button buttonPageSizeChange;
        private System.Windows.Forms.TextBox textBoxPageSize;
        private System.Windows.Forms.Label labelPageSize;
        private System.Windows.Forms.Button buttonLastPage;
        private System.Windows.Forms.Button buttonNextPage;
        private System.Windows.Forms.Button buttonPreviousPage;
        private System.Windows.Forms.Button buttonFirstPage;
        private System.Windows.Forms.Label labelPage;
        private System.Windows.Forms.TextBox textBoxPage;
        private System.Windows.Forms.DataGridView dataGridViewMc;
    }
}
