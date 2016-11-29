<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="cEstudiantes.aspx.cs" Inherits="TeacherControlWeb.Consultas.cEstudiantes" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="container">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="row">
            <div class=" col s12">

                <div class=" card-panel">
                    <div class=" card-title center-align light-green-text">
                        <h3>Consulta de Estudiantes</h3>
                    </div>
                    <div class="card-small">
                        <div class="card-content">
                            <div class="row">
                                <div class=" col s1">
                                    <asp:Label CssClass=" select-label" ID="FiltroLabel" runat="server" Text="Filtrar por:"></asp:Label>
                                </div>
                                <div class="col s3">
                                    <asp:DropDownList ToolTip="Estudiantes" ID="FiltroDropDownList" runat="server" CssClass="select-dropdown btn white black-text">
                                        <asp:ListItem Value="Id">Id</asp:ListItem>
                                        <asp:ListItem Value="Nombre">Nombre</asp:ListItem>
                                        <asp:ListItem Value="Matricula">Matricula</asp:ListItem>
                                        <asp:ListItem Value="Celular">Celular</asp:ListItem>

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

                                <div class="col s1">
                                    <asp:Label ID="DesdeLabel" runat="server" Text="Desde:"></asp:Label>

                                </div>
                                <div class="col s2">

                                    <asp:TextBox ID="DesdeTextBox" runat="server" type="date"></asp:TextBox>
                                </div>
                                <div class="col s1">
                                    <asp:Label ID="HastaLabel" runat="server" Text="Hasta:"></asp:Label>

                                </div>
                                <div class="col s2">

                                    <asp:TextBox ID="HastaTextBox" runat="server" type="date"></asp:TextBox>
                                </div>
                                <div class="col s4">
                                    <asp:Label ID="ActivadorLabel" runat="server" Text="Activar Filtro por Fecha"></asp:Label>


                                </div>
                                <div class="col s3 switch">
                                    <label>

                                        <asp:CheckBox ID="ONCheckBox" runat="server" />
                                        <span class="lever"></span>

                                    </label>
                                </div>

                            </div>
                            <div class="row">
                                <div class=" col s12 m12 l2 ">
                                    <asp:GridView ID="EstudianteGridView" CssClass="Table responsive-table table-of-contents highlight" runat="server">
                                        <Columns>
                                            <asp:HyperLinkField
                                                DataNavigateUrlFields="EstudianteId"
                                                DataNavigateUrlFormatString="/Registros/rEstudiantes.aspx?ID={0}"
                                                Text="Editar"
                                                ControlStyle-CssClass="btn waves-effect white-text" />
                                        </Columns>
                                    </asp:GridView>

                                </div>
                            </div>
                        </div>

                    </div>
                </div>

                <div class="card-action">
                    <a class="waves-effect waves-light btn modal-trigger" href="#modal1"><i class="material-icons prefix">print</i></a>

                </div>
                <!-- Modal Trigger -->


                <!-- Modal Structure -->
                <div id="modal1" class="modal modal-fixed-footer">

                    <div class="modal-content">
                        <rsweb:ReportViewer ID="EstudianteReportViewer" runat="server" Width="721px"></rsweb:ReportViewer>
                    </div>
                    <div class="modal-footer">
                       
                        <asp:LinkButton  ID="ImprimirButton" CausesValidation="false" CssClass=" waves-effect green darken-1 white-text btn " runat="server" Style="left: 0px; top: 1px"><i class="material-icons prefix">repeat</i></asp:LinkButton>
                        <a href="#!" class=" modal-action modal-close waves-effect waves-green btn-flat">Cerrar</a>
                    </div>
                </div>

            </div>
        </div>

    </div>
</asp:Content>
