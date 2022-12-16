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
    public partial class FormChumon : Form
    {
        //メッセージ表示用クラスのインスタンス化
        MessageDsp messageDsp = new MessageDsp();
        //データベース注文テーブルアクセス用クラスのインスタンス化
        ChumonDataAccess chumonDataAccess = new ChumonDataAccess();
        //データベース受注テーブルアクセス用クラスのインスタンス化
        ChumonDataAccess ChumonDataAccess = new ChumonDataAccess();
        //データベース社員テーブルアクセス用クラスのインスタンス化
        EmployeeDataAccess employeeDataAccess = new EmployeeDataAccess();
        //データベース営業所テーブルアクセス用クラスのインスタンス化
        SalesOfficeDataAccess salesOfficeDataAccess = new SalesOfficeDataAccess();
        //入力形式チェック用クラスのインスタンス化
        DataInputFormCheck dataInputFormCheck = new DataInputFormCheck();
        //データベース顧客テーブルアクセス用クラスのインスタンス化
        ClientDataAccess clientDataAccess = new ClientDataAccess();
        //データグリッドビュー用の注文データ
        private static List<T_ChumonDsp> Chumon;
        //データグリッドビュー用の社員データ
        private static List<M_EmployeeDsp> Employee;
        //コンボボックス用の営業所データ
        private static List<M_SalesOffice> SalesOffice;


        public FormChumon()
        {
            InitializeComponent();
        }

        private void FormChumon_Load(object sender, EventArgs e)
        {
            //日時の表示
            labelDay.Text = DateTime.Now.ToString("yyyy/MM/dd/(ddd)");
            labelTime.Text = DateTime.Now.ToString("HH:mm");
            //panelHeaderに表示するログインデータ
            labelUserName.Text = "ユーザー名：" + FormMain.loginName;
            labelPosition.Text = "権限:" + FormMain.loginPoName;
            labelSalesOffice.Text = FormMain.loginSoName;
            labelUserID.Text = "ユーザーID：" + FormMain.loginEmID.ToString();
            //非表示理由タブ選択不可、入力不可
            textBoxChHidden.TabStop = false;
            textBoxChHidden.ReadOnly = true;

            SetFormDataGridView();
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
            dataGridViewChumon.ReadOnly = true;
            //直接のサイズの変更を不可
            dataGridViewChumon.AllowUserToResizeRows = false;
            dataGridViewChumon.AllowUserToResizeColumns = false;
            //直接の登録を不可にする
            dataGridViewChumon.AllowUserToAddRows = false;
            //行内をクリックすることで行を選択
            dataGridViewChumon.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //奇数行の色を変更
            dataGridViewChumon.AlternatingRowsDefaultCellStyle.BackColor = Color.Honeydew;
            //ヘッダー位置の指定
            dataGridViewChumon.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //データグリッドビューのデータ取得
            GetDataGridView();

        }
   

        private void SetDataGridView()
        {
            int pageSize = int.Parse(textBoxPageSize.Text);
            int pageNo = int.Parse(textBoxPage.Text) - 1;
            dataGridViewChumon.DataSource = Chumon.Skip(pageSize * pageNo).Take(pageSize).ToList();
            //各列幅の指定 //1475
            dataGridViewChumon.Columns[0].Width = 100;
            dataGridViewChumon.Columns[1].Width = 100;
            dataGridViewChumon.Columns[2].Visible = false;
            dataGridViewChumon.Columns[3].Width = 100;
            dataGridViewChumon.Columns[4].Width = 100;
            dataGridViewChumon.Columns[5].Width = 150;
            dataGridViewChumon.Columns[6].Width = 100;
            dataGridViewChumon.Columns[7].Width = 200;
            dataGridViewChumon.Columns[8].Width = 200;
            dataGridViewChumon.Columns[9].Visible = false;
            dataGridViewChumon.Columns[10].Visible = false;
            dataGridViewChumon.Columns[11].Width = 460;

            //各列の文字位置の指定
            dataGridViewChumon.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewChumon.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewChumon.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewChumon.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewChumon.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewChumon.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewChumon.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewChumon.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewChumon.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewChumon.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewChumon.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewChumon.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            //dataGridViewの総ページ数
            labelPage.Text = "/" + ((int)Math.Ceiling(Chumon.Count / (double)pageSize)) + "ページ";

            dataGridViewChumon.Refresh();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            //日時更新
            labelDay.Text = DateTime.Now.ToString("yyyy/MM/dd/(ddd)");
            labelTime.Text = DateTime.Now.ToString("HH:mm");
        }

        private void buttonFormDel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonChumonDetail_Click(object sender, EventArgs e)
        {
            if (labelChumon.Text == "注文管理")
            {
                labelChumon.Text = "注文詳細管理";
                buttonChumonDetail.Text = "注文管理";
                userControlChumonDetail1.Visible = true;
                panelChumon.Visible = false;
                return;
            }
            if (labelChumon.Text == "注文詳細管理")
            {
                labelChumon.Text = "注文管理";
                buttonChumonDetail.Text = "注文詳細";
                panelChumon.Visible = true;
                userControlChumonDetail1.Visible = false;
                return;
            }
        }



        ////////注文情報検索///////////
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            //妥当な注文データ取得
            if (!GetValidDataAtSelect())
                return;

            // 8.3.4.2 注文情報抽出
            GenerateDataAtSelect();

            // 8.3.4.3 注文抽出結果表示
            SetSelectData();
        }

        ///////////////////////////////
        //　＊.*.*.* 妥当な注文データ取得
        //メソッド名：GetValidDataAtSlect()
        //引　数   ：なし
        //戻り値   ：true or false
        //機　能   ：入力データの形式チェック
        //          ：エラーがない場合True
        //          ：エラーがある場合False
        ///////////////////////////////
        private bool GetValidDataAtSelect()
        {
            //注文IDの適否
            if (!String.IsNullOrEmpty(textBoxChID.Text.Trim()))
            {
                //文字チェック
                if (!dataInputFormCheck.CheckNumeric(textBoxChID.Text.Trim()))
                {
                    MessageBox.Show("注文IDは半角数値入力です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxChID.Focus();
                    return false;
                }
                //文字数
                if (textBoxChID.TextLength > 6)
                {
                    MessageBox.Show("注文IDは6文字以下です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxChID.Focus();
                    return false;
                }
            }
            //受注IDの適否
            if (!String.IsNullOrEmpty(textBoxOrID.Text.Trim()))
            {
                //文字チェック
                if (!dataInputFormCheck.CheckNumeric(textBoxOrID.Text.Trim()))
                {
                    MessageBox.Show("受注IDは半角数値入力です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxOrID.Focus();
                    return false;
                }
                //文字数
                if (textBoxOrID.TextLength > 6)
                {
                    MessageBox.Show("受注IDは6文字以下です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxOrID.Focus();
                    return false;
                }
            }
            //顧客IDの適否
            if (!String.IsNullOrEmpty(textBoxClID.Text.Trim()))
            {
                //文字チェック
                if (!dataInputFormCheck.CheckNumeric(textBoxClID.Text.Trim()))
                {
                    MessageBox.Show("顧客IDは半角数値入力です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxClID.Focus();
                    return false;
                }
                //文字数
                if (textBoxClID.TextLength > 6)
                {
                    MessageBox.Show("顧客IDは6文字以下です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxClID.Focus();
                    return false;
                }
                // 顧客IDの存在チェック
                if (!clientDataAccess.CheckClIDExistence(int.Parse(textBoxClID.Text.Trim())))
                {
                    MessageBox.Show("入力された顧客IDは存在しません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxClID.Focus();
                    return false;
                }

            }
            //非表示フラグ
            if (checkBoxHidden.CheckState == CheckState.Indeterminate)
            {
                MessageBox.Show("非表示理由が不確定な状態です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                checkBoxHidden.Focus();
                return false;
            }

            return true;
        }
        ///////////////////////////////
        //　8.3.4.2 注文情報抽出
        //メソッド名：GenerateDataAtSelect()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：注文データの取得
        ///////////////////////////////
        private void GenerateDataAtSelect()
        {
            //日付範囲
            DateTime? startDay = null;
            DateTime? endDay = null;
            if (dateTimePickerDateStart.Checked)
                startDay = DateTime.Parse(dateTimePickerDateStart.Text);
            if (dateTimePickerDateEnd.Checked)
                endDay = DateTime.Parse(dateTimePickerDateEnd.Text);

            //非表示フラグ変換
            int chFlg = 0;
            if (checkBoxHidden.Checked == true)
            {
                chFlg = 2;
            }
            //注文確定フラグ変換
            int stateFlg = 0;
            if (checkBoxStateFlag.Checked == true)
            {
                stateFlg = 1;
            }
            //日付範囲が選択されていない
            if (startDay == null && endDay == null)
            {
                //入荷!=null
                if (!String.IsNullOrEmpty(textBoxChID.Text.Trim()))
                {
                    //受注ID!=null
                    if (!String.IsNullOrEmpty(textBoxOrID.Text.Trim()))
                    {
                        //顧客!=null
                        if (!String.IsNullOrEmpty(textBoxClID.Text.Trim()))
                        {
                            T_ChumonDsp selectCondition = new T_ChumonDsp()
                            {
                                ChID = int.Parse(textBoxChID.Text.Trim()),
                                OrID = int.Parse(textBoxOrID.Text.Trim()),
                                ClID = int.Parse(textBoxClID.Text.Trim()),
                                ChFlag = chFlg,
                                ChStateFlag = stateFlg,
                                ChHidden = textBoxChHidden.Text.Trim()
                            };
                            //データの抽出
                            Chumon = ChumonDataAccess.GetChumonData(1, selectCondition);

                        }
                        else
                        {
                            T_ChumonDsp selectCondition = new T_ChumonDsp()
                            {
                                ChID = int.Parse(textBoxChID.Text.Trim()),
                                OrID = int.Parse(textBoxOrID.Text.Trim()),
                                ChFlag = chFlg,
                                ChStateFlag = stateFlg,
                                ChHidden = textBoxChHidden.Text.Trim()
                            };
                            //データの抽出
                            Chumon = ChumonDataAccess.GetChumonData(2, selectCondition);

                        }

                    }
                    else
                    {
                        //顧客!=null
                        if (!String.IsNullOrEmpty(textBoxClID.Text.Trim()))
                        {
                            T_ChumonDsp selectCondition = new T_ChumonDsp()
                            {
                                ChID = int.Parse(textBoxChID.Text.Trim()),
                                ClID = int.Parse(textBoxClID.Text.Trim()),
                                ChFlag = chFlg,
                                ChStateFlag = stateFlg,
                                ChHidden = textBoxChHidden.Text.Trim()
                            };
                            //データの抽出
                            Chumon = ChumonDataAccess.GetChumonData(3, selectCondition);

                        }
                        else
                        {
                            T_ChumonDsp selectCondition = new T_ChumonDsp()
                            {
                                ChID = int.Parse(textBoxChID.Text.Trim()),
                                ChFlag = chFlg,
                                ChStateFlag = stateFlg,
                                ChHidden = textBoxChHidden.Text.Trim()
                            };
                            //データの抽出
                            Chumon = ChumonDataAccess.GetChumonData(4, selectCondition);

                        }


                    }

                }
                else
                {
                    //受注ID!=null
                    if (!String.IsNullOrEmpty(textBoxOrID.Text.Trim()))
                    {
                        //顧客!=null
                        if (!String.IsNullOrEmpty(textBoxClID.Text.Trim()))
                        {
                            T_ChumonDsp selectCondition = new T_ChumonDsp()
                            {
                                OrID = int.Parse(textBoxOrID.Text.Trim()),
                                ClID = int.Parse(textBoxClID.Text.Trim()),
                                ChFlag = chFlg,
                                ChStateFlag = stateFlg,
                                ChHidden = textBoxChHidden.Text.Trim()
                            };
                            //データの抽出
                            Chumon = ChumonDataAccess.GetChumonData(5, selectCondition);

                        }
                        else
                        {
                            T_ChumonDsp selectCondition = new T_ChumonDsp()
                            {
                                OrID = int.Parse(textBoxOrID.Text.Trim()),
                                ChFlag = chFlg,
                                ChStateFlag = stateFlg,
                                ChHidden = textBoxChHidden.Text.Trim()
                            };
                            //データの抽出
                            Chumon = ChumonDataAccess.GetChumonData(6, selectCondition);

                        }

                    }
                    else
                    {
                        //顧客!=null
                        if (!String.IsNullOrEmpty(textBoxClID.Text.Trim()))
                        {
                            T_ChumonDsp selectCondition = new T_ChumonDsp()
                            {
                                ClID = int.Parse(textBoxClID.Text.Trim()),
                                ChFlag = chFlg,
                                ChStateFlag = stateFlg,
                                ChHidden = textBoxChHidden.Text.Trim()
                            };
                            //データの抽出
                            Chumon = ChumonDataAccess.GetChumonData(7, selectCondition);

                        }
                        else
                        {
                            T_ChumonDsp selectCondition = new T_ChumonDsp()
                            {
                                ChFlag = chFlg,
                                ChStateFlag = stateFlg,
                                ChHidden = textBoxChHidden.Text.Trim()
                            };
                            //データの抽出
                            Chumon = ChumonDataAccess.GetChumonData(8, selectCondition);

                        }


                    }

                }
            }
            //日付範囲が選択されている
            else if (startDay != null && endDay != null)
            {
                //入荷!=null
                if (!String.IsNullOrEmpty(textBoxChID.Text.Trim()))
                {
                    //受注ID!=null
                    if (!String.IsNullOrEmpty(textBoxOrID.Text.Trim()))
                    {
                        //顧客!=null
                        if (!String.IsNullOrEmpty(textBoxClID.Text.Trim()))
                        {
                            T_ChumonDsp selectCondition = new T_ChumonDsp()
                            {
                                ChID = int.Parse(textBoxChID.Text.Trim()),
                                OrID = int.Parse(textBoxOrID.Text.Trim()),
                                ClID = int.Parse(textBoxClID.Text.Trim()),
                                ChFlag = chFlg,
                                ChStateFlag = stateFlg,
                                ChHidden = textBoxChHidden.Text.Trim()
                            };
                            //データの抽出
                            Chumon = ChumonDataAccess.GetChumonDateData(1, selectCondition, startDay, endDay);

                        }
                        else//顧客ID未入力
                        {
                            T_ChumonDsp selectCondition = new T_ChumonDsp()
                            {
                                ChID = int.Parse(textBoxChID.Text.Trim()),
                                OrID = int.Parse(textBoxOrID.Text.Trim()),
                                ChFlag = chFlg,
                                ChStateFlag = stateFlg,
                                ChHidden = textBoxChHidden.Text.Trim()
                            };
                            //データの抽出
                            Chumon = ChumonDataAccess.GetChumonDateData(2, selectCondition, startDay, endDay);

                        }

                    }
                    else//受注ID未入力
                    {
                        //顧客!=null
                        if (!String.IsNullOrEmpty(textBoxClID.Text.Trim()))
                        {
                            T_ChumonDsp selectCondition = new T_ChumonDsp()
                            {
                                ChID = int.Parse(textBoxChID.Text.Trim()),
                                ClID = int.Parse(textBoxClID.Text.Trim()),
                                ChFlag = chFlg,
                                ChStateFlag = stateFlg,
                                ChHidden = textBoxChHidden.Text.Trim()
                            };
                            //データの抽出
                            Chumon = ChumonDataAccess.GetChumonDateData(3, selectCondition, startDay, endDay);

                        }
                        else
                        {
                            T_ChumonDsp selectCondition = new T_ChumonDsp()
                            {
                                ChID = int.Parse(textBoxChID.Text.Trim()),
                                ChFlag = chFlg,
                                ChStateFlag = stateFlg,
                                ChHidden = textBoxChHidden.Text.Trim()
                            };
                            //データの抽出
                            Chumon = ChumonDataAccess.GetChumonDateData(4, selectCondition, startDay, endDay);

                        }
                    }
                }
                else//入荷ID未入力
                {
                    //受注ID!=null
                    if (!String.IsNullOrEmpty(textBoxOrID.Text.Trim()))
                    {
                        //顧客!=null
                        if (!String.IsNullOrEmpty(textBoxClID.Text.Trim()))
                        {
                            T_ChumonDsp selectCondition = new T_ChumonDsp()
                            {
                                OrID = int.Parse(textBoxOrID.Text.Trim()),
                                ClID = int.Parse(textBoxClID.Text.Trim()),
                                ChFlag = chFlg,
                                ChStateFlag = stateFlg,
                                ChHidden = textBoxChHidden.Text.Trim()
                            };
                            //データの抽出
                            Chumon = ChumonDataAccess.GetChumonDateData(5, selectCondition, startDay, endDay);

                        }
                        else//顧客ID未入力
                        {
                            T_ChumonDsp selectCondition = new T_ChumonDsp()
                            {
                                OrID = int.Parse(textBoxOrID.Text.Trim()),
                                ChFlag = chFlg,
                                ChStateFlag = stateFlg,
                                ChHidden = textBoxChHidden.Text.Trim()
                            };
                            //データの抽出
                            Chumon = ChumonDataAccess.GetChumonDateData(6, selectCondition, startDay, endDay);

                        }

                    }
                    else//受注ID未入力
                    {
                        //顧客!=null
                        if (!String.IsNullOrEmpty(textBoxClID.Text.Trim()))
                        {
                            T_ChumonDsp selectCondition = new T_ChumonDsp()
                            {
                                ClID = int.Parse(textBoxClID.Text.Trim()),
                                ChFlag = chFlg,
                                ChStateFlag = stateFlg,
                                ChHidden = textBoxChHidden.Text.Trim()
                            };
                            //データの抽出
                            Chumon = ChumonDataAccess.GetChumonDateData(7, selectCondition, startDay, endDay);

                        }
                        else//顧客ID未入力
                        {
                            T_ChumonDsp selectCondition = new T_ChumonDsp()
                            {
                                ChFlag = chFlg,
                                ChStateFlag = stateFlg,
                                ChHidden = textBoxChHidden.Text.Trim()
                            };
                            //データの抽出
                            Chumon = ChumonDataAccess.GetChumonDateData(8, selectCondition, startDay, endDay);

                        }
                    }
                }
            }
        }
        ///////////////////////////////
        //　8.3.4.3 注文抽出結果表示
        //メソッド名：SetSelectData()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：注文情報の表示
        ///////////////////////////////
        private void SetSelectData()
        {

        }
        ///////////////////////////////
        //メソッド名：buttonList_Click()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：注文データの一覧表示機能
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
        //機　能   ：注文データの非表示一覧表示機能
        ///////////////////////////////
        private void buttonHiddenList_Click(object sender, EventArgs e)
        {
            // 入力エリアのクリア
            ClearInput();

            GetHiddenDataGridView();
        }

        ///////////////////////////////
        //メソッド名：ClearInput()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：入力エリアをクリア
        ///////////////////////////////
        private void ClearInput()
        {
            // デートタイムピッカの設定
            dateTimePickerDateStart.Checked = false;
            dateTimePickerDateEnd.Checked = false;
            textBoxChID.Text = "";
            textBoxOrID.Text = "";
            textBoxClID.Text = "";
            textBoxClName.Text = "";
            checkBoxStateFlag.Checked = false;
            textBoxChHidden.Text = "";
            checkBoxHidden.Checked = false;
        }

        ///////////////////////////////
        //メソッド名：GetDataGridView()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：データグリッドビューに表示するデータの取得
        ///////////////////////////////
        private void GetDataGridView()
        {
            //注文データの取得
            Chumon = chumonDataAccess.GetChumonData();
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
            //注文データの取得
            Chumon = chumonDataAccess.GetChumonData();
            // DataGridViewに表示するデータを指定
            SetDataGridView();
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
            int pageSize = int.Parse(textBoxPageSize.Text);
            dataGridViewChumon.DataSource = Chumon.Take(pageSize).ToList();

            // DataGridViewを更新
            dataGridViewChumon.Refresh();
            //ページ番号の設定
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
            int lastNo = (int)Math.Ceiling(Chumon.Count / (double)pageSize) - 1;
            //最終ページでなければ
            if (pageNo <= lastNo)
                dataGridViewChumon.DataSource = Chumon.Skip(pageSize * pageNo).Take(pageSize).ToList();

            // DataGridViewを更新
            dataGridViewChumon.Refresh();
            //ページ番号の設定
            int lastPage = (int)Math.Ceiling(Chumon.Count / (double)pageSize);
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
            int pageNo = (int)Math.Ceiling(Chumon.Count / (double)pageSize) - 1;
            dataGridViewChumon.DataSource = Chumon.Skip(pageSize * pageNo).Take(pageSize).ToList();

            // DataGridViewを更新
            dataGridViewChumon.Refresh();
            //ページ番号の設定
            textBoxPage.Text = (pageNo + 1).ToString();
        }


        //入力クリア
        private void buttonClear_Click(object sender, EventArgs e)
        {
            ClearInput();
        }

        private void checkBoxHidden_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBoxHidden.Checked==true)
            {
                textBoxChHidden.TabStop = true;
                textBoxChHidden.ReadOnly = false;
            }
            else
            {
                textBoxChHidden.Text="";
                textBoxChHidden.TabStop = false;
                textBoxChHidden.ReadOnly = true;
            }
        }


        //データグリッドビュー セルクリック
        private void dataGridViewChumon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //データグリッドビューからクリックされたデータを各入力エリアへ
            textBoxChID.Text = dataGridViewChumon.Rows[dataGridViewChumon.CurrentRow.Index].Cells[0].Value.ToString();
            textBoxOrID.Text = dataGridViewChumon.Rows[dataGridViewChumon.CurrentRow.Index].Cells[1].Value.ToString();
            textBoxClID.Text = dataGridViewChumon.Rows[dataGridViewChumon.CurrentRow.Index].Cells[4].Value.ToString();
            textBoxClName.Text = dataGridViewChumon.Rows[dataGridViewChumon.CurrentRow.Index].Cells[5].Value.ToString();
            //flagの値の「0」「2」をbool型に変換してチェックボックスに表示させる
            if (dataGridViewChumon.Rows[dataGridViewChumon.CurrentRow.Index].Cells[8].Value.ToString() != 2.ToString())
            {
                checkBoxHidden.Checked = false;
            }
            else
            {
                checkBoxHidden.Checked = true;
            }
            //非表示理由がnullではない場合テキストボックスに表示させる
            if (dataGridViewChumon.Rows[dataGridViewChumon.CurrentRow.Index].Cells[9].Value != null)
            {
                checkBoxHidden.Text = dataGridViewChumon.Rows[dataGridViewChumon.CurrentRow.Index].Cells[9].Value.ToString();
            }


        }

        private void buttonKakutei_Click(object sender, EventArgs e)
        {

        }
    }
}

