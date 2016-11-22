<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="TeacherControlWeb.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Teacher Control</title>
    <link href="img/logo.ico" rel="icon" />
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet" />
    <link href="/css/materialize.css" rel="stylesheet" />
</head>
<body class="responsive-img col s12 m12 l12 container " background="/img/fondo2.jpg">

    <form id="form1" runat="server">

        <div class="container  right-aligned">
            <div class="container right-aligned">
                <div class="row">
                    <div class="col s12 m6 l8">
                        <div class="card center-on-small-only z-depth-4 ">
                            <div class="card-content center-align">
                                <span class="card-title black-text">Iniciar Sesion</span>

                                <div class="row">
                                    <div class="input-field col s12">
                                        <asp:TextBox ID="UserTextBox" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ControlToValidate="UserTextBox" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Introduzca el Nombre de usuario" ValidationGroup="G" ForeColor="Red">*</asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ControlToValidate="UserTextBox" ID="RegularExpressionValidator1" ValidationExpression="^[a-zA-Z./s]{3,20}$" runat="server" ErrorMessage="Formato Incorrecto" ValidationGroup="G" ForeColor="Red">*</asp:RegularExpressionValidator>
                                        <label class="active" for="UserTextBoxo" >Nombre Usuario</label>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="input-field col s12">
                                        <asp:TextBox ID="PassTextBox" runat="server" TextMode="Password"></asp:TextBox>
                                        <asp:RequiredFieldValidator ControlToValidate="PassTextBox" ID="RequiredFieldValidator2" runat="server" ErrorMessage="Introduzca la Clave" ValidationGroup="G" ForeColor="Red">*</asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ControlToValidate="PassTextBox" ID="RegularExpressionValidator2" ValidationExpression="^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{6,10}$" runat="server" ErrorMessage="Debe de Conter al Menos 6 digitos" ValidationGroup="G" ForeColor="Red">*</asp:RegularExpressionValidator>
                                        <label class="active" for="PassTextBox" >Contraseña</label>
                                    </div>
                                </div>
                                <div class="card-action center">
                                    <asp:Button CssClass="btn btn-block waves-effect waves-green" ValidationGroup="G" ID="EntrarButton" runat="server" Text="Entrar" OnClick="EntrarButton_Click" />

                                    <asp:CheckBox ID="RememberMeCheckBox" runat="server" Text="Recordarme" />

                                    <asp:HyperLink NavigateUrl="Registrar.aspx" ID="Registrarme" runat="server">NO Tienes una Cuenta Registrate</asp:HyperLink>
                                    <asp:ValidationSummary  ValidationGroup="G" ID="ValidationSummary1" runat="server" BorderStyle="Dotted" ForeColor="Red" HeaderText="Atencion" />
                                </div>

                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>


    </form>
</body>

</html>
