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
			 Fecha date,
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

select * from Materias where UsuarioId=1 and MateriaId=2;
 Select * from CalificacionesPromedioView 
 select * from CalificacionDetalle
 Select * from Grupos_View Where Id=1;
 select *  from Cursos where UsuarioId = 1 and CursoId=1
 
 Update Cursos set Descripcion = 'Lab B de Sis' where UsuarioId = 1 and CursoId=1;
select * from CalificacionesPromedioView where C.UsuarioId=1
 select *  from Asistencia_View
--create view Asistencia_View as
-- select A.UsuarioId as Id,CS.Descripcion as Curso,A.Grupo as Seccion,A.CantidaEst as Asistencia, case AD.Estado when 'Presente' then COUNT(AD.Id) else '0' end as Presencias,case AD.Estado when 'Ausente' then COUNT(AD.Id) else '0' end as Ausencias,case AD.Estado when 'Excusas' then COUNT(AD.Id) else '0' end as Excusas,A.Fecha from Asistencias A inner join AsistenciaDetalle as AD on A.AsistenciaId = AD.AsistenciaId inner join Cursos CS on A.CursoId=CS.CursoId inner join Usuarios U on A.UsuarioId = U.UsuarioId group by A.UsuarioId,CS.Descripcion,A.Grupo,A.CantidaEst,A.Fecha,AD.Estado 
----create view CalificacionesPromedioView as
-- select
--       C.CalificacionId as Id, Cs.Descripcion as Curso,G.Descripcion as Seccion, CD.Estudiante, CD.Matricula ,M.Descripcion as Materia, Sum(CD.Puntuacion) as Puntos_Acumulados, Sum(CD.Puntuacion)/100 as Promedio,case when Sum(CD.Puntuacion)>=70 then 'Aprobado' else 'Reprobado' end as Estado
--  from 
--  Calificaciones as C inner join CalificacionDetalle as CD on C.CalificacionId= CD.CalificacionId
--   inner join Materias as M on M.MateriaId = C.MateriaId 
--   inner join Cursos Cs on C.CursoId = Cs.CursoId 
--   left join Grupos G on Cs.CursoId = G.CursoId
--   inner join Usuarios U on C.UsuarioId = U.UsuarioId
--   Group by C.CalificacionId, CD.Estudiante, CD.Matricula,M.Descripcion, Cs.Descripcion, G.Descripcion;
   --select * from Calificaciones_view
   --select E.EstudianteId Id, E.Nombre, E.Matricula, case E.Genero when 1 then 'M' Else 'F' end as Sexo, E.Celular, E.Email,E.Direccion,C.Descripcion as Curso, E.Grupo as Seccion, YEar(GETDate())-YEAR(E.FechaNacimiento) as Edad, E.Fecha from Estudiantes as E inner join Cursos as C on E.CursoId = C.CursoId inner join Usuarios as U on E.UsuarioId= U.UsuarioId where E.UsuarioId =3 ;