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
    public partial class UserControlSmallClassification : UserControl
    {
        //メッセージ表示用クラスのインスタンス化
        MessageDsp messageDsp = new MessageDsp();
        //入力形式チェック用クラスのインスタンス化
        DataInputFormCheck dataInputFormCheck = new DataInputFormCheck();
        //データベース小分類テーブルアクセス用クラスのインスタンス化
        SmallClassification smallClassification = new SmallClassification();
        //データベース大分類テーブルアクセス用クラスのインスタンス化
        MajorClassificationDataAccess majorClassification = new MajorClassificationDataAccess();
        //コンボボックス用の大分類データ
        private static List<M_MajorCassification> MajorCassifications;
        //データグリッドビュー用の顧客データ
        private static List<M_SmallClassificationDsp> SmallClass;


        public UserControlSmallClassification()
        {
            InitializeComponent();
        }

        private void UserControlSmallClassification_Load(object sender, EventArgs e)
        {
            //コンボボックスの設定
            SetFormComboBox();

            //データグリッドビューの設定
            SetFormDataGridView();

        }

        private void SetFormComboBox()
        {
            //大分類データの取得
            MajorCassifications = majorClassification.GetMcData();
            comboBoxMcID.DataSource = MajorCassifications;
            comboBoxMcID.DisplayMember = "McName";
            comboBoxMcID.ValueMember = "McID";
            //コンボボックスを読み取り専用
            comboBoxMcID.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxMcID.SelectedIndex = -1;
        }

        private void buttonResist_Click(object sender, EventArgs e)
        {
            // 妥当な小分類データを取得
            if (!GetValidDataAtRegistration())
                return;

            // 小分類情報作成
            var regSc = GenerateDataAtRegistration();

            // 小分類情報登録
            RegistrationSc(regSc);

        }
        ///////////////////////////////
        //　4.4.1.1 妥当な顧客データ取得
        //メソッド名：GetValidDataAtRegistration()
        //引　数   ：なし
        //戻り値   ：true or false
        //機　能   ：入力データの形式チェック
        //          ：エラーがない場合True
        //          ：エラーがある場合False
        ///////////////////////////////
        private bool GetValidDataAtRegistration()
        {
            //大分類が未選択
            if (comboBoxMcID.SelectedIndex == -1)
            {
                MessageBox.Show("大分類が選択されていません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBoxMcID.Focus();
                return false;
            }

            //小分類IDの適否
            if (!String.IsNullOrEmpty(textBoxScID.Text.Trim()))
            {
                //顧客IDは入力不要です
                MessageBox.Show("小分類IDは入力不要です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxScID.Focus();
                return false;
            }

            //小分類名の適否
            if (!String.IsNullOrEmpty(textBoxScName.Text.Trim()))
            {
                if (textBoxScName.TextLength > 50)
                {
                    //小分類名は50文字以下です
                    MessageBox.Show("小分類名は50文字以下です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxScName.Focus();
                    return false;
                }
            }
            else
            {
                //小分類名が入力されていません
                MessageBox.Show("小分類名が入力されていません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxScName.Focus();
                return false;
            }

            //フラグの適否
            if (checkBoxScFlag.CheckState == CheckState.Indeterminate)
            {
                MessageBox.Show("非表示フラグが不確定の状態です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                checkBoxScFlag.Focus();
                return false;
            }
            if (checkBoxScFlag.Checked == true)
            {
                MessageBox.Show("非表示フラグがチェックされています", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                checkBoxScFlag.Focus();
                return false;
            }

            //非表示理由の適否
            if (!String.IsNullOrEmpty(textBoxScHidden.Text.Trim()))
            {
                MessageBox.Show("非表示理由は登録できません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxScHidden.Focus();
                return false;
            }

            return true;
        }

        ///////////////////////////////
        //　4.4.1.2 小分類情報作成
        //メソッド名：GenerateDataAtRegistration()
        //引　数   ：なし
        //戻り値   ：小分類登録情報
        //機　能   ：登録データのセット
        ///////////////////////////////
        private M_SmallClassification GenerateDataAtRegistration()
        {
            int ScFlag = 0;
            if (checkBoxScFlag.Checked == true)
            {
                ScFlag = 2;
            }

            return new M_SmallClassification
            {
                McID = int.Parse(comboBoxMcID.SelectedValue.ToString()),
                ScName = textBoxScName.Text.Trim(),
                ScFlag = ScFlag,
                ScHidden = textBoxScHidden.Text.Trim()
            };
        }

        ///////////////////////////////
        //　4.4.1.3 小分類情報登録
        //メソッド名：RegistrationSc
        //引　数   ：小分類情報
        //戻り値   ：なし
        //機　能   ：小分類情報の登録
        ///////////////////////////////
        private void RegistrationSc(M_SmallClassification regSc)
        {
            //登録確認メッセージ
            DialogResult result = MessageBox.Show("小分類データを登録してよろしいですか?", "追加確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (result == DialogResult.Cancel)
                return;
            //顧客情報の登録
            bool flg = smallClassification.AddSmallClassData(regSc);
            if (flg == true)
                MessageBox.Show("データを登録しました", "追加確認", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("データの登録に失敗しました", "追加確認", MessageBoxButtons.OK, MessageBoxIcon.Information);

            textBoxScID.Focus();

            //入力エリアのクリア
            ClearInput();
            //データグリッドビューの表示
            GetDataGridView();
        }

        ///////////////////////////////
        //メソッド名：ClearInput()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：入力エリアをクリア
        ///////////////////////////////
        private void ClearInput()
        {
            comboBoxMcID.SelectedIndex = -1;
            textBoxScID.Text = "";
            textBoxScName.Text = "";
            checkBoxScFlag.Checked = false;
            textBoxScHidden.Text = "";
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
            dataGridViewSc.ReadOnly = true;
            //直接のサイズの変更を不可
            dataGridViewSc.AllowUserToResizeRows = false;
            dataGridViewSc.AllowUserToResizeColumns = false;
            //直接の登録を不可にする
            dataGridViewSc.AllowUserToAddRows = false;
            //行内をクリックすることで行を選択
            dataGridViewSc.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //奇数行の色を変更
            dataGridViewSc.AlternatingRowsDefaultCellStyle.BackColor = Color.Honeydew;
            //ヘッダー位置の指定
            dataGridViewSc.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

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
            // 小分類データの取得
            SmallClass = smallClassification.GetScData();

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
            dataGridViewSc.DataSource = SmallClass.Skip(pageSize * pageNo).Take(pageSize).ToList();


            //各列幅の指定 //1300
            dataGridViewSc.Columns[0].Width = 100;
            dataGridViewSc.Columns[1].Width = 250;
            dataGridViewSc.Columns[2].Width = 100;
            dataGridViewSc.Columns[3].Width = 250;
            dataGridViewSc.Columns[4].Visible = false;
            dataGridViewSc.Columns[5].Width = 635;




            //各列の文字位置の指定
            dataGridViewSc.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewSc.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewSc.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewSc.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewSc.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewSc.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;


            //dataGridViewの総ページ数
            labelPage.Text = "/" + ((int)Math.Ceiling(SmallClass.Count / (double)pageSize)) + "ページ";




            dataGridViewSc.Refresh();

        }

        ///////////////小分類情報更新//////////////////
        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            // 4.4.2.1 小分類情報更新
            if (!GetValidDataUpdate())
                return;

            // 4.4.2.2 小分類情報作成
            var updSc = GenerateDataUpdate();
            // 4.4.2.3顧客情報更新
            UpdateSc(updSc);
        }

        ///////////////////////////////
        //  4.4.2.1 妥当な顧客データ取得
        //メソッド名：GetValidDataAtUpdate()
        //引　数   ：なし
        //戻り値   ：true or false
        //機　能   ：入力データの形式チェック
        //          ：エラーがない場合True
        //          ：エラーがある場合False
        ///////////////////////////////
        private bool GetValidDataUpdate()
        {
            //大分類が未選択
            if (comboBoxMcID.SelectedIndex == -1)
            {
                MessageBox.Show("大分類が選択されていません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBoxMcID.Focus();
                return false;
            }

            //小分類IDの適否
            if (!String.IsNullOrEmpty(textBoxScID.Text.Trim()))
            {
                //小分類IDの半角数値チェック
                if (!dataInputFormCheck.CheckNumeric(textBoxScID.Text.Trim()))
                {
                    MessageBox.Show("小分類IDは半角数値入力です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxScID.Focus();
                    return false;
                }
                //文字数
                if (textBoxScID.TextLength > 2)
                {
                    MessageBox.Show("小分類IDは2文字以下です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxScID.Focus();
                    return false;
                }

                // 小分類IDの存在チェック
                if (!smallClassification.CheckScIDExistence(int.Parse(textBoxScID.Text.Trim())))
                {
                    MessageBox.Show("入力された小分類IDは存在しません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxScID.Focus();
                    return false;
                }
            }
            else
            {
                //小分類IDが入力されていません
                MessageBox.Show("小分類IDが入力されていません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxScID.Focus();
                return false;
            }

            //小分類名の適否
            if (!String.IsNullOrEmpty(textBoxScName.Text.Trim()))
            {
                if (textBoxScName.TextLength > 50)
                {
                    //小分類名は50文字以下です
                    MessageBox.Show("小分類名は50文字以下です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxScName.Focus();
                    return false;
                }
            }
            else
            {
                //小分類名が入力されていません
                MessageBox.Show("小分類名が入力されていません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxScName.Focus();
                return false;
            }

            //フラグの適否
            if (checkBoxScFlag.CheckState == CheckState.Indeterminate)
            {
                MessageBox.Show("非表示フラグが不確定の状態です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                checkBoxScFlag.Focus();
                return false;
            }

            //非表示理由の適否
            if (checkBoxScFlag.Checked == true && string.IsNullOrEmpty(textBoxScHidden.Text.Trim()))
            {
                MessageBox.Show("非表示理由が入力されていません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxScHidden.Focus();
                return false;
            }

            return true;
        }

        ///////////////////////////////
        //　4.4.2.2 小分類情報作成
        //メソッド名：GenerateDataAtUpdate()
        //引　数   ：なし
        //戻り値   ：小分類更新情報
        //機　能   ：更新データのセット
        ///////////////////////////////
        private M_SmallClassification GenerateDataUpdate()
        {
            int ScFlag = 0;
            if (checkBoxScFlag.Checked == true)
                ScFlag = 2;

            return new M_SmallClassification
            {
                ScID = int.Parse(textBoxScID.Text.Trim()),
                McID = int.Parse(comboBoxMcID.SelectedValue.ToString()),
                ScName = textBoxScName.Text.Trim(),
                ScFlag = ScFlag,
                ScHidden = textBoxScHidden.Text.Trim()
            };
        }

        ///////////////////////////////
        //　4.4.2.3 小分類情報更新
        //メソッド名：UpdateClient()
        //引　数   ：小分類情報
        //戻り値   ：なし
        //機　能   ：顧客情報の更新
        ///////////////////////////////
        private void UpdateSc(M_SmallClassification updSc)
        {
            // 更新確認メッセージ
            DialogResult result = MessageBox.Show("データを更新してよろしいですか?", "更新確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (result == DialogResult.Cancel)
                return;

            // スタッフ情報の更新
            bool flg = smallClassification.UpdateSmallClassData(updSc);
            if (flg == true)
                MessageBox.Show("データを更新しました", "更新確認", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("データの更新に失敗しました", "更新確認", MessageBoxButtons.OK, MessageBoxIcon.Error);

            textBoxScID.Focus();

            // 入力エリアのクリア
            ClearInput();

            // データグリッドビューの表示
            GetDataGridView();
        }

        private void dataGridViewSc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxScID.Text = dataGridViewSc.Rows[dataGridViewSc.CurrentRow.Index].Cells[2].Value.ToString();
            comboBoxMcID.Text = dataGridViewSc.Rows[dataGridViewSc.CurrentRow.Index].Cells[1].Value.ToString();
            textBoxScName.Text = dataGridViewSc.Rows[dataGridViewSc.CurrentRow.Index].Cells[3].Value.ToString();

            //flagの値の「0」「2」をbool型に変換してチェックボックスに表示させる
            if (dataGridViewSc.Rows[dataGridViewSc.CurrentRow.Index].Cells[4].Value.ToString() != 2.ToString())
            {
                checkBoxScFlag.Checked = false;
            }
            else
            {
                checkBoxScFlag.Checked = true;
            }

            //非表示理由がnullではない場合テキストボックスに表示させる
            if (dataGridViewSc.Rows[dataGridViewSc.CurrentRow.Index].Cells[5].Value != null)
            {
                textBoxScHidden.Text = dataGridViewSc.Rows[dataGridViewSc.CurrentRow.Index].Cells[5].Value.ToString();
            }
        }

        ///////////小分類情報検索/////////////
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            //妥当な顧客データを取得
            if (!GetValidAtSelect())
                return;

            //小分類情報抽出
            GenerateDataAtSelect();

            //顧客抽出結果表示
            SetSelectData();
        }

        ///////////////////////////////
        //　4.4.4.1 妥当な小分類データ取得
        //メソッド名：GetValidDataAtSlect()
        //引　数   ：なし
        //戻り値   ：true or false
        //機　能   ：入力データの形式チェック
        //          ：エラーがない場合True
        //          ：エラーがある場合False
        ///////////////////////////////
        private bool GetValidAtSelect()
        {
            //小分類IDの適否
            if (!String.IsNullOrEmpty(textBoxScID.Text.Trim()))
            {
                //小分類IDの半角数値チェック
                if (!dataInputFormCheck.CheckNumeric(textBoxScID.Text.Trim()))
                {
                    MessageBox.Show("小分類IDは半角数値入力です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxScID.Focus();
                    return false;
                }
                //文字数
                if (textBoxScID.TextLength > 2)
                {
                    MessageBox.Show("小分類IDは2文字以下です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxScID.Focus();
                    return false;
                }

                // 小分類IDの存在チェック
                if (!smallClassification.CheckScIDExistence(int.Parse(textBoxScID.Text.Trim())))
                {
                    MessageBox.Show("入力された小分類IDは存在しません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxScID.Focus();
                    return false;
                }
            }

            //小分類名の適否
            if (!String.IsNullOrEmpty(textBoxScName.Text.Trim()))
            {
                if (textBoxScName.TextLength > 50)
                {
                    //小分類名は50文字以下です
                    MessageBox.Show("小分類名は50文字以下です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxScName.Focus();
                    return false;
                }
            }

            //フラグの適否
            if (checkBoxScFlag.CheckState == CheckState.Indeterminate)
            {
                MessageBox.Show("非表示フラグが不確定の状態です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                checkBoxScFlag.Focus();
                return false;
            }

            return true;
        }

        ///////////////////////////////
        //　4.4.4.2 小分類情報抽出
        //メソッド名：GenerateDataAtSelect()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：検索データの取得
        ///////////////////////////////
        private void GenerateDataAtSelect()
        {
            //フラグ情報
            int scFlg = 0;
            if (checkBoxScFlag.Checked == true)
            {
                scFlg = 2;
            }
            //コンボボックスが未選択の場合Emptyを設定
            string cMajorClass = "";
            if (comboBoxMcID.SelectedIndex != -1)
                cMajorClass = comboBoxMcID.SelectedValue.ToString();

            //検索条件のセット
            //小分類IDが入力されていて、営業所も選択されている場合
            if (!String.IsNullOrEmpty(textBoxScID.Text.Trim()) && cMajorClass != "")
            {
                M_SmallClassificationDsp selectCondition = new M_SmallClassificationDsp()
                {
                    ScID = int.Parse(textBoxScID.Text.Trim()),
                    McID = int.Parse(cMajorClass),
                    ScName = textBoxScName.Text.Trim(),
                    ScFlag = scFlg,
                    ScHidden = textBoxScHidden.Text.Trim()
                };

                //小分類データの抽出
                SmallClass = smallClassification.GetScData(1, selectCondition);
            }
            //小分類IDが入力されていて、大分類が未選択の場合
            else if (!String.IsNullOrEmpty(textBoxScID.Text.Trim()) && cMajorClass == "")
            {
                M_SmallClassificationDsp selectCondition = new M_SmallClassificationDsp()
                {
                    ScID = int.Parse(textBoxScID.Text.Trim()),
                    ScName = textBoxScName.Text.Trim(),
                    ScFlag = scFlg,
                    ScHidden = textBoxScHidden.Text.Trim()
                };

                //小分類データの抽出
                SmallClass = smallClassification.GetScData(2, selectCondition);
            }
            //小分類IDが未入力で、大分類が選択されている場合
            else if (cMajorClass != "")
            {
                M_SmallClassificationDsp selectCondition = new M_SmallClassificationDsp()
                {
                    McID = int.Parse(cMajorClass),
                    ScName = textBoxScName.Text.Trim(),
                    ScFlag = scFlg,
                    ScHidden = textBoxScHidden.Text.Trim()
                };

                //小分類データの抽出
                SmallClass = smallClassification.GetScData(3, selectCondition);
            }
            //顧客IDが未入力で、大分類も未選択の場合
            else
            {
                M_SmallClassificationDsp selectCondition = new M_SmallClassificationDsp()
                {
                    ScName = textBoxScName.Text.Trim(),
                    ScFlag = scFlg,
                    ScHidden = textBoxScHidden.Text.Trim()
                };

                //小分類データの抽出
                SmallClass = smallClassification.GetScData(4, selectCondition);
            }
        }

        ///////////////////////////////
        //　3.4.1.3 顧客抽出結果表示
        //メソッド名：SetSelectData()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：顧客情報の表示
        ///////////////////////////////
        private void SetSelectData()
        {
            textBoxPage.Text = "1";

            int pageSize = int.Parse(textBoxPageSize.Text);

            dataGridViewSc.DataSource = SmallClass;
            if (SmallClass.Count == 0)
            {
                MessageBox.Show("該当データが存在しません", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            labelPage.Text = "/" + ((int)Math.Ceiling(SmallClass.Count / (double)pageSize)) + "ページ";
            dataGridViewSc.Refresh();

        }



























        private void buttonClear_Click(object sender, EventArgs e)
        {
            ClearInput();
        }

        private void buttonList_Click(object sender, EventArgs e)
        {
            //入力エリアのクリア
            ClearInput();
            //データグリッドビューの表示
            GetDataGridView();
        }

        private void buttonNotList_Click(object sender, EventArgs e)
        {
            //入力エリアのクリア
            ClearInput();
            //データグリッドビューの表示
            GetHiddenDataGridView();
        }
        ///////////////////////////////
        //メソッド名：GetHiddenDataGridView()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：データグリッドビューに表示する非表示データの取得
        ///////////////////////////////
        private void GetHiddenDataGridView()
        {
            // 小分類データの取得
            SmallClass = smallClassification.GetSmallClassHiddenData();

            // DataGridViewに表示するデータを指定
            SetDataGridView();
        }

        private void checkBoxScFlag_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxScFlag.Checked == true)
            {
                textBoxScHidden.TabStop = true;
                textBoxScHidden.ReadOnly = false;
                textBoxScHidden.Enabled = true;
            }
            else
            {
                textBoxScHidden.Text = "";
                textBoxScHidden.TabStop = false;
                textBoxScHidden.ReadOnly = true;
                textBoxScHidden.Enabled = false;
            }
        }

        private void buttonPageSizeChange_Click(object sender, EventArgs e)
        {
            textBoxPage.Text = 1.ToString();
            SetDataGridView();
        }

        private void buttonFirstPage_Click(object sender, EventArgs e)
        {
            if (!PageSizeCheck())
                return;

            int pageSize = int.Parse(textBoxPageSize.Text);
            dataGridViewSc.DataSource = SmallClass.Take(pageSize).ToList();

            // DataGridViewを更新
            dataGridViewSc.Refresh();
            //ページ番号の設定
            textBoxPage.Text = "1";
        }

        private void buttonPreviousPage_Click(object sender, EventArgs e)
        {
            if (!PageSizeCheck())
                return;
            int pageSize = int.Parse(textBoxPageSize.Text.Trim());
            if (!PageCheck())
                return;
            int pageNo = int.Parse(textBoxPage.Text) - 2;
            dataGridViewSc.DataSource = SmallClass.Skip(pageSize * pageNo).Take(pageSize).ToList();

            // DataGridViewを更新
            dataGridViewSc.Refresh();
            //ページ番号の設定
            if (pageNo + 1 > 1)
                textBoxPage.Text = (pageNo + 1).ToString();
            else
                textBoxPage.Text = "1";
        }

        private void buttonNextPage_Click(object sender, EventArgs e)
        {
            if (!PageSizeCheck())
                return;
            int pageSize = int.Parse(textBoxPageSize.Text.Trim());
            if (!PageCheck())
                return;
            int pageNo = int.Parse(textBoxPage.Text);
            //最終ページの計算
            int lastNo = (int)Math.Ceiling(SmallClass.Count / (double)pageSize) - 1;
            //最終ページでなければ
            if (pageNo <= lastNo)
                dataGridViewSc.DataSource = SmallClass.Skip(pageSize * pageNo).Take(pageSize).ToList();

            // DataGridViewを更新
            dataGridViewSc.Refresh();
            //ページ番号の設定
            int lastPage = (int)Math.Ceiling(SmallClass.Count / (double)pageSize);
            if (pageNo >= lastPage)
                textBoxPage.Text = lastPage.ToString();
            else
                textBoxPage.Text = (pageNo + 1).ToString();
        }

        private void buttonLastPage_Click(object sender, EventArgs e)
        {
            if (!PageSizeCheck())
                return;

            int pageSize = int.Parse(textBoxPageSize.Text);
            //最終ページの計算
            int pageNo = (int)Math.Ceiling(SmallClass.Count / (double)pageSize) - 1;
            dataGridViewSc.DataSource = SmallClass.Skip(pageSize * pageNo).Take(pageSize).ToList();

            // DataGridViewを更新
            dataGridViewSc.Refresh();
            //ページ番号の設定
            textBoxPage.Text = (pageNo + 1).ToString();
        }
    }
}
