<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="rCursos.aspx.cs" Inherits="TeacherControlWeb.Registros.rCursos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class=" container">

        <%--<div class="row center"> Registro de Usuarios</div>--%>
        <div class="row">
            <div class=" col s12">

                <div class="card-panel">
                    <div class=" card-title center-align light-green-text">
                        <h3>Registro de Cursos</h3>
                    </div>
                    <div class="card-small">
                        <div class=" card-content">
                            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                            <%-- Id --%>
                            <div class="row">
                                <div class="input-field col l3 m3 s4">
                                    <i class="material-icons prefix">turned_in</i>
                                    <label for="IdTextBox">Id:</label>
                                    <asp:TextBox CssClass="validate" ID="IdTextBox" ReadOnly="true" runat="server" TextMode="Number"></asp:TextBox>

                                </div>
                                
                                        <div class="col l2 m2 s3">
                                           
                                            <a class="waves-effect blue darken-1 white-text btn modal-trigger" href="#modal1"><i class="material-icons prefix" OnClick="BuscarButton_Click">search</i></a>
                                            <%--<asp:LinkButton data-target="modal1" Visible="true" ToolTip="Buscar" ID="BuscarButton" runat="server" CssClass=" waves-effect blue darken-1 white-text btn modal-trigger" OnClick="BuscarButton_Click"><i class="material-icons prefix">search</i></asp:LinkButton>--%>
                                        </div>
                              
                            </div>
                            <%-- Nombres --%>
                            <div class="row">
                                <div class="input-field col l10 m10 s8">
                                    <i class="material-icons prefix">description</i>
                                    <label for="DescripcionTextBox">Descripcion:</label>
                                    <asp:TextBox CssClass="validate" ID="DescripcionTextBox" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="DescripcionTextBox" runat="server" ForeColor="#CC0000" ValidationGroup="G" ErrorMessage="Introduzca un Curso." SetFocusOnError="True">*</asp:RequiredFieldValidator>
                                </div>
                            </div>


                            <div class="row">
                                <div class="col s3"></div>
                                <div class="col s6">
                                    <div class="card-action center">
                                          <asp:ValidationSummary ID="ValidationSummary1" runat="server" BorderStyle="Dotted" HeaderText="Atencion!" ShowMessageBox="False" DisplayMode="SingleParagraph" ForeColor="#CC0000" ValidationGroup="G" />
                                        <asp:Button CssClass="waves-effect  light-blue lighten-1 btn " ID="NuevoButton" runat="server" Text="Nuevo" OnClick="NuevoButton_Click" />
                                        <asp:Button CssClass="waves-effect  waves-light btn" ID="GuardarButton" runat="server" Text="Guardar" Style="left: 0px; top: 0px" ValidationGroup="G" OnClick="GuardarButton_Click" />
                                        <asp:Button CssClass="waves-effect  red  btn materialize-red " ID="EliminarButton" runat="server" Text="Eliminar" OnClick="EliminarButton_Click" />
                                    </div>
                                </div>
                                <div class="col s3">
                                </div>
                                <!-- Modal Trigger -->
                                <%--<a class="waves-effect waves-light btn modal-trigger" href="#modal1"><i class="material-icons prefix">print</i></a>--%>

                                <!-- Modal Structure -->
                                <div id="modal1" class="modal bottom-sheet">

                                    <div class="modal-content">
                                        <h1>Listado de Cursos</h1>
                                        <div class="row">
                                            <asp:GridView ID="Cursos2GridView" CssClass=" striped highlight responsive-table picker__table" runat="server">
                                                <Columns>
                                                    <asp:HyperLinkField
                                                        DataNavigateUrlFields="ID"
                                                        DataNavigateUrlFormatString="/Registros/rCursos.aspx?ID={0}"
                                                        Text="Editar"
                                                        ControlStyle-CssClass="btn waves-effect white-text " />
                                                </Columns>
                                            </asp:GridView>

                                        </div>
                                    </div>
                                    <div class="modal-footer">

                                        <a href="#!" class=" modal-action modal-close waves-effect waves-green btn-flat">Cerrar</a>
                                    </div>
                                </div>

                            </div>

                        </div>
                    </div>
                </div>
            </div>

        </div>
    </div>


</asp:Content>
