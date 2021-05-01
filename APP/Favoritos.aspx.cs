using Proyecto_Programado_1.Entidades;
using Proyecto_Programado_1.Servicios;
using System;
using System.Web.UI;

namespace Proyecto_Programado_1.APP
{
    public partial class Favoritos : System.Web.UI.Page
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

                CargarFavoritos(usuario);
            }
        }

        public void CargarFavoritos(Usuario usuario)
        {
            servFavoritos servicioFavoritos = new servFavoritos();

            if (servicioFavoritos.ObtenerFavoritos(usuario).Count > 0)
            {
                repFavoritos.DataSource = servicioFavoritos.ObtenerFavoritos(usuario);
                repFavoritos.DataBind();
            }
            else
            {
                repFavoritos.Visible = false;
            }
        }

        protected void btnQuitar_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario usuario = (Usuario)Session["usuario"];

                servFavoritos servicioFavoritos = new servFavoritos();

                int Idn = Convert.ToInt16(Page.Request.Form[txtCodigoFav.UniqueID]);

                servicioFavoritos.QuitarDeFavoritos(Idn);

                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "mostrarMensaje('Se quitó el libro de favoritos correctamente.');", true);

                CargarFavoritos(usuario);
            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "mostrarMensaje('Ocurrió un error al intentar quitar el libro de favoritos');", true);
            }
        }

        protected void btnBuscarLibro_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "mostrarMensaje('Lo sentimos, aquí no puede realizar busquedas.');", true);
        }
    }
}