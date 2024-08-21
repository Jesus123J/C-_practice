using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoStore.data
{
    public  class MysqlConfiguration
    {
        private MySqlConfiguration connectionString;

        public MysqlConfiguration(string connectionString) {
            ConnectionString = ConnectionString;
        }

        public string ConnectionString { get; set; }    
    }
}
