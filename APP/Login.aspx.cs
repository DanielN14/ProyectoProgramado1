using System;
using System.IO;
using System.Net;
using System.Text;
using System.Web.UI;
using Proyecto_Programado_1.Entidades;

namespace Proyecto_Programado_1.APP
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Clear();
        }
        protected void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            var email = txtEmail.Value;
            var password = txtPassword.Value;

            var firebaseUrl = "https://identitytoolkit.googleapis.com/v1/accounts:signInWithPassword?key=";

            var apiKey = "AIzaSyCgaD5Y3YlZOkleMIjSvPa0tPnKGHkO_30";

            var request = (HttpWebRequest)WebRequest.Create(firebaseUrl + apiKey);
            var postData = "email=" + email + "&password=" + password;
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
                    Session["usuario"] = usuario;
                    Response.Redirect("Libros.aspx");
                }
            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "mostrarMensaje('Usuario no registrado en el sistema.');", true);
            }
        }
    }
}