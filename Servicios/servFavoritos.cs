using Proyecto_Programado_1.Database;
using Proyecto_Programado_1.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Proyecto_Programado_1.Servicios
{
    public class servFavoritos
    {
        public List<ResObtFavorito> ObtenerFavoritos(Usuario usuario)
        {
            Conexion conexion = new Conexion();

            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@CorreoUsuario", usuario.Email));

            DataTable dt = conexion.ExecuteProcedureAndFill("spObtenerFavoritos", param);

            List<ResObtFavorito> resObtFavorito = new List<ResObtFavorito>();

            foreach (DataRow row in dt.Rows)
            {
                ResObtFavorito resobtfavorito = new ResObtFavorito
                {
                    IdFav = Convert.ToInt32(row["IdFav"]),
                    Id = Convert.ToInt32(row["Id"]),
                    ISBN = row["ISBN"].ToString(),
                    ImagenPortada = row["ImagenPortada"].ToString(),
                    Titulo = row["Titulo"].ToString(),
                    Autor = row["Autor"].ToString(),
                    FechaPublicacion = Convert.ToDateTime(row["FechaPublicacion"]),
                    Precio = Convert.ToDecimal(row["Precio"].ToString()),
                };

                resObtFavorito.Add(resobtfavorito);
            }

            return resObtFavorito;
        }

        public void GuardarEnFavoritos(Favorito favorito)
        {
            Conexion conexion = new Conexion();

            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@IdLibro", favorito.IdLibro));
            param.Add(new SqlParameter("@CorreoUsuario", favorito.CorreoUsuario));

            conexion.ExecuteProcedure("spGuardarEnFavoritos", param);
        }

        public void QuitarDeFavoritos(int id)
        {
            Conexion conexion = new Conexion();

            conexion.Execute("DELETE FROM  [dbo].[Favoritos] WHERE IdFav = " + id);
        }

        public bool ConsultarFavoritoExistente(Usuario usuario, int IdLibro)
        {
            Conexion conexion = new Conexion();

            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@IdLibro", IdLibro));
            param.Add(new SqlParameter("@CorreoUsuario", usuario.Email));

            DataTable consulta = conexion.ExecuteProcedureAndFill("spEnFavoritos", param);

            List<IdFavExistente> idExistente = new List<IdFavExistente>();

            foreach (DataRow row in consulta.Rows)
            {
                IdFavExistente Idexist = new IdFavExistente
                {
                    IdFav = Convert.ToInt32(row["IdFav"]),
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
    }
}