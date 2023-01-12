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
    public partial class UserControlPosition : UserControl
    {
        //入力形式チェック用クラスのインスタンス化
        DataInputFormCheck dataInputFormCheck = new DataInputFormCheck();
        //メッセージ表示用クラスのインスタンス化
        MessageDsp messageDsp = new MessageDsp();
        //データベース大分類テーブルアクセス用クラスのインスタンス化
        PositionDataAccess positionDataAccess = new PositionDataAccess();
        //データグリッドビュー用の役職データ
        private static List<M_PositionDsp> Position;
        public UserControlPosition()
        {
            InitializeComponent();
        }

        private void UserControlPosition_Load(object sender, EventArgs e)
        {
            //データグリッドビューの設定
            SetFormDataGridView();
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
        //          ：エラーがなbbbbbbbい場合True
        //          ：エラーがある場合False
        ///////////////////////////////
        private bool GetValidDataAtRegistration()
        {
            // 役職IDの適否
            if (!String.IsNullOrEmpty(textBoxPoID.Text.Trim()))
            {
                //役職IDは入力不要です
                MessageBox.Show("役職IDは入力不要です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxPoID.Focus();
                return false;
            }


            // 役職名の適否
            if (!String.IsNullOrEmpty(textBoxPoName.Text.Trim()))
            {
                // 役職名の文字数チェック
                if (textBoxPoName.TextLength > 50)
                {
                    //MessageBox.Show("役職名は50文字以下です");
                    MessageBox.Show("役職名は50文字以下です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxPoName.Focus();
                    return false;
                }
            }
            else
            {
                MessageBox.Show("役職名が入力されていません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxPoName.Focus();
                return false;
            }
            // 削除フラグの適否
            if (checkBoxPoFlag.CheckState == CheckState.Indeterminate)
            {
                MessageBox.Show(" 非表示フラグが不確定の状態です");
                checkBoxPoFlag.Focus();
                return false;
            }
            if (checkBoxPoFlag.Checked == true)
            {
                MessageBox.Show("非表示フラグがチェックされています", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                checkBoxPoFlag.Focus();
                return false;
            }

            // 非表示の適否
            if (!String.IsNullOrEmpty(textBoxPoHidden.Text.Trim()))
            {
                MessageBox.Show("非表示理由は登録できません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxPoHidden.Focus();
                return false;
            }
            return true;
        }
        ///////////////////////////////
        //　8.2.1.2 役職情報作成
        //メソッド名：GenerateDataAtRegistration()
        //引　数   ：なし
        //戻り値   ：役職登録情報
        //機　能   ：登録データのセット
        ///////////////////////////////
        private M_Position GenerateDataAtRegistration()
        {
            return new M_Position
            {
                PoName = textBoxPoName.Text.Trim(),
                PoFlag = 0,
                PoHidden = String.Empty,
            };
        }
        ///////////////////////////////
        //　8.2.1.3 役職情報登録
        //メソッド名：RegistrationPosition()
        //引　数   ：役職情報
        //戻り値   ：なし
        //機　能   ：役職データの登録
        ///////////////////////////////
        private void RegistrationPosition(M_Position regPosition)
        {
            // 登録確認メッセージ
            DialogResult result = MessageBox.Show("役職データを登録してよろしいですか?", "追加確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (result == DialogResult.Cancel)
                return;
            // 役職情報の登録
            bool flg = positionDataAccess.AddPositionData(regPosition);
            if (flg == true)
                MessageBox.Show("データを登録しました", "追加確認", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("データの登録に失敗しました", "追加確認", MessageBoxButtons.OK, MessageBoxIcon.Information);

            textBoxPoID.Focus();

            // 入力エリアのクリア
            ClearInput();

            // データグリッドビューの表示
            GetDataGridView();

        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //クリックされた行データをテキストボックスへ
            textBoxPoID.Text = dataGridViewPo.Rows[dataGridViewPo.CurrentRow.Index].Cells[0].Value.ToString();
            textBoxPoName.Text = dataGridViewPo.Rows[dataGridViewPo.CurrentRow.Index].Cells[1].Value.ToString();
            checkBoxPoFlag.Checked = bool.Parse(dataGridViewPo.Rows[dataGridViewPo.CurrentRow.Index].Cells[2].Value.ToString());
            textBoxPoHidden.Text = dataGridViewPo.Rows[dataGridViewPo.CurrentRow.Index].Cells[3].Value.ToString();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            // 8.2.2.1 妥当な役職データ取得
            if (!GetValidDataAtUpdate())
                return;

            // 8.2.2.2 役職情報作成
            var updPosition = GenerateDataAtUpdate();

            // 8.2.2.3 役職情報更新
            UpdatePosition(updPosition);
        }
        ///////////////////////////////
        //　8.2.2.1 妥当な役職データ取得
        //メソッド名：GetValidDataAtUpdate()
        //引　数   ：なし
        //戻り値   ：true or false
        //機　能   ：入力データの形式チェック
        //          ：エラーがない場合True
        //          ：エラーがある場合False
        ///////////////////////////////
        private bool GetValidDataAtUpdate()
        {

            // 役職IDの未入力チェック
            if (!String.IsNullOrEmpty(textBoxPoID.Text.Trim()))
            {
                // 役職IDの半角英数字チェック
                if (!dataInputFormCheck.CheckHalfAlphabetNumeric(textBoxPoID.Text.Trim()))
                {
                    //MessageBox.Show("役職IDは全て半角英数字入力です");
                    MessageBox.Show("役職IDは半角数値入力です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxPoID.Focus();
                    return false;
                }
                // 役職IDの文字数チェック
                if (textBoxPoID.TextLength > 2)
                {
                    //MessageBox.Show("役職IDは2文字です");
                    MessageBox.Show("役職IDは2文字以下です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxPoID.Focus();
                    return false;
                }
                // 役職IDの存在チェック
                if (!positionDataAccess.CheckPoIDExistence(int.Parse(textBoxPoID.Text.Trim())))
                {
                    //MessageBox.Show("入力された役職IDは存在しません");
                    MessageBox.Show("入力された役職IDは存在しません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxPoID.Focus();
                    return false;
                }
            }
            else
            {
                //MessageBox.Show("役職IDが入力されていません");
                MessageBox.Show("役職IDが入力されていません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxPoID.Focus();
                return false;
            }


            // 役職名の適否
            if (!String.IsNullOrEmpty(textBoxPoName.Text.Trim()))
            {   
                // 役職名の文字数チェック
                if (textBoxPoName.TextLength > 50)
                {
                    //MessageBox.Show("役職名は50文字以下です");
                    MessageBox.Show("役職名は50文字以下です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxPoName.Focus();
                    return false;
                }
            }
            else
            {
                //MessageBox.Show("役職名が入力されていません");
                MessageBox.Show("役職名が入力されていません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxPoName.Focus();
                return false;
            }



            // 削除フラグの適否
            if (checkBoxPoFlag.CheckState == CheckState.Indeterminate)
            {
                //MessageBox.Show("非表示フラグが不確定の状態です");
                MessageBox.Show("非表示フラグが不確定の状態です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                checkBoxPoFlag.Focus();
                return false;
            }

            // 備考の適否
            if (checkBoxPoFlag.Checked == true && string.IsNullOrEmpty(textBoxPoHidden.Text.Trim()))
            {
                MessageBox.Show("非表示理由が入力されていません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxPoHidden.Focus();
                return false;
            }
            return true;
        }
        ///////////////////////////////
        //　8.2.2.2 役職情報作成
        //メソッド名：GenerateDataAtUpdate()
        //引　数   ：なし
        //戻り値   ：役職更新情報
        //機　能   ：更新データのセット
        ///////////////////////////////
        private M_PositionDsp GenerateDataAtUpdate()
        {
            int poFlag = 0;
            if (checkBoxPoFlag.Checked == true)
                poFlag = 2;
            return new M_PositionDsp
            {
                PoID = int.Parse(textBoxPoID.Text.Trim()),
                PoName = textBoxPoName.Text.Trim(),
                PoFlag = poFlag,
                PoHidden = textBoxPoHidden.Text.Trim()
            };
        }
        ///////////////////////////////
        //　8.2.2.3 役職情報更新
        //メソッド名：UpdatePosition()
        //引　数   ：役職情報
        //戻り値   ：なし
        //機　能   ：役職情報の更新
        ///////////////////////////////
        private void UpdatePosition(M_PositionDsp updPosition)
        {
            // 更新確認メッセージ
            DialogResult result = MessageBox.Show("データを更新してよろしいですか?", "追加確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Cancel)
                return;

            // 役職情報の更新
            bool flg = positionDataAccess.UpdatePositionData(updPosition);
            if (flg == true)
                MessageBox.Show("データを更新しました", "更新確認", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("データの更新に失敗しました", "更新確認", MessageBoxButtons.OK, MessageBoxIcon.Error);

            textBoxPoID.Focus();

            // 入力エリアのクリア
            ClearInput();

            // データグリッドビューの表示
            GetDataGridView();


        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            // 8.2.4.1 妥当な役職データ取得
            if (!GetValidDataAtSelect())
                return;

            // 8.2.4.2 役職情報抽出
            GenerateDataAtSelect();

            // 8.2.4.3 役職抽出結果表示
            SetSelectData();
        }

        private void buttonList_Click(object sender, EventArgs e)
        {
            //入力エリアのクリア
            ClearInput();

            GetDataGridView();
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
            textBoxPoID.Text = "";
            textBoxPoName.Text = "";
            textBoxPoHidden.Text = "";
            checkBoxPoFlag.Checked = false;
        }
        ///////////////////////////////
        //メソッド名：GetDataGridView()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：データグリッドビューに表示するデータの取得
        ///////////////////////////////
        private void GetDataGridView()
        {

            // 役職データの取得
            Position = positionDataAccess.GetPositionData();

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
            dataGridViewPo.ReadOnly = true;
            //直接のサイズの変更を不可
            dataGridViewPo.AllowUserToResizeRows = false;
            dataGridViewPo.AllowUserToResizeColumns = false;
            //直接の登録を不可にする
            dataGridViewPo.AllowUserToAddRows = false;
            //行内をクリックすることで行を選択
            dataGridViewPo.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //奇数行の色を変更
            dataGridViewPo.AlternatingRowsDefaultCellStyle.BackColor = Color.Honeydew;
            //ヘッダー位置の指定
            dataGridViewPo.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

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
            dataGridViewPo.DataSource = Position.Skip(pageSize * pageNo).Take(pageSize).ToList();
            //各列幅の指定
            dataGridViewPo.Columns[0].Width = 120;
            dataGridViewPo.Columns[1].Width = 180;
            dataGridViewPo.Columns[2].Width = 100;
            dataGridViewPo.Columns[3].Width = 575;

            //各列の文字位置の指定
            dataGridViewPo.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewPo.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewPo.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewPo.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            //dataGridViewの総ページ数
            labelPage.Text = "/" + ((int)Math.Ceiling(Position.Count / (double)pageSize)) + "ページ";

            dataGridViewPo.Refresh();
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
            dataGridViewPo.DataSource = Position.Take(pageSize).ToList();

            // DataGridViewを更新
            dataGridViewPo.Refresh();
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
            dataGridViewPo.DataSource = Position.Skip(pageSize * pageNo).Take(pageSize).ToList();

            // DataGridViewを更新
            dataGridViewPo.Refresh();
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
            int lastNo = (int)Math.Ceiling(Position.Count / (double)pageSize) - 1;
            //最終ページでなければ
            if (pageNo <= lastNo)
                dataGridViewPo.DataSource = Position.Skip(pageSize * pageNo).Take(pageSize).ToList();

            // DataGridViewを更新
            dataGridViewPo.Refresh();
            //ページ番号の設定
            int lastPage = (int)Math.Ceiling(Position.Count / (double)pageSize);
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
            int pageNo = (int)Math.Ceiling(Position.Count / (double)pageSize) - 1;
            dataGridViewPo.DataSource = Position.Skip(pageSize * pageNo).Take(pageSize).ToList();

            // DataGridViewを更新
            dataGridViewPo.Refresh();
            //ページ番号の設定
            textBoxPage.Text = (pageNo + 1).ToString();
        }
        ///////////////////////////////
        //　8.2.4.1 妥当な役職データ取得
        //メソッド名：GetValidDataAtSlect()
        //引　数   ：なし
        //戻り値   ：true or false
        //機　能   ：入力データの形式チェック
        //          ：エラーがない場合True
        //          ：エラーがある場合False
        ///////////////////////////////
        private bool GetValidDataAtSelect()
        {

            // 役職CD入力時チェック
            if (!String.IsNullOrEmpty(textBoxPoID.Text.Trim()))
            {
                // 役職IDの半角英数字チェック
                if (!dataInputFormCheck.CheckHalfAlphabetNumeric(textBoxPoID.Text.Trim()))
                {
                    //MessageBox.Show("役職CDは全て半角英数字入力です");
                    messageDsp.DspMsg("M2001");
                    textBoxPoID.Focus();
                    return false;
                }
                // 役職IDの文字数チェック
                if (textBoxPoID.TextLength > 2)
                {
                    //MessageBox.Show("役職CDは2 文字までです");
                    messageDsp.DspMsg("M2002");
                    textBoxPoID.Focus();
                    return false;
                }
            }
            // 役職名入力時チェック
            if (!String.IsNullOrEmpty(textBoxPoName.Text.Trim()))
            {
                // 役職名の全角チェック
                if (!dataInputFormCheck.CheckFullWidth(textBoxPoName.Text.Trim()))
                {
                    //MessageBox.Show("役職名は全て全角入力です");
                    messageDsp.DspMsg("M2005");
                    textBoxPoName.Focus();
                    return false;
                }
                // 役職名の文字数チェック
                if (textBoxPoName.TextLength > 25)
                {
                    //MessageBox.Show("役職名は25文字以下です");
                    messageDsp.DspMsg("M2006");
                    textBoxPoName.Focus();
                    return false;
                }
            }

            return true;

        }
        ///////////////////////////////
        //　8.2.4.2 役職情報抽出
        //メソッド名：GenerateDataAtSelect()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：役職情報の取得
        ///////////////////////////////
        private void GenerateDataAtSelect()
        {
            int poFlg = 0;
            if(checkBoxPoFlag.Checked == true)
            {
                poFlg = 2;
            }
            // 検索条件のセット
            if (!String.IsNullOrEmpty(textBoxPoID.Text.Trim()))
            {
                M_PositionDsp position = new M_PositionDsp()
                {
                    PoID = int.Parse(textBoxPoID.Text.Trim()),
                    PoName = textBoxPoName.Text.Trim(),
                    PoFlag = poFlg,
                    PoHidden = textBoxPoHidden.Text.Trim()
                };
                // 役職データの抽出
                Position = positionDataAccess.GetPositionData(1,position);
            }
            

        }
        ///////////////////////////////
        //　8.2.4.3 役職抽出結果表示
        //メソッド名：SetSelectData()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：役職情報の表示
        ///////////////////////////////
        private void SetSelectData()
        {
            textBoxPage.Text = "1";

            int pageSize = int.Parse(textBoxPageSize.Text);

            dataGridViewPo.DataSource = Position;
            if (Position.Count == 0)
            {
                MessageBox.Show("該当データが存在しません", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            labelPage.Text = "/" + ((int)Math.Ceiling(Position.Count / (double)pageSize)) + "ページ";
            dataGridViewPo.Refresh();
        }

        private void checkBoxPoFlag_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxPoFlag.Checked == true)
            {
                textBoxPoHidden.TabStop = true;
                textBoxPoHidden.ReadOnly = false;
                textBoxPoHidden.Enabled = true;
            }
            else
            {
                textBoxPoHidden.Text = "";
                textBoxPoHidden.TabStop = false;
                textBoxPoHidden.ReadOnly = true;
                textBoxPoHidden.Enabled = false;
            }
        }

        private void buttonNotList_Click(object sender, EventArgs e)
        {
            ClearInput();

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
            //営業データの取得
            Position = positionDataAccess.GetPositionHiddenData();

            // DataGridViewに表示するデータを指定
            SetDataGridView();
        }

        private void dataGridViewPo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxPoID.Text = dataGridViewPo.Rows[dataGridViewPo.CurrentRow.Index].Cells[0].Value.ToString();
            textBoxPoName.Text = dataGridViewPo.Rows[dataGridViewPo.CurrentRow.Index].Cells[1].Value.ToString();

            //flagの値の「0」「2」をbool型に変換してチェックボックスに表示させる
            if (dataGridViewPo.Rows[dataGridViewPo.CurrentRow.Index].Cells[2].Value.ToString() != 2.ToString())
            {
                checkBoxPoFlag.Checked = false;
            }
            else
            {
                checkBoxPoFlag.Checked = true;
            }
            //非表示理由がnullではない場合テキストボックスに表示させる
            if (dataGridViewPo.Rows[dataGridViewPo.CurrentRow.Index].Cells[3].Value != null)
            {
                textBoxPoHidden.Text = dataGridViewPo.Rows[dataGridViewPo.CurrentRow.Index].Cells[3].Value.ToString();
            }


        }
    }
}
