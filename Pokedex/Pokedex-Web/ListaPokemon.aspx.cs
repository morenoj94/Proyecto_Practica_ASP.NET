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
            //btnListaActivada.Visible = true;
            //btnListaTotal.Visible = false;
            //btnListaDesactivada.Visible = true;


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

        //protected void btnListaTotal_Click(object sender, EventArgs e)
        //{
        //    btnListaTotal.Visible = false;
        //    //btnListaDesactivada.Visible = true;
        //    btnListaActivada.Visible = true;
        //    cargarGrilla();
        //}

        //protected void btnListaDesactivada_Click(object sender, EventArgs e)
        //{
        //    btnListaDesactivada.Visible = false;
        //    btnListaTotal.Visible = true;
        //    btnListaActivada.Visible = true;
        //    cargarGrilla(false);
        //}

        //protected void btnListaActivada_Click(object sender, EventArgs e)
        //{
        //    btnListaActivada.Visible = false;
        //    btnListaTotal.Visible = true;
        //    //btnListaDesactivada.Visible = true;
        //    cargarGrilla(true);
        //}

        public void cargarGrilla()
        {
            PokemonNegocio negocio = new PokemonNegocio();
            Session.Add("listPokemon", negocio.listarConSP());
            dgvListaPokemon.DataSource = Session["listPokemon"];
            dgvListaPokemon.DataBind();
        }
        public void cargarGrilla(bool activo)
        {
            List<Pokemon> listPokemon = ((List<Pokemon>)Session["listPokemon"]).FindAll(x => x.Activo = activo);
            dgvListaPokemon.DataSource = listPokemon;
            dgvListaPokemon.DataBind();
        }

        protected void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            List<Pokemon> listFiltrada = ((List<Pokemon>)Session["listPokemon"]).FindAll(x => x.Nombre.ToUpper().Contains(txtFiltro.Text.ToUpper()));
            dgvListaPokemon.DataSource= listFiltrada;
            dgvListaPokemon.DataBind();
        }

        protected void cbxFiltroAvanzado_CheckedChanged(object sender, EventArgs e)
        {
            txtFiltro.Enabled = !cbxFiltroAvanzado.Checked;
        }

        protected void ddlCriterio_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void ddlCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlCriterio.Items.Clear();
            if (ddlCampo.SelectedIndex.ToString()== "Numero")
            {
                ddlCriterio.Items.Add("Menor que");
                ddlCriterio.Items.Add("Igual a");
                ddlCriterio.Items.Add("Mayor que");
            }
            else
            {
                ddlCriterio.Items.Add("Comienza con");
                ddlCriterio.Items.Add("Contiene");
                ddlCriterio.Items.Add("Termina con");
            }

        }
    }
}