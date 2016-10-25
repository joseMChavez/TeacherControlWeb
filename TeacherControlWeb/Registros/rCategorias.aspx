<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="rCategorias.aspx.cs" Inherits="TeacherControlWeb.Registros.rCategorias" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class=" container">

        <%--<div class="row center"> Registro de Usuarios</div>--%>
        <div class="row">
            <div class=" col s12">

                <div class="card-panel">
                    <div class=" card-title center-align light-green-text">
                        <h3>Registro de Categorias</h3>
                    </div>
                    <div class="card-small">
                        <div class=" card-content">

                            <%-- Id --%>
                            <div class="row">
                                <div class="input-field col s3">
                                    <i class="material-icons prefix">turned_in</i>
                                    <label for="IdTextBox">Id:</label>
                                    <asp:TextBox CssClass="validate" ID="IdTextBox" runat="server"></asp:TextBox>

                                </div>
                                <div class="col s3">
                                    <asp:LinkButton ToolTip="Buscar" ID="BuscarButton" runat="server" CssClass=" waves-effect blue darken-1 white-text btn"><i class="material-icons prefix">search</i></asp:LinkButton>
                                </div>

                            </div>
                            <%-- Nombres --%>
                            <div class="row">
                                <div class="input-field col s8">
                                    <i class="material-icons prefix">description</i>
                                    <label for="DescripcionTextBox">Descripcion:</label>
                                    <asp:TextBox CssClass="validate" ID="DescripcionTextBox" runat="server"></asp:TextBox>
                                </div>
                            </div>
                          

                            <div class="row">
                                <div class="col s3"></div>
                                <div class="col s6">
                                    <div class="card-action center">

                                        <asp:Button CssClass="waves-effect  light-blue lighten-1 btn " ID="NuevoButton" runat="server" Text="Nuevo"  />
                                        <asp:Button CssClass="waves-effect  waves-light btn" ID="GuardarButton" runat="server" Text="Guardar"  Style="left: 0px; top: 0px" />
                                        <asp:Button CssClass="waves-effect  red  btn materialize-red " ID="EliminarButton" runat="server" Text="Eliminar"  />
                                    </div>
                                </div>
                                <div class="col s3">
                                </div>

                            </div>
                        </div>
                    </div>
                </div>

            </div>
        </div>
    </div>

</asp:Content>
