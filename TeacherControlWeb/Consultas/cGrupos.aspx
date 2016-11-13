<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="cGrupos.aspx.cs" Inherits="TeacherControlWeb.Consultas.cGrupos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
     <div class="container">
       
        <div class="row">
            <div class=" col s12">

                <div class=" card-panel">
                    <div class=" card-title center-align light-green-text">
                        <h3>Consulta de Secciones</h3>
                    </div>
                    <div class="card-small">
                        <div class="card-content">
                            <div class="row">
                                <div class=" col s1">
                                    <asp:Label CssClass=" select-label" ID="FiltroLabel" runat="server" Text="Filtrar por:"></asp:Label>
                                </div>
                                <div class="col s3">
                                    <asp:DropDownList ToolTip="Seleccione una Opcion" ID="FiltroDropDownList" runat="server" CssClass="select-dropdown btn white black-text">
                                        <asp:ListItem Value="Id">Id</asp:ListItem>
                                        <asp:ListItem Value="Curso">Curso</asp:ListItem>
                                        <asp:ListItem Value="Seccion">Seccion</asp:ListItem>
                                       
                                    </asp:DropDownList>
                                </div>
                                <div class="input-field col s6">
                                    <asp:TextBox ID="FiltroTextBox" runat="server"></asp:TextBox>
                                </div>
                                <div class="col s2">
                                    <asp:LinkButton ToolTip="Buscar" ID="BuscarButton" runat="server" CssClass=" waves-effect blue darken-1 white-text btn" OnClick="BuscarButton_Click"><i class="material-icons prefix">search</i></asp:LinkButton>
                                </div>
                            </div>
                            <div class="row">
                                <asp:GridView ID="GruposGridView" CssClass=" striped highlight responsive-table picker__table" runat="server">
                                   <Columns>
                                        <asp:HyperLinkField
                                        DataNavigateUrlFields="Id"
                                        DataNavigateUrlFormatString="/Registros/rGrupos.aspx?Id={0}"
                                        Text="Editar"
                                         ControlStyle-CssClass="btn waves-effect white-text"  />
                                       </Columns>
                                </asp:GridView>

                            </div>
                        </div>

                    </div>
                </div>
              
            </div>
        </div>

    </div>
</asp:Content>
