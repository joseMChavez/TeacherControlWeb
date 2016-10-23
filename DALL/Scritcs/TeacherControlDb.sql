Create Database TeacherControlWebDB
go

go
Drop table Usuarios;
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
create table Cursos(
	CursoId int identity(1,1),
	Descripcion varchar(50),
	 primary key (CursoId) 
)
go
CREATE TABLE Grupos(
  GrupoId int identity(1,1),
  Descripcion varchar(15),
  primary key(GrupoId)
)

go
Create table Estudiantes( 
		EstudianteId int identity(1,1) primary key,
		Matricula int,
		Nombre varchar(70),
		Genero bit,
		FechaNacimiento Date,
		Edad int,
		Celular varchar(15),
		Email Varchar(70),
		Direccion varchar(100),
		CursoId int Foreign key References Cursos(CursoId),
		Grupo varchar(10),
		
)

go
create table Materias(
        MateriaId int identity(1,1),
		Descripcion varchar(100),
		primary key(MateriaId)
)
go
create table Asistencias(
       AsistenciaId int identity(1,1),
	   CursoId int,
	   GrupoId int,
	   Fecha Date,
	   CantidaEst int,
	   foreign key(GrupoId) references Grupos(GrupoId),
	   foreign key(CursoId) references Cursos(CursoId),
	   primary key(AsistenciaId)
) 
go
Create table AsistenciaDetalle(
 Id int identity(1,1),
 EstudianteId  Int references Estudiantes(EstudianteId), 
 Matricula int,
 AsistenciaId int foreign key references Asistencias(AsistenciaId),
 Estado varchar(15),
 primary key(Id)
)
go
create table Calificaciones(
		CalificacionId int identity(1,1) primary key,
		EstudianteId int foreign key references Estudiantes(EstudianteId), 
		MateriaId int references Materias(MateriaId), 
	    Curso varchar(20),
	    Grupo varchar(5),
		TotalPuntos float,
	    Fecha DateTime	
)
go
create table CalificacionDetalle(
		Id int identity(1,1) primary key,
		CalificacionId int foreign key references Calificaciones(CalificacionId),
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