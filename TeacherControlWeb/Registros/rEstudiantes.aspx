<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="rEstudiantes.aspx.cs" Inherits="TeacherControlWeb.rEstudiantes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class=" container">

        <%--<div class="row center"> Registro de Usuarios</div>--%>
        <div class="row">
            <div class=" col s12">

                <div class="card-panel">
                    <div class=" card-title center-align light-green-text">
                        <h3 class="center">Registro de Estudiantes</h3>
                        <asp:Label ID="FechaLabel" CssClass="amber-text center" runat="server"></asp:Label><br />
                    </div>
                    <div class="card-small">
                        <div class=" card-content">
                            <%-- Imagen --%>
                            <div class="row">
                                <div class=" circle responsive-img col s12 center-align">
                                    <asp:Image ID="Imagen" runat="server" CssClass=" circle-clipper avatar" Height="93px" Width="146px" ImageUrl="/img/images.png" />

                                </div>
                            </div>
                            <div class="row">
                                <div class="col s8 center-align">
                                    <asp:FileUpload ID="CargarArchivoBTN" runat="server" CssClass=" input-field" ForeColor="#3366FF" ViewStateMode="Enabled" Style="left: 0px; top: 0px; width: 281px" />
                                </div>
                                <div class="col s4">

                                    <asp:LinkButton ID="CargarImgButton" runat="server" CssClass=" waves-effect blue darken-1 white-text btn" OnClick="CargarImgButton_Click"><i class="material-icons prefix">input</i></asp:LinkButton>
                                </div>
                            </div>

                            <%-- Id --%>
                            <div class="row">
                                <div class="input-field col s3">
                                    <i class="material-icons prefix">turned_in</i>
                                    <label for="IdTextBox">Id:</label>
                                    <asp:TextBox CssClass="validate" ID="IdTextBox" runat="server"></asp:TextBox>

                                </div>
                                <div class="col s3">
                                    <a class="waves-effect blue darken-1 white-text btn modal-trigger" href="#modal1"><i class="material-icons prefix">search</i></a>
                                </div>

                            </div>
                            <%-- Matricula --%>
                            <div class="row">
                                <div class="input-field col s8">

                                    <i class="material-icons prefix">account_circle</i>
                                    <label for="MatriculaTextBox">Matricula:</label>
                                    <asp:TextBox CssClass="validate" ID="MatriculaTextBox" runat="server"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Solo se Aceptan Matriculas Numericas" Text="*" ControlToValidate="MatriculaTextBox" ForeColor="Red" ValidationGroup="G" ValidationExpression="\d{8}"></asp:RegularExpressionValidator>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Introduzca una Matricula." ValidationGroup="G" ControlToValidate="MatriculaTextBox" ForeColor="Red">*</asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <%-- Nombres --%>
                            <div class="row">
                                <div class="input-field col s8">
                                    <i class="material-icons prefix">perm_identity</i>
                                    <label for="NombresTextBox">Nombres:</label>
                                    <asp:TextBox CssClass="validate" ID="NombresTextBox" runat="server"></asp:TextBox>
                                    <asp:RegularExpressionValidator ControlToValidate="NombresTextBox" ID="RegularExpressionValidator6" ValidationExpression="^[a-zA-Z/s]{3,60}$" runat="server" ErrorMessage="Solo textos." ValidationGroup="G" ForeColor="Red">*</asp:RegularExpressionValidator>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Introduzca Nombre Y Apellidos del Estudiante." ValidationGroup="G" ControlToValidate="NombresTextBox" ForeColor="Red">*</asp:RequiredFieldValidator>
                                </div>
                            </div>

                            <%-- Celular --%>
                            <div class="row">
                                <div class="input-field col s6">
                                    <i class="material-icons prefix">phone</i>
                                    <label for="TelefonoTextBox">Celular:</label>
                                    <asp:TextBox CssClass=" valign-wrapper" ID="TelefonoTextBox" runat="server"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Formato Incorrecto" Text="*" ControlToValidate="TelefonoTextBox" ForeColor="Red" ValidationGroup="G" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}"></asp:RegularExpressionValidator>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Introduzca un Numero Telefonico." ValidationGroup="G" ControlToValidate="TelefonoTextBox" ForeColor="Red">*</asp:RequiredFieldValidator>
                                </div>
                            </div>

                            <%-- Email --%>
                            <div class="row">
                                <div class="input-field col m6 l6 s12">
                                    <i class="material-icons prefix">email</i>
                                    <label for="EmailTextBox" data-error="wrong" data-success="right">Email:</label>
                                    <asp:TextBox CssClass="validate" ID="EmailTextBox" runat="server" TextMode="Email"></asp:TextBox>
                                     <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Formato Incorrecto" Text="*" ControlToValidate="EmailTextBox" ForeColor="Red" ValidationGroup="G" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ></asp:RegularExpressionValidator>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Introduzca un e-Mail." ValidationGroup="G" ControlToValidate="EmailTextBox" ForeColor="Red">*</asp:RequiredFieldValidator>
                                </div>
                               
                            </div>
                            <%-- Direccion --%>
                            <div class="row">
                                <div class="input-field col s12">
                                    <i class="material-icons prefix">email</i>
                                    <label for="DireccionTextBox" data-error="wrong" data-success="right">Direccion:</label>
                                    <asp:TextBox CssClass="validate" ID="DireccionTextBox" runat="server" TextMode="SingleLine"></asp:TextBox>
                                </div>
                                    
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Introduzca la Direccion." ValidationGroup="G" ControlToValidate="DireccionTextBox" ForeColor="Red">*</asp:RequiredFieldValidator>
                            </div>
                            <%--Genero  --%>
                            <div class="row">
                                <div class=" col s2 m2 l2">
                                    <b>Sexo:</b>
                                </div>
                                <div class="input-field col s2">
                                    <%-- <i class="material-icons prefix">vpn_key</i>--%>
                                    <asp:RadioButton ID="McRadioButton" Text="M" GroupName="Sexo" runat="server" />
                                    <asp:RadioButton ID="FmRadioButton" Text="F" GroupName="Sexo" runat="server" />
                                </div>
                                <div class="input-field col s2 ">
                                    <%-- <i class="material-icons prefix">vpn_key</i>--%>
                                </div>
                            </div>
                            <%--Fechar Nacimiento--%>
                            <div class="row">
                                <div class=" col s2 m2 l2">
                                    <b>Fecha de Nacimiento:</b>
                                </div>
                                <div class="input-field col s6 m3 l3">
                                   
                                    <asp:TextBox CssClass="validate" ID="FNacTextBox" runat="server" TextMode="Date" MaxLength="10"></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Introduzca la Fecha de Nacimiento del Estudiante." ValidationGroup="G" ControlToValidate="FNacTextBox" ForeColor="Red">*</asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <%-- Curso --%>
                            <div class="row">
                                <div class=" col s2 m2 l2">
                                    <b>Cursos:</b>
                                </div>
                                <div class=" input-field col s4 m4 l4">

                                    <asp:DropDownList ToolTip="Lista de Cursos" ID="CursosDropDownList" runat="server" CssClass="select-dropdown accent-1 btn  white black-text">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <%-- Grupo --%>
                            <div class="row">

                                <div class=" col s2 m2 l2">
                                    <b>Grupos:</b>
                                </div>
                                <div class=" col s4 m4 l4">

                                    <asp:DropDownList ToolTip="Lista de Grupo" ID="GruposDropDownList" runat="server" CssClass="select-dropdown accent-1 btn white black-text">
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col s3"></div>
                        <div class="col s6">
                            <div class="card-action center">
                                <asp:ValidationSummary ID="ValidationSummary1" ValidationGroup="G" runat="server" BorderStyle="Dotted" ForeColor="#CC0000" HeaderText="Atencion!" />
                                <asp:Button CssClass="waves-effect  light-blue lighten-1 btn " ID="NuevoButton" runat="server" Text="Nuevo" OnClick="NuevoButton_Click" />
                                <asp:Button CssClass="waves-effect  waves-light btn" ValidationGroup="G" ID="GuardarButton" runat="server" Text="Guardar" Style="left: 0px; top: 0px" OnClick="GuardarButton_Click" />
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


</asp:Content>
