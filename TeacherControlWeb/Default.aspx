<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TeacherControlWeb.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <!--panel-->
<div class="section no-pad-bot" id="index-banner">
    <div class="container">
        <h1 class="text_h center header cd-headline letters type">
            <span>Teacher Control es </span> 
            <span class="cd-words-wrapper waiting">
                <b class="is-visible">Comodidad.</b>
                <b>Modernidad.</b>
                <b>Portabilidad.</b>
            </span>
        </h1>
    </div>
</div>
<div class=" parallax-container">
    <div class="parallax"><img src="img/fondo2.jpg"></div>
</div>
<div class="section scrollspy" id="work">
    <div class="container">
        <h2 class="header text_b mdi-action-label-outline">Facil Acceso </h2>
        <div class="row">
            <div class="col s10 m4 l4">
                <div class="card">
                    <div class="card-image waves-effect waves-block waves-light">
                        <img class=" circle activator responsive-img" src="/img/e.png">
                    </div>
                    <div class="card-content">
                        <span class="card-title activator grey-text text-darken-4">Estudiantes <i class="material-icons right">arrow_drop_up</i></span>
                        <p><a href="/Registros/rEstudiantes.aspx">Regristrar Estudiantes</a></p>
                    </div>
                    <div class="card-reveal">
                        <span class="card-title grey-text text-darken-4">Registro de estudiantes <i class="material-icons right">arrow_drop_down</i></span>
                        <p>Esta opcion te permite direcionarte al registro de estudiantes.</p>
                    </div>
                </div>
            </div>
            <div class="col s12 m4 l4">
                <div class="card">
                    <div class="card-image waves-effect waves-block waves-light">
                        <img class=" circle activator responsive-img" src="img/Icon.png">
                    </div>
                    <div class="card-content">
                        <span class="card-title activator grey-text text-darken-4">Cursos<i class="material-icons right">arrow_drop_up</i></span>
                        <p><a href="/Registros/rCursos.aspx">Registrar Curso</a></p>
                    </div>
                    <div class="card-reveal">
                        <span class="card-title grey-text text-darken-4">Registro de Curos<i class="material-icons right">arrow_drop_down</i></span>
                        <p>Es Conveniente que Registre Cursos antes de intentar Registrar Estudiantes, y Luego Registre Grupos</p>
                    </div>
                </div>
            </div>
            <div class="col s12 m4 l4">
                <div class="card">
                    <div class="card-image waves-effect waves-block waves-light">
                        <img class="activator circle responsive-img" src="img/Asistencia.png">
                    </div>
                    <div class="card-content">
                        <span class="card-title activator grey-text text-darken-4">Asistencias <i class="material-icons prefix right">arrow_drop_up</i></span>
                        <p><a href="/Registros/rAsistencia.aspx">Pasar Lista</a></p>
                    </div>
                    <div class="card-reveal">
                        <span class="card-title grey-text text-darken-4">Registro de Asistencias<i class="material-icons prefix right">arrow_drop_down</i></span>
                        <p>Pasar Lista es algo que se realiza cada vez que se realiza o se imparte clases, Registre Cursos Y Grupos.</p>
                    </div>
                </div>
            </div>
            <div class="col s12 m4 l4">
                <div class="card">
                    <div class="card-image waves-effect waves-block waves-light">
                        <img class="activator circle responsive-img" src="/img/cali.jpg">
                    </div>
                    <div class="card-content">
                        <span class="card-title activator grey-text text-darken-4">Calificaciones <i class="material-icons right">arrow_drop_up</i></span>
                        <p><a href="/Registros/rCalificaciones.aspx">Agreagr Calificaciones</a></p>
                    </div>
                    <div class="card-reveal">
                        <span class="card-title grey-text text-darken-4">Registro de Calificaciones<i class="material-icons right">arrow_drop_down</i></span>
                        <p>Te facilitamos poder agregar calificaciones a tus estudiantes una vez, se la ganen, cree las Categorias de Calificaiones un ejemplo seria una Parcial.</p>
                    </div>
                </div>
            </div>
            <div class="col s12 m4 l4">
                <div class="card">
                    <div class="card-image waves-effect waves-block waves-light">
                        <img class="activator circle responsive-img" src="/img/book.png">
                    </div>
                    <div class="card-content">
                        <span class="card-title activator grey-text text-darken-4">Materias <i class="material-icons right">arrow_drop_up</i></span>
                        <p><a href="/Registros/rMaterias.aspx">Registrar Materias</a></p>
                    </div>
                    <div class="card-reveal">
                        <span class="card-title grey-text text-darken-4">Registro de Calificaciones <i class="material-icons right">arrow_drop_down</i></span>
                        <p>Aqui Registras las Materias que impartes.</p>
                    </div>
                </div>
            </div>
        <%--    <div class="col s12 m4 l4">
                <div class="card">
                    <div class="card-image waves-effect waves-block waves-light">
                        <img class="activator" src="/img/images.png">
                    </div>
                    <div class="card-content">
                        <span class="card-title activator grey-text text-darken-4">Project Title <i class="mdi-navigation-more-vert right"></i></span>
                        <p><a href="#">Project link</a></p>
                    </div>
                    <div class="card-reveal">
                        <span class="card-title grey-text text-darken-4">Project Title <i class="mdi-navigation-close right"></i></span>
                        <p>Here is some more information about this project that is only revealed once clicked on.</p>
                    </div>
                </div>
            </div>--%>
        </div>
        <div class=" parallax-container">
    <div class=" parallax">
        <img src="img/cs.jpg" /> </div>
</div>
    </div>
</div>
</asp:Content>
