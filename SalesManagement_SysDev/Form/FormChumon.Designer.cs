
namespace SalesManagement_SysDev
{
    partial class FormChumon
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
            this.labelChumon = new System.Windows.Forms.Label();
            this.buttonFormDel = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonChumonDetail = new System.Windows.Forms.Button();
            this.buttonHiddenList = new System.Windows.Forms.Button();
            this.buttonList = new System.Windows.Forms.Button();
            this.buttonLogout = new System.Windows.Forms.Button();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.panelInput = new System.Windows.Forms.Panel();
            this.buttonClear = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.buttonKakutei = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelClName = new System.Windows.Forms.Label();
            this.textBoxClID = new System.Windows.Forms.TextBox();
            this.labelClID = new System.Windows.Forms.Label();
            this.textBoxEmID = new System.Windows.Forms.TextBox();
            this.labelEmID = new System.Windows.Forms.Label();
            this.comboBoxSoID = new System.Windows.Forms.ComboBox();
            this.labelSoID = new System.Windows.Forms.Label();
            this.textBoxChID = new System.Windows.Forms.TextBox();
            this.labelChID = new System.Windows.Forms.Label();
            this.textBoxOrID = new System.Windows.Forms.TextBox();
            this.labelOrID = new System.Windows.Forms.Label();
            this.labelChDate = new System.Windows.Forms.Label();
            this.DateTimePickerChDate = new System.Windows.Forms.DateTimePicker();
            this.checkBoxStateFlag = new System.Windows.Forms.CheckBox();
            this.panelHeader.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panelInput.SuspendLayout();
            this.panel1.SuspendLayout();
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
            this.panelHeader.Controls.Add(this.labelChumon);
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
            // labelChumon
            // 
            this.labelChumon.AutoSize = true;
            this.labelChumon.Font = new System.Drawing.Font("HGSｺﾞｼｯｸE", 39.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelChumon.ForeColor = System.Drawing.Color.White;
            this.labelChumon.Location = new System.Drawing.Point(694, 22);
            this.labelChumon.Name = "labelChumon";
            this.labelChumon.Size = new System.Drawing.Size(235, 53);
            this.labelChumon.TabIndex = 1;
            this.labelChumon.Text = "注文管理";
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
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Honeydew;
            this.panel2.Controls.Add(this.buttonKakutei);
            this.panel2.Controls.Add(this.buttonChumonDetail);
            this.panel2.Controls.Add(this.buttonHiddenList);
            this.panel2.Controls.Add(this.buttonList);
            this.panel2.Controls.Add(this.buttonLogout);
            this.panel2.Controls.Add(this.buttonSearch);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(250, 980);
            this.panel2.TabIndex = 28;
            // 
            // buttonChumonDetail
            // 
            this.buttonChumonDetail.BackColor = System.Drawing.Color.LightGreen;
            this.buttonChumonDetail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonChumonDetail.Font = new System.Drawing.Font("MS UI Gothic", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonChumonDetail.Location = new System.Drawing.Point(0, 801);
            this.buttonChumonDetail.Name = "buttonChumonDetail";
            this.buttonChumonDetail.Size = new System.Drawing.Size(250, 100);
            this.buttonChumonDetail.TabIndex = 41;
            this.buttonChumonDetail.Text = "注文詳細";
            this.buttonChumonDetail.UseVisualStyleBackColor = false;
            // 
            // buttonHiddenList
            // 
            this.buttonHiddenList.BackColor = System.Drawing.Color.White;
            this.buttonHiddenList.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.buttonHiddenList.FlatAppearance.BorderSize = 4;
            this.buttonHiddenList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonHiddenList.Font = new System.Drawing.Font("MS UI Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonHiddenList.Location = new System.Drawing.Point(25, 330);
            this.buttonHiddenList.Name = "buttonHiddenList";
            this.buttonHiddenList.Size = new System.Drawing.Size(200, 80);
            this.buttonHiddenList.TabIndex = 39;
            this.buttonHiddenList.Text = "非表示リスト";
            this.buttonHiddenList.UseVisualStyleBackColor = false;
            // 
            // buttonList
            // 
            this.buttonList.BackColor = System.Drawing.Color.White;
            this.buttonList.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.buttonList.FlatAppearance.BorderSize = 4;
            this.buttonList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonList.Font = new System.Drawing.Font("MS UI Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonList.Location = new System.Drawing.Point(25, 225);
            this.buttonList.Name = "buttonList";
            this.buttonList.Size = new System.Drawing.Size(200, 80);
            this.buttonList.TabIndex = 38;
            this.buttonList.Text = "一覧表示";
            this.buttonList.UseVisualStyleBackColor = false;
            // 
            // buttonLogout
            // 
            this.buttonLogout.BackColor = System.Drawing.Color.DarkGreen;
            this.buttonLogout.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonLogout.Font = new System.Drawing.Font("MS UI Gothic", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonLogout.ForeColor = System.Drawing.Color.White;
            this.buttonLogout.Location = new System.Drawing.Point(0, 900);
            this.buttonLogout.Name = "buttonLogout";
            this.buttonLogout.Size = new System.Drawing.Size(250, 80);
            this.buttonLogout.TabIndex = 5;
            this.buttonLogout.Text = "ログアウト";
            this.buttonLogout.UseVisualStyleBackColor = false;
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
            // 
            // panelInput
            // 
            this.panelInput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.panelInput.Controls.Add(this.checkBoxStateFlag);
            this.panelInput.Controls.Add(this.labelChDate);
            this.panelInput.Controls.Add(this.DateTimePickerChDate);
            this.panelInput.Controls.Add(this.textBoxOrID);
            this.panelInput.Controls.Add(this.labelOrID);
            this.panelInput.Controls.Add(this.labelClName);
            this.panelInput.Controls.Add(this.textBoxClID);
            this.panelInput.Controls.Add(this.labelClID);
            this.panelInput.Controls.Add(this.textBoxEmID);
            this.panelInput.Controls.Add(this.labelEmID);
            this.panelInput.Controls.Add(this.comboBoxSoID);
            this.panelInput.Controls.Add(this.labelSoID);
            this.panelInput.Controls.Add(this.textBoxChID);
            this.panelInput.Controls.Add(this.labelChID);
            this.panelInput.Controls.Add(this.buttonClear);
            this.panelInput.Location = new System.Drawing.Point(280, 31);
            this.panelInput.Name = "panelInput";
            this.panelInput.Size = new System.Drawing.Size(1616, 169);
            this.panelInput.TabIndex = 29;
            // 
            // buttonClear
            // 
            this.buttonClear.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonClear.Location = new System.Drawing.Point(1511, 136);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(102, 30);
            this.buttonClear.TabIndex = 28;
            this.buttonClear.Text = "入力クリア";
            this.buttonClear.UseVisualStyleBackColor = true;
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // buttonKakutei
            // 
            this.buttonKakutei.BackColor = System.Drawing.Color.White;
            this.buttonKakutei.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.buttonKakutei.FlatAppearance.BorderSize = 4;
            this.buttonKakutei.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonKakutei.Font = new System.Drawing.Font("MS UI Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonKakutei.Location = new System.Drawing.Point(25, 120);
            this.buttonKakutei.Name = "buttonKakutei";
            this.buttonKakutei.Size = new System.Drawing.Size(200, 80);
            this.buttonKakutei.TabIndex = 43;
            this.buttonKakutei.Text = "確定";
            this.buttonKakutei.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.panelInput);
            this.panel1.Location = new System.Drawing.Point(0, 100);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1920, 980);
            this.panel1.TabIndex = 30;
            // 
            // labelClName
            // 
            this.labelClName.AutoSize = true;
            this.labelClName.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelClName.Location = new System.Drawing.Point(1187, 18);
            this.labelClName.Name = "labelClName";
            this.labelClName.Size = new System.Drawing.Size(82, 24);
            this.labelClName.TabIndex = 59;
            this.labelClName.Text = "顧客名";
            // 
            // textBoxClID
            // 
            this.textBoxClID.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBoxClID.Location = new System.Drawing.Point(1059, 16);
            this.textBoxClID.Name = "textBoxClID";
            this.textBoxClID.Size = new System.Drawing.Size(77, 28);
            this.textBoxClID.TabIndex = 58;
            // 
            // labelClID
            // 
            this.labelClID.AutoSize = true;
            this.labelClID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.labelClID.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelClID.Location = new System.Drawing.Point(973, 18);
            this.labelClID.Name = "labelClID";
            this.labelClID.Size = new System.Drawing.Size(80, 24);
            this.labelClID.TabIndex = 57;
            this.labelClID.Text = "顧客ID";
            // 
            // textBoxEmID
            // 
            this.textBoxEmID.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBoxEmID.Location = new System.Drawing.Point(856, 16);
            this.textBoxEmID.Name = "textBoxEmID";
            this.textBoxEmID.Size = new System.Drawing.Size(77, 28);
            this.textBoxEmID.TabIndex = 56;
            // 
            // labelEmID
            // 
            this.labelEmID.AutoSize = true;
            this.labelEmID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.labelEmID.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelEmID.Location = new System.Drawing.Point(770, 18);
            this.labelEmID.Name = "labelEmID";
            this.labelEmID.Size = new System.Drawing.Size(80, 24);
            this.labelEmID.TabIndex = 55;
            this.labelEmID.Text = "社員ID";
            // 
            // comboBoxSoID
            // 
            this.comboBoxSoID.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.comboBoxSoID.FormattingEnabled = true;
            this.comboBoxSoID.Location = new System.Drawing.Point(562, 17);
            this.comboBoxSoID.Name = "comboBoxSoID";
            this.comboBoxSoID.Size = new System.Drawing.Size(173, 29);
            this.comboBoxSoID.TabIndex = 54;
            // 
            // labelSoID
            // 
            this.labelSoID.AutoSize = true;
            this.labelSoID.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelSoID.Location = new System.Drawing.Point(452, 18);
            this.labelSoID.Name = "labelSoID";
            this.labelSoID.Size = new System.Drawing.Size(106, 24);
            this.labelSoID.TabIndex = 53;
            this.labelSoID.Text = "営業所名";
            // 
            // textBoxChID
            // 
            this.textBoxChID.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBoxChID.Location = new System.Drawing.Point(99, 17);
            this.textBoxChID.Name = "textBoxChID";
            this.textBoxChID.Size = new System.Drawing.Size(77, 28);
            this.textBoxChID.TabIndex = 52;
            // 
            // labelChID
            // 
            this.labelChID.AutoSize = true;
            this.labelChID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.labelChID.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelChID.Location = new System.Drawing.Point(13, 18);
            this.labelChID.Name = "labelChID";
            this.labelChID.Size = new System.Drawing.Size(80, 24);
            this.labelChID.TabIndex = 51;
            this.labelChID.Text = "注文ID";
            // 
            // textBoxOrID
            // 
            this.textBoxOrID.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBoxOrID.Location = new System.Drawing.Point(316, 16);
            this.textBoxOrID.Name = "textBoxOrID";
            this.textBoxOrID.Size = new System.Drawing.Size(77, 28);
            this.textBoxOrID.TabIndex = 61;
            // 
            // labelOrID
            // 
            this.labelOrID.AutoSize = true;
            this.labelOrID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.labelOrID.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelOrID.Location = new System.Drawing.Point(230, 18);
            this.labelOrID.Name = "labelOrID";
            this.labelOrID.Size = new System.Drawing.Size(80, 24);
            this.labelOrID.TabIndex = 60;
            this.labelOrID.Text = "受注ID";
            // 
            // labelChDate
            // 
            this.labelChDate.AutoSize = true;
            this.labelChDate.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelChDate.Location = new System.Drawing.Point(13, 69);
            this.labelChDate.Name = "labelChDate";
            this.labelChDate.Size = new System.Drawing.Size(82, 24);
            this.labelChDate.TabIndex = 63;
            this.labelChDate.Text = "受注日";
            // 
            // DateTimePickerChDate
            // 
            this.DateTimePickerChDate.Font = new System.Drawing.Font("MS UI Gothic", 16.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.DateTimePickerChDate.Location = new System.Drawing.Point(101, 68);
            this.DateTimePickerChDate.Name = "DateTimePickerChDate";
            this.DateTimePickerChDate.Size = new System.Drawing.Size(220, 30);
            this.DateTimePickerChDate.TabIndex = 62;
            // 
            // checkBoxStateFlag
            // 
            this.checkBoxStateFlag.AutoSize = true;
            this.checkBoxStateFlag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.checkBoxStateFlag.Font = new System.Drawing.Font("MS UI Gothic", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.checkBoxStateFlag.ForeColor = System.Drawing.Color.Red;
            this.checkBoxStateFlag.Location = new System.Drawing.Point(17, 115);
            this.checkBoxStateFlag.Name = "checkBoxStateFlag";
            this.checkBoxStateFlag.Size = new System.Drawing.Size(152, 33);
            this.checkBoxStateFlag.TabIndex = 64;
            this.checkBoxStateFlag.Text = "受注確定";
            this.checkBoxStateFlag.UseVisualStyleBackColor = false;
            // 
            // FormChumon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Honeydew;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormChumon";
            this.Text = "FormChumon";
            this.Load += new System.EventHandler(this.FormChumon_Load);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panelInput.ResumeLayout(false);
            this.panelInput.PerformLayout();
            this.panel1.ResumeLayout(false);
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
        private System.Windows.Forms.Label labelChumon;
        private System.Windows.Forms.Button buttonFormDel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonChumonDetail;
        private System.Windows.Forms.Button buttonHiddenList;
        private System.Windows.Forms.Button buttonList;
        private System.Windows.Forms.Button buttonLogout;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.Panel panelInput;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Button buttonKakutei;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelClName;
        private System.Windows.Forms.TextBox textBoxClID;
        private System.Windows.Forms.Label labelClID;
        private System.Windows.Forms.TextBox textBoxEmID;
        private System.Windows.Forms.Label labelEmID;
        private System.Windows.Forms.ComboBox comboBoxSoID;
        private System.Windows.Forms.Label labelSoID;
        private System.Windows.Forms.TextBox textBoxChID;
        private System.Windows.Forms.Label labelChID;
        private System.Windows.Forms.TextBox textBoxOrID;
        private System.Windows.Forms.Label labelOrID;
        private System.Windows.Forms.Label labelChDate;
        private System.Windows.Forms.DateTimePicker DateTimePickerChDate;
        private System.Windows.Forms.CheckBox checkBoxStateFlag;
    }
}