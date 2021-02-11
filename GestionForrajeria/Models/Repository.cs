using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GestionForrajeria.Models
{
    public class Repository
    {
        public static string DataPath = new SqliteConnectionStringBuilder()
        {
            DataSource = Path.Combine(Directory.GetCurrentDirectory()) + @"\Data\Forrajeria.db"
        }.ToString();
    }
}
