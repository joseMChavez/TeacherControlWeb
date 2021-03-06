﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="cCursos.aspx.cs" Inherits="TeacherControlWeb.Consultas.cCursos" %>

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
                        <h3>Consulta de Cursos</h3>
                    </div>
                    <div class="card-small">
                        <div class="card-content">
                            <div class="row">
                                <div class=" col s2 m1 l1">
                                    <asp:Label CssClass=" select-label" ID="FiltroLabel" runat="server" Text="Filtrar por:"></asp:Label>
                                </div>
                                <div class="col s10 m3 l3">
                                    <asp:DropDownList ToolTip="Seleccione una Opcion" ID="FiltroDropDownList" runat="server" CssClass="select-dropdown btn white black-text">
                                        <asp:ListItem Value="C.CursoId">Id</asp:ListItem>
                                        <asp:ListItem Value="C.Descripcion">Descripcion</asp:ListItem>
                                       
                                    </asp:DropDownList>
                                </div>
                                <div class="input-field col s10 m6 l6">
                                    <asp:TextBox ID="FiltroTextBox" runat="server"></asp:TextBox>
                                </div>
                                <div class="col s2 m2 l2">
                                    <asp:LinkButton ToolTip="Buscar" ID="BuscarButton" runat="server" CssClass=" waves-effect blue darken-1 white-text btn" OnClick="BuscarButton_Click"><i class="material-icons prefix">search</i></asp:LinkButton>
                                </div>
                            </div>
                            <div class="row">
                                <asp:GridView ID="CursosGridView" CssClass=" striped highlight responsive-table picker__table" runat="server">
                                   <Columns>
                                        <asp:HyperLinkField
                                        DataNavigateUrlFields="ID"
                                        DataNavigateUrlFormatString="/Registros/rCursos.aspx?ID={0}"
                                        Text="Editar"
                                         ControlStyle-CssClass="btn waves-effect white-text" />
                                       </Columns>
                                </asp:GridView>

                            </div>
                        </div>

                    </div>
                </div>
                <div class="card-action">
                   
                </div>
                <!-- Modal Trigger -->
                <a class="waves-effect waves-light btn modal-trigger" href="#modal1"><i class="material-icons prefix">print</i></a>

                <!-- Modal Structure -->
                <div id="modal1" class="modal modal-fixed-footer">
                   
                    <div class="modal-content">
                        
                        <rsweb:ReportViewer ID="CursosReportViewer" runat="server" Width="730"></rsweb:ReportViewer>
                    </div>
                    <div class="modal-footer">
                       
                        <a href="#!" class=" modal-action modal-close waves-effect waves-green btn-flat">Cerrar</a>
                    </div>
                </div>
            </div>
        </div>

    </div>
</asp:Content>
