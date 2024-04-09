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
    public partial class ListaPokemon : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {           
            
                PokemonNegocio negocio = new PokemonNegocio();
                dgvListaPokemon.DataSource = negocio.listarConSP();
                dgvListaPokemon.DataBind();           

        }

        protected void dgvListaPokemon_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = dgvListaPokemon.SelectedDataKey.Value.ToString();
            Response.Redirect($"Formulario.aspx?id={id}");
        }

        protected void dgvListaPokemon_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvListaPokemon.PageIndex = e.NewPageIndex;
            dgvListaPokemon.DataBind();
        }
    }
}