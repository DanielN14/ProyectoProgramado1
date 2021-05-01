using Proyecto_Programado_1.Database;
using Proyecto_Programado_1.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Proyecto_Programado_1.Servicios
{
    public class servCarrito
    {
        public List<ResObtCarrito> ObtenerTCarrito(Usuario usuario)
        {
            Conexion conexion = new Conexion();

            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@CorreoUsuario", usuario.Email));

            DataTable dt = conexion.ExecuteProcedureAndFill("spObtenerCarrito", param);

            List<ResObtCarrito> respObtCarrito = new List<ResObtCarrito>();

            foreach (DataRow row in dt.Rows)
            {
                ResObtCarrito resObtCarrito = new ResObtCarrito
                {
                    IdCar = Convert.ToInt32(row["IdCar"]),
                    Id = Convert.ToInt32(row["Id"]),
                    ISBN = row["ISBN"].ToString(),
                    ImagenPortada = row["ImagenPortada"].ToString(),
                    Titulo = row["Titulo"].ToString(),
                    Autor = row["Autor"].ToString(),
                    FechaPublicacion = Convert.ToDateTime(row["FechaPublicacion"]),
                    Precio = Convert.ToDecimal(row["Precio"].ToString()),
                };

                respObtCarrito.Add(resObtCarrito);
            }

            return respObtCarrito;
        }

        public bool ConsultarCarritoExistente(Usuario usuario, int IdLibro)
        {
            Conexion conexion = new Conexion();

            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@IdLibro", IdLibro));
            param.Add(new SqlParameter("@CorreoUsuario", usuario.Email));

            DataTable consulta = conexion.ExecuteProcedureAndFill("spEnCarrito", param);


            List<IdCarExistente> idExistente = new List<IdCarExistente>();

            foreach (DataRow row in consulta.Rows)
            {
                IdCarExistente Idexist = new IdCarExistente
                {
                    IdCar = Convert.ToInt32(row["IdCar"]),
                    IdLibro = Convert.ToInt32(row["IdLibro"]),
                };

                idExistente.Add(Idexist);
            }

            if (idExistente.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        internal object ObtenerFavoritos(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public void GuardarEnCarrito(Carrito carrito)
        {
            Conexion conexion = new Conexion();

            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@IdLibro", carrito.IdLibro));
            param.Add(new SqlParameter("@CorreoUsuario", carrito.CorreoUsuario));

            conexion.ExecuteProcedure("spGuardarEnCarrito", param);
        }

        public void QuitarDeCarrito(int id)
        {
            Conexion conexion = new Conexion();

            conexion.Execute("DELETE FROM  [dbo].[Carrito] WHERE IdCar = " + id);
        }
    }
}