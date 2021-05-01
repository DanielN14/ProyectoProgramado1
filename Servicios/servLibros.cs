using System;
using System.Collections.Generic;
using Proyecto_Programado_1.Entidades;
using Proyecto_Programado_1.Database;
using System.Data;
using System.Data.SqlClient;

namespace Proyecto_Programado_1.Servicios
{
    public class servLibros
    {
        public List<Libro> ObtenerLibros()
        {
            Conexion conexion = new Conexion();

            DataTable dt = conexion.ExecuteProcedureAndFill("spObtenerLibros", null);

            List<Libro> Libros = new List<Libro>();

            foreach (DataRow row in dt.Rows)
            {
                Libro libro = new Libro
                {
                    Id = Convert.ToInt32(row["Id"]),
                    ISBN = row["ISBN"].ToString(),
                    ImagenPortada = row["ImagenPortada"].ToString(),
                    Titulo = row["Titulo"].ToString(),
                    Autor = row["Autor"].ToString(),
                    FechaPublicacion = Convert.ToDateTime(row["FechaPublicacion"]),
                    Precio = Convert.ToDecimal(row["Precio"].ToString()),
                };

                Libros.Add(libro);
            }

            return Libros;
        }

        public List<Libro> ObtenerLibro(int idLibro)
        {
            Conexion conexion = new Conexion();

            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@Id", idLibro));

            DataTable dt = conexion.ExecuteProcedureAndFill("spObtenerLibro", param);

            List<Libro> libros = new List<Libro>();

            foreach (DataRow row in dt.Rows)
            {
                Libro libro = new Libro
                {
                    Id = Convert.ToInt32(row["Id"]),
                    ISBN = row["ISBN"].ToString(),
                    ImagenPortada = row["ImagenPortada"].ToString(),
                    Titulo = row["Titulo"].ToString(),
                    Autor = row["Autor"].ToString(),
                    FechaPublicacion = Convert.ToDateTime(row["FechaPublicacion"]),
                    Precio = Convert.ToDecimal(row["Precio"].ToString()),
                };

                libros.Add(libro);
            }

            return libros;
        }

        public List<Libro> BuscarLibro(string ISBN_Titulo)
        {
            Conexion conexion = new Conexion();

            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@ISBN_Titulo", ISBN_Titulo));

            DataTable dt = conexion.ExecuteProcedureAndFill("spBusquedaLibro", param);

            List<Libro> libros = new List<Libro>();

            foreach (DataRow row in dt.Rows)
            {
                Libro libro = new Libro
                {
                    Id = Convert.ToInt32(row["Id"]),
                    ISBN = row["ISBN"].ToString(),
                    ImagenPortada = row["ImagenPortada"].ToString(),
                    Titulo = row["Titulo"].ToString(),
                    Autor = row["Autor"].ToString(),
                    FechaPublicacion = Convert.ToDateTime(row["FechaPublicacion"]),
                    Precio = Convert.ToDecimal(row["Precio"].ToString()),
                };

                libros.Add(libro);
            }
            return libros;
        }
    }
}