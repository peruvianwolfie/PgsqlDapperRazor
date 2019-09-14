using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PgsqlDapperRazor.Entities;

namespace PgsqlDapperRazor.Services
{
    public interface ICliente
    {
        List<Cliente> ListaClientes();
        Cliente ClienteDetalle(int id);
    }
}
