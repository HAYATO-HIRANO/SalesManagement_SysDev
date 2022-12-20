using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesManagement_SysDev//.DbAccess
{
    class ProductDataAccess
    {
        ///////////////////////////////
        //メソッド名：CheckPrIDExistence()
        //引　数   ：商品ID
        //戻り値   ：True or False
        //機　能   ：一致する商品IDの有無を確認
        //          ：一致データありの場合True
        //          ：一致データなしの場合False
        ///////////////////////////////
        public bool CheckPrIDExistence(int prID )
        {
            bool flg = false;
            try
            {
                var context = new SalesManagement_DevContext();
                flg = context.M_Products.Any(x => x.PrID==prID);
                context.Dispose();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return flg;
        }

        //public bool CheckPrModelNumberExistence( string prMB)
        //{
        //    bool flg = false;
        //    try
        //    {
        //        var context = new SalesManagement_DevContext();
        //        flg = context.M_Products.Any(x => x.PrModelNumber == prMB); 
        //        context.Dispose();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);

        //    }
        //    return flg;
        //}
    



        ///////////////////////////////
        //メソッド名：AddProductData()
        //引　数   ：商品データ
        //戻り値   ：True or False
        //機　能   ：商品データの登録
        //          ：登録成功の場合True
        //          ：登録失敗の場合False
        ///////////////////////////////
        public bool AddProductData(M_Product regpd)
        {
            try
            {
                var context = new SalesManagement_DevContext();
                context.M_Products.Add(regpd);
                context.SaveChanges();
                context.Dispose();

                return true;
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        ///////////////////////////////
        //メソッド名　UpdateProductData()
        //引　数   ：商品データ
        //戻り値   ：True or False
        //機　能   ：商品データの更新
        //          ：更新成功の場合True
        //          ：更新失敗の場合False
        ///////////////////////////////

        public bool UpdateProductData(M_Product updPd)
        {
            try
            {
                var context = new SalesManagement_DevContext();
                var product = context.M_Products.Single(x => x.PrID == updPd.PrID);
                product.MaID = updPd.MaID;
                product.PrName = updPd.PrName;
                product.Price = updPd.Price;
                product.PrJCode = updPd.PrJCode;
                product.PrSafetyStock = updPd.PrSafetyStock;
                product.ScID = updPd.ScID;
                product.PrModelNumber = updPd.PrModelNumber;
                product.PrColor = updPd.PrColor;
                product.PrReleaseDate = updPd.PrReleaseDate;
                product.PrFlag = updPd.PrFlag;
                product.PrHidden = updPd.PrHidden;

                context.SaveChanges();
                context.Dispose();

                return true;
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        ///////////////////////////////
        //メソッド名：GetProductData()　オーバーロード
        //引　数   ：商品データ
        //戻り値   ：条件一致商品データ
        //機　能   ：条件一致商品データの取得
        ///////////////////////////////
       
        public List<M_ProductDsp> GetProductData(int flg, M_ProductDsp selectCondition)
        {
          

            List<M_ProductDsp> product = new List<M_ProductDsp>();
            try
            {
                var context = new SalesManagement_DevContext();
                if (flg==1)
                {
                    var tb = from t1 in context.M_Products
                             join t2 in context.M_Makers
                             on t1.MaID equals t2.MaID
                             join t3 in context.M_SmallClassifications
                             on t1.ScID equals t3.ScID
                             where t1.PrID.ToString().Contains(selectCondition.PrID.ToString()) &&
                             t1.MaID==selectCondition.MaID&&
                             t1.PrName.Contains(selectCondition.PrName)&&
                             //t1.Price==selectCondition.Price&&
                             //t1.PrSafetyStock==selectCondition.PrSafetyStock&&
                             t1.ScID==selectCondition.ScID&&
                             //t1.PrModelNumber.Contains(selectCondition.PrModelNumber)&&
                             t1.PrColor.Contains(selectCondition.PrColor)&&
                             //t1.PrReleaseDate==selectCondition.PrReleaseDate&&
                             t1.PrFlag==selectCondition.PrFlag&&
                             t1.PrHidden.Contains(selectCondition.PrHidden)
                             
                             select new
                             {
                                 t1.PrID,
                                 t2.MaID,
                                 t2.MaName,
                                 t1.PrName,
                                 t1.Price,
                                 t1.PrSafetyStock,
                                 t3.McID,
                                 McName = (context.M_MajorCassifications.FirstOrDefault(x => x.McID == t3.McID)).McName,
                                 t3.ScID,
                                 t3.ScName,
                                 t1.PrModelNumber,
                                 t1.PrColor,
                                 t1.PrReleaseDate,
                                 t1.PrFlag,
                                 t1.PrHidden,
                             };

                    // IEnumerable型のデータをList型へ
                    foreach (var p in tb)
                    {
                        product.Add(new M_ProductDsp()
                        {
                            PrID = p.PrID,
                            MaID = p.MaID,
                            MaName = p.MaName,
                            PrName = p.PrName,
                            Price = p.Price,
                            PrSafetyStock = p.PrSafetyStock,
                            McID = p.McID,
                            McName = p.McName,
                            ScID = p.ScID,
                            ScName = p.ScName,
                            PrModelNumber = p.PrModelNumber,
                            PrColor = p.PrColor,
                            PrReleaseDate = p.PrReleaseDate,
                            PrFlag = p.PrFlag,
                            PrHidden = p.PrHidden,
                        });
                    }
                    context.Dispose();


                }
                if (flg == 2)
                {
                    var tb = from t1 in context.M_Products
                             join t2 in context.M_Makers
                             on t1.MaID equals t2.MaID
                             join t3 in context.M_SmallClassifications
                             on t1.ScID equals t3.ScID
                             //join t4 in context.M_MajorCassifications
                             // on t3.McID equals t4.McID
                             where t1.PrID.ToString().Contains(selectCondition.PrID.ToString())&&
                             t1.MaID == selectCondition.MaID &&
                             t1.PrName.Contains(selectCondition.PrName) &&
                             //t1.Price == selectCondition.Price &&
                             //t1.PrSafetyStock == selectCondition.PrSafetyStock &&
                             t1.ScID == selectCondition.ScID &&
                             //t1.PrModelNumber.Contains(selectCondition.PrModelNumber) &&
                             t1.PrColor.Contains(selectCondition.PrColor) &&
                             t1.PrReleaseDate == selectCondition.PrReleaseDate &&
                             t1.PrFlag == selectCondition.PrFlag &&
                             t1.PrHidden.Contains(selectCondition.PrHidden)

                             select new
                             {
                                 t1.PrID,
                                 t2.MaID,
                                 t2.MaName,
                                 t1.PrName,
                                 t1.Price,
                                 t1.PrSafetyStock,
                                 t3.McID,
                                 McName = (context.M_MajorCassifications.FirstOrDefault(x => x.McID == t3.McID)).McName,
                                 t3.ScID,
                                 t3.ScName,
                                 t1.PrModelNumber,
                                 t1.PrColor,
                                 t1.PrReleaseDate,
                                 t1.PrFlag,
                                 t1.PrHidden,
                             };

                    // IEnumerable型のデータをList型へ
                    foreach (var p in tb)
                    {
                        product.Add(new M_ProductDsp()
                        {
                            PrID = p.PrID,
                            MaID = p.MaID,
                            MaName = p.MaName,
                            PrName = p.PrName,
                            Price = p.Price,
                            PrSafetyStock = p.PrSafetyStock,
                            McID = p.McID,
                            McName = p.McName,
                            ScID = p.ScID,
                            ScName = p.ScName,
                            PrModelNumber = p.PrModelNumber,
                            PrColor = p.PrColor,
                            PrReleaseDate = p.PrReleaseDate,
                            PrFlag = p.PrFlag,
                            PrHidden = p.PrHidden,
                        });
                    }
                    context.Dispose();
                }
                if (flg == 3)
                {
                    var tb = from t1 in context.M_Products
                             join t2 in context.M_Makers
                             on t1.MaID equals t2.MaID
                             join t3 in context.M_SmallClassifications
                             on t1.ScID equals t3.ScID
                             //join t4 in context.M_MajorCassifications
                             // on t3.McID equals t4.McID
                             where t1.PrID.ToString().Contains(selectCondition.PrID.ToString()) &&
                             //t1.MaID == selectCondition.MaID &&
                             t1.PrName.Contains(selectCondition.PrName) &&
                             //t1.Price == selectCondition.Price &&
                             //t1.PrSafetyStock == selectCondition.PrSafetyStock &&
                             //t1.ScID == selectCondition.ScID &&
                             //t1.PrModelNumber.Contains(selectCondition.PrModelNumber) &&
                             t1.PrColor.Contains(selectCondition.PrColor) &&
                             //t1.PrReleaseDate == selectCondition.PrReleaseDate &&
                             t1.PrFlag == selectCondition.PrFlag &&
                             t1.PrHidden.Contains(selectCondition.PrHidden)
                             

                             select new
                             {
                                 t1.PrID,
                                 t2.MaID,
                                 t2.MaName,
                                 t1.PrName,
                                 t1.Price,
                                 t1.PrSafetyStock,
                                 t3.McID,
                                 McName = (context.M_MajorCassifications.FirstOrDefault(x => x.McID == t3.McID)).McName,
                                 t3.ScID,
                                 t3.ScName,
                                 t1.PrModelNumber,
                                 t1.PrColor,
                                 t1.PrReleaseDate,
                                 t1.PrFlag,
                                 t1.PrHidden,
                             };

                    // IEnumerable型のデータをList型へ
                    foreach (var p in tb)
                    {
                        product.Add(new M_ProductDsp()
                        {
                            PrID = p.PrID,
                            MaID = p.MaID,
                            MaName = p.MaName,
                            PrName = p.PrName,
                            Price = p.Price,
                            PrSafetyStock = p.PrSafetyStock,
                            McID = p.McID,
                            McName = p.McName,
                            ScID = p.ScID,
                            ScName = p.ScName,
                            PrModelNumber = p.PrModelNumber,
                            PrColor = p.PrColor,
                            PrReleaseDate = p.PrReleaseDate,
                            PrFlag = p.PrFlag,
                            PrHidden = p.PrHidden,
                        });
                    }
                    context.Dispose();
                }
                if (flg == 4)
                {
                    var tb = from t1 in context.M_Products
                             join t2 in context.M_Makers
                             on t1.MaID equals t2.MaID
                             join t3 in context.M_SmallClassifications
                             on t1.ScID equals t3.ScID
                             //join t4 in context.M_MajorCassifications
                             // on t3.McID equals t4.McID
                             where //t1.PrID.ToString().Contains(selectCondition.PrID.ToString()) &&
                             t1.MaID == selectCondition.MaID &&
                             t1.PrName.Contains(selectCondition.PrName) &&
                             //t1.Price == selectCondition.Price &&
                             //t1.PrSafetyStock == selectCondition.PrSafetyStock &&
                             t1.ScID == selectCondition.ScID &&
                             //t1.PrModelNumber.Contains(selectCondition.PrModelNumber) &&
                             t1.PrColor.Contains(selectCondition.PrColor) &&
                             //t1.PrReleaseDate == selectCondition.PrReleaseDate &&
                             t1.PrFlag == selectCondition.PrFlag &&
                             t1.PrHidden.Contains(selectCondition.PrHidden)

                             select new
                             {
                                 t1.PrID,
                                 t2.MaID,
                                 t2.MaName,
                                 t1.PrName,
                                 t1.Price,
                                 t1.PrSafetyStock,
                                 t3.McID,
                                 McName = (context.M_MajorCassifications.FirstOrDefault(x => x.McID == t3.McID)).McName,
                                 t3.ScID,
                                 t3.ScName,
                                 t1.PrModelNumber,
                                 t1.PrColor,
                                 t1.PrReleaseDate,
                                 t1.PrFlag,
                                 t1.PrHidden,
                             };

                    // IEnumerable型のデータをList型へ
                    foreach (var p in tb)
                    {
                        product.Add(new M_ProductDsp()
                        {
                            PrID = p.PrID,
                            MaID = p.MaID,
                            MaName = p.MaName,
                            PrName = p.PrName,
                            Price = p.Price,
                            PrSafetyStock = p.PrSafetyStock,
                            McID = p.McID,
                            McName = p.McName,
                            ScID = p.ScID,
                            ScName = p.ScName,
                            PrModelNumber = p.PrModelNumber,
                            PrColor = p.PrColor,
                            PrReleaseDate = p.PrReleaseDate,
                            PrFlag = p.PrFlag,
                            PrHidden = p.PrHidden,
                        });
                    }
                    context.Dispose();
                }
                if (flg == 5)
                {
                    var tb = from t1 in context.M_Products
                             join t2 in context.M_Makers
                             on t1.MaID equals t2.MaID
                             join t3 in context.M_SmallClassifications
                             on t1.ScID equals t3.ScID
                             //join t4 in context.M_MajorCassifications
                             // on t3.McID equals t4.McID
                             where //t1.PrID.ToString().Contains(selectCondition.PrID.ToString()) &&
                             //t1.MaID == selectCondition.MaID &&
                             t1.PrName.Contains(selectCondition.PrName) &&
                             //t1.Price == selectCondition.Price &&
                             //t1.PrSafetyStock == selectCondition.PrSafetyStock &&
                             t1.ScID == selectCondition.ScID &&
                             //t1.PrModelNumber.Contains(selectCondition.PrModelNumber) &&
                             t1.PrColor.Contains(selectCondition.PrColor) &&
                             //t1.PrReleaseDate == selectCondition.PrReleaseDate &&
                             t1.PrFlag == selectCondition.PrFlag &&
                             t1.PrHidden.Contains(selectCondition.PrHidden)

                             select new
                             {
                                 t1.PrID,
                                 t2.MaID,
                                 t2.MaName,
                                 t1.PrName,
                                 t1.Price,
                                 t1.PrSafetyStock,
                                 t3.McID,
                                 McName = (context.M_MajorCassifications.FirstOrDefault(x => x.McID == t3.McID)).McName,
                                 t3.ScID,
                                 t3.ScName,
                                 t1.PrModelNumber,
                                 t1.PrColor,
                                 t1.PrReleaseDate,
                                 t1.PrFlag,
                                 t1.PrHidden,
                             };

                    // IEnumerable型のデータをList型へ
                    foreach (var p in tb)
                    {
                        product.Add(new M_ProductDsp()
                        {
                            PrID = p.PrID,
                            MaID = p.MaID,
                            MaName = p.MaName,
                            PrName = p.PrName,
                            Price = p.Price,
                            PrSafetyStock = p.PrSafetyStock,
                            McID = p.McID,
                            McName = p.McName,
                            ScID = p.ScID,
                            ScName = p.ScName,
                            PrModelNumber = p.PrModelNumber,
                            PrColor = p.PrColor,
                            PrReleaseDate = p.PrReleaseDate,
                            PrFlag = p.PrFlag,
                            PrHidden = p.PrHidden,
                        });
                    }
                    context.Dispose();
                }
                if (flg == 6)
                {
                    var tb = from t1 in context.M_Products
                             join t2 in context.M_Makers
                             on t1.MaID equals t2.MaID
                             join t3 in context.M_SmallClassifications
                             on t1.ScID equals t3.ScID
                             //join t4 in context.M_MajorCassifications
                             // on t3.McID equals t4.McID
                             where t1.PrID.ToString().Contains(selectCondition.PrID.ToString()) &&
                            // t1.MaID == selectCondition.MaID &&
                             t1.PrName.Contains(selectCondition.PrName) &&
                             //t1.Price == selectCondition.Price &&
                             //t1.PrSafetyStock == selectCondition.PrSafetyStock &&
                             t1.ScID == selectCondition.ScID &&
                             //t1.PrModelNumber.Contains(selectCondition.PrModelNumber) &&
                             t1.PrColor.Contains(selectCondition.PrColor) &&
                             //t1.PrReleaseDate == selectCondition.PrReleaseDate &&
                             t1.PrFlag == selectCondition.PrFlag &&
                             t1.PrHidden.Contains(selectCondition.PrHidden)

                             select new
                             {
                                 t1.PrID,
                                 t2.MaID,
                                 t2.MaName,
                                 t1.PrName,
                                 t1.Price,
                                 t1.PrSafetyStock,
                                 t3.McID,
                                 McName = (context.M_MajorCassifications.FirstOrDefault(x => x.McID == t3.McID)).McName,
                                 t3.ScID,
                                 t3.ScName,
                                 t1.PrModelNumber,
                                 t1.PrColor,
                                 t1.PrReleaseDate,
                                 t1.PrFlag,
                                 t1.PrHidden,
                             };

                    // IEnumerable型のデータをList型へ
                    foreach (var p in tb)
                    {
                        product.Add(new M_ProductDsp()
                        {
                            PrID = p.PrID,
                            MaID = p.MaID,
                            MaName = p.MaName,
                            PrName = p.PrName,
                            Price = p.Price,
                            PrSafetyStock = p.PrSafetyStock,
                            McID = p.McID,
                            McName = p.McName,
                            ScID = p.ScID,
                            ScName = p.ScName,
                            PrModelNumber = p.PrModelNumber,
                            PrColor = p.PrColor,
                            PrReleaseDate = p.PrReleaseDate,
                            PrFlag = p.PrFlag,
                            PrHidden = p.PrHidden,
                        });
                    }
                    context.Dispose();
                }
                if (flg == 7)
                {
                    var tb = from t1 in context.M_Products
                             join t2 in context.M_Makers
                             on t1.MaID equals t2.MaID
                             join t3 in context.M_SmallClassifications
                             on t1.ScID equals t3.ScID
                             //join t4 in context.M_MajorCassifications
                             // on t3.McID equals t4.McID
                             where //t1.PrID.ToString().Contains(selectCondition.PrID.ToString()) &&
                             t1.MaID == selectCondition.MaID &&
                             t1.PrName.Contains(selectCondition.PrName) &&
                             //t1.Price == selectCondition.Price &&
                             //t1.PrSafetyStock == selectCondition.PrSafetyStock &&
                             //t1.ScID == selectCondition.ScID &&
                             //t1.PrModelNumber.Contains(selectCondition.PrModelNumber) &&
                             t1.PrColor.Contains(selectCondition.PrColor) &&
                             //t1.PrReleaseDate == selectCondition.PrReleaseDate &&
                             t1.PrFlag == selectCondition.PrFlag &&
                             t1.PrHidden.Contains(selectCondition.PrHidden)

                             select new
                             {
                                 t1.PrID,
                                 t2.MaID,
                                 t2.MaName,
                                 t1.PrName,
                                 t1.Price,
                                 t1.PrSafetyStock,
                                 t3.McID,
                                 McName = (context.M_MajorCassifications.FirstOrDefault(x => x.McID == t3.McID)).McName,
                                 t3.ScID,
                                 t3.ScName,
                                 t1.PrModelNumber,
                                 t1.PrColor,
                                 t1.PrReleaseDate,
                                 t1.PrFlag,
                                 t1.PrHidden,
                             };

                    // IEnumerable型のデータをList型へ
                    foreach (var p in tb)
                    {
                        product.Add(new M_ProductDsp()
                        {
                            PrID = p.PrID,
                            MaID = p.MaID,
                            MaName = p.MaName,
                            PrName = p.PrName,
                            Price = p.Price,
                            PrSafetyStock = p.PrSafetyStock,
                            McID = p.McID,
                            McName = p.McName,
                            ScID = p.ScID,
                            ScName = p.ScName,
                            PrModelNumber = p.PrModelNumber,
                            PrColor = p.PrColor,
                            PrReleaseDate = p.PrReleaseDate,
                            PrFlag = p.PrFlag,
                            PrHidden = p.PrHidden,
                        });
                    }
                    context.Dispose();
                }
                if (flg == 8)
                {
                    var tb = from t1 in context.M_Products
                             join t2 in context.M_Makers
                             on t1.MaID equals t2.MaID
                             join t3 in context.M_SmallClassifications
                             on t1.ScID equals t3.ScID
                             //join t4 in context.M_MajorCassifications
                             // on t3.McID equals t4.McID
                             where //t1.PrID.ToString().Contains(selectCondition.PrID.ToString()) &&
                             //t1.MaID == selectCondition.MaID &&
                             t1.PrName.Contains(selectCondition.PrName) &&
                             //t1.Price == selectCondition.Price &&
                             //t1.PrSafetyStock == selectCondition.PrSafetyStock &&
                             //t1.ScID == selectCondition.ScID &&
                             //t1.PrModelNumber.Contains(selectCondition.PrModelNumber) &&
                             t1.PrColor.Contains(selectCondition.PrColor) &&
                             //t1.PrReleaseDate == selectCondition.PrReleaseDate &&
                             t1.PrFlag == selectCondition.PrFlag &&
                             t1.PrHidden.Contains(selectCondition.PrHidden)

                             select new
                             {
                                 t1.PrID,
                                 t2.MaID,
                                 t2.MaName,
                                 t1.PrName,
                                 t1.Price,
                                 t1.PrSafetyStock,
                                 t3.McID,
                                 McName = (context.M_MajorCassifications.FirstOrDefault(x => x.McID == t3.McID)).McName,
                                 t3.ScID,
                                 t3.ScName,
                                 t1.PrModelNumber,
                                 t1.PrColor,
                                 t1.PrReleaseDate,
                                 t1.PrFlag,
                                 t1.PrHidden,
                             };

                    // IEnumerable型のデータをList型へ
                    foreach (var p in tb)
                    {
                        product.Add(new M_ProductDsp()
                        {
                            PrID = p.PrID,
                            MaID = p.MaID,
                            MaName = p.MaName,
                            PrName = p.PrName,
                            Price = p.Price,
                            PrSafetyStock = p.PrSafetyStock,
                            McID = p.McID,
                            McName = p.McName,
                            ScID = p.ScID,
                            ScName = p.ScName,
                            PrModelNumber = p.PrModelNumber,
                            PrColor = p.PrColor,
                            PrReleaseDate = p.PrReleaseDate,
                            PrFlag = p.PrFlag,
                            PrHidden = p.PrHidden,
                        });
                    }
                    context.Dispose();
                }
            }
               
                
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return product;
        }

        ///////////////////////////////
        //メソッド名：GetHiddenData()　
        //引　数   ：なし
        //戻り値   ：非表示データ
        //機　能   ：非表示データの取得
        ///////////////////////////////

        public List<M_ProductDsp> GetHiddenData()
        {
            List<M_ProductDsp> product = new List<M_ProductDsp>();
            try
            {
                var context = new SalesManagement_DevContext();
                //product = context.M_Products.ToList();
                var tb = from t1 in context.M_Products
                         join t2 in context.M_Makers
                         on t1.MaID equals t2.MaID
                         join t3 in context.M_SmallClassifications
                         on t1.ScID equals t3.ScID
                         //join t4 in context.M_MajorCassifications
                         // on t3.McID equals t4.McID
                         where t1.PrFlag == 2
                         
                         select new
                         {
                             t1.PrID,
                             t2.MaID,
                             t2.MaName,
                             t1.PrName,
                             t1.Price,
                             t1.PrSafetyStock,
                             t3.McID,
                             McName = (context.M_MajorCassifications.FirstOrDefault(x => x.McID == t3.McID)).McName,
                             t3.ScID,
                             t3.ScName,
                             t1.PrModelNumber,
                             t1.PrColor,
                             t1.PrReleaseDate,
                             t1.PrFlag,
                             t1.PrHidden,


                         };

                // IEnumerable型のデータをList型へ
                foreach (var p in tb)
                {
                    product.Add(new M_ProductDsp()
                    {
                        PrID = p.PrID,
                        MaID = p.MaID,
                        MaName = p.MaName,
                        PrName = p.PrName,
                        Price = p.Price,
                        PrSafetyStock = p.PrSafetyStock,
                        McID = p.McID,
                        McName = p.McName,
                        ScID = p.ScID,
                        ScName = p.ScName,
                        PrModelNumber = p.PrModelNumber,
                        PrColor = p.PrColor,
                        PrReleaseDate = p.PrReleaseDate,
                        PrFlag = p.PrFlag,
                        PrHidden = p.PrHidden,
                    });
                }
                context.Dispose();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return product;
        }

        ///////////////////////////////
        //メソッド名： GetProductData()
        //引　数   ：なし
        //戻り値   ：商品データ
        //機　能   ：商品データの取得
        ///////////////////////////////

        public List<M_ProductDsp> GetProductData()
        {
            List<M_ProductDsp> product = new List<M_ProductDsp>();
            try
            {
                var context = new SalesManagement_DevContext();
                //product = context.M_Products.ToList();
                var tb = from t1 in context.M_Products
                         join t2 in context.M_Makers
                         on t1.MaID equals t2.MaID
                         join t3 in context.M_SmallClassifications
                         on t1.ScID equals t3.ScID
                         //join t4 in context.M_MajorCassifications
                         // on t3.McID equals t4.McID
                         
//
                         select new
                         {
                             t1.PrID,
                             t2.MaID,
                             t2.MaName,
                             t1.PrName,
                             t1.Price,
                             t1.PrSafetyStock,
                             t3.McID,
                             McName = (context.M_MajorCassifications.FirstOrDefault(x => x.McID== t3.McID)).McName,
                             t3.ScID,
                             t3.ScName,
                             t1.PrModelNumber ,
                             t1.PrColor,
                             t1.PrReleaseDate,
                             t1.PrFlag,
                             t1.PrHidden,


                         };

                // IEnumerable型のデータをList型へ
                foreach (var p in tb)
                {
                    product.Add(new M_ProductDsp()
                    {
                       PrID=p.PrID,
                       MaID=p.MaID,
                       MaName=p.MaName,
                       PrName=p.PrName,
                       Price=p.Price,
                       PrSafetyStock=p.PrSafetyStock,
                       McID=p.McID,
                       McName=p.McName,
                       ScID=p.ScID,
                       ScName=p.ScName,
                       PrModelNumber=p.PrModelNumber,
                       PrColor=p.PrColor,
                       PrReleaseDate=p.PrReleaseDate,
                       PrFlag=p.PrFlag,
                       PrHidden=p.PrHidden,
                    });
                }
                context.Dispose();
            
               
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return product;
        }
        ///////////////////////////////
        //メソッド名：GetPrIDData()
        //引　数   ：商品ID
        //戻り値   ：商品データ
        //機　能   ：商品データ取得
        ///////////////////////////////


        public M_Product GetPrIDData(int prID)
        {

            M_Product product = new M_Product();

            try
            {
                var context = new SalesManagement_DevContext();
                product = context.M_Products.Single(x => x.PrID == prID );
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return product;
        }

    }
}
