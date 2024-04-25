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


            if (Session["usuario"]==null)
            {
                Session.Add("error", "Para poder ver los pokemos en formato lista debes iniciar session. \nVe a la ventana home y desde alli presiona el boton login");
                Response.Redirect("Error.aspx", false);
            }
            cargarGrilla();
            //btnListaActivada.Visible = true;
            btnListaTotal.Visible = false;
            //btnListaDesactivada.Visible = true;


        }

        protected void dgvListaPokemon_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((Usuario)Session["usuario"]).TipoUsuario == TipoUsuario.ADMIN)
            {
                string id = dgvListaPokemon.SelectedDataKey.Value.ToString();
                Response.Redirect($"Formulario.aspx?id={id}");
            }
            else
            {
                Session.Add("error", "Maquina tienes que iniciar session como admin para poder modificar un pokemon");
                Response.Redirect("Error.aspx", false);
            }
            
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

        }

        protected void btnListaDesactivada_Click(object sender, EventArgs e)
        {
            btnListaDesactivada.Visible = false;
            btnListaTotal.Visible = true;
            btnListaActivada.Visible = true;
            //cargarGrilla(false);
            try
            {
                PokemonNegocio negocio = new PokemonNegocio();
                dgvListaPokemon.DataSource = negocio.filtrar("", "", "", "Inactivos");
                dgvListaPokemon.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw;
            }
        }

        protected void btnListaActivada_Click(object sender, EventArgs e)
        {
            btnListaActivada.Visible = false;
            btnListaTotal.Visible = true;
            btnListaDesactivada.Visible = true;
            //cargarGrilla(true);
            try
            {
                PokemonNegocio negocio = new PokemonNegocio();
                dgvListaPokemon.DataSource = negocio.filtrar("", "", "", "Activos");
                dgvListaPokemon.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw;
            }
        }

        public void cargarGrilla()
        {
            try
            {
                PokemonNegocio negocio = new PokemonNegocio();
                Session.Add("listPokemon", negocio.listarConSP());
                dgvListaPokemon.DataSource = Session["listPokemon"];
                dgvListaPokemon.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw;
            }
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
            dgvListaPokemon.DataSource = listFiltrada;
            dgvListaPokemon.DataBind();
        }

        protected void cbxFiltroAvanzado_CheckedChanged(object sender, EventArgs e)
        {
            ddlCampo.SelectedValue = "";
            txtFiltro.Enabled = !cbxFiltroAvanzado.Checked;
        }

        protected void ddlCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlCriterio.Items.Clear();

            if (ddlCampo.SelectedValue.ToString() == "Numero")
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

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            try
            {
                PokemonNegocio negocio = new PokemonNegocio();
                dgvListaPokemon.DataSource = negocio.filtrar(ddlCampo.SelectedValue,
                    ddlCriterio.SelectedValue, txtFiltroavanzado.Text,
                    ddlEstado.SelectedValue);
                dgvListaPokemon.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw;
            }

        }
    }
}