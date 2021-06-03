using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Data;

namespace Latest_27_05
{
    class JoinCheck
    {
        static int record = 0;
        private string column1;
        private string column2;
        private string column3;
        static List<string> ansTable;
        static List<List<string>> colLists;


        public JoinCheck(string column1, string column2, string column3)
        {

        }
        public static void JoinCheckQuery(string connectionString, string sqlCommand)
        {
            string queryString = "select distinct dbid, DB_NAME(dbid) FROM sys.sysprocesses where dbid > 0 ";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(queryString, connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            //colLists = frmQueries.getCol(connectionString, ansTable, queryString);
                            //Console.WriteLine("Debug getCol | Column List check: " + colLists[0][0]);
                            Console.WriteLine(String.Format("{0}, {1}", reader[0], reader[1]));
                        }
                        reader.Close();
                }
            }catch(Exception e)
            {
                Console.WriteLine("Debug JoinCheckQuery | " + e.Message);
            }
        }
        
        public static void JoinCheckQueryTest(string connectionString) //Method to check Join Function
        {
            DataTable schema = null;
            string sqlCommand = "SELECT Name, AVG(SickLeaveHours) AS sickLeave, AVG(VacationHours) AS vacation, COUNT(D.Name) AS noStaff FROM HumanResources.Department AS D LEFT OUTER JOIN HumanResources.EmployeeDepartmentHistory AS EDH ON D.DepartmentID = EDH.DepartmentID JOIN HumanResources.Employee AS E ON EDH.BusinessEntityID = E.BusinessEntityID  WHERE EDH.EndDate IS NULL OR EDH.EndDate >= getDate() GROUP BY D.Name";
            record = 0;
            //string queryString = "Select * From Account;";
            try
            {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                SqlCommand command = new SqlCommand(sqlCommand, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                {
                    while (reader.Read())
                    {
                        record++;
                        colLists = frmQueries.getCol(connectionString, ansTable, sqlCommand);

                        //TODO: GetColList Valid Join Query Column Name & Get affected rows Record
                        Console.WriteLine("Debug getCol | Column List check: " + colLists[0][0]);
                        Console.WriteLine(String.Format("{0}, {1}", reader[0], reader[1]));
                    }

                    //TODO: Deduction expected to be here
                    Console.WriteLine(record);
                    reader.Close();
                }
            }
                
            }
                catch(Exception e)
                {
                    Console.WriteLine("Debug JoinCheckQueryTest | " + e.Message);
                }

        }
    }
}
