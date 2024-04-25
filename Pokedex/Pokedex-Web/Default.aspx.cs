using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace Pokedex_Web
{
    public partial class PokedexWeb : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] != null)
            {
                Usuario usuario = (Usuario)Session["usuario"];
                string user = usuario.User;
                lblIngreste.Text = $"{user}... Ingresaste exitosamente";
            }

        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Remove("usuario");
            Response.Redirect("Default.aspx", false);
            
        }
    }
}