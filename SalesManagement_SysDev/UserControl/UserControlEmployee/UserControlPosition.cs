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
    public partial class UserControlPosition : UserControl
    {
        DataInputFormCheck dataInputFormCheck = new DataInputFormCheck();

        MessageDsp messageDsp = new MessageDsp();
        public UserControlPosition()
        {
            InitializeComponent();
        }

        private void UserControlPosition_Load(object sender, EventArgs e)
        {

        }

        private void textBoxEmID_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelPoID_Click(object sender, EventArgs e)
        {

        }

        private void buttonResist_Click(object sender, EventArgs e)
        {
            // 8.2.1.1 妥当な役職データ取得
            if (!GetValidDataAtRegistration())
                return;

            // 8.2.1.2 役職情報作成
            var regPosition = GenerateDataAtRegistration();

            // 8.2.1.3 役職情報登録
            RegistrationPosition(regPosition);
        }
        ///////////////////////////////
        //　8.2.1.1 妥当な役職データ取得
        //メソッド名：GetValidDataAtRegistration()
        //引　数   ：なし
        //戻り値   ：true or false
        //機　能   ：入力データの形式チェック
        //          ：エラーがない場合True
        //          ：エラーがある場合False
        ///////////////////////////////
        private bool GetValidDataAtRegistration()
        {

            // 役職IDの適否
            if (!String.IsNullOrEmpty(textBoxEmID.Text.Trim()))
            {
                // 役職IDの半角英数字チェック
                if (!dataInputFormCheck.CheckHalfAlphabetNumeric(textBoxEmID.Text.Trim()))
                {
                    //MessageBox.Show("役職IDは全て半角英数字入力です");
                    MessageDsp.DspMsg("M2001");
                    textBoxEmID.Focus();
                    return false;
                }
                // 役職IDの文字数チェック
                if (textBoxEmID.TextLength != 2)
                {
                    //MessageBox.Show("役職IDは2文字です");
                    MessageDsp.DspMsg("M2002");
                    textBoxEmID.Focus();
                    return false;
                }
                // 役職IDの重複チェック
                if (positionDataAccess.CheckPositionCDExistence(textBoxEmID.Text.Trim()))
                {
                    //MessageBox.Show("入力された役職CDは既に存在します");
                    messageDsp.DspMsg("M2003");
                    textBoxEmID.Focus();
                    return false;
                }
            }
            else
            {
                //MessageBox.Show("役職CDが入力されていません");
                messageDsp.DspMsg("M2004");
                textBoxEmID.Focus();
                return false;
            }

            // 役職名の適否
            if (!String.IsNullOrEmpty(textBoxPoName.Text.Trim()))
            {
                // 役職名の全角チェック
                if (!dataInputFormCheck.CheckFullWidth(textBoxPositionName.Text.Trim()))
                {
                    //MessageBox.Show("役職名は全て全角入力です");
                    messageDsp.DspMsg("M2005");
                    textBoxPositionName.Focus();
                    return false;
                }
                // 役職名の文字数チェック
                if (textBoxPositionName.TextLength > 25)
                {
                    //MessageBox.Show("役職名は25文字以下です");
                    messageDsp.DspMsg("M2006");
                    textBoxPositionName.Focus();
                    return false;
                }
            }
            else
            {
                //MessageBox.Show("役職名が入力されていません");
                messageDsp.DspMsg("M2007");
                textBoxPositionName.Focus();
                return false;
            }

            // 削除フラグの適否
            if (checkBoxDeleteFlg.CheckState == CheckState.Indeterminate)
            {
                //MessageBox.Show("削除フラグが不確定の状態です");
                messageDsp.DspMsg("M2008");
                checkBoxDeleteFlg.Focus();
                return false;
            }

            // 備考の適否
            if (!String.IsNullOrEmpty(textBoxComments.Text.Trim()))
            {
                if (textBoxComments.TextLength > 80)
                {
                    //MessageBox.Show("備考は80文字以下です");
                    messageDsp.DspMsg("M2009");
                    textBoxComments.Focus();
                    return false;
                }
            }
            return true;
        }

        private void textBoxPoName_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxPage_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {

        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {

        }

        private void buttonList_Click(object sender, EventArgs e)
        {

        }
    }
}
