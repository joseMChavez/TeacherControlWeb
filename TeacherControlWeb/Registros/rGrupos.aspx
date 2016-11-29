<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="rGrupos.aspx.cs" Inherits="TeacherControlWeb.Registros.rGrupos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class=" container">

        <%--<div class="row center"> Registro de Usuarios</div>--%>
        <div class="row">
            <div class=" col s12">

                <div class="card-panel">
                    <div class=" card-title center-align light-green-text">
                        <h3>Registro de Secciones</h3>
                    </div>
                    <div class="card-small">
                        <div class=" card-content">

                            <%-- Id --%>
                            <div class="row">
                                <div class="input-field col s3 m3 l2">
                                    <i class="material-icons prefix">turned_in</i>
                                    <label for="IdTextBox">Id:</label>
                                    <asp:TextBox CssClass="validate" ID="IdTextBox" ReadOnly="true" runat="server"></asp:TextBox>

                                </div>
                                <div class="col s3 m2 l2">
                                    <a class="waves-effect blue darken-1 white-text btn modal-trigger" href="#modal1"><i class="material-icons prefix">search</i></a>
                                </div>

                            </div>
                            <div class="row">
                                <div class="input-field col s12 m6 l4">
                                    <asp:DropDownList CssClass="select-dropdown accent-1 btn white black-text" ID="CursosDropDownList" runat="server"></asp:DropDownList>

                                </div>
                            </div>
                            <%-- Desc --%>
                            <div class="row">
                                <div class="input-field col s12 m8 l6">
                                    <i class="material-icons prefix">description</i>
                                    <label for="DescripcionTextBox">Descripcion:</label>
                                    <asp:TextBox CssClass="validate" ID="DescripcionTextBox" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="DescripcionTextBox" runat="server" ForeColor="#CC0000" ValidationGroup="G" ErrorMessage="Introduzca una Seccion" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                                </div>
                            </div>


                            <div class="row">
                                <div class="col s3"></div>
                                <div class="col s6">
                                    <div class="card-action center">
                                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" BorderStyle="Dotted" HeaderText="Atencion!" ShowMessageBox="False" DisplayMode="SingleParagraph" ForeColor="#CC0000" ValidationGroup="G" />
                                        <asp:Button CssClass="waves-effect  light-blue lighten-1 btn " ID="NuevoButton" runat="server" Text="Nuevo" OnClick="NuevoButton_Click" />
                                        <asp:Button CssClass="waves-effect  waves-light btn" ID="GuardarButton" runat="server" ValidationGroup="G" Text="Guardar" Style="left: 0px; top: 0px" OnClick="GuardarButton_Click" />
                                        <asp:Button CssClass="waves-effect  red  btn materialize-red " ID="EliminarButton" runat="server" Text="Eliminar" OnClick="EliminarButton_Click" />
                                    </div>
                                </div>
                                <div class="col s3">
                                </div>

                            </div>
                            <%-- modal --%>
                            <div id="modal1" class="modal bottom-sheet">

                                <div class="modal-content">
                                    <h1>Listado de Grupos</h1>
                                    <div class="row">
                                        <asp:GridView ID="GrupoGridView" CssClass=" striped highlight responsive-table picker__table" runat="server">
                                            <Columns>
                                                <asp:HyperLinkField
                                                    DataNavigateUrlFields="GrupoId"
                                                    DataNavigateUrlFormatString="/Registros/rGrupos.aspx?Id={0}"
                                                    Text="Editar"
                                                    ControlStyle-CssClass="btn btn-block waves-effect white-text" />
                                            </Columns>
                                        </asp:GridView>

                                    </div>
                                </div>
                                <div class="modal-footer">

                                    <a href="#!" class=" modal-action modal-close waves-effect waves-green btn-flat"><i class="material-icons">power_settings_new</i></a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

            </div>
        </div>
    </div>

</asp:Content>
