﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace IBM_24Jan24LINQ_DB
{
    internal class ADONETEg
    {

        static void Main()
        {
            SqlConnection _cn = new SqlConnection();

            SqlConnectionStringBuilder _cnb = new SqlConnectionStringBuilder();
            _cnb.DataSource = @"(localdb)\MSSQLLocalDB";
            _cnb.InitialCatalog = "IBM25Jan24Db";
            _cnb.IntegratedSecurity = true;


            _cn.ConnectionString = _cnb.ConnectionString;



            string choice = "";

            do
            {
                Console.Clear();
                Console.WriteLine("Employee Details through ADO.NET \n\n\n1. List Employees\n\n2. Add New Employee\n\n3. Edit Employee\n\n4. Delete Employee\n\n5. Stored Proc \n\n6. Display Using DataSet(Datatable) \n\n0. Exit \n\n\n\n");
                Console.Write("Enter Choice:");
                choice = Console.ReadLine();



                if (choice == "1")
                {

                    ListEmployees(_cn);


                }
                if (choice == "2")
                {
                    

                }

                if (choice == "3")
                {
                  

                }
                if (choice == "4")
                {
                   

                }
                if (choice == "5")
                {
                   

                }

            } while (choice != "0");



        }

        private static void ListEmployees(SqlConnection _cn)
        {
            SqlCommand _cmd=new SqlCommand ();

            _cmd.Connection = _cn;
            _cmd.CommandType = CommandType.Text;
            _cmd.CommandText = "select * from employee";
            
            _cn.Open();
           SqlDataReader _drd=     _cmd.ExecuteReader();
            
            if (_drd.HasRows==false)
            { Console.Clear(); Console.Write("Record(s) not found!!!\nPress any key to Continue...");
                Console.ReadKey();
                return;
            }
                Console.Clear();
                Console.WriteLine($"EmpID          |EmpName          |Salary");
                while (_drd.Read())
                {
                    Console.WriteLine($"{_drd.GetValue(0)}|{_drd.GetValue(1)}|{_drd.GetValue(2)}");
                }
                Console.Write( "Press any key to Continue..." );
                Console.ReadKey();
         
            _drd.Close(); _cn.Close();



        }
    }
}