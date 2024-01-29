using System;
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
                    AddNewEmployee(_cn);


                }

                if (choice == "3")
                {
                    EditEmployee(_cn);


                }
                if (choice == "4")
                {
                   

                }
                if (choice == "5")
                {
                   

                }

            } while (choice != "0");



        }

        private static void EditEmployee(SqlConnection _cn)
        {
            // Display Employees 
            ListEmployees(_cn) ;


            Console.WriteLine("\n\nEnter Employee Details to Seek for Edit" );
            Console.Write("Emp ID to Seek:");
            string empID= Console.ReadLine();
            SeekEmployee(_cn, empID);


            Console.WriteLine("Enter Employee Details to Update");
            Console.Write("New Emp Name  :");
            string _enm = Console.ReadLine();
            Console.Write("New Emp Salary:");
            decimal _Sal = decimal.Parse(Console.ReadLine());



            SqlCommand _cmd = new
                SqlCommand(cmdText: "update  [Employee] set  [EmpName]=@empnm, [Salary] =@sal where EmployeeID=@eid",
                connection: _cn);

            _cmd.Parameters.Add("@empnm", SqlDbType.VarChar, 50).Value = _enm;
            _cmd.Parameters.Add("@sal", SqlDbType.Money).Value = _Sal;
            _cmd.Parameters.Add("@eid", SqlDbType.Int).Value = empID;


            _cn.Open();

            if (_cmd.ExecuteNonQuery() > 0)
                Console.WriteLine("Updated Successfully!!!\n Press any key to Continue...");
            else
                Console.WriteLine("Something went Worng!!!\n Press any key to Continue...");

            _cn.Close();

            Console.ReadKey();



        }

        private static void AddNewEmployee(SqlConnection _cn)
        { 
            Console.Clear ();
            Console.WriteLine( "Enter Employee Details to Insert");
            Console.Write("Emp Name  :"  );
            string _enm = Console.ReadLine();
            Console.Write("Emp Salary:");
            decimal _Sal = decimal.Parse( Console.ReadLine());



            SqlCommand _cmd=new 
                SqlCommand (cmdText: "INSERT INTO [Employee] ( [EmpName], [Salary]) VALUES ( @empnm,@sal )",
                connection: _cn);

            _cmd.Parameters.Add("@empnm", SqlDbType.VarChar,50).Value = _enm;
            _cmd.Parameters.Add("@sal", SqlDbType.Money).Value = _Sal;


            _cn.Open();

            if (_cmd.ExecuteNonQuery() > 0)
                Console.WriteLine("Inserted Successfully!!!\n Press any key to Continue...");
            else 
                Console.WriteLine("Something went Worng!!!\n Press any key to Continue...");
            
            _cn.Close();

            Console.ReadKey();

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
   
       private static void SeekEmployee(SqlConnection _cn,string EmpID)
        {
            SqlCommand _cmd=new SqlCommand ();

            _cmd.Connection = _cn;
            _cmd.CommandType = CommandType.Text;
            _cmd.CommandText = $"select * from employee where EmployeeId={EmpID}";
            
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
