﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="cUsuarios.aspx.cs" Inherits="TeacherControlWeb.Consultas.cUsuarios" %>

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
                                <div class="col s12 m2 l2">
                                    <asp:DropDownList ID="TipoDropDownL" runat="server" CssClass="select-dropdown btn white black-text" AutoPostBack="True" OnSelectedIndexChanged="TipoDropDownL_SelectedIndexChanged">
                                        <asp:ListItem Value="1">Lista</asp:ListItem>
                                        <asp:ListItem Value="0">Mosaico</asp:ListItem>

                                    </asp:DropDownList>
                                </div>
                                </div>
                            <div class="row">
                                <div class=" col s1">
                                    <asp:Label CssClass=" select-label" ID="FiltroLabel" runat="server" Text="Filtrar por:"></asp:Label>
                                </div>
                                <div class="col s3">
                                    <asp:DropDownList ToolTip="Tipo de Usuarios" ID="FiltroDropDownList" runat="server" CssClass="select-dropdown btn white black-text">
                                        <asp:ListItem Value="Nombres">Nombres</asp:ListItem>
                                        <asp:ListItem Value="UserName">Nombre de Usuario</asp:ListItem>
                                        <asp:ListItem Value="TipoUsuario">Tipo de Usuario</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="input-field col s6">
                                    <asp:TextBox ID="FiltroTextBox" runat="server"></asp:TextBox>
                                </div>
                                <div class="col s2">
                                    <asp:LinkButton ToolTip="Buscar" ID="BuscarButton" runat="server" CssClass=" waves-effect blue darken-1 white-text btn" OnClick="BuscarButton_Click"><i class="material-icons prefix">search</i></asp:LinkButton>
                                </div>
                            </div>
                             <div id="fecha" runat="server" class="row">

                                <div class="col s12 m1 l1">
                                    <asp:Label ID="DesdeLabel" runat="server" Text="Desde:"></asp:Label>

                                </div>
                                <div class="col s12 m2 l2">

                                    <asp:TextBox ID="DesdeTextBox" runat="server" type="date"></asp:TextBox>
                                </div>
                                <div class="col s12 m1 l1">
                                    <asp:Label ID="HastaLabel" runat="server" Text="Hasta:"></asp:Label>

                                </div>
                                <div class="col s12 m2 l2">

                                    <asp:TextBox ID="HastaTextBox" runat="server" type="date"></asp:TextBox>
                                </div>
                                <div class="col s10 m4 l4">
                                    <asp:Label ID="ActivadorLabel" runat="server" Text="Activar Filtro por Fecha"></asp:Label>


                                </div>
                                <div class="col s2 m3 l3 switch">
                                    <label>

                                        <asp:CheckBox ID="ONCheckBox" runat="server" />
                                        <span class="lever"></span>

                                    </label>
                                </div>

                            </div>
                            <div id="repeater" runat="server" class="row">
                                <asp:Repeater ID="UsuariosRepeater" runat="server">
                                    <ItemTemplate>
                                        <div class="col s4">
                                            <div class="card-panel light-blue lighten-1 white-text">
                                                <div class="card-title">
                                                    <asp:Label ID="NombresLabel" runat="server" Text='<%# Eval("Nombres")%>'></asp:Label>
                                                </div>
                                                <div class="card-image">
                                                    <img class=" responsive-img circle" alt="NO HAY" src='<%# Eval("Imagen")%>'>
                                                </div>
                                                <div class="card-content">
                                                    
                                                    <asp:Label ID="UserLabel" runat="server" Text='<%# Eval("UserName")%>'></asp:Label><br />
                                                    <asp:Label ID="EmailLabel" runat="server" Text='<%# Eval("Email")%>'></asp:Label><br />
                                                    <asp:Label ID="TellLabel" runat="server" Text='<%# Eval("Telefono")%>'></asp:Label>
                                                </div>
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                   
                                </asp:Repeater>
                            </div>
                            <div id="grid" runat="server" class="row">
                                <div class=" col s12 m12 l12 ">
                                    <asp:GridView ID="UGridView" CssClass="Table responsive-table table-of-contents highlight" runat="server">
                                        <Columns>
                                            <asp:HyperLinkField
                                                DataNavigateUrlFields="UsuarioId"
                                                DataNavigateUrlFormatString="/Registros/rUsuarios.aspx?ID={0}"
                                                Text="Editar"
                                                ControlStyle-CssClass="btn waves-effect white-text" />
                                        </Columns>
                                    </asp:GridView>

                                </div>
                                </div>
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
                        
                        <rsweb:ReportViewer ID="UsuariosReportViewer" runat="server" Width="721px"></rsweb:ReportViewer>
                    </div>
                    <div class="modal-footer">
                         <asp:LinkButton  data-target="modal1" ID="ImprimirButton" CausesValidation="false" CssClass=" waves-effect green darken-1 white-text btn" runat="server" OnClick="ImprimirButton_Click" Style="left: 0px; top: 1px"><i class="material-icons prefix">repeat</i></asp:LinkButton>
                        <a href="#!" class=" modal-action modal-close waves-effect waves-green btn-flat">Cerrar</a>
                    </div>
                </div>
            </div>
        </div>

    </div>

</asp:Content>
