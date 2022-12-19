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
    public partial class UserControlMaker : UserControl
    {
        //データベースメーカテーブルアクセス用クラスのインスタンス化
        MakerDataAccess makerDataAccess = new MakerDataAccess();
        //入力形式チェック用クラスのインスタンス化
        DataInputFormCheck dataInputFormCheck = new DataInputFormCheck();
        //データグリッドビュー用のメーカデータ
        private static List<M_MakerDsp> Maker;
        public UserControlMaker()
        {
            InitializeComponent();
        }




        private void UserControlMaker_Load(object sender, EventArgs e)
        {
            //非表示理由タブ選択不可、入力不可
            textBoxMaHidden.TabStop = false;
            textBoxMaHidden.ReadOnly = true;
            //データグリッドビューの設定
            SetFormDataGridView();

        }


        ///////////////メーカ情報登録////////////////////

        private void buttonResist_Click(object sender, EventArgs e)
        {
            //4.2.1.1 妥当なメーカデータ取得
            if (!GetValidDataAtRegistration())
                return;

            //4.2.1.2 メーカ情報作成
            var regMaker = GenerateDataAtRegistration();

            //4.2.1.3メーカ情報登録
            RegistrationStaff(regMaker);

        }
        ///////////////////////////////
        //　4.2.1.1 妥当なメーカデータ取得
        //メソッド名：GetValidDataAtRegistration()
        //引　数   ：なし
        //戻り値   ：true or false
        //機　能   ：入力データの形式チェック
        //          ：エラーがない場合True
        //          ：エラーがある場合False
        ///////////////////////////////
        private bool GetValidDataAtRegistration()
        {
            // メーカIDの適否
            if (!String.IsNullOrEmpty(textBoxMaID.Text.Trim()))
            {
                // メーカIDは入力不要です
                MessageBox.Show("メーカIDは入力不要です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxMaID.Focus();
                return false;
            }
            // メーカ名の適否
            if (!String.IsNullOrEmpty(textBoxMaName.Text.Trim()))
            {
                if (textBoxMaName.TextLength > 50)
                {
                // メーカ名は50字以下です
                    MessageBox.Show("メーカ名は50文字以下です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxMaName.Focus();
                    return false;
                }
            }
            else
            {
                // メーカ名は入力不要です
                MessageBox.Show("メーカ名を入力してください", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxMaName.Focus();
                return false;
            }
            // 電話番号の適否
            if (!String.IsNullOrEmpty(textBoxMaPhone.Text.Trim()))
            {
                // 電話番号の半角数値ハイフンチェック
                if (!dataInputFormCheck.CheckNumericHyphen(textBoxMaPhone.Text.Trim()))
                {
                    MessageBox.Show("電話番号の入力形式が正しくありません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxMaPhone.Focus();
                    return false;
                }
                // 文字数
                if (textBoxMaPhone.TextLength > 13)
                {
                    MessageBox.Show("電話番号は13文字以下です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxMaPhone.Focus();
                    return false;
                }
            }
            else
            {
                MessageBox.Show("電話番号が入力されていません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxMaPhone.Focus();
                return false;
            }
            // FAXの適否
            if (!String.IsNullOrEmpty(textBoxMaFAX.Text.Trim()))
            {
                //FAXの半角英数字チェック
                if (!dataInputFormCheck.CheckNumericHyphen(textBoxMaFAX.Text.Trim()))
                {
                    MessageBox.Show("FAXの入力形式が正しくありません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxMaFAX.Focus();
                    return false;
                }
                //文字数
                if (textBoxMaFAX.TextLength > 13)
                {
                    MessageBox.Show("FAXは13文字以下です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxMaFAX.Focus();
                    return false;
                }
            }
            else
            {
                //FAXを入力してください
                MessageBox.Show("FAXを入力してください", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxMaFAX.Focus();
                return false;
            }
            // 郵便番号の適否
            if (!String.IsNullOrEmpty(textBoxMaPostal.Text.Trim()))
            {
                //郵便番号の半角英数字チェック
                if (!dataInputFormCheck.CheckNumeric(textBoxMaPostal.Text.Trim()))
                {
                    //MessageBox.Show("郵便番号は半角数値です");
                    MessageBox.Show("郵便番号は半角数値です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxMaPostal.Focus();
                    return false;
                }
                //文字数
                if (textBoxMaPostal.TextLength != 7)
                {
                //MessageBox.Show("郵便番号は7文字です");
                    MessageBox.Show("郵便番号は7文字です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxMaPostal.Focus();
                    return false;
                }
            }
            else
            {
                MessageBox.Show("郵便番号を入力してください", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxMaPostal.Focus();
                return false;
            }
            // 住所の適否
            if (!String.IsNullOrEmpty(textBoxMaAddress.Text.Trim()))
            {
                // 文字数
                if (textBoxMaAddress.TextLength > 50)
                {
                //MessageBox.Show("住所は50文字以下です");
                    MessageBox.Show("住所は50文字以下です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxMaAddress.Focus();
                    return false;
                }
            }
            else
            {
                MessageBox.Show("住所を入力してください", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxMaAddress.Focus();
                return false;
            }
            // 非表示フラグの適否
            if (checkBoxMaFlag.CheckState == CheckState.Indeterminate)
            {
                MessageBox.Show(" 非表示フラグが不確定の状態です");
                checkBoxMaFlag.Focus();
                return false;
            }
            // 非表示理由の適否
            if (String.IsNullOrEmpty(textBoxMaHidden.Text.Trim()))
            {
                MessageBox.Show("非表示理由を入力してください", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxMaHidden.Focus();
                return false;
            }
            return true;
        }

        ///////////////////////////////
        //　4.2.1.2 メーカ情報作成
        //メソッド名：GenerateDataAtRegistration()
        //引　数   ：なし
        //戻り値   ：メーカ登録情報
        //機　能   ：登録データのセット
        ///////////////////////////////
        private M_Maker GenerateDataAtRegistration()
        {
            return new M_Maker
            {
                MaName = textBoxMaName.Text.Trim(),
                MaPhone = textBoxMaPhone.Text.Trim(),
                MaFAX = textBoxMaFAX.Text.Trim(),
                MaPostal = textBoxMaPostal.Text.Trim(),
                MaAdress = textBoxMaAddress.Text.Trim(),
                MaFlag = 0,
                MaHidden = String.Empty
            };
        }
        ///////////////////////////////
        //　4.2.1.3 メーカ情報登録
        //メソッド名：RegistrationStaff()
        //引　数   ：メーカ情報
        //戻り値   ：なし
        //機　能   ：メーカ情報の登録
        ///////////////////////////////
        private void RegistrationStaff(M_Maker regMaker)
        {
            // 登録確認メッセージ
            DialogResult result = MessageBox.Show("メーカデータを登録してよろしいですか?");
            if (result == DialogResult.Cancel)
                return;

            // 役職情報の登録
            bool flg = makerDataAccess.AddMakerData(regMaker);
            if (flg == true)
                MessageBox.Show("データを登録しました","追加確認",MessageBoxButtons.OK,MessageBoxIcon.Information);
            else
                MessageBox.Show("データの登録に失敗しました","追加確認",MessageBoxButtons.OK,MessageBoxIcon.Error);

            textBoxMaID.Focus();

            // 入力エリアのクリア
            ClearInput();

            // データグリッドビューの表示
            GetDataGridView();
        }
        //データグリッドビュー設定

        ///////////////////////////////
        //メソッド名：PageSizeCheck()
        //引　数   ：なし
        //戻り値   ：true or false
        //機　能   ：入力データの形式チェック
        //          ：エラーがない場合True
        //          ：エラーがある場合False
        ///////////////////////////////
        private bool PageSizeCheck()
        {
            if (!String.IsNullOrEmpty(textBoxPageSize.Text.Trim()))
            {
                if (!dataInputFormCheck.CheckNumeric(textBoxPageSize.Text.Trim()))
                {
                    MessageBox.Show("ページ行数は半角数値のみです", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxPageSize.Focus();
                    return false;
                }
                if (int.Parse(textBoxPageSize.Text) <= 0)
                {
                    MessageBox.Show("ページ行数は1以上です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxPageSize.Focus();
                    return false;

                }
            }
            else
            {
                MessageBox.Show("ページ行数が入力されていません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxPageSize.Focus();
                return false;

            }
            return true;
        }
        ///////////////////////////////
        //メソッド名：PageCheck()
        //引　数   ：なし
        //戻り値   ：true or false
        //機　能   ：入力データの形式チェック
        //          ：エラーがない場合True
        //          ：エラーがある場合False
        ///////////////////////////////
        private bool PageCheck()
        {
            if (!String.IsNullOrEmpty(textBoxPage.Text.Trim()))
            {
                if (!dataInputFormCheck.CheckNumeric(textBoxPage.Text.Trim()))
                {
                    MessageBox.Show("ページ数は半角数値のみです", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxPage.Focus();
                    return false;
                }
                if (int.Parse(textBoxPage.Text) <= 0)
                {
                    MessageBox.Show("ページ数は1以上です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxPage.Focus();
                    return false;

                }
            }
            else
            {
                MessageBox.Show("ページ数が入力されていません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxPage.Focus();
                return false;

            }
            return true;
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
            textBoxPageSize.Text = "20";
            //dataGridViewのページ番号指定
            textBoxPage.Text = "1";
            //読み取り専用に指定
            dataGridViewMaker.ReadOnly = true;
            //直接のサイズの変更を不可
            dataGridViewMaker.AllowUserToResizeRows = false;
            dataGridViewMaker.AllowUserToResizeColumns = false;
            //直接の登録を不可にする
            dataGridViewMaker.AllowUserToAddRows = false;
            //行内をクリックすることで行を選択
            dataGridViewMaker.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //奇数行の色を変更
            dataGridViewMaker.AlternatingRowsDefaultCellStyle.BackColor = Color.Honeydew;
            //ヘッダー位置の指定
            dataGridViewMaker.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //データグリッドビューのデータ取得
            GetDataGridView();
        }
        ///////////////////////////////
        //メソッド名：GetDataGridView()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：データグリッドビューに表示するデータの取得
        ///////////////////////////////
        private void GetDataGridView()
        {
            // メーカデータの取得
            Maker = makerDataAccess.GetMakerData();

            // DataGridViewに表示するデータを指定
            SetDataGridView();
        }
        ///////////////////////////////
        //メソッド名：GetHiddenDataGridView()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：データグリッドビューに表示する非表示データの取得
        ///////////////////////////////
        private void GetHiddenDataGridView()
        {
            // メーカデータの取得
            Maker = makerDataAccess.GetMakerHiddenData();

            // DataGridViewに表示するデータを指定
            SetDataGridView();
        }
        ///////////////////////////////
        //メソッド名：SetDataGridView()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：データグリッドビューへの表示
        ///////////////////////////////
        private void SetDataGridView()
        {
            if (!PageSizeCheck())
                return;

            int pageSize = int.Parse(textBoxPageSize.Text);
            int pageNo = int.Parse(textBoxPage.Text) - 1;
            dataGridViewMaker.DataSource = Maker.Skip(pageSize * pageNo).Take(pageSize).ToList();
            //各列幅の指定
            dataGridViewMaker.Columns[0].Width = 50;//ID
            dataGridViewMaker.Columns[1].Width = 300;//name
            dataGridViewMaker.Columns[2].Width = 100;//juusyo
            dataGridViewMaker.Columns[3].Width = 100;//denwa
            dataGridViewMaker.Columns[4].Width = 100;//yuubinn
            dataGridViewMaker.Columns[5].Width = 400;//fax
            dataGridViewMaker.Columns[6].Visible = false;//huragu
            dataGridViewMaker.Columns[7].Width = 514;//riyuu

            //各列の文字位置の指定
            dataGridViewMaker.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewMaker.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewMaker.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewMaker.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewMaker.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewMaker.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewMaker.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewMaker.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            //dataGridViewの総ページ数
            labelPage.Text = "/" + ((int)Math.Ceiling(Maker.Count / (double)pageSize)) + "ページ";

            dataGridViewMaker.Refresh();
        }
        ///////////////////////////////
        //メソッド名：buttonPageSizeChange_Click()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：データグリッドビューの表示件数変更
        ///////////////////////////////

        private void buttonPageSizeChange_Click(object sender, EventArgs e)
        {
            textBoxPage.Text = 1.ToString();

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
            if (!PageSizeCheck())
                return;

            int pageSize = int.Parse(textBoxPageSize.Text);
            dataGridViewMaker.DataSource = Maker.Take(pageSize).ToList();

            // DataGridViewを更新
            dataGridViewMaker.Refresh();
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
            if (!PageSizeCheck())
                return;
            int pageSize = int.Parse(textBoxPageSize.Text.Trim());
            if (!PageCheck())
                return;
            int pageNo = int.Parse(textBoxPage.Text) - 2;
            dataGridViewMaker.DataSource = Maker.Skip(pageSize * pageNo).Take(pageSize).ToList();

            // DataGridViewを更新
            dataGridViewMaker.Refresh();
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
            if (!PageSizeCheck())
                return;
            int pageSize = int.Parse(textBoxPageSize.Text.Trim());
            if (!PageCheck())
                return;
            int pageNo = int.Parse(textBoxPage.Text);
            //最終ページの計算
            int lastNo = (int)Math.Ceiling(Maker.Count / (double)pageSize) - 1;
            //最終ページでなければ
            if (pageNo <= lastNo)
                dataGridViewMaker.DataSource = Maker.Skip(pageSize * pageNo).Take(pageSize).ToList();

            // DataGridViewを更新
            dataGridViewMaker.Refresh();
            //ページ番号の設定
            int lastPage = (int)Math.Ceiling(Maker.Count / (double)pageSize);
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
            if (!PageSizeCheck())
                return;

            int pageSize = int.Parse(textBoxPageSize.Text);
            //最終ページの計算
            int pageNo = (int)Math.Ceiling(Maker.Count / (double)pageSize) - 1;
            dataGridViewMaker.DataSource = Maker.Skip(pageSize * pageNo).Take(pageSize).ToList();

            // DataGridViewを更新
            dataGridViewMaker.Refresh();
            //ページ番号の設定
            textBoxPage.Text = (pageNo + 1).ToString();

        }
        ///////////////////////////////
        //メソッド名：ClearInput()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：入力エリアをクリア
        ///////////////////////////////
        private void ClearInput()
        {
            textBoxMaID.Text = "";
            textBoxMaName.Text = "";
            textBoxMaPhone.Text = "";
            textBoxMaPostal.Text = "";
            textBoxMaFAX.Text = "";
            checkBoxMaFlag.Checked = false;
            textBoxMaHidden.Text = "";

        }
        ///////////////メーカ情報更新//////////////////

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            // 4.2.2.1 妥当なメーカデータ取得
            if (!GetValidDataAtUpdate())
                return;

            // 4.2.2.2　メーカ情報作成
            var updMaker = GenerateDataAtUpdate();

            // 4.2.2.3 メーカ情報更新
            UpdateMaker(updMaker);

        }
        ///////////////////////////////
        //  4.2.2.1 妥当なメーカデータ取得
        //メソッド名：GetValidDataAtUpdate()
        //引　数   ：なし
        //戻り値   ：true or false
        //機　能   ：入力データの形式チェック
        //          ：エラーがない場合True
        //          ：エラーがある場合False
        ///////////////////////////////
        private bool GetValidDataAtUpdate()
        {
            // メーカIDの適否
            if (!String.IsNullOrEmpty(textBoxMaID.Text.Trim()))
            {
                // メーカIDの半角英数字チェック
                if (!dataInputFormCheck.CheckHalfAlphabetNumeric(textBoxMaID.Text.Trim()))
                {
                    MessageBox.Show("メーカIDは半角英数字です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxMaID.Focus();
                    return false;
                }
                // メーカIDの文字数チェック
                if (textBoxMaID.TextLength > 4)
                {
                    MessageBox.Show("メーカIDは4文字以下です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxMaID.Focus();
                    return false;
                }
                // メーカIDの存在チェック
                if (!makerDataAccess.CheckMakerCDExistence(int.Parse(textBoxMaID.Text.Trim())))
                {
                    MessageBox.Show("入力されたメーカIDは存在しません");
                    textBoxMaID.Focus();
                    return false;
                }
            }
            else
            {
                MessageBox.Show("メーカIDが入力されていません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxMaID.Focus();
                return false;
            }
            // メーカ名の適否
            if (!String.IsNullOrEmpty(textBoxMaName.Text.Trim()))
            {
                // メーカ名の文字数チェック
                if (textBoxMaName.TextLength > 50)
                {
                    MessageBox.Show("メーカ名50文字以下です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxMaName.Focus();
                    return false;
                }
            }
            else
            {
                MessageBox.Show("メーカ名が入力されていません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxMaName.Focus();
                return false;
            }
            // 電話番号の適否
            if (!String.IsNullOrEmpty(textBoxMaPhone.Text.Trim()))
            {
                // 電話番号の文字種チェック
                if (!dataInputFormCheck.CheckNumericHyphen(textBoxMaPhone.Text.Trim()))
                {
                    MessageBox.Show("電話番号の入力形式が正しくありません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxMaPhone.Focus();
                    return false;
                }
                // 電話番号の文字数チェック
                if (textBoxMaPhone.TextLength > 13)
                {
                    MessageBox.Show("電話番号は13文字以下です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxMaPhone.Focus();
                    return false;
                }
            }
            else
            {
                MessageBox.Show("電話番号が入力されていません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxMaPhone.Focus();
                return false;
            }
            // FAXの適否
            if (!String.IsNullOrEmpty(textBoxMaFAX.Text.Trim()))
            {
                // FAXの文字種チェック
                if (!dataInputFormCheck.CheckNumericHyphen(textBoxMaFAX.Text.Trim()))
                {
                    MessageBox.Show("FAXの入力形式が正しくありません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxMaFAX.Focus();
                    return false;
                }
                // FAXの文字数チェック
                if (textBoxMaFAX.TextLength > 13)
                {
                    MessageBox.Show("FAXは13文字以下です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxMaFAX.Focus();
                    return false;
                }
            }
            else
            {
                MessageBox.Show("FAXが入力されていません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxMaFAX.Focus();
                return false;
            }
            // 郵便番号の適否
            if (!String.IsNullOrEmpty(textBoxMaPostal.Text.Trim()))
            {
                //郵便番号の半角英数字チェック
                if (!dataInputFormCheck.CheckNumeric(textBoxMaPostal.Text.Trim()))
                {
                    //MessageBox.Show("郵便番号は半角数値です");
                    MessageBox.Show("郵便番号は半角数値です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxMaPostal.Focus();
                    return false;
                }
                //文字数
                if (textBoxMaPostal.TextLength != 7)
                {
                    //MessageBox.Show("郵便番号は7文字です");
                    MessageBox.Show("郵便番号は7文字です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxMaPostal.Focus();
                    return false;
                }
            }
            else
            {
                MessageBox.Show("郵便番号を入力してください", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxMaPostal.Focus();
                return false;
            }
            // 住所の適否
            if (!String.IsNullOrEmpty(textBoxMaAddress.Text.Trim()))
            {
                // 文字数
                if (textBoxMaAddress.TextLength > 50)
                {
                    //MessageBox.Show("住所は50文字以下です");
                    MessageBox.Show("住所は50文字以下です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxMaAddress.Focus();
                    return false;
                }
            }
            else
            {
                MessageBox.Show("住所を入力してください", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxMaAddress.Focus();
                return false;
            }
            // 非表示フラグの適否
            if (checkBoxMaFlag.CheckState == CheckState.Indeterminate)
            {
                MessageBox.Show(" 非表示フラグが不確定の状態です");
                checkBoxMaFlag.Focus();
                return false;
            }
            // 非表示理由の適否
            if (String.IsNullOrEmpty(textBoxMaHidden.Text.Trim()))
            {
                MessageBox.Show("非表示理由を入力してください", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxMaHidden.Focus();
                return false;
            }
            return true;
        }
        ///////////////////////////////
        //　4.2.2.2 メーカ情報作成
        //メソッド名：GenerateDataAtUpdate()
        //引　数   ：なし
        //戻り値   ：メーカ更新情報
        //機　能   ：更新データのセット
        ///////////////////////////////
        private M_Maker GenerateDataAtUpdate()
        {
            int MaFlag = 0;
            if (checkBoxMaFlag.Checked == true)
            {
                MaFlag = 2;
            }

            return new M_Maker
            {
                MaID = int.Parse(textBoxMaID.Text.Trim()),
                MaName = textBoxMaName.Text.Trim(),
                MaPhone = textBoxMaPhone.Text.Trim(),
                MaFAX = textBoxMaFAX.Text.Trim(),
                MaPostal = textBoxMaPostal.Text.Trim(),
                MaAdress = textBoxMaAddress.Text.Trim(),
                MaFlag = MaFlag,
                MaHidden = String.Empty
            };
        }
        ///////////////////////////////
        //　4.2.2.3 メーカ情報更新
        //メソッド名：UpdateMaker()
        //引　数   ：メーカ情報
        //戻り値   ：なし
        //機　能   ：メーカ情報の更新
        ///////////////////////////////
        private void UpdateMaker(M_Maker updMaker)
        {
            // 更新確認メッセージ
            DialogResult result = MessageBox.Show("メーカデータを更新してよろしいですか?");
            if (result == DialogResult.Cancel)
                return;

            // 役職情報の更新
            bool flg = makerDataAccess.UpdateMakerData(updMaker);
            if (flg == true)
                //MessageBox.Show("データを更新しました。");
                MessageBox.Show("データを更新しました", "追加確認", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                //MessageBox.Show("データの更新に失敗しました。");
                MessageBox.Show("データの更新に失敗しました", "追加確認", MessageBoxButtons.OK, MessageBoxIcon.Error);

            textBoxMaID.Focus();

            // 入力エリアのクリア
            ClearInput();

            // データグリッドビューの表示
            GetDataGridView();
        }

        ///////////メーカ情報検索/////////////

        private void buttonSearch_Click(object sender, EventArgs e)
        {

            //妥当な顧客データ取得
            if (!GetValidDataAtSelect())
                return;

            // 顧客情報抽出
            GenerateDataAtSelect();

            //  顧客抽出結果表示
            SetSelectData();

        }
        ///////////////////////////////
        //　4.2.4.1 妥当なメーカデータ取得
        //メソッド名：GetValidDataAtSlect()
        //引　数   ：なし
        //戻り値   ：true or false
        //機　能   ：入力データの形式チェック
        //          ：エラーがない場合True
        //          ：エラーがある場合False
        ///////////////////////////////
        private bool GetValidDataAtSelect()
        {
            // メーカIDの適否
            if (!String.IsNullOrEmpty(textBoxMaID.Text.Trim()))
            {
                // メーカIDの半角英数字チェック
                if (!dataInputFormCheck.CheckHalfAlphabetNumeric(textBoxMaID.Text.Trim()))
                {
                    MessageBox.Show("メーカIDは半角英数字です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxMaID.Focus();
                    return false;
                }
                // メーカIDの文字数チェック
                if (textBoxMaID.TextLength > 4)
                {
                    MessageBox.Show("メーカIDは4文字以下です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxMaID.Focus();
                    return false;
                }
                // メーカIDの存在チェック
                if (!makerDataAccess.CheckMakerCDExistence(int.Parse(textBoxMaID.Text.Trim())))
                {
                    MessageBox.Show("入力されたメーカIDは存在しません");
                    textBoxMaID.Focus();
                    return false;
                }
            }

            // メーカ名の適否
            if (!String.IsNullOrEmpty(textBoxMaName.Text.Trim()))
            {
                // メーカ名の文字数チェック
                if (textBoxMaName.TextLength > 50)
                {
                    MessageBox.Show("メーカ名50文字以下です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxMaName.Focus();
                    return false;
                }
            }

            // 電話番号の適否
            if (!String.IsNullOrEmpty(textBoxMaPhone.Text.Trim()))
            {
                // 電話番号の文字種チェック
                if (!dataInputFormCheck.CheckNumericHyphen(textBoxMaPhone.Text.Trim()))
                {
                    MessageBox.Show("電話番号の入力形式が正しくありません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxMaPhone.Focus();
                    return false;
                }
                // 電話番号の文字数チェック
                if (textBoxMaPhone.TextLength > 13)
                {
                    MessageBox.Show("電話番号は13文字以下です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxMaPhone.Focus();
                    return false;
                }
            }

            // FAXの適否
            if (!String.IsNullOrEmpty(textBoxMaFAX.Text.Trim()))
            {
                // FAXの文字種チェック
                if (!dataInputFormCheck.CheckNumericHyphen(textBoxMaFAX.Text.Trim()))
                {
                    MessageBox.Show("FAXの入力形式が正しくありません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxMaFAX.Focus();
                    return false;
                }
                // FAXの文字数チェック
                if (textBoxMaFAX.TextLength > 13)
                {
                    MessageBox.Show("FAXは13文字以下です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxMaFAX.Focus();
                    return false;
                }
            }

            // 郵便番号の適否
            if (!String.IsNullOrEmpty(textBoxMaPostal.Text.Trim()))
            {
                //郵便番号の半角英数字チェック
                if (!dataInputFormCheck.CheckNumeric(textBoxMaPostal.Text.Trim()))
                {
                    //MessageBox.Show("郵便番号は半角数値です");
                    MessageBox.Show("郵便番号は半角数値です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxMaPostal.Focus();
                    return false;
                }
                //文字数
                if (textBoxMaPostal.TextLength != 7)
                {
                    //MessageBox.Show("郵便番号は7文字です");
                    MessageBox.Show("郵便番号は7文字です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxMaPostal.Focus();
                    return false;
                }
            }

            // 住所の適否
            if (!String.IsNullOrEmpty(textBoxMaAddress.Text.Trim()))
            {
                // 文字数
                if (textBoxMaAddress.TextLength > 50)
                {
                    //MessageBox.Show("住所は50文字以下です");
                    MessageBox.Show("住所は50文字以下です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxMaAddress.Focus();
                    return false;
                }
            }

            // 非表示フラグの適否
            if (checkBoxMaFlag.CheckState == CheckState.Indeterminate)
            {
                MessageBox.Show(" 非表示フラグが不確定の状態です","入力確認",MessageBoxButtons.OK,MessageBoxIcon.Error);
                checkBoxMaFlag.Focus();
                return false;
            }
            // 非表示理由の適否
            if (!String.IsNullOrEmpty(textBoxMaHidden.Text.Trim()))
            {
                MessageBox.Show("非表示理由を入力してください", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxMaHidden.Focus();
                return false;
            }

            return true;

        }
        ///////////////////////////////
        //　4.2.4.2 メーカ情報抽出
        //メソッド名：GenerateDataAtSelect()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：検索データの取得
        ///////////////////////////////
        private void GenerateDataAtSelect()
        {
            // フラグ情報
            int maFlag = 0;
            if (checkBoxMaFlag.Checked == true)
            {
                maFlag = 2;
            }

            // 検索条件のセット
            // メーカIDが入力されている場合
            if (!String.IsNullOrEmpty(textBoxMaID.Text.Trim()))      
            {
                M_MakerDsp selectCondition = new M_MakerDsp()
                {
                    MaID = int.Parse(textBoxMaID.Text.Trim()),
                    MaName = textBoxMaName.Text.Trim(),
                    MaPhone = textBoxMaPhone.Text.Trim(),
                    MaFAX = textBoxMaFAX.Text.Trim(),
                    MaPostal = textBoxMaPostal.Text.Trim(),
                    MaAdress = textBoxMaAddress.Text.Trim(),
                    MaFlag = maFlag,
                    MaHidden = textBoxMaHidden.Text.Trim()
                };

                // メーカデータの抽出
                Maker = makerDataAccess.GetMakerData(1,selectCondition);

            }
            // メーカIDが入力されていない場合
            if (String.IsNullOrEmpty(textBoxMaID.Text.Trim()))
            {
                M_MakerDsp selectCondition = new M_MakerDsp()
                {
                    MaName = textBoxMaName.Text.Trim(),
                    MaPhone = textBoxMaPhone.Text.Trim(),
                    MaFAX = textBoxMaFAX.Text.Trim(),
                    MaPostal = textBoxMaPostal.Text.Trim(),
                    MaAdress = textBoxMaAddress.Text.Trim(),
                    MaFlag = maFlag,
                    MaHidden = String.Empty
                };

                // メーカデータの抽出
                //Maker = makerDataAccess.GetMakerIDData(2, selectCondition);
            }
        }
        ///////////////////////////////
        //　4.2.4.3 メーカ抽出結果表示
        //メソッド名：SetSelectData()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：メーカ情報の表示
        ///////////////////////////////
        private void SetSelectData()
        {
            textBoxPage.Text = "1";

            int pageSize = int.Parse(textBoxPageSize.Text);

            dataGridViewMaker.DataSource = Maker;
            if (Maker.Count == 0)
            {
                MessageBox.Show("該当データが存在しません", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            labelPage.Text = "/" + ((int)Math.Ceiling(Maker.Count / (double)pageSize)) + "ページ";
            dataGridViewMaker.Refresh();
        }
        ///////////////////////////////
        //メソッド名：dataGridViewMaker_CellClick()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：データグリッドビューから選択された情報を各入力エリアにセット
        ///////////////////////////////

        private void dataGridViewMaker_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //データグリッドビューからクリックされたデータを各入力エリアへ
            textBoxMaID.Text = dataGridViewMaker.Rows[dataGridViewMaker.CurrentRow.Index].Cells[0].Value.ToString();
            textBoxMaName.Text = dataGridViewMaker.Rows[dataGridViewMaker.CurrentRow.Index].Cells[3].Value.ToString();
            textBoxMaPhone.Text = dataGridViewMaker.Rows[dataGridViewMaker.CurrentRow.Index].Cells[4].Value.ToString();
            textBoxMaFAX.Text = dataGridViewMaker.Rows[dataGridViewMaker.CurrentRow.Index].Cells[5].Value.ToString();
            textBoxMaPostal.Text = dataGridViewMaker.Rows[dataGridViewMaker.CurrentRow.Index].Cells[6].Value.ToString();
            textBoxMaAddress.Text = dataGridViewMaker.Rows[dataGridViewMaker.CurrentRow.Index].Cells[7].Value.ToString();
            //flagの値の「0」「2」をbool型に変換してチェックボックスに表示させる
            if (dataGridViewMaker.Rows[dataGridViewMaker.CurrentRow.Index].Cells[8].Value.ToString() != 2.ToString())
            {
                checkBoxMaFlag.Checked = false;
            }
            else
            {
                checkBoxMaFlag.Checked = true;
            }
            //非表示理由がnullではない場合テキストボックスに表示させる
            if (dataGridViewMaker.Rows[dataGridViewMaker.CurrentRow.Index].Cells[9].Value != null)
            {
                textBoxMaHidden.Text = dataGridViewMaker.Rows[dataGridViewMaker.CurrentRow.Index].Cells[9].Value.ToString();
            }
        }
        ///////////////////////////////
        //メソッド名：buttonList_Click()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：メーカデータの一覧表示機能
        ///////////////////////////////

        private void buttonList_Click(object sender, EventArgs e)
        {
            // 入力エリアのクリア
            ClearInput();
            // データグリッドビューの表示
            GetDataGridView();
        }
        ///////////////////////////////
        //メソッド名：buttonNotList_Click()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：メーカデータの非表示リスト表示機能
        ///////////////////////////////

        private void buttonNotList_Click(object sender, EventArgs e)
        {
            // 入力クリア
            ClearInput();
            // データグリッドビューの表示
            GetHiddenDataGridView();
        }

        private void checkBoxMaFlag_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxMaFlag.Checked == true)
            {
                textBoxMaHidden.TabStop = true;
                textBoxMaHidden.ReadOnly = false;
            }
            else
            {
                textBoxMaHidden.Text = "";
                textBoxMaHidden.TabStop = false;
                textBoxMaHidden.ReadOnly = true;

            }

        }
        //入力クリア
        private void buttonClear_Click(object sender, EventArgs e)
        {
            ClearInput();
        }
    }
}
