
namespace SalesManagement_SysDev
{
    partial class FormShipment
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.labelUserID = new System.Windows.Forms.Label();
            this.labelPosition = new System.Windows.Forms.Label();
            this.labelSalesOffice = new System.Windows.Forms.Label();
            this.labelUserName = new System.Windows.Forms.Label();
            this.labelDay = new System.Windows.Forms.Label();
            this.labelTime = new System.Windows.Forms.Label();
            this.labelShipment = new System.Windows.Forms.Label();
            this.buttonFormDel = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panelShipment = new System.Windows.Forms.Panel();
            this.buttonPageSizeChange = new System.Windows.Forms.Button();
            this.textBoxPageSize = new System.Windows.Forms.TextBox();
            this.dataGridViewSh = new System.Windows.Forms.DataGridView();
            this.labelPageSize = new System.Windows.Forms.Label();
            this.textBoxPage = new System.Windows.Forms.TextBox();
            this.buttonLastPage = new System.Windows.Forms.Button();
            this.labelPage = new System.Windows.Forms.Label();
            this.buttonNextPage = new System.Windows.Forms.Button();
            this.buttonFirstPage = new System.Windows.Forms.Button();
            this.buttonPreviousPage = new System.Windows.Forms.Button();
            this.panelInput = new System.Windows.Forms.Panel();
            this.dateTimePickerDateEnd = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.labelOut = new System.Windows.Forms.Label();
            this.dateTimePickerDateStart = new System.Windows.Forms.DateTimePicker();
            this.textBoxClName = new System.Windows.Forms.TextBox();
            this.textBoxShID = new System.Windows.Forms.TextBox();
            this.labelShID = new System.Windows.Forms.Label();
            this.checkBox1Hidden = new System.Windows.Forms.CheckBox();
            this.checkBoxStateFlag = new System.Windows.Forms.CheckBox();
            this.labelClName = new System.Windows.Forms.Label();
            this.buttonClear2 = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.textBoxShHidden = new System.Windows.Forms.TextBox();
            this.textBoxClID = new System.Windows.Forms.TextBox();
            this.labelClID = new System.Windows.Forms.Label();
            this.textBoxOrID = new System.Windows.Forms.TextBox();
            this.labelOrID = new System.Windows.Forms.Label();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.buttonHiddenList = new System.Windows.Forms.Button();
            this.buttonHidden = new System.Windows.Forms.Button();
            this.buttonList = new System.Windows.Forms.Button();
            this.buttonConfirm = new System.Windows.Forms.Button();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.buttonDetail = new System.Windows.Forms.Button();
            this.buttonLogout = new System.Windows.Forms.Button();
            this.userControlShipmentDetail1 = new SalesManagement_SysDev.UserControlShipmentDetail();
            this.panelHeader.SuspendLayout();
            this.panelShipment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSh)).BeginInit();
            this.panelInput.SuspendLayout();
            this.panelLeft.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.DarkGreen;
            this.panelHeader.Controls.Add(this.labelUserID);
            this.panelHeader.Controls.Add(this.labelPosition);
            this.panelHeader.Controls.Add(this.labelSalesOffice);
            this.panelHeader.Controls.Add(this.labelUserName);
            this.panelHeader.Controls.Add(this.labelDay);
            this.panelHeader.Controls.Add(this.labelTime);
            this.panelHeader.Controls.Add(this.labelShipment);
            this.panelHeader.Controls.Add(this.buttonFormDel);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Margin = new System.Windows.Forms.Padding(2);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1920, 100);
            this.panelHeader.TabIndex = 14;
            // 
            // labelUserID
            // 
            this.labelUserID.AutoSize = true;
            this.labelUserID.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelUserID.ForeColor = System.Drawing.Color.White;
            this.labelUserID.Location = new System.Drawing.Point(245, 14);
            this.labelUserID.Name = "labelUserID";
            this.labelUserID.Size = new System.Drawing.Size(146, 27);
            this.labelUserID.TabIndex = 13;
            this.labelUserID.Text = "ユーザーID：";
            // 
            // labelPosition
            // 
            this.labelPosition.AutoSize = true;
            this.labelPosition.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelPosition.ForeColor = System.Drawing.Color.White;
            this.labelPosition.Location = new System.Drawing.Point(12, 56);
            this.labelPosition.Name = "labelPosition";
            this.labelPosition.Size = new System.Drawing.Size(83, 27);
            this.labelPosition.TabIndex = 11;
            this.labelPosition.Text = "権限：";
            // 
            // labelSalesOffice
            // 
            this.labelSalesOffice.AutoSize = true;
            this.labelSalesOffice.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelSalesOffice.ForeColor = System.Drawing.Color.White;
            this.labelSalesOffice.Location = new System.Drawing.Point(12, 14);
            this.labelSalesOffice.Name = "labelSalesOffice";
            this.labelSalesOffice.Size = new System.Drawing.Size(180, 27);
            this.labelSalesOffice.TabIndex = 12;
            this.labelSalesOffice.Text = "和歌山営業所";
            // 
            // labelUserName
            // 
            this.labelUserName.AutoSize = true;
            this.labelUserName.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelUserName.ForeColor = System.Drawing.Color.White;
            this.labelUserName.Location = new System.Drawing.Point(245, 56);
            this.labelUserName.Name = "labelUserName";
            this.labelUserName.Size = new System.Drawing.Size(147, 27);
            this.labelUserName.TabIndex = 10;
            this.labelUserName.Text = "ユーザー名：";
            // 
            // labelDay
            // 
            this.labelDay.AutoSize = true;
            this.labelDay.Font = new System.Drawing.Font("MS UI Gothic", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelDay.ForeColor = System.Drawing.Color.White;
            this.labelDay.Location = new System.Drawing.Point(1382, 2);
            this.labelDay.Name = "labelDay";
            this.labelDay.Size = new System.Drawing.Size(252, 35);
            this.labelDay.TabIndex = 9;
            this.labelDay.Text = "2022/10/10(月)";
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.BackColor = System.Drawing.Color.DarkGreen;
            this.labelTime.Font = new System.Drawing.Font("MS UI Gothic", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelTime.ForeColor = System.Drawing.Color.White;
            this.labelTime.Location = new System.Drawing.Point(1422, 36);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(174, 64);
            this.labelTime.TabIndex = 8;
            this.labelTime.Text = "12:00";
            // 
            // labelShipment
            // 
            this.labelShipment.AutoSize = true;
            this.labelShipment.Font = new System.Drawing.Font("HGSｺﾞｼｯｸE", 39.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelShipment.ForeColor = System.Drawing.Color.White;
            this.labelShipment.Location = new System.Drawing.Point(694, 22);
            this.labelShipment.Name = "labelShipment";
            this.labelShipment.Size = new System.Drawing.Size(235, 53);
            this.labelShipment.TabIndex = 1;
            this.labelShipment.Text = "出荷管理";
            // 
            // buttonFormDel
            // 
            this.buttonFormDel.BackColor = System.Drawing.Color.DarkGreen;
            this.buttonFormDel.Font = new System.Drawing.Font("MS UI Gothic", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonFormDel.ForeColor = System.Drawing.Color.White;
            this.buttonFormDel.Location = new System.Drawing.Point(1720, 0);
            this.buttonFormDel.Name = "buttonFormDel";
            this.buttonFormDel.Size = new System.Drawing.Size(200, 100);
            this.buttonFormDel.TabIndex = 0;
            this.buttonFormDel.Text = "✕閉じる";
            this.buttonFormDel.UseVisualStyleBackColor = false;
            this.buttonFormDel.Click += new System.EventHandler(this.buttonFormDel_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panelShipment
            // 
            this.panelShipment.Controls.Add(this.buttonPageSizeChange);
            this.panelShipment.Controls.Add(this.textBoxPageSize);
            this.panelShipment.Controls.Add(this.dataGridViewSh);
            this.panelShipment.Controls.Add(this.labelPageSize);
            this.panelShipment.Controls.Add(this.textBoxPage);
            this.panelShipment.Controls.Add(this.buttonLastPage);
            this.panelShipment.Controls.Add(this.labelPage);
            this.panelShipment.Controls.Add(this.buttonNextPage);
            this.panelShipment.Controls.Add(this.buttonFirstPage);
            this.panelShipment.Controls.Add(this.buttonPreviousPage);
            this.panelShipment.Controls.Add(this.panelInput);
            this.panelShipment.Controls.Add(this.panelLeft);
            this.panelShipment.Location = new System.Drawing.Point(0, 100);
            this.panelShipment.Name = "panelShipment";
            this.panelShipment.Size = new System.Drawing.Size(1920, 980);
            this.panelShipment.TabIndex = 15;
            // 
            // buttonPageSizeChange
            // 
            this.buttonPageSizeChange.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonPageSizeChange.Location = new System.Drawing.Point(1733, 266);
            this.buttonPageSizeChange.Name = "buttonPageSizeChange";
            this.buttonPageSizeChange.Size = new System.Drawing.Size(99, 28);
            this.buttonPageSizeChange.TabIndex = 19;
            this.buttonPageSizeChange.Text = "行数変更";
            this.buttonPageSizeChange.UseVisualStyleBackColor = true;
            // 
            // textBoxPageSize
            // 
            this.textBoxPageSize.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBoxPageSize.Location = new System.Drawing.Point(1694, 268);
            this.textBoxPageSize.Name = "textBoxPageSize";
            this.textBoxPageSize.Size = new System.Drawing.Size(33, 26);
            this.textBoxPageSize.TabIndex = 18;
            this.textBoxPageSize.Text = "20";
            // 
            // dataGridViewSh
            // 
            this.dataGridViewSh.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSh.Location = new System.Drawing.Point(293, 296);
            this.dataGridViewSh.Name = "dataGridViewSh";
            this.dataGridViewSh.RowTemplate.Height = 21;
            this.dataGridViewSh.Size = new System.Drawing.Size(1552, 605);
            this.dataGridViewSh.TabIndex = 21;
            this.dataGridViewSh.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewOrder_CellContentClick);
            // 
            // labelPageSize
            // 
            this.labelPageSize.AutoSize = true;
            this.labelPageSize.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelPageSize.Location = new System.Drawing.Point(1583, 273);
            this.labelPageSize.Name = "labelPageSize";
            this.labelPageSize.Size = new System.Drawing.Size(105, 19);
            this.labelPageSize.TabIndex = 20;
            this.labelPageSize.Text = "1ページ行数";
            // 
            // textBoxPage
            // 
            this.textBoxPage.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBoxPage.Location = new System.Drawing.Point(295, 263);
            this.textBoxPage.Name = "textBoxPage";
            this.textBoxPage.Size = new System.Drawing.Size(45, 31);
            this.textBoxPage.TabIndex = 13;
            this.textBoxPage.Text = "1";
            this.textBoxPage.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // buttonLastPage
            // 
            this.buttonLastPage.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonLastPage.Location = new System.Drawing.Point(1155, 263);
            this.buttonLastPage.Name = "buttonLastPage";
            this.buttonLastPage.Size = new System.Drawing.Size(50, 30);
            this.buttonLastPage.TabIndex = 17;
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
            this.labelPage.TabIndex = 12;
            this.labelPage.Text = "ページ";
            // 
            // buttonNextPage
            // 
            this.buttonNextPage.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonNextPage.Location = new System.Drawing.Point(1087, 263);
            this.buttonNextPage.Name = "buttonNextPage";
            this.buttonNextPage.Size = new System.Drawing.Size(50, 30);
            this.buttonNextPage.TabIndex = 16;
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
            this.buttonFirstPage.TabIndex = 14;
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
            this.buttonPreviousPage.TabIndex = 15;
            this.buttonPreviousPage.Text = "◀";
            this.buttonPreviousPage.UseVisualStyleBackColor = true;
            // 
            // panelInput
            // 
            this.panelInput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.panelInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelInput.Controls.Add(this.dateTimePickerDateEnd);
            this.panelInput.Controls.Add(this.label1);
            this.panelInput.Controls.Add(this.labelOut);
            this.panelInput.Controls.Add(this.dateTimePickerDateStart);
            this.panelInput.Controls.Add(this.textBoxClName);
            this.panelInput.Controls.Add(this.textBoxShID);
            this.panelInput.Controls.Add(this.labelShID);
            this.panelInput.Controls.Add(this.checkBox1Hidden);
            this.panelInput.Controls.Add(this.checkBoxStateFlag);
            this.panelInput.Controls.Add(this.labelClName);
            this.panelInput.Controls.Add(this.buttonClear2);
            this.panelInput.Controls.Add(this.buttonClear);
            this.panelInput.Controls.Add(this.textBoxShHidden);
            this.panelInput.Controls.Add(this.textBoxClID);
            this.panelInput.Controls.Add(this.labelClID);
            this.panelInput.Controls.Add(this.textBoxOrID);
            this.panelInput.Controls.Add(this.labelOrID);
            this.panelInput.Location = new System.Drawing.Point(293, 52);
            this.panelInput.Name = "panelInput";
            this.panelInput.Size = new System.Drawing.Size(1552, 173);
            this.panelInput.TabIndex = 11;
            // 
            // dateTimePickerDateEnd
            // 
            this.dateTimePickerDateEnd.Checked = false;
            this.dateTimePickerDateEnd.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.dateTimePickerDateEnd.Location = new System.Drawing.Point(1271, 97);
            this.dateTimePickerDateEnd.Name = "dateTimePickerDateEnd";
            this.dateTimePickerDateEnd.ShowCheckBox = true;
            this.dateTimePickerDateEnd.Size = new System.Drawing.Size(198, 26);
            this.dateTimePickerDateEnd.TabIndex = 84;
            this.dateTimePickerDateEnd.Value = new System.DateTime(2022, 12, 8, 0, 0, 0, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(1038, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 13);
            this.label1.TabIndex = 83;
            this.label1.Text = "※検索用(範囲指定)";
            // 
            // labelOut
            // 
            this.labelOut.AutoSize = true;
            this.labelOut.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelOut.Location = new System.Drawing.Point(1241, 101);
            this.labelOut.Name = "labelOut";
            this.labelOut.Size = new System.Drawing.Size(32, 21);
            this.labelOut.TabIndex = 82;
            this.labelOut.Text = "～";
            // 
            // dateTimePickerDateStart
            // 
            this.dateTimePickerDateStart.Checked = false;
            this.dateTimePickerDateStart.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.dateTimePickerDateStart.Location = new System.Drawing.Point(1040, 97);
            this.dateTimePickerDateStart.Name = "dateTimePickerDateStart";
            this.dateTimePickerDateStart.ShowCheckBox = true;
            this.dateTimePickerDateStart.Size = new System.Drawing.Size(198, 26);
            this.dateTimePickerDateStart.TabIndex = 81;
            this.dateTimePickerDateStart.Value = new System.DateTime(2022, 12, 8, 0, 0, 0, 0);
            // 
            // textBoxClName
            // 
            this.textBoxClName.BackColor = System.Drawing.Color.Silver;
            this.textBoxClName.Enabled = false;
            this.textBoxClName.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBoxClName.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.textBoxClName.Location = new System.Drawing.Point(757, 19);
            this.textBoxClName.Name = "textBoxClName";
            this.textBoxClName.Size = new System.Drawing.Size(246, 27);
            this.textBoxClName.TabIndex = 68;
            // 
            // textBoxShID
            // 
            this.textBoxShID.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBoxShID.Location = new System.Drawing.Point(99, 16);
            this.textBoxShID.Name = "textBoxShID";
            this.textBoxShID.Size = new System.Drawing.Size(77, 28);
            this.textBoxShID.TabIndex = 0;
            // 
            // labelShID
            // 
            this.labelShID.AutoSize = true;
            this.labelShID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.labelShID.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelShID.Location = new System.Drawing.Point(13, 18);
            this.labelShID.Name = "labelShID";
            this.labelShID.Size = new System.Drawing.Size(80, 24);
            this.labelShID.TabIndex = 67;
            this.labelShID.Text = "出荷ID";
            // 
            // checkBox1Hidden
            // 
            this.checkBox1Hidden.AutoSize = true;
            this.checkBox1Hidden.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.checkBox1Hidden.Location = new System.Drawing.Point(230, 80);
            this.checkBox1Hidden.Name = "checkBox1Hidden";
            this.checkBox1Hidden.Size = new System.Drawing.Size(149, 28);
            this.checkBox1Hidden.TabIndex = 7;
            this.checkBox1Hidden.Text = "非表示理由";
            this.checkBox1Hidden.UseVisualStyleBackColor = true;
            this.checkBox1Hidden.CheckedChanged += new System.EventHandler(this.checkBox1Hidden_CheckedChanged);
            // 
            // checkBoxStateFlag
            // 
            this.checkBoxStateFlag.AutoSize = true;
            this.checkBoxStateFlag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.checkBoxStateFlag.Font = new System.Drawing.Font("MS UI Gothic", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.checkBoxStateFlag.ForeColor = System.Drawing.Color.Red;
            this.checkBoxStateFlag.Location = new System.Drawing.Point(17, 76);
            this.checkBoxStateFlag.Name = "checkBoxStateFlag";
            this.checkBoxStateFlag.Size = new System.Drawing.Size(152, 33);
            this.checkBoxStateFlag.TabIndex = 6;
            this.checkBoxStateFlag.Text = "出荷確定";
            this.checkBoxStateFlag.UseVisualStyleBackColor = false;
            // 
            // labelClName
            // 
            this.labelClName.AutoSize = true;
            this.labelClName.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelClName.Location = new System.Drawing.Point(669, 20);
            this.labelClName.Name = "labelClName";
            this.labelClName.Size = new System.Drawing.Size(82, 24);
            this.labelClName.TabIndex = 50;
            this.labelClName.Text = "顧客名";
            // 
            // buttonClear2
            // 
            this.buttonClear2.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonClear2.Location = new System.Drawing.Point(1447, 140);
            this.buttonClear2.Name = "buttonClear2";
            this.buttonClear2.Size = new System.Drawing.Size(102, 30);
            this.buttonClear2.TabIndex = 9;
            this.buttonClear2.Text = "入力クリア";
            this.buttonClear2.UseVisualStyleBackColor = true;
            this.buttonClear2.Click += new System.EventHandler(this.buttonClear2_Click);
            // 
            // buttonClear
            // 
            this.buttonClear.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonClear.Location = new System.Drawing.Point(1444, 192);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(102, 30);
            this.buttonClear.TabIndex = 10;
            this.buttonClear.Text = "入力クリア";
            this.buttonClear.UseVisualStyleBackColor = true;
            // 
            // textBoxShHidden
            // 
            this.textBoxShHidden.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBoxShHidden.Location = new System.Drawing.Point(381, 79);
            this.textBoxShHidden.Multiline = true;
            this.textBoxShHidden.Name = "textBoxShHidden";
            this.textBoxShHidden.Size = new System.Drawing.Size(622, 84);
            this.textBoxShHidden.TabIndex = 8;
            // 
            // textBoxClID
            // 
            this.textBoxClID.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBoxClID.Location = new System.Drawing.Point(541, 18);
            this.textBoxClID.Name = "textBoxClID";
            this.textBoxClID.Size = new System.Drawing.Size(77, 28);
            this.textBoxClID.TabIndex = 4;
            // 
            // labelClID
            // 
            this.labelClID.AutoSize = true;
            this.labelClID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.labelClID.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelClID.Location = new System.Drawing.Point(455, 20);
            this.labelClID.Name = "labelClID";
            this.labelClID.Size = new System.Drawing.Size(80, 24);
            this.labelClID.TabIndex = 12;
            this.labelClID.Text = "顧客ID";
            // 
            // textBoxOrID
            // 
            this.textBoxOrID.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBoxOrID.Location = new System.Drawing.Point(312, 20);
            this.textBoxOrID.Name = "textBoxOrID";
            this.textBoxOrID.Size = new System.Drawing.Size(77, 28);
            this.textBoxOrID.TabIndex = 1;
            // 
            // labelOrID
            // 
            this.labelOrID.AutoSize = true;
            this.labelOrID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.labelOrID.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelOrID.Location = new System.Drawing.Point(226, 22);
            this.labelOrID.Name = "labelOrID";
            this.labelOrID.Size = new System.Drawing.Size(80, 24);
            this.labelOrID.TabIndex = 4;
            this.labelOrID.Text = "受注ID";
            // 
            // panelLeft
            // 
            this.panelLeft.BackColor = System.Drawing.Color.Honeydew;
            this.panelLeft.Controls.Add(this.buttonHiddenList);
            this.panelLeft.Controls.Add(this.buttonHidden);
            this.panelLeft.Controls.Add(this.buttonList);
            this.panelLeft.Controls.Add(this.buttonConfirm);
            this.panelLeft.Controls.Add(this.buttonSearch);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Margin = new System.Windows.Forms.Padding(2);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(250, 980);
            this.panelLeft.TabIndex = 10;
            // 
            // buttonHiddenList
            // 
            this.buttonHiddenList.BackColor = System.Drawing.Color.White;
            this.buttonHiddenList.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.buttonHiddenList.FlatAppearance.BorderSize = 4;
            this.buttonHiddenList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonHiddenList.Font = new System.Drawing.Font("MS UI Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonHiddenList.Location = new System.Drawing.Point(25, 435);
            this.buttonHiddenList.Name = "buttonHiddenList";
            this.buttonHiddenList.Size = new System.Drawing.Size(200, 80);
            this.buttonHiddenList.TabIndex = 4;
            this.buttonHiddenList.Text = "非表示リスト";
            this.buttonHiddenList.UseVisualStyleBackColor = false;
            this.buttonHiddenList.Click += new System.EventHandler(this.buttonHiddenList_Click);
            // 
            // buttonHidden
            // 
            this.buttonHidden.BackColor = System.Drawing.Color.White;
            this.buttonHidden.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.buttonHidden.FlatAppearance.BorderSize = 4;
            this.buttonHidden.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonHidden.Font = new System.Drawing.Font("MS UI Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonHidden.Location = new System.Drawing.Point(25, 225);
            this.buttonHidden.Name = "buttonHidden";
            this.buttonHidden.Size = new System.Drawing.Size(200, 80);
            this.buttonHidden.TabIndex = 2;
            this.buttonHidden.Text = "非表示";
            this.buttonHidden.UseVisualStyleBackColor = false;
            // 
            // buttonList
            // 
            this.buttonList.BackColor = System.Drawing.Color.White;
            this.buttonList.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.buttonList.FlatAppearance.BorderSize = 4;
            this.buttonList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonList.Font = new System.Drawing.Font("MS UI Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonList.Location = new System.Drawing.Point(25, 330);
            this.buttonList.Name = "buttonList";
            this.buttonList.Size = new System.Drawing.Size(200, 80);
            this.buttonList.TabIndex = 3;
            this.buttonList.Text = "一覧表示";
            this.buttonList.UseVisualStyleBackColor = false;
            this.buttonList.Click += new System.EventHandler(this.buttonList_Click);
            // 
            // buttonConfirm
            // 
            this.buttonConfirm.BackColor = System.Drawing.Color.White;
            this.buttonConfirm.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.buttonConfirm.FlatAppearance.BorderSize = 4;
            this.buttonConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonConfirm.Font = new System.Drawing.Font("MS UI Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonConfirm.Location = new System.Drawing.Point(25, 15);
            this.buttonConfirm.Name = "buttonConfirm";
            this.buttonConfirm.Size = new System.Drawing.Size(200, 80);
            this.buttonConfirm.TabIndex = 0;
            this.buttonConfirm.Text = "確定";
            this.buttonConfirm.UseCompatibleTextRendering = true;
            this.buttonConfirm.UseVisualStyleBackColor = false;
            this.buttonConfirm.Click += new System.EventHandler(this.buttonConfirm_Click);
            // 
            // buttonSearch
            // 
            this.buttonSearch.BackColor = System.Drawing.Color.White;
            this.buttonSearch.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.buttonSearch.FlatAppearance.BorderSize = 4;
            this.buttonSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSearch.Font = new System.Drawing.Font("MS UI Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonSearch.Location = new System.Drawing.Point(25, 120);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(200, 80);
            this.buttonSearch.TabIndex = 1;
            this.buttonSearch.Text = "検索";
            this.buttonSearch.UseVisualStyleBackColor = false;
            // 
            // buttonDetail
            // 
            this.buttonDetail.BackColor = System.Drawing.Color.LightGreen;
            this.buttonDetail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDetail.Font = new System.Drawing.Font("MS UI Gothic", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonDetail.Location = new System.Drawing.Point(0, 901);
            this.buttonDetail.Name = "buttonDetail";
            this.buttonDetail.Size = new System.Drawing.Size(250, 100);
            this.buttonDetail.TabIndex = 17;
            this.buttonDetail.Text = "出荷詳細";
            this.buttonDetail.UseVisualStyleBackColor = false;
            this.buttonDetail.Click += new System.EventHandler(this.buttonDetail_Click);
            // 
            // buttonLogout
            // 
            this.buttonLogout.BackColor = System.Drawing.Color.DarkGreen;
            this.buttonLogout.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonLogout.Font = new System.Drawing.Font("MS UI Gothic", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonLogout.ForeColor = System.Drawing.Color.White;
            this.buttonLogout.Location = new System.Drawing.Point(0, 1000);
            this.buttonLogout.Name = "buttonLogout";
            this.buttonLogout.Size = new System.Drawing.Size(250, 80);
            this.buttonLogout.TabIndex = 18;
            this.buttonLogout.TabStop = false;
            this.buttonLogout.Text = "ログアウト";
            this.buttonLogout.UseVisualStyleBackColor = false;
            // 
            // userControlShipmentDetail1
            // 
            this.userControlShipmentDetail1.BackColor = System.Drawing.Color.Honeydew;
            this.userControlShipmentDetail1.Location = new System.Drawing.Point(0, 100);
            this.userControlShipmentDetail1.Name = "userControlShipmentDetail1";
            this.userControlShipmentDetail1.Size = new System.Drawing.Size(1920, 980);
            this.userControlShipmentDetail1.TabIndex = 19;
            // 
            // FormShipment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Honeydew;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.buttonDetail);
            this.Controls.Add(this.buttonLogout);
            this.Controls.Add(this.panelShipment);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.userControlShipmentDetail1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormShipment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "出荷管理";
            this.Load += new System.EventHandler(this.FormShipment_Load);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelShipment.ResumeLayout(false);
            this.panelShipment.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSh)).EndInit();
            this.panelInput.ResumeLayout(false);
            this.panelInput.PerformLayout();
            this.panelLeft.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label labelUserID;
        private System.Windows.Forms.Label labelPosition;
        private System.Windows.Forms.Label labelSalesOffice;
        private System.Windows.Forms.Label labelUserName;
        private System.Windows.Forms.Label labelDay;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.Label labelShipment;
        private System.Windows.Forms.Button buttonFormDel;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panelShipment;
        private System.Windows.Forms.Button buttonPageSizeChange;
        private System.Windows.Forms.TextBox textBoxPageSize;
        private System.Windows.Forms.DataGridView dataGridViewSh;
        private System.Windows.Forms.Label labelPageSize;
        private System.Windows.Forms.TextBox textBoxPage;
        private System.Windows.Forms.Button buttonLastPage;
        private System.Windows.Forms.Label labelPage;
        private System.Windows.Forms.Button buttonNextPage;
        private System.Windows.Forms.Button buttonFirstPage;
        private System.Windows.Forms.Button buttonPreviousPage;
        private System.Windows.Forms.Panel panelInput;
        private System.Windows.Forms.TextBox textBoxShID;
        private System.Windows.Forms.Label labelShID;
        private System.Windows.Forms.CheckBox checkBox1Hidden;
        private System.Windows.Forms.CheckBox checkBoxStateFlag;
        private System.Windows.Forms.Label labelClName;
        private System.Windows.Forms.Button buttonClear2;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.TextBox textBoxShHidden;
        private System.Windows.Forms.TextBox textBoxClID;
        private System.Windows.Forms.Label labelClID;
        private System.Windows.Forms.TextBox textBoxOrID;
        private System.Windows.Forms.Label labelOrID;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Button buttonHiddenList;
        private System.Windows.Forms.Button buttonHidden;
        private System.Windows.Forms.Button buttonList;
        private System.Windows.Forms.Button buttonConfirm;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.Button buttonDetail;
        private System.Windows.Forms.Button buttonLogout;
        private UserControlShipmentDetail userControlShipmentDetail1;
        private System.Windows.Forms.TextBox textBoxClName;
        private System.Windows.Forms.DateTimePicker dateTimePickerDateEnd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelOut;
        private System.Windows.Forms.DateTimePicker dateTimePickerDateStart;
    }
}