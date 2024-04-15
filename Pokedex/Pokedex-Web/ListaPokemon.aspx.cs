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


            cargarGrilla();
            btnListaActivada.Visible = false;
            btnListaTotal.Visible = true;
            btnListaDesactivada.Visible = true;


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

        protected void btnListaTotal_Click(object sender, EventArgs e)
        {
            btnListaTotal.Visible = false;
            btnListaDesactivada.Visible = true;
            btnListaActivada.Visible = true;
            cargarGrilla();
        }

        protected void btnListaDesactivada_Click(object sender, EventArgs e)
        {
            btnListaDesactivada.Visible = false;
            btnListaTotal.Visible = true;
            btnListaActivada.Visible = true;
            cargarGrilla(false);
        }

        protected void btnListaActivada_Click(object sender, EventArgs e)
        {
            btnListaActivada.Visible = false;
            btnListaTotal.Visible = true;
            btnListaDesactivada.Visible = true;
            cargarGrilla(true);
        }

        public void cargarGrilla()
        {
            PokemonNegocio negocio = new PokemonNegocio();
            dgvListaPokemon.DataSource = negocio.listarConSP();
            dgvListaPokemon.DataBind();
        }
        public void cargarGrilla(bool activo)
        {
            PokemonNegocio negocio = new PokemonNegocio();
            List<Pokemon> listPokemon = (negocio.listarConSP()).FindAll(x => x.Activo = activo);
            dgvListaPokemon.DataSource = listPokemon;
            dgvListaPokemon.DataBind();
        }
    }
}