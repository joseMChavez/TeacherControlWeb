<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registrar.aspx.cs" Inherits="TeacherControlWeb.Registrar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Teacher Control</title>
    <link href="img/logo.ico" rel="icon" />
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet" />

    <link href="/css/plugin-min.css" type="text/css" rel="stylesheet" />
    <link href="/css/custom-min.css" type="text/css" rel="stylesheet" />
    <link href="/css/materialize.css" type="text/css" rel="stylesheet" />
    <link href="/css/toastr.min.css" rel="stylesheet" />

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class=" container">


                <div class="row">
                    <div class=" col s12">

                        <div class="card-panel">
                            <div class=" card-title center-align light-green-text">
                                <a class="left-align amber-text" href="login.aspx">Retornar</a>
                                <h1>Registrar</h1>
                                  <asp:TextBox ID="FechaTbx" CssClass="amber-text center" TextMode="Date" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Seleccione una Fecha" Text="*" ValidationGroup="G" Display="Dynamic" ControlToValidate="FechaTbx">*</asp:RequiredFieldValidator>
                            </div>
                            <div class="card-small">
                                <div class=" card-content">
                                    <%-- Imagen --%>
                                    <div class="row">
                                        <div class=" card-image circle-clipper responsive-img col s12 center-align">
                                            <asp:Image ID="Imagen" runat="server" CssClass=" avatar" Height="93px" Width="146px" ImageUrl="/img/images.png" />

                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col s8 center-align">
                                            <asp:FileUpload ID="CargarArchivoBTN" runat="server" CssClass="file-field input-field" BorderStyle="Groove" ForeColor="#3366FF" ViewStateMode="Enabled" />
                                        </div>
                                        <div class="col s4 m3 l3">

                                            <asp:LinkButton ID="CargarImgButton" runat="server" CssClass=" waves-effect blue darken-1 white-text btn" OnClick="CargarImgButton_Click"><i class="material-icons prefix">input</i></asp:LinkButton>
                                        </div>
                                    </div>


                                    <%-- Nombres --%>
                                    <div class="row">
                                        <div class="input-field col s10 m6 l6">
                                            <i class="material-icons prefix">perm_identity</i>
                                            <label for="NombresTextBox">Nombres:</label>
                                            <asp:TextBox CssClass="validate" ID="NombresTextBox" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="NombresTextBox" ValidationGroup="G" ForeColor="red" ErrorMessage="Introduzca Su Nombre y Apellidos,">*</asp:RequiredFieldValidator>

                                        </div>
                                    </div>
                                    <%-- Nombre de Usuario --%>
                                    <div class="row">
                                        <div class="input-field col s10 m6 l6">

                                            <i class="material-icons prefix">account_circle</i>
                                            <label for="UserTextBox">Nombre de Usuarios:</label>
                                            <asp:TextBox CssClass="validate" ID="UserTextBox" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="UserTextBox" ValidationGroup="G" ForeColor="red" ErrorMessage="Introduzca un nombre de Usuario.">*</asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ControlToValidate="UserTextBox" ID="RegularExpressionValidator3" ValidationExpression="^[a-zA-Z./s]{3,20}$" runat="server" ErrorMessage="Formato Incorrecto" ValidationGroup="G" ForeColor="Red">*</asp:RegularExpressionValidator>
                                        </div>
                                    </div>
                                    <%-- Telefono --%>
                                    <div class="row">
                                        <div class="input-field col s10 m4 l4">
                                            <i class="material-icons prefix">phone</i>
                                            <label for="TelefonoTextBox">Telefono:</label>
                                            <asp:TextBox CssClass=" valign-wrapper" ID="TelefonoTextBox" runat="server" MaxLength="20"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TelefonoTextBox" ValidationGroup="G" ForeColor="red" ErrorMessage="introduzca un Numero de Telefono o Celular.">*</asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Numero de Telefono Incorrecto!" ForeColor="Red" ControlToValidate="TelefonoTextBox" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}" ValidationGroup="G">*</asp:RegularExpressionValidator>
                                        </div>
                                    </div>

                                    <%-- Email --%>
                                    <div class="row">
                                        <div class="input-field col s12 m8 l8">
                                            <i class="material-icons prefix">email</i>
                                            <label for="EmailTextBox" data-error="wrong" data-success="right">Email:</label>
                                            <asp:TextBox CssClass="validate" ID="EmailTextBox" runat="server" MaxLength="50"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="EmailTextBox" ValidationGroup="G" ForeColor="red" ErrorMessage="Introduzca un e-mail.">*</asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="EmailTextBox" ErrorMessage="e-mail Incorreco" ForeColor="#CC0000" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="G">*</asp:RegularExpressionValidator>
                                        </div>
                                    </div>
                                    <%-- clave --%>
                                    <div class="row">
                                        <div class="input-field col s10 m6 l6">
                                            <i class="material-icons prefix">vpn_key</i>
                                            <label for="ClaveTextBox">Contraseña:</label>
                                            <asp:TextBox CssClass="validate" ID="ClaveTextBox" runat="server" TextMode="Password" MaxLength="10"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Introduzca una Clave de Seguridad" ValidationGroup="G" ControlToValidate="ClaveTextBox"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ControlToValidate="ClaveTextBox" ID="RegularExpressionValidator4" ValidationExpression="^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{8,10}$" runat="server" ErrorMessage="Formato Incorrecto" ValidationGroup="G" ForeColor="Red">*</asp:RegularExpressionValidator>
                                        </div>
                                    </div>
                                    <%-- Repetir Clave --%>
                                    <div class="row">
                                        <div class="input-field col s10 m6 l6">
                                            <i class="material-icons prefix">lock</i>
                                            <label for="ConfirmarTextBox">Repetir Contraseña:</label>
                                            <asp:TextBox CssClass="validate" ID="ConfirmarTextBox" runat="server" TextMode="Password" MaxLength="10"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Se Debe de Repetir" ValidationGroup="G" ControlToValidate="ConfirmarTextBox"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ControlToValidate="ConfirmarTextBox" ID="RegularExpressionValidator5" ValidationExpression="^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{8,10}$" runat="server" ErrorMessage="Su Contraseña es Debil " ValidationGroup="G" ForeColor="Red">*</asp:RegularExpressionValidator>
                                        </div>
                                    </div>
                                    <%--    <%-- tipo de Usuario 
                            <div class="row">

                                <div class="input-field col s10 m6 l6">

                                    <i class="material-icons prefix">list</i>

                                    <asp:DropDownList ToolTip="Tipo de Usuarios" ID="TipoDropDownList" runat="server" CssClass="select-dropdown accent-1 btn white black-text">
                                        <asp:ListItem>Maestro</asp:ListItem>
                                        <asp:ListItem>Asistente</asp:ListItem>
                                        <asp:ListItem>Administrador</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>--%>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col m3 l3"></div>
                                <div class="col s12">
                                    <div class="card-action center">
                                        <asp:Button CssClass="waves-effect  waves-light btn" ID="GuardarButton" runat="server" Text="Registrar" Style="left: 0px; top: 0px" ValidationGroup="G" OnClick="GuardarButton_Click" />
                                    </div>
                                </div>
                                <div class=" center-align col m3 l3" style="width: 705px">
                                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="G" BorderStyle="Dotted" ForeColor="#CC0000" HeaderText="Atencion!" />
                                </div>

                            </div>

                        </div>


                    </div>
                </div>
            </div>

        </div>
    </form>
</body>
<script src="/js/jquery-2.2.0.min.js"></script>

<script src="/js/toastr.min.js"></script>
<script src="/js/plugin-min.js"></script>
<script src="/js/custom-min.js"></script>
<script src="/js/materialize.min.js"></script>
<script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/angularjs/1.0.7/angular.min.js"></script>

</html>
