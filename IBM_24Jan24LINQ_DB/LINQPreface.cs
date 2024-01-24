using IBM_24Jan24LINQ_DB.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

//using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBM_24Jan24LINQ_DB
{
    internal class LINQPreface
    {
        class a
        {

        }
        class b:a { }


        static void Main(string[] args)
        {

            a obj= new b();

            a obj2 = new a();
            b obj3 = new b();
            obj2 = obj3;

            obj3=  obj2 as b;
            obj3 = (b)obj2;




           
            IEnumerable l= new List<string>();

            string st = "";
           


            List<IBMEmployee> _emps = new List<IBMEmployee> { 
                new IBMEmployee { EmpID=1000, EmpName="Ganesh", Salary=1000 },
                new IBMEmployee { EmpID=1001, EmpName="Mahesh", Salary=12000 },
                new IBMEmployee { EmpID=1002, EmpName="Dinesh", Salary=15000 },
                new IBMEmployee { EmpID=1003, EmpName="Vignesh", Salary=18000 },
            };

           IEnumerable<IBMEmployee> _emp= _emps;


          //  IEnumerable<IBMEmployee> _qry = _emps.Where(FilterForSalaryGt1000);


            //IEnumerable<IBMEmployee> _qry = _emps.Where(emp => emp.Salary > 1000);
           // var _qry = _emps.Where(emp => emp.Salary > 1000);
            var _qry = _emps.Where(emp => emp.EmpName.Contains("a") );


            foreach (IBMEmployee emp in _qry)
                Console.WriteLine(  $"EmpName :{emp.EmpName}, Salary:{emp.Salary}");
        }

        static bool FilterForSalaryGt1000(IBMEmployee emp) => emp.Salary > 1000;

    }
}
