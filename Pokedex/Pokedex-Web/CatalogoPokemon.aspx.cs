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
    public partial class CatalogoPokemon1 : System.Web.UI.Page
    {
        public List<Pokemon> listPokemon { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            PokemonNegocio negocio = new PokemonNegocio();
            listPokemon = negocio.listarConSP();

            if (!IsPostBack)
            {
                reRepetidor.DataSource = listPokemon;
                reRepetidor.DataBind();
            }
        }

        protected void btnEjemplo_Click(object sender, EventArgs e)
        {
            int id = int.Parse(((Button)sender).CommandArgument);
            Response.Redirect($"Formulario.aspx?id={id}", false);
        }
    }
}