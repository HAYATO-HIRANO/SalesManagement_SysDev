using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesManagement_SysDev
{
    class EmployeeDataAccess
    {
        ///////////////////////////////
        //メソッド名：CheckEmIDExistence()
        //引　数   ：社員ID
        //戻り値   ：True or False
        //機　能   ：一致するスタッフコードの有無を確認
        //          ：一致データありの場合True
        //          ：一致データなしの場合False
        ///////////////////////////////
        public bool CheckEmIDExistence(int emID)
        {
            bool flg = false;
            try
            {
                var context = new SalesManagement_DevContext();
                //社員IDで一致するデータが存在するか
                flg = context.M_Employees.Any(x => x.EmID == emID);
                context.Dispose();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
               
            }
            return flg;
        }

        ///////////////////////////////
        //メソッド名：AddEmployeeData()
        //引　数   ：社員データ
        //戻り値   ：True or False
        //機　能   ：社員データの登録
        //          ：登録成功の場合True
        //          ：登録失敗の場合False
        ///////////////////////////////
        public bool AddEmployeeData(M_Employee regEmployee)
        {
            try
            {
                var context = new SalesManagement_DevContext();
                context.M_Employees.Add(regEmployee);
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
        //メソッド名：UpdateEmployeeData()
        //引　数   :社員データ
        //戻り値   ：True or False
        //機　能   ：社員データの更新
        //          ：更新成功の場合True
        //          ：更新失敗の場合False
        ///////////////////////////////
        public bool UpdateEmployeeData(M_Employee updEmployee)
        {
            try
            {
                var context = new SalesManagement_DevContext();
                var employee = context.M_Employees.Single(x => x.EmID == updEmployee.EmID);
                employee.EmName = updEmployee.EmName;
                employee.SoID = updEmployee.SoID;
                employee.PoID = updEmployee.PoID;
                employee.EmHiredate = updEmployee.EmHiredate;
                employee.EmPassword = updEmployee.EmPassword;
                employee.EmPhone = updEmployee.EmPhone;
                employee.EmFlag = updEmployee.EmFlag;
                employee.EmHidden = updEmployee.EmHidden;
                // パスワード入力時のみ更新
                if (!String.IsNullOrEmpty(updEmployee.EmPassword))
                    employee.EmPassword = updEmployee.EmPassword;
                employee.EmFlag = updEmployee.EmFlag;
                employee.EmHidden = updEmployee.EmHidden;

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
        //メソッド名：GetEmployeeData()
        //引　数   ：なし
        //戻り値   ：全社員データ
        //機　能   ：全社員データの取得
        ///////////////////////////////
        public List<M_EmployeeDsp> GetEmployeeData()
        {
            List<M_EmployeeDsp> employee = new List<M_EmployeeDsp>();

            try
            {
                var context = new SalesManagement_DevContext();
                //tbはIEnumerable型
                var tb = from t1 in context.M_Employees
                         join t2 in context.M_SalesOffices
                         on t1.SoID equals t2.SoID
                         join t3 in context.M_Positions
                         on t1.PoID equals t3.PoID

                         select new
                         {
                             t1.EmID,
                             t1.EmName,
                             t1.SoID,
                             t2.SoName,
                             t1.PoID,
                             t3.PoName,
                             t1.EmHiredate,
                             t1.EmPassword,
                             t1.EmPhone,
                             t1.EmFlag,
                             t1.EmHidden
                         };
                foreach(var p in tb)
                {
                    employee.Add(new M_EmployeeDsp()
                    {
                        EmID = p.EmID,
                        EmName = p.EmName,
                        SoID = p.SoID,
                        SoName = p.SoName,
                        PoID = p.PoID,
                        PoName = p.PoName,
                        EmHiredate = p.EmHiredate,
                        EmPassword = p.EmPassword,
                        EmPhone = p.EmPhone,
                        EmFlag = p.EmFlag,
                        EmHidden = p.EmHidden
                    });
                }
                context.Dispose(); 
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return employee;
        }
        ///////////////////////////////
        //メソッド名：GetEmployeeData() オーバーロード
        //引　数   ：検索条件
        //戻り値   ：条件一致社員データ
        //機　能   ：条件一致社員データの取得
        ///////////////////////////////
        public List<M_EmployeeDsp> GetEmployeeData(M_EmployeeDsp selectCondition)
        {
            List<M_EmployeeDsp> employee = new List<M_EmployeeDsp>();
            try
            {

                var context = new SalesManagement_DevContext();
                // tbはIEnumerable型
                var tb = from t1 in context.M_Employees
                         join t2 in context.M_SalesOffices
                         on t1.SoID equals t2.SoID
                         join t3 in context.M_Positions
                         on t1.PoID equals t3.PoID
                         where t1.EmID.ToString().Contains(selectCondition.EmID.ToString()) &&
                               t1.EmName.Contains(selectCondition.EmName) &&
                               t1.SoID.ToString().Contains(selectCondition.SoID.ToString()) &&
                               t1.PoID.ToString().Contains(selectCondition.PoID.ToString()) &&
                               t1.EmPhone.Contains(selectCondition.EmPhone) &&
                               t1.EmHiredate.ToString().Contains(selectCondition.EmHiredate.ToString())


                         select new
                         {
                             t1.EmID,
                             t1.EmName,
                             t1.SoID,
                             t2.SoName,
                             t1.PoID,
                             t3.PoName,
                             t1.EmHiredate,
                             t1.EmPassword,
                             t1.EmPhone,
                             t1.EmFlag,
                             t1.EmHidden
                         };

                // IEnumerable型のデータをList型へ
                foreach(var p in tb)
                {
                    employee.Add(new M_EmployeeDsp()
                    {
                        EmID = p.EmID,
                        EmName = p.EmName,
                        SoID = p.SoID,
                        SoName = p.SoName,
                        PoID = p.PoID,
                        PoName = p.PoName,
                        EmHiredate = p.EmHiredate,
                        EmPassword = p.EmPassword,
                        EmPhone = p.EmPhone,
                        EmFlag = p.EmFlag,
                        EmHidden = p.EmHidden
                    });
                }
                context.Dispose();


            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return employee;
        }
    }
}
