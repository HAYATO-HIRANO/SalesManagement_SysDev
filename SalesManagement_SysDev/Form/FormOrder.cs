using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SalesManagement_SysDev
{
    public partial class FormOrder : Form
    {
        //データベース受注テーブルアクセス用クラスのインスタンス化
        OrderDataAccess orderDataAccess = new OrderDataAccess();
        //データベース受注テーブルアクセス用クラスのインスタンス化
        OrderDetailDataAccess orderDetailDataAccess = new OrderDetailDataAccess();
        //データベース注文テーブルアクセス用クラスのインスタンス化
        ChumonDataAccess chumonDataAccess = new ChumonDataAccess();
        //データベース顧客テーブルアクセス用クラスのインスタンス化
        ClientDataAccess clientDataAccess = new ClientDataAccess();
        //データベース社員テーブルアクセス用クラスのインスタンス化
        EmployeeDataAccess employeeDataAccess = new EmployeeDataAccess();

        //入力形式チェック用クラスのインスタンス化
        DataInputFormCheck dataInputFormCheck = new DataInputFormCheck();
        //データグリッドビュー用の受注データ
        private static List<T_OrderDsp> Order;
        public FormOrder()
        {
            InitializeComponent();
        }

        private void FormOrder_Load(object sender, EventArgs e)
        {
            userControlOrderDetail1.Visible = false;
            //日時の表示
            labelDay.Text = DateTime.Now.ToString("yyyy/MM/dd/(ddd)");
            labelTime.Text = DateTime.Now.ToString("HH:mm");
            //panelHeaderに表示するログインデータ
            labelUserName.Text = "ユーザー名：" + FormMain.loginName;
            labelPosition.Text = "権限:" + FormMain.loginPoName;
            labelSalesOffice.Text = FormMain.loginSoName;
            labelUserID.Text = "ユーザーID：" + FormMain.loginEmID.ToString();

            //非表示理由タブ選択不可、入力不可
            textBoxOrHidden.TabStop = false;
            textBoxOrHidden.ReadOnly = true;
            //顧客名選択不可、入力不可
            textBoxClName.TabStop = false;
            textBoxClName.ReadOnly = true;

            //データグリッドビューの設定
            SetFormDataGridView();
        }
        ///////////////受注情報登録////////////////////

        private void buttonRegist_Click(object sender, EventArgs e)
        {
            //8.1.1.1 妥当な受注データ取得
            if (!GetValidDataAtRegistration())
                return;

            //8.1.1.2 受注情報作成
            var regOrder = GenerateDataAtRegistration();

            //8.1.1.3  受注情報登録
            RegistrationOrder(regOrder);

        }
        ///////////////////////////////
        //　8.1.1.1  妥当な受注データ取得
        //メソッド名：GetValidDataAtRegistration()
        //引　数   ：なし
        //戻り値   ：true or false
        //機　能   ：入力データの形式チェック
        //          ：エラーがない場合True
        //          ：エラーがある場合False
        ///////////////////////////////
        private bool GetValidDataAtRegistration()
        {
            //受注IDの適否
            if (!String.IsNullOrEmpty(textBoxOrID.Text.Trim()))
            {
                //受注IDは入力不要です
                MessageBox.Show("受注IDは入力不要です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxOrID.Focus();
                return false;
            }

            ////営業所名の選択チェック
            //if (comboBoxSoID.SelectedIndex == -1)
            //{
            //    //営業所名が選択されていません
            //    MessageBox.Show("営業所名が選択されていません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);

            //    comboBoxSoID.Focus();
            //    return false;
            //}
            ////社員IDの適否
            //if (!String.IsNullOrEmpty(textBoxEmID.Text.Trim()))
            //{
            //    //社員IDの半角数値チェック
            //    if (!dataInputFormCheck.CheckNumeric(textBoxEmID.Text.Trim()))
            //    {
            //        MessageBox.Show("社員IDは半角数値入力です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        textBoxEmID.Focus();
            //        return false;
            //    }
            //    //文字数
            //    if (textBoxEmID.TextLength > 6)
            //    {
            //        MessageBox.Show("社員IDは6文字以下です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        textBoxEmID.Focus();
            //        return false;
            //    }

            //    // 社員IDの存在チェック
            //    if (!employeeDataAccess.CheckEmIDExistence(int.Parse(textBoxEmID.Text.Trim())))
            //    {
            //        MessageBox.Show("入力された社員IDは存在しません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        textBoxEmID.Focus();
            //        return false;
            //    }

            //}
            //else
            //{
            //    MessageBox.Show("社員ID が入力されていません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    textBoxEmID.Focus();
            //    return false;
            //}

            //顧客IDの適否
            if (!String.IsNullOrEmpty(textBoxClID.Text.Trim()))
            {
                //顧客IDの半角数値チェック
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
            else
            {
                MessageBox.Show("顧客ID が入力されていません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxClID.Focus();
                return false;
            }
            //顧客担当者名の適否
            if (!String.IsNullOrEmpty(textBoxClCharge.Text.Trim()))
            {
                if (textBoxClCharge.TextLength > 50)
                {
                    MessageBox.Show("顧客担当者名は50文字以下です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxClCharge.Focus();
                    return false;
                }
            }
            else
            {
                MessageBox.Show("顧客担当者名が入力されていません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxClCharge.Focus();
                return false;

            }
            ////受注日の選択チェック
            //if (DateTimePickerOrDate.Checked == false)
            //{
            //    //受注日が選択されていません
            //    MessageBox.Show("受注日が選択されていません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);

            //   　DateTimePickerOrDate.Focus();
            //    return false;
            //}

            //非表示フラグの適否
            if (checkBoxHidden.CheckState == CheckState.Indeterminate)
            {
                MessageBox.Show("非表示理由が不確定な状態です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                checkBoxHidden.Focus();
                return false;
            }
            if (checkBoxHidden.Checked == true)
            {
                MessageBox.Show("非表示理由は登録できません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                checkBoxHidden.Focus();
                return false;
            }

            ////非表示理由の適否　必要なし
            //if (!String.IsNullOrEmpty(textBoxOrHidden.Text.Trim()))
            //{
            //    MessageBox.Show("非表示理由は登録できません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    textBoxOrHidden.Focus();
            //    return false;
            //}

            //受注状態フラグ
            if (checkBoxStateFlag.CheckState == CheckState.Indeterminate)
            {
                MessageBox.Show("受注確定が不確定な状態です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                checkBoxStateFlag.Focus();
                return false;
            }

            if (checkBoxStateFlag.Checked == true)
            {
                MessageBox.Show("受注確定がチェックされています", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                checkBoxStateFlag.Focus();
                return false;
            }

            return true;
        }
        ///////////////////////////////
        //　8.1.1.2 受注情報作成
        //メソッド名：GenerateDataAtRegistration()
        //引　数   ：なし
        //戻り値   ：受注登録情報
        //機　能   ：登録データのセット
        ///////////////////////////////
        private T_Order GenerateDataAtRegistration()
        {
            //ログインしている社員IDの社員情報を取得する
            M_Employee employee = employeeDataAccess.GetEmIDData(FormMain.loginEmID);

            return new T_Order
            {

                //SoID= int.Parse(comboBoxSoID.SelectedValue.ToString()),
                //EmID =int.Parse(textBoxEmID.Text.Trim()),
                SoID = employee.SoID,
                EmID = employee.EmID,
                ClID = int.Parse(textBoxClID.Text.Trim()),
                ClCharge = textBoxClCharge.Text.Trim(),
                OrDate = DateTime.Now,//現在の時刻
                OrStateFlag = 0,
                OrFlag = 0,
                OrHidden = String.Empty//空文字

            };
        }
        ///////////////////////////////
        //　8.1.1.3 受注情報登録
        //メソッド名：RegistrationOrder()
        //引　数   ：受注情報
        //戻り値   ：なし
        //機　能   ：受注情報の登録
        ///////////////////////////////
        private void RegistrationOrder(T_Order regOrder)
        {
            // 登録確認メッセージ
            DialogResult result = MessageBox.Show("受注データを登録してよろしいですか?", "追加確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Cancel)
                return;
            // 受注情報の登録
            bool flg = orderDataAccess.AddOrderData(regOrder);
            if (flg == true)
            {
                result = MessageBox.Show("データを登録しました、詳細登録画面に移動してよろしいですか?", "追加確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    //入力エリアのクリア
                    ClearInput();

                    //データグリッドビューの表示
                    GetDataGridView();

                    labelOrder.Text = "受注詳細管理";
                    buttonDetail.Text = "受注管理";
                    userControlOrderDetail1.Visible = true;
                    panelOrder.Visible = false;
                    return;
                }

            }
            else
                MessageBox.Show("データの登録に失敗しました", "追加確認", MessageBoxButtons.OK, MessageBoxIcon.Error);

            textBoxOrID.Focus();

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
            dataGridViewOrder.ReadOnly = true;
            //直接のサイズの変更を不可
            dataGridViewOrder.AllowUserToResizeRows = false;
            dataGridViewOrder.AllowUserToResizeColumns = false;
            //直接の登録を不可にする
            dataGridViewOrder.AllowUserToAddRows = false;
            //行内をクリックすることで行を選択
            dataGridViewOrder.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //奇数行の色を変更
            dataGridViewOrder.AlternatingRowsDefaultCellStyle.BackColor = Color.Honeydew;
            //ヘッダー位置の指定
            dataGridViewOrder.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

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
            // 受注データの取得
            Order = orderDataAccess.GetOrderData();

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
            // 受注データの取得
            Order = orderDataAccess.GetOrderHiddenData();

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
            if (!String.IsNullOrEmpty(textBoxPageSize.Text.Trim()))
            {
                if (!dataInputFormCheck.CheckNumeric(textBoxPageSize.Text.Trim()))
                {
                    MessageBox.Show("ページ行数は半角数値のみです", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxPageSize.Focus();
                    return;
                }
                if (int.Parse(textBoxPageSize.Text) <= 0)
                {
                    MessageBox.Show("ページ行数は1以上です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxPageSize.Focus();
                    return;

                }
            }
            else
            {
                MessageBox.Show("ページ行数が入力されていません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxPageSize.Focus();
                return;

            }

            int pageSize = int.Parse(textBoxPageSize.Text);
            int pageNo = int.Parse(textBoxPage.Text) - 1;
            dataGridViewOrder.DataSource = Order.Skip(pageSize * pageNo).Take(pageSize).ToList();
            //各列幅の指定 //1510
            dataGridViewOrder.Columns[0].Width = 100;
            dataGridViewOrder.Columns[1].Visible = false;
            dataGridViewOrder.Columns[2].Width = 200;
            dataGridViewOrder.Columns[3].Width = 100;
            dataGridViewOrder.Columns[4].Width = 200;
            dataGridViewOrder.Columns[5].Width = 100;
            dataGridViewOrder.Columns[6].Width = 200;
            dataGridViewOrder.Columns[7].Width = 175;
            dataGridViewOrder.Columns[8].Width = 200;
            dataGridViewOrder.Columns[9].Visible = false;
            dataGridViewOrder.Columns[10].Visible = false;
            dataGridViewOrder.Columns[11].Width = 250;

            //各列の文字位置の指定
            dataGridViewOrder.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewOrder.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewOrder.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewOrder.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewOrder.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewOrder.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewOrder.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewOrder.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewOrder.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            //dataGridViewの総ページ数
            labelPage.Text = "/" + ((int)Math.Ceiling(Order.Count / (double)pageSize)) + "ページ";

            dataGridViewOrder.Refresh();
        }
        //////受注情報確定////////
        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            // 8.1.4.1 妥当な受注データ取得
            if (!GetValidDataAtConfirm())
                return;
            // 8.1.4.2　受注情報作成
            var conChumon = GenerateDataAtConfirm();
            //8.1.4.3 受注詳細情報作成
            var conChumonDetail = GenerateDetailDataAtConfirm();

            // 8.1.4.4 受注情報確定
            ConfirmOrder(conChumon, conChumonDetail);

        }

        ///////////////////////////////
        //  8.1.4.1 妥当な受注データ取得
        //メソッド名：GetValidDataAtConfirm()
        //引　数   ：なし
        //戻り値   ：true or false
        //機　能   ：入力データの形式チェック
        //          ：エラーがない場合True
        //          ：エラーがある場合False
        ///////////////////////////////
        private bool GetValidDataAtConfirm()
        {
            //受注IDの適否
            if (!String.IsNullOrEmpty(textBoxOrID.Text.Trim()))
            {
                //受注IDの半角数値チェック
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

                // 受注IDの存在チェック
                if (!orderDataAccess.CheckOrIDExistence(int.Parse(textBoxOrID.Text.Trim())))
                {
                    MessageBox.Show("入力された受注IDは存在しません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxOrID.Focus();
                    return false;
                }

            }
            else
            {
                MessageBox.Show("受注ID が入力されていません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxOrID.Focus();
                return false;
            }
            //受注確定状態の判定
            var order = orderDataAccess.GetOrIDData(int.Parse(textBoxOrID.Text.Trim()));
            if (order.OrStateFlag == 1)
            {
                MessageBox.Show("入力された受注IDはすでに確定されています", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxOrID.Focus();
                return false;

            }
            //受注状態フラグ
            if (checkBoxStateFlag.CheckState == CheckState.Indeterminate)
            {
                MessageBox.Show("受注確定が不確定な状態です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                checkBoxStateFlag.Focus();
                return false;
            }
            if (checkBoxStateFlag.Checked == false)
            {
                MessageBox.Show("受注確定がチェックされていません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                checkBoxStateFlag.Focus();
                return false;
            }
            //詳細情報の件数チェック
            var orderDetail = orderDetailDataAccess.GetOrIDDetailData(int.Parse(textBoxOrID.Text.Trim()));
            if (orderDetail.Count == 0)
            {
                MessageBox.Show("詳細情報が登録されていません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;

            }

            return true;
        }
        ///////////////////////////////
        //　8.1.4.2 注文情報作成
        //メソッド名：GenerateDataAtConfirm()
        //引　数   ：なし
        //戻り値   ：受注確定情報
        //機　能   ：確定データのセット
        ///////////////////////////////
        private T_Chumon GenerateDataAtConfirm()
        {
            T_Order order = orderDataAccess.GetOrIDData(int.Parse(textBoxOrID.Text.Trim()));

            return new T_Chumon
            {
                OrID = int.Parse(order.OrID.ToString()),
                EmID = 0,
                SoID = int.Parse(order.SoID.ToString()),
                ClID = int.Parse(order.ClID.ToString()),
                ChDate = DateTime.Now,
                ChStateFlag = 0,
                ChFlag = 0,
                ChHidden = String.Empty
            };


        }
        ///////////////////////////////
        //　8.1.4.3 受注情報作成
        //メソッド名：GenerateDetailDataAtConfirm()
        //引　数   ：なし
        //戻り値   ：受注詳細確定情報
        //機　能   ：確定データのセット
        ///////////////////////////////
        private List<T_ChumonDetail> GenerateDetailDataAtConfirm()
        {
            List<T_OrderDetail> orderDetail = orderDetailDataAccess.GetOrIDDetailData(int.Parse(textBoxOrID.Text.Trim()));

            List<T_ChumonDetail> chumonDetail = new List<T_ChumonDetail>();
            foreach (var p in orderDetail)
            {
                chumonDetail.Add(new T_ChumonDetail()
                {
                    PrID = p.PrID,
                    ChQuantity = p.OrQuantity
                });
            }
            return chumonDetail;


        }

        ///////////////////////////////
        //　8.1.4.4 受注情報確定
        //メソッド名：ConfirmOrder()
        //引　数   ：注文情報,注文詳細情報
        //戻り値   ：なし
        //機　能   ：受注情報の確定
        ///////////////////////////////
        private void ConfirmOrder(T_Chumon conChumon, List<T_ChumonDetail> conChumonDetail)
        {
            // 確定確認メッセージ
            DialogResult result = MessageBox.Show("データを確定してよろしいですか?", "追加確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (result == DialogResult.Cancel)
                return;

            // 受注情報の確定
            //注文テーブルにデータ登録
            bool addFlg = chumonDataAccess.AddChumonData(conChumon);
            //注文IDの取得
            T_Chumon chumon = chumonDataAccess.GetOrIDData(int.Parse(textBoxOrID.Text.Trim()));
            //注文詳細テーブルにデータ登録/
            ///成功か失敗の判定は未完成
            foreach (var p in conChumonDetail)
            {
                T_ChumonDetail AddCh = new T_ChumonDetail();
                AddCh.ChID = chumon.ChID;
                AddCh.PrID = p.PrID;
                AddCh.ChQuantity = p.ChQuantity;
                chumonDataAccess.AddChDetailData(AddCh);
            }
            //受注状態フラグの更新
            bool conFlg = orderDataAccess.UpdateStateFlag(int.Parse(textBoxOrID.Text.Trim()));
            //全ての登録,更新が成功
            if (addFlg == true && conFlg == true)
            {

                MessageBox.Show("データを確定しました", "追加確認", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("データの確定に失敗しました", "追加確認", MessageBoxButtons.OK, MessageBoxIcon.Error);

            textBoxOrID.Focus();

            // 入力エリアのクリア
            ClearInput();

            // データグリッドビューの表示
            GetDataGridView();

        }

        //////受注情報検索///////
        private void buttonSearch_Click(object sender, EventArgs e)
        {

            //8.5.1.1妥当な受注データ取得
            if (!GetValidDataAtSelect())
                return;

            //8.5.1.2 受注情報抽出
            GenerateDataAtSelect();

            //8.5.1.3  受注抽出結果表示
            SetSelectData();

        }
        ///////////////////////////////
        //　8.5.1.1 妥当な受注データ取得
        //メソッド名：GetValidDataAtSlect()
        //引　数   ：なし
        //戻り値   ：true or false
        //機　能   ：入力データの形式チェック
        //          ：エラーがない場合True
        //          ：エラーがある場合False
        ///////////////////////////////
        private bool GetValidDataAtSelect()
        {
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
                // 受注IDの存在チェック
                if (!orderDataAccess.CheckOrIDExistence(int.Parse(textBoxOrID.Text.Trim())))
                {
                    MessageBox.Show("入力された受注IDは存在しません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            //顧客担当名の適否
            if (!String.IsNullOrEmpty(textBoxClCharge.Text.Trim()))
            {
                if (textBoxClCharge.TextLength > 50)
                {
                    //顧客担当名は50文字以下です
                    MessageBox.Show("顧客担当名は50文字以下です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxClCharge.Focus();
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
            //受注日範囲のチェック
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
            //受注状態フラグ
            if (checkBoxStateFlag.CheckState == CheckState.Indeterminate)
            {
                MessageBox.Show("受注確定が不確定な状態です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                checkBoxStateFlag.Focus();
                return false;
            }

            return true;
        }
        ///////////////////////////////
        //　8.5.1.2 受注情報抽出
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
            int orFlg = 0;
            if (checkBoxHidden.Checked == true)
            {
                orFlg = 2;
            }
            //受注確定フラグ変換
            int stateFlg = 0;
            if (checkBoxStateFlag.Checked == true)
            {
                stateFlg = 1;
            }

            //// コンボボックスが未選択の場合Emptyを設定
            //string cSalesOffice = "";
            //if (comboBoxSoID.SelectedIndex != -1)
            //    cSalesOffice = comboBoxSoID.SelectedValue.ToString();

            //日付範囲が選択されていない
            if (startDay == null && endDay == null)
            {
                if (!String.IsNullOrEmpty(textBoxOrID.Text.Trim()))
                {
                    if (!String.IsNullOrEmpty(textBoxClID.Text.Trim()))
                    {
                        T_OrderDsp selectCondition = new T_OrderDsp()
                        {
                            OrID = int.Parse(textBoxOrID.Text.Trim()),
                            ClID = int.Parse(textBoxClID.Text.Trim()),
                            ClCharge = textBoxClCharge.Text.Trim(),
                            OrFlag = orFlg,
                            OrStateFlag = stateFlg,
                            OrHidden = textBoxOrHidden.Text.Trim()
                        };
                        //データの抽出
                        Order = orderDataAccess.GetOrderData(1, selectCondition);

                    }
                    else
                    {
                        T_OrderDsp selectCondition = new T_OrderDsp()
                        {
                            OrID = int.Parse(textBoxOrID.Text.Trim()),
                            ClCharge = textBoxClCharge.Text.Trim(),
                            OrFlag = orFlg,
                            OrStateFlag = stateFlg,
                            OrHidden = textBoxOrHidden.Text.Trim()
                        };
                        //データの抽出
                        Order = orderDataAccess.GetOrderData(2, selectCondition);

                    }

                }
                else
                {
                    if (!String.IsNullOrEmpty(textBoxClID.Text.Trim()))
                    {
                        T_OrderDsp selectCondition = new T_OrderDsp()
                        {
                            ClID = int.Parse(textBoxClID.Text.Trim()),
                            ClCharge = textBoxClCharge.Text.Trim(),
                            OrFlag = orFlg,
                            OrStateFlag = stateFlg,
                            OrHidden = textBoxOrHidden.Text.Trim()
                        };
                        //データの抽出
                        Order = orderDataAccess.GetOrderData(3, selectCondition);

                    }
                    else
                    {
                        T_OrderDsp selectCondition = new T_OrderDsp()
                        {
                            ClCharge = textBoxClCharge.Text.Trim(),
                            OrFlag = orFlg,
                            OrStateFlag = stateFlg,
                            OrHidden = textBoxOrHidden.Text.Trim()
                        };
                        //データの抽出
                        Order = orderDataAccess.GetOrderData(4, selectCondition);

                    }


                }
            }
            //日付範囲が選択されている
            else if (startDay != null && endDay != null)
            {
                if (!String.IsNullOrEmpty(textBoxOrID.Text.Trim()))
                {
                    if (!String.IsNullOrEmpty(textBoxClID.Text.Trim()))
                    {
                        T_OrderDsp selectCondition = new T_OrderDsp()
                        {
                            OrID = int.Parse(textBoxOrID.Text.Trim()),
                            ClID = int.Parse(textBoxClID.Text.Trim()),
                            ClCharge = textBoxClCharge.Text.Trim(),
                            OrFlag = orFlg,
                            OrStateFlag = stateFlg,
                            OrHidden = textBoxOrHidden.Text.Trim()
                        };
                        //データの抽出
                        Order = orderDataAccess.GetOrderDateData(1, selectCondition, startDay, endDay);

                    }
                    else
                    {
                        T_OrderDsp selectCondition = new T_OrderDsp()
                        {
                            OrID = int.Parse(textBoxOrID.Text.Trim()),
                            ClCharge = textBoxClCharge.Text.Trim(),
                            OrFlag = orFlg,
                            OrStateFlag = stateFlg,
                            OrHidden = textBoxOrHidden.Text.Trim()
                        };
                        //データの抽出
                        Order = orderDataAccess.GetOrderDateData(2, selectCondition, startDay, endDay);

                    }

                }
                else
                {
                    if (!String.IsNullOrEmpty(textBoxClID.Text.Trim()))
                    {
                        T_OrderDsp selectCondition = new T_OrderDsp()
                        {
                            ClID = int.Parse(textBoxClID.Text.Trim()),
                            ClCharge = textBoxClCharge.Text.Trim(),
                            OrFlag = orFlg,
                            OrStateFlag = stateFlg,
                            OrHidden = textBoxOrHidden.Text.Trim()
                        };
                        //データの抽出
                        Order = orderDataAccess.GetOrderDateData(3, selectCondition, startDay, endDay);

                    }
                    else
                    {
                        T_OrderDsp selectCondition = new T_OrderDsp()
                        {
                            ClCharge = textBoxClCharge.Text.Trim(),
                            OrFlag = orFlg,
                            OrStateFlag = stateFlg,
                            OrHidden = textBoxOrHidden.Text.Trim()
                        };
                        //データの抽出
                        Order = orderDataAccess.GetOrderDateData(4, selectCondition, startDay, endDay);

                    }


                }

            }



        }
        ///////////////////////////////
        //　8.5.1.3 受注抽出結果表示
        //メソッド名：SetSelectData()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：受注情報の表示
        ///////////////////////////////
        private void SetSelectData()
        {
            textBoxPage.Text = "1";

            int pageSize = int.Parse(textBoxPageSize.Text);

            dataGridViewOrder.DataSource = Order;
            if (Order.Count == 0)
            {
                MessageBox.Show("該当データが存在しません", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            labelPage.Text = "/" + ((int)Math.Ceiling(Order.Count / (double)pageSize)) + "ページ";
            dataGridViewOrder.Refresh();

        }

        private void buttonSaisyou_Click(object sender, EventArgs e)
        {

        }

        private void buttonFormDel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            FormLogin formLogin = new FormLogin();
            FormMain formMain = new FormMain();
            formLogin.Show();
            this.Visible = false;
            formMain.Close();
        }



        private void buttonDetail_Click(object sender, EventArgs e)
        {
            if (labelOrder.Text == "受注管理")
            {
                labelOrder.Text = "受注詳細管理";
                buttonDetail.Text = "受注管理";
                userControlOrderDetail1.Visible = true;
                panelOrder.Visible = false;
                return;
            }
            if (labelOrder.Text == "受注詳細管理")
            {
                labelOrder.Text = "受注管理";
                buttonDetail.Text = "受注詳細";
                panelOrder.Visible = true;
                userControlOrderDetail1.Visible = false;
            }



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
        //メソッド名：buttonLastPage_Click()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：データグリッドビューの最終ページ表示
        ///////////////////////////////

        private void buttonLastPage_Click(object sender, EventArgs e)
        {
            int pageSize = int.Parse(textBoxPageSize.Text);
            //最終ページの計算
            int pageNo = (int)Math.Ceiling(Order.Count / (double)pageSize) - 1;
            dataGridViewOrder.DataSource = Order.Skip(pageSize * pageNo).Take(pageSize).ToList();

            // DataGridViewを更新
            dataGridViewOrder.Refresh();
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
            int pageSize = int.Parse(textBoxPageSize.Text);
            int pageNo = int.Parse(textBoxPage.Text);
            //最終ページの計算
            int lastNo = (int)Math.Ceiling(Order.Count / (double)pageSize) - 1;
            //最終ページでなければ
            if (pageNo <= lastNo)
                dataGridViewOrder.DataSource = Order.Skip(pageSize * pageNo).Take(pageSize).ToList();

            // DataGridViewを更新
            dataGridViewOrder.Refresh();
            //ページ番号の設定
            int lastPage = (int)Math.Ceiling(Order.Count / (double)pageSize);
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
            int pageSize = int.Parse(textBoxPageSize.Text);
            int pageNo = int.Parse(textBoxPage.Text) - 2;
            dataGridViewOrder.DataSource = Order.Skip(pageSize * pageNo).Take(pageSize).ToList();

            // DataGridViewを更新
            dataGridViewOrder.Refresh();
            //ページ番号の設定
            if (pageNo + 1 > 1)
                textBoxPage.Text = (pageNo + 1).ToString();
            else
                textBoxPage.Text = "1";

        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            //日時更新
            labelDay.Text = DateTime.Now.ToString("yyyy/MM/dd/(ddd)");
            labelTime.Text = DateTime.Now.ToString("HH:mm");
        }

        //////////非表示機能///////////
        private void buttonHidden_Click(object sender, EventArgs e)
        {
            // 8.1.2.1 妥当な受注データ取得
            if (!GetValidDataAtHidden())
                return;

            // 8.1.2.2　受注情報作成
            var hidOrder = GenerateDataAtHidden();

            // 8.1.2.3 受注情報非表示
            HiddenOrder(hidOrder);

        }
        ///////////////////////////////
        //  8.1.2.1 妥当な受注データ取得
        //メソッド名：GetValidDataAtHidden()
        //引　数   ：なし
        //戻り値   ：true or false
        //機　能   ：入力データの形式チェック
        //          ：エラーがない場合True
        //          ：エラーがある場合False
        ///////////////////////////////
        private bool GetValidDataAtHidden()
        {
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
                // 受注IDの存在チェック
                if (!orderDataAccess.CheckOrIDExistence(int.Parse(textBoxOrID.Text.Trim())))
                {
                    MessageBox.Show("入力された受注IDは存在しません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxOrID.Focus();
                    return false;
                }

            }
            else
            {
                MessageBox.Show("受注ID が入力されていません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxOrID.Focus();
                return false;
            }
            //非表示フラグの適否
            if (checkBoxHidden.Checked == false)
            {
                MessageBox.Show("非表示理由が入力されていません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                checkBoxHidden.Checked = true;
                textBoxOrHidden.Focus();
                return false;

            }
            //非表示理由の適否
            if (checkBoxHidden.Checked == true && String.IsNullOrEmpty(textBoxOrHidden.Text.Trim()))
            {
                MessageBox.Show("非表示理由が入力されていません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxOrHidden.Focus();
                return false;
            }

            return true;
        }
        ///////////////////////////////
        //　8.1.2.2 受注情報作成
        //メソッド名：GenerateDataAtHidden()
        //引　数   ：なし
        //戻り値   ：受注非表示情報
        //機　能   ：非表示データのセット
        ///////////////////////////////
        private T_Order GenerateDataAtHidden()
        {
            int hidFlag = 0;
            if (checkBoxHidden.Checked == true)
            {
                hidFlag = 2;
            }

            return new T_Order
            {
                OrID = int.Parse(textBoxOrID.Text.Trim()),
                OrFlag = hidFlag,
                OrHidden = textBoxOrHidden.Text.Trim()
            };
        }
        ///////////////////////////////
        //　8.1.2.3 受注情報非表示
        //メソッド名：HiddenOrder()
        //引　数   ：受注情報
        //戻り値   ：なし
        //機　能   ：受注情報の非表示
        ///////////////////////////////
        private void HiddenOrder(T_Order hidOrder)
        {
            // 非表示確認メッセージ
            DialogResult result = MessageBox.Show("データを非表示にしてよろしいですか?", "非表示確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (result == DialogResult.Cancel)
                return;

            // 受注情報の非表示(フラグの更新)
            bool flg = orderDataAccess.UpdateHiddenFlag(hidOrder);
            if (flg == true)
                MessageBox.Show("データを非表示にしました", "非表示確認", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("データの非表示に失敗しました", "非表示確認", MessageBoxButtons.OK, MessageBoxIcon.Error);

            textBoxOrID.Focus();

            // 入力エリアのクリア
            ClearInput();

            // データグリッドビューの表示
            GetDataGridView();
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
            dataGridViewOrder.DataSource = Order.Take(pageSize).ToList();

            // DataGridViewを更新
            dataGridViewOrder.Refresh();
            //ページ番号の設定
            textBoxPage.Text = "1";

        }
        ///////////////////////////////
        //メソッド名：ClearInput()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：入力エリアをクリア
        ///////////////////////////////
        private void ClearInput()
        {
            textBoxOrID.Text = "";
            textBoxClID.Text = "";
            textBoxClCharge.Text = "";
            checkBoxStateFlag.Checked = false;
            checkBoxHidden.Checked = false;
            textBoxOrHidden.Text = "";
        }

        //////入力クリア///////
        private void buttonClear2_Click(object sender, EventArgs e)
        {
            ClearInput();
        }
        //////8.1.3.1 一覧表示//////
        private void buttonList_Click(object sender, EventArgs e)
        {
            ClearInput();
            GetDataGridView();
        }
        /////8.1.6.1 非表示リスト//////
        private void buttonHiddenList_Click(object sender, EventArgs e)
        {
            ClearInput();
            GetHiddenDataGridView();
        }
        //非表示フラグが変わった時
        private void checkBoxHidden_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxHidden.Checked == true)
            {
                textBoxOrHidden.TabStop = true;
                textBoxOrHidden.ReadOnly = false;
            }
            else
            {
                textBoxOrHidden.Text = "";
                textBoxOrHidden.TabStop = false;
                textBoxOrHidden.ReadOnly = true;

            }
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

        private void dataGridViewOrder_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //データグリッドビューからクリックされたデータを各入力エリアへ
            textBoxOrID.Text = dataGridViewOrder.Rows[dataGridViewOrder.CurrentRow.Index].Cells[0].Value.ToString();
            textBoxClID.Text = dataGridViewOrder.Rows[dataGridViewOrder.CurrentRow.Index].Cells[5].Value.ToString();
            textBoxClName.Text = dataGridViewOrder.Rows[dataGridViewOrder.CurrentRow.Index].Cells[6].Value.ToString();
            textBoxClCharge.Text = dataGridViewOrder.Rows[dataGridViewOrder.CurrentRow.Index].Cells[7].Value.ToString();
            //flagの値の「0」「1」をbool型に変換してチェックボックスに表示させる

            if (dataGridViewOrder.Rows[dataGridViewOrder.CurrentRow.Index].Cells[9].Value.ToString() != 1.ToString())
            {
                checkBoxStateFlag.Checked = false;
            }
            else
            {
                checkBoxStateFlag.Checked = true;
            }
            //flagの値の「0」「2」をbool型に変換してチェックボックスに表示させる
            if (dataGridViewOrder.Rows[dataGridViewOrder.CurrentRow.Index].Cells[10].Value.ToString() != 2.ToString())
            {
                checkBoxHidden.Checked = false;
            }
            else
            {
                checkBoxHidden.Checked = true;
            }
            //非表示理由がnullではない場合テキストボックスに表示させる
            if (dataGridViewOrder.Rows[dataGridViewOrder.CurrentRow.Index].Cells[11].Value != null)
            {
                textBoxOrHidden.Text = dataGridViewOrder.Rows[dataGridViewOrder.CurrentRow.Index].Cells[11].Value.ToString();
            }

        }

        private void panelHeader_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
