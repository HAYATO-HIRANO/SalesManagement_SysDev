using System;
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
    public partial class UserControlSalesOffice : UserControl
    {
        DataInputFormCheck dataInputFormCheck = new DataInputFormCheck();

        MessageDsp messageDsp = new MessageDsp();

        SalesOfficeDataAccess salesOfficeDataAccess = new SalesOfficeDataAccess();

        private static List<M_SalesOffice> SalesOffice;
        public UserControlSalesOffice()
        {
            InitializeComponent();
        }

        private void UserControlSalesOffice_Load(object sender, EventArgs e)
        {

        }

        private void buttonResist_Click(object sender, EventArgs e)
        {
            //6.3.1.1 妥当な営業所データ取得
            if (!GetValidDataAtRegistration())
                return;

            //6.3.1.2 営業所情報作成
            var regSalesOffice = GenerateDataAtRegistration();

            //6.3.1.3 営業所情報登録
            RegistrationSalesOffice(regSalesOffice);
        }
        ///////////////////////////////
        //　6.3.1.1 妥当な営業所データ取得
        //メソッド名：GetValidDataAtRegistration()
        //引　数   ：なし
        //戻り値   ：true or false
        //機　能   ：入力データの形式チェック
        //          ：エラーがなbbbbbbbい場合True
        //          ：エラーがある場合False
        ///////////////////////////////
        private bool GetValidDataAtRegistration()
        {
            //営業所IDの適否
            if (!String.IsNullOrEmpty(textBoxSoID.Text.Trim()))
            {
                //営業所IDの半角英数字チェック
                if (!dataInputFormCheck.CheckHalfAlphabetNumeric(textBoxSoID.Text.Trim()))
                {
                    MessageBox.Show("営業所IDは全て半角英数字入力です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //messageDsp.DspMsg("M***");
                    textBoxSoID.Focus();
                    return false;
                }
                // 営業所IDの文字数チェック
                if (textBoxSoID.TextLength != 15)
                {
                    MessageBox.Show("営業所IDは15文字です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //messageDsp.DspMsg("M***");
                    textBoxSoID.Focus();
                    return false;
                }
                //営業所ID重複チェック
                if (salesOfficeDataAccess.CheckSalesOfficeCDExistence(int.Parse(textBoxSoID.Text.Trim())))
                {
                    MessageBox.Show("入力された営業所IDは既に存在します", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxSoID.Focus();
                    return false;
                }
            }
            else
            {
                MessageBox.Show("営業所IDが入力されていません");
                //messageDsp.DspMsg("M***");
                textBoxSoID.Focus();
                return false;
            }
            //営業所名の適否
            if (!String.IsNullOrEmpty(textBoxSoName.Text.Trim()))
            {
                // 営業所名の文字数チェック
                if (textBoxSoName.TextLength > 50)
                {
                    MessageBox.Show("営業所名は50文字以下です");
                    //messageDsp.DspMsg("M***");
                    textBoxSoName.Focus();
                    return false;
                }
            }
            else
            {
                MessageBox.Show("営業所名が入力されていません");
                textBoxSoName.Focus();
                return false;

            }
            //電話番号の適否
            if (!String.IsNullOrEmpty(textBoxSoPhone.Text.Trim()))
            {
                //電話番号の全角チェック
                if (!dataInputFormCheck.CheckFullWidth(textBoxSoPhone.Text.Trim()))
                {
                    MessageBox.Show("電話番号は全て全角入力です。");
                    textBoxSoPhone.Focus();
                    return false;
                }
                //電話番号の文字数チェック
                if (textBoxSoPhone.TextLength > 13)
                {
                    MessageBox.Show("電話番号は13文字以下です。");
                    //messageDsp.DspMsg("M***");
                    textBoxSoPhone.Focus();
                    return false;
                }
            }
            else
            {
                MessageBox.Show("電話番号が入力されていません");
                textBoxSoPhone.Focus();
                return false;
            }
            //FAXの適否
            if (!String.IsNullOrEmpty(textBoxSoFAX.Text.Trim()))
            {
                //FAXの全角チェック
                if (!dataInputFormCheck.CheckFullWidth(textBoxSoFAX.Text.Trim()))
                {
                    MessageBox.Show("FAXの入力形式が正しくありません");
                    textBoxSoFAX.Focus();
                    return false;

                }
                //FAXの文字数チェック
                if (textBoxSoFAX.TextLength < 13)
                {
                    //MeaaageBox.Show("FAXは13文字以下です。")；
                    messageDsp.DspMsg("M***");
                    textBoxSoFAX.Focus();
                    return false;
                }
            }
            //郵便番号の適否
            if (!String.IsNullOrEmpty(textBoxSoPostal.Text.Trim()))
            {
                //郵便番号全角チェック
                if (!dataInputFormCheck.CheckFullWidth(textBoxSoPostal.Text.Trim()))
                {
                    MessageBox.Show("郵便番号は全て半角数値入力です。");
                    textBoxSoPostal.Focus();
                    return false;

                }
                //郵便の文字数チェック
                if (textBoxSoPostal.TextLength == 7)
                {
                    //MeaaageBox.Show("郵便番号は7文字です。")；
                    messageDsp.DspMsg("M***");
                    textBoxSoPostal.Focus();
                    return false;
                }
            }
            //住所の適否
            if (!String.IsNullOrEmpty(textBoxSoAddress.Text.Trim()))
            {
                //住所全角チェック
                if (!dataInputFormCheck.CheckFullWidth(textBoxSoAddress.Text.Trim()))
                {
                    MessageBox.Show("住所が入力されていません");
                    textBoxSoAddress.Focus();
                    return false;
                }
                //住所の文字数チェック
                if (textBoxSoAddress.TextLength < 50)
                {
                    //MeaaageBox.Show("住所は５０文字です。")；
                    messageDsp.DspMsg("M***");
                    textBoxSoAddress.Focus();
                    return false;
                }
            }

            // 削除フラグの適否
            if (checkBoxMaFlag.CheckState == CheckState.Indeterminate)
            {
                MessageBox.Show(" 非表示フラグが不確定の状態です");
                checkBoxMaFlag.Focus();
                return false;
            }
            // 備考の適否
            if (!String.IsNullOrEmpty(textBoxMaHidden.Text.Trim()))
            {
                if (textBoxMaHidden.TextLength > 100)
                {
                    MessageBox.Show("備考は80文字以下です");
                    textBoxMaHidden.Focus();
                    return false;
                }
            }
            return false;
        }
        ///////////////////////////////
        //　6.3.1.2 営業所情報作成
        //メソッド名：GenerateDataAtRegistration()
        //引　数   ：なし
        //戻り値   ：営業所登録情報
        //機　能   ：登録データのセット
        ///////////////////////////////
        private M_SalesOffice GenerateDataAtRegistration()
        {
            return new M_SalesOffice
            {
                SoID = int.Parse(textBoxSoID.Text.Trim()),
                SoName = textBoxSoName.Text.Trim(),
                SoPhone = textBoxSoPhone.Text.Trim(),
                SoFAX = textBoxSoFAX.Text.Trim(),
                SoPostal = textBoxSoPostal.Text.Trim(),
                SoAddress = textBoxSoAddress.Text.Trim(),
                SoFlag = Convert.ToInt32(checkBoxMaFlag.Checked),
                SoHidden = textBoxMaHidden.Text.Trim(),
            };
        }

        ///////////////////////////////
        //　6.3.1.3 営業所情報登録
        //メソッド名：RegistrationSalesOffice()
        //引　数   ：営業所情報
        //戻り値   ：なし
        //機　能   ：営業所データの登録
        ///////////////////////////////
        private void RegistrationSalesOffice(M_SalesOffice regSalesOffice)
        {
            // 登録確認メッセージ
            DialogResult result = MessageBox.Show("営業所データを登録してよろしいですか?");
            if (result == DialogResult.Cancel)
                return;

            // 営業所情報の登録
            bool flg = salesOfficeDataAccess.AddSalesOfficeData(regSalesOffice);
            if (flg == true)
                MessageBox.Show("データを登録しました。");
            else
                MessageBox.Show("データの登録に失敗しました。");

            textBoxSoID.Focus();

            // 入力エリアのクリア
            ClearInput();

            // データグリッドビューの表示
            GetDataGridView();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            //6.3.2.1  妥当な営業所データ取得
            if (!GetValidDataAtUpdate())
                return;

            //6.3.2.2 営業所情報作成
            var updSalesOffice = GenerateDataAtUpdate();

            //6.3.2.3 営業所情報更新
            UpdateSalesOffice(updSalesOffice);
        }
        ///////////////////////////////
        //　6.3.2.1 妥当な営業所データ取得
        //メソッド名：GetValidDataAtUpdate()
        //引　数   ：なし
        //戻り値   ：true or false
        //機　能   ：入力データの形式チェック
        //          ：エラーがない場合True
        //          ：エラーがある場合False
        ///////////////////////////////
        private bool GetValidDataAtUpdate()
        {
            //営業所ID未入力チェック
            if (!String.IsNullOrEmpty(textBoxSoID.Text.Trim()))
            {
                // 営業所IDの半角英数字チェック
                if (!dataInputFormCheck.CheckHalfAlphabetNumeric(textBoxSoID.Text.Trim()))
                {
                    //MessageBox.Show("営業所IDは全て半角英数字入力です");
                    messageDsp.DspMsg("M***");
                    textBoxSoID.Focus();
                    return false;
                }
                // 営業所IDの文字数チェック
                if (textBoxSoID.TextLength != 2)
                {
                    //MessageBox.Show("営業所IDは2文字です");
                    messageDsp.DspMsg("M***");
                    textBoxSoID.Focus();
                    return false;
                }
                // 役営業所IDの存在チェック
                if (!salesOfficeDataAccess.CheckSalesOfficeCDExistence(int.Parse(textBoxSoID.Text.Trim())))
                {
                    //MessageBox.Show("入力された営業所IDは存在しません");
                    messageDsp.DspMsg("M***");
                    textBoxSoID.Focus();
                    return false;
                }
            }
            else
            {
                //MessageBox.Show("営業所IDが入力されていません");
                messageDsp.DspMsg("M***");
                textBoxSoID.Focus();
                return false;
            }


            // 営業所名の適否
            if (!String.IsNullOrEmpty(textBoxSoName.Text.Trim()))
            {
                // 営業所名の全角チェック
                if (!dataInputFormCheck.CheckFullWidth(textBoxSoName.Text.Trim()))
                {
                    //MessageBox.Show("営業所名は全て全角入力です");
                    messageDsp.DspMsg("M***");
                    textBoxSoName.Focus();
                    return false;
                }
                // 営業所名の文字数チェック
                if (textBoxSoName.TextLength > 50)
                {
                    //MessageBox.Show("営業所名は50文字以下です");
                    messageDsp.DspMsg("M***");
                    textBoxSoName.Focus();
                    return false;
                }
            }
            else
            {
                //MessageBox.Show("営業所名が入力されていません");
                messageDsp.DspMsg("M***");
                textBoxSoName.Focus();
                return false;
            }

            //電話番号の適否
            if (!String.IsNullOrEmpty(textBoxSoPhone.Text.Trim()))
            {
                //電話番号の全角チェック
                if (!dataInputFormCheck.CheckFullWidth(textBoxSoPhone.Text.Trim()))
                {
                    //MessageBox.Show("電話番号は全て全角入力です");
                    messageDsp.DspMsg("M***");
                    textBoxSoPhone.Focus();
                    return false;
                }
                // 電話番号の文字数チェック
                if (textBoxSoPhone.TextLength > 13)
                {
                    //MessageBox.Show("電話番号は13文字以下です");
                    messageDsp.DspMsg("M***");
                    textBoxSoPhone.Focus();
                    return false;
                }
            }
            else
            {
                //MessageBox.Show("電話番号が入力されていません");
                messageDsp.DspMsg("M***");
                textBoxSoPhone.Focus();
                return false;
            }

            //FAXの適否
            if (!String.IsNullOrEmpty(textBoxSoFAX.Text.Trim()))
            {
                //FAXの全角チェック
                if (!dataInputFormCheck.CheckFullWidth(textBoxSoFAX.Text.Trim()))
                {
                    //MessageBox.Show("FAXは全て全角入力です");
                    messageDsp.DspMsg("M***");
                    textBoxSoFAX.Focus();
                    return false;
                }
                // FAXの文字数チェック
                if (textBoxSoFAX.TextLength > 13)
                {
                    //MessageBox.Show("FAXは13文字以下です");
                    messageDsp.DspMsg("M***");
                    textBoxSoFAX.Focus();
                    return false;
                }
            }
            else
            {
                //MessageBox.Show("FAXが入力されていません");
                messageDsp.DspMsg("M***");
                textBoxSoFAX.Focus();
                return false;
            }

            //郵便番号の適否
            if (!String.IsNullOrEmpty(textBoxSoPostal.Text.Trim()))
            {
                //郵便番号の全角チェック
                if (!dataInputFormCheck.CheckFullWidth(textBoxSoPostal.Text.Trim()))
                {
                    //MessageBox.Show("郵便番号は全て全角入力です");
                    messageDsp.DspMsg("M***");
                    textBoxSoPostal.Focus();
                    return false;
                }
                // 郵便番号の文字数チェック
                if (textBoxSoPostal.TextLength == 7)
                {
                    //MessageBox.Show("郵便番号は7文字です");
                    messageDsp.DspMsg("M***");
                    textBoxSoPostal.Focus();
                    return false;
                }
            }
            else
            {
                //MessageBox.Show("郵便番号が入力されていません");
                messageDsp.DspMsg("M***");
                textBoxSoPostal.Focus();
                return false;
            }

            //住所の適否
            if (!String.IsNullOrEmpty(textBoxSoAddress.Text.Trim()))
            {
                //住所の全角チェック
                if (!dataInputFormCheck.CheckFullWidth(textBoxSoAddress.Text.Trim()))
                {
                    //MessageBox.Show("住所は全て全角入力です");
                    messageDsp.DspMsg("M***");
                    textBoxSoAddress.Focus();
                    return false;
                }
                // 住所の文字数チェック
                if (textBoxSoAddress.TextLength < 50)
                {
                    //MessageBox.Show("住所は50文字以下です");
                    messageDsp.DspMsg("M***");
                    textBoxSoAddress.Focus();
                    return false;
                }
            }
            else
            {
                //MessageBox.Show("住所が入力されていません");
                messageDsp.DspMsg("M***");
                textBoxSoAddress.Focus();
                return false;
            }

            // 削除フラグの適否
            if (checkBoxMaFlag.CheckState == CheckState.Indeterminate)
            {
                //MessageBox.Show("非表示フラグが不確定の状態です");
                messageDsp.DspMsg("M***");
                checkBoxMaFlag.Focus();
                return false;
            }

            // 備考の適否
            if (!String.IsNullOrEmpty(textBoxMaHidden.Text.Trim()))
            {
                if (textBoxMaHidden.TextLength > 100)
                {
                    //MessageBox.Show("備考は100文字以下です");
                    messageDsp.DspMsg("M***");
                    textBoxMaHidden.Focus();
                    return false;
                }
            }
            return true;
        }

        ///////////////////////////////
        //　6.3.2.2 営業所情報作成
        //メソッド名：GenerateDataAtUpdate()
        //引　数   ：なし
        //戻り値   ：営業所更新情報
        //機　能   ：更新データのセット
        ///////////////////////////////
        private M_SalesOffice GenerateDataAtUpdate()
        {
            return new M_SalesOffice
            {
                SoID = int.Parse(textBoxSoID.Text.Trim()),
                SoName = textBoxSoName.Text.Trim(),
                SoPhone = textBoxSoPhone.Text.Trim(),
                SoFAX = textBoxSoFAX.Text.Trim(),
                SoPostal = textBoxSoPostal.Text.Trim(),
                SoAddress = textBoxSoAddress.Text.Trim(),
                SoFlag = Convert.ToInt32(checkBoxMaFlag.Checked),
                SoHidden = textBoxMaHidden.Text.Trim(),
            };
        }

        ///////////////////////////////
        //　6.3.2.3 営業所情報更新
        //メソッド名：UpdateSalesOffice()
        //引　数   ：営業所情報
        //戻り値   ：なし
        //機　能   ：営業所情報の更新
        ///////////////////////////////
        private void UpdateSalesOffice(M_SalesOffice updSalesOffice)
        {
            //更新確認メッセージ
            DialogResult result = messageDsp.DspMsg("M***");
            if (result == DialogResult.Cancel)
                return;

            //営業所情報の更新
            bool flg = salesOfficeDataAccess.UpdateSalesOfficeData(updSalesOffice);
            if (flg == true)
                //MessageBox.Show("データを更新しました。");
                messageDsp.DspMsg("M***");
            else
                //MessageBox.Show("データの更新に失敗しました。");
                messageDsp.DspMsg("M***");

            textBoxSoID.Focus();

            // 入力エリアのクリア
            ClearInput();

            // データグリッドビューの表示
            GetDataGridView();
        }


        private void buttonSearch_Click(object sender, EventArgs e)
        {
            //6.3.4.1 妥当な営業データ取得
            if (!GetValidDataAtSelect())
                return;
            //6.3.4.2 営業情報抽出
            GenerateDataAtSelect();

            // 8.2.4.3 営業抽出結果表示
            SetSelectData();
        }


        private void buttonClear_Click(object sender, EventArgs e)
        {
            // 入力エリアのクリア
            ClearInput();

            // データグリッドビューの表示
            SetFormDataGridView();
        }
        ///////////////////////////////
        //メソッド名：ClearInput()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：入力エリアをクリア
        ///////////////////////////////
        private void ClearInput()
        {
            textBoxSoID.Text = "";
            textBoxSoName.Text = "";
            textBoxSoPhone.Text = "";
            textBoxSoFAX.Text = "";
            textBoxSoPostal.Text = "";
            textBoxSoAddress.Text = "";


            checkBoxMaFlag.Checked = false;
        }
        ///////////////////////////////
        //メソッド名：GetDataGridView()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：データグリッドビューに表示するデータの取得
        ///////////////////////////////
        private void GetDataGridView()
        {

            // 営業データの取得
            SalesOffice = salesOfficeDataAccess.GetSalesOfficeData();

            // DataGridViewに表示するデータを指定
            SetDataGridView();
        }
        ///////////////////////////////
        //メソッド名：SetFormDataGridView()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：データグリッドビューの設定
        ///////////////////////////////
        private void SetFormDataGridView()
        {

            //dataGridViewのページサイズ指定
            textBoxPageSize.Text = "10";
            //dataGridViewのページ番号指定
            textBoxPage.Text = "1";
            //読み取り専用に指定
            dataGridViewSalesOffice.ReadOnly = true;
            //行内をクリックすることで行を選択
            dataGridViewSalesOffice.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            //ヘッダー位置の指定
            dataGridViewSalesOffice.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //データグリッドビューのデータ取得
            GetDataGridView();
        }
        ///////////////////////////////
        //メソッド名：SetDataGridView()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：データグリッドビューへの表示
        ///////////////////////////////
        private void SetDataGridView()
        {
            int pageSize = int.Parse(textBoxPageSize.Text);
            int pageNo = int.Parse(textBoxPage.Text) - 1;
            dataGridViewSalesOffice.DataSource = SalesOffice.Skip(pageSize * pageNo).Take(pageSize).ToList();
            //各列幅の指定
            dataGridViewSalesOffice.Columns[0].Width = 100;
            dataGridViewSalesOffice.Columns[1].Width = 200;
            dataGridViewSalesOffice.Columns[2].Width = 100;
            dataGridViewSalesOffice.Columns[3].Width = 400;

            //各列の文字位置の指定
            dataGridViewSalesOffice.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewSalesOffice.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewSalesOffice.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewSalesOffice.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            //dataGridViewの総ページ数
            labelPage.Text = "/" + ((int)Math.Ceiling(SalesOffice.Count / (double)pageSize)) + "ページ";

            dataGridViewSalesOffice.Refresh();
        }
        ///////////////////////////////
        //メソッド名：buttonPageSizeChange_Click()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：データグリッドビューの表示件数変更
        ///////////////////////////////
        private void buttonPageSizeChange_Click(object sender, EventArgs e)
        {
            SetDataGridView();
        }
        ///////////////////////////////
        //メソッド名：buttonFirstPage_Click()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：データグリッドビューの先頭ページ表示
        ///////////////////////////////
        private void buttonFirstPage_Click(object sender, EventArgs e)
        {
            int pageSize = int.Parse(textBoxPageSize.Text);
            dataGridViewSalesOffice.DataSource = SalesOffice.Take(pageSize).ToList();

            // DataGridViewを更新
            dataGridViewSalesOffice.Refresh();
            //ページ番号の設定
            textBoxPage.Text = "1";
        }
        ///////////////////////////////
        //メソッド名：buttonPreviousPage_Click()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：データグリッドビューの前ページ表示
        ///////////////////////////////
        private void buttonPreviousPage_Click(object sender, EventArgs e)
        {
            int pageSize = int.Parse(textBoxPageSize.Text);
            int pageNo = int.Parse(textBoxPage.Text) - 2;
            dataGridViewSalesOffice.DataSource = SalesOffice.Skip(pageSize * pageNo).Take(pageSize).ToList();

            // DataGridViewを更新
            dataGridViewSalesOffice.Refresh();
            //ページ番号の設定
            if (pageNo + 1 > 1)
                textBoxPage.Text = (pageNo + 1).ToString();
            else
                textBoxPage.Text = "1";
        }
        ///////////////////////////////
        //メソッド名：buttonNextPage_Click()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：データグリッドビューの次ページ表示
        ///////////////////////////////
        private void buttonNextPage_Click(object sender, EventArgs e)
        {
            int pageSize = int.Parse(textBoxPageSize.Text);
            int pageNo = int.Parse(textBoxPage.Text);
            //最終ページの計算
            int lastNo = (int)Math.Ceiling(SalesOffice.Count / (double)pageSize) - 1;
            //最終ページでなければ
            if (pageNo <= lastNo)
                dataGridViewSalesOffice.DataSource = SalesOffice.Skip(pageSize * pageNo).Take(pageSize).ToList();

            // DataGridViewを更新
            dataGridViewSalesOffice.Refresh();
            //ページ番号の設定
            int lastPage = (int)Math.Ceiling(SalesOffice.Count / (double)pageSize);
            if (pageNo >= lastPage)
                textBoxPage.Text = lastPage.ToString();
            else
                textBoxPage.Text = (pageNo + 1).ToString();
        }
        ///////////////////////////////
        //メソッド名：buttonLastPage_Click()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：データグリッドビューの最終ページ表示
        ///////////////////////////////
        private void buttonLastPage_Click(object sender, EventArgs e)
        {
            int pageSize = int.Parse(textBoxPageSize.Text);
            //最終ページの計算
            int pageNo = (int)Math.Ceiling(SalesOffice.Count / (double)pageSize) - 1;
            dataGridViewSalesOffice.DataSource = SalesOffice.Skip(pageSize * pageNo).Take(pageSize).ToList();

            // DataGridViewを更新
            dataGridViewSalesOffice.Refresh();
            //ページ番号の設定
            textBoxPage.Text = (pageNo + 1).ToString();
        }
        ///////////////////////////////
        //　6.3.4.1 妥当な営業データ取得
        //メソッド名：GetValidDataAtSlect()
        //引　数   ：なし
        //戻り値   ：true or false
        //機　能   ：入力データの形式チェック
        //          ：エラーがない場合True
        //          ：エラーがある場合False
        ///////////////////////////////
        private bool GetValidDataAtSelect()
        {
            //営業ID入力時チェック
            if (!String.IsNullOrEmpty(textBoxSoID.Text.Trim()))
            {
                //営業IDの半角英数字チェック
                if (!dataInputFormCheck.CheckHalfAlphabetNumeric(textBoxSoID.Text.Trim()))
                {
                    //MessageBox.Show("営業CDは全て半角英数字入力です");
                    messageDsp.DspMsg("M***");
                    textBoxSoID.Focus();
                    return false;
                }
                // 営業IDの文字数チェック
                if (textBoxSoID.TextLength > 2)
                {
                    //MessageBox.Show("営業IDは2 文字までです");
                    messageDsp.DspMsg("M***");
                    textBoxSoID.Focus();
                    return false;
                }
            }

            //営業所名の適否
            if (!String.IsNullOrEmpty(textBoxSoName.Text.Trim()))
            {
                //営業所名の半角英数字チェック
                if (!dataInputFormCheck.CheckHalfAlphabetNumeric(textBoxSoName.Text.Trim()))
                {
                    //MessageBox.Show("営業所名は全て半角英数字入力です");
                    messageDsp.DspMsg("M***");
                    textBoxSoName.Focus();
                    return false;
                }
                // 営業所名の文字数チェック
                if (textBoxSoName.TextLength > 50)
                {
                    //MessageBox.Show("営業所名は50文字までです");
                    messageDsp.DspMsg("M***");
                    textBoxSoName.Focus();
                    return false;
                }
            }
            //電話番号の適否
            if (!String.IsNullOrEmpty(textBoxSoPhone.Text.Trim()))
            {
                //電話番号の半角英数字チェック
                if (!dataInputFormCheck.CheckHalfAlphabetNumeric(textBoxSoPhone.Text.Trim()))
                {
                    //MessageBox.Show("電話番号は全て半角英数字入力です");
                    messageDsp.DspMsg("M***");
                    textBoxSoPhone.Focus();
                    return false;
                }
                // 電話番号の文字数チェック
                if (textBoxSoPhone.TextLength > 13)
                {
                    //MessageBox.Show("電話番号は13文字までです");
                    messageDsp.DspMsg("M***");
                    textBoxSoPhone.Focus();
                    return false;
                }
            }

            //FAXの適否
            if (!String.IsNullOrEmpty(textBoxSoFAX.Text.Trim()))
            {
                //FAXの半角英数字チェック
                if (!dataInputFormCheck.CheckHalfAlphabetNumeric(textBoxSoFAX.Text.Trim()))
                {
                    //MessageBox.Show("FAXは全て半角英数字入力です");
                    messageDsp.DspMsg("M***");
                    textBoxSoFAX.Focus();
                    return false;
                }
                // FAXの文字数チェック
                if (textBoxSoFAX.TextLength > 13)
                {
                    //MessageBox.Show("FAXは13文字までです");
                    messageDsp.DspMsg("M***");
                    textBoxSoFAX.Focus();
                    return false;
                }
            }

            //郵便番号の適否
            if (!String.IsNullOrEmpty(textBoxSoPostal.Text.Trim()))
            {
                //郵便番号の半角英数字チェック
                if (!dataInputFormCheck.CheckHalfAlphabetNumeric(textBoxSoPostal.Text.Trim()))
                {
                    //MessageBox.Show("郵便番号は全て半角英数字入力です");
                    messageDsp.DspMsg("M***");
                    textBoxSoPostal.Focus();
                    return false;
                }
                // 郵便番号の文字数チェック
                if (textBoxSoPostal.TextLength == 7)
                {
                    //MessageBox.Show("郵便番号は7文字です");
                    messageDsp.DspMsg("M***");
                    textBoxSoPostal.Focus();
                    return false;
                }
            }

            //住所の適否
            if (!String.IsNullOrEmpty(textBoxSoAddress.Text.Trim()))
            {
                //住所の半角英数字チェック
                if (!dataInputFormCheck.CheckHalfAlphabetNumeric(textBoxSoAddress.Text.Trim()))
                {
                    //MessageBox.Show("住所は全て半角英数字入力です");
                    messageDsp.DspMsg("M***");
                    textBoxSoAddress.Focus();
                    return false;
                }
                // 住所の文字数チェック
                if (textBoxSoAddress.TextLength < 50)
                {
                    //MessageBox.Show("住所は50文字以下です");
                    messageDsp.DspMsg("M***");
                    textBoxSoAddress.Focus();
                    return false;
                }
            }

            //削除フラグの適否
            if (checkBoxMaFlag.CheckState == CheckState.Indeterminate)
            {
                //MessageBox.Show("非表示フラグが不確定の状態です");
                messageDsp.DspMsg("M***");
                checkBoxMaFlag.Focus();
                return false;
            }
            //備考の適否
            if (!String.IsNullOrEmpty(textBoxMaHidden.Text.Trim()))
            {
                if (textBoxMaHidden.TextLength > 100)
                {
                    //MessageBox.Show("備考は100文字以下です");
                    messageDsp.DspMsg("M***");
                    textBoxMaHidden.Focus();
                    return false;
                }
            }
            return true;
        }
        ///////////////////////////////
        //　6.3.4.2 営業情報抽出
        //メソッド名：GenerateDataAtSelect()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：営業情報の取得
        ///////////////////////////////
        private void GenerateDataAtSelect()
        {
            // 検索条件のセット
            M_SalesOffice salesOffice = new M_SalesOffice()
            {
                SoID = int.Parse(textBoxSoID.Text.Trim()),
                SoName = textBoxSoName.Text.Trim(),
                SoPhone = textBoxSoPhone.Text.Trim(),
                SoFAX = textBoxSoFAX.Text.Trim(),
                SoPostal = textBoxSoPostal.Text.Trim(),
                SoAddress = textBoxSoAddress.Text.Trim(),

            };
            //営業データの抽出
            SalesOffice = salesOfficeDataAccess.GetSalesOfficeData(salesOffice);
        }

        ///////////////////////////////
        //　6.3.4.3 営業抽出結果表示
        //メソッド名：SetSelectData()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：営業情報の表示
        ///////////////////////////////
        private void SetSelectData()
        {
            textBoxPage.Text = "1";

            int pageSize = int.Parse(textBoxPageSize.Text);

            dataGridViewSalesOffice.DataSource = SalesOffice;

            labelPage.Text = "/" + ((int)Math.Ceiling(SalesOffice.Count / (double)pageSize)) + "ページ";
            dataGridViewSalesOffice.Refresh();
        }

        private void dataGridViewSalesOffice_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}


