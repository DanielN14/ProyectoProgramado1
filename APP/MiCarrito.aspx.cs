using System;
using System.Web.UI;
using Proyecto_Programado_1.Entidades;
using Proyecto_Programado_1.Servicios;

namespace Proyecto_Programado_1.APP
{
    public partial class MiCarrito : System.Web.UI.Page
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

                CargarCarrito(usuario);
            }
        }
        public void CargarCarrito(Usuario usuario)
        {
            servCarrito servicioCompras = new servCarrito();

            if (servicioCompras.ObtenerTCarrito(usuario).Count > 0)
            {
                repMiCarrito.DataSource = servicioCompras.ObtenerTCarrito(usuario);
                repMiCarrito.DataBind();
            }
            else
            {
                repMiCarrito.Visible = false;
            }
        }

        protected void btnBuscarLibro_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "mostrarMensaje('Lo sentimos, aquí no puede realizar busquedas.');", true);
        }

        protected void btnQuitar_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario usuario = (Usuario)Session["usuario"];

                servCarrito servicioCarrito = new servCarrito();

                int Idn = Convert.ToInt16(Page.Request.Form[txtCodigo.UniqueID]);

                servicioCarrito.QuitarDeCarrito(Idn);

                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "mostrarMensaje('Se quitó el libro del carrito correctamente.');", true);

                CargarCarrito(usuario);
            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "mostrarMensaje('Ocurrió un error al intentar quitar el libro del carrito');", true);
            }
        }


    }
}