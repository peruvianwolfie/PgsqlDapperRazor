using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PgsqlDapperRazor.Services;
using System.Collections.Generic;
using PgsqlDapperRazor.Entities;

namespace PgsqlDapperRazor.Pages
{
    public class ProductosModel : PageModel
    {
        IProducto _producto;
        public ProductosModel(IProducto producto)
        {
            _producto = producto;
        }
        
        [BindProperty]
        public Producto ProductoDetalle { get; set; }

        [BindProperty]
        public List<Producto> ListaProductos { get; set; }

        [TempData]
        public string Message { get; set; }

        public void OnGet()
        {
            Message = "Página cargada";

            ProductoDetalle = _producto.ProductoDetalle(1);
            ListaProductos = _producto.ListaProductos();
        }

        public void OnPost(int idProducto)
        {
            Message = $""; 
            ListaProductos = _producto.ListaProductos();
            ProductoDetalle = _producto.ProductoDetalle(idProducto);                        
        }
    }
}