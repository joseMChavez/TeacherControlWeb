<%@ Page Title="Asistencias|Teacher Control" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="rAsistencia.aspx.cs" Inherits="TeacherControlWeb.Registros.rAsistencia" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class=" container">

        <div class="row">
            <div class=" col s12">

                <div class="card-panel">
                    <div class=" card-title center-align light-green-text">
                        <h3>Registro de Asitencia</h3>
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
                                    <%--<a class="waves-effect blue darken-1 white-text btn modal-trigger" href="#modal1"><i class="material-icons prefix" onclick="BuscarButton_Click">search</i></a>--%>
                                    <asp:LinkButton data-target="modal1" Visible="true" ToolTip="Buscar" ID="BuscarButton" runat="server" CssClass=" waves-effect blue darken-1 white-text btn modal-trigger"><i class="material-icons prefix">search</i></asp:LinkButton>
                                </div>
                                <div class="input-field col l2 m4 s8">
                                    <asp:Label ID="FechaLabel" runat="server" CssClass="amber-text" Text=""></asp:Label>
                                </div>

                            </div>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <%-- Cursos y Grupos --%>

                                    <div class="row">

                                        <%--Curso--%>
                                        <div class="  col s10 m4 l4">
                                            <asp:DropDownList ToolTip="Lista de Cursos" ID="CursoDropDownList" runat="server" CssClass="dropdown-button btn  white black-text" AutoPostBack="True" OnSelectedIndexChanged="CursoDropDownList_SelectedIndexChanged">
                                                <asp:ListItem Selected="false" Text="[Elija un Curso]"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                        <%--  Grupo--%>
                                        <div class="input-field col s10 m2 l2">
                                            <asp:DropDownList ID="GrupoDropDownList" runat="server" CssClass="dropdown-button btn white black-text" AutoPostBack="True">
                                                <asp:ListItem Selected="false" Text="[Elija un Grupo]"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                        <div class="col s10 m6 l6">
                                            <asp:LinkButton Visible="true" ToolTip="Cargar Estudiantes" ID="CargarButton" runat="server" CssClass=" waves-effect green darken-1 white-text btn " OnClick="CargarButton_Click"><i class="material-icons prefix">play_for_work</i></asp:LinkButton>

                                        </div>
                                    </div>


                                    <%-- Detalle --%>

                                    <div class="row">
                                        <%--Estudiantes--%>
                                        <div class=" input-field col s10 m3 l3">
                                            <asp:DropDownList ID="EstudiantesDropDownList" runat="server" CssClass="dropdown-button btn  white black-text" AutoPostBack="True" OnTextChanged="EstudiantesDropDownList_TextChanged">
                                                <asp:ListItem Selected="false" Text="[Elija un Estuadiante]"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                        <%--  Matricula--%>
                                        <div class=" input-field col s10 m3 l3">
                                            <asp:DropDownList ID="MatDropDownList" runat="server" CssClass="dropdown-button btn btn white black-text" AutoPostBack="True">
                                            </asp:DropDownList>
                                        </div>
                                        <%--Estado--%>
                                        <div class=" input-field col s10 m3 l3">
                                            <asp:DropDownList ID="EstadoDropDownList" runat="server" CssClass="dropdown-button btn  white black-text">
                                                <asp:ListItem Value="Presente">Presente</asp:ListItem>
                                                <asp:ListItem Value="Ausente">Ausente</asp:ListItem>
                                                <asp:ListItem Value="Excusa">Excusa</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                        <div class="col s1 m3 l2">
                                            <asp:LinkButton Visible="true" ToolTip="Agregar" ID="AddButton" runat="server" CssClass=" waves-effect green darken-1 white-text btn " OnClick="AddButton_Click"><i class="material-icons prefix">add</i></asp:LinkButton>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col s12 m12 l12">
                                            <asp:GridView CssClass="table-of-contents striped responsive-table highlight" ID="AsistenciaGridView" runat="server">
                                            </asp:GridView>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col s10 m4 l4">
                                            <asp:Label ID="letraLabel" runat="server" Text="Cantidad de Estudiantes: "></asp:Label>
                                        </div>
                                        <div class="col s2 m2 l2">
                                            <asp:Label ID="CantidadLabel" CssClass="amber-text" runat="server" Text=""></asp:Label>
                                        </div>
                                    </div>

                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <div class="row">
                                <div class="col s3"></div>
                                <div class="col s6">
                                    <div class="card-action center">

                                        <asp:Button CssClass="waves-effect  light-blue lighten-1 btn " ID="NuevoButton" runat="server" Text="Nuevo" OnClick="NuevoButton_Click" />
                                        <asp:Button CssClass="waves-effect  waves-light btn" ID="GuardarButton" runat="server" Text="Guardar" Style="left: 0px; top: 0px" OnClick="GuardarButton_Click" />
                                        <asp:Button CssClass="waves-effect  red  btn materialize-red " ID="EliminarButton" runat="server" Text="Eliminar" OnClick="EliminarButton_Click" />
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
