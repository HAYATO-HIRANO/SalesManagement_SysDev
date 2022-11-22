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
    public partial class UserControlMajorClassification : UserControl
    {
        //データベース大分類テーブルアクセス用クラスのインスタンス化
        MajorClassificationDataAccess majorClassificationDataAccess = new MajorClassificationDataAccess();
        //入力形式チェック用クラスのインスタンス化
        DataInputFormCheck dataInputFormCheck = new DataInputFormCheck();
        //データグリッドビュー用の大分類データ
        private static List<M_MajorCassification> MajorCassification;

        public UserControlMajorClassification()
        {
            InitializeComponent();
        }

        private void UserControlMajorClassification_Load(object sender, EventArgs e)
        {
            //非表示理由タブ選択不可、入力不可
            textBoxMcHidden.TabStop = false;
            textBoxMcHidden.ReadOnly = true;

            //データグリッドビューの設定
            SetFormDataGridView();
        }
        
        ///////////////大分類情報登録////////////////////

        private void buttonResist_Click(object sender, EventArgs e)
        {
            //  妥当な妥当なデータ取得
            if (!GetValidDataAtRegistration())
                return;

            //  大分類情報作成
            var regMc = GenerateDataAtRegistration();

            // 大分類情報登録
            RegistrationMc(regMc);

        }
        ///////////////////////////////
        //　4.3.1.1 妥当な大分類データ取得
        //メソッド名：GetValidDataAtRegistration()
        //引　数   ：なし
        //戻り値   ：true or false
        //機　能   ：入力データの形式チェック
        //          ：エラーがない場合True
        //          ：エラーがある場合False
        ///////////////////////////////
        private bool GetValidDataAtRegistration()
        {
            //大分類IDの適否
            if (!String.IsNullOrEmpty(textBoxMcID.Text.Trim()))
            {
                //大分類IDは入力不要です
                MessageBox.Show("大分類IDは入力不要です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxMcID.Focus();
                return false;

            }
            //大分類名の適否
            if (!String.IsNullOrEmpty(textBoxMcName.Text.Trim()))
            {
                if (textBoxMcName.TextLength > 50)
                {
                    
                    MessageBox.Show("大分類名は50文字以下です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    textBoxMcName.Focus();
                    return false;
                }
            }
            else
            {
                
                MessageBox.Show("大分類名が入力されていません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxMcName.Focus();
                return false;

            }
            //フラグの適否
            if (checkBoxMcFlag.CheckState == CheckState.Indeterminate)
            {
                MessageBox.Show("非表示フラグが不確定の状態です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);

                checkBoxMcFlag.Focus();
                return false;
            }
            if (checkBoxMcFlag.Checked == true)
            {
                MessageBox.Show("非表示フラグがチェックされています", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                checkBoxMcFlag.Focus();
                return false;
            }
            //非表示理由の適否
            if (!String.IsNullOrEmpty(textBoxMcHidden.Text.Trim()))
            {
                MessageBox.Show("非表示理由は登録できません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxMcHidden.Focus();
                return false;
            }

            return true;
        }
        ///////////////////////////////
        //　4.3.1.2　大分類情報作成
        //メソッド名：GenerateDataAtRegistration()
        //引　数   ：なし
        //戻り値   ：大分類登録情報
        //機　能   ：登録データのセット
        ///////////////////////////////
        private M_MajorCassification GenerateDataAtRegistration()
        {
            int McFlag = 0;
            if(checkBoxMcFlag.Checked == true)
            {
                McFlag = 2;
            }
            return new M_MajorCassification
            {
                McName = textBoxMcName.Text.Trim(),
                McFlag=McFlag,
                McHidden=textBoxMcHidden.Text.Trim(),
            };
        }
        ///////////////////////////////
        //　4.3.1.3 大分類情報登録
        //メソッド名：RegistrationStaff()
        //引　数   ：大分類情報
        //戻り値   ：なし
        //機　能   ：大分類情報の登録
        ///////////////////////////////
        private void RegistrationMc(M_MajorCassification regMc)
        {            
            // 登録確認メッセージ
            DialogResult result = MessageBox.Show("大分類データを登録してよろしいですか?", "追加確認", MessageBoxButtons.OK, MessageBoxIcon.Question);
            if (result == DialogResult.Cancel)
                return;
            // 大分類情報の登録
            bool flg = majorClassificationDataAccess.AddMcData(regMc);
            if (flg == true)
                MessageBox.Show("データを登録しました。", "追加確認", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                
            else
                MessageBox.Show("データの登録に失敗しました。", "追加確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                

            textBoxMcID.Focus();

            //入力エリアのクリア
            ClearInput();
            //データグリッドビューの表示
            GetDataGridView();


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
            dataGridViewMc.ReadOnly = true;
            //直接のサイズの変更を不可
            dataGridViewMc.AllowUserToResizeRows = false;
            dataGridViewMc.AllowUserToResizeColumns = false;
            //直接の登録を不可にする
            dataGridViewMc.AllowUserToAddRows = false;
            //行内をクリックすることで行を選択
            dataGridViewMc.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //奇数行の色を変更
            dataGridViewMc.AlternatingRowsDefaultCellStyle.BackColor = Color.Honeydew;
            //ヘッダー位置の指定
            dataGridViewMc.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

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
            // 大分類データの取得
            MajorCassification = majorClassificationDataAccess.GetMcData();

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
            //大分類データの取得
            MajorCassification = majorClassificationDataAccess.GetMcHiddenData();

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
            int pageSize = int.Parse(textBoxPageSize.Text);
            int pageNo = int.Parse(textBoxPage.Text) - 1;
            dataGridViewMc.DataSource = MajorCassification.Skip(pageSize * pageNo).Take(pageSize).ToList();
            //各列幅の指定 
            dataGridViewMc.Columns[0].Width = 100;
            dataGridViewMc.Columns[1].Width = 100;
            dataGridViewMc.Columns[2].Width = 180;
            dataGridViewMc.Columns[3].Width = 180;
            //各列の文字位置の指定
            dataGridViewMc.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewMc.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewMc.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewMc.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            //dataGridViewの総ページ数
            labelPage.Text = "/" + ((int)Math.Ceiling(MajorCassification.Count / (double)pageSize)) + "ページ";

            dataGridViewMc.Refresh();

        }

        private void buttonPageSizeChange_Click(object sender, EventArgs e)
        {
            SetDataGridView();

        }

        private void buttonFirstPage_Click(object sender, EventArgs e)
        {
            int pageSize = int.Parse(textBoxPageSize.Text);
            dataGridViewMc.DataSource = MajorCassification.Take(pageSize).ToList();

            // DataGridViewを更新
            dataGridViewMc.Refresh();
            //ページ番号の設定
            textBoxPage.Text = "1";

        }

        private void buttonPreviousPage_Click(object sender, EventArgs e)
        {
            int pageSize = int.Parse(textBoxPageSize.Text);
            int pageNo = int.Parse(textBoxPage.Text) - 2;
            dataGridViewMc.DataSource = MajorCassification.Skip(pageSize * pageNo).Take(pageSize).ToList();

            // DataGridViewを更新
            dataGridViewMc.Refresh();
            //ページ番号の設定
            if (pageNo + 1 > 1)
                textBoxPage.Text = (pageNo + 1).ToString();
            else
                textBoxPage.Text = "1";

        }

        private void buttonNextPage_Click(object sender, EventArgs e)
        {
            int pageSize = int.Parse(textBoxPageSize.Text);
            int pageNo = int.Parse(textBoxPage.Text);
            //最終ページの計算
            int lastNo = (int)Math.Ceiling(MajorCassification.Count / (double)pageSize) - 1;
            //最終ページでなければ
            if (pageNo <= lastNo)
                dataGridViewMc.DataSource = MajorCassification.Skip(pageSize * pageNo).Take(pageSize).ToList();

            // DataGridViewを更新
            dataGridViewMc.Refresh();
            //ページ番号の設定
            int lastPage = (int)Math.Ceiling(MajorCassification.Count / (double)pageSize);
            if (pageNo >= lastPage)
                textBoxPage.Text = lastPage.ToString();
            else
                textBoxPage.Text = (pageNo + 1).ToString();

        }

        private void buttonLastPage_Click(object sender, EventArgs e)
        {
            int pageSize = int.Parse(textBoxPageSize.Text);
            //最終ページの計算
            int pageNo = (int)Math.Ceiling(MajorCassification.Count / (double)pageSize) - 1;
            dataGridViewMc.DataSource = MajorCassification.Skip(pageSize * pageNo).Take(pageSize).ToList();

            // DataGridViewを更新
            dataGridViewMc.Refresh();
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
            textBoxMcID.Text = "";
            textBoxMcName.Text = "";
            checkBoxMcFlag.Checked = false;
            textBoxMcHidden.Text = "";
        }


        private void buttonClear_Click(object sender, EventArgs e)
        {
            ClearInput();

            
        }
        ///////////////大分類情報更新//////////////////

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            // 4.3.2.1 妥当な大分類データ取得
            if (!GetValidDataAtUpdate())
                return;

            // 4.3.2.2　大分類情報作成
            var updMc = GenerateDataAtUpdate();

            // 4.3.2.3 大分類情報更新
            UpdateMc(updMc);

        }
        ///////////////////////////////
        //  4.3.2.1 妥当な大分類データ取得
        //メソッド名：GetValidDataAtUpdate()
        //引　数   ：なし
        //戻り値   ：true or false
        //機　能   ：入力データの形式チェック
        //          ：エラーがない場合True
        //          ：エラーがある場合False
        ///////////////////////////////
        private bool GetValidDataAtUpdate()
        {
            //大分類IDの適否
            
            if (!String.IsNullOrEmpty(textBoxMcID.Text.Trim()))
            {
                //大分類IDの半角数値チェック
                if (!dataInputFormCheck.CheckNumeric(textBoxMcID.Text.Trim()))
                {
                    MessageBox.Show("大分類IDは半角数値入力です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxMcID.Focus();
                    return false;
                }
                //文字数
                if (textBoxMcID.TextLength > 2)
                {
                    MessageBox.Show("大分類IDは2文字以下です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
                    textBoxMcID.Focus();
                    return false;
                }

                // 大分類IDの存在チェック
                if (!majorClassificationDataAccess.CheckMcIDExistence(int.Parse(textBoxMcID.Text.Trim())))
                {
                    MessageBox.Show("入力された大分類IDは存在しません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
                    textBoxMcID.Focus();
                    return false;
                }

            }
            else
            {
                MessageBox.Show("大分類ID が入力されていません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
               
                textBoxMcID.Focus();
                return false;
            }
            //大分類名の適否
            if (!String.IsNullOrEmpty(textBoxMcName.Text.Trim()))
            {
                if (textBoxMcName.TextLength > 50)
                {

                    MessageBox.Show("大分類名は50文字以下です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    textBoxMcName.Focus();
                    return false;
                }
            }
            else
            {

                MessageBox.Show("大分類名が入力されていません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxMcName.Focus();
                return false;

            }
            //フラグの適否
            if (checkBoxMcFlag.CheckState == CheckState.Indeterminate)
            {
                MessageBox.Show("非表示フラグが不確定の状態です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);

                checkBoxMcFlag.Focus();
                return false;
            }
            //非表示理由の適否
            if (checkBoxMcFlag.Checked == true && !String.IsNullOrEmpty(textBoxMcHidden.Text.Trim()))
            {
                MessageBox.Show("非表示理由が入力されていません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxMcHidden.Focus();
                return false;
            }


            return true;
        }
        ///////////////////////////////
        //　4.3.2.2 大分類情報作成
        //メソッド名：GenerateDataAtUpdate()
        //引　数   ：なし
        //戻り値   ：大分類更新情報
        //機　能   ：更新データのセット
        ///////////////////////////////
        private M_MajorCassification GenerateDataAtUpdate()
        {
            int McFlag = 0;
            if (checkBoxMcFlag.Checked == true)
            {
                McFlag = 2;
            }
            return new M_MajorCassification
            {
                McName = textBoxMcName.Text.Trim(),
                McFlag = McFlag,
                McHidden = textBoxMcHidden.Text.Trim(),
            };
        }
        ///////////////////////////////
        //　4.3.2.3 大分類情報更新
        //メソッド名：UpdateMc()
        //引　数   ：大分類情報
        //戻り値   ：なし
        //機　能   ：大分類情報の更新
        ///////////////////////////////
        private void UpdateMc(M_MajorCassification updMc)
        {
            // 更新確認メッセージ
            DialogResult result = MessageBox.Show("大分類データを更新してよろしいですか?", "追加確認", MessageBoxButtons.OK, MessageBoxIcon.Question);
            if (result == DialogResult.Cancel)
                return;

            // 大分類情報の更新
            bool flg = majorClassificationDataAccess.UpdateMcData(updMc);
            if (flg == true)
                MessageBox.Show("データを更新しました。", "追加確認", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
               
            else
                MessageBox.Show("データの更新に失敗しました。", "追加確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            textBoxMcID.Focus();

            // 入力エリアのクリア
            ClearInput();

            // データグリッドビューの表示
            GetDataGridView();

        }
        ///////////大分類情報検索/////////////

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            //妥当な大分類データ取得
            if (!GetValidDataAtSelect())
                return;

            //大分類情報抽出
            GenerateDataAtSelect();

            //大分類抽出結果表示
            SetSelectData();

        }
        ///////////////////////////////
        //　4.3.3.1 妥当な大分類データ取得
        //メソッド名：GetValidDataAtSlect()
        //引　数   ：なし
        //戻り値   ：true or false
        //機　能   ：入力データの形式チェック
        //          ：エラーがない場合True
        //          ：エラーがある場合False
        ///////////////////////////////
        private bool GetValidDataAtSelect()
        {
            if (!String.IsNullOrEmpty(textBoxMcID.Text.Trim()))
            {
                //大分類IDの半角数値チェック
                if (!dataInputFormCheck.CheckNumeric(textBoxMcID.Text.Trim()))
                {
                    MessageBox.Show("大分類IDは半角数値入力です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxMcID.Focus();
                    return false;
                }
                //文字数
                if (textBoxMcID.TextLength > 2)
                {
                    MessageBox.Show("大分類IDは2文字以下です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    textBoxMcID.Focus();
                    return false;
                }

                // 大分類IDの存在チェック
                if (!majorClassificationDataAccess.CheckMcIDExistence(int.Parse(textBoxMcID.Text.Trim())))
                {
                    MessageBox.Show("入力された大分類IDは存在しません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    textBoxMcID.Focus();
                    return false;
                }

            }
            //大分類名の適否
            if (!String.IsNullOrEmpty(textBoxMcName.Text.Trim()))
            {
                if (textBoxMcName.TextLength > 50)
                {

                    MessageBox.Show("大分類名は50文字以下です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    textBoxMcName.Focus();
                    return false;
                }
            }
            //非表示フラグの適否
            if (checkBoxMcFlag.Checked == true)
            {
                MessageBox.Show("非表示フラグがチェックされています", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                checkBoxMcFlag.Focus();
                return false;
            }
            return true;
        }
        ///////////////////////////////
        //　4.3.3.2 大分類情報抽出
        //メソッド名：GenerateDataAtSelect()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：検索データの取得
        ///////////////////////////////
        private void GenerateDataAtSelect()
        {

            if (!String.IsNullOrEmpty(textBoxMcID.Text.Trim()))
            {
                M_MajorCassification selectCondition = new M_MajorCassification()
                {
                    McID = int.Parse(textBoxMcID.Text.Trim()),
                    McName = textBoxMcName.Text.Trim(),

                };
                MajorCassification = majorClassificationDataAccess.GetMcData(selectCondition);
            }
            else
            {
                M_MajorCassification selectCondition = new M_MajorCassification()
                {
                    
                    McName = textBoxMcName.Text.Trim(),

                };
                MajorCassification = majorClassificationDataAccess.GetMcData(selectCondition);
            }
                
        }
        ///////////////////////////////
        //　4.3.3.3 大分類抽出結果表示
        //メソッド名：SetSelectData()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：大分類情報の表示
        ///////////////////////////////
        private void SetSelectData()
        {
            textBoxPage.Text = "1";

            int pageSize = int.Parse(textBoxPageSize.Text);

            dataGridViewMc.DataSource = MajorCassification;
            if (MajorCassification.Count == 0)
            {
                MessageBox.Show("該当データが存在しません", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            labelPage.Text = "/" + ((int)Math.Ceiling(MajorCassification.Count / (double)pageSize)) + "ページ";
            dataGridViewMc.Refresh();


        }
        ///////////////////////////////
        //メソッド名：buttonList_Click()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：大分類データの一覧表示機能
        ///////////////////////////////

        private void buttonList_Click(object sender, EventArgs e)
        {
            GetDataGridView();
        }
        ///////////////////////////////
        //メソッド名：buttonNotList_Click()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：大分類データの非表示一覧表示機能
        ///////////////////////////////

        private void buttonNotList_Click(object sender, EventArgs e)
        {
            GetHiddenDataGridView();
        }

        private void checkBoxMcFlag_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxMcFlag.Checked == true)
            {
                textBoxMcHidden.TabStop = true;
                textBoxMcHidden.ReadOnly = false;
            }
            else
            {
                textBoxMcHidden.Text = "";
                textBoxMcHidden.TabStop = false;
                textBoxMcHidden.ReadOnly = true;

            }

        }
    }
}
