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
        //入力形式チェック用クラスのインスタンス化
        DataInputFormCheck dataInputFormCheck = new DataInputFormCheck();
        //データベース大分類テーブルアクセス用クラスのインスタンス化
        SalesOfficeDataAccess salesOfficeDataAccess = new SalesOfficeDataAccess();
        //データグリッドビュー用の大分類データ
        private static List<M_SalesOfficeDsp> SalesOffice;
        public UserControlSalesOffice()
        {
            InitializeComponent();
        }

        private void UserControlSalesOffice_Load(object sender, EventArgs e)
        {
            //非表示理由タブ選択不可、入力不可
            textBoxSoHidden.TabStop = false;
            textBoxSoHidden.ReadOnly = true;

            //データグリッドビューの設定
            SetFormDataGridView();
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
        //          ：エラーがない場合True
        //          ：エラーがある場合False
        ///////////////////////////////
        private bool GetValidDataAtRegistration()
        {
            //営業所IDの適否
            if (!String.IsNullOrEmpty(textBoxSoID.Text.Trim()))
            {
                MessageBox.Show("営業所IDは入力不要です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxSoID.Focus();
                return false;

            }
            //営業所名の適否
            if (!String.IsNullOrEmpty(textBoxSoName.Text.Trim()))
            {
                // 営業所名の文字数チェック
                if (textBoxSoName.TextLength > 50)
                {
                    MessageBox.Show("営業所名は50文字以下です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    textBoxSoName.Focus();
                    return false;
                }
            }
            else
            {
                MessageBox.Show("営業所名が入力されていません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxSoName.Focus();
                return false;

            }
            //電話番号の適否
            if (!String.IsNullOrEmpty(textBoxSoPhone.Text.Trim()))
            {
                //電話番号の半角数値ハイフンチェック
                if (!dataInputFormCheck.CheckNumericHyphen(textBoxSoPhone.Text.Trim()))
                {
                    MessageBox.Show("電話番号の入力形式が正しくありません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxSoPhone.Focus();
                    return false;
                }
                //電話番号の文字数チェック
                if (textBoxSoPhone.TextLength > 13)
                {
                    MessageBox.Show("電話番号は13文字以下です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    textBoxSoPhone.Focus();
                    return false;
                }
            }
            else
            {
                MessageBox.Show("電話番号が入力されていません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxSoPhone.Focus();
                return false;
            }
            //FAXの適否
            if (!String.IsNullOrEmpty(textBoxSoFAX.Text.Trim()))
            {
                //FAXの半角英数字チェック
                if (!dataInputFormCheck.CheckNumericHyphen(textBoxSoFAX.Text.Trim()))
                {
                    MessageBox.Show("FAXの入力形式が正しくありません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxSoFAX.Focus();
                    return false;

                }
                //FAXの文字数チェック
                if (textBoxSoFAX.TextLength > 13)
                {
                    MessageBox.Show("FAXは13文字以下です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    textBoxSoFAX.Focus();
                    return false;
                }
            }
            else
            {
                //FAXが入力されていません
                MessageBox.Show("FAXが入力されていません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxSoFAX.Focus();
                return false;
            }

            //郵便番号の適否
            if (!String.IsNullOrEmpty(textBoxSoPostal.Text.Trim()))
            {
                //郵便番号半角数値チェック
                if (!dataInputFormCheck.CheckNumeric(textBoxSoPostal.Text.Trim()))
                {

                    MessageBox.Show("郵便番号は半角数値です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxSoPostal.Focus();
                    return false;

                }
                //郵便の文字数チェック
                if (textBoxSoPostal.TextLength != 7)
                {
                    MessageBox.Show("郵便番号は7文字です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    textBoxSoPostal.Focus();
                    return false;
                }
            }
            else
            {
                //郵便番号が入力されていません
                MessageBox.Show("郵便番号が入力されていません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxSoPostal.Focus();
                return false;
            }

            //住所の適否
            if (!String.IsNullOrEmpty(textBoxSoAddress.Text.Trim()))
            {
                //住所の文字数チェック
                if (textBoxSoAddress.TextLength > 50)
                {
                    MessageBox.Show("住所は50文字以下です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxSoAddress.Focus();
                    return false;
                }
            }
            else
            {
                MessageBox.Show("住所が入力されていません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxSoAddress.Focus();
                return false;
            }

            // フラグの適否
            if (checkBoxSoFlag.CheckState == CheckState.Indeterminate)
            {
                MessageBox.Show(" 非表示フラグが不確定の状態です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                checkBoxSoFlag.Focus();
                return false;
            }
            if (checkBoxSoFlag.Checked == true)
            {
                MessageBox.Show("非表示フラグがチェックされています", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                checkBoxSoFlag.Focus();
                return false;
            }

            //非表示理由の適否
            if (!String.IsNullOrEmpty(textBoxSoHidden.Text.Trim()))
            {
                MessageBox.Show("非表示理由は登録できません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxSoHidden.Focus();
                return false;
            }
            return true;
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
                SoName = textBoxSoName.Text.Trim(),
                SoPhone = textBoxSoPhone.Text.Trim(),
                SoFAX = textBoxSoFAX.Text.Trim(),
                SoPostal = textBoxSoPostal.Text.Trim(),
                SoAddress = textBoxSoAddress.Text.Trim(),
                SoFlag = 0,
                SoHidden = String.Empty,
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
            DialogResult result = MessageBox.Show("営業所データを登録してよろしいですか?", "追加確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Cancel)
                return;

            // 営業所情報の登録
            bool flg = salesOfficeDataAccess.AddSalesOfficeData(regSalesOffice);
            if (flg == true)
                MessageBox.Show("データを登録しました", "追加確認", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("データの登録に失敗しました", "追加確認", MessageBoxButtons.OK, MessageBoxIcon.Error);

            textBoxSoID.Focus();

            // 入力エリアのクリア
            ClearInput();

            // データグリッドビューの表示
            GetDataGridView();
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
            //営業所IDの適否
            if (!String.IsNullOrEmpty(textBoxSoID.Text.Trim()))
            {
                // 営業所IDの半角数値チェック
                if (!dataInputFormCheck.CheckNumeric(textBoxSoID.Text.Trim()))
                {
                    MessageBox.Show("営業所IDは半角数値入力です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxSoID.Focus();
                    return false;
                }
                // 営業所IDの文字数チェック
                if (textBoxSoID.TextLength > 2)
                {
                    MessageBox.Show("営業所IDは2文字以下です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxSoID.Focus();
                    return false;
                }
                // 営業所IDの存在チェック
                if (!salesOfficeDataAccess.CheckSalesOfficeCDExistence(int.Parse(textBoxSoID.Text.Trim())))
                {
                    MessageBox.Show("入力された営業所IDは存在しません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxSoID.Focus();
                    return false;
                }
            }
            else
            {
                MessageBox.Show("営業所IDが入力されていません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxSoID.Focus();
                return false;
            }


            // 営業所名の適否
            if (!String.IsNullOrEmpty(textBoxSoName.Text.Trim()))
            {
                // 営業所名の文字数チェック
                if (textBoxSoName.TextLength > 50)
                {
                    MessageBox.Show("営業所名は50文字以下です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxSoName.Focus();
                    return false;
                }
            }
            else
            {
                MessageBox.Show("営業所名が入力されていません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxSoName.Focus();
                return false;
            }

            //電話番号の適否
            if (!String.IsNullOrEmpty(textBoxSoPhone.Text.Trim()))
            {
                //電話番号の半角数値ハイフンチェック
                if (!dataInputFormCheck.CheckNumericHyphen(textBoxSoPhone.Text.Trim()))
                {
                    MessageBox.Show("電話番号の入力形式が正しくありません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxSoPhone.Focus();
                    return false;
                }
                // 電話番号の文字数チェック
                if (textBoxSoPhone.TextLength > 13)
                {
                    MessageBox.Show("電話番号は13文字以下です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxSoPhone.Focus();
                    return false;
                }
            }
            else
            {
                MessageBox.Show("電話番号が入力されていません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxSoPhone.Focus();
                return false;
            }

            //FAXの適否
            if (!String.IsNullOrEmpty(textBoxSoFAX.Text.Trim()))
            {
                //FAXの半角英数字チェック
                if (!dataInputFormCheck.CheckNumericHyphen(textBoxSoFAX.Text.Trim()))
                {
                    MessageBox.Show("FAXの入力形式が正しくありません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxSoFAX.Focus();
                    return false;
                }
                // FAXの文字数チェック
                if (textBoxSoFAX.TextLength > 13)
                {
                    MessageBox.Show("FAXは13文字以下です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxSoFAX.Focus();
                    return false;
                }
            }
            else
            {
                //FAXが入力されていません
                MessageBox.Show("FAXが入力されていません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxSoFAX.Focus();
                return false;
            }

            //郵便番号の適否
            if (!String.IsNullOrEmpty(textBoxSoPostal.Text.Trim()))
            {
                //郵便番号の半角英数字チェック
                if (!dataInputFormCheck.CheckNumeric(textBoxSoPostal.Text.Trim()))
                {

                    MessageBox.Show("郵便番号は半角数値入力です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxSoPostal.Focus();
                    return false;
                }
                // 郵便番号の文字数チェック
                if (textBoxSoPostal.TextLength != 7)
                {
                    MessageBox.Show("郵便番号は7文字です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    textBoxSoPostal.Focus();
                    return false;
                }
            }
            else
            {
                //郵便番号を入力してください
                MessageBox.Show("郵便番号を入力してください", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxSoPostal.Focus();
                return false;
            }

            //住所の適否
            if (!String.IsNullOrEmpty(textBoxSoAddress.Text.Trim()))
            {

                // 住所の文字数チェック
                if (textBoxSoAddress.TextLength > 50)
                {
                    //MessageBox.Show("住所は50文字以下です");
                    MessageBox.Show("住所は50文字以下です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxSoAddress.Focus();
                    return false;
                }
            }
            else
            {
                //MessageBox.Show("住所が入力されていません");
                MessageBox.Show("住所が入力されていません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxSoAddress.Focus();
                return false;
            }

            // フラグの適否
            if (checkBoxSoFlag.CheckState == CheckState.Indeterminate)
            {
                MessageBox.Show("非表示フラグが不確定の状態です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                checkBoxSoFlag.Focus();
                return false;
            }

            // 非表示理由の適否
            if (checkBoxSoFlag.Checked == true && String.IsNullOrEmpty(textBoxSoHidden.Text.Trim()))
            {
                MessageBox.Show("非表示理由が入力されていません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                checkBoxSoFlag.Focus();
                return false;
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
            int SoFlag = 0;
            if (checkBoxSoFlag.Checked == true)
            {
                SoFlag = 2;
            }
            return new M_SalesOffice
            {
                SoID = int.Parse(textBoxSoID.Text.Trim()),
                SoName = textBoxSoName.Text.Trim(),
                SoPhone = textBoxSoPhone.Text.Trim(),
                SoFAX = textBoxSoFAX.Text.Trim(),
                SoPostal = textBoxSoPostal.Text.Trim(),
                SoAddress = textBoxSoAddress.Text.Trim(),
                SoFlag = SoFlag,
                SoHidden = textBoxSoHidden.Text.Trim(),
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
            DialogResult result = MessageBox.Show("データを更新しますか？", "追加確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Cancel)
                return;

            //営業所情報の更新
            bool flg = salesOfficeDataAccess.UpdateSalesOfficeData(updSalesOffice);
            if (flg == true)
                MessageBox.Show("データを更新しました", "追加確認", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("データの更新に失敗しました", "追加確認", MessageBoxButtons.OK, MessageBoxIcon.Error);

            textBoxSoID.Focus();

            // 入力エリアのクリア
            ClearInput();

            // データグリッドビューの表示
            GetDataGridView();
        }

        //////検索/////
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
                //営業ID文字チェック
                if (!dataInputFormCheck.CheckNumeric(textBoxSoID.Text.Trim()))
                {
                    MessageBox.Show("営業IDは半角数値入力です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxSoID.Focus();
                    return false;
                }
                // 営業IDの文字数チェック
                if (textBoxSoID.TextLength > 2)
                {
                    MessageBox.Show("営業IDは2文字以下です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxSoID.Focus();
                    return false;
                }
                // 営業IDの存在チェック
                if (!salesOfficeDataAccess.CheckSalesOfficeCDExistence(int.Parse(textBoxSoID.Text.Trim())))
                {
                    MessageBox.Show("入力された営業IDは存在しません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxSoID.Focus();
                    return false;
                }
            }

            //営業所名の適否
            if (!String.IsNullOrEmpty(textBoxSoName.Text.Trim()))
            {

                // 営業所名の文字数チェック
                if (textBoxSoName.TextLength > 50)
                {
                    MessageBox.Show("営業所名は50文字以下です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxSoName.Focus();
                    return false;
                }
            }
            //電話番号の適否
            if (!String.IsNullOrEmpty(textBoxSoPhone.Text.Trim()))
            {
                //電話番号の半角数値ハイフンチェック
                if (!dataInputFormCheck.CheckNumericHyphen(textBoxSoPhone.Text.Trim()))
                {
                    MessageBox.Show("電話番号の入力形式が正しくありません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxSoPhone.Focus();
                    return false;
                }
                // 電話番号の文字数チェック
                if (textBoxSoPhone.TextLength > 13)
                {
                    MessageBox.Show("電話番号は13文字以下です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxSoPhone.Focus();
                    return false;
                }
            }

            //FAXの適否
            if (!String.IsNullOrEmpty(textBoxSoFAX.Text.Trim()))
            {
                //FAXの半角英数字チェック
                if (!dataInputFormCheck.CheckNumericHyphen(textBoxSoFAX.Text.Trim()))
                {
                    MessageBox.Show("FAXの入力形式が正しくありません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxSoFAX.Focus();
                    return false;
                }
                // FAXの文字数チェック
                if (textBoxSoFAX.TextLength > 13)
                {
                    MessageBox.Show("FAXは13文字以下です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxSoFAX.Focus();
                    return false;
                }
            }

            //郵便番号の適否
            if (!String.IsNullOrEmpty(textBoxSoPostal.Text.Trim()))
            {
                //郵便番号の半角数値チェック
                if (!dataInputFormCheck.CheckHalfAlphabetNumeric(textBoxSoPostal.Text.Trim()))
                {
                    MessageBox.Show("郵便番号は半角数値入力です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxSoPostal.Focus();
                    return false;
                }
                // 郵便番号の文字数チェック
                if (textBoxSoPostal.TextLength > 7)
                {
                    MessageBox.Show("郵便番号の最大文字数を超えています", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxSoPostal.Focus();
                    return false;
                }
            }

            //住所の適否
            if (!String.IsNullOrEmpty(textBoxSoAddress.Text.Trim()))
            {
                // 住所の文字数チェック
                if (textBoxSoAddress.TextLength > 50)
                {
                    MessageBox.Show("住所は50文字以下です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    textBoxSoAddress.Focus();
                    return false;
                }
            }

            //フラグの適否
            if (checkBoxSoFlag.CheckState == CheckState.Indeterminate)
            {
                MessageBox.Show("非表示フラグが不確定な状態です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                checkBoxSoFlag.Focus();
                return false;
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
            int soFlg = 0;
            if (checkBoxSoFlag.Checked == true)
            {
                soFlg = 2;
            }
            // 検索条件のセット
            if (!String.IsNullOrEmpty(textBoxSoID.Text.Trim()))
            {

                M_SalesOfficeDsp salesOffice = new M_SalesOfficeDsp()
                {
                    SoID = int.Parse(textBoxSoID.Text.Trim()),
                    SoName = textBoxSoName.Text.Trim(),
                    SoPhone = textBoxSoPhone.Text.Trim(),
                    SoFAX = textBoxSoFAX.Text.Trim(),
                    SoPostal = textBoxSoPostal.Text.Trim(),
                    SoAddress = textBoxSoAddress.Text.Trim(),
                    SoFlag = soFlg,
                    SoHidden=textBoxSoHidden.Text.Trim(),
                };
                //営業データの抽出
                 SalesOffice = salesOfficeDataAccess.GetSalesOfficeData(1,salesOffice);
            }
            else
            {
                M_SalesOfficeDsp salesOffice = new M_SalesOfficeDsp()
                {
                    SoName = textBoxSoName.Text.Trim(),
                    SoPhone = textBoxSoPhone.Text.Trim(),
                    SoFAX = textBoxSoFAX.Text.Trim(),
                    SoPostal = textBoxSoPostal.Text.Trim(),
                    SoAddress = textBoxSoAddress.Text.Trim(),
                    SoFlag = soFlg,
                    SoHidden = textBoxSoHidden.Text.Trim(),

                };
                //営業データの抽出
                 SalesOffice = salesOfficeDataAccess.GetSalesOfficeData(2,salesOffice);
            }
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
            if (SalesOffice.Count == 0)
            {
                MessageBox.Show("該当データが存在しません", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            labelPage.Text = "/" + ((int)Math.Ceiling(SalesOffice.Count / (double)pageSize)) + "ページ";
            dataGridViewSalesOffice.Refresh();
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
            checkBoxSoFlag.Checked = false;
            textBoxSoHidden.Text = "";
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
        //メソッド名：GetHiddenDataGridView()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：データグリッドビューに表示する非表示データの取得
        ///////////////////////////////
        private void GetHiddenDataGridView()
        {
            //営業データの取得
            SalesOffice = salesOfficeDataAccess.GetSalesOfficeHiddenData();

            // DataGridViewに表示するデータを指定
            SetDataGridView();
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
            dataGridViewSalesOffice.ReadOnly = true;
            //行内をクリックすることで行を選択
            dataGridViewSalesOffice.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //直接のサイズの変更を不可
            dataGridViewSalesOffice.AllowUserToResizeRows = false;
            dataGridViewSalesOffice.AllowUserToResizeColumns = false;
            //直接の登録を不可にする
            dataGridViewSalesOffice.AllowUserToAddRows = false;
            //奇数行の色を変更
            dataGridViewSalesOffice.AlternatingRowsDefaultCellStyle.BackColor = Color.Honeydew;
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
            if (!PageSizeCheck())
                return;

            int pageSize = int.Parse(textBoxPageSize.Text);
            int pageNo = int.Parse(textBoxPage.Text) - 1;
            dataGridViewSalesOffice.DataSource = SalesOffice.Skip(pageSize * pageNo).Take(pageSize).ToList();
            //各列幅の指定1400
            dataGridViewSalesOffice.Columns[0].Width = 100;
            dataGridViewSalesOffice.Columns[1].Width = 250;
            dataGridViewSalesOffice.Columns[2].Width = 175;
            dataGridViewSalesOffice.Columns[3].Width = 175;
            dataGridViewSalesOffice.Columns[4].Width = 130;
            dataGridViewSalesOffice.Columns[5].Width = 300;
            dataGridViewSalesOffice.Columns[6].Visible = false;
            dataGridViewSalesOffice.Columns[7].Width = 247;
            //各列の文字位置の指定
            dataGridViewSalesOffice.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewSalesOffice.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewSalesOffice.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewSalesOffice.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewSalesOffice.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewSalesOffice.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewSalesOffice.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

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
        //引　数   ：なし——
        //戻り値   ：なし
        //機　能   ：データグリッドビューの先頭ページ表示
        ///////////////////////////////
        private void buttonFirstPage_Click(object sender, EventArgs e)
        {
            if (!PageSizeCheck())
                return;

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
            if (!PageSizeCheck())
                return;
            int pageSize = int.Parse(textBoxPageSize.Text.Trim());
            if (!PageCheck())
                return;

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
            if (!PageSizeCheck())
                return;
            int pageSize = int.Parse(textBoxPageSize.Text.Trim());
            if (!PageCheck())
                return;
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
            if (!PageSizeCheck())
                return;

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
        //メソッド名：buttonList_Click()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：営業データの一覧表示機能
        ///////////////////////////////
        private void buttonList_Click(object sender, EventArgs e)
        {
            // 入力エリアのクリア
            ClearInput();

            GetDataGridView();
        }

        ///////////////////////////////
        //メソッド名：buttonNotList_Click()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：営業データの非表示一覧表示機能
        ///////////////////////////////
        private void buttonNotList_Click(object sender, EventArgs e)
        {
            // 入力エリアのクリア
            ClearInput();

            GetHiddenDataGridView();
        }


       
        //入力クリア
        private void buttonClear_Click(object sender, EventArgs e)
        {
            ClearInput();
        }

        private void checkBoxSoFlag_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSoFlag.Checked == true)
            {
                textBoxSoHidden.TabStop = true;
                textBoxSoHidden.ReadOnly = false;
            }
            else
            {
                textBoxSoHidden.Text = "";
                textBoxSoHidden.TabStop = false;
                textBoxSoHidden.ReadOnly = true;
            }
        }
        //データグリッドビュー セルクリック
        private void dataGridViewSalesOffice_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //データグリッドビューからクリックされたデータを各入力エリアへ
            textBoxSoID.Text = dataGridViewSalesOffice.Rows[dataGridViewSalesOffice.CurrentRow.Index].Cells[0].Value.ToString();
            textBoxSoName.Text = dataGridViewSalesOffice.Rows[dataGridViewSalesOffice.CurrentRow.Index].Cells[1].Value.ToString();
            textBoxSoPhone.Text = dataGridViewSalesOffice.Rows[dataGridViewSalesOffice.CurrentRow.Index].Cells[2].Value.ToString();
            textBoxSoFAX.Text = dataGridViewSalesOffice.Rows[dataGridViewSalesOffice.CurrentRow.Index].Cells[3].Value.ToString();
            textBoxSoPostal.Text = dataGridViewSalesOffice.Rows[dataGridViewSalesOffice.CurrentRow.Index].Cells[4].Value.ToString();
            textBoxSoAddress.Text = dataGridViewSalesOffice.Rows[dataGridViewSalesOffice.CurrentRow.Index].Cells[5].Value.ToString();

            //flagの値の「0」「2」をbool型に変換してチェックボックスに表示させる
            if (dataGridViewSalesOffice.Rows[dataGridViewSalesOffice.CurrentRow.Index].Cells[6].Value.ToString() != 2.ToString())
            {
                checkBoxSoFlag.Checked = false;
            }
            else
            {
                checkBoxSoFlag.Checked = true;
            }
            //非表示理由がnullではない場合テキストボックスに表示させる
            if (dataGridViewSalesOffice.Rows[dataGridViewSalesOffice.CurrentRow.Index].Cells[7].Value != null)
            {
                textBoxSoHidden.Text = dataGridViewSalesOffice.Rows[dataGridViewSalesOffice.CurrentRow.Index].Cells[7].Value.ToString();
            }

        }
    }
}


