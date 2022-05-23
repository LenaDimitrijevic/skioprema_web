create database skioprema

use skioprema

create table musterije(
id int identity(1,1) primary key,
ime nvarchar(20),
prezime nvarchar(30),
adresa nvarchar(30),
jmbg varchar(15),
email varchar(30),
lozinka varchar(30)
)

create table brend(
id int identity(1,1) primary key,
naziv nvarchar(20),
kolicina int
)

create table skije(
id int identity(1,1) primary key,
naziv nvarchar(20),
tip nvarchar(20),
duzina int,
kolicina int,
brend_id int foreign key references brend(id)
)

create table stapovi(
id int identity(1,1) primary key,
naziv nvarchar(20),
tip nvarchar(20),
duzina int,
kolicina int,
brend_id int foreign key references brend(id)
)

create table pancerice(
id int identity(1,1) primary key,
naziv nvarchar(20),
tip nvarchar(20),
broj int,
kolicina int,
brend_id int foreign key references brend(id)
)

create table kacige(
id int identity(1,1) primary key,
naziv nvarchar(20),
tip nvarchar(20),
kolicina int,
brend_id int foreign key references brend(id)
)

create table iznajmljivanje(
id int identity(1,1) primary key,
musterija_id int foreign key references musterije(id),
skije_id int foreign key references skije(id),
stapovi_id int foreign key references stapovi(id),
pancerice_id int foreign key references pancerice(id),
kaciga_id int foreign key references kacige(id),
datum_iznajmljivanja date
)


go
create proc Brendovi
as
begin try
	select * from brend
end try
begin catch
	return @@error
end catch
go

go
create proc login_musterija
@email varchar(50),
@lozinka varchar(20)
as
begin try
if exists (select top 1 email,lozinka from musterije where email = @email and lozinka= @lozinka)
	begin
		return 1
	end
	return 0
end try
begin catch
	return @@error
end catch
go

go
create proc insert_musterija
@email varchar(50),
@lozinka varchar(20)
as
begin try
if exists (select top 1 email,lozinka from musterije where email = @email and lozinka= @lozinka)
	return 1
	else
	insert into musterije (email,lozinka) 
	values (@email,@lozinka)
		return 0;
end try
begin catch
	return @@error
end catch
go

go
create proc iznajmljeno
@datum date
as
begin try
select musterije.ime,skije.naziv,stapovi.naziv,pancerice.naziv,kacige.naziv from iznajmljivanje join musterije on musterije.id = iznajmljivanje.musterija_id join skije on skije.id = iznajmljivanje.skije_id
join stapovi on stapovi.id = iznajmljivanje.stapovi_id join pancerice on pancerice.id = iznajmljivanje.pancerice_id join kacige on kacige.id = iznajmljivanje.kaciga_id where datum_iznajmljivanja = @datum
end try
begin catch
	return @@error
end catch
go

go
create proc pretraga_skija
@trm varchar(50)
as
begin try
select * from skije where naziv like @trm
end try 
begin catch
	return @@error
end catch
go

go
create proc pretraga_stapova
@trm varchar(50)
as
begin try
select * from stapovi where naziv like @trm
end try 
begin catch
	return @@error
end catch
go

go
create proc pretraga_pancerica
@trm varchar(50)
as
begin try
select * from pancerice where naziv like @trm
end try 
begin catch
	return @@error
end catch
go

go
create proc pretraga_kaciga
@trm varchar(50)
as
begin try
select * from kacige where naziv like @trm
end try 
begin catch
	return @@error
end catch
go

go
create proc upis_iznajmljivanja
@musterija int,
@skije int,
@stapovi int,
@pancerice int,
@kaciga int,
@datum date
as
begin try 
if exists (select top 1 * from musterije where id=@musterija) and exists(select top 1 * from skije where id=@skije) and exists(select top 1 * from stapovi where id=@stapovi) and exists(select top 1 * from pancerice where id=@pancerice) and exists(select top 1 * from kacige where id=@kaciga)
		begin
			return 0
		end
	insert Into iznajmljivanje(musterija_id,skije_id,stapovi_id,pancerice_id,kaciga_id,datum_iznajmljivanja) Values (@musterija,@skije,@stapovi,@pancerice,@kaciga,@datum)
	return 1
end try
begin catch
	return @@error
end catch
go
