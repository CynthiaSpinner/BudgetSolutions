using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetSolutions
{
    class IncomeData
    {
        string stringConnection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\cynth\Documents\expense.mdf;Integrated Security=True;Connect Timeout=30";

        public int ID { get; set; }
        public string Type { get; set; }
        public string NickName { get; set; }
        public string DepositDate { get; set; }
        public string Amount { get; set; }

        public List<IncomeData> IncomeListData()
        {
            List<IncomeData> listIncome = new List<IncomeData>();

            using (SqlConnection connect = new SqlConnection(stringConnection))
            {
                connect.Open();

                string selectIncomeData = "SELECT * FROM income";

                using (SqlCommand cmd = new SqlCommand(selectIncomeData, connect))
                {
                    SqlDataReader iReader = cmd.ExecuteReader();

                    while (iReader.Read())
                    {
                        IncomeData iData = new IncomeData();
                        iData.ID = (int)iReader["ID"];
                        iData.Type = iReader["Type"].ToString();
                        iData.NickName = iReader["name"].ToString();
                        iData.DepositDate = iReader["date"].ToString();
                        iData.Amount = iReader["amount"].ToString();
                        

                        listIncome.Add(iData);
                    }
                }
            }
            return listIncome;
        }
    }
}
