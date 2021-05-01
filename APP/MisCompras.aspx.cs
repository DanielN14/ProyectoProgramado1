using Proyecto_Programado_1.Entidades;
using Proyecto_Programado_1.Servicios;
using System;
using System.Data;
using System.Web.UI;

namespace Proyecto_Programado_1.APP
{
    public partial class MisCompras : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                servMisCompras servicioMisCompras = new servMisCompras();
                Usuario usuario = (Usuario)Session["usuario"];

                if (usuario == null)
                {
                    Response.Redirect("Login.aspx");
                }                

                servicioMisCompras.ModificarEstadoCompras(usuario);
                CargarCompras(usuario);
            }
        }

        public void CargarCompras(Usuario usuario)
        {
            servCompras servicioCompras = new servCompras();

            DataTable ds = servicioCompras.ObtenerCompras(usuario);

            if (ds.Rows.Count > 0)
            {
                repMisLibros.DataSource = servicioCompras.ObtenerCompras(usuario);
                repMisLibros.DataBind();
            }
            else
            {
                repMisLibros.Visible = false;
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Usuario usuario = (Usuario)Session["usuario"];

            int Idn = Convert.ToInt16(Page.Request.Form[txtCodigo.UniqueID]);

            servCompras servicioCompras = new servCompras();

            servicioCompras.CancelarCompra(Idn);

            CargarCompras(usuario);
        }

        protected void btnBuscarLibro_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "mostrarMensaje('Lo sentimos, aquí no puede realizar busquedas.');", true);
        }
    }
}