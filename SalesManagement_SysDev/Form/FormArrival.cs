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
    public partial class FormArrival : Form
    {
        //データベース入荷テーブルアクセス用クラスのインスタンス化
        ArrivalDataAccess arrivalDataAccess = new ArrivalDataAccess();
        //データベース入荷詳細テーブルアクセス用クラスのインスタンス化
        ArrivalDetailDataAccess arrivalDetailDataAccess = new ArrivalDetailDataAccess();
        //データベース出荷テーブルアクセス用クラスのインスタンス化
        ShipmentDataAccess shipmentDataAccess = new ShipmentDataAccess();
        //データベース出荷詳細テーブルアクセス用クラスのインスタンス化
        ShipmentDetailDataAccess shipmentDetailDataAccess = new ShipmentDetailDataAccess();

        //データベース顧客テーブルアクセス用クラスのインスタンス化
        ClientDataAccess clientDataAccess = new ClientDataAccess();
        //入力形式チェック用クラスのインスタンス化
        DataInputFormCheck dataInputFormCheck = new DataInputFormCheck();
        //データグリッドビュー用の出庫データ
        private static List<T_ArrivalDsp> Arrival;
        //入荷ID参照用クラス
        private TArrival tArrival = new TArrival();

        public FormArrival()
        {
            InitializeComponent();
            userControlArrivalDetail1.addTArrival(tArrival);
        }

        private void FormArrival_Load(object sender, EventArgs e)
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
            textBoxArHidden.TabStop = false;
            textBoxArHidden.ReadOnly = true;


            //データグリッドビューの設定
            SetFormDataGridView();
        }
        //入力された顧客IDの顧客名を取得
        private void textBoxClID_TextChanged(object sender, EventArgs e)
        {
            textBoxClName.Text = "";
            if (dataInputFormCheck.CheckNumeric(textBoxClID.Text.Trim()))
            {
                if (textBoxClID.TextLength < 6)
                {
                    if (clientDataAccess.CheckClIDExistence(int.Parse(textBoxClID.Text.Trim())))
                    {
                        M_Client client = clientDataAccess.GetClIDData(int.Parse(textBoxClID.Text.Trim()));
                        textBoxClName.Text = client.ClName.ToString();
                    }

                }
            }

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
            dataGridViewAr.ReadOnly = true;
            //直接のサイズの変更を不可
            dataGridViewAr.AllowUserToResizeRows = false;
            dataGridViewAr.AllowUserToResizeColumns = false;
            //直接の登録を不可にする
            dataGridViewAr.AllowUserToAddRows = false;
            //行内をクリックすることで行を選択
            dataGridViewAr.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //奇数行の色を変更
            dataGridViewAr.AlternatingRowsDefaultCellStyle.BackColor = Color.Honeydew;
            //ヘッダー位置の指定
            dataGridViewAr.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

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
            // 入荷データの取得
            Arrival = arrivalDataAccess.GetArrivalData();

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
            // 入荷データの取得
            Arrival = arrivalDataAccess.GetArrivalHiddenData();

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
            dataGridViewAr.DataSource = Arrival.Skip(pageSize * pageNo).Take(pageSize).ToList();
            //各列幅の指定 //1510
            dataGridViewAr.Columns[0].Width = 100;
            dataGridViewAr.Columns[1].Visible = false;
            dataGridViewAr.Columns[2].Width = 200;
            dataGridViewAr.Columns[3].Width = 100;
            dataGridViewAr.Columns[4].Width = 200;
            dataGridViewAr.Columns[5].Width = 100;
            dataGridViewAr.Columns[6].Width = 200;
            dataGridViewAr.Columns[7].Width = 175;
            dataGridViewAr.Columns[8].Width = 200;
            dataGridViewAr.Columns[9].Visible = false;
            dataGridViewAr.Columns[10].Visible = false;
            dataGridViewAr.Columns[11].Width = 250;

            //各列の文字位置の指定
            dataGridViewAr.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewAr.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewAr.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewAr.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewAr.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewAr.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewAr.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewAr.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewAr.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            //dataGridViewの総ページ数
            labelPage.Text = "/" + ((int)Math.Ceiling(Arrival.Count / (double)pageSize)) + "ページ";

            dataGridViewAr.Refresh();
        }
        ///////////////////////////////
        //メソッド名：buttonPageSizeChange_Click()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：データグリッドビューの表示件数変更
        ///////////////////////////////

        private void buttonPageSizeChange_Click(object sender, EventArgs e)
        {
            textBoxPage.Text=1.ToString();
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
            dataGridViewAr.DataSource = Arrival.Take(pageSize).ToList();

            // DataGridViewを更新
            dataGridViewAr.Refresh();
            //ページ番号の設定
            textBoxPage.Text = "1";

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
            int pageNo = (int)Math.Ceiling(Arrival.Count / (double)pageSize) - 1;
            dataGridViewAr.DataSource = Arrival.Skip(pageSize * pageNo).Take(pageSize).ToList();

            // DataGridViewを更新
            dataGridViewAr.Refresh();
            //ページ番号の設定
            textBoxPage.Text = (pageNo + 1).ToString();

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
            int lastNo = (int)Math.Ceiling(Arrival.Count / (double)pageSize) - 1;
            //最終ページでなければ
            if (pageNo <= lastNo)
                dataGridViewAr.DataSource = Arrival.Skip(pageSize * pageNo).Take(pageSize).ToList();

            // DataGridViewを更新
            dataGridViewAr.Refresh();
            //ページ番号の設定
            int lastPage = (int)Math.Ceiling(Arrival.Count / (double)pageSize);
            if (pageNo >= lastPage)
                textBoxPage.Text = lastPage.ToString();
            else
                textBoxPage.Text = (pageNo + 1).ToString();

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
            dataGridViewAr.DataSource = Arrival.Skip(pageSize * pageNo).Take(pageSize).ToList();

            // DataGridViewを更新
            dataGridViewAr.Refresh();
            //ページ番号の設定
            if (pageNo + 1 > 1)
                textBoxPage.Text = (pageNo + 1).ToString();
            else
                textBoxPage.Text = "1";

        }
        private void dataGridViewAr_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //データグリッドビューからクリックされたデータを各入力エリアへ
            textBoxArID.Text = dataGridViewAr.Rows[dataGridViewAr.CurrentRow.Index].Cells[0].ToString();
            textBoxOrID.Text = dataGridViewAr.Rows[dataGridViewAr.CurrentRow.Index].Cells[1].ToString();
            textBoxClID.Text = dataGridViewAr.Rows[dataGridViewAr.CurrentRow.Index].Cells[6].ToString();
            textBoxClName.Text = dataGridViewAr.Rows[dataGridViewAr.CurrentRow.Index].Cells[7].ToString();

            //flagの値の「0」「1」をbool型に変換してチェックボックスに表示させる
            if (dataGridViewAr.Rows[dataGridViewAr.CurrentRow.Index].Cells[9].Value.ToString() != 1.ToString())
            {
                checkBoxStateFlag.Checked = false;
            }
            else
            {
                checkBoxStateFlag.Checked = true;
            }
            //flagの値の「0」「2」をbool型に変換してチェックボックスに表示させる
            if (dataGridViewAr.Rows[dataGridViewAr.CurrentRow.Index].Cells[10].Value.ToString() != 2.ToString())
            {
                checkBoxHidden.Checked = false;
            }
            else
            {
                checkBoxHidden.Checked = true;
            }

            //非表示理由がnullではない場合テキストボックスに表示させる
            if (dataGridViewAr.Rows[dataGridViewAr.CurrentRow.Index].Cells[11].Value != null)
            {
                checkBoxHidden.Text = dataGridViewAr.Rows[dataGridViewAr.CurrentRow.Index].Cells[11].Value.ToString();
            }

        }

        ///////////////////////////////
        //メソッド名：ClearInput()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：入力エリアをクリア
        ///////////////////////////////
        private void ClearInput()
        {
            textBoxArID.Text = "";
            textBoxOrID.Text = "";
            textBoxClID.Text = "";
            checkBoxStateFlag.Checked = false;
            checkBoxHidden.Checked = false;
            textBoxArHidden.Text = "";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //日時更新
            labelDay.Text = DateTime.Now.ToString("yyyy/MM/dd/(ddd)");
            labelTime.Text = DateTime.Now.ToString("HH:mm");
        }
        private void buttonFormDel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonDetail_Click(object sender, EventArgs e)
        {
            if (labelArrival.Text == "入荷管理")
            {
                if (!String.IsNullOrEmpty(textBoxArID.Text.Trim()))
                {
                    tArrival.ArID = int.Parse(textBoxArID.Text.Trim());
                    userControlArrivalDetail1.addTArrival(tArrival);
                }

                labelArrival.Text = "入荷詳細管理";
                buttonDetail.Text = "入荷管理";
                userControlArrivalDetail1.Visible = true;
                panelArrival.Visible = false;
                return;
            }
            if (labelArrival.Text == "入荷詳細管理")
            {
                labelArrival.Text = "入荷管理";
                buttonDetail.Text = "入荷詳細";
                panelArrival.Visible = true;
                userControlArrivalDetail1.Visible = false;  
                return;
            }
        }
        //13.1.3 入荷情報確定
        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            // 13.1.3.1 妥当な入荷データ取得
            if (!GetValidDataAtConfirm())
                return;
            // 13.1.3.2　出荷情報作成
            var conShipment = GenerateDataAtConfirm();
            // 13.1.3.3 出荷詳細情報作成
            var conShDetail = GenerateDetailDataAtConfirm();

            // 13.1.3.4 入荷情報確定
            ConfirmArrival(conShipment, conShDetail);

        }
        ///////////////////////////////
        //  13.1.3.1 妥当な入荷データ取得
        //メソッド名：GetValidDataAtConfirm()
        //引　数   ：なし
        //戻り値   ：true or false
        //機　能   ：入力データの形式チェック
        //          ：エラーがない場合True
        //          ：エラーがある場合False
        ///////////////////////////////
        private bool GetValidDataAtConfirm()
        {
            //入荷IDの適否
            if (!String.IsNullOrEmpty(textBoxArID.Text.Trim()))
            {
                //文字チェック
                if (!dataInputFormCheck.CheckNumeric(textBoxArID.Text.Trim()))
                {
                    MessageBox.Show("入荷IDは半角数値入力です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxArID.Focus();
                    return false;
                }
                //文字数
                if (textBoxArID.TextLength > 6)
                {
                    MessageBox.Show("入荷IDは6文字以下です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxArID.Focus();
                    return false;
                }
                // 入荷IDの存在チェック
                if (!arrivalDataAccess.CheckArIDExistence(int.Parse(textBoxArID.Text.Trim())))
                {
                    MessageBox.Show("入力された入荷IDは存在しません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxArID.Focus();
                    return false;
                }

            }
            else
            {
                MessageBox.Show("入荷ID が入力されていません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxArID.Focus();
                return false;
            }
            //入荷確定状態の判定
            var arrival = arrivalDataAccess.GetArIDData(int.Parse(textBoxArID.Text.Trim()));
            if (arrival.ArStateFlag == 1)
            {
                MessageBox.Show("入力された入荷IDはすでに確定されています", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxArID.Focus();
                return false;

            }
            //入荷状態フラグ
            if (checkBoxStateFlag.CheckState == CheckState.Indeterminate)
            {
                MessageBox.Show("入荷確定が不確定な状態です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                checkBoxStateFlag.Focus();
                return false;
            }
            if (checkBoxStateFlag.Checked == false)
            {
                MessageBox.Show("入荷確定がチェックされていません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                checkBoxStateFlag.Focus();
                return false;
            }
            //詳細情報の件数チェック
            var arrivalDetail = arrivalDetailDataAccess.GetArIDDetailData(int.Parse(textBoxArID.Text.Trim()));
            if (arrivalDetail.Count == 0)
            {
                MessageBox.Show("詳細情報が登録されていません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;

            }
            return true;
        }
        ///////////////////////////////
        //　13.1.3.2　入荷情報作成
        //メソッド名：GenerateDataAtConfirm()
        //引　数   ：なし
        //戻り値   ：入荷確定情報
        //機　能   ：確定データのセット
        ///////////////////////////////
        private T_Shipment GenerateDataAtConfirm()
        {
            T_Arrival arrival = arrivalDataAccess.GetArIDData(int.Parse(textBoxArID.Text.Trim()));

            return new T_Shipment
            {

                OrID = int.Parse(arrival.OrID.ToString()),
                EmID = 0,
                SoID = int.Parse(arrival.SoID.ToString()),
                ClID = int.Parse(arrival.ClID.ToString()),
                ShFinishDate=null,
                ShStateFlag = 0,
                ShFlag = 0,
                ShHidden = String.Empty
            };


        }
        ///////////////////////////////
        //　13.1.3.3 入庫詳細情報作成
        //メソッド名：GenerateDetailDataAtConfirm()
        //引　数   ：なし
        //戻り値   ：出荷詳細確定情報
        //機　能   ：確定データのセット
        ///////////////////////////////
        private List<T_ShipmentDetail> GenerateDetailDataAtConfirm()
        {
            List<T_ArrivalDetail> arrivalDetail = arrivalDetailDataAccess.GetArIDDetailData(int.Parse(textBoxArID.Text.Trim()));

            List<T_ShipmentDetail> shipmentDetail = new List<T_ShipmentDetail>();
            foreach (var p in arrivalDetail)
            {
                shipmentDetail.Add(new T_ShipmentDetail()
                {

                    PrID = p.PrID,
                     ShDquantity = p.ArQuantity
                });
            }
            return shipmentDetail;


        }

        ///////////////////////////////
        //　13.1.3.4 入荷情報確定
        //メソッド名：ConfirmSyukko()
        //引　数   ：出荷情報,出荷詳細情報
        //戻り値   ：なし
        //機　能   ：入荷情報の確定
        ///////////////////////////////
        private void ConfirmArrival(T_Shipment conShipment, List<T_ShipmentDetail> conShipmentDetail)
        {
            // 確定確認メッセージ
            DialogResult result = MessageBox.Show("データを確定してよろしいですか?", "確定確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (result == DialogResult.Cancel)
                return;

            // 入荷情報の確定
            //出荷テーブルにデータ登録
            bool addFlg = shipmentDataAccess.AddShipmentData(conShipment);
            //出荷IDの取得
            T_Arrival arrival = arrivalDataAccess.GetArIDData(int.Parse(textBoxArID.Text.Trim()));
            T_Shipment shipment = shipmentDataAccess.GetOrIDData(arrival.OrID);
            //出荷詳細テーブルにデータ登録/
            ///成功か失敗の判定は未完成
            foreach (var p in conShipmentDetail)
            {
                T_ShipmentDetail AddSh = new T_ShipmentDetail();
                AddSh.ShID = shipment.ShID;
                AddSh.PrID = p.PrID;
                AddSh.ShDquantity = p.ShDquantity;
                shipmentDetailDataAccess.AddShipmentDetailData(AddSh);
            }
            //入荷状態フラグの更新
            bool conFlg = arrivalDataAccess.UpdateStateFlag(int.Parse(textBoxArID.Text.Trim()));
            //全ての登録,更新が成功
            if (addFlg == true && conFlg == true)
            {

                MessageBox.Show("データを確定しました", "追加確認", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("データの確定に失敗しました", "追加確認", MessageBoxButtons.OK, MessageBoxIcon.Error);

            textBoxArID.Focus();

            // 入力エリアのクリア
            ClearInput();

            // データグリッドビューの表示
            GetDataGridView();

        }
        //13.1.3 入荷検索機能
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            //13.1.3.1妥当な入荷データ取得
            if (!GetValidDataAtSelect())
                return;

            //13.1.3.2 入荷情報抽出
            GenerateDataAtSelect();

            //13.1.3.3　入荷抽出結果表示
            SetSelectData();

        }
        ///////////////////////////////
        //　13.1.3.1 妥当な入荷データ取得
        //メソッド名：GetValidDataAtSlect()
        //引　数   ：なし
        //戻り値   ：true or false
        //機　能   ：入力データの形式チェック
        //          ：エラーがない場合True
        //          ：エラーがある場合False
        ///////////////////////////////
        private bool GetValidDataAtSelect()
        {
            //入荷IDの適否
            if (!String.IsNullOrEmpty(textBoxArID.Text.Trim()))
            {
                //文字チェック
                if (!dataInputFormCheck.CheckNumeric(textBoxArID.Text.Trim()))
                {
                    MessageBox.Show("入荷IDは半角数値入力です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxArID.Focus();
                    return false;
                }
                //文字数
                if (textBoxArID.TextLength > 6)
                {
                    MessageBox.Show("入荷IDは6文字以下です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxArID.Focus();
                    return false;
                }
                // 入荷IDの存在チェック
                if (!arrivalDataAccess.CheckArIDExistence(int.Parse(textBoxArID.Text.Trim())))
                {
                    MessageBox.Show("入力された入荷IDは存在しません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxArID.Focus();
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
            //入荷日範囲のチェック
            if (dateTimePickerDateStart.Checked == true && dateTimePickerDateEnd.Checked == true)
            {
                if (DateTime.Parse(dateTimePickerDateStart.Text) > DateTime.Parse(dateTimePickerDateEnd.Text))
                {
                    MessageBox.Show("日付の範囲が不正です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dateTimePickerDateStart.Focus();
                    return false;
                }
            }
            else if (dateTimePickerDateStart.Checked == true && dateTimePickerDateEnd.Checked == false ||
                dateTimePickerDateStart.Checked == false && dateTimePickerDateEnd.Checked == true)
            {
                MessageBox.Show("日付の範囲が不正です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dateTimePickerDateStart.Focus();
                return false;
            }
            //入荷状態フラグ
            if (checkBoxStateFlag.CheckState == CheckState.Indeterminate)
            {
                MessageBox.Show("入荷確定が不確定な状態です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                checkBoxStateFlag.Focus();
                return false;
            }

            return true;
        }
        ///////////////////////////////
        //　13.1.2.2 受注情報抽出
        //メソッド名：GenerateDataAtSelect()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：検索データの取得
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
            int hidFlg = 0;
            if (checkBoxHidden.Checked == true)
            {
                hidFlg = 2;
            }
            //入荷確定フラグ変換
            int stateFlg = 0;
            if (checkBoxStateFlag.Checked == true)
            {
                stateFlg = 1;
            }
            //日付範囲が選択されていない
            if (startDay == null && endDay == null)
            {
                //入荷!=null
                if (!String.IsNullOrEmpty(textBoxArID.Text.Trim()))
                {
                    //受注ID!=null
                    if (!String.IsNullOrEmpty(textBoxOrID.Text.Trim()))
                    {
                        //顧客!=null
                        if (!String.IsNullOrEmpty(textBoxClID.Text.Trim()))
                        {
                            T_ArrivalDsp selectCondition = new T_ArrivalDsp()
                            {
                                ArID= int.Parse(textBoxArID.Text.Trim()),
                                OrID = int.Parse(textBoxOrID.Text.Trim()),
                                ClID = int.Parse(textBoxClID.Text.Trim()),
                                ArFlag = hidFlg,
                                ArStateFlag = stateFlg,
                                ArHidden = textBoxArHidden.Text.Trim()
                            };
                            //データの抽出
                            Arrival = arrivalDataAccess.GetArrivalData(1, selectCondition);

                        }
                        else
                        {
                            T_ArrivalDsp selectCondition = new T_ArrivalDsp()
                            {
                                ArID = int.Parse(textBoxArID.Text.Trim()),
                                OrID = int.Parse(textBoxOrID.Text.Trim()),
                                ArFlag = hidFlg,
                                ArStateFlag = stateFlg,
                                ArHidden = textBoxArHidden.Text.Trim()
                            };
                            //データの抽出
                            Arrival = arrivalDataAccess.GetArrivalData(2, selectCondition);

                        }

                    }
                    else
                    {
                        //顧客!=null
                        if (!String.IsNullOrEmpty(textBoxClID.Text.Trim()))
                        {
                            T_ArrivalDsp selectCondition = new T_ArrivalDsp()
                            {
                                ArID = int.Parse(textBoxArID.Text.Trim()),
                                ClID = int.Parse(textBoxClID.Text.Trim()),
                                ArFlag = hidFlg,
                                ArStateFlag = stateFlg,
                                ArHidden = textBoxArHidden.Text.Trim()
                            };
                            //データの抽出
                            Arrival = arrivalDataAccess.GetArrivalData(3, selectCondition);

                        }
                        else
                        {
                            T_ArrivalDsp selectCondition = new T_ArrivalDsp()
                            {
                                ArID = int.Parse(textBoxArID.Text.Trim()),
                                ArFlag = hidFlg,
                                ArStateFlag = stateFlg,
                                ArHidden = textBoxArHidden.Text.Trim()
                            };
                            //データの抽出
                            Arrival = arrivalDataAccess.GetArrivalData(4, selectCondition);

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
                            T_ArrivalDsp selectCondition = new T_ArrivalDsp()
                            {
                                OrID = int.Parse(textBoxOrID.Text.Trim()),
                                ClID = int.Parse(textBoxClID.Text.Trim()),
                                ArFlag = hidFlg,
                                ArStateFlag = stateFlg,
                                ArHidden = textBoxArHidden.Text.Trim()
                            };
                            //データの抽出
                            Arrival = arrivalDataAccess.GetArrivalData(5, selectCondition);

                        }
                        else
                        {
                            T_ArrivalDsp selectCondition = new T_ArrivalDsp()
                            {
                                OrID = int.Parse(textBoxOrID.Text.Trim()),
                                ArFlag = hidFlg,
                                ArStateFlag = stateFlg,
                                ArHidden = textBoxArHidden.Text.Trim()
                            };
                            //データの抽出
                            Arrival = arrivalDataAccess.GetArrivalData(6, selectCondition);

                        }

                    }
                    else
                    {
                        //顧客!=null
                        if (!String.IsNullOrEmpty(textBoxClID.Text.Trim()))
                        {
                            T_ArrivalDsp selectCondition = new T_ArrivalDsp()
                            {
                                ClID = int.Parse(textBoxClID.Text.Trim()),
                                ArFlag = hidFlg,
                                ArStateFlag = stateFlg,
                                ArHidden = textBoxArHidden.Text.Trim()
                            };
                            //データの抽出
                            Arrival = arrivalDataAccess.GetArrivalData(7, selectCondition);

                        }
                        else
                        {
                            T_ArrivalDsp selectCondition = new T_ArrivalDsp()
                            {
                                ArFlag = hidFlg,
                                ArStateFlag = stateFlg,
                                ArHidden = textBoxArHidden.Text.Trim()
                            };
                            //データの抽出
                            Arrival = arrivalDataAccess.GetArrivalData(8, selectCondition);

                        }


                    }

                }
            }
            //日付範囲が選択されている
            else if (startDay != null && endDay != null)
            {
                //入荷!=null
                if (!String.IsNullOrEmpty(textBoxArID.Text.Trim()))
                {
                    //受注ID!=null
                    if (!String.IsNullOrEmpty(textBoxOrID.Text.Trim()))
                    {
                        //顧客!=null
                        if (!String.IsNullOrEmpty(textBoxClID.Text.Trim()))
                        {
                            T_ArrivalDsp selectCondition = new T_ArrivalDsp()
                            {
                                ArID = int.Parse(textBoxArID.Text.Trim()),
                                OrID = int.Parse(textBoxOrID.Text.Trim()),
                                ClID = int.Parse(textBoxClID.Text.Trim()),
                                ArFlag = hidFlg,
                                ArStateFlag = stateFlg,
                                ArHidden = textBoxArHidden.Text.Trim()
                            };
                            //データの抽出
                            Arrival = arrivalDataAccess.GetArrivalDateData(1, selectCondition, startDay, endDay);

                        }
                        else//顧客ID未入力
                        {
                            T_ArrivalDsp selectCondition = new T_ArrivalDsp()
                            {
                                ArID = int.Parse(textBoxArID.Text.Trim()),
                                OrID = int.Parse(textBoxOrID.Text.Trim()),
                                ArFlag = hidFlg,
                                ArStateFlag = stateFlg,
                                ArHidden = textBoxArHidden.Text.Trim()
                            };
                            //データの抽出
                            Arrival = arrivalDataAccess.GetArrivalDateData(2, selectCondition, startDay, endDay);

                        }

                    }
                    else//受注ID未入力
                    {
                        //顧客!=null
                        if (!String.IsNullOrEmpty(textBoxClID.Text.Trim()))
                        {
                            T_ArrivalDsp selectCondition = new T_ArrivalDsp()
                            {
                                ArID = int.Parse(textBoxArID.Text.Trim()),
                                ClID = int.Parse(textBoxClID.Text.Trim()),
                                ArFlag = hidFlg,
                                ArStateFlag = stateFlg,
                                ArHidden = textBoxArHidden.Text.Trim()
                            };
                            //データの抽出
                            Arrival = arrivalDataAccess.GetArrivalDateData(3, selectCondition, startDay, endDay);

                        }
                        else
                        {
                            T_ArrivalDsp selectCondition = new T_ArrivalDsp()
                            {
                                ArID = int.Parse(textBoxArID.Text.Trim()),
                                ArFlag = hidFlg,
                                ArStateFlag = stateFlg,
                                ArHidden = textBoxArHidden.Text.Trim()
                            };
                            //データの抽出
                            Arrival = arrivalDataAccess.GetArrivalDateData(4, selectCondition, startDay, endDay);

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
                            T_ArrivalDsp selectCondition = new T_ArrivalDsp()
                            {
                                OrID = int.Parse(textBoxOrID.Text.Trim()),
                                ClID = int.Parse(textBoxClID.Text.Trim()),
                                ArFlag = hidFlg,
                                ArStateFlag = stateFlg,
                                ArHidden = textBoxArHidden.Text.Trim()
                            };
                            //データの抽出
                            Arrival = arrivalDataAccess.GetArrivalDateData(5, selectCondition, startDay, endDay);

                        }
                        else//顧客ID未入力
                        {
                            T_ArrivalDsp selectCondition = new T_ArrivalDsp()
                            {
                                OrID = int.Parse(textBoxOrID.Text.Trim()),
                                ArFlag = hidFlg,
                                ArStateFlag = stateFlg,
                                ArHidden = textBoxArHidden.Text.Trim()
                            };
                            //データの抽出
                            Arrival = arrivalDataAccess.GetArrivalDateData(6, selectCondition, startDay, endDay);

                        }

                    }
                    else//受注ID未入力
                    {
                        //顧客!=null
                        if (!String.IsNullOrEmpty(textBoxClID.Text.Trim()))
                        {
                            T_ArrivalDsp selectCondition = new T_ArrivalDsp()
                            {
                                ClID = int.Parse(textBoxClID.Text.Trim()),
                                ArFlag = hidFlg,
                                ArStateFlag = stateFlg,
                                ArHidden = textBoxArHidden.Text.Trim()
                            };
                            //データの抽出
                            Arrival = arrivalDataAccess.GetArrivalDateData(7, selectCondition, startDay, endDay);

                        }
                        else//顧客ID未入力
                        {
                            T_ArrivalDsp selectCondition = new T_ArrivalDsp()
                            {
                                ArFlag = hidFlg,
                                ArStateFlag = stateFlg,
                                ArHidden = textBoxArHidden.Text.Trim()
                            };
                            //データの抽出
                            Arrival = arrivalDataAccess.GetArrivalDateData(8, selectCondition, startDay, endDay);

                        }


                    }

                }

            }

        }
        ///////////////////////////////
        //　13.1.3.3 入荷抽出結果表示
        //メソッド名：SetSelectData()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：入荷情報の表示
        ///////////////////////////////
        private void SetSelectData()
        {
            textBoxPage.Text = "1";

            int pageSize = int.Parse(textBoxPageSize.Text);

            dataGridViewAr.DataSource = Arrival;
            if (Arrival.Count == 0)
            {
                MessageBox.Show("該当データが存在しません", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            labelPage.Text = "/" + ((int)Math.Ceiling(Arrival.Count / (double)pageSize)) + "ページ";
            dataGridViewAr.Refresh();

        }


        //13.1.4　入荷非表示機能
        private void buttonHidden_Click(object sender, EventArgs e)
        {
            // 13.1.4.1 妥当な入荷データ取得
            if (!GetValidDataAtHidden())
                return;

            // 13.1.4.2　入荷情報作成
            var hidArrival = GenerateDataAtHidden();

            // 13.1.4.3 入荷情報非表示
            HiddenArrival(hidArrival);

        }
        ///////////////////////////////
        //  13.1.4.1 妥当な入荷データ取得
        //メソッド名：GetValidDataAtHidden()
        //引　数   ：なし
        //戻り値   ：true or false
        //機　能   ：入力データの形式チェック
        //          ：エラーがない場合True
        //          ：エラーがある場合False
        ///////////////////////////////
        private bool GetValidDataAtHidden()
        {
            //入荷IDの適否
            if (!String.IsNullOrEmpty(textBoxArID.Text.Trim()))
            {
                //文字チェック
                if (!dataInputFormCheck.CheckNumeric(textBoxArID.Text.Trim()))
                {
                    MessageBox.Show("入荷IDは半角数値入力です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxArID.Focus();
                    return false;
                }
                //文字数
                if (textBoxArID.TextLength > 6)
                {
                    MessageBox.Show("入荷IDは6文字以下です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxArID.Focus();
                    return false;
                }
                // 入荷IDの存在チェック
                if (!arrivalDataAccess.CheckArIDExistence(int.Parse(textBoxArID.Text.Trim())))
                {
                    MessageBox.Show("入力された入荷IDは存在しません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxArID.Focus();
                    return false;
                }

            }
            else
            {
                MessageBox.Show("入荷ID が入力されていません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxArID.Focus();
                return false;
            }
            //非表示フラグの適否
            if (checkBoxHidden.Checked == false)
            {
                MessageBox.Show("非表示理由が入力されていません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                checkBoxHidden.Checked = true;
                textBoxArHidden.Focus();
                return false;

            }
            //非表示理由の適否
            if (checkBoxHidden.Checked == true && String.IsNullOrEmpty(textBoxArHidden.Text.Trim()))
            {
                MessageBox.Show("非表示理由が入力されていません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxArHidden.Focus();
                return false;
            }

            return true;
        }
        ///////////////////////////////
        //　13.1.4.2 入荷情報作成
        //メソッド名：GenerateDataAtHidden()
        //引　数   ：なし
        //戻り値   ：入荷非表示情報
        //機　能   ：非表示データのセット
        ///////////////////////////////
        private T_Arrival GenerateDataAtHidden()
        {
            int hidFlag = 0;
            if (checkBoxHidden.Checked == true)
            {
                hidFlag = 2;
            }

            return new T_Arrival
            {
                ArID = int.Parse(textBoxArID.Text.Trim()),
                ArFlag = hidFlag,
                ArHidden = textBoxArHidden.Text.Trim()
            };
        }
        ///////////////////////////////
        //　13.1.4.3 入荷情報非表示
        //メソッド名：HiddenArrival()
        //引　数   ：入荷情報
        //戻り値   ：なし
        //機　能   ：入荷情報の非表示
        ///////////////////////////////
        private void HiddenArrival(T_Arrival hidArrival)
        {
            // 非表示確認メッセージ
            DialogResult result = MessageBox.Show("データを非表示にしてよろしいですか?", "非表示確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (result == DialogResult.Cancel)
                return;

            // 入荷情報の非表示(フラグの更新)
            bool flg = arrivalDataAccess.UpdateHiddenFlag(hidArrival);
            if (flg == true)
                MessageBox.Show("データを非表示にしました", "非表示確認", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("データの非表示に失敗しました", "非表示確認", MessageBoxButtons.OK, MessageBoxIcon.Error);

            textBoxArID.Focus();

            // 入力エリアのクリア
            ClearInput();

            // データグリッドビューの表示
            GetDataGridView();
        }
        //13.1.1 一覧表示機能
        private void buttonList_Click(object sender, EventArgs e)
        {
            ClearInput();
            GetDataGridView();
        }
        //13.1.5 非表示リスト機能
        private void buttonHiddenList_Click(object sender, EventArgs e)
        {
            ClearInput();
            GetHiddenDataGridView();
        }
        //入力クリア
        private void buttonClear2_Click(object sender, EventArgs e)
        {
            ClearInput();
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("ログアウトしてよろしいですか？", "ログアウト確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (result == DialogResult.OK)
            {
                //OK時の処理
                FormMain.loginName = "";
                Dispose();
            }
        }
    }
}
