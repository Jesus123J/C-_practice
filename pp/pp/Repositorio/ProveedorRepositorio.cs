using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pp.Repositorio
{
    public class ProveedorRepositorio : ProveedorImpl
    {
        private readonly MysqlConfiguration _connectionString;

        public ProveedorRepositorio(MysqlConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<bool> TestConnectionAsync()
        {
            try
            {
                using (var connection = new MySqlConnection(_connectionString.ConnectionString))
                {
                    await connection.OpenAsync();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        protected MySqlConnection dbConnection()
        { 
                var connection = new MySqlConnection(_connectionString.ConnectionString);

                if (connection == null)
                {
                    throw new Exception("La conexión a la base de datos es nula.");
                }

                try
                {
                    // Intentar abrir la conexión
                    connection.Open();
                }
                catch (Exception ex)
                {
                    // Aquí puedes registrar el error o manejarlo como prefieras
                    throw new Exception("No se pudo abrir la conexión a la base de datos.", ex);
                }
                finally
                {
                    // Cerrar la conexión inmediatamente después de probarla
                    connection.Close();
                }

                return connection;
        }

        

        public Task<bool> DeleteProveedor(Proveedor proveedor)
        {
            throw new NotImplementedException();
        }

        public Task<Proveedor> GetProveedor(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Proveedor>> GetProveedors()
        {
            var db = dbConnection();

            // Verificar si la conexión es nula
            if (db == null)
            {
                // Puedes lanzar una excepción o devolver un resultado vacío, dependiendo de lo que necesites
                throw new InvalidOperationException("La conexión a la base de datos es nula.");
                // O devolver un resultado vacío
                // return Enumerable.Empty<Proveedor>();
            }

            var sql = @"SELECT * FROM proveedores;";
            return await db.QueryAsync<Proveedor>(sql, new { });
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
