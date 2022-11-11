
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
            this.panelHeader2 = new System.Windows.Forms.Panel();
            this.buttonList = new System.Windows.Forms.Button();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.buttonResist = new System.Windows.Forms.Button();
            this.panelInput = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.textBoxEmHidden = new System.Windows.Forms.TextBox();
            this.checkBoxPoFlag = new System.Windows.Forms.CheckBox();
            this.textBoxPoName = new System.Windows.Forms.TextBox();
            this.labelPoName = new System.Windows.Forms.Label();
            this.textBoxEmID = new System.Windows.Forms.TextBox();
            this.labelPoID = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelHeader2
            // 
            this.panelHeader2.Controls.Add(this.buttonList);
            this.panelHeader2.Controls.Add(this.buttonSearch);
            this.panelHeader2.Controls.Add(this.buttonUpdate);
            this.panelHeader2.Controls.Add(this.buttonResist);
            this.panelHeader2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader2.Location = new System.Drawing.Point(0, 0);
            this.panelHeader2.Name = "panelHeader2";
            this.panelHeader2.Size = new System.Drawing.Size(1670, 130);
            this.panelHeader2.TabIndex = 0;
            // 
            // buttonList
            // 
            this.buttonList.BackColor = System.Drawing.Color.LightGreen;
            this.buttonList.Font = new System.Drawing.Font("MS UI Gothic", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonList.Location = new System.Drawing.Point(1205, 22);
            this.buttonList.Name = "buttonList";
            this.buttonList.Size = new System.Drawing.Size(180, 80);
            this.buttonList.TabIndex = 3;
            this.buttonList.Text = "一覧表示";
            this.buttonList.UseVisualStyleBackColor = false;
            this.buttonList.Click += new System.EventHandler(this.buttonList_Click);
            // 
            // buttonSearch
            // 
            this.buttonSearch.BackColor = System.Drawing.Color.LightGreen;
            this.buttonSearch.Font = new System.Drawing.Font("MS UI Gothic", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonSearch.Location = new System.Drawing.Point(881, 22);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(180, 80);
            this.buttonSearch.TabIndex = 2;
            this.buttonSearch.Text = "検索";
            this.buttonSearch.UseVisualStyleBackColor = false;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.BackColor = System.Drawing.Color.LightGreen;
            this.buttonUpdate.Font = new System.Drawing.Font("MS UI Gothic", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonUpdate.Location = new System.Drawing.Point(555, 22);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(180, 80);
            this.buttonUpdate.TabIndex = 1;
            this.buttonUpdate.Text = "更新";
            this.buttonUpdate.UseVisualStyleBackColor = false;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // buttonResist
            // 
            this.buttonResist.BackColor = System.Drawing.Color.LightGreen;
            this.buttonResist.Font = new System.Drawing.Font("MS UI Gothic", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonResist.Location = new System.Drawing.Point(234, 22);
            this.buttonResist.Name = "buttonResist";
            this.buttonResist.Size = new System.Drawing.Size(180, 80);
            this.buttonResist.TabIndex = 0;
            this.buttonResist.Text = "登録";
            this.buttonResist.UseVisualStyleBackColor = false;
            this.buttonResist.Click += new System.EventHandler(this.buttonResist_Click);
            // 
            // panelInput
            // 
            this.panelInput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.panelInput.Controls.Add(this.button1);
            this.panelInput.Controls.Add(this.textBoxEmHidden);
            this.panelInput.Controls.Add(this.checkBoxPoFlag);
            this.panelInput.Controls.Add(this.textBoxPoName);
            this.panelInput.Controls.Add(this.labelPoName);
            this.panelInput.Controls.Add(this.textBoxEmID);
            this.panelInput.Controls.Add(this.labelPoID);
            this.panelInput.Location = new System.Drawing.Point(317, 178);
            this.panelInput.Name = "panelInput";
            this.panelInput.Size = new System.Drawing.Size(1019, 192);
            this.panelInput.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(941, 166);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 21;
            this.button1.Text = "入力クリア";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // textBoxEmHidden
            // 
            this.textBoxEmHidden.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBoxEmHidden.Location = new System.Drawing.Point(358, 80);
            this.textBoxEmHidden.Multiline = true;
            this.textBoxEmHidden.Name = "textBoxEmHidden";
            this.textBoxEmHidden.Size = new System.Drawing.Size(564, 94);
            this.textBoxEmHidden.TabIndex = 20;
            // 
            // checkBoxPoFlag
            // 
            this.checkBoxPoFlag.AutoSize = true;
            this.checkBoxPoFlag.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.checkBoxPoFlag.Location = new System.Drawing.Point(182, 80);
            this.checkBoxPoFlag.Name = "checkBoxPoFlag";
            this.checkBoxPoFlag.Size = new System.Drawing.Size(170, 31);
            this.checkBoxPoFlag.TabIndex = 18;
            this.checkBoxPoFlag.Text = "非表示フラグ";
            this.checkBoxPoFlag.UseVisualStyleBackColor = true;
            // 
            // textBoxPoName
            // 
            this.textBoxPoName.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBoxPoName.Location = new System.Drawing.Point(280, 15);
            this.textBoxPoName.Name = "textBoxPoName";
            this.textBoxPoName.Size = new System.Drawing.Size(642, 34);
            this.textBoxPoName.TabIndex = 17;
            this.textBoxPoName.TextChanged += new System.EventHandler(this.textBoxPoName_TextChanged);
            // 
            // labelPoName
            // 
            this.labelPoName.AutoSize = true;
            this.labelPoName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.labelPoName.Font = new System.Drawing.Font("MS UI Gothic", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelPoName.Location = new System.Drawing.Point(177, 18);
            this.labelPoName.Name = "labelPoName";
            this.labelPoName.Size = new System.Drawing.Size(100, 29);
            this.labelPoName.TabIndex = 16;
            this.labelPoName.Text = "役職名";
            // 
            // textBoxEmID
            // 
            this.textBoxEmID.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBoxEmID.Location = new System.Drawing.Point(113, 15);
            this.textBoxEmID.Name = "textBoxEmID";
            this.textBoxEmID.Size = new System.Drawing.Size(41, 34);
            this.textBoxEmID.TabIndex = 15;
            this.textBoxEmID.Text = "99";
            this.textBoxEmID.TextChanged += new System.EventHandler(this.textBoxEmID_TextChanged);
            // 
            // labelPoID
            // 
            this.labelPoID.AutoSize = true;
            this.labelPoID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.labelPoID.Font = new System.Drawing.Font("MS UI Gothic", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelPoID.Location = new System.Drawing.Point(10, 18);
            this.labelPoID.Name = "labelPoID";
            this.labelPoID.Size = new System.Drawing.Size(97, 29);
            this.labelPoID.TabIndex = 4;
            this.labelPoID.Text = "役職ID";
            this.labelPoID.Click += new System.EventHandler(this.labelPoID_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(317, 453);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 21;
            this.dataGridView1.Size = new System.Drawing.Size(1019, 503);
            this.dataGridView1.TabIndex = 7;
            // 
            // buttonPageSizeChange
            // 
            this.buttonPageSizeChange.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonPageSizeChange.Location = new System.Drawing.Point(1242, 420);
            this.buttonPageSizeChange.Name = "buttonPageSizeChange";
            this.buttonPageSizeChange.Size = new System.Drawing.Size(99, 28);
            this.buttonPageSizeChange.TabIndex = 33;
            this.buttonPageSizeChange.Text = "行数変更";
            this.buttonPageSizeChange.UseVisualStyleBackColor = true;
            // 
            // textBoxPageSize
            // 
            this.textBoxPageSize.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBoxPageSize.Location = new System.Drawing.Point(1195, 422);
            this.textBoxPageSize.Name = "textBoxPageSize";
            this.textBoxPageSize.Size = new System.Drawing.Size(41, 26);
            this.textBoxPageSize.TabIndex = 32;
            this.textBoxPageSize.Text = "100";
            // 
            // labelPageSize
            // 
            this.labelPageSize.AutoSize = true;
            this.labelPageSize.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelPageSize.Location = new System.Drawing.Point(1084, 427);
            this.labelPageSize.Name = "labelPageSize";
            this.labelPageSize.Size = new System.Drawing.Size(105, 19);
            this.labelPageSize.TabIndex = 31;
            this.labelPageSize.Text = "1ページ行数";
            // 
            // buttonLastPage
            // 
            this.buttonLastPage.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonLastPage.Location = new System.Drawing.Point(904, 416);
            this.buttonLastPage.Name = "buttonLastPage";
            this.buttonLastPage.Size = new System.Drawing.Size(50, 30);
            this.buttonLastPage.TabIndex = 30;
            this.buttonLastPage.Text = "▶l";
            this.buttonLastPage.UseVisualStyleBackColor = true;
            // 
            // buttonNextPage
            // 
            this.buttonNextPage.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonNextPage.Location = new System.Drawing.Point(836, 416);
            this.buttonNextPage.Name = "buttonNextPage";
            this.buttonNextPage.Size = new System.Drawing.Size(50, 30);
            this.buttonNextPage.TabIndex = 29;
            this.buttonNextPage.Text = "▶";
            this.buttonNextPage.UseVisualStyleBackColor = true;
            // 
            // buttonPreviousPage
            // 
            this.buttonPreviousPage.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonPreviousPage.Location = new System.Drawing.Point(756, 416);
            this.buttonPreviousPage.Name = "buttonPreviousPage";
            this.buttonPreviousPage.Size = new System.Drawing.Size(50, 31);
            this.buttonPreviousPage.TabIndex = 28;
            this.buttonPreviousPage.Text = "◀";
            this.buttonPreviousPage.UseVisualStyleBackColor = true;
            // 
            // buttonFirstPage
            // 
            this.buttonFirstPage.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonFirstPage.Location = new System.Drawing.Point(689, 416);
            this.buttonFirstPage.Name = "buttonFirstPage";
            this.buttonFirstPage.Size = new System.Drawing.Size(50, 30);
            this.buttonFirstPage.TabIndex = 27;
            this.buttonFirstPage.Text = "l◀";
            this.buttonFirstPage.UseVisualStyleBackColor = true;
            // 
            // labelPage
            // 
            this.labelPage.AutoSize = true;
            this.labelPage.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelPage.Location = new System.Drawing.Point(367, 422);
            this.labelPage.Name = "labelPage";
            this.labelPage.Size = new System.Drawing.Size(70, 24);
            this.labelPage.TabIndex = 26;
            this.labelPage.Text = "ページ";
            // 
            // textBoxPage
            // 
            this.textBoxPage.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBoxPage.Location = new System.Drawing.Point(317, 415);
            this.textBoxPage.Name = "textBoxPage";
            this.textBoxPage.Size = new System.Drawing.Size(45, 31);
            this.textBoxPage.TabIndex = 25;
            this.textBoxPage.Text = "100";
            this.textBoxPage.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBoxPage.TextChanged += new System.EventHandler(this.textBoxPage_TextChanged);
            // 
            // UserControlPosition
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
            this.Name = "UserControlPosition";
            this.Size = new System.Drawing.Size(1670, 980);
            this.Load += new System.EventHandler(this.UserControlPosition_Load);
            this.panelHeader2.ResumeLayout(false);
            this.panelInput.ResumeLayout(false);
            this.panelInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader2;
        private System.Windows.Forms.Button buttonList;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Button buttonResist;
        private System.Windows.Forms.Panel panelInput;
        private System.Windows.Forms.Label labelPoID;
        private System.Windows.Forms.TextBox textBoxEmID;
        private System.Windows.Forms.TextBox textBoxPoName;
        private System.Windows.Forms.Label labelPoName;
        private System.Windows.Forms.CheckBox checkBoxPoFlag;
        private System.Windows.Forms.TextBox textBoxEmHidden;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button buttonPageSizeChange;
        private System.Windows.Forms.TextBox textBoxPageSize;
        private System.Windows.Forms.Label labelPageSize;
        private System.Windows.Forms.Button buttonLastPage;
        private System.Windows.Forms.Button buttonNextPage;
        private System.Windows.Forms.Button buttonPreviousPage;
        private System.Windows.Forms.Button buttonFirstPage;
        private System.Windows.Forms.Label labelPage;
        private System.Windows.Forms.TextBox textBoxPage;
        private System.Windows.Forms.Button button1;
    }
}
