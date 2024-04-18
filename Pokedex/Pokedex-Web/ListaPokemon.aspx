<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ListaPokemon.aspx.cs" Inherits="Pokedex_Web.ListaPokemon" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" />
    <h1>Lista de pokemons</h1>

    <asp:UpdatePanel runat="server">
        <ContentTemplate>

            <%-- Filtro simple y check de filtro avanzado --%>
            <div class="row">
                <%-- Filtro simple --%>
                <div class="col-3">
                    <div class="mb-2">
                        <label for="txtFiltro" class="form-label">Filtro rapido</label>
                        <asp:TextBox ID="txtFiltro" runat="server" OnTextChanged="txtFiltro_TextChanged" AutoPostBack="true" CssClass="form-control" />
                    </div>
                </div>

                <%-- check de filtro avanzado --%>
                <div class="col-3" style="display: flex; flex-direction: column; justify-content: flex-end;">
                    <div class="mb-2">
                        <asp:CheckBox ID="cbxFiltroAvanzado" Text="Filtro avanzado"
                            OnCheckedChanged="cbxFiltroAvanzado_CheckedChanged"
                            AutoPostBack="true" runat="server" />
                    </div>
                </div>
            </div>

            <%-- Campos para el filtro avanzado --%>
            <%if (cbxFiltroAvanzado.Checked)
            {%>
            <div class="row">
                <%-- Control para el campo --%>
                <div class="col-3">
                    <div class="mb-2">
                        <label for="ddlCampo" class="form-label">Campo</label>
                        <asp:DropDownList ID="ddlCampo" OnSelectedIndexChanged="ddlCampo_SelectedIndexChanged" AutoPostBack="true" CssClass="form-select" runat="server">
                            <asp:ListItem Text="Nombre" />
                            <asp:ListItem Text="Tipo" />
                            <asp:ListItem Text="Numero" />
                        </asp:DropDownList>
                    </div>
                </div>

                <%-- Control para el criterio --%>
                <div class="col-3">
                    <div class="mb-2">
                        <label for="ddlCriterio" class="form-label">Criterio</label>
                        <asp:DropDownList ID="ddlCriterio" OnSelectedIndexChanged="ddlCriterio_SelectedIndexChanged" CssClass="form-select" runat="server">                            
                        </asp:DropDownList>
                    </div>
                </div>

                <%-- Control para el filtro --%>
                <div class="col-3">
                    <div class="mb-2">
                        <label for="txtFiltroAvanzado" class="form-label">Filtro</label>
                        <asp:TextBox ID="txtFiltroavanzado" runat="server" CssClass="form-control" />
                    </div>
                </div>

                <%-- Control para activos o inactivos --%>
                <div class="col-3">
                    <div class="mb-2">
                        <label for="ddlCampo" class="form-label">Estado</label>
                        <asp:Label Text="Estado" CssClass="form-label" runat="server" />
                        <asp:DropDownList ID="ddlEstado" CssClass="form-select" runat="server">
                            <asp:ListItem Text="Todos" />
                            <asp:ListItem Text="Activos" />
                            <asp:ListItem Text="Inactivos" />
                        </asp:DropDownList>
                    </div>
                </div>

            </div>
            <div class="row">
                <div class="col-3">
                    <div class="mb-2">
                        <asp:Button ID="btnFiltrar" Text="Filtrar" CssClass="btn btn-dark" runat="server" />
                    </div>
                </div>
            </div>
            <%} %>



           <%-- Botones para mostrar la lista entrera o solo elementos activos --%>
            <%--<asp:Button ID="btnListaTotal" CssClass="btn btn-dark" Text="Todos los Pokemons" OnClick="btnListaTotal_Click" runat="server" />--%>
            <%--<asp:Button ID="btnListaDesactivada" CssClass="btn btn-dark" Text="Pokemons Desactivados" OnClick="btnListaDesactivada_Click" runat="server" />--%>
            <%--<asp:Button ID="btnListaActivada" CssClass="btn btn-dark" Text="Pokemons activos" OnClick="btnListaActivada_Click" runat="server" />--%>


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
        </ContentTemplate>
    </asp:UpdatePanel>
    <a href="Formulario.aspx" class="btn btn-dark">Agregar</a>

</asp:Content>
