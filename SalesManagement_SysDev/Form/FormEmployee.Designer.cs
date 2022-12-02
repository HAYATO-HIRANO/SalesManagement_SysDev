namespace SalesManagement_SysDev
{
    partial class FormEmployee
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.labelUserID = new System.Windows.Forms.Label();
            this.labelPosition = new System.Windows.Forms.Label();
            this.labelSalesOffice = new System.Windows.Forms.Label();
            this.labelUserName = new System.Windows.Forms.Label();
            this.labelDay = new System.Windows.Forms.Label();
            this.labelTime = new System.Windows.Forms.Label();
            this.labelEmployee = new System.Windows.Forms.Label();
            this.buttonFormDel = new System.Windows.Forms.Button();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.buttonHiddenList = new System.Windows.Forms.Button();
            this.buttonList = new System.Windows.Forms.Button();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.buttonRegist = new System.Windows.Forms.Button();
            this.buttonSetting = new System.Windows.Forms.Button();
            this.buttonLogout = new System.Windows.Forms.Button();
            this.panelSetting = new System.Windows.Forms.Panel();
            this.buttonSalesOffice = new System.Windows.Forms.Button();
            this.buttonPosition = new System.Windows.Forms.Button();
            this.panelInput = new System.Windows.Forms.Panel();
            this.checkBoxEmFlag = new System.Windows.Forms.CheckBox();
            this.dateTimePickerHiredate = new System.Windows.Forms.DateTimePicker();
            this.comboBoxPoID = new System.Windows.Forms.ComboBox();
            this.comboBoxSoID = new System.Windows.Forms.ComboBox();
            this.textBoxEmHidden = new System.Windows.Forms.TextBox();
            this.textBoxEmPhone = new System.Windows.Forms.TextBox();
            this.textBoxEmPassword = new System.Windows.Forms.TextBox();
            this.textBoxEmName = new System.Windows.Forms.TextBox();
            this.textBoxEmID = new System.Windows.Forms.TextBox();
            this.labelPhone = new System.Windows.Forms.Label();
            this.labelPassword = new System.Windows.Forms.Label();
            this.labelEmHiredate = new System.Windows.Forms.Label();
            this.labelPoID = new System.Windows.Forms.Label();
            this.labelSoID = new System.Windows.Forms.Label();
            this.labelEmName = new System.Windows.Forms.Label();
            this.labelEmID = new System.Windows.Forms.Label();
            this.dataGridViewEmployee = new System.Windows.Forms.DataGridView();
            this.buttonPageSizeChange = new System.Windows.Forms.Button();
            this.textBoxPageSize = new System.Windows.Forms.TextBox();
            this.labelPageSize = new System.Windows.Forms.Label();
            this.buttonLastPage = new System.Windows.Forms.Button();
            this.buttonNextPage = new System.Windows.Forms.Button();
            this.buttonPreviousPage = new System.Windows.Forms.Button();
            this.buttonFirstPage = new System.Windows.Forms.Button();
            this.labelPage = new System.Windows.Forms.Label();
            this.textBoxPage = new System.Windows.Forms.TextBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.panelEmployee = new System.Windows.Forms.Panel();
            this.userControlSalesOffice1 = new SalesManagement_SysDev.UserControlSalesOffice();
            this.userControlPosition1 = new SalesManagement_SysDev.UserControlPosition();
            this.panel3.SuspendLayout();
            this.panelHeader.SuspendLayout();
            this.panelLeft.SuspendLayout();
            this.panelSetting.SuspendLayout();
            this.panelInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEmployee)).BeginInit();
            this.panelEmployee.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.DarkGreen;
            this.panel3.Controls.Add(this.panelHeader);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1920, 100);
            this.panel3.TabIndex = 3;
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
            this.panelHeader.Controls.Add(this.labelEmployee);
            this.panelHeader.Controls.Add(this.buttonFormDel);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Margin = new System.Windows.Forms.Padding(2);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1920, 100);
            this.panelHeader.TabIndex = 13;
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
            // labelEmployee
            // 
            this.labelEmployee.AutoSize = true;
            this.labelEmployee.Font = new System.Drawing.Font("HGSｺﾞｼｯｸE", 39.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelEmployee.ForeColor = System.Drawing.Color.White;
            this.labelEmployee.Location = new System.Drawing.Point(694, 22);
            this.labelEmployee.Name = "labelEmployee";
            this.labelEmployee.Size = new System.Drawing.Size(235, 53);
            this.labelEmployee.TabIndex = 1;
            this.labelEmployee.Text = "社員管理";
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
            this.buttonFormDel.Click += new System.EventHandler(this.buttonFormDel_Click_1);
            // 
            // panelLeft
            // 
            this.panelLeft.BackColor = System.Drawing.Color.Honeydew;
            this.panelLeft.Controls.Add(this.buttonHiddenList);
            this.panelLeft.Controls.Add(this.buttonList);
            this.panelLeft.Controls.Add(this.buttonUpdate);
            this.panelLeft.Controls.Add(this.buttonSearch);
            this.panelLeft.Controls.Add(this.buttonRegist);
            this.panelLeft.Location = new System.Drawing.Point(0, 100);
            this.panelLeft.Margin = new System.Windows.Forms.Padding(2);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(250, 980);
            this.panelLeft.TabIndex = 4;
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
            this.buttonHiddenList.TabIndex = 40;
            this.buttonHiddenList.Text = "非表示リスト";
            this.buttonHiddenList.UseVisualStyleBackColor = false;
            this.buttonHiddenList.Click += new System.EventHandler(this.buttonHiddenList_Click);
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
            this.buttonList.TabIndex = 25;
            this.buttonList.Text = "一覧表示";
            this.buttonList.UseVisualStyleBackColor = false;
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.BackColor = System.Drawing.Color.White;
            this.buttonUpdate.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.buttonUpdate.FlatAppearance.BorderSize = 4;
            this.buttonUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonUpdate.Font = new System.Drawing.Font("MS UI Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonUpdate.Location = new System.Drawing.Point(25, 120);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(200, 80);
            this.buttonUpdate.TabIndex = 2;
            this.buttonUpdate.Text = "更新";
            this.buttonUpdate.UseVisualStyleBackColor = false;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // buttonSearch
            // 
            this.buttonSearch.BackColor = System.Drawing.Color.White;
            this.buttonSearch.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.buttonSearch.FlatAppearance.BorderSize = 4;
            this.buttonSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSearch.Font = new System.Drawing.Font("MS UI Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonSearch.Location = new System.Drawing.Point(25, 225);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(200, 80);
            this.buttonSearch.TabIndex = 1;
            this.buttonSearch.Text = "検索";
            this.buttonSearch.UseVisualStyleBackColor = false;
            // 
            // buttonRegist
            // 
            this.buttonRegist.BackColor = System.Drawing.Color.White;
            this.buttonRegist.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.buttonRegist.FlatAppearance.BorderSize = 4;
            this.buttonRegist.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRegist.Font = new System.Drawing.Font("MS UI Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonRegist.Location = new System.Drawing.Point(25, 15);
            this.buttonRegist.Name = "buttonRegist";
            this.buttonRegist.Size = new System.Drawing.Size(200, 80);
            this.buttonRegist.TabIndex = 0;
            this.buttonRegist.Text = "登録";
            this.buttonRegist.UseVisualStyleBackColor = false;
            this.buttonRegist.Click += new System.EventHandler(this.buttonRegist_Click);
            // 
            // buttonSetting
            // 
            this.buttonSetting.BackColor = System.Drawing.Color.LightGreen;
            this.buttonSetting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSetting.Font = new System.Drawing.Font("MS UI Gothic", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonSetting.Location = new System.Drawing.Point(0, 901);
            this.buttonSetting.Name = "buttonSetting";
            this.buttonSetting.Size = new System.Drawing.Size(250, 100);
            this.buttonSetting.TabIndex = 26;
            this.buttonSetting.Text = "設定";
            this.buttonSetting.UseVisualStyleBackColor = false;
            this.buttonSetting.Click += new System.EventHandler(this.buttonSetting_Click);
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
            this.buttonLogout.TabIndex = 7;
            this.buttonLogout.Text = "ログアウト";
            this.buttonLogout.UseVisualStyleBackColor = false;
            this.buttonLogout.Click += new System.EventHandler(this.buttonLogout_Click);
            // 
            // panelSetting
            // 
            this.panelSetting.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.panelSetting.Controls.Add(this.buttonSalesOffice);
            this.panelSetting.Controls.Add(this.buttonPosition);
            this.panelSetting.Location = new System.Drawing.Point(0, 100);
            this.panelSetting.Name = "panelSetting";
            this.panelSetting.Size = new System.Drawing.Size(250, 802);
            this.panelSetting.TabIndex = 25;
            this.panelSetting.Paint += new System.Windows.Forms.PaintEventHandler(this.panelSetting_Paint);
            // 
            // buttonSalesOffice
            // 
            this.buttonSalesOffice.BackColor = System.Drawing.Color.LightGreen;
            this.buttonSalesOffice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSalesOffice.Font = new System.Drawing.Font("MS UI Gothic", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonSalesOffice.Location = new System.Drawing.Point(0, 129);
            this.buttonSalesOffice.Name = "buttonSalesOffice";
            this.buttonSalesOffice.Size = new System.Drawing.Size(250, 130);
            this.buttonSalesOffice.TabIndex = 2;
            this.buttonSalesOffice.Text = "営業所管理";
            this.buttonSalesOffice.UseVisualStyleBackColor = false;
            this.buttonSalesOffice.Click += new System.EventHandler(this.buttonSalesOffice_Click);
            // 
            // buttonPosition
            // 
            this.buttonPosition.BackColor = System.Drawing.Color.LightGreen;
            this.buttonPosition.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPosition.Font = new System.Drawing.Font("MS UI Gothic", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonPosition.Location = new System.Drawing.Point(0, 0);
            this.buttonPosition.Name = "buttonPosition";
            this.buttonPosition.Size = new System.Drawing.Size(250, 130);
            this.buttonPosition.TabIndex = 1;
            this.buttonPosition.Text = "役職管理";
            this.buttonPosition.UseVisualStyleBackColor = false;
            this.buttonPosition.Click += new System.EventHandler(this.buttonPosition_Click);
            // 
            // panelInput
            // 
            this.panelInput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.panelInput.Controls.Add(this.checkBoxEmFlag);
            this.panelInput.Controls.Add(this.dateTimePickerHiredate);
            this.panelInput.Controls.Add(this.comboBoxPoID);
            this.panelInput.Controls.Add(this.comboBoxSoID);
            this.panelInput.Controls.Add(this.textBoxEmHidden);
            this.panelInput.Controls.Add(this.textBoxEmPhone);
            this.panelInput.Controls.Add(this.textBoxEmPassword);
            this.panelInput.Controls.Add(this.textBoxEmName);
            this.panelInput.Controls.Add(this.textBoxEmID);
            this.panelInput.Controls.Add(this.labelPhone);
            this.panelInput.Controls.Add(this.labelPassword);
            this.panelInput.Controls.Add(this.labelEmHiredate);
            this.panelInput.Controls.Add(this.labelPoID);
            this.panelInput.Controls.Add(this.labelSoID);
            this.panelInput.Controls.Add(this.labelEmName);
            this.panelInput.Controls.Add(this.labelEmID);
            this.panelInput.Location = new System.Drawing.Point(54, 36);
            this.panelInput.Name = "panelInput";
            this.panelInput.Size = new System.Drawing.Size(1552, 144);
            this.panelInput.TabIndex = 6;
            this.panelInput.Paint += new System.Windows.Forms.PaintEventHandler(this.panel4_Paint);
            // 
            // checkBoxEmFlag
            // 
            this.checkBoxEmFlag.AutoSize = true;
            this.checkBoxEmFlag.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.checkBoxEmFlag.Location = new System.Drawing.Point(658, 73);
            this.checkBoxEmFlag.Name = "checkBoxEmFlag";
            this.checkBoxEmFlag.Size = new System.Drawing.Size(152, 28);
            this.checkBoxEmFlag.TabIndex = 17;
            this.checkBoxEmFlag.Text = "非表示フラグ";
            this.checkBoxEmFlag.UseVisualStyleBackColor = true;
            // 
            // dateTimePickerHiredate
            // 
            this.dateTimePickerHiredate.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.dateTimePickerHiredate.Location = new System.Drawing.Point(411, 70);
            this.dateTimePickerHiredate.Name = "dateTimePickerHiredate";
            this.dateTimePickerHiredate.Size = new System.Drawing.Size(200, 31);
            this.dateTimePickerHiredate.TabIndex = 22;
            // 
            // comboBoxPoID
            // 
            this.comboBoxPoID.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.comboBoxPoID.FormattingEnabled = true;
            this.comboBoxPoID.Location = new System.Drawing.Point(1026, 14);
            this.comboBoxPoID.Name = "comboBoxPoID";
            this.comboBoxPoID.Size = new System.Drawing.Size(196, 29);
            this.comboBoxPoID.TabIndex = 21;
            // 
            // comboBoxSoID
            // 
            this.comboBoxSoID.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.comboBoxSoID.FormattingEnabled = true;
            this.comboBoxSoID.Location = new System.Drawing.Point(742, 14);
            this.comboBoxSoID.Name = "comboBoxSoID";
            this.comboBoxSoID.Size = new System.Drawing.Size(185, 29);
            this.comboBoxSoID.TabIndex = 20;
            // 
            // textBoxEmHidden
            // 
            this.textBoxEmHidden.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBoxEmHidden.Location = new System.Drawing.Point(816, 71);
            this.textBoxEmHidden.Multiline = true;
            this.textBoxEmHidden.Name = "textBoxEmHidden";
            this.textBoxEmHidden.Size = new System.Drawing.Size(541, 60);
            this.textBoxEmHidden.TabIndex = 19;
            // 
            // textBoxEmPhone
            // 
            this.textBoxEmPhone.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBoxEmPhone.Location = new System.Drawing.Point(1375, 16);
            this.textBoxEmPhone.Name = "textBoxEmPhone";
            this.textBoxEmPhone.Size = new System.Drawing.Size(144, 28);
            this.textBoxEmPhone.TabIndex = 17;
            // 
            // textBoxEmPassword
            // 
            this.textBoxEmPassword.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBoxEmPassword.Location = new System.Drawing.Point(121, 72);
            this.textBoxEmPassword.Name = "textBoxEmPassword";
            this.textBoxEmPassword.Size = new System.Drawing.Size(144, 28);
            this.textBoxEmPassword.TabIndex = 16;
            this.textBoxEmPassword.TextChanged += new System.EventHandler(this.textBoxEmPassword_TextChanged);
            // 
            // textBoxEmName
            // 
            this.textBoxEmName.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBoxEmName.Location = new System.Drawing.Point(363, 13);
            this.textBoxEmName.Name = "textBoxEmName";
            this.textBoxEmName.Size = new System.Drawing.Size(248, 28);
            this.textBoxEmName.TabIndex = 15;
            // 
            // textBoxEmID
            // 
            this.textBoxEmID.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBoxEmID.Location = new System.Drawing.Point(99, 14);
            this.textBoxEmID.Name = "textBoxEmID";
            this.textBoxEmID.Size = new System.Drawing.Size(144, 28);
            this.textBoxEmID.TabIndex = 14;
            // 
            // labelPhone
            // 
            this.labelPhone.AutoSize = true;
            this.labelPhone.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.labelPhone.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelPhone.Location = new System.Drawing.Point(1263, 16);
            this.labelPhone.Name = "labelPhone";
            this.labelPhone.Size = new System.Drawing.Size(106, 24);
            this.labelPhone.TabIndex = 10;
            this.labelPhone.Text = "電話番号";
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.labelPassword.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelPassword.Location = new System.Drawing.Point(16, 72);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(103, 24);
            this.labelPassword.TabIndex = 9;
            this.labelPassword.Text = "パスワード";
            this.labelPassword.Click += new System.EventHandler(this.labelPassword_Click);
            // 
            // labelEmHiredate
            // 
            this.labelEmHiredate.AutoSize = true;
            this.labelEmHiredate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.labelEmHiredate.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelEmHiredate.Location = new System.Drawing.Point(275, 73);
            this.labelEmHiredate.Name = "labelEmHiredate";
            this.labelEmHiredate.Size = new System.Drawing.Size(130, 24);
            this.labelEmHiredate.TabIndex = 8;
            this.labelEmHiredate.Text = "入社年月日";
            // 
            // labelPoID
            // 
            this.labelPoID.AutoSize = true;
            this.labelPoID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.labelPoID.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelPoID.Location = new System.Drawing.Point(962, 16);
            this.labelPoID.Name = "labelPoID";
            this.labelPoID.Size = new System.Drawing.Size(58, 24);
            this.labelPoID.TabIndex = 7;
            this.labelPoID.Text = "役職";
            // 
            // labelSoID
            // 
            this.labelSoID.AutoSize = true;
            this.labelSoID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.labelSoID.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelSoID.Location = new System.Drawing.Point(654, 16);
            this.labelSoID.Name = "labelSoID";
            this.labelSoID.Size = new System.Drawing.Size(82, 24);
            this.labelSoID.TabIndex = 6;
            this.labelSoID.Text = "営業所";
            // 
            // labelEmName
            // 
            this.labelEmName.AutoSize = true;
            this.labelEmName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.labelEmName.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelEmName.Location = new System.Drawing.Point(275, 16);
            this.labelEmName.Name = "labelEmName";
            this.labelEmName.Size = new System.Drawing.Size(82, 24);
            this.labelEmName.TabIndex = 5;
            this.labelEmName.Text = "社員名";
            // 
            // labelEmID
            // 
            this.labelEmID.AutoSize = true;
            this.labelEmID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.labelEmID.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelEmID.Location = new System.Drawing.Point(13, 16);
            this.labelEmID.Name = "labelEmID";
            this.labelEmID.Size = new System.Drawing.Size(80, 24);
            this.labelEmID.TabIndex = 4;
            this.labelEmID.Text = "社員ID";
            // 
            // dataGridViewEmployee
            // 
            this.dataGridViewEmployee.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEmployee.Location = new System.Drawing.Point(54, 253);
            this.dataGridViewEmployee.Name = "dataGridViewEmployee";
            this.dataGridViewEmployee.RowTemplate.Height = 21;
            this.dataGridViewEmployee.Size = new System.Drawing.Size(1552, 707);
            this.dataGridViewEmployee.TabIndex = 7;
            this.dataGridViewEmployee.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewEmployee_CellContentClick);
            // 
            // buttonPageSizeChange
            // 
            this.buttonPageSizeChange.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonPageSizeChange.Location = new System.Drawing.Point(1498, 223);
            this.buttonPageSizeChange.Name = "buttonPageSizeChange";
            this.buttonPageSizeChange.Size = new System.Drawing.Size(99, 28);
            this.buttonPageSizeChange.TabIndex = 24;
            this.buttonPageSizeChange.Text = "行数変更";
            this.buttonPageSizeChange.UseVisualStyleBackColor = true;
            this.buttonPageSizeChange.Click += new System.EventHandler(this.buttonPageSizeChange_Click);
            // 
            // textBoxPageSize
            // 
            this.textBoxPageSize.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBoxPageSize.Location = new System.Drawing.Point(1458, 225);
            this.textBoxPageSize.Name = "textBoxPageSize";
            this.textBoxPageSize.Size = new System.Drawing.Size(29, 26);
            this.textBoxPageSize.TabIndex = 23;
            this.textBoxPageSize.Text = "20";
            this.textBoxPageSize.TextChanged += new System.EventHandler(this.textBoxPageSize_TextChanged);
            // 
            // labelPageSize
            // 
            this.labelPageSize.AutoSize = true;
            this.labelPageSize.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelPageSize.Location = new System.Drawing.Point(1347, 230);
            this.labelPageSize.Name = "labelPageSize";
            this.labelPageSize.Size = new System.Drawing.Size(105, 19);
            this.labelPageSize.TabIndex = 22;
            this.labelPageSize.Text = "1ページ行数";
            // 
            // buttonLastPage
            // 
            this.buttonLastPage.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonLastPage.Location = new System.Drawing.Point(920, 216);
            this.buttonLastPage.Name = "buttonLastPage";
            this.buttonLastPage.Size = new System.Drawing.Size(50, 30);
            this.buttonLastPage.TabIndex = 21;
            this.buttonLastPage.Text = "▶l";
            this.buttonLastPage.UseVisualStyleBackColor = true;
            this.buttonLastPage.Click += new System.EventHandler(this.buttonLastPage_Click);
            // 
            // buttonNextPage
            // 
            this.buttonNextPage.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonNextPage.Location = new System.Drawing.Point(852, 216);
            this.buttonNextPage.Name = "buttonNextPage";
            this.buttonNextPage.Size = new System.Drawing.Size(50, 30);
            this.buttonNextPage.TabIndex = 20;
            this.buttonNextPage.Text = "▶";
            this.buttonNextPage.UseVisualStyleBackColor = true;
            this.buttonNextPage.Click += new System.EventHandler(this.buttonNextPage_Click);
            // 
            // buttonPreviousPage
            // 
            this.buttonPreviousPage.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonPreviousPage.Location = new System.Drawing.Point(772, 216);
            this.buttonPreviousPage.Name = "buttonPreviousPage";
            this.buttonPreviousPage.Size = new System.Drawing.Size(50, 31);
            this.buttonPreviousPage.TabIndex = 19;
            this.buttonPreviousPage.Text = "◀";
            this.buttonPreviousPage.UseVisualStyleBackColor = true;
            this.buttonPreviousPage.Click += new System.EventHandler(this.buttonPreviousPage_Click);
            // 
            // buttonFirstPage
            // 
            this.buttonFirstPage.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonFirstPage.Location = new System.Drawing.Point(705, 216);
            this.buttonFirstPage.Name = "buttonFirstPage";
            this.buttonFirstPage.Size = new System.Drawing.Size(50, 30);
            this.buttonFirstPage.TabIndex = 18;
            this.buttonFirstPage.Text = "l◀";
            this.buttonFirstPage.UseVisualStyleBackColor = true;
            this.buttonFirstPage.Click += new System.EventHandler(this.buttonFirstPage_Click);
            // 
            // labelPage
            // 
            this.labelPage.AutoSize = true;
            this.labelPage.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelPage.Location = new System.Drawing.Point(110, 223);
            this.labelPage.Name = "labelPage";
            this.labelPage.Size = new System.Drawing.Size(70, 24);
            this.labelPage.TabIndex = 17;
            this.labelPage.Text = "ページ";
            // 
            // textBoxPage
            // 
            this.textBoxPage.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBoxPage.Location = new System.Drawing.Point(60, 216);
            this.textBoxPage.Name = "textBoxPage";
            this.textBoxPage.Size = new System.Drawing.Size(45, 31);
            this.textBoxPage.TabIndex = 16;
            this.textBoxPage.Text = "100";
            this.textBoxPage.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Honeydew;
            this.panel2.Location = new System.Drawing.Point(250, 100);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1670, 980);
            this.panel2.TabIndex = 25;
            // 
            // panelEmployee
            // 
            this.panelEmployee.Controls.Add(this.panelInput);
            this.panelEmployee.Controls.Add(this.buttonPageSizeChange);
            this.panelEmployee.Controls.Add(this.textBoxPage);
            this.panelEmployee.Controls.Add(this.dataGridViewEmployee);
            this.panelEmployee.Controls.Add(this.textBoxPageSize);
            this.panelEmployee.Controls.Add(this.labelPage);
            this.panelEmployee.Controls.Add(this.buttonFirstPage);
            this.panelEmployee.Controls.Add(this.labelPageSize);
            this.panelEmployee.Controls.Add(this.buttonPreviousPage);
            this.panelEmployee.Controls.Add(this.buttonLastPage);
            this.panelEmployee.Controls.Add(this.buttonNextPage);
            this.panelEmployee.Location = new System.Drawing.Point(251, 100);
            this.panelEmployee.Name = "panelEmployee";
            this.panelEmployee.Size = new System.Drawing.Size(1670, 980);
            this.panelEmployee.TabIndex = 26;
            // 
            // userControlSalesOffice1
            // 
            this.userControlSalesOffice1.BackColor = System.Drawing.Color.Honeydew;
            this.userControlSalesOffice1.Location = new System.Drawing.Point(251, 100);
            this.userControlSalesOffice1.Name = "userControlSalesOffice1";
            this.userControlSalesOffice1.Size = new System.Drawing.Size(1670, 980);
            this.userControlSalesOffice1.TabIndex = 27;
            // 
            // userControlPosition1
            // 
            this.userControlPosition1.BackColor = System.Drawing.Color.Honeydew;
            this.userControlPosition1.Location = new System.Drawing.Point(251, 100);
            this.userControlPosition1.Name = "userControlPosition1";
            this.userControlPosition1.Size = new System.Drawing.Size(1670, 980);
            this.userControlPosition1.TabIndex = 28;
            // 
            // FormEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Honeydew;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.buttonLogout);
            this.Controls.Add(this.buttonSetting);
            this.Controls.Add(this.panelLeft);
            this.Controls.Add(this.panelSetting);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panelEmployee);
            this.Controls.Add(this.userControlSalesOffice1);
            this.Controls.Add(this.userControlPosition1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormEmployee";
            this.Text = "FormEmployee";
            this.Load += new System.EventHandler(this.FormEmployee_Load);
            this.panel3.ResumeLayout(false);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelLeft.ResumeLayout(false);
            this.panelSetting.ResumeLayout(false);
            this.panelInput.ResumeLayout(false);
            this.panelInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEmployee)).EndInit();
            this.panelEmployee.ResumeLayout(false);
            this.panelEmployee.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Button buttonLogout;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.Button buttonRegist;
        private System.Windows.Forms.Panel panelInput;
        private System.Windows.Forms.Label labelEmID;
        private System.Windows.Forms.DataGridView dataGridViewEmployee;
        private System.Windows.Forms.Label labelPhone;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.Label labelEmHiredate;
        private System.Windows.Forms.Label labelPoID;
        private System.Windows.Forms.Label labelSoID;
        private System.Windows.Forms.Label labelEmName;
        private System.Windows.Forms.TextBox textBoxEmID;
        private System.Windows.Forms.TextBox textBoxEmPhone;
        private System.Windows.Forms.TextBox textBoxEmPassword;
        private System.Windows.Forms.TextBox textBoxEmName;
        private System.Windows.Forms.TextBox textBoxEmHidden;
        private System.Windows.Forms.DateTimePicker dateTimePickerHiredate;
        private System.Windows.Forms.ComboBox comboBoxPoID;
        private System.Windows.Forms.ComboBox comboBoxSoID;
        private System.Windows.Forms.CheckBox checkBoxEmFlag;
        private System.Windows.Forms.Button buttonPageSizeChange;
        private System.Windows.Forms.TextBox textBoxPageSize;
        private System.Windows.Forms.Label labelPageSize;
        private System.Windows.Forms.Button buttonLastPage;
        private System.Windows.Forms.Button buttonNextPage;
        private System.Windows.Forms.Button buttonPreviousPage;
        private System.Windows.Forms.Button buttonFirstPage;
        private System.Windows.Forms.Label labelPage;
        private System.Windows.Forms.TextBox textBoxPage;
        private System.Windows.Forms.Button buttonList;
        private System.Windows.Forms.Panel panelSetting;
        private System.Windows.Forms.Button buttonSalesOffice;
        private System.Windows.Forms.Button buttonPosition;
        private System.Windows.Forms.Button buttonSetting;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label labelUserID;
        private System.Windows.Forms.Label labelPosition;
        private System.Windows.Forms.Label labelSalesOffice;
        private System.Windows.Forms.Label labelUserName;
        private System.Windows.Forms.Label labelDay;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.Label labelEmployee;
        private System.Windows.Forms.Button buttonFormDel;
        private System.Windows.Forms.Button buttonHiddenList;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panelEmployee;
        private UserControlSalesOffice userControlSalesOffice1;
        private UserControlPosition userControlPosition1;
    }
}