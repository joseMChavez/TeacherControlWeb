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
                        <rsweb:ReportViewer ID="UsuariosReportViewer" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="824px">
                            <LocalReport ReportPath="Reportes\UsuariosReport.rdlc">
                                <DataSources>
                                    <rsweb:ReportDataSource DataSourceId="SqlDataSourceUsuarios" Name="DataSet1" />
                                </DataSources>
                            </LocalReport>
                        </rsweb:ReportViewer>
                        
                        <asp:SqlDataSource ID="SqlDataSourceUsuarios" runat="server" ConnectionString="<%$ ConnectionStrings:ConStr %>" SelectCommand="SELECT [Nombres], [UserName], [Email], [Telefono], [TipoUsuario] FROM [Usuarios]"></asp:SqlDataSource>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

