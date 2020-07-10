use BDAcademico
go 

if OBJECT_ID('TUsuarioE') is not null
	drop table TUsuarioE
go
create table TUsuarioE
(
	Usuario varchar(50) primary key,
	Contrasena varchar(200)
)
go

-----PA que permite ingresar un usuario con contraseña encriptada
if OBJECT_ID('spAgregarUsuarioE') is not null
	drop proc spAgregarUsuarioE 
go 
create proc spAgregarUsuarioE
@Usuario varchar(50),@Contrasena varchar(50)
as
begin
	insert into TUsuarioE values (@Usuario,@Contrasena)
end
go

exec spAgregarUsuarioE 'juansito','1234'
go
exec spAgregarUsuarioE 'pedro','1234'
go
exec spAgregarUsuarioE 'juanito','123'
go
exec spAgregarUsuarioE 'tony','12'
go
select * from TUsuarioE

-------PA LOGIN
if OBJECT_ID('spLoginUsuarioE') is not null
	drop proc spLoginUsuarioE
go
create proc spLoginUsuarioE
@Usuario varchar (50),@Contrasena varchar(5)
as
begin
	if exists (select Usuario from TUsuarioE where Usuario=@Usuario)
		----Desncriptar la contraseña
		declare @ContrasenaD varchar (50)
		set @ContrasenaD = (select CAST(DECRYPTBYPASSPHRASE('contra',Contrasena)as varchar (50))
		from TUsuarioE where Usuario=@Usuario)
		---Comparar contraseñas
		if (@Contrasena=@ContrasenaD)
		begin
			select CodError=0,Mensaje='Usuario correctamente logueado'
		end
	else
		select CodError=1, Mensaje='Error: Usuario no existe'
end
go

exec spLoginUsuarioE 'tony','12'
go

if OBJECT_ID('spActualizarContrasenass') is not null
drop proc spActualizarContrasenass
go

create proc spActualizarContrasenass
@Usuario varchar(50), @Contrasena varchar(50),@Contrasena2 varchar(50)
as
begin
	--validar que el Usuario que exista
	if exists (select Usuario from TUsuarioE where Usuario=@Usuario and Contrasena=@Contrasena)
		----Desncriptar la contraseña
		---Comparar contraseñas
	
		begin try
			update TUsuarioE set Contrasena=@Contrasena2 where Usuario=@Usuario 
			select CodError = 0, Mensaje='Contraseña actualizada correctamente'
		end try
		begin catch
			select CodError = 1, Mensaje = 'No se pudo actualizar'
		end catch
	else select CodError=1, Mensaje='Contraseña no existe'
end
go
exec spActualizarContrasenass 'juansito','1234','123456'
select * from TUsuarioE
-----------------------------------------------------------------------------------
-------Listar por semestre------------------

if OBJECT_ID('spListarSemestre') is not null
drop proc spListarSemestre

go
create proc spListarSemestre
@Usuario varchar(50), @Semestre varchar(50)
as
begin
declare @CodAlumno char(5)
	set @CodAlumno = (select CodAlumno from TAlumno where Usuario = @Usuario)
	
 
	select N.Semestre, N.CodAsignatura, A.Asignatura, N.Parcial1, N.Parcial2,N.NotaFinal
	from TNotas N inner join TAsignatura A on
		N.CodAsignatura = A.CodAsignatura
	where N.CodAlumno = @CodAlumno and N.Semestre=@Semestre
	
end

exec spListarSemestre 'cuellar@hotmail.com','2010-I'

select*from TAlumno
select*from TNotas
--------------Listar solo semestre---------------
if OBJECT_ID('spListarSolosemestre') is not null
drop proc spListarSolosemestre
go
create proc spListarSolosemestre
as
begin
select Semestre from TNotas
group by Semestre
end
go

exec spListarSolosemestre