<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Pokedex_Web.PokedexWeb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Bienvenido</h1>
    <%if (Session["usuario"] != null)
        {%>
    <h5> <asp:Label ID="lblIngreste" Text="" runat="server" /> </h5>
    <asp:Button ID="btnLogout" Text="Logout" CssClass="btn btn-primary" OnClick="btnLogout_Click" runat="server" />

    <% }
        else
        {%>
    <h5>Si quieres acceder a la lista de pokemons debes iniciar sesion</h5>
    <a href="Login.aspx" class="btn btn-primary">Login</a>
    <%} %>
</asp:Content>
