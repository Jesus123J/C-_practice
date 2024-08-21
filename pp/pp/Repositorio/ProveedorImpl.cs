
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pp.Repositorio
{
    public interface  ProveedorImpl
    {
        Task<bool> TestConnectionAsync();
        Task<IEnumerable<Proveedor>> GetProveedors();
        Task<Proveedor> GetProveedor(int id);
        Task<bool> InsertProveedor(Proveedor proveedor);
        Task<bool> UpdateProveedor(Proveedor proveedor);
        Task<bool> DeleteProveedor(Proveedor proveedor);
    }
}
