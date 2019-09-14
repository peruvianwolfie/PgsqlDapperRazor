using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PgsqlDapperRazor.Services;
using PgsqlDapperRazor.Entities;

namespace PgsqlDapperRazor.Pages
{
    public class ClientesModel : PageModel
    {
        ICliente _cliente;
        public ClientesModel(ICliente cliente)
        {
            _cliente = cliente;
        }
        [BindProperty]
        public List<Cliente> ListaClientes { get; set; }

        [BindProperty]
        public Cliente ClienteDetalle{ get; set; }

        [TempData]
        public string Message { get; set; }
        public void OnGet()
        {
            Message = "Página cargada";
            
            ClienteDetalle = _cliente.ClienteDetalle(1);
            ListaClientes = _cliente.ListaClientes();
        }
    }
}