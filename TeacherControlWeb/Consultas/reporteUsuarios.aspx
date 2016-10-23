<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="reporteUsuarios.aspx.cs" Inherits="TeacherControlWeb.Consultas.reporteUsuarios" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="ContentPlaceHolder2">
    <div class="container">
         <asp:ScriptManager ID="ScriptManager1" runat="server">
                        </asp:ScriptManager>
        <div class="row">
            <div class="col s12">
                <div class="card">
                    <div class="card-content">
                        <div class="col s4">
                                <asp:LinkButton ID="CargarImgButton" runat="server" CssClass=" waves-effect blue darken-1 white-text btn" OnClick="CargarImgButton_Click">Cargar<i class="material-icons prefix">input</i></asp:LinkButton>
                                </div>
                        <rsweb:ReportViewer ID="UsuariosReportViewer" runat="server" Width="721px">

                        </rsweb:ReportViewer>
                        
                       
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

