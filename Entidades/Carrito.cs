
using System;

namespace Proyecto_Programado_1.Entidades
{
    public class Carrito
    {
        public int IdCar { get; set; }
        public int IdLibro { get; set; }
        public string CorreoUsuario { get; set; }
    }

    public class ResObtCarrito
    {
        public int IdCar { get; set; }
        public int Id { get; set; }
        public string ISBN { get; set; }
        public string ImagenPortada { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public DateTime FechaPublicacion { get; set; }
        public decimal Precio { get; set; }
    }

    public class IdCarExistente
    {
        public int IdCar { get; set; }
        public int IdLibro { get; set; }
    }
}