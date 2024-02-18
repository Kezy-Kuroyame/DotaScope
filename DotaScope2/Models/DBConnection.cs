using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotaScope2.Models
{
    public class DBConnection
    {
        private static string connectionString = "Host=localhost;Username=postgres;Password=kir54678199;Database=DotaScope";
        public static string ConnectionString { get { return connectionString; } }
        
        private static string connectionStringSQLitePC = "Data Source=" + Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "DotaScope.db");
        public static string ConnectionStringSQLitePC { get { return connectionStringSQLitePC; } }
        
        private static string connectionStringSQLiteAndroid = "Data Source=" + Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "DotaScope.db");
        public static string ConnectionStringSQLiteAndroid { get { return connectionStringSQLitePC; } }
    }
}
