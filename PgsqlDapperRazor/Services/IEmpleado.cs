using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PgsqlDapperRazor.Entities;

namespace PgsqlDapperRazor.Services
{
    public interface IEmpleado
    {
        object ListaEmpleados();
        object EmpleadoDetalle(int id);
    }
}
