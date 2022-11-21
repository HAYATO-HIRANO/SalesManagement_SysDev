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
            //SetFormDataGridView();

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

        }

        ///////////////////////////////
        //メソッド名：SetFormDataGridView()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：データグリッドビューの設定 
        ///////////////////////////////
        private void SetFormDataGridView()
        {

        }
        ///////////////////////////////
        //メソッド名：GetDataGridView()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：データグリッドビューに表示するデータの取得
        ///////////////////////////////
        private void GetDataGridView()
        {

        }
        ///////////////////////////////
        //メソッド名：GetHiddenDataGridView()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：データグリッドビューに表示する非表示データの取得
        ///////////////////////////////
        private void GetHiddenDataGridView()
        {

        }
        ///////////////////////////////
        //メソッド名：SetDataGridView()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：データグリッドビューへの表示
        ///////////////////////////////
        private void SetDataGridView()
        {

        }
        ///////////////////////////////
        //メソッド名：buttonPageSizeChange_Click()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：データグリッドビューの表示件数変更
        ///////////////////////////////

        private void buttonPageSizeChange_Click(object sender, EventArgs e)
        {

        }
        ///////////////////////////////
        //メソッド名：buttonFirstPage_Click()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：データグリッドビューの先頭ページ表示
        ///////////////////////////////

        private void buttonFirstPage_Click(object sender, EventArgs e)
        {

        }
        ///////////////////////////////
        //メソッド名：buttonPreviousPage_Click()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：データグリッドビューの前ページ表示
        ///////////////////////////////
        private void buttonPreviousPage_Click(object sender, EventArgs e)
        {

        }
        ///////////////////////////////
        //メソッド名：buttonNextPage_Click()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：データグリッドビューの次ページ表示
        ///////////////////////////////
        private void buttonNextPage_Click(object sender, EventArgs e)
        {

        }
        ///////////////////////////////
        //メソッド名：buttonLastPage_Click()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：データグリッドビューの最終ページ表示
        ///////////////////////////////

        private void buttonLastPage_Click(object sender, EventArgs e)
        {

        }
        ///////////////////////////////
        //メソッド名：ClearInput()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：入力エリアをクリア
        ///////////////////////////////
        private void ClearInput()
        {

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
            return new M_Maker
            {

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

        }

    }
}
