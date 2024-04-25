using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pokedex_Web
{
    public partial class Login : System.Web.UI.Page
    {
        public Usuario usuarioIniciado { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] != null)
            {
                lblIngresaste.Text = "Maquina ya abriste session, no hace falta que hagas loging. si te cansaste entonces tienes que hacer logout";
            }
            
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            Usuario usuario;
            UsuarioNegocio negocio = new UsuarioNegocio();
            try
            {
                usuario = new Usuario(txtUsuario.Text, txtPassword.Text);
                if (negocio.Login(usuario))
                {
                    Session.Add("usuario", usuario);
                    usuarioIniciado = usuario;
                    Response.Redirect("Default.aspx", false);
                }
                else
                {
                    Session.Add("error", "usuario o pass incorrecta");
                    Response.Redirect("Error.aspx", false);
                }


            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Remove("usuario");
            Response.Redirect("Default.aspx", false);
        }
    }
}