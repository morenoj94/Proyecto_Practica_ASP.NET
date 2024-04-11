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

            try
            {
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
            catch (Exception ex)
            {

                Session.Add("error", ex);
                throw;
                //redireccion a pantalla de error
            }


        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Pokemon aux = new Pokemon();
                PokemonNegocio negocio = new PokemonNegocio();
                aux.Numero = int.Parse(txtNumero.Text);
                aux.Nombre = txtNombre.Text;
                aux.Descripcion = txtDescripcion.Text;
                aux.UrlImagen = txtUrlImagen.Text;
                aux.Tipo = new Elemento();
                aux.Tipo.Id = int.Parse(ddlTipo.SelectedValue);
                aux.Debilidad = new Elemento();
                aux.Debilidad.Id = int.Parse(ddlDebilidad.SelectedValue);

                negocio.agregarPokemon(aux);
                Response.Redirect("ListaPokemon.aspx", false);
            }
            catch (Exception ex)
            {

                Session.Add("error", ex);
                throw;
                //redireccion a pantalla de error
            }
        }

        protected void txtUrlImagen_TextChanged(object sender, EventArgs e)
        {
            imgPokemon.ImageUrl = txtUrlImagen.Text;
        }
    }
}