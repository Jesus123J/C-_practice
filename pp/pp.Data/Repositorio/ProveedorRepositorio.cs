using Dapper;
using MySql.Data.MySqlClient;
using pp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pp.Data.Repositorio
{
    public class ProveedorRepositorio : ProveedorImpl
    {
        private readonly MysqlConfiguration _connectionString;

        public ProveedorRepositorio(MysqlConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }

        public Task<bool> DeleteProveedor(Proveedor proveedor)
        {
            throw new NotImplementedException();
        }

        public Task<Proveedor> GetProveedor(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Proveedor>> GetProveedors()
        {
            var db = dbConnection();
            var sql = @"SELECT * FROM proveedor WHERE id = @Id;";
            return db.QueryAsync<Proveedor>(sql, new { });
        }

        public Task<bool> InsertProveedor(Proveedor proveedor)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateProveedor(Proveedor proveedor)
        {
            throw new NotImplementedException();
        }
    }
}
