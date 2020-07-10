--PA para TCarrera
--Maricarmen DIAZ CHAVEZ
---20/2/20
use BDAcademico
go

---Listar Usuario
if OBJECT_ID('spListarUsuario') is not null
drop proc spListarUsuario
go
create proc spListarUsuario
as
begin
select Usuario, Contrasena from TUsuario
end
go
--Consulta
execute spListarUsuario
go

-- PA para Agregar Usuario
if OBJECT_ID('spAgregarUsuario') is not null
   drop proc spAgregarUsuario
go
create proc spAgregarUsuario
 @Usuario varchar(50),@Contrasena varchar (50)
as
begin
  --Validacion de parametros CodError = 0 (Correcto), CodError = 1, (Error)
  --Validacion la clave primaria
  if not exists(select Usuario from TUsuario where Usuario=@Usuario)
  --Validacion que la Usuario no se duplique
  if not exists(select Usuario from TUsuario where Usuario=@Usuario)
  begin
     insert into TUsuario values (@Usuario,@Contrasena)
	 select CodError = 0,Mensaje ='Usuario insertada en TUsuario'
  end
     else select CodError = 1,Mensaje ='Error: Usuario duplicada en TUsuario'
   else select CodError = 1,Mensaje ='Error: clave duplicada en TUsuario'
end 
go

execute spAgregarUsuario 'aaaaa','1234'
go

--Probar el PA
execute spAgregarUsuario 'mari@gmail.com','m123'
go
execute spAgregarUsuario 'chauca@gmail.com','m123'
go
execute spAgregarUsuario 'chaucas@gmail.com','asd'
go
execute spAgregarUsuario 'castelo@gmail.com','asdqq'
go
execute spAgregarUsuario 'rigucha@gmail.com','pimbo'
go


select*from TAlumno
select*from TUsuario

---Eliminar Usuario
if OBJECT_ID('spEliminarUsuario') is not null
drop proc spEliminarUsuario
go
create proc spEliminarUsuario
@Usuario varchar(50)
as
begin
	--Usuario exista
	if exists(select Usuario from TUsuario where Usuario=@Usuario)
	--Usuario no este en la tabla Docente
		if not exists(select Usuario from TDocente where Usuario=@Usuario)
		--Usuario no este en la tabla Alumno
			if not exists(select Usuario from TAlumno where Usuario=@Usuario) 
			begin
				delete from TUsuario where Usuario=@Usuario
				select CodError=0, Mensaje='Error:Usuario eliminado de TUsuario'
			end
			else select CodError=1, Mensaje='Error:Usuario existe en TAlumno'
		else select CodError=1, Mensaje='Error:Usuario existe en TDocente'
	else select CodError=1, Mensaje='Error:Usuario no existe en TUsuario'
end
go
--probar el PA
execute spEliminarUsuario 'maril@gmail.com'
go

--actualizar Usuario
if OBJECT_ID('spActualizarUsuario') is not null
drop proc spActualizarUsuario
go

create proc spActualizarUsuario
@Usuario varchar(50), @Contrasena varchar(50)
as
begin
	--validar que el Usuario que exista
	if exists(select Usuario from TUsuario where Usuario=@Usuario)
		if not exists(select Contrasena from TUsuario where Contrasena=@Contrasena)
		begin
			update TUsuario set Contrasena=@Contrasena where Usuario=@Usuario
			select CodError=0, Mensaje='Contrasena actualizada en TUsuario'
		end
		else select CodError=1, Mensaje='ERROR: Contraseña duplicada en TUsuario'
	else select CodError=1, Mensaje='ERROR: Usuario no existe en TUsuario'
end
go
--probar PA
execute spActualizarUsuario 'mari@gmail.com','ma123'
go



--busqueda Usuario

if OBJECT_ID('spBuscarUsuario') is not null
drop proc spBuscarUsuario
go

create proc spBuscarUsuario
@Texto varchar(50), @Criterio varchar(50)
as
begin
	If(@Criterio='Usuario')
		select Usuario, Contrasena from TUsuario where Usuario=@Texto
end
go
--Probar PA
execute spBuscarUsuario 'mari@gmail.com','Usuario'
go

-- PA que permita hacer Login
if OBJECT_ID('spLoginUsuario') is not null
	drop proc spLoginUsuario
go
create proc spLoginUsuario
@Usuario varchar(50), @Contrasena varchar(50)
as
begin
	if exists(select Usuario from TUsuario where Usuario = @Usuario and Contrasena=@Contrasena)
		begin
			declare @TipoUsuario varchar(20)
			if exists(select Usuario from TAlumno where Usuario = @Usuario)
				set @TipoUsuario = 'Alumno'
			else if exists(select Usuario from TDocente where Usuario = @Usuario)
				set @TipoUsuario = 'Docente'
			select CodError = 0, Mensaje = @TipoUsuario
		end
	else select CodError = 1, Mensaje = 'Error: Usuario y/o Contraseñas Incorrectas'
end
go

exec spLoginUsuario 'cuellar@hotmail.com','1234'
go


select*from TUsuario

update TUsuario set Contrasena ='7110eda4d09e062aa5e4a390b0a572ac0d2c0220'
where Usuario='alquiper@hotmail.com'


------------------PA ACTUALIZAR CONTRASEÑA---------------------
if OBJECT_ID('spActualizarContrasenaNueva') is not null
drop proc spActualizarContrasenaNueva
go

create proc spActualizarContrasenaNueva
@Usuario varchar(50), @Contrasena varchar(50),@Contrasena2 varchar(50)
as
begin
	--validar que el Usuario que exista
	if exists (select Usuario from TUsuario where Usuario=@Usuario and Contrasena=@Contrasena)
		----Desncriptar la contraseña
		---Comparar contraseñas
	
		begin try
			update TUsuario set Contrasena=@Contrasena2 where Usuario=@Usuario 
			select CodError = 0, Mensaje='Contraseña actualizada correctamente'
		end try
		begin catch
			select CodError = 1, Mensaje = 'No se pudo actualizar'
		end catch
	else select CodError=1, Mensaje='Contraseña no existe'
end
go
exec spActualizarContrasenaNueva 'cuellar@hotmail.com','1234','redes'

select * from TUsuario