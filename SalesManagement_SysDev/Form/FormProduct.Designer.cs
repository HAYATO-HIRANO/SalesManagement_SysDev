﻿
namespace SalesManagement_SysDev
{
    partial class FormProduct
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
            this.panelHeader = new System.Windows.Forms.Panel();
            this.label = new System.Windows.Forms.Label();
            this.labelUserName = new System.Windows.Forms.Label();
            this.labelDay = new System.Windows.Forms.Label();
            this.labelTime = new System.Windows.Forms.Label();
            this.buttonSaisyou = new System.Windows.Forms.Button();
            this.labelProduct = new System.Windows.Forms.Label();
            this.buttonFormDel = new System.Windows.Forms.Button();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.buttonList = new System.Windows.Forms.Button();
            this.buttonLogout = new System.Windows.Forms.Button();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.buttonRegist = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.comboBoxMc = new System.Windows.Forms.ComboBox();
            this.labelMc = new System.Windows.Forms.Label();
            this.labelPrReleaseDate = new System.Windows.Forms.Label();
            this.DateTimePickerPrReleaseDate = new System.Windows.Forms.DateTimePicker();
            this.comboBoxSc = new System.Windows.Forms.ComboBox();
            this.labelSc = new System.Windows.Forms.Label();
            this.comboBoxMaker = new System.Windows.Forms.ComboBox();
            this.textBoxPrID = new System.Windows.Forms.TextBox();
            this.labelPrHidden = new System.Windows.Forms.Label();
            this.textBoxPrHidden = new System.Windows.Forms.TextBox();
            this.labelPrID = new System.Windows.Forms.Label();
            this.checkBoxPrFlag = new System.Windows.Forms.CheckBox();
            this.labelMName = new System.Windows.Forms.Label();
            this.textBoxPrSafetyStock = new System.Windows.Forms.TextBox();
            this.labelMaker = new System.Windows.Forms.Label();
            this.labelPrSafetyStock = new System.Windows.Forms.Label();
            this.textBoxPrName = new System.Windows.Forms.TextBox();
            this.textBoxPrModelNumber = new System.Windows.Forms.TextBox();
            this.labelColor = new System.Windows.Forms.Label();
            this.labelPrModelNumber = new System.Windows.Forms.Label();
            this.textBoxColor = new System.Windows.Forms.TextBox();
            this.textBoxJCode = new System.Windows.Forms.TextBox();
            this.labelJcode = new System.Windows.Forms.Label();
            this.dataGridViewProduct = new System.Windows.Forms.DataGridView();
            this.buttonPageSizeChange = new System.Windows.Forms.Button();
            this.textBoxPageSize = new System.Windows.Forms.TextBox();
            this.labelPageSize = new System.Windows.Forms.Label();
            this.buttonLastPage = new System.Windows.Forms.Button();
            this.buttonNextPage = new System.Windows.Forms.Button();
            this.buttonPreviousPage = new System.Windows.Forms.Button();
            this.buttonFirstPage = new System.Windows.Forms.Button();
            this.labelPage = new System.Windows.Forms.Label();
            this.textBoxPage = new System.Windows.Forms.TextBox();
            this.buttonSetting = new System.Windows.Forms.Button();
            this.panelSetting = new System.Windows.Forms.Panel();
            this.buttonProduct = new System.Windows.Forms.Button();
            this.buttonMajorClassification = new System.Windows.Forms.Button();
            this.buttonMaker = new System.Windows.Forms.Button();
            this.buttonSmallClassification = new System.Windows.Forms.Button();
            this.userControlMaker1 = new SalesManagement_SysDev.UserControlMaker();
            this.panelHeader.SuspendLayout();
            this.panelLeft.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProduct)).BeginInit();
            this.panelSetting.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.DarkGreen;
            this.panelHeader.Controls.Add(this.label);
            this.panelHeader.Controls.Add(this.labelUserName);
            this.panelHeader.Controls.Add(this.labelDay);
            this.panelHeader.Controls.Add(this.labelTime);
            this.panelHeader.Controls.Add(this.buttonSaisyou);
            this.panelHeader.Controls.Add(this.labelProduct);
            this.panelHeader.Controls.Add(this.buttonFormDel);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Margin = new System.Windows.Forms.Padding(2);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1920, 100);
            this.panelHeader.TabIndex = 25;
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label.ForeColor = System.Drawing.Color.White;
            this.label.Location = new System.Drawing.Point(914, 59);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(51, 16);
            this.label.TabIndex = 11;
            this.label.Text = "権限：";
            // 
            // labelUserName
            // 
            this.labelUserName.AutoSize = true;
            this.labelUserName.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelUserName.ForeColor = System.Drawing.Color.White;
            this.labelUserName.Location = new System.Drawing.Point(875, 21);
            this.labelUserName.Name = "labelUserName";
            this.labelUserName.Size = new System.Drawing.Size(90, 16);
            this.labelUserName.TabIndex = 10;
            this.labelUserName.Text = "ユーザー名：";
            // 
            // labelDay
            // 
            this.labelDay.AutoSize = true;
            this.labelDay.Font = new System.Drawing.Font("MS UI Gothic", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelDay.ForeColor = System.Drawing.Color.White;
            this.labelDay.Location = new System.Drawing.Point(1344, 2);
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
            this.labelTime.Location = new System.Drawing.Point(1384, 36);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(174, 64);
            this.labelTime.TabIndex = 8;
            this.labelTime.Text = "12:00";
            // 
            // buttonSaisyou
            // 
            this.buttonSaisyou.BackColor = System.Drawing.Color.DarkGreen;
            this.buttonSaisyou.Font = new System.Drawing.Font("MS UI Gothic", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonSaisyou.ForeColor = System.Drawing.Color.White;
            this.buttonSaisyou.Location = new System.Drawing.Point(1773, 0);
            this.buttonSaisyou.Name = "buttonSaisyou";
            this.buttonSaisyou.Size = new System.Drawing.Size(75, 75);
            this.buttonSaisyou.TabIndex = 7;
            this.buttonSaisyou.Text = "ー";
            this.buttonSaisyou.UseVisualStyleBackColor = false;
            // 
            // labelProduct
            // 
            this.labelProduct.AutoSize = true;
            this.labelProduct.Font = new System.Drawing.Font("HGSｺﾞｼｯｸE", 39.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelProduct.ForeColor = System.Drawing.Color.White;
            this.labelProduct.Location = new System.Drawing.Point(297, 20);
            this.labelProduct.Name = "labelProduct";
            this.labelProduct.Size = new System.Drawing.Size(235, 53);
            this.labelProduct.TabIndex = 1;
            this.labelProduct.Text = "商品管理";
            // 
            // buttonFormDel
            // 
            this.buttonFormDel.BackColor = System.Drawing.Color.DarkGreen;
            this.buttonFormDel.Font = new System.Drawing.Font("MS UI Gothic", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonFormDel.ForeColor = System.Drawing.Color.White;
            this.buttonFormDel.Location = new System.Drawing.Point(1845, 0);
            this.buttonFormDel.Name = "buttonFormDel";
            this.buttonFormDel.Size = new System.Drawing.Size(75, 75);
            this.buttonFormDel.TabIndex = 0;
            this.buttonFormDel.Text = "✕";
            this.buttonFormDel.UseVisualStyleBackColor = false;
            this.buttonFormDel.Click += new System.EventHandler(this.buttonFormDel_Click);
            // 
            // panelLeft
            // 
            this.panelLeft.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.panelLeft.Controls.Add(this.panelSetting);
            this.panelLeft.Controls.Add(this.buttonSetting);
            this.panelLeft.Controls.Add(this.buttonList);
            this.panelLeft.Controls.Add(this.buttonLogout);
            this.panelLeft.Controls.Add(this.buttonUpdate);
            this.panelLeft.Controls.Add(this.buttonSearch);
            this.panelLeft.Controls.Add(this.buttonRegist);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 100);
            this.panelLeft.Margin = new System.Windows.Forms.Padding(2);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(250, 980);
            this.panelLeft.TabIndex = 26;
            // 
            // buttonList
            // 
            this.buttonList.BackColor = System.Drawing.Color.LightGreen;
            this.buttonList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonList.Font = new System.Drawing.Font("MS UI Gothic", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonList.Location = new System.Drawing.Point(0, 385);
            this.buttonList.Name = "buttonList";
            this.buttonList.Size = new System.Drawing.Size(250, 130);
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
            // buttonUpdate
            // 
            this.buttonUpdate.BackColor = System.Drawing.Color.LightGreen;
            this.buttonUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonUpdate.Font = new System.Drawing.Font("MS UI Gothic", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonUpdate.Location = new System.Drawing.Point(0, 129);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(250, 130);
            this.buttonUpdate.TabIndex = 2;
            this.buttonUpdate.Text = "更新";
            this.buttonUpdate.UseVisualStyleBackColor = false;
            // 
            // buttonSearch
            // 
            this.buttonSearch.BackColor = System.Drawing.Color.LightGreen;
            this.buttonSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSearch.Font = new System.Drawing.Font("MS UI Gothic", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonSearch.Location = new System.Drawing.Point(0, 258);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(250, 130);
            this.buttonSearch.TabIndex = 1;
            this.buttonSearch.Text = "検索";
            this.buttonSearch.UseVisualStyleBackColor = false;
            // 
            // buttonRegist
            // 
            this.buttonRegist.BackColor = System.Drawing.Color.LightGreen;
            this.buttonRegist.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRegist.Font = new System.Drawing.Font("MS UI Gothic", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonRegist.Location = new System.Drawing.Point(0, 0);
            this.buttonRegist.Name = "buttonRegist";
            this.buttonRegist.Size = new System.Drawing.Size(250, 130);
            this.buttonRegist.TabIndex = 0;
            this.buttonRegist.Text = "登録";
            this.buttonRegist.UseVisualStyleBackColor = false;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.panel4.Controls.Add(this.comboBoxMc);
            this.panel4.Controls.Add(this.labelMc);
            this.panel4.Controls.Add(this.labelPrReleaseDate);
            this.panel4.Controls.Add(this.DateTimePickerPrReleaseDate);
            this.panel4.Controls.Add(this.comboBoxSc);
            this.panel4.Controls.Add(this.labelSc);
            this.panel4.Controls.Add(this.comboBoxMaker);
            this.panel4.Controls.Add(this.textBoxPrID);
            this.panel4.Controls.Add(this.labelPrHidden);
            this.panel4.Controls.Add(this.textBoxPrHidden);
            this.panel4.Controls.Add(this.labelPrID);
            this.panel4.Controls.Add(this.checkBoxPrFlag);
            this.panel4.Controls.Add(this.labelMName);
            this.panel4.Controls.Add(this.textBoxPrSafetyStock);
            this.panel4.Controls.Add(this.labelMaker);
            this.panel4.Controls.Add(this.labelPrSafetyStock);
            this.panel4.Controls.Add(this.textBoxPrName);
            this.panel4.Controls.Add(this.textBoxPrModelNumber);
            this.panel4.Controls.Add(this.labelColor);
            this.panel4.Controls.Add(this.labelPrModelNumber);
            this.panel4.Controls.Add(this.textBoxColor);
            this.panel4.Controls.Add(this.textBoxJCode);
            this.panel4.Controls.Add(this.labelJcode);
            this.panel4.Location = new System.Drawing.Point(306, 143);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1552, 230);
            this.panel4.TabIndex = 27;
            // 
            // comboBoxMc
            // 
            this.comboBoxMc.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.comboBoxMc.FormattingEnabled = true;
            this.comboBoxMc.Location = new System.Drawing.Point(531, 81);
            this.comboBoxMc.Name = "comboBoxMc";
            this.comboBoxMc.Size = new System.Drawing.Size(196, 29);
            this.comboBoxMc.TabIndex = 24;
            // 
            // labelMc
            // 
            this.labelMc.AutoSize = true;
            this.labelMc.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelMc.Location = new System.Drawing.Point(386, 81);
            this.labelMc.Name = "labelMc";
            this.labelMc.Size = new System.Drawing.Size(106, 24);
            this.labelMc.TabIndex = 23;
            this.labelMc.Text = "大分類名";
            // 
            // labelPrReleaseDate
            // 
            this.labelPrReleaseDate.AutoSize = true;
            this.labelPrReleaseDate.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelPrReleaseDate.Location = new System.Drawing.Point(1170, 144);
            this.labelPrReleaseDate.Name = "labelPrReleaseDate";
            this.labelPrReleaseDate.Size = new System.Drawing.Size(82, 24);
            this.labelPrReleaseDate.TabIndex = 22;
            this.labelPrReleaseDate.Text = "発売日";
            // 
            // DateTimePickerPrReleaseDate
            // 
            this.DateTimePickerPrReleaseDate.Font = new System.Drawing.Font("MS UI Gothic", 16.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.DateTimePickerPrReleaseDate.Location = new System.Drawing.Point(1287, 140);
            this.DateTimePickerPrReleaseDate.Name = "DateTimePickerPrReleaseDate";
            this.DateTimePickerPrReleaseDate.Size = new System.Drawing.Size(220, 30);
            this.DateTimePickerPrReleaseDate.TabIndex = 21;
            // 
            // comboBoxSc
            // 
            this.comboBoxSc.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.comboBoxSc.FormattingEnabled = true;
            this.comboBoxSc.Location = new System.Drawing.Point(142, 81);
            this.comboBoxSc.Name = "comboBoxSc";
            this.comboBoxSc.Size = new System.Drawing.Size(196, 29);
            this.comboBoxSc.TabIndex = 20;
            // 
            // labelSc
            // 
            this.labelSc.AutoSize = true;
            this.labelSc.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelSc.Location = new System.Drawing.Point(15, 81);
            this.labelSc.Name = "labelSc";
            this.labelSc.Size = new System.Drawing.Size(106, 24);
            this.labelSc.TabIndex = 19;
            this.labelSc.Text = "小分類名";
            // 
            // comboBoxMaker
            // 
            this.comboBoxMaker.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.comboBoxMaker.FormattingEnabled = true;
            this.comboBoxMaker.Location = new System.Drawing.Point(340, 21);
            this.comboBoxMaker.Name = "comboBoxMaker";
            this.comboBoxMaker.Size = new System.Drawing.Size(196, 29);
            this.comboBoxMaker.TabIndex = 7;
            // 
            // textBoxPrID
            // 
            this.textBoxPrID.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBoxPrID.Location = new System.Drawing.Point(101, 21);
            this.textBoxPrID.Name = "textBoxPrID";
            this.textBoxPrID.Size = new System.Drawing.Size(84, 28);
            this.textBoxPrID.TabIndex = 2;
            this.textBoxPrID.Text = "012345";
            // 
            // labelPrHidden
            // 
            this.labelPrHidden.AutoSize = true;
            this.labelPrHidden.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelPrHidden.Location = new System.Drawing.Point(204, 134);
            this.labelPrHidden.Name = "labelPrHidden";
            this.labelPrHidden.Size = new System.Drawing.Size(130, 24);
            this.labelPrHidden.TabIndex = 17;
            this.labelPrHidden.Text = "非表示理由";
            // 
            // textBoxPrHidden
            // 
            this.textBoxPrHidden.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBoxPrHidden.Location = new System.Drawing.Point(340, 134);
            this.textBoxPrHidden.Multiline = true;
            this.textBoxPrHidden.Name = "textBoxPrHidden";
            this.textBoxPrHidden.Size = new System.Drawing.Size(787, 84);
            this.textBoxPrHidden.TabIndex = 18;
            // 
            // labelPrID
            // 
            this.labelPrID.AutoSize = true;
            this.labelPrID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.labelPrID.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelPrID.Location = new System.Drawing.Point(15, 22);
            this.labelPrID.Name = "labelPrID";
            this.labelPrID.Size = new System.Drawing.Size(80, 24);
            this.labelPrID.TabIndex = 1;
            this.labelPrID.Text = "商品ID";
            // 
            // checkBoxPrFlag
            // 
            this.checkBoxPrFlag.AutoSize = true;
            this.checkBoxPrFlag.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.checkBoxPrFlag.Location = new System.Drawing.Point(19, 134);
            this.checkBoxPrFlag.Name = "checkBoxPrFlag";
            this.checkBoxPrFlag.Size = new System.Drawing.Size(176, 28);
            this.checkBoxPrFlag.TabIndex = 16;
            this.checkBoxPrFlag.Text = "商品管理フラグ";
            this.checkBoxPrFlag.UseVisualStyleBackColor = true;
            // 
            // labelMName
            // 
            this.labelMName.AutoSize = true;
            this.labelMName.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelMName.Location = new System.Drawing.Point(230, 22);
            this.labelMName.Name = "labelMName";
            this.labelMName.Size = new System.Drawing.Size(108, 24);
            this.labelMName.TabIndex = 3;
            this.labelMName.Text = "メーカー名";
            // 
            // textBoxPrSafetyStock
            // 
            this.textBoxPrSafetyStock.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBoxPrSafetyStock.Location = new System.Drawing.Point(1340, 21);
            this.textBoxPrSafetyStock.Name = "textBoxPrSafetyStock";
            this.textBoxPrSafetyStock.Size = new System.Drawing.Size(150, 28);
            this.textBoxPrSafetyStock.TabIndex = 14;
            this.textBoxPrSafetyStock.Text = "0123456789012";
            this.textBoxPrSafetyStock.TextChanged += new System.EventHandler(this.textBoxClFAX_TextChanged);
            // 
            // labelMaker
            // 
            this.labelMaker.AutoSize = true;
            this.labelMaker.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelMaker.Location = new System.Drawing.Point(568, 22);
            this.labelMaker.Name = "labelMaker";
            this.labelMaker.Size = new System.Drawing.Size(82, 24);
            this.labelMaker.TabIndex = 5;
            this.labelMaker.Text = "商品名";
            // 
            // labelPrSafetyStock
            // 
            this.labelPrSafetyStock.AutoSize = true;
            this.labelPrSafetyStock.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelPrSafetyStock.Location = new System.Drawing.Point(1204, 22);
            this.labelPrSafetyStock.Name = "labelPrSafetyStock";
            this.labelPrSafetyStock.Size = new System.Drawing.Size(130, 24);
            this.labelPrSafetyStock.TabIndex = 13;
            this.labelPrSafetyStock.Text = "安全在庫数";
            // 
            // textBoxPrName
            // 
            this.textBoxPrName.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBoxPrName.Location = new System.Drawing.Point(656, 22);
            this.textBoxPrName.Name = "textBoxPrName";
            this.textBoxPrName.Size = new System.Drawing.Size(199, 28);
            this.textBoxPrName.TabIndex = 6;
            // 
            // textBoxPrModelNumber
            // 
            this.textBoxPrModelNumber.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBoxPrModelNumber.Location = new System.Drawing.Point(886, 81);
            this.textBoxPrModelNumber.Name = "textBoxPrModelNumber";
            this.textBoxPrModelNumber.Size = new System.Drawing.Size(267, 28);
            this.textBoxPrModelNumber.TabIndex = 12;
            this.textBoxPrModelNumber.Text = "0123456";
            // 
            // labelColor
            // 
            this.labelColor.AutoSize = true;
            this.labelColor.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelColor.Location = new System.Drawing.Point(1204, 81);
            this.labelColor.Name = "labelColor";
            this.labelColor.Size = new System.Drawing.Size(34, 24);
            this.labelColor.TabIndex = 7;
            this.labelColor.Text = "色";
            // 
            // labelPrModelNumber
            // 
            this.labelPrModelNumber.AutoSize = true;
            this.labelPrModelNumber.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelPrModelNumber.Location = new System.Drawing.Point(810, 81);
            this.labelPrModelNumber.Name = "labelPrModelNumber";
            this.labelPrModelNumber.Size = new System.Drawing.Size(58, 24);
            this.labelPrModelNumber.TabIndex = 11;
            this.labelPrModelNumber.Text = "型番";
            // 
            // textBoxColor
            // 
            this.textBoxColor.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBoxColor.Location = new System.Drawing.Point(1281, 81);
            this.textBoxColor.Name = "textBoxColor";
            this.textBoxColor.Size = new System.Drawing.Size(209, 28);
            this.textBoxColor.TabIndex = 8;
            // 
            // textBoxJCode
            // 
            this.textBoxJCode.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBoxJCode.Location = new System.Drawing.Point(1006, 21);
            this.textBoxJCode.Name = "textBoxJCode";
            this.textBoxJCode.Size = new System.Drawing.Size(147, 28);
            this.textBoxJCode.TabIndex = 10;
            this.textBoxJCode.Text = "0123456789012";
            // 
            // labelJcode
            // 
            this.labelJcode.AutoSize = true;
            this.labelJcode.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelJcode.Location = new System.Drawing.Point(894, 22);
            this.labelJcode.Name = "labelJcode";
            this.labelJcode.Size = new System.Drawing.Size(107, 24);
            this.labelJcode.TabIndex = 9;
            this.labelJcode.Text = "JANコード";
            // 
            // dataGridViewProduct
            // 
            this.dataGridViewProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProduct.Location = new System.Drawing.Point(309, 411);
            this.dataGridViewProduct.Name = "dataGridViewProduct";
            this.dataGridViewProduct.RowTemplate.Height = 21;
            this.dataGridViewProduct.Size = new System.Drawing.Size(1549, 630);
            this.dataGridViewProduct.TabIndex = 28;
            // 
            // buttonPageSizeChange
            // 
            this.buttonPageSizeChange.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonPageSizeChange.Location = new System.Drawing.Point(1747, 382);
            this.buttonPageSizeChange.Name = "buttonPageSizeChange";
            this.buttonPageSizeChange.Size = new System.Drawing.Size(99, 28);
            this.buttonPageSizeChange.TabIndex = 37;
            this.buttonPageSizeChange.Text = "行数変更";
            this.buttonPageSizeChange.UseVisualStyleBackColor = true;
            // 
            // textBoxPageSize
            // 
            this.textBoxPageSize.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBoxPageSize.Location = new System.Drawing.Point(1700, 384);
            this.textBoxPageSize.Name = "textBoxPageSize";
            this.textBoxPageSize.Size = new System.Drawing.Size(41, 26);
            this.textBoxPageSize.TabIndex = 36;
            this.textBoxPageSize.Text = "100";
            // 
            // labelPageSize
            // 
            this.labelPageSize.AutoSize = true;
            this.labelPageSize.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelPageSize.Location = new System.Drawing.Point(1589, 389);
            this.labelPageSize.Name = "labelPageSize";
            this.labelPageSize.Size = new System.Drawing.Size(105, 19);
            this.labelPageSize.TabIndex = 35;
            this.labelPageSize.Text = "1ページ行数";
            // 
            // buttonLastPage
            // 
            this.buttonLastPage.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonLastPage.Location = new System.Drawing.Point(1169, 379);
            this.buttonLastPage.Name = "buttonLastPage";
            this.buttonLastPage.Size = new System.Drawing.Size(50, 30);
            this.buttonLastPage.TabIndex = 34;
            this.buttonLastPage.Text = "▶l";
            this.buttonLastPage.UseVisualStyleBackColor = true;
            // 
            // buttonNextPage
            // 
            this.buttonNextPage.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonNextPage.Location = new System.Drawing.Point(1101, 379);
            this.buttonNextPage.Name = "buttonNextPage";
            this.buttonNextPage.Size = new System.Drawing.Size(50, 30);
            this.buttonNextPage.TabIndex = 33;
            this.buttonNextPage.Text = "▶";
            this.buttonNextPage.UseVisualStyleBackColor = true;
            // 
            // buttonPreviousPage
            // 
            this.buttonPreviousPage.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonPreviousPage.Location = new System.Drawing.Point(1021, 379);
            this.buttonPreviousPage.Name = "buttonPreviousPage";
            this.buttonPreviousPage.Size = new System.Drawing.Size(50, 31);
            this.buttonPreviousPage.TabIndex = 32;
            this.buttonPreviousPage.Text = "◀";
            this.buttonPreviousPage.UseVisualStyleBackColor = true;
            // 
            // buttonFirstPage
            // 
            this.buttonFirstPage.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonFirstPage.Location = new System.Drawing.Point(954, 379);
            this.buttonFirstPage.Name = "buttonFirstPage";
            this.buttonFirstPage.Size = new System.Drawing.Size(50, 30);
            this.buttonFirstPage.TabIndex = 31;
            this.buttonFirstPage.Text = "l◀";
            this.buttonFirstPage.UseVisualStyleBackColor = true;
            // 
            // labelPage
            // 
            this.labelPage.AutoSize = true;
            this.labelPage.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelPage.Location = new System.Drawing.Point(359, 386);
            this.labelPage.Name = "labelPage";
            this.labelPage.Size = new System.Drawing.Size(70, 24);
            this.labelPage.TabIndex = 30;
            this.labelPage.Text = "ページ";
            // 
            // textBoxPage
            // 
            this.textBoxPage.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBoxPage.Location = new System.Drawing.Point(309, 379);
            this.textBoxPage.Name = "textBoxPage";
            this.textBoxPage.Size = new System.Drawing.Size(45, 31);
            this.textBoxPage.TabIndex = 29;
            this.textBoxPage.Text = "100";
            this.textBoxPage.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // buttonSetting
            // 
            this.buttonSetting.BackColor = System.Drawing.Color.LightGreen;
            this.buttonSetting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSetting.Font = new System.Drawing.Font("MS UI Gothic", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonSetting.Location = new System.Drawing.Point(0, 801);
            this.buttonSetting.Name = "buttonSetting";
            this.buttonSetting.Size = new System.Drawing.Size(250, 100);
            this.buttonSetting.TabIndex = 39;
            this.buttonSetting.Text = "設定";
            this.buttonSetting.UseVisualStyleBackColor = false;
            this.buttonSetting.Click += new System.EventHandler(this.buttonSetting_Click);
            // 
            // panelSetting
            // 
            this.panelSetting.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.panelSetting.Controls.Add(this.buttonSmallClassification);
            this.panelSetting.Controls.Add(this.buttonProduct);
            this.panelSetting.Controls.Add(this.buttonMajorClassification);
            this.panelSetting.Controls.Add(this.buttonMaker);
            this.panelSetting.Location = new System.Drawing.Point(1, 0);
            this.panelSetting.Name = "panelSetting";
            this.panelSetting.Size = new System.Drawing.Size(250, 901);
            this.panelSetting.TabIndex = 40;
            this.panelSetting.Paint += new System.Windows.Forms.PaintEventHandler(this.panelSetting_Paint);
            // 
            // buttonProduct
            // 
            this.buttonProduct.BackColor = System.Drawing.Color.LightGreen;
            this.buttonProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonProduct.Font = new System.Drawing.Font("MS UI Gothic", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonProduct.Location = new System.Drawing.Point(-1, 801);
            this.buttonProduct.Name = "buttonProduct";
            this.buttonProduct.Size = new System.Drawing.Size(250, 100);
            this.buttonProduct.TabIndex = 27;
            this.buttonProduct.Text = "商品管理";
            this.buttonProduct.UseVisualStyleBackColor = false;
            this.buttonProduct.Click += new System.EventHandler(this.buttonEmployee_Click);
            // 
            // buttonMajorClassification
            // 
            this.buttonMajorClassification.BackColor = System.Drawing.Color.LightGreen;
            this.buttonMajorClassification.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMajorClassification.Font = new System.Drawing.Font("MS UI Gothic", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonMajorClassification.Location = new System.Drawing.Point(-1, 129);
            this.buttonMajorClassification.Name = "buttonMajorClassification";
            this.buttonMajorClassification.Size = new System.Drawing.Size(250, 130);
            this.buttonMajorClassification.TabIndex = 2;
            this.buttonMajorClassification.Text = "大分類管理";
            this.buttonMajorClassification.UseVisualStyleBackColor = false;
            // 
            // buttonMaker
            // 
            this.buttonMaker.BackColor = System.Drawing.Color.LightGreen;
            this.buttonMaker.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMaker.Font = new System.Drawing.Font("MS UI Gothic", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonMaker.Location = new System.Drawing.Point(-1, 0);
            this.buttonMaker.Name = "buttonMaker";
            this.buttonMaker.Size = new System.Drawing.Size(250, 130);
            this.buttonMaker.TabIndex = 1;
            this.buttonMaker.Text = "メーカー管理";
            this.buttonMaker.UseVisualStyleBackColor = false;
            this.buttonMaker.Click += new System.EventHandler(this.buttonMaker_Click);
            // 
            // buttonSmallClassification
            // 
            this.buttonSmallClassification.BackColor = System.Drawing.Color.LightGreen;
            this.buttonSmallClassification.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSmallClassification.Font = new System.Drawing.Font("MS UI Gothic", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonSmallClassification.Location = new System.Drawing.Point(-1, 258);
            this.buttonSmallClassification.Name = "buttonSmallClassification";
            this.buttonSmallClassification.Size = new System.Drawing.Size(250, 130);
            this.buttonSmallClassification.TabIndex = 28;
            this.buttonSmallClassification.Text = "小分類管理";
            this.buttonSmallClassification.UseVisualStyleBackColor = false;
            // 
            // userControlMaker1
            // 
            this.userControlMaker1.BackColor = System.Drawing.Color.Honeydew;
            this.userControlMaker1.Location = new System.Drawing.Point(250, 100);
            this.userControlMaker1.Name = "userControlMaker1";
            this.userControlMaker1.Size = new System.Drawing.Size(1670, 980);
            this.userControlMaker1.TabIndex = 38;
            // 
            // FormProduct
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Honeydew;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.userControlMaker1);
            this.Controls.Add(this.buttonPageSizeChange);
            this.Controls.Add(this.textBoxPageSize);
            this.Controls.Add(this.labelPageSize);
            this.Controls.Add(this.buttonLastPage);
            this.Controls.Add(this.buttonNextPage);
            this.Controls.Add(this.buttonPreviousPage);
            this.Controls.Add(this.buttonFirstPage);
            this.Controls.Add(this.labelPage);
            this.Controls.Add(this.textBoxPage);
            this.Controls.Add(this.dataGridViewProduct);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panelLeft);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormProduct";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FormProduct_Load);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelLeft.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProduct)).EndInit();
            this.panelSetting.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Label labelUserName;
        private System.Windows.Forms.Label labelDay;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.Button buttonSaisyou;
        private System.Windows.Forms.Label labelProduct;
        private System.Windows.Forms.Button buttonFormDel;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Button buttonLogout;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.Button buttonRegist;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ComboBox comboBoxMaker;
        private System.Windows.Forms.TextBox textBoxPrID;
        private System.Windows.Forms.Label labelPrHidden;
        private System.Windows.Forms.TextBox textBoxPrHidden;
        private System.Windows.Forms.Label labelPrID;
        private System.Windows.Forms.CheckBox checkBoxPrFlag;
        private System.Windows.Forms.Label labelMName;
        private System.Windows.Forms.TextBox textBoxPrSafetyStock;
        private System.Windows.Forms.Label labelMaker;
        private System.Windows.Forms.Label labelPrSafetyStock;
        private System.Windows.Forms.TextBox textBoxPrName;
        private System.Windows.Forms.TextBox textBoxPrModelNumber;
        private System.Windows.Forms.Label labelColor;
        private System.Windows.Forms.Label labelPrModelNumber;
        private System.Windows.Forms.TextBox textBoxColor;
        private System.Windows.Forms.TextBox textBoxJCode;
        private System.Windows.Forms.Label labelJcode;
        private System.Windows.Forms.Label labelSc;
        private System.Windows.Forms.ComboBox comboBoxSc;
        private System.Windows.Forms.Label labelPrReleaseDate;
        private System.Windows.Forms.DateTimePicker DateTimePickerPrReleaseDate;
        private System.Windows.Forms.DataGridView dataGridViewProduct;
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
        private System.Windows.Forms.ComboBox comboBoxMc;
        private System.Windows.Forms.Label labelMc;
        private System.Windows.Forms.Button buttonSetting;
        private System.Windows.Forms.Panel panelSetting;
        private System.Windows.Forms.Button buttonProduct;
        private System.Windows.Forms.Button buttonMajorClassification;
        private System.Windows.Forms.Button buttonMaker;
        private System.Windows.Forms.Button buttonSmallClassification;
        private UserControlMaker userControlMaker1;
    }
}