﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Formulario.aspx.cs" Inherits="Pokedex_Web.Formulario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" />
    <%-- El update panel necesita un scrip manager para funcionar --%>
    <br />
    <div class="row">
        <div class="col-6">

            <div class="mb-2">
                <label for="txtId" class="form-label">Id</label>
                <asp:TextBox ID="txtId" runat="server" CssClass="form-control" />
            </div>
            <div class="mb-2">
                <label for="txtNombre" class="form-label">Nombre</label>
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" />
            </div>
            <div class="mb-2">
                <label for="txtNumero" class="form-label">numero</label>
                <asp:TextBox ID="txtNumero" runat="server" CssClass="form-control" />
            </div>
            <div class="mb-2">
                <label for="ddlTipo" class="form-label">Tipo</label>
                <asp:DropDownList ID="ddlTipo" CssClass="form-select" runat="server">
                </asp:DropDownList>
            </div>
            <div class="mb-2">
                <label for="ddlDebilidad" class="form-label">Debilidad</label>
                <asp:DropDownList ID="ddlDebilidad" CssClass="form-select" runat="server">
                </asp:DropDownList>
            </div>
            <br />
            <asp:Button ID="btnAceptar" CssClass="btn btn-dark" Text="Aceptar" OnClick="btnAceptar_Click" runat="server" />
        </div>

        <div class="col-6">
            <div class="mb-2">
                <label for="txtDescripcion" class="form-label">Descripcion</label>
                <asp:TextBox ID="txtDescripcion" TextMode="MultiLine" runat="server" CssClass="form-control" />
            </div>
            <%-- El update panel necesita un scrip manager para funcionar --%>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div class="mb-2">
                        <label for="txtUrlImagen" class="form-label">Url Imagen</label>
                        <asp:TextBox ID="txtUrlImagen" OnTextChanged="txtUrlImagen_TextChanged"
                            runat="server" CssClass="form-control" AutoPostBack="true" />
                    </div>
                    <asp:Image ImageUrl="https://i0.wp.com/usma.ac.pa/wp-content/uploads/2020/02/placeholder.png?ssl=1"
                        ID="imgPokemon" runat="server" Width="60%" />

                </ContentTemplate>
            </asp:UpdatePanel>



        </div>
    </div>
</asp:Content>