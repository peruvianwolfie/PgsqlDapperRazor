using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PgsqlDapperRazor.Entities;

namespace PgsqlDapperRazor.Services
{
    public interface IProducto
    {
        List<Producto> ListaProductos();
        Producto ProductoDetalle(int id);        
    }
}
