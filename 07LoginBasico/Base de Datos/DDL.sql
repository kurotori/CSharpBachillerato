drop schema if exists loginBasico;
create schema loginBasico;
use loginBasico;

drop user if exists "loginBasico"@"%";
create user "loginBasico"@"%" identified by "59LaU)0AOek-ydyE[";

grant 
insert,select,update,delete,
create routine,alter routine,execute 
on loginBasico.* 
to "loginBasico"@"%";

create table usuario(
	CI int(8) unsigned not null unique primary key,
	nombre varchar(12) not null,
	sal varchar(100) not null,
	hash varchar(88) not null,
	fecha_registro datetime default current_timestamp
);

create table sesion(
	ID int(10) not null unique auto_increment primary key,
	estado enum('abierta','cerrada') default 'abierta'
);

create table inicia(
	usuario_CI int(8) unsigned not null,
	sesion_ID int(10) not null unique primary key,
	fecha_abierta timestamp not null default current_timestamp,
	fecha_cerrada timestamp default current_timestamp
);

alter table inicia
add constraint fk_usuario_inicia
foreign key (usuario_CI)
references usuario(CI)
on update cascade
on delete cascade;

alter table inicia
add constraint fk_inicia_sesion
foreign key (sesion_ID)
references sesion(ID)
on update cascade
on delete cascade;


/*  PROCEDIMIENTOS */

/* Inicio de Sesión */
DELIMITER $$
CREATE DEFINER = 'loginBasico'@'%'
PROCEDURE iniciar_sesion( 
	IN usuario_ci int(8) unsigned,
	IN hash varchar(88)
)
BEGIN
	DECLARE usr_ci int(8) unsigned;
	DECLARE hsh varchar(88);
	DECLARE existe tinyint(1);
	DECLARE ssn_id INT(10);
	
	SET usr_ci = usuario_ci;
	SET hsh = hash;
	
	SELECT count(*) INTO existe 
	FROM usuario 
	WHERE usuario.CI = usr_ci
	AND usuario.hash = hsh;
	
	IF existe = 1 THEN
		UPDATE sesion INNER JOIN inicia
		SET sesion.estado = 'cerrada'
		WHERE 
		sesion.ID = inicia.sesion_ID AND
		inicia.usuario_CI = usr_ci AND
		sesion.estado = 'abierta';
		
		INSERT INTO sesion() VALUES();
		SET ssn_id = LAST_INSERT_ID();
		
		INSERT INTO inicia(usuario_CI,sesion_ID)
		VALUES(usr_ci,ssn_id);
	ELSE
		SET ssn_id = -1;	
	END IF;
	
	SELECT ssn_id;

END$$
DELIMITER ;