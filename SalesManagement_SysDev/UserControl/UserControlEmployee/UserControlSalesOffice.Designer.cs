
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
            this.dataGridViewMaker = new System.Windows.Forms.DataGridView();
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
            this.panelHeader2.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.panelHeader2.Name = "panelHeader2";
            this.panelHeader2.Size = new System.Drawing.Size(2783, 195);
            this.panelHeader2.TabIndex = 2;
            // 
            // buttonNotList
            // 
            this.buttonNotList.BackColor = System.Drawing.Color.LightGreen;
            this.buttonNotList.Font = new System.Drawing.Font("MS UI Gothic", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonNotList.Location = new System.Drawing.Point(2158, 33);
            this.buttonNotList.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.buttonNotList.Name = "buttonNotList";
            this.buttonNotList.Size = new System.Drawing.Size(342, 120);
            this.buttonNotList.TabIndex = 4;
            this.buttonNotList.Text = "非表示リスト";
            this.buttonNotList.UseVisualStyleBackColor = false;
            // 
            // buttonList
            // 
            this.buttonList.BackColor = System.Drawing.Color.LightGreen;
            this.buttonList.Font = new System.Drawing.Font("MS UI Gothic", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonList.Location = new System.Drawing.Point(1678, 33);
            this.buttonList.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.buttonList.Name = "buttonList";
            this.buttonList.Size = new System.Drawing.Size(342, 120);
            this.buttonList.TabIndex = 3;
            this.buttonList.Text = "一覧表示";
            this.buttonList.UseVisualStyleBackColor = false;
            // 
            // buttonSearch
            // 
            this.buttonSearch.BackColor = System.Drawing.Color.LightGreen;
            this.buttonSearch.Font = new System.Drawing.Font("MS UI Gothic", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonSearch.Location = new System.Drawing.Point(1202, 33);
            this.buttonSearch.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(342, 120);
            this.buttonSearch.TabIndex = 2;
            this.buttonSearch.Text = "検索";
            this.buttonSearch.UseVisualStyleBackColor = false;
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.BackColor = System.Drawing.Color.LightGreen;
            this.buttonUpdate.Font = new System.Drawing.Font("MS UI Gothic", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonUpdate.Location = new System.Drawing.Point(708, 33);
            this.buttonUpdate.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(342, 120);
            this.buttonUpdate.TabIndex = 1;
            this.buttonUpdate.Text = "更新";
            this.buttonUpdate.UseVisualStyleBackColor = false;
            // 
            // buttonResist
            // 
            this.buttonResist.BackColor = System.Drawing.Color.LightGreen;
            this.buttonResist.Font = new System.Drawing.Font("MS UI Gothic", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonResist.Location = new System.Drawing.Point(203, 33);
            this.buttonResist.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.buttonResist.Name = "buttonResist";
            this.buttonResist.Size = new System.Drawing.Size(342, 120);
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
            this.panelInput.Location = new System.Drawing.Point(450, 204);
            this.panelInput.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.panelInput.Name = "panelInput";
            this.panelInput.Size = new System.Drawing.Size(1850, 288);
            this.panelInput.TabIndex = 8;
            // 
            // buttonClear
            // 
            this.buttonClear.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonClear.Location = new System.Drawing.Point(1675, 238);
            this.buttonClear.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(170, 45);
            this.buttonClear.TabIndex = 32;
            this.buttonClear.Text = "入力クリア";
            this.buttonClear.UseVisualStyleBackColor = true;
            // 
            // textBoxSoAddress
            // 
            this.textBoxSoAddress.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBoxSoAddress.Location = new System.Drawing.Point(507, 96);
            this.textBoxSoAddress.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.textBoxSoAddress.Name = "textBoxSoAddress";
            this.textBoxSoAddress.Size = new System.Drawing.Size(952, 39);
            this.textBoxSoAddress.TabIndex = 31;
            // 
            // labelSoAdress
            // 
            this.labelSoAdress.AutoSize = true;
            this.labelSoAdress.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.labelSoAdress.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelSoAdress.Location = new System.Drawing.Point(400, 99);
            this.labelSoAdress.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.labelSoAdress.Name = "labelSoAdress";
            this.labelSoAdress.Size = new System.Drawing.Size(87, 36);
            this.labelSoAdress.TabIndex = 30;
            this.labelSoAdress.Text = "住所";
            // 
            // textBoxMaHidden
            // 
            this.textBoxMaHidden.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBoxMaHidden.Location = new System.Drawing.Point(290, 164);
            this.textBoxMaHidden.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.textBoxMaHidden.Multiline = true;
            this.textBoxMaHidden.Name = "textBoxMaHidden";
            this.textBoxMaHidden.Size = new System.Drawing.Size(1169, 110);
            this.textBoxMaHidden.TabIndex = 20;
            // 
            // checkBoxMaFlag
            // 
            this.checkBoxMaFlag.AutoSize = true;
            this.checkBoxMaFlag.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.checkBoxMaFlag.Location = new System.Drawing.Point(27, 170);
            this.checkBoxMaFlag.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.checkBoxMaFlag.Name = "checkBoxMaFlag";
            this.checkBoxMaFlag.Size = new System.Drawing.Size(226, 40);
            this.checkBoxMaFlag.TabIndex = 18;
            this.checkBoxMaFlag.Text = "非表示フラグ";
            this.checkBoxMaFlag.UseVisualStyleBackColor = true;
            // 
            // textBoxSoPostal
            // 
            this.textBoxSoPostal.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBoxSoPostal.Location = new System.Drawing.Point(207, 93);
            this.textBoxSoPostal.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.textBoxSoPostal.Name = "textBoxSoPostal";
            this.textBoxSoPostal.Size = new System.Drawing.Size(149, 39);
            this.textBoxSoPostal.TabIndex = 29;
            // 
            // labelSoPostal
            // 
            this.labelSoPostal.AutoSize = true;
            this.labelSoPostal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.labelSoPostal.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelSoPostal.Location = new System.Drawing.Point(20, 96);
            this.labelSoPostal.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.labelSoPostal.Name = "labelSoPostal";
            this.labelSoPostal.Size = new System.Drawing.Size(159, 36);
            this.labelSoPostal.TabIndex = 28;
            this.labelSoPostal.Text = "郵便番号";
            // 
            // textBoxSoFAX
            // 
            this.textBoxSoFAX.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBoxSoFAX.Location = new System.Drawing.Point(1535, 15);
            this.textBoxSoFAX.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.textBoxSoFAX.Name = "textBoxSoFAX";
            this.textBoxSoFAX.Size = new System.Drawing.Size(254, 39);
            this.textBoxSoFAX.TabIndex = 27;
            // 
            // labelSoFAX
            // 
            this.labelSoFAX.AutoSize = true;
            this.labelSoFAX.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.labelSoFAX.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelSoFAX.Location = new System.Drawing.Point(1438, 21);
            this.labelSoFAX.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.labelSoFAX.Name = "labelSoFAX";
            this.labelSoFAX.Size = new System.Drawing.Size(80, 36);
            this.labelSoFAX.TabIndex = 26;
            this.labelSoFAX.Text = "FAX";
            // 
            // textBoxSoPhone
            // 
            this.textBoxSoPhone.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBoxSoPhone.Location = new System.Drawing.Point(1103, 18);
            this.textBoxSoPhone.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.textBoxSoPhone.Name = "textBoxSoPhone";
            this.textBoxSoPhone.Size = new System.Drawing.Size(254, 39);
            this.textBoxSoPhone.TabIndex = 25;
            // 
            // labelSoPhone
            // 
            this.labelSoPhone.AutoSize = true;
            this.labelSoPhone.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.labelSoPhone.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelSoPhone.Location = new System.Drawing.Point(917, 21);
            this.labelSoPhone.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.labelSoPhone.Name = "labelSoPhone";
            this.labelSoPhone.Size = new System.Drawing.Size(159, 36);
            this.labelSoPhone.TabIndex = 24;
            this.labelSoPhone.Text = "電話番号";
            // 
            // textBoxSoName
            // 
            this.textBoxSoName.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBoxSoName.Location = new System.Drawing.Point(473, 21);
            this.textBoxSoName.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.textBoxSoName.Name = "textBoxSoName";
            this.textBoxSoName.Size = new System.Drawing.Size(367, 39);
            this.textBoxSoName.TabIndex = 23;
            // 
            // labelSoName
            // 
            this.labelSoName.AutoSize = true;
            this.labelSoName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.labelSoName.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelSoName.Location = new System.Drawing.Point(287, 24);
            this.labelSoName.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.labelSoName.Name = "labelSoName";
            this.labelSoName.Size = new System.Drawing.Size(159, 36);
            this.labelSoName.TabIndex = 22;
            this.labelSoName.Text = "営業所名";
            // 
            // textBoxSoID
            // 
            this.textBoxSoID.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBoxSoID.Location = new System.Drawing.Point(173, 21);
            this.textBoxSoID.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.textBoxSoID.Name = "textBoxSoID";
            this.textBoxSoID.Size = new System.Drawing.Size(54, 39);
            this.textBoxSoID.TabIndex = 15;
            this.textBoxSoID.Text = "11";
            // 
            // labelSaID
            // 
            this.labelSaID.AutoSize = true;
            this.labelSaID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.labelSaID.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelSaID.Location = new System.Drawing.Point(20, 24);
            this.labelSaID.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.labelSaID.Name = "labelSaID";
            this.labelSaID.Size = new System.Drawing.Size(155, 36);
            this.labelSaID.TabIndex = 4;
            this.labelSaID.Text = "営業所ID";
            this.labelSaID.Click += new System.EventHandler(this.labelSaID_Click);
            // 
            // buttonPageSizeChange
            // 
            this.buttonPageSizeChange.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonPageSizeChange.Location = new System.Drawing.Point(2557, 536);
            this.buttonPageSizeChange.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.buttonPageSizeChange.Name = "buttonPageSizeChange";
            this.buttonPageSizeChange.Size = new System.Drawing.Size(165, 42);
            this.buttonPageSizeChange.TabIndex = 54;
            this.buttonPageSizeChange.Text = "行数変更";
            this.buttonPageSizeChange.UseVisualStyleBackColor = true;
            // 
            // textBoxPageSize
            // 
            this.textBoxPageSize.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBoxPageSize.Location = new System.Drawing.Point(2478, 538);
            this.textBoxPageSize.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.textBoxPageSize.Name = "textBoxPageSize";
            this.textBoxPageSize.Size = new System.Drawing.Size(46, 36);
            this.textBoxPageSize.TabIndex = 53;
            this.textBoxPageSize.Text = "20";
            // 
            // labelPageSize
            // 
            this.labelPageSize.AutoSize = true;
            this.labelPageSize.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelPageSize.Location = new System.Drawing.Point(2293, 546);
            this.labelPageSize.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.labelPageSize.Name = "labelPageSize";
            this.labelPageSize.Size = new System.Drawing.Size(158, 29);
            this.labelPageSize.TabIndex = 52;
            this.labelPageSize.Text = "1ページ行数";
            // 
            // buttonLastPage
            // 
            this.buttonLastPage.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonLastPage.Location = new System.Drawing.Point(1507, 524);
            this.buttonLastPage.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.buttonLastPage.Name = "buttonLastPage";
            this.buttonLastPage.Size = new System.Drawing.Size(83, 45);
            this.buttonLastPage.TabIndex = 51;
            this.buttonLastPage.Text = "▶l";
            this.buttonLastPage.UseVisualStyleBackColor = true;
            // 
            // buttonNextPage
            // 
            this.buttonNextPage.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonNextPage.Location = new System.Drawing.Point(1393, 524);
            this.buttonNextPage.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.buttonNextPage.Name = "buttonNextPage";
            this.buttonNextPage.Size = new System.Drawing.Size(83, 45);
            this.buttonNextPage.TabIndex = 50;
            this.buttonNextPage.Text = "▶";
            this.buttonNextPage.UseVisualStyleBackColor = true;
            // 
            // buttonPreviousPage
            // 
            this.buttonPreviousPage.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonPreviousPage.Location = new System.Drawing.Point(1260, 524);
            this.buttonPreviousPage.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.buttonPreviousPage.Name = "buttonPreviousPage";
            this.buttonPreviousPage.Size = new System.Drawing.Size(83, 46);
            this.buttonPreviousPage.TabIndex = 49;
            this.buttonPreviousPage.Text = "◀";
            this.buttonPreviousPage.UseVisualStyleBackColor = true;
            // 
            // buttonFirstPage
            // 
            this.buttonFirstPage.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonFirstPage.Location = new System.Drawing.Point(1148, 524);
            this.buttonFirstPage.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.buttonFirstPage.Name = "buttonFirstPage";
            this.buttonFirstPage.Size = new System.Drawing.Size(83, 45);
            this.buttonFirstPage.TabIndex = 48;
            this.buttonFirstPage.Text = "l◀";
            this.buttonFirstPage.UseVisualStyleBackColor = true;
            // 
            // labelPage
            // 
            this.labelPage.AutoSize = true;
            this.labelPage.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelPage.Location = new System.Drawing.Point(137, 534);
            this.labelPage.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.labelPage.Name = "labelPage";
            this.labelPage.Size = new System.Drawing.Size(103, 36);
            this.labelPage.TabIndex = 47;
            this.labelPage.Text = "ページ";
            // 
            // textBoxPage
            // 
            this.textBoxPage.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBoxPage.Location = new System.Drawing.Point(53, 525);
            this.textBoxPage.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.textBoxPage.Name = "textBoxPage";
            this.textBoxPage.Size = new System.Drawing.Size(72, 43);
            this.textBoxPage.TabIndex = 46;
            this.textBoxPage.Text = "100";
            this.textBoxPage.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // dataGridViewMaker
            // 
            this.dataGridViewMaker.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMaker.Location = new System.Drawing.Point(53, 579);
            this.dataGridViewMaker.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.dataGridViewMaker.Name = "dataGridViewMaker";
            this.dataGridViewMaker.RowHeadersWidth = 62;
            this.dataGridViewMaker.RowTemplate.Height = 21;
            this.dataGridViewMaker.Size = new System.Drawing.Size(2678, 854);
            this.dataGridViewMaker.TabIndex = 45;
            // 
            // UserControlSalesOffice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
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
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "UserControlSalesOffice";
            this.Size = new System.Drawing.Size(2783, 1470);
            this.Load += new System.EventHandler(this.UserControlSalesOffice_Load);
            this.panelHeader2.ResumeLayout(false);
            this.panelInput.ResumeLayout(false);
            this.panelInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMaker)).EndInit();
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
        private System.Windows.Forms.DataGridView dataGridViewMaker;
    }
}
