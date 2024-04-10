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
    public partial class Formulario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtId.Enabled = false;

            if (!IsPostBack)
            {
                ElementoNegocio negocio = new ElementoNegocio();
                List<Elemento> lista = negocio.listar();

                ddlTipo.DataSource = lista;
                ddlTipo.DataValueField = "Id";
                ddlTipo.DataTextField = "Descripcion";
                ddlTipo.DataBind();

                ddlDebilidad.DataSource = lista;
                ddlDebilidad.DataValueField = "Id";
                ddlDebilidad.DataTextField = "Descripcion";
                ddlDebilidad.DataBind();

            }

        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {

        }

        protected void txtUrlImagen_TextChanged(object sender, EventArgs e)
        {
            imgPokemon.ImageUrl = txtUrlImagen.Text;
        }
    }
}