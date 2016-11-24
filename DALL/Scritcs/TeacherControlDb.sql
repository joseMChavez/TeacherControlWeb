Create Database TeacherControlWebDB
go
Use TeacherControlWeb
go

create table Usuarios(
			 UsuarioId int identity(1,1),
			 Nombres varchar(70),
			 UserName varchar(30),
			 Email varchar(100),
			 Telefono varchar(15),
			 Clave varchar(15),
			 ConfirmarClave Varchar(15),
			 Imagen varchar(Max),
			 TipoUsuario varchar(20),
			 primary key(UsuarioId)
) 
Go
create  table Cursos(
	CursoId int identity(1,1),
	UsuarioId int references Usuarios(UsuarioId),
	Descripcion varchar(50),
	 primary key (CursoId) 
)

go
CREATE TABLE Grupos(
  GrupoId int identity(1,1),
  CursoId int references Cursos(CursoId),
  UsuarioId int references Usuarios(UsuarioId),
  Descripcion varchar(15),
  primary key(GrupoId)
)

go
Create table Estudiantes( 
		EstudianteId int identity(1,1) primary key,
		UsuarioId int references Usuarios(UsuarioId),
		Matricula int,
		Nombre varchar(70),
		Genero bit,
		FechaNacimiento Date,
		Celular varchar(15),
		Email Varchar(70),
		Direccion varchar(100),
		CursoId int Foreign key References Cursos(CursoId),
		Grupo varchar(10),
		Fecha Date
)
Drop table Estudiantes

go
create table Materias(
        MateriaId int identity(1,1),
		UsuarioId int references Usuarios(UsuarioId),
		Descripcion varchar(100),
		primary key(MateriaId)
)

go
create table Asistencias(
       AsistenciaId int identity(1,1) primary key(AsistenciaId),
	   CursoId int  references Cursos(CursoId),
	   UsuarioId int references Usuarios(UsuarioId),
	   Grupo Varchar(30),
	   Fecha Date,
	   CantidaEst int,   
) 
go
Create table AsistenciaDetalle(
 Id int identity(1,1)  primary key(Id),
 Estudiante Varchar(70),
 Matricula int,
 AsistenciaId int references Asistencias(AsistenciaId),
 Estado varchar(15),

)

go
create table Calificaciones(
		CalificacionId int identity(1,1) primary key,
		CursoId int  references Cursos(CursoId), 
		UsuarioId int references Usuarios(UsuarioId),
		MateriaId int references Materias(MateriaId), 
	    Grupo varchar(20),
	    Fecha Date
)
go
create table CalificacionDetalle(
		Id int identity(1,1) primary key,
		CalificacionId int foreign key references Calificaciones(CalificacionId),
		 Estudiante Varchar(70),
		 Matricula int,
		Descripcion varchar(70),
		Puntuacion float
)


go
CREATE TABLE CategoriaCalificaciones
(
	CategoriaCalificacionesId INT identity(1,1) NOT NULL PRIMARY KEY, 
    Descripcion VARCHAR(100) NOT NULL
)

go

go
select * from  AsistenciaDetalle;
select * From Estudiante
Insert Into Asistencias(Curso,CursoGrupo,Fecha) values(1,'C','2016-03-31 09:21:32 PM',1) ;
Insert into AsistenciaDetalle(AsistenciaId,EstudianteId,Activo) Values(5,'Jose','Presente')
select A.AsistenciaId as Id,A.Curso, A.CursoGrupo as Grupo,AD.EstudianteId as Estudiante,AD.Activo as Estado, A.Fecha from Asistencias as  A Inner join AsistenciaDetalle as AD ON A.AsistenciaId=AD.AsistenciaId;
select E.Nombre, E.Matricula,C.Descripcion as Curso, E.Grupo as Seccion, YEar(GETDate())-YEAR(E.FechaNacimiento) as Edad from Estudiantes as E inner join Cursos as C on E.CursoId = C.CursoId

 Select * from CalificacionesPromedioView 
 select * from CalificacionDetalle
 select *  from EstudiantePorCursos
select * from Grupos_view
 select *  from AsistenciaPorEstudiante_View 

   select * from Calificaciones_view
