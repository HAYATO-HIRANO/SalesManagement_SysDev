using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesManagement_SysDev//.DbAccess
{
    class MajorClassificationDataAccess
    {
        ///////////////////////////////
        //メソッド名：CheckMcIDExistence()
        //引　数   ：大分類ID
        //戻り値   ：True or False
        //機　能   ：一致する大分類IDの有無を確認
        //          ：一致データありの場合True
        //          ：一致データなしの場合False
        ///////////////////////////////
        public bool CheckMcIDExistence(int McID)
        {
            bool flg = false;
            try
            {
                var context = new SalesManagement_DevContext();
                flg = context.M_MajorCassifications.Any(x => x.McID == McID);
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return flg;
        }

        ///////////////////////////////
        //メソッド名：SelectMcExistenceCheck()
        //引　数   ：大分類IDと大分類名
        //戻り値   ：True or False
        //機　能   ：一致する大分類IDの有無を確認
        //          ：一致データありの場合True
        //          ：一致データなしの場合False
        ///////////////////////////////
        public bool SelectMcExistenceCheck(int mcID,string mcName)
        {
            bool flg = false;
            try
            {
                var context = new SalesManagement_DevContext();
                flg = context.M_MajorCassifications.Any(x => x.McID == mcID && x.McName.Contains(mcName));
                context.Dispose();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return flg;
        }


        ///////////////////////////////
        //メソッド名：AddMcData()
        //引　数   ：大分類データ
        //戻り値   ：True or False
        //機　能   ：一致する大分類IDの登録
        //          ：登録成功の場合True
        //          ：登録失敗の場合False
        ///////////////////////////////
        public bool AddMcData(M_MajorCassification regMajorCassification)
        {
            try
            {
                var context = new SalesManagement_DevContext();
                context.M_MajorCassifications.Add(regMajorCassification);
                context.SaveChanges();
                context.Dispose();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }


        ///////////////////////////////
        //メソッド名：UpdateMcData()
        //引　数   ：大分類データ
        //戻り値   ：True or False
        //機　能   ：一致する大分類IDの更新
        //          ：更新成功の場合True
        //          ：更新失敗の場合False
        ///////////////////////////////
        public bool UpdateMcData(M_MajorCassification updMajorCassification)
        {
            try
            {
                var context = new SalesManagement_DevContext();
                var MajorCassification = context.M_MajorCassifications.Single(x => x.McID == updMajorCassification.McID);
                MajorCassification.McName = updMajorCassification.McName;
                MajorCassification.McFlag = updMajorCassification.McFlag;
                MajorCassification.McHidden = updMajorCassification.McHidden;

                context.SaveChanges();
                context.Dispose();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        ///////////////////////////////
        //メソッド名：GetMcData()
        //引　数   ：なし
        //戻り値   ：大分類データ
        //機　能   ：大分類データの取得
        ///////////////////////////////
        public List<M_MajorCassification> GetMcData()
        {
            List<M_MajorCassification> majorCassifications = new List<M_MajorCassification>();

            try
            {
                var context = new SalesManagement_DevContext();
                majorCassifications = context.M_MajorCassifications.ToList();
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return majorCassifications;
        }
        ///////////////////////////////
        //メソッド名：GetMcData()　オーバーロード
        //引　数   ：検索条件
        //戻り値   ：表示大分類用データ
        //機　能   ：表示大分類データの取得
        ///////////////////////////////
        public List<M_MajorCassification> GetMcData(M_MajorCassification selectCondition)
        {
            List<M_MajorCassification> majorCassifications = new List<M_MajorCassification>();
            try
            {
                var context = new SalesManagement_DevContext();
                majorCassifications = context.M_MajorCassifications.Where(x => x.McID == selectCondition.McID&&x.McName==selectCondition.McName&&
                x.McFlag == 0).ToList();
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return majorCassifications;
        }

        ///////////////////////////////
        //メソッド名：GetMcDspData()
        //引　数   ：検索条件
        //戻り値   ：表示用大分類データ
        //機　能   ：表示用大分類データの取得
        ///////////////////////////////

        public List<M_MajorCassification> GetMcDspData()
        {
            List<M_MajorCassification> majorCassifications = new List<M_MajorCassification>();
            try
            {
                var context = new SalesManagement_DevContext();
                majorCassifications = context.M_MajorCassifications.Where(x =>  x.McFlag == 0).ToList();
                context.Dispose();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return majorCassifications;
        }

        ///////////////////////////////
        //メソッド名：GetComboboxText()
        //引　数   ：大分類ID
        //戻り値   ：大分類IDからカテゴリ名
        //機　能   ：表示大分類IDからカテゴリ名の取得
        ///////////////////////////////
        public bool GetComboboxText(int McID)
        {
            var context = new SalesManagement_DevContext();
            bool flg = context.M_MajorCassifications.Any(x => x.McID == McID);

            return flg;
        }
        ///////////////////////////////
        //メソッド名：GetMcHiddenData()
        //引　数   ：なし
        //戻り値   ：大分類データ
        //機　能   ：大分類非表示データの取得
        ///////////////////////////////
        public List<M_MajorCassification> GetMcHiddenData()
        {
            List<M_MajorCassification> majorCassifications = new List<M_MajorCassification>();

            try
            {
                var context = new SalesManagement_DevContext();
                majorCassifications = context.M_MajorCassifications.Where(x => x.McFlag == 2).ToList();

                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return majorCassifications;
        }


    }


}

　