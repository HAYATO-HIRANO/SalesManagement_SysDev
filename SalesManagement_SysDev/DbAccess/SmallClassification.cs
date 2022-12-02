using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesManagement_SysDev//.DbAccess
{
    class SmallClassification
    {
        ///////////////////////////////
        //メソッド名： CheckScIDExistence()
        //引　数   ：小分類ID
        //戻り値   ：True or False
        //機　能   ：一致する小分類コードの有無を確認
        //          ：一致データありの場合True
        //          ：一致データなしの場合False
        ///////////////////////////////

        public bool CheckScIDExistence(int scID)
        {
            bool flg = false;
            try
            {
                var context = new SalesManagement_DevContext();
                flg = context.M_SmallClassifications.Any(x => x.ScID == scID);
                context.Dispose();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
      
            }
            return flg;
        }

        ///////////////////////////////
        //メソッド名： SelectScExistenceCheck()
        //引　数   ：小分類ID、小分類名
        //戻り値   ：True or False
        //機　能   ：部分一致する小分類コード、小分類名の有無を確認
        //          ：部分一致データありの場合True
        //          ：部分一致データなしの場合False
        ///////////////////////////////

        public bool SelectScExistenceCheck(int scID, string scName)
        {
            bool flg = false;
            try
            {
                var context = new SalesManagement_DevContext();
                flg = context.M_SmallClassifications.Any(x=>x.ScID==scID&&x.ScName.Contains(scName));
                context.Dispose();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return flg;
        }




        ///////////////////////////////
        //メソッド名： AddSmallClassData()
        //引　数   ：小分類データ
        //戻り値   ：True or False
        //機　能   ：小分類データの登録
        //          ：登録成功の場合True
        //          ：登録失敗の場合False
        ///////////////////////////////

        public bool AddSmallClassData(M_SmallClassification regSmallClass)
        {
            try
            {
                var context = new SalesManagement_DevContext();
                context.M_SmallClassifications.Add(regSmallClass);
                context.SaveChanges();
                context.Dispose();

                return false;
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

        }

        ///////////////////////////////
        //メソッド名：UpdateSmallClassData()
        //引　数   ：小分類データ
        //戻り値   ：True or False
        //機　能   ：小分類データの更新
        //          ：更新成功の場合True
        //          ：更新失敗の場合False
        ///////////////////////////////

        public bool UpdateSmallClassData(M_SmallClassification updSmallClass)
        {
            try
            {
                var context = new SalesManagement_DevContext();
                var smallClass = context.M_SmallClassifications.Single(x => x.ScID == updSmallClass.ScID);
                smallClass.McID = updSmallClass.McID;
                smallClass.ScName = updSmallClass.ScName;
                smallClass.ScFlag = updSmallClass.ScFlag;
                smallClass.ScHidden = updSmallClass.ScHidden;

                context.SaveChanges();
                context.Dispose();

                return true;

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }



        }


        /////////////////////////////////
        ////メソッド名：CheckCascadeParentSc()
        ////引　数   ：小分類ID
        ////戻り値   ：True or False
        ////機　能   ：小分類IDが商品マスタでの利用可否
        ////          ：利用されているの場合True
        ////          ：利用されていない場合False
        /////////////////////////////////

        public bool CheckCascadeParentSc(int scID)
        {
            var context = new SalesManagement_DevContext();

            bool flg = context.M_SmallClassifications.Any(x => x.ScID == scID);

            return flg;
        }





        ///////////////////////////////
        //メソッド名：GetScData()
        //引　数   ：なし
        //戻り値   ：小分類データ
        //機　能   ：小分類データの取得
        ///////////////////////////////

        public List<M_SmallClassification> GetScData()
        {
            List<M_SmallClassification> smallClass = new List<M_SmallClassification>();
            try
            {
                var context = new SalesManagement_DevContext();
                smallClass = context.M_SmallClassifications.ToList();
                context.Dispose();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK,MessageBoxIcon.Error);

            }
            return smallClass;
        }

        ///////////////////////////////
        //メソッド名：GetScData()　オーバーロードdivision
        //引　数   ：検索条件
        //戻り値   ：条件一致小分類データ
        //機　能   ：条件一致小分類データの取得
        ///////////////////////////////

        public List<M_SmallClassification> GetScData(M_SmallClassification selectCondition)
        {
            List<M_SmallClassification> smallClassification = new List<M_SmallClassification>();
            try
            {
                var context = new SalesManagement_DevContext();
                smallClassification = context.M_SmallClassifications.Where(x => x.McID== selectCondition.McID&&x.ScID==selectCondition.ScID&&x.ScName==selectCondition.ScName).ToList();
                context.Dispose();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return smallClassification;
        }

        ///////////////////////////////
        //メソッド名：GetParentScDspData()
        //引　数   ：なし
        //戻り値   ：表示用商品親カテゴリデータ
        //機　能   ：表示用商品親カテゴリデータの取得
        ///////////////////////////////

        public List<M_SmallClassification> GetParentScDspData(int McID)
        {
            List<M_SmallClassification> smallClassification = new List<M_SmallClassification>();
            try
            {
                var context = new SalesManagement_DevContext();
                smallClassification = context.M_SmallClassifications.Where(x =>x.McID== McID).ToList();
                //var tb = from t1 in context.M_MajorCassifications
                //         join t2 in context.M_SmallClassifications
                //         on t1.McID equals t2.McID
                //         select new
                //         {
                //             t1.McID,
                //             t1.McName,
                //            // t2.ScID,
                //             t2.ScName,

                //                                //FormMain権限分割機能で使用
                //         };
                //foreach (var p in tb)
                //{
                //     smallClassification.Add(new M_SmallClassification()
                //    {
                //        McID = p.McID,
                //       // ScID = p.ScID,
                      
                //    });
                //}
                context.Dispose();
                //this.Close();
              
                //context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return smallClassification;
        }

        ///////////////////////////////
        //メソッド名：GetMcDspData()
        //引　数   ：検索条件
        //戻り値   ：表示用小分類データ
        //機　能   ：表示用小分類データの取得
        ///////////////////////////////


        public List<M_SmallClassification> GetScDspData(int scID)
        {
            List<M_SmallClassification> smallClassification = new List<M_SmallClassification>();
            try
            {
                var context = new SalesManagement_DevContext();
                smallClassification = context.M_SmallClassifications.Where(x => x.ScID == scID && x.ScFlag == 0).ToList();
                context.Dispose();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return smallClassification;
        }
        ///////////////////////////////
        //メソッド名：GetComboboxText()
        //引　数   ：小分類ID
        //戻り値   ：小分類IDからカテゴリ名
        //機　能   ：表示小分類IDからカテゴリ名の取得
        ///////////////////////////////
        public string GetComboboxText(int scID)
        {
            string cmbText = null;
            try
            {
                var context = new SalesManagement_DevContext();
                cmbText = context.M_SmallClassifications.Single(x => x.ScID == scID).ScName;
                context.Dispose();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return cmbText;
        }


    }
}
