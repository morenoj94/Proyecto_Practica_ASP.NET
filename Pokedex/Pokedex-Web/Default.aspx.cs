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
        public List<Pokemon> listPokemon { get; set; }        
        protected void Page_Load(object sender, EventArgs e)
        {
            PokemonNegocio negocio = new PokemonNegocio();
            listPokemon = negocio.listarConSP();

            if(!IsPostBack) 
            {
                reRepetidor.DataSource = listPokemon;
                reRepetidor.DataBind();
            }
        }

        protected void btnEjemplo_Click(object sender, EventArgs e)
        {
            string var = ((Button)sender).CommandArgument;

        }
    }
}