using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArandaPrueba.Core.DTO
{
    public class ProductosDTO
    {
        public decimal? IdProducto { get; set; }

        public string? Nombre { get; set; }

        public string? DescripcionBreve { get; set; }

        public decimal? IdCategoria { get; set; }

        public string? Categoria { get; set; }

        public byte[]? ImagenProducto { get; set; }
    }
}