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
                flg = context.M_Products.Any(x => x.PrID==prID&&x.PrFlag==0);
                context.Dispose();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return flg;
        }

        public bool CheckPrModelNumberExistence( string prMB)
        {
            bool flg = false;
            try
            {
                var context = new SalesManagement_DevContext();
                flg = context.M_Products.Any(x => x.PrModelNumber == prMB); 
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return flg;
        }
    



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
        //public List<M_Product> GetProductData(M_Product selectCondition)
        //{
        //    List<M_Product> product = new List<M_Product>();
        //    try
        //    {
        //        var context = new SalesManagement_DevContext();
        //        product = context.M_Products.Where(x => x.PrID == selectCondition.PrID&&x.MaID==selectCondition.MaID&&
                                                   //x.PrName.Contains(selectCondition.PrName)&&x.PrModelNumber.Contains(selectCondition.PrModelNumber)&&x.PrColor.Contains(selectCondition.PrColor)&&
                                                   //x.ScID==selectCondition.ScID&&x.PrColor.Contains(selectCondition.PrColor)).ToList();
        //        context.Dispose();
        //    }catch(Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);

        //    }
        //    return product;
        //}
        public List<M_Product> GetProductData(M_Product selectCondition)
        {
            List<M_Product> product = new List<M_Product>();
            try
            {
                var context = new SalesManagement_DevContext();
                product = context.M_Products.Where(x => x.PrID == selectCondition.PrID&& x.MaID == selectCondition.MaID).ToList();
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

        public List<M_Product> GetProductData()
        {
            List<M_Product> product = new List<M_Product>();
            try
            {
                var context = new SalesManagement_DevContext();
                product = context.M_Products.ToList();
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
                product = context.M_Products.Single(x => x.PrID == prID && x.PrFlag == 0);
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
