﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesManagement_SysDev
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            userControl11.Visible = false;

        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            userControl11.Visible = false;
            userControl21.Visible = false;
            userControl31.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }

        private void userControl11_Load(object sender, EventArgs e)
        {

        }

        private void buttonHonbu_Click(object sender, EventArgs e)
        {
            userControl21.Visible = false;
            userControl21.Visible = false;
            userControl11.Visible = true;
        }
    }
}
