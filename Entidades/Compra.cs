using System;

namespace Proyecto_Programado_1.Entidades
{
    public class Compra
    {
        public int Id { get; set; }
        public int IdLibro { get; set; }
        public string CorreoUsuario { get; set; }
        public string Nombre { get; set; }
        public int CantidadLibros { get; set; }
        public decimal CostoLibros { get; set; }
        public decimal PrecioLibro { get; set; }
        public DateTime FechaCompra { get; set; }
        public string EstadoEntrega { get; set; }
        public string Pais { get; set; }
        public string EstadoProvincia { get; set; }
        public string DireccionEntrega { get; set; }
        public string CodigoPostal { get; set; }
        public string Numtarjeta { get; set; }
        public string FechaExpiracion { get; set; }
        public string CodigoSeguridad { get; set; }
    }
    public class ObtFechaCompra
    {
        public int Id { get; set; }
        public DateTime FechaCompra { get; set; }

    }
}