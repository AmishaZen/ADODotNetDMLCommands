﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ADODotNetDMLcommand
{
    class DMLStoredProcedure
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

        public int InsertWithSp()
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
                cmd = new SqlCommand("sp_InsertEmp", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                
                cmd.Parameters.Add("@ename", SqlDbType.VarChar, 20).Value = ename;
                cmd.Parameters.Add("@sal", SqlDbType.Float).Value = esal;
                cmd.Parameters.Add("@dno", SqlDbType.Int).Value = did;

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
        }
        public int UpdateWithSp()
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
                cmd = new SqlCommand("sp_UpdateEmp", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@empId", SqlDbType.Int).Value = eid;
                cmd.Parameters.Add("@empname", SqlDbType.VarChar, 20).Value = ename;
                cmd.Parameters.Add("@esal", SqlDbType.Float).Value = esal;
                cmd.Parameters.Add("@deptId", SqlDbType.Int).Value = did;

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
        }
        public int DeleteWithSp()
        {
            try
            {
                Console.WriteLine("Enter employee Id");
                var eid = Convert.ToInt32(Console.ReadLine());
                
                cn = new SqlConnection(@"Data Source=DESKTOP-5OGL65Q\AMISQLTUTORIAL;Initial Catalog=WFA3DotNet;Integrated Security=True");
                cmd = new SqlCommand("sp_DeleteEmp", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@eid", SqlDbType.Int).Value = eid;
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

        public void ShowEmpDetails()
        {
            try
            {

                cn = new SqlConnection(@"Data Source=DESKTOP-5OGL65Q\AMISQLTUTORIAL;Initial Catalog=WFA3DotNet;Integrated Security=True");
                cmd = new SqlCommand("sp_SelectEmps", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                Console.WriteLine("Enter an existing Employee id to see the details....");
                var eid = Convert.ToInt32(Console.ReadLine());

                cmd.Parameters.Add("@empid", SqlDbType.Int).Value = eid;

                cn.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Console.WriteLine($"{dr["EmpName"]}\t {dr["Salary"]}\t{dr["DeptName"]}");
                }
                


            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");

            }
            finally
            {
                dr.Close();
                cn.Close();
            }
        }


    }
    class DMLUsingStoredProcedure
    {
        static void Main(string[] args)
        {
            DMLStoredProcedure st = new DMLStoredProcedure();
            int option;
            Console.WriteLine("Check DML operations");
            st.ShowData();
            Console.WriteLine("--------------------------------------");
            do
            {

                Console.WriteLine("Enter option \n1, for insert data\n2. for Delete Record\n3. for Upadte record\n4.Search \n5.for Exit");
                option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1: st.InsertWithSp(); break;
                    case 2: st.DeleteWithSp(); break;
                    case 3: st.UpdateWithSp(); break;
                    case 4: st.ShowEmpDetails(); break;
                    default: Console.WriteLine("wrong choice"); break;
                }
            } while (option > 1 && option <= 4);
        }
    }
}
