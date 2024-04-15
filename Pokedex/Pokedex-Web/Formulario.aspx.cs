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
        public bool ConfirmarEliminar { get; set; }
        public bool Activo { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            txtId.Enabled = false;
            ConfirmarEliminar = false;
            Activo = true;

            try
            {
                //carga inicial
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

                //carga si viene un id por url

                if (!(Request.QueryString["id"] == null) && !IsPostBack)// agregamos la coondicion si es postback
                {                    
                    int id = int.Parse(Request.QueryString["id"]);
                    PokemonNegocio negocio = new PokemonNegocio();
                    //List<Pokemon> lista = negocio.listarConSP();
                    // no creo la variable lista y solo creo la variable pokemon, igual llamo al metodo listar pero en la misma linea de codigo hago el filtro con la expresion lamda
                    Pokemon seleccionado = (negocio.listarConSP()).Find(x => x.Id == id);

                    txtId.Text = seleccionado.Id.ToString();
                    txtNombre.Text = seleccionado.Nombre;
                    txtNumero.Text = seleccionado.Numero.ToString();
                    txtDescripcion.Text = seleccionado.Descripcion;
                    txtUrlImagen.Text = seleccionado.UrlImagen;
                    imgPokemon.ImageUrl = txtUrlImagen.Text;

                    ddlTipo.SelectedValue = seleccionado.Tipo.Id.ToString();
                    ddlDebilidad.SelectedValue = seleccionado.Debilidad.Id.ToString();

                    if (seleccionado.Activo)
                    {
                        Activo = true;
                    }
                    else 
                    {
                        Activo=false;
                    }

                    btnAceptar.Text = "Modificar";

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

                if (Request.QueryString["id"] != null)
                {
                    aux.Id = int.Parse(txtId.Text); // agregamos el id en el poke aux para poder modificar en base al id
                    negocio.modificarPokemonConSP(aux);
                }
                else
                {
                    negocio.agregarConSP(aux);
                }
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

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                ConfirmarEliminar = true;
            }
        }

        protected void btnConfirmarEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                PokemonNegocio negocio = new PokemonNegocio();
                if (cbxConfirmareliminar.Checked)
                {
                    negocio.eliminarPokemon(int.Parse(txtId.Text));
                    Response.Redirect("ListaPokemon.aspx", false);
                }
                else
                {
                    negocio.eliminarLogico(int.Parse(txtId.Text));
                    Response.Redirect("ListaPokemon.aspx", false);
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw;
                //redireccion a pantalla de error
            }
        }

        protected void cbxConfirmareliminar_CheckedChanged(object sender, EventArgs e)
        {
            ConfirmarEliminar = true;
            if (cbxConfirmareliminar.Checked)
            {
                btnConfirmarEliminar.CssClass = "btn btn-outline-danger";
                btnConfirmarEliminar.Text = "Eliminar";
            }
            else 
            {
                btnConfirmarEliminar.CssClass = "btn btn-outline-warning";
                btnConfirmarEliminar.Text = "Inactivar";
            }
        }

        protected void btnActivar_Click(object sender, EventArgs e)
        {
            try
            {
                PokemonNegocio negocio = new PokemonNegocio();
                negocio.activarPokemon(int.Parse(txtId.Text));
                Response.Redirect("ListaPokemon.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw;
                //redireccion a pantalla de error
            }
        }
    }
}