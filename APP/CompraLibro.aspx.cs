using Proyecto_Programado_1.Entidades;
using Proyecto_Programado_1.Servicios;
using System;
using System.Collections.Generic;
using System.Web.UI;

namespace Proyecto_Programado_1.APP
{
    public partial class CompraLibro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Usuario usuario = (Usuario)Session["usuario"];
                if (usuario == null)
                {
                    Response.Redirect("Login.aspx");
                }

                servLibros servicioLibros = new servLibros();
                int idLibro = Convert.ToInt32(Request.QueryString["idLibro"]);
                List<Libro> libroEncontrado = servicioLibros.ObtenerLibro(idLibro);

                if (libroEncontrado != null)
                {
                    repLibro.DataSource = libroEncontrado;
                    repLibro.DataBind();
                }
                else
                {
                    lblMensaje.Visible = true;
                    lblMensaje.Text = "No se encontro el Libro con el ID " + idLibro;
                }

                GenerarCalculosCompra(idLibro, libroEncontrado[0].Precio, Convert.ToInt16(DDCantLibros.SelectedValue));
            }
        }

        protected void btnComprar_Click(object sender, EventArgs e)
        {
            try
            {
                Compra compra = (Compra)Session["compra"];

                servCompras serv = new servCompras();

                serv.GuardarCompra(compra);

                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "mostrarMensaje('Compra realizada correctamente');", true);
            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "mostrarMensaje('Error al intentar realizar la compra');", true);
            }
        }

        public void GenerarCalculosCompra(int IdLibro, decimal precio, int cantLibros)
        {
            string fechaExp = selectMesExp.Value + "/" + selectAnoExp.Value;

            decimal costLibros = cantLibros * precio;

            Usuario usuario = (Usuario)Session["usuario"];

            Compra compra = new Compra()
            {
                Id = 1,
                IdLibro = IdLibro,
                CorreoUsuario = usuario.Email,
                Nombre = usuario.DisplayName,
                CantidadLibros = cantLibros,
                CostoLibros = costLibros,
                PrecioLibro = precio,
                FechaCompra = DateTime.Now,
                EstadoEntrega = "Pendiente",
                Pais = txtPais.Value,
                EstadoProvincia = txtEstadoProvincia.Value,
                DireccionEntrega = txtDireccionEntrega.Value,
                CodigoPostal = txtCodigoPostal.Value,
                Numtarjeta = txtNumTarjeta.Value,
                FechaExpiracion = fechaExp,
                CodigoSeguridad = txtCVV.Value
            };

            Session["compra"] = compra;

        }

        protected void btnBuscarLibro_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "mostrarMensaje('Lo sentimos, aquí no puede realizar busquedas.');", true);
        }

        protected void DDCantLibros_SelectedIndexChanged(object sender, EventArgs e)
        {
            Compra compra = (Compra)Session["compra"];

            GenerarCalculosCompra(compra.IdLibro, compra.PrecioLibro, Convert.ToInt16(DDCantLibros.SelectedValue));
        }
    }
}
