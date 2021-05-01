using System;
using System.Collections.Generic;
using System.Web.UI;
using Proyecto_Programado_1.Entidades;
using Proyecto_Programado_1.Servicios;

namespace Proyecto_Programado_1.APP
{
    public partial class Libros : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            cargarLibros();
            
        }

        protected void btnBuscarLibro_Click(object sender, EventArgs e)
        {
            servLibros servicioLibros = new servLibros();
            List<Libro> libroEncontrado = servicioLibros.BuscarLibro(txtBusqueda.Value);

            if ((libroEncontrado.Count != 0) && !(txtBusqueda.Value.Equals("")))
            {
                repLibro.DataSource = libroEncontrado;
                repLibro.DataBind();
            }
            else if (txtBusqueda.Value.Equals("")) cargarLibros();
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "mostrarMensaje('Lo sentimos, no se encontraron resultados');", true);
                cargarLibros();
            }
        }

        protected void cargarLibros()
        {
            servLibros servicioLibros = new servLibros();
            repLibro.DataSource = servicioLibros.ObtenerLibros();
            repLibro.DataBind();
        }

        protected void btnAgregarCarrito_Click(object sender, EventArgs e)
        {
            try
            {
                servCarrito servicioCarrito = new servCarrito();

                Usuario usuario = (Usuario)Session["usuario"];

                int Idn = Convert.ToInt16(Page.Request.Form[txtCodigoCar.UniqueID]);

                Carrito carrito = new Carrito()
                {
                    IdCar = 1,
                    IdLibro = Idn,
                    CorreoUsuario = usuario.Email
                };

                if (servicioCarrito.ConsultarCarritoExistente(usuario, carrito.IdLibro) == false)
                {
                    servicioCarrito.GuardarEnCarrito(carrito);

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "mostrarMensaje('Se agregó al carrito');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "mostrarMensaje('El libro ya se encuentra en el carrito');", true);
                }
            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "mostrarMensaje('Ocurrió un error al intentar agregar al carrito');", true);
            }
        }

        protected void btnAgregarFavoritos_Click(object sender, EventArgs e)
        {
            try
            {
                servFavoritos servicioFavoritos = new servFavoritos();

                Usuario usuario = (Usuario)Session["usuario"];

                int Idn = Convert.ToInt16(Page.Request.Form[txtCodigoFav.UniqueID]);

                Favorito favorito = new Favorito()
                {
                    IdFav = 1,
                    IdLibro = Idn,
                    CorreoUsuario = usuario.Email
                };

                if (servicioFavoritos.ConsultarFavoritoExistente(usuario, favorito.IdLibro) == false)
                {
                    servicioFavoritos.GuardarEnFavoritos(favorito);

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "mostrarMensaje('Se agregó a favoritos');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "mostrarMensaje('El libro ya se encuentra en favoritos');", true);
                }
            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "mostrarMensaje('Ocurrió un error al intentar agregar a favoritos');", true);
            }
        }
    }
}