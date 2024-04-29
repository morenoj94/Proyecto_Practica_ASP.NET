<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Pokedex_Web.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />

    <%if (Session["usuario"] == null)
        {%>
    <div class="row">
        <div class="col-5">

            <div class="mb-3">
                <label for="txtUsuario" class="form-label">Usuario</label>
                <asp:TextBox ID="txtUsuario" CssClass="form-control" aria-describedby="emailHelp" runat="server" />
            </div>
            <div class="mb-3">
                <label for="txtPassword" class="form-label">Password</label>
                <asp:TextBox ID="txtPassword" CssClass="form-control" TextMode="Password" runat="server" />
            </div>
            <asp:Button ID="btnAceptar" CssClass="btn btn-primary" Text="Aceptar" OnClick="btnAceptar_Click" runat="server" />

        </div>
    </div>
    <%}
        else
        {%>
    <div class="mb-3">
        <h5> <asp:Label ID="lblIngresaste" Text="" runat="server" /> </h5>
    </div>
    <asp:Button ID="btnLogout" Text="Logout" CssClass="btn btn-primary" OnClick="btnLogout_Click" runat="server" />

    <%} %>
</asp:Content>
