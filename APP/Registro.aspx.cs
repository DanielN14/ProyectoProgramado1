using Proyecto_Programado_1.Entidades;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Web.UI;

namespace Proyecto_Programado_1.APP
{
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Clear();
        }
        protected void btnRegistrarUsuario_Click(object sender, EventArgs e)
        {
            var nombreUsuario = txtNombreUsuario.Value;
            var email = txtEmail.Value;
            var password = txtPassword.Value;

            var firebaseUrl = "https://identitytoolkit.googleapis.com/v1/accounts:signUp?key=";

            var apiKey = "AIzaSyCgaD5Y3YlZOkleMIjSvPa0tPnKGHkO_30";

            var request = (HttpWebRequest)WebRequest.Create(firebaseUrl + apiKey);
            var postData = "email=" + email + "&password=" + password + "&displayName=" + nombreUsuario;
            var data = Encoding.UTF8.GetBytes(postData);

            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;

            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            try
            {
                var response = (HttpWebResponse)request.GetResponse();
                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

                Usuario usuario = Newtonsoft.Json.JsonConvert.DeserializeObject<Usuario>(responseString);

                if (!string.IsNullOrEmpty(usuario.Email))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "mostrarMensajeConfirmacion('Usuario creado correctamente.');", true);
                    Session["usuario"] = usuario;
                }
            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "mostrarMensaje('Ocurrió un error al intentar registrar el usuario.');", true);
            }
        }
    }
}