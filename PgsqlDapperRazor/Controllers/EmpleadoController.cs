using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using PgsqlDapperRazor.Services;
using Microsoft.AspNetCore.Mvc;

namespace PgsqlDapperRazor.Controllers
{
    [Produces("application/json")]    
    public class EmpleadoController : Controller
    {
        IEmpleado empleado;
        public EmpleadoController(IEmpleado _empleado)
        {
            empleado = _empleado;
        }

        [Route("api/Empleado/{empID}")]
        public ActionResult EmpleadoDetalle(int empId)
        {
            var result = empleado.EmpleadoDetalle(empId);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("api/ListaEmpleados")]
        public ActionResult ListaEmpleados()
        {
            var result = empleado.ListaEmpleados();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        
    }
}