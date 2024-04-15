<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ListaPokemon.aspx.cs" Inherits="Pokedex_Web.ListaPokemon" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Lista de pokemons</h1>

    
    <asp:Button ID="btnListaTotal" CssClass="btn btn-dark" Text="Todos los Pokemons" OnClick="btnListaTotal_Click" runat="server" />
    <asp:Button ID="btnListaDesactivada" CssClass="btn btn-dark" Text="Pokemons Desactivados" OnClick="btnListaDesactivada_Click" runat="server" />
    <asp:Button ID="btnListaActivada" CssClass="btn btn-dark" Text="Pokemons activos" OnClick="btnListaActivada_Click" runat="server" />


    <asp:GridView ID="dgvListaPokemon" CssClass="table table-striped table-bordered"
        runat="server" AutoGenerateColumns="false" DataKeyNames="Id"
        OnSelectedIndexChanged="dgvListaPokemon_SelectedIndexChanged"
        OnPageIndexChanging="dgvListaPokemon_PageIndexChanging"
        AllowPaging="true" PageSize="5">
        <Columns>
            <asp:BoundField HeaderText="Numero" DataField="Numero" />
            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
            <asp:BoundField HeaderText="Tipo" DataField="Tipo.Descripcion" />
            <asp:CheckBoxField HeaderText="Activo" DataField="Activo" />
            <asp:CommandField HeaderText="Accion" ShowSelectButton="true" SelectText="✍" />
        </Columns>
    </asp:GridView>
    <a href="Formulario.aspx" class="btn btn-dark">Agregar</a>

</asp:Content>
