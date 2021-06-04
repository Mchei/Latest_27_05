using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections;
using Excel = Microsoft.Office.Interop.Excel;
using System.Data.OleDb;
using JoinCheck = Latest_27_05.JoinCheck;

namespace Latest_27_05
{
    public partial class frmQueries : Form
    {
        private static frmQueries staticQueries;
        //ansChecker
        //IList<string> answerColumns = new List<string>();
        List<string> tableName;
        static List<List<string>> colList = new List<List<string>>();

        static List<string> colName1;
        static List<string> colName2;
        static List<string> colName3;
        

        //studentChecker
        List<string> stuTableName;
        List<string> stuColName;
        List<List<string>> stuColList = new List<List<string>>();
        public string QueryOne;
        public string QueryTwo;
        public string QueryThree;

        public bool QueryOneChecker = false;
        public bool QueryTwoChecker = false;
        public bool QueryThreeChecker = false;
        public bool QueryFourChecker = false;
        public bool QueryFiveChecker = false;

        //excel import
        private int rowCnt;
        List<string> QueryOneList;
        List<string> QueryTwoList;
        List<string> QueryThreeList;
        List<string> QueryFourList;
        List<string> QueryFiveList;

        List<string> IDList;

        public string sampleQueryLocation;
        public string filename;
        public string foldername;

        //Deduction
        //public List<>

        public frmQueries(string sample)
        {
            InitializeComponent();
            staticQueries = this;
            location.Text = sample;

        }
        public frmQueries()
        {
            InitializeComponent();

            tableName = new List<string>();
            colName1 = new List<string>();
            colName2 = new List<string>();
            colName3 = new List<string>();
            stuTableName = new List<string>();
            stuColName = new List<string>();
            staticQueries = this;

            //tableName = GetTables();
            //getCol();

        }
        public string ansQuery;
        public string excel_location;
        public string connectionString;
        public int studentCount;

        private void executeButton_Click(object sender, EventArgs e)
        {

            string[] ansQuery = new string[] { "query1", "query2", "query3" };
            for (int i = 0; i < ansQuery.Length; i++)
            {
                
                Control[] ansQueryTextBox = this.Controls.Find(ansQuery[i], true);
                if (filename == null && excel_location == null)
                {
                    // Sample database
                    openFileDialog1.ShowDialog();
                    filename = openFileDialog1.FileName;
                    connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + filename + ";Integrated Security=True;Connection Timeout=30;Min Pool Size=50;Max Pool Size=1000;Pooling=true;";

                    // Excel 
                    openFileDialog2.ShowDialog();
                    excel_location = openFileDialog2.FileName;
                    tableName = GetTables(connectionString);
                    if (ansSQLChecker(ansQueryTextBox[0].Text, i, connectionString) == false){
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
                else
                {
                    connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + filename + ";Integrated Security=True;Connection Timeout=30;Min Pool Size=50;Max Pool Size=1000;Pooling=true;";
                    tableName = GetTables(connectionString);
                    //getCol(connectionString);

                    //MessageBox.Show(i.ToString());
                    if (ansSQLChecker(ansQueryTextBox[0].Text, i, connectionString) == false)
                    {
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
            }

            QueryOneList = new List<string>();
            QueryTwoList = new List<string>();
            QueryThreeList = new List<string>();
            IDList = new List<string>();

            Microsoft.Office.Interop.Excel.Application ExcelObj = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook theWorkbook = ExcelObj.Workbooks.Open(@excel_location, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            Microsoft.Office.Interop.Excel.Sheets sheets = theWorkbook.Worksheets;
            Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)theWorkbook.Worksheets.get_Item(1);
            Microsoft.Office.Interop.Excel.Range range = worksheet.UsedRange;

            range = worksheet.UsedRange;
            
            for (rowCnt = 1; rowCnt <= range.Rows.Count; rowCnt++) //QueryOne Cell import from Excel;
            {
                string ID = range.Cells[rowCnt, 2].Text.ToString();
                QueryOne = (string)(range.Cells[rowCnt, 3] as Excel.Range).Value;
                QueryTwo = (string)(range.Cells[rowCnt, 4] as Excel.Range).Value;
                QueryThree = (string)(range.Cells[rowCnt, 5] as Excel.Range).Value;


                QueryOneList.Add(QueryOne);
                QueryTwoList.Add(QueryTwo);
                QueryThreeList.Add(QueryThree);
                IDList.Add(ID);

                //Console.WriteLine(ID + " -------- " + QueryOne);
                //Console.WriteLine("Row Count return: " + rowCnt.ToString());
            }
            studentCount = range.Rows.Count;
            //Console.WriteLine("Debug Button | Excel Query: " + QueryOne);
            //Console.WriteLine("Row Count return: " + rowCnt.ToString());
            for (int i = 0; i < rowCnt - 1; i++)
            {
                if(query1.TextLength > 4)
                {
                    QueryOneChecker = true;
                    //testQuery(connectionString, QueryOneList[i]);
                    //Console.WriteLine("Debug Button | Show Query List: " + QueryOneList[i]);
                    if (StuSQLChecker(QueryOneList[i], i+
                        1, connectionString))
                    {
                        //Console.WriteLine("Debug Button | Query Passed: " + QueryOneList[i]);
                        //Console.WriteLine("Debug Button | Query Passed: " + String.Join(", ", colList[0]));
                    }
                    else
                    {
                        //Console.WriteLine("Debug Button | Query Failed: " + String.Join(", ", stuColName)); //show student is wrong
                        //Console.WriteLine("Debug Button | Answer Query Check: " + String.Join(", ", colList[0]));
                        //Console.WriteLine("Debug Button | Excel Query Failed: " + QueryOne);
                    }
                    //exportDialog.ShowDialog();
                    //foldername = exportDialog.SelectedPath;
                    //ListToExcel(QueryOneList);
                }
                else
                {
                    QueryOneChecker = false;
                    QueryTwoChecker = false;
                    QueryThreeChecker = false;
                    return;
                }


            }
            for (int i = 0; i < rowCnt - 1; i++)
            {
                if (query2.TextLength > 4)
                {
                    QueryOneChecker = false;
                    QueryTwoChecker = true;
                    //Console.WriteLine("Debug Button | Show Query List: " + QueryTwoList[i]);
                    if (StuSQLChecker(QueryTwoList[i], i+1, connectionString))
                    {
                        //Console.WriteLine("Debug Button | Query Passed: " + QueryTwoList[i]);
                        Console.WriteLine("Debug Button | Query Passed: " + String.Join(", ", colList[1]));
                    }
                    else
                    {
                        Console.WriteLine("Debug Button | Query Failed: " + String.Join(", ", stuColName)); //show student is wrong
                        //Console.WriteLine("Debug Button | Answer Query Check: " + String.Join(", ", colList[1]));
                        //Console.WriteLine("Debug Button | Excel Query Failed: " + QueryTwo);
                    }
                }
                else
                {
                    QueryOneChecker = false;
                    QueryTwoChecker = false;
                    QueryThreeChecker = false;
                    return;
                }


            }
            for (int i = 0; i < rowCnt - 1; i++)
            {
                if (query3.TextLength > 4)
                {
                    QueryOneChecker = false;
                    QueryTwoChecker = false;
                    QueryThreeChecker = true;
                    //Console.WriteLine("Debug Button | Show Query List: " + QueryThreeList[i]);
                    if (StuSQLChecker(QueryThreeList[i], i+1, connectionString))
                    {
                        //Console.WriteLine("Debug Button | Query Passed: " + QueryThree);
                        Console.WriteLine("Debug Button | Query Passed: " + String.Join(", ", colList[2]));
                    }
                    else
                    {
                        Console.WriteLine("Debug Button | Query Failed: " + String.Join(", ", stuColName)); //show student is wrong
                        //Console.WriteLine("Debug Button | Answer Query Check: " + String.Join(", ", colList[2]));
                        //Console.WriteLine("Debug Button | Excel Query Failed: " + QueryThree);
                    }
                }
                else
                {
                    QueryOneChecker = false;
                    QueryTwoChecker = false;
                    QueryThreeChecker = false;
                    return;
                }

            }

            Properties.Settings.Default.query1 = query1.Text;
            Properties.Settings.Default.query2 = query2.Text;
            Properties.Settings.Default.query3 = query3.Text;
            filename = Properties.Settings.Default.Sample_location;
            excel_location = Properties.Settings.Default.Excel_location;
            Properties.Settings.Default.Save();
            theWorkbook.Close(0);


        }
        public int numberOfRecords;
        public bool StuSQLChecker(string sql, int num, string connectionString)
        {
            //SELECT * FROM Account;
            if (!sql.Equals("", StringComparison.OrdinalIgnoreCase))
            {
                List<string> sqlPart = new List<string>();
                //sql = sql.Replace(";", ""); //delete ; 
                sqlPart = sql.Split(' ').ToList();
                //
                // SELECT username,userId,password FROM Account;
                //  [0]    [1]                      [2]    [3]  
                // check columnName and *
                // also check column Name

                //check sql select
                //root.Equals(root2, StringComparison.OrdinalIgnoreCase);
                //https://docs.microsoft.com/en-us/dotnet/csharp/how-to/compare-strings
                if (!sqlPart[0].Equals("select", StringComparison.OrdinalIgnoreCase) && !sqlPart[0].Equals("update", StringComparison.OrdinalIgnoreCase) && !sqlPart[0].Equals("delete", StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("Ans Query " + num + " | Choose from select, update, delete", "Error Message", MessageBoxButtons.OK);
                    return false;
                }

                // check if columnName exist in colName list<string>
                List<string> sqlColumnName = new List<string>();
                sqlColumnName = sqlPart[1].Split(',').ToList();
                bool columnNameExist = true;    //
                for (int i = 0; i < sqlColumnName.Count; i++)
                {
                    // check exist
                    if (colName1.Contains(sqlColumnName[i]) == false)    //
                    {
                        columnNameExist = false;
                    }
                }


                if (!sqlPart[1].Equals("*", StringComparison.OrdinalIgnoreCase) && columnNameExist == false)
                {
                    MessageBox.Show("Ans Query " + num + " | Column Name is wrong, not exist or Spelling error?", "Error Message", MessageBoxButtons.OK);
                    return false;
                }


                if (!sqlPart[2].Equals("from", StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("Ans Query  " + num + " | From wrong (may have a space?)", "Error Message", MessageBoxButtons.OK);
                    return false;
                }


                // check if table Name exist in tableName list<string>         

                // check exist
                if (tableName.Contains(sqlPart[3]) == false)
                {
                    MessageBox.Show("Ans Query  " + num + " | Tablename wrong, not exist or Spelling error?", "Error Message", MessageBoxButtons.OK);
                    return false;
                }


                // check groupby or orderby
                // SELECT * FROM Account GROUP BY username;
                //  [0]  [1] [2]   [3]    [4]  [5]   [6]

                if (sqlPart.Count > 4)
                {
                    // check whether is group by or order by or not
                    if (sqlPart[4].Equals("group", StringComparison.OrdinalIgnoreCase) || sqlPart[4].Equals("order", StringComparison.OrdinalIgnoreCase))
                    {
                        if (sqlPart[5].Equals("by", StringComparison.OrdinalIgnoreCase))
                        {
                            // check column Name
                            // check exist
                            if (colName1.Contains(sqlPart[6]) == false)
                            {
                                MessageBox.Show("Query " + num + " | Group/order by column name is not exist.", "Error Message", MessageBoxButtons.OK);
                                return false;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Query " + num + " | Group/order by is wrong.", "Error Message", MessageBoxButtons.OK);
                            return false;
                        }

                    }
                    else if (sqlPart[4].Equals("where", StringComparison.OrdinalIgnoreCase))
                    {
                        // SELECT * FROM Account WHERE userId = 'Mexico';
                        //  [0]  [1] [2]   [3]    [4]   [5]  [6]   [7]
                        // check column Name
                        // check exist
                        if (colName1.Contains(sqlPart[5]) == false)
                        {
                            MessageBox.Show("Query " + num + " | Where column name is not exist", "Error Message", MessageBoxButtons.OK);
                            return false;
                        }
                        else
                        {
                            // find the column name successful
                            // check =
                            if (!sqlPart[6].Equals("=", StringComparison.OrdinalIgnoreCase) && !sqlPart[6].Equals("!=", StringComparison.OrdinalIgnoreCase))
                            {
                                MessageBox.Show("Query " + num + " | = is wrong", "Error Message", MessageBoxButtons.OK);
                                return false;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Query " + num + " | Where/group by/order by is wrong", "Error Message", MessageBoxButtons.OK);
                        return false;
                    }
                }

                stuTableName = GetTables(connectionString);
                getStudentCol(connectionString, stuTableName, sql);

                if (QueryOneChecker == true)  //hard coding 
                {
                    int correct = 1;
                    for (int i = 0; i < colList[0].Count; i++)
                    {
                        string ansColNameString;
                        ansColNameString = colList[0][i];
                        //Console.WriteLine("DeBug | ColName [i] Output: " + ansColNameString);
                        //Console.WriteLine("DeBug | ColName [i] Output: " + colName1.Count.ToString());
                        //Console.WriteLine("DeBug | StudentColName [i] Output: " + stuColName[i]);
                        //Console.WriteLine("DeBug | StudentColName [i] Output: " + stuColName.Count.ToString());

                        if (stuColName[i].Contains(ansColNameString) && stuColName.Count == colList[0].Count)
                        {
                            //Console.WriteLine("DeBug StuSQLChecker | StudentCol Contain AnsCol: " + stuColName[i]);
                            correct++;
                        }
                        else if (correct == i)
                        {
                            Console.WriteLine("DeBug StuSQLChecker | Student Query " + num + " | Column count and Column name passed.");
                            return true;
                        }
                        else
                        {
                            Console.WriteLine("DeBug StuSQLChecker | Student Query " + num + " Matched the Answer Query Count BUT does not matched the Answer Query.");
                            return false;
                        }
                    }
                    //Console.WriteLine("Debug | Student Query " + num + " | No error :)");
                    return true;
                }
                else if (QueryTwoChecker == true)
                {
                    int correct = 1;
                    for (int i = 0; i < colList[1].Count; i++)
                    {
                        string ansColNameString;
                        ansColNameString = colList[1][i];
                        //Console.WriteLine("DeBug | ColName [i] Output: " + ansColNameString);
                        //Console.WriteLine("DeBug | ColName [i] Output: " + colName1.Count.ToString());
                        //Console.WriteLine("DeBug | StudentColName [i] Output: " + stuColName[i]);
                        //Console.WriteLine("DeBug | StudentColName [i] Output: " + stuColName.Count.ToString());

                        if (stuColName[i].Contains(ansColNameString) && stuColName.Count == colList[1].Count)
                        {
                            //Console.WriteLine("DeBug StuSQLChecker | StudentCol Contain AnsCol: " + stuColName[i]);
                            correct++;
                        }
                        else if (correct == i)
                        {
                            Console.WriteLine("DeBug StuSQLChecker | Student Query " + num + " | Column count and Column name passed.");
                            return true;
                        }
                        else
                        {
                            Console.WriteLine("DeBug StuSQLChecker | Student Query " + num + " Matched the Answer Query Count BUT does not matched the Answer Query.");
                            return false;
                        }
                    }
                    //Console.WriteLine("Debug | Student Query " + num + " | No error :)");
                    return true;
                }
                else if (QueryThreeChecker == true)
                {
                    int correct = 1;
                    for (int i = 0; i < colList[2].Count; i++)
                    {
                        string ansColNameString;
                        ansColNameString = colList[2][i];
                        //Console.WriteLine("DeBug | ColName [i] Output: " + ansColNameString);
                        //Console.WriteLine("DeBug | ColName [i] Output: " + colName1.Count.ToString());
                        //Console.WriteLine("DeBug | StudentColName [i] Output: " + stuColName[i]);
                        //Console.WriteLine("DeBug | StudentColName [i] Output: " + stuColName.Count.ToString());

                        if (stuColName[i].Contains(ansColNameString) && stuColName.Count == colList[2].Count)
                        {
                            //Console.WriteLine("DeBug StuSQLChecker | StudentCol Contain AnsCol: " + stuColName[i]);
                            correct++;
                        }
                        else if (correct == i)
                        {
                            Console.WriteLine("DeBug StuSQLChecker | Student Query " + num + " | Column count and Column name passed.");
                            return true;
                        }
                        else
                        {
                            Console.WriteLine("DeBug StuSQLChecker | Student Query " + num + " Matched the Answer Query Count BUT does not matched the Answer Query.");
                            return false;
                        }
                    }
                    //Console.WriteLine("Debug | Student Query " + num + " | No error :)");
                    return true;
                }
                else
                {
                    Console.WriteLine("Debug StuSQLChecker | Student SQL Check Returned False& did not run Compare.");
                    return false;
                }
            }
            return false;  
        }



        public bool ansSQLChecker(string sql, int num, string connectionString) //Basic SQL Select checker -- version 1.0 of checker
            {
            JoinCheck.JoinCheckQuery(connectionString, sql);
            JoinCheck.JoinCheckQueryTest(connectionString);

            //SELECT * FROM Account;
            if (!sql.Equals("", StringComparison.OrdinalIgnoreCase))
            {
                List<string> sqlPart = new List<string>();
                sql = sql.Replace(";", ""); //delete ; 
                sqlPart = sql.Split(' ').ToList();//

                //check sql select
                //root.Equals(root2, StringComparison.OrdinalIgnoreCase);
                //https://docs.microsoft.com/en-us/dotnet/csharp/how-to/compare-strings
                if (!sqlPart[0].Equals("select", StringComparison.OrdinalIgnoreCase) &&!sqlPart[0].Equals("update", StringComparison.OrdinalIgnoreCase) && !sqlPart[0].Equals("delete", StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("Ans Query " + num + " | Choose from select, update, delete", "Error Message", MessageBoxButtons.OK);
                    return false;
                }


                // SELECT username,userId,password FROM Account;
                //  [0]    [1]                      [2]    [3]  
                // check columnName and *
                // also check column Name

                // kill all space inside sqlPart[1]
                // TODO: kill all space
                sqlPart[1] = sqlPart[1].Replace(" ", "");

                // check if columnName exist in colName list<string>
                List<string> sqlColumnName = new List<string>();
                sqlColumnName = sqlPart[1].Split(',').ToList();
                bool columnNameExist = true;    //
                for (int i = 0; i < sqlColumnName.Count; i++)
                {
                    // check exist
                    if (colName1.Contains(sqlColumnName[i]) == false)    //
                    {
                        columnNameExist = false;
                    }
                }


                if (!sqlPart[1].Equals("*", StringComparison.OrdinalIgnoreCase) && columnNameExist == false)
                {
                    MessageBox.Show("Ans Query " + num + " | Column Name is wrong, not exist or Spelling error?", "Error Message", MessageBoxButtons.OK);
                    return false;
                }


                if (!sqlPart[2].Equals("from", StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("Ans Query  " + num + " | From wrong (may have a space?)", "Error Message", MessageBoxButtons.OK);
                    return false;
                }


                // check if table Name exist in tableName list<string>         

                // check exist
                if (tableName.Contains(sqlPart[3]) == false)
                {
                    MessageBox.Show("Ans Query  " + num + " | Tablename wrong, not exist or Spelling error?", "Error Message", MessageBoxButtons.OK);
                    return false;
                }


                // check groupby or orderby
                // SELECT * FROM Account GROUP BY username;
                //  [0]  [1] [2]   [3]    [4]  [5]   [6]

                if (sqlPart.Count > 4)
                {
                    // check whether is group by or order by or not
                    if (sqlPart[4].Equals("group", StringComparison.OrdinalIgnoreCase) || sqlPart[4].Equals("order", StringComparison.OrdinalIgnoreCase))
                    {
                        if (sqlPart[5].Equals("by", StringComparison.OrdinalIgnoreCase))
                        {
                            // check column Name
                            // check exist
                            if (colName1.Contains(sqlPart[6]) == false)
                            {
                                MessageBox.Show("Query " + num + " | Group/order by column name is not exist.", "Error Message", MessageBoxButtons.OK);
                                return false;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Query " + num + " | Group/order by is wrong.", "Error Message", MessageBoxButtons.OK);
                            return false;
                        }

                    }
                    else if (sqlPart[4].Equals("where", StringComparison.OrdinalIgnoreCase))
                    {
                        // SELECT * FROM Account WHERE userId = 'Mexico';
                        //  [0]  [1] [2]   [3]    [4]   [5]  [6]   [7]
                        // check column Name
                        // check exist
                        if (colName1.Contains(sqlPart[5]) == false)
                        {
                            MessageBox.Show("Query " + num + " | Where column name is not exist", "Error Message", MessageBoxButtons.OK);
                            return false;
                        }
                        else
                        {
                            // find the column name successful
                            // check =
                            if (!sqlPart[6].Equals("=", StringComparison.OrdinalIgnoreCase) && !sqlPart[6].Equals("!=", StringComparison.OrdinalIgnoreCase))
                            {
                                MessageBox.Show("Query " + num + " | = is wrong", "Error Message", MessageBoxButtons.OK);
                                return false;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Query " + num + " | Where/group by/order by is wrong", "Error Message", MessageBoxButtons.OK);
                        return false;
                    }
                }


                tableName = GetTables(connectionString);
                getCol(connectionString, tableName, sql);
                
                
                Console.WriteLine("Ans Query: " + num + " | No error :)");
                return true;
            }
            return false;
        }

        public static List<string> GetTables(string connectionString) //Method to Get All Table
        {
            
            //Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\jeffe\Source\Repos\Mchei\SQLChecker2021\SQLChecker2021\SQLProjectDB.mdf;Integrated Security=True
            string startupPath = System.IO.Directory.GetCurrentDirectory();

            //string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\jeffe\Source\Repos\Mchei\SQLChecker2021\SQLChecker2021\SQLProjectDB.mdf;Integrated Security=True";
            //string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + startupPath + "\\SQLProjectDB.mdf;Integrated Security=True";
            //connectionString = connectionString.Replace("\\bin\\Debug", "");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                DataTable schema = connection.GetSchema("Tables");
                List<string> TableNames = new List<string>();
                foreach (DataRow row in schema.Rows)
                {
                    TableNames.Add(row[2].ToString());
                    //Console.WriteLine("row[2].ToString(): " + row[2].ToString());
                }
                connection.Close();
                return TableNames;
            }
        }
        public static List<List<string>> getCol(string connectionString, List<string> ansTable, string sqlCommand) //Method to Return Columns Name and Number
        {
            DataTable schema = null;

            if (colName1.Count == 0) 
            {
                staticQueries.query1.Enabled = false;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    var schemaCommand = new SqlCommand(sqlCommand, connection);
                    connection.Open();
                    var reader = schemaCommand.ExecuteReader(CommandBehavior.SchemaOnly);
                    schema = reader.GetSchemaTable();

                            foreach (DataRow col in schema.Rows)
                            {
                                colName1.Add(col.Field<String>("ColumnName"));
                            }
                    connection.Close();
                    colList.Add(colName1);
                    return colList;
                            //Console.WriteLine("Debug getCol | Column subList check: " + String.Join(", ", colName1));
                            //Console.WriteLine("Debug getCol | Column List check: " + colList[0][0]);
                }
            }
            else{
                Console.WriteLine("Debug getCol | ColName1={0}", String.Join(", ", colName1));
                Console.WriteLine("Debug getCol | ColName2={0}", String.Join(", ", colName2));
                Console.WriteLine("Debug getCol | ColName2={0}", String.Join(", ", colName3));
                return colList;
            }   
        }

        public static List<string> GetStudentTables(string connectionString, string table)
        {

            //Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\jeffe\Source\Repos\Mchei\SQLChecker2021\SQLChecker2021\SQLProjectDB.mdf;Integrated Security=True
            string startupPath = System.IO.Directory.GetCurrentDirectory();

            //string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\jeffe\Source\Repos\Mchei\SQLChecker2021\SQLChecker2021\SQLProjectDB.mdf;Integrated Security=True";
            //string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + startupPath + "\\SQLProjectDB.mdf;Integrated Security=True";
            //connectionString = connectionString.Replace("\\bin\\Debug", "");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                DataTable schema = connection.GetSchema("Tables");
                List<string> stuTableNames = new List<string>();
                foreach (DataRow row in schema.Rows)
                {
                    stuTableNames.Add(row[2].ToString());

                    //Console.WriteLine("row[2].ToString(): " + row[2].ToString());
                }
                connection.Close();
                return stuTableNames;
            }
        }


        public void getStudentCol(string connectionString, List<string> stuTable, string sqlCommand)
        {
            DataTable schema = null;
            if (stuColName.Count == 0)
            {

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (var schemaCommand = new SqlCommand(sqlCommand, connection))
                    {
                        connection.Open();
                        using (var reader = schemaCommand.ExecuteReader(CommandBehavior.SchemaOnly))
                        {
                            
                            schema = reader.GetSchemaTable();
                            foreach (DataRow col in schema.Rows)
                            {
                                stuColName.Add(col.Field<String>("ColumnName"));
                                //Console.WriteLine("Debug getStudentCol | Column check: " + String.Join(", ", stuColName));
                            }
                            this.stuColList.Add(stuColName);

                            //numberOfRecords = insertColReturn(connectionString, null);
                            getColSingle(connectionString, sqlCommand);
                            //testQuery(connectionString, sqlCommand);


                            Console.WriteLine("Debug getCol | getColSingle: " + numberOfRecords);
                            //Console.WriteLine("Debug | Column subList check: " + String.Join(", ", stuColName));
                            //Console.WriteLine("Debug | Student Column List check: " + stuColList[0][0]);
                            connection.Close();
                        }
                    }
                }
            }
            else
            {
                stuColName.Clear();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (var schemaCommand = new SqlCommand(sqlCommand, connection))
                    {
                        connection.Open();
                        using (var reader = schemaCommand.ExecuteReader(CommandBehavior.SchemaOnly))
                        {
                            schema = reader.GetSchemaTable();
                            foreach (DataRow col in schema.Rows)
                            {
                                stuColName.Add(col.Field<String>("ColumnName"));
                                //Console.WriteLine("Debug getStudentCol | Column check: " + String.Join(", ", stuColName));
                            }
                            this.stuColList.Add(stuColName);
                            connection.Close();
                            //Console.WriteLine("Debug | Column subList check: " + String.Join(", ", stuColName));
                            //Console.WriteLine("Debug | Student Column List check: " + stuColList[0][0]);

                        }
                    }
                }
            }




        }

        public void getColSingle(string connectionString, string sqlCommand)
        {
            try
            {
                DataTable schema = null;
                SqlConnection connection = new SqlConnection(connectionString);
                string sql = "Select Avg(userId) From Account";
                SqlCommand comd = new SqlCommand(sql, connection);
                connection.Open();
                numberOfRecords = Convert.ToInt32(comd.ExecuteScalar());
            }
            catch(Exception e)
            {
                Console.WriteLine("Debug | getColSingle: " + e.Message);
            }
        }

        private void location_TextChanged(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void query1_TextChanged(object sender, EventArgs e)
        {

        }
        private void frmQueries_FormClosed(object sender, FormClosedEventArgs e)
        {
            Properties.Settings.Default.query1 = query1.Text;
            Properties.Settings.Default.query2 = query2.Text;
            Properties.Settings.Default.query3 = query3.Text;
            Properties.Settings.Default.Save();
            //Properties.Settings.Default.Sample_location = query1.Text;
            //Properties.Settings.Default.Excel_location = query1.Text;
        }

        private void frmQueries_FormLoad(object sender, EventArgs e)
        {
            query1.Text = Properties.Settings.Default.query1;
            query2.Text = Properties.Settings.Default.query2;
            query3.Text = Properties.Settings.Default.query3;
            filename = Properties.Settings.Default.Sample_location;
            excel_location = Properties.Settings.Default.Excel_location;

        }

        private void reset_Click(object sender, EventArgs e)
        {
            query1.Enabled = true;
            query2.Enabled = true;
            query3.Enabled = true;
            query4.Enabled = true;
            query5.Enabled = true;
            query6.Enabled = true;
            query7.Enabled = true;
            query8.Enabled = true;
            query9.Enabled = true;
            query10.Enabled = true;
            query11.Enabled = true;
            query12.Enabled = true;
            query13.Enabled = true;
            query14.Enabled = true;
            query15.Enabled = true;
            colName1.Clear();
            colName2.Clear();
            colName3.Clear();

        }
        public void ListToExcel(List<string> list)
        {

        }

        private void loadButton_Click(object sender, EventArgs e)
        {
                       
            frmLoad f2 = new frmLoad();
            f2.ShowDialog(); // Shows Form2
        }

        private void query2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
