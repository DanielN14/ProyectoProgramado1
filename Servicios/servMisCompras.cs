using Proyecto_Programado_1.Database;
using Proyecto_Programado_1.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Proyecto_Programado_1.Servicios
{
    public class servMisCompras
    {
        public void ModificarEstadoCompras(Usuario usuario)
        {
            Conexion conexion = new Conexion();

            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@CorreoUsuario", usuario.Email));

            DataTable dt = conexion.ExecuteProcedureAndFill("spObtenerFechaCompra", param);

            foreach (DataRow row in dt.Rows)
            {
                ObtFechaCompra fechaObt = new ObtFechaCompra
                {
                    Id = Convert.ToInt32(row["Id"]),
                    FechaCompra = Convert.ToDateTime(row["FechaCompra"])
                };

                decimal estadoEntrega= Convert.ToDecimal((DateTime.Now - fechaObt.FechaCompra).TotalDays);

                if (estadoEntrega>=1)
                {
                    servCompras servicioCompras = new servCompras();
                    servicioCompras.ActualizarEstadoCompra(fechaObt.Id);
                }
            }
        }
    }
}