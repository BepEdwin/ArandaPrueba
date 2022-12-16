namespace ArandaPrueba.Core.Entities
{
    public class TbProductos
    {
        public decimal IdProducto { get; set; }

        public string? Nombre { get; set; }

        public string? DescripcionBreve { get; set; }

        public decimal IdCategoria { get; set; }

        public byte[]? ImagenProducto { get; set; }
    }
}