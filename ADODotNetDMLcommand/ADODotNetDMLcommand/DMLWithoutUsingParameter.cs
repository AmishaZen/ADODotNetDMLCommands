using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ADODotNetDMLcommand
{
    
    class DMLCmdWithoutParameters
    {
        SqlConnection cn = null;
        SqlCommand cmd = null;
        SqlDataReader dr = null;

        public int ShowData()
        {

            try
            {
                cn = new SqlConnection(@"Data Source=DESKTOP-5OGL65Q\AMISQLTUTORIAL;Initial Catalog=WFA3DotNet;Integrated Security=True");
                cmd = new SqlCommand("select * from Employee", cn);
                cn.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Console.WriteLine($"{dr["EmpId"]}\t{dr["EmpName"]}\t{dr["Salary"]}\t{dr["DeptNo"]}");
                }
                return 0;
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                return 0;
            }
            finally

            {

                cn.Close();
            }
            return 0;


        }
        public int InsertOneRow()
        {
            try
            {
                Console.WriteLine("Enter Emp Name");
                var ename = Console.ReadLine();
                Console.WriteLine("Enter Emp Salary");
                var esal = Convert.ToSingle(Console.ReadLine());
                Console.WriteLine("Enter Emp dept id");
                var did = Convert.ToInt32(Console.ReadLine());
                cn = new SqlConnection(@"Data Source=DESKTOP-5OGL65Q\AMISQLTUTORIAL;Initial Catalog=WFA3DotNet;Integrated Security=True");
                cmd = new SqlCommand("insert into Employee values('" + ename + "'," + esal + "," + did + ")", cn);
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                Console.WriteLine("one row added to the table");
                ShowData();
                return i;


            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                return 1;
            }
            finally
            {
                cn.Close();
            }
        }
        public int DeleteOneRow()
        {
            try
            {
                Console.WriteLine("Enter employee Id");
                var eid = Convert.ToInt32(Console.ReadLine());
                cn = new SqlConnection(@"Data Source=DESKTOP-5OGL65Q\AMISQLTUTORIAL;Initial Catalog=WFA3DotNet;Integrated Security=True");
                cmd = new SqlCommand("delete from Employee where EmpId=" + eid + "", cn);
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                Console.WriteLine("one row deleted to the table");
                ShowData();
                return i;


            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                return 1;
            }
            finally
            {
                cn.Close();
            }
        }

        public int UpadteRow()
        {
            try
            {
                Console.WriteLine("Enter employee Id");
                var eid = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Emp Name");
                var ename = Console.ReadLine();
                Console.WriteLine("Enter Emp Salary");
                var esal = Convert.ToSingle(Console.ReadLine());
                Console.WriteLine("Enter Emp dept id");
                var did = Convert.ToInt32(Console.ReadLine());
                cn = new SqlConnection(@"Data Source=DESKTOP-5OGL65Q\AMISQLTUTORIAL;Initial Catalog=WFA3DotNet;Integrated Security=True");
                cmd = new SqlCommand("update Employee set EmpName='" + ename + "',Salary=" + esal + ",DeptNo=" + did + " where EmpId=" + eid + "", cn);
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                Console.WriteLine("one row updated to the table");
                ShowData();
                return i;


            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                return 1;
            }
            finally
            {
                cn.Close();

            }
            return 0;
        }
        public void SearchOneRow()
        {
            try
            {
                Console.WriteLine("Enter Emp ID");
                int eid = int.Parse(Console.ReadLine());
                
                cn = new SqlConnection(@"Data Source=DESKTOP-5OGL65Q\AMISQLTUTORIAL;Initial Catalog=WFA3DotNet;Integrated Security=True");
                cmd = new SqlCommand("select * from Employee where EmpId="+eid+"", cn);
                cn.Open();
                dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {

                        Console.WriteLine($"Emp Name : {dr["empname"].ToString()}");
                        Console.WriteLine($"Salary : { dr["salary"].ToString()}");
                        Console.WriteLine($"DeptNo :{dr["deptNo"].ToString()}\n");
                    }
                //ShowData();

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                
            }
            finally
            {
                dr.Close();
                cn.Close();
            }
        }
    }
    class DMLWithoutUsingParameter
    {
        static void Main(string[] args)
        {
            DMLCmdWithoutParameters dmw = new DMLCmdWithoutParameters();
            int option;
            Console.WriteLine("Check DML operations");
            dmw.ShowData();
            Console.WriteLine("--------------------------------------");
            do
            {

                Console.WriteLine("Enter option \n1, for insert data\n2. for Delete Record\n3. for Upadte record\n4. for Search\n5.for Exit");
                option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1: dmw.InsertOneRow(); break;
                    case 2: dmw.DeleteOneRow(); break;
                    case 3: dmw.UpadteRow(); break;
                    case 4: dmw.SearchOneRow();break;
                    default: Console.WriteLine("wrong choice"); break;
                }
            } while (option > 1 && option <= 4);
        }
    }
}
