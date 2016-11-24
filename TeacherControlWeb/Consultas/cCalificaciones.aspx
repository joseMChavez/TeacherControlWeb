<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="cCalificaciones.aspx.cs" Inherits="TeacherControlWeb.Consultas.cCalificaciones" %>

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
                        <h3>Consulta de Calificaciones</h3>
                    </div>
                    <div class="card-small">
                        <div class="card-content">
                            <div class ="row">
                                <div class="col s6">
                                    <asp:DropDownList ID="TipoDropDownL" runat="server" CssClass="select-dropdown btn white black-text" AutoPostBack="True" OnSelectedIndexChanged="TipoDropDownL_SelectedIndexChanged">
                                        <asp:ListItem Value="1">Listado de Calificaciones</asp:ListItem>
                                        <asp:ListItem Value="0">Calificaciones Acumuladas</asp:ListItem>
                                        
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="row">
                                <div class=" col s1">
                                    <asp:Label CssClass=" select-label" ID="FiltroLabel" runat="server" Text="Filtrar por:"></asp:Label>
                                </div>
                                <div id="ListaFiltro" runat="server" class="col s3">
                                    <asp:DropDownList ID="FiltroDropDownList" runat="server" CssClass="select-dropdown btn white black-text">
                                        <asp:ListItem Value="Id">Id</asp:ListItem>
                                        <asp:ListItem Value="Curso">Curso</asp:ListItem>
                                        <asp:ListItem Value="Materia">Materia</asp:ListItem>
                                        <asp:ListItem Value="Estudiante">Estudiante</asp:ListItem>
                                         <asp:ListItem Value="Matricula">Matricula</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                 <div id="FiltroDDL" runat="server" class="col s3">
                                    <asp:DropDownList ID="FiltroDropDownList2" runat="server" CssClass="select-dropdown btn white black-text">
                                        <asp:ListItem Value="Id">Id</asp:ListItem>
                                        <asp:ListItem Value="Curso">Curso</asp:ListItem>
                                       
                                        <asp:ListItem Value="Estudiante">Estudiante</asp:ListItem>
                                         <asp:ListItem Value="Matricula">Matricula</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="input-field col s6">
                                    <asp:TextBox ID="FiltroTextBox" runat="server"></asp:TextBox>
                                </div>
                                <div class="col s2">
                                    <asp:LinkButton ToolTip="Buscar" ID="BuscarButton" runat="server" CssClass=" waves-effect blue darken-1 white-text btn" OnClick="BuscarButton_Click"><i class="material-icons prefix">search</i></asp:LinkButton>
                                </div>
                            </div>

                            <div id="Desde" runat="server" class="row">

                                <div class="col s1">
                                    <asp:Label ID="DesdeLabel" runat="server" Text="Desde:"></asp:Label>

                                </div>
                                <div id="DesdeDos" runat="server" class="col s2">

                                    <asp:TextBox ID="DesdeTextBox" runat="server" type="date"></asp:TextBox>
                                </div>
                                <div id="Hasta" runat="server" class="col s1">
                                    <asp:Label ID="HastaLabel" runat="server" Text="Hasta:"></asp:Label>

                                </div>
                                <div id="Hasta2" runat="server" class="col s2">

                                    <asp:TextBox ID="HastaTextBox" runat="server" type="date"></asp:TextBox>
                                </div>
                                <div id="Activador1" runat="server" class="col s1">
                                    <asp:Label ID="ActivadorLabel" runat="server" Text="Activar Filtro por Fecha."></asp:Label>
                                </div>
                                <div id="Activador2" runat="server" class="col s5 switch">
                                    <label>

                                        <asp:CheckBox ID="ONCheckBox" runat="server" />
                                        <span class="lever"></span>

                                    </label>
                                </div>

                            </div>
                            <div class="row">
                                <div class=" col s12 m12 l2 ">
                                    <asp:GridView ID="CalificacionesGridView" CssClass="Table responsive-table table-of-contents highlight" runat="server"></asp:GridView>
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


                        <rsweb:ReportViewer ID="CalificacionesReport" runat="server" Width="721px"></rsweb:ReportViewer>
                    </div>
                    <div class="modal-footer">
                        <hr width="90%" align="center">
                        <asp:LinkButton data-target="modal1" ID="ImprimirButton" CausesValidation="false" CssClass=" waves-effect green darken-1 white-text btn " runat="server" Style="left: 0px; top: 1px" OnClick="ImprimirButton_Click"><i class="material-icons prefix">repeat</i></asp:LinkButton>
                        <a href="#!" class=" modal-action modal-close waves-effect waves-green btn-flat">Cerrar</a>
                    </div>
                </div>

            </div>
        </div>

    </div>
</asp:Content>
