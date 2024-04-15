<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Pokedex_Web.PokedexWeb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Bienvenido</h1>
    <h4>Esta es la Pokedex Web</h4>

    <div class="row row-cols-1 row-cols-md-3 g-4">
        <%--<%foreach (dominio.Pokemon poke in listPokemon)
            {%>
        <div class="col">
            <div class="card h-100">
                <img src="<%:poke.UrlImagen %>" class="card-img-top" alt="...">
                <div class="card-body">
                    <h5 class="card-title"><%:poke.Nombre %></h5>
                    <p class="card-text"><%:poke.Descripcion %></p>
                </div>
                <div class="card-footer">
                    <small class="text-body-secondary"><a href="DetallePokemon.aspx?id=<%:poke.Id %>">ver detalle</a></small>
                </div>
            </div>
        </div>        
        <%}%>--%>


        <%-- Primero tenemos las tarjetas cargadas con un for each pero ahora lo cargamos con un repeater --%>



        <asp:Repeater ID="reRepetidor" runat="server">
            <ItemTemplate>
                <div class="col">
                    <div class="card h-100">
                        <a href="Formulario.aspx?id=<%#Eval("Id") %>">
                            <button></button>
                        <img src="<%#Eval("UrlImagen") %>"  class="card-img-top" alt="...">
                        </a>
                        <div class="card-body">
                            <h5 class="card-title"><%#Eval("Nombre")%></h5>
                            <p class="card-text"><%#Eval("Descripcion")%></p>
                        </div>
                        <div class="card-footer">
                            <small class="text-body-secondary">                                
                                <asp:Button ID="btnEjemplo" CssClass="btn btn-primary" Text="Ejemplo" runat="server" CommandArgument='<%#Eval("Id") %>'  CommandName="pokemonId" OnClick="btnEjemplo_Click" />
                                <%-- en este boton el command argumente se usa con comillas simples '' --%>
                            </small>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
