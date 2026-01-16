-------------------------   USUARIOS  --------------------------
CREATE TABLE Usuario(
	IdUsuario INT IDENTITY(1,1) PRIMARY KEY,
	Nombre NVARCHAR(50),
	Apellido NVARCHAR(50),
	Dni INT,
	Telefono bigint,
    Direccion NVARCHAR (100),
	Correo NVARCHAR (100),
    LoginName NVARCHAR (50),
    Password NVARCHAR (50),
    Rol NVARCHAR (50),
    Foto IMAGE NULL 
);
-------------------------   PROCEDIMIENTOS
GO
CREATE PROCEDURE sp_ListarUsuarios(
	@cTexto VARCHAR(225))
AS
BEGIN
	 SELECT * FROM USUARIO u
	 WHERE u.Nombre  LIKE '%'+@cTexto+ '%';
END

GO
CREATE PROCEDURE sp_ListarUsuariosAdoptantes(
	@cTexto VARCHAR(225))
AS
BEGIN
	 SELECT * FROM USUARIO u
	 WHERE u.Rol  LIKE '%'+@cTexto+ '%';
END

GO
CREATE PROCEDURE sp_AgregarUsuario
	@nombre NVARCHAR(50),
	@apellido NVARCHAR(50),
	@dni INT,
	@telefono bigint,
	@correo NVARCHAR(100),
	@direccion NVARCHAR(100),
	@loginName NVARCHAR(50),
	@password NVARCHAR(50),
	@rol NVARCHAR(50),
	@foto IMAGE

AS
	INSERT INTO USUARIO VALUES (@nombre,@apellido,@dni,@telefono,@correo,@direccion,@loginName,@password,@rol,@foto)


GO
CREATE PROCEDURE sp_EditarUsuario

@idUsuario int,
@nombre NVARCHAR(100),
@apellido NVARCHAR(100),
@dni INT,
@telefono BIGINT,
@correo NVARCHAR(100),
@direccion NVARCHAR(100),
@loginName NVARCHAR(50),
@password NVARCHAR(50),
@rol NVARCHAR(50),
@foto IMAGE

AS
	UPDATE USUARIO SET 
			Nombre = @nombre,
			Apellido = @apellido,
			Dni= @dni,
			Telefono = @telefono,
			Correo = @correo,
			Direccion = @direccion,
			LoginName = @loginName,
			Password = @password,
			Rol = @rol,
			Foto = @foto
	WHERE IdUsuario=@idUsuario

GO
CREATE PROCEDURE sp_EliminarUsuario
	@idUsuario INT
AS
	DELETE FROM USUARIO Where IdUsuario = @idUsuario

GO
CREATE PROCEDURE sp_ObtenerFoto
	@idUsuario INT
AS
	SELECT Foto FROM USUARIO WHERE IdUsuario = @idUsuario
Return 0
GO
CREATE PROCEDURE sp_UsuarioPorId
	@id int
AS
BEGIN
	 SELECT CONCAT(u.IdUsuario,'. ', u.Nombre,' ',u.Apellido) as Nombre FROM USUARIO u
	 WHERE u.IdUsuario = @id;
END
GO
CREATE PROCEDURE sp_ReporteUsuarios
AS
BEGIN
	 SELECT * FROM USUARIO order by Nombre
END



-------------------------------  MASCOTA  --------------------------------
CREATE TABLE Mascota(
	IdMascota int identity(1,1) primary key,
	Nombre nvarchar(100),
	Especie nvarchar(100),
	Sexo nvarchar(100),
	Edad nvarchar(10),
	Castrado bit,
	Descripcion nvarchar(200),
	Situacion nvarchar(100),
	Estado NVARCHAR (50),
	FechaIngreso date,
	Foto IMAGE NULL
);
-------------------------   PROCEDIMIENTOS
GO
CREATE PROCEDURE sp_ListarMascotas(
	@cTexto VARCHAR(225))
AS
BEGIN
	 SELECT * FROM MASCOTA m
	 WHERE m.Nombre  LIKE '%'+@cTexto+ '%';
END

go 

CREATE PROCEDURE sp_ListarMascotasPorEstado
	@estado1 VARCHAR(25),
	@estado2 VARCHAR(25)
AS
BEGIN
	 SELECT * FROM MASCOTA m
	 WHERE m.Estado LIKE '%'+@estado1+ '%' or m.Estado LIKE '%'+@estado2+ '%';
END

go 

CREATE PROCEDURE sp_BuscarMascotaPorNombreOEspecie(
	@nombre VARCHAR(50),
	@especie VARCHAR(50))
AS
BEGIN
SELECT * FROM MASCOTA m
WHERE m.Nombre  LIKE '%'+@nombre+ '%' and 
	  m.Especie Like '%'+@especie+ '%';
end

GO
CREATE PROCEDURE sp_AgregarMascota
	@nombre NVARCHAR(100),
	@especie NVARCHAR(100),
	@sexo NVARCHAR(100),
	@edad NVARCHAR(10),
	@castrado bit,
	@descripcion NVARCHAR(200),
	@situacion NVARCHAR(100),
	@estado NVARCHAR(50),
	@fechaIngreso date,
	@foto IMAGE

AS
	INSERT INTO MASCOTA VALUES (@nombre,@especie,@sexo,@edad,@castrado,@descripcion,@situacion,@estado,@fechaIngreso,@foto)


GO
CREATE PROCEDURE sp_EditarMascota

@idMascota int,
@nombre NVARCHAR(100),
@especie NVARCHAR(100),
@sexo NVARCHAR(100),
@edad NVARCHAR(10),
@castrado bit,
@descripcion NVARCHAR(200),
@situacion NVARCHAR(100),
@estado NVARCHAR(50),
@fechaIngreso date,
@foto IMAGE

AS
	UPDATE MASCOTA SET 
			Nombre = @nombre,
			Especie = @especie,
			Sexo= @sexo,
			Edad = @edad,
			Castrado= @castrado,
			Descripcion = @descripcion,
			Situacion = @situacion,
			Estado = @estado,
			FechaIngreso = @fechaIngreso, 
			Foto = @foto
	WHERE IdMascota=@idMascota

GO

CREATE PROCEDURE sp_EditarEstadoDeMascota

@idMascota int,
@estado NVARCHAR(50)
AS
	UPDATE MASCOTA SET Estado = @estado WHERE IdMascota=@idMascota
GO
CREATE PROCEDURE sp_EliminarMascota
	@idMascota INT
AS
	DELETE FROM MASCOTA Where IdMascota = @idMascota

GO
CREATE PROCEDURE sp_ObtenerFotoMascota
	@idMascota INT
AS
	SELECT Foto FROM MASCOTA WHERE IdMascota = @idMascota
Return 0
GO

CREATE PROCEDURE sp_ReporteMascotas
AS
BEGIN
	 SELECT * FROM MASCOTA order by Especie, Nombre, Sexo
END
GO
CREATE PROCEDURE sp_MascotaPorId
	@idMascota INT
AS
	SELECT * FROM MASCOTA Where IdMascota = @idMascota
GO

CREATE PROCEDURE sp_ApadrinadosPorId
	@id INT
AS
	SELECT m.IdMascota, m.Nombre,'Ver' as Detalle FROM MASCOTA m 
	inner join ApadrinadoDetalle ad on ad.IdMascota = m.IdMascota
	inner join Apadrinado a on ad.IdApadrinado = a.IdApadrinado
	Where a.IdApadrinado = @id
GO


------------------------------------------- VISITA  -----------------------------
CREATE TABLE Visita(
	IdVisita INT IDENTITY(1,1) PRIMARY KEY,
	IdUsuario int,
	Nombre nvarchar(50),
	Apellido nvarchar(50),
	DNI int,
	Motivo nvarchar(100),
	Fecha date,
	Hora Time,
	Descripcion nvarchar(100),
	foreign key (IdUsuario) references Usuario(IdUsuario)
);

-------------------------   PROCEDIMIENTOS
GO
CREATE PROCEDURE sp_ListarVisitas
AS
BEGIN
	 SELECT * FROM Visita
END

GO
CREATE PROCEDURE sp_VisitasPorAdoptante
	@dni INT
AS
	SELECT * FROM Visita WHERE DNI = @dni

GO
CREATE PROCEDURE sp_AgregarVisita
	@idUsuario int,
	@nombre NVARCHAR(50),
	@apellido NVARCHAR(50),
	@dni int,
	@motivo NVARCHAR(100),
	@descripcion NVARCHAR(100)
AS
	INSERT INTO Visita VALUES (@idUsuario,@nombre,@apellido,@dni,@motivo, GETDATE(), FORMAT(GETDATE(),'HH:mm'),@descripcion)

GO
CREATE PROCEDURE sp_EditarVisita
	@idVisita int,
	@idUsuario int,
	@nombre NVARCHAR(50),
	@apellido NVARCHAR(50),
	@dni int,
	@motivo NVARCHAR(100),
	@descripcion NVARCHAR(100)

AS
	UPDATE Visita SET 
	IdUsuario = @idUsuario,
	Nombre = @nombre,
	Apellido = @apellido,
	DNI = @dni,
	Motivo = @motivo,
	Descripcion = @descripcion
	WHERE IdVisita=@idVisita

GO
CREATE PROCEDURE sp_EliminarVisita
	@idVisita INT
AS
	DELETE FROM Visita Where IdVisita = @idVisita

GO


----------------------------------------   APADRINADO  ---------------------------------------------
CREATE TABLE Apadrinado(
	IdApadrinado INT IDENTITY(1,1) PRIMARY KEY,
	IdUsuario int,
	Fecha date,
	Monto float,
	Estado NVARCHAR(30),
	Comentario NVARCHAR(100)
	foreign key (IdUsuario) references Usuario(IdUsuario)
);

----------------------------------------  APADRINADODETALLE  ---------------------------------------
create table ApadrinadoDetalle(
	IdApadrinadoDetalle int IDENTITY(1,1) primary key,
	IdMascota int null,
	IdApadrinado int null,
	foreign key (IdMascota) references Mascota(IdMascota),
	foreign key (IdApadrinado) references Apadrinado(IdApadrinado)
);
go 

--tabla temporal: es una estructura personalizada
create type Detalle as Table(
	Id int,
	IdMascota int,
	primary key(Id)
);
--drop type Detalle;
----------------PROCEDIMIENTOS  -----------------
go
Create Procedure sp_GuardarApadrinado
	@idUsuario int,
	@monto decimal(10,2),
	@estado nvarchar(50),
	@comentario nvarchar(100),
	@lstDetalle Detalle readonly
As
BEGIN
	BEGIN TRANSACTION
	--variable
	DECLARE @idApadrinado int
	insert into Apadrinado(IdUsuario, Fecha, Monto, Estado, Comentario) 
	values (@idUsuario, GETDATE(), @monto , @estado, @comentario)
	SET @idApadrinado = @@IDENTITY
	insert into ApadrinadoDetalle(IdMascota, IdApadrinado)
	select IdMascota ,@idApadrinado from @lstDetalle
	COMMIT
END
go

--Prueba de guardado
declare @lstDetalle Detalle
insert into @lstDetalle (Id, IdMascota)
values (1,2)
insert into @lstDetalle (Id,IdMascota)
values (2,3)

exec dbo.sp_GuardarApadrinado 8,2600,'En espera', 'comentario', @lstDetalle
select * from Apadrinado;
select * from ApadrinadoDetalle;
go

CREATE PROCEDURE sp_EditarApadrinado
	@id INT,
	@estado nvarchar(50)
AS
	UPDATE Apadrinado SET 
		Estado = @estado	
	WHERE IdApadrinado = @id;

GO
CREATE PROCEDURE sp_ListarApadrinados
AS
BEGIN
	Select a.*,CONCAT(u.Nombre, ' ', u.Apellido) as Adoptante, u.Dni, u.Correo, COUNT(ad.IdMascota) as Mascotas,'Ver' as Detalle
	from Apadrinado a
	inner join Usuario u on a.IdUsuario = u.IdUsuario
	inner join ApadrinadoDetalle ad on ad.IdApadrinado=a.IdApadrinado
	group by a.IdApadrinado, a.IdUsuario, a.Fecha,a.Monto,a.Estado, a.Comentario, u.Nombre, u.Apellido, u.Dni, u.Correo
END
GO
CREATE PROCEDURE sp_ListarApadrinadoPorId
 @id int
AS
BEGIN
	Select * from Apadrinado WHERE IdApadrinado = @id
END
GO

CREATE PROCEDURE sp_ListarApadrinadosPorIdUsuario
 @id int
AS
BEGIN
	Select a.*,CONCAT(u.Nombre, ' ', u.Apellido) as Adoptante, COUNT(ad.IdMascota) as Mascotas,'Ver' as Detalle
	from Apadrinado a
inner join Usuario u on a.IdUsuario = u.IdUsuario
inner join ApadrinadoDetalle ad on ad.IdApadrinado=a.IdApadrinado
where a.IdUsuario = @id
group by a.IdApadrinado, a.IdUsuario, a.Fecha,a.Monto,a.Estado, a.Comentario, u.Nombre, u.Apellido
END




----------------------------------------  ADOPCION  ---------------------------------------
CREATE TABLE Adopcion(
	IdAdopcion INT IDENTITY(1,1) PRIMARY KEY,
	IdUsuario int,
	IdMascota int,
	Fecha date,
	Estado NVARCHAR(50),
	Comentario NVARCHAR(100)
	foreign key (IdUsuario) references Usuario(IdUsuario),
	foreign key (IdMascota) references Mascota(IdMascota)
);
-------------------------   PROCEDIMIENTOS
GO
CREATE PROCEDURE sp_ListarAdopciones(
	@cTexto VARCHAR(225))
AS
BEGIN
	 SELECT a.*, CONCAT(u.Nombre, ' ', u.Apellido) as Adoptante,CONCAT(m.Nombre,'(',m.Especie,')') as Mascota FROM Adopcion a
	 inner join Usuario u on a.IdUsuario = u.IdUsuario
	 inner join Mascota m on a.IdMascota = m.IdMascota
	 WHERE a.Estado  LIKE '%'+@cTexto+ '%';
END

GO
CREATE PROCEDURE sp_ListarAdopcionesVoluntarios
AS
BEGIN
	SELECT a.*, 
	m.Nombre as mascota, m.Especie, m.sexo,m.edad,
	CONCAT(u.Nombre, ' ', u.Apellido) as Adoptante, u.Dni,u.Telefono, u.Correo, u.Direccion,'Ver' as Detalle FROM Adopcion a
	 inner join Usuario u on a.IdUsuario = u.IdUsuario
	 inner join Mascota m on a.IdMascota = m.IdMascota
END

GO
CREATE PROCEDURE sp_ListarAdopcionPorIdUsuario
 @id int
AS
BEGIN
	SELECT a.*, 
	m.Nombre as mascota, m.Especie, m.sexo,m.edad,
	CONCAT(u.Nombre, ' ', u.Apellido) as Adoptante, u.Dni,u.Telefono, u.Correo, u.Direccion,'Ver' as Detalle FROM Adopcion a
	 inner join Usuario u on a.IdUsuario = u.IdUsuario
	 inner join Mascota m on a.IdMascota = m.IdMascota
	 WHERE u.IdUsuario = @id;
END


GO
CREATE PROCEDURE sp_AgregarAdopcion
	@idUsuario int,
	@idMascota int,
	@estado NVARCHAR(50),
	@comentario NVARCHAR(100)
AS
	INSERT INTO Adopcion VALUES (@idUsuario,@idMascota,GETDATE(),@estado,@comentario)


GO
CREATE PROCEDURE sp_EditarAdopcion
	@idAdopcion int,
	@idUsuario int,
	@idMascota int,
	@estado NVARCHAR(50),
	@comentario NVARCHAR(100)
AS
	UPDATE Adopcion SET 
			IdUsuario = @idUsuario,
			IdMascota = @idMascota,
			Estado = @estado,
			Comentario = @comentario
	WHERE IdAdopcion=@idAdopcion

GO
CREATE PROCEDURE sp_EliminarAdopcion
	@idAdopcion INT
AS
	DELETE FROM Adopcion Where IdAdopcion = @idAdopcion

GO

CREATE PROCEDURE sp_ReporteAdopcion
@id int
AS
BEGIN
	SELECT a.*, m.*, CONCAT(u.Nombre, ' ', u.Apellido) as Adoptante, u.Dni,u.Telefono, u.Correo, u.Direccion 
	FROM Adopcion a
	 inner join Usuario u on a.IdUsuario = u.IdUsuario
	 inner join Mascota m on a.IdMascota = m.IdMascota
	 WHERE a.IdAdopcion = @id
END