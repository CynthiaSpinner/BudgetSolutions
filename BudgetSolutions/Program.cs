using System;
using System.IO;
using System.Configuration;
using System.Windows.Forms;

namespace BudgetSolutions
{
    internal static class Program
    {
        public static string ConnectionString { get; private set; }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            string appDataPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "BudgetSolutions"
            );

            string dbPath = Path.Combine(appDataPath, "budget.mdf");

            if (!Directory.Exists(appDataPath))
                Directory.CreateDirectory(appDataPath);

            ConnectionString = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={dbPath};Integrated Security=True;Connect Timeout=30";

            if (!File.Exists(dbPath))
                DatabaseSetup.Initialize(dbPath, ConnectionString);

            Application.Run(new Form1());
        }
    }
}
