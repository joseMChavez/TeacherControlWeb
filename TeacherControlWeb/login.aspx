<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="TeacherControlWeb.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Teacher Control</title>
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet" />
    <link href="/css/materialize.css" rel="stylesheet" />
</head>
<body class="responsive-img col s12 m12 l12 container background" background="/img/fondo2.jpg">

    <form id="form1" runat="server">

        <div class="container  center-align">
            <div class="container right-aligned">
                <div class="row">
                    <div class="col s12 m6 l8">
                        <div class="card center-on-small-only z-depth-4 ">
                            <div class="card-content center-align">
                                <span class="card-title black-text">Iniciar Sesion</span>

                                <div class="row">
                                    <div class="input-field col s12">
                                        <asp:TextBox ID="UserTextBox" runat="server"></asp:TextBox>
                                        <label for="UserTextBoxo" class="active">Nombre Usuario</label>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="input-field col s12">
                                        <asp:TextBox ID="PassTextBox" runat="server" TextMode="Password"></asp:TextBox>

                                        <label for="PassTextBox" class="active">Contraseña</label>
                                    </div>
                                </div>
                                <div class="card-action center">
                                    <asp:Button CssClass="btn btn-block waves-effect waves-green" ID="EntrarButton" runat="server" Text="Entrar" />
                                    
                                            <asp:CheckBox ID="RememberMeCheckBox" runat="server" Text="Recordarme" />
                                            
                                    </div>
                                
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
