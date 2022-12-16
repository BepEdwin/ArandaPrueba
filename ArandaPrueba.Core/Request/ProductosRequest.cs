using Microsoft.AspNetCore.Http;

namespace ArandaPrueba.Core.Request
{
    public class ProductosRequest
    {
        public string? Nombre { get; set; }

        public string? DescripcionBreve { get; set; }

        public decimal IdCategoria { get; set; }

        public string? ImagenB64 { get; set; }
    }
}