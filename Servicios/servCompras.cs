using Proyecto_Programado_1.Entidades;
using Proyecto_Programado_1.Database;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

namespace Proyecto_Programado_1.Servicios
{
    public class servCompras
    {
        public void GuardarCompra(Compra compra)
        {
            Conexion conexion = new Conexion();

            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@IdLibro", compra.IdLibro));
            param.Add(new SqlParameter("@CorreoUsuario", compra.CorreoUsuario));
            param.Add(new SqlParameter("@Nombre", compra.Nombre));
            param.Add(new SqlParameter("@CantidadLibros", compra.CantidadLibros));
            param.Add(new SqlParameter("@CostoLibros", compra.CostoLibros));
            param.Add(new SqlParameter("@PrecioLibro", compra.PrecioLibro));
            param.Add(new SqlParameter("@FechaCompra", compra.FechaCompra));
            param.Add(new SqlParameter("@EstadoEntrega", compra.EstadoEntrega));
            param.Add(new SqlParameter("@Pais", compra.Pais));
            param.Add(new SqlParameter("@EstadoProvincia", compra.EstadoProvincia));
            param.Add(new SqlParameter("@DireccionEntrega", compra.DireccionEntrega));
            param.Add(new SqlParameter("@CodigoPostal", compra.CodigoPostal));
            param.Add(new SqlParameter("@Numtarjeta", compra.Numtarjeta));
            param.Add(new SqlParameter("@FechaExpiracion", compra.FechaExpiracion));
            param.Add(new SqlParameter("@CodigoSeguridad", compra.CodigoSeguridad));

            conexion.ExecuteProcedure("spGuardarCompra", param);
        }

        public DataTable ObtenerCompras(Usuario usuario)
        {
            Conexion conexion = new Conexion();

            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@CorreoUsuario", usuario.Email));

            return conexion.ExecuteProcedureAndFill("spObtenerCompras", param);
        }

        public void CancelarCompra(int id)
        {
            Conexion conexion = new Conexion();

            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@Id", id));

            conexion.ExecuteProcedure("spCancelarCompra", param);
        }

        public void ActualizarEstadoCompra(int id)
        {
            Conexion conexion = new Conexion();

            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@Id", id));

            conexion.ExecuteProcedure("spActualizarEstadoCompra", param);
        }
    }
}