using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotaScope2.Models
{
    public class DBConnection
    {
        private static string connectionString = "Host=localhost;Username=postgres;Password=kir54678199;Database=DotaScopeBD";
        public static string ConnectionString { get { return connectionString; } }
    }
}
