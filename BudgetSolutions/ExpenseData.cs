using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BudgetSolutions
{
    class ExpenseData
    {
        string stringConnection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\cynth\Documents\expense.mdf;Integrated Security=True;Connect Timeout=30";

        public int ID { get; set; }
        public string Category { get; set; }
        public string Type { get; set; }
        public string NickName { get; set; }
        public string DueDate { get; set; }
        public string Amount { get; set; }
        public string Grace { get; set; }
        public string LateFee { get; set; }
        public string PassedDue { get; set; }
        public string PassedAmount { get; set; }
        public string Credit { get; set; }


        public List<ExpenseData> ExpenseListData()
        {
            List<ExpenseData> listExpense = new List<ExpenseData>();

            using (SqlConnection connect = new SqlConnection(stringConnection))
            {
                connect.Open();

                string selectExpenseData = "SELECT * FROM expenses";

                using(SqlCommand cmd = new SqlCommand(selectExpenseData, connect))
                {
                    SqlDataReader eReader = cmd.ExecuteReader();

                    while(eReader.Read())
                    {
                        ExpenseData eData = new ExpenseData();
                        eData.ID = (int)eReader["ID"]; //0
                        eData.Category = eReader["category"].ToString(); //1
                        eData.Type = eReader["Type"].ToString(); //2
                        eData.NickName = eReader["name"].ToString(); //3
                        eData.DueDate = ((DateTime)eReader["date"]).ToString("MM-dd-yyyy"); //4
                        eData.Amount = eReader["amount"].ToString(); //5
                        eData.Grace = eReader["grace"].ToString(); //6
                        eData.LateFee = eReader["lateFee"].ToString(); //7
                        eData.PassedDue = eReader["passed"].ToString(); //8
                        eData.PassedAmount = eReader["passedAmount"].ToString(); //9
                        eData.Credit = eReader["creditIssue"].ToString(); //10

                        listExpense.Add(eData);
                    }
                }
            }
            return listExpense;
        }
    }
}
