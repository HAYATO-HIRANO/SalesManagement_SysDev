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
        public bool CheckPrIDExistence(int prID)
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

        public List<M_Product> GetProductData(M_Product selectCondition)
        {
            List<M_Product> product = new List<M_Product>();
            try
            {
                var context = new SalesManagement_DevContext();
                product = context.M_Products.Where(x => x.PrID == selectCondition.PrID).ToList();
                context.Dispose();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return product;
        }



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
    }
}
