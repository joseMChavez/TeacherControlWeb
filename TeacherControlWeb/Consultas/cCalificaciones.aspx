﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="cCalificaciones.aspx.cs" Inherits="TeacherControlWeb.Consultas.cCalificaciones" %>

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
                        <h3>Consulta de Usuarios</h3>
                    </div>
                    <div class="card-small">
                        <div class="card-content">
                            <div class="row">
                                <div class=" col s1">
                                    <asp:Label CssClass=" select-label" ID="FiltroLabel" runat="server" Text="Filtrar por:"></asp:Label>
                                </div>
                                <div class="col s3">
                                    <asp:DropDownList ToolTip="Tipo de Usuarios" ID="FiltroDropDownList" runat="server" CssClass="select-dropdown btn white black-text">
                                        <asp:ListItem Value="CalifficacionesId">Id</asp:ListItem>
                                        <asp:ListItem Value="Estudiante">Nombres</asp:ListItem>
                                        <asp:ListItem Value="E.Matricula">Matricula</asp:ListItem>
                                        <asp:ListItem Value="M.Materia">Materia</asp:ListItem>
                                        <asp:ListItem Value="C.Curso">Curso</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="input-field col s6">
                                    <asp:TextBox ID="FiltroTextBox" runat="server"></asp:TextBox>
                                </div>
                                <div class="col s2">
                                    <asp:LinkButton ToolTip="Buscar" ID="BuscarButton" runat="server" CssClass=" waves-effect blue darken-1 white-text btn"><i class="material-icons prefix">search</i></asp:LinkButton>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col s3">
                                    <asp:Label ID="ActivadorLabel" runat="server" Text="Activar"></asp:Label>

                                </div>
                                <div class="col s1">
                                    <asp:CheckBox ID="ActivadorCheckBox" runat="server" /></div>
                                <div class="col s2">
                                    <asp:Label ID="DesdeLabel" runat="server" Text="Desde:"></asp:Label>
                                    <asp:TextBox ID="TextBox1" runat="server" Visible="false"></asp:TextBox>
                                </div>
                                <div class="col s2">
                                    <input id="iDesde" type="date" min="21/10/2016" value="21/10/2016" />
                                </div>
                                <div class="col s2">
                                    <asp:Label ID="HastaLabel" runat="server" Text="Hasta:"></asp:Label>
                                    <asp:TextBox ID="TextBox" runat="server" Visible="false"></asp:TextBox>
                                </div>
                                <div class="col s2">
                                    <input id="iHasta" type="date" value="21/10/2016" />
                                </div>

                            </div>
                            <div class="row">
                                <div class=" col s1 l2 Table responsive-table picker__table">
                                    <asp:GridView ID="CalificacionesGridView" runat="server"></asp:GridView>
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
                                <asp:LinkButton data-target="modal1" ID="ImprimirButton" CausesValidation="false" CssClass=" waves-effect green darken-1 white-text btn " runat="server" Style="left: 0px; top: 1px" OnClick="ImprimirButton_Click"><i class="material-icons prefix">repeat</i></asp:LinkButton>
                                <hr width="90%" align="center">
                                <rsweb:ReportViewer ID="CalificacionesReport" runat="server" Width="721px"></rsweb:ReportViewer>
                            </div>
                            <div class="modal-footer">
                                <a href="#!" class=" modal-action modal-close waves-effect waves-green btn-flat">Cerrar</a>
                            </div>
                        </div>
                  
            </div>
        </div>

    </div>
</asp:Content>
