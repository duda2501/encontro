-- Database generated with pgModeler (PostgreSQL Database Modeler).
-- pgModeler  version: 0.9.0-alpha
-- PostgreSQL version: 9.5
-- Project Site: pgmodeler.com.br
-- Model Author: ---


-- Database creation must be done outside an multicommand file.
-- These commands were put in this file only for convenience.
-- -- object: encontrocampistas | type: DATABASE --
-- -- DROP DATABASE IF EXISTS encontrocampistas;
-- CREATE DATABASE encontrocampistas
-- 	ENCODING = 'UTF8'
-- 	LC_COLLATE = 'Portuguese_Brazil.UTF8'
-- 	LC_CTYPE = 'Portuguese_Brazil.UTF8'
-- 	TABLESPACE = pg_default
-- 	OWNER = postgres
-- ;
-- -- ddl-end --
-- 

-- object: public."Campistas_CampistaId_seq" | type: SEQUENCE --
-- DROP SEQUENCE IF EXISTS public."Campistas_CampistaId_seq" CASCADE;
CREATE SEQUENCE public."Campistas_CampistaId_seq"
	INCREMENT BY 1
	MINVALUE 1
	MAXVALUE 9223372036854775807
	START WITH 1
	CACHE 1
	NO CYCLE
	OWNED BY NONE;
-- ddl-end --
ALTER SEQUENCE public."Campistas_CampistaId_seq" OWNER TO encontrocampis;
-- ddl-end --

-- object: public."Campistas" | type: TABLE --
-- DROP TABLE IF EXISTS public."Campistas" CASCADE;
CREATE TABLE public."Campistas"(
	"CampistaId" integer NOT NULL DEFAULT nextval('public."Campistas_CampistaId_seq"'::regclass),
	"Nome" character varying NOT NULL,
	"Endereco" character varying,
	"Numero" character varying,
	"Bairro" character varying,
	"Complemento" character varying,
	"DataNascimento" date,
	"Telefone" character varying,
	"Celular" character varying,
	"RG" character varying,
	"CPF" character varying,
	"Peso" numeric(10,2),
	"Altura" numeric(10,2),
	"TipoCamiseta" character varying,
	"TamanhoCamiseta" character varying,
	"NomeMae" character varying,
	"FoneMae" character varying,
	"NomePai" character varying,
	"FonePai" character varying,
	"Responsavel" character varying,
	"FoneResponsavel" character varying,
	"Paroquia" character varying,
	"Batizado" boolean,
	"PrimeiraComunhao" boolean,
	"Crismado" boolean,
	"Casado" boolean,
	"Email" character varying,
	"Medicamentos" character varying,
	"CEP" character varying,
	"Cidade" character varying,
	"Sexo" character varying,
	"ParoquiaAcampamento" character varying,
	"TipoAcampamento" character varying,
	"AnoAcampamento" integer,
	"Pastoral" character varying,
	CONSTRAINT "PKCampista" PRIMARY KEY ("CampistaId")

);
-- ddl-end --
ALTER TABLE public."Campistas" OWNER TO encontrocampis;
-- ddl-end --

-- object: public."Eventos_EventoId_seq" | type: SEQUENCE --
-- DROP SEQUENCE IF EXISTS public."Eventos_EventoId_seq" CASCADE;
CREATE SEQUENCE public."Eventos_EventoId_seq"
	INCREMENT BY 1
	MINVALUE 1
	MAXVALUE 9223372036854775807
	START WITH 1
	CACHE 1
	NO CYCLE
	OWNED BY NONE;
-- ddl-end --
ALTER SEQUENCE public."Eventos_EventoId_seq" OWNER TO encontrocampis;
-- ddl-end --

-- object: public."Eventos" | type: TABLE --
-- DROP TABLE IF EXISTS public."Eventos" CASCADE;
CREATE TABLE public."Eventos"(
	"EventoId" integer NOT NULL DEFAULT nextval('public."Eventos_EventoId_seq"'::regclass),
	"Descricao" character varying NOT NULL,
	"DataHoraRealizacao" timestamp,
	"Local" character varying,
	"Duracao" integer,
	"TipoEvento" integer,
	CONSTRAINT "PKEvento" PRIMARY KEY ("EventoId")

);
-- ddl-end --
ALTER TABLE public."Eventos" OWNER TO encontrocampis;
-- ddl-end --

-- object: public."TipoEvento_TipoEventoId_seq" | type: SEQUENCE --
-- DROP SEQUENCE IF EXISTS public."TipoEvento_TipoEventoId_seq" CASCADE;
CREATE SEQUENCE public."TipoEvento_TipoEventoId_seq"
	INCREMENT BY 1
	MINVALUE 1
	MAXVALUE 9223372036854775807
	START WITH 1
	CACHE 1
	NO CYCLE
	OWNED BY NONE;
-- ddl-end --
ALTER SEQUENCE public."TipoEvento_TipoEventoId_seq" OWNER TO encontrocampis;
-- ddl-end --

-- object: public."TiposEventos" | type: TABLE --
-- DROP TABLE IF EXISTS public."TiposEventos" CASCADE;
CREATE TABLE public."TiposEventos"(
	"TipoEventoId" integer NOT NULL DEFAULT nextval('public."TipoEvento_TipoEventoId_seq"'::regclass),
	"DescricaoTipoEvento" character varying NOT NULL,
	"PermiteInscricao" boolean,
	CONSTRAINT "PKTiposEventos" PRIMARY KEY ("TipoEventoId")

);
-- ddl-end --
ALTER TABLE public."TiposEventos" OWNER TO encontrocampis;
-- ddl-end --

-- object: public."Usuarios" | type: TABLE --
-- DROP TABLE IF EXISTS public."Usuarios" CASCADE;
CREATE TABLE public."Usuarios"(
	login character varying NOT NULL,
	"Senha" character varying NOT NULL,
	"Nome" character varying NOT NULL,
	"CampistaId" integer,
	CONSTRAINT "PKUsuario" PRIMARY KEY (login)

);
-- ddl-end --
ALTER TABLE public."Usuarios" OWNER TO encontrocampis;
-- ddl-end --

-- object: public."GruposUsuarios_GrupoUsuarioId_Seq" | type: SEQUENCE --
-- DROP SEQUENCE IF EXISTS public."GruposUsuarios_GrupoUsuarioId_Seq" CASCADE;
CREATE SEQUENCE public."GruposUsuarios_GrupoUsuarioId_Seq"
	INCREMENT BY 1
	MINVALUE 1
	MAXVALUE 2147483647
	START WITH 1
	CACHE 1
	NO CYCLE
	OWNED BY NONE;
-- ddl-end --
ALTER SEQUENCE public."GruposUsuarios_GrupoUsuarioId_Seq" OWNER TO encontrocampis;
-- ddl-end --

-- object: public."GruposUsuarios" | type: TABLE --
-- DROP TABLE IF EXISTS public."GruposUsuarios" CASCADE;
CREATE TABLE public."GruposUsuarios"(
	"GrupoUsuarioId" integer NOT NULL DEFAULT nextval('public."GruposUsuarios_GrupoUsuarioId_Seq"'::regclass),
	"Nome" character varying NOT NULL,
	"EditaCampista" bool,
	"AcessaParoquia" bool,
	"AcessaTodasParoquias" bool,
	CONSTRAINT "PKGruposUsuarios" PRIMARY KEY ("GrupoUsuarioId")

);
-- ddl-end --
ALTER TABLE public."GruposUsuarios" OWNER TO encontrocampis;
-- ddl-end --

-- object: public."UsuariosGruposUsuarios" | type: TABLE --
-- DROP TABLE IF EXISTS public."UsuariosGruposUsuarios" CASCADE;
CREATE TABLE public."UsuariosGruposUsuarios"(
	"GrupoUsuarioId" integer NOT NULL,
	login character varying NOT NULL,
	CONSTRAINT "PKUsuariosGruposUsuarios" PRIMARY KEY (login,"GrupoUsuarioId")

);
-- ddl-end --
ALTER TABLE public."UsuariosGruposUsuarios" OWNER TO encontrocampis;
-- ddl-end --

-- object: public."Inscricoes" | type: TABLE --
-- DROP TABLE IF EXISTS public."Inscricoes" CASCADE;
CREATE TABLE public."Inscricoes"(
	"CampistaId" integer NOT NULL,
	"EventoId" integer NOT NULL,
	CONSTRAINT "PKInscricoes" PRIMARY KEY ("CampistaId","EventoId")

);
-- ddl-end --
ALTER TABLE public."Inscricoes" OWNER TO encontrocampis;
-- ddl-end --

-- object: public."Cedentes_CedenteId_Seq" | type: SEQUENCE --
-- DROP SEQUENCE IF EXISTS public."Cedentes_CedenteId_Seq" CASCADE;
CREATE SEQUENCE public."Cedentes_CedenteId_Seq"
	INCREMENT BY 1
	MINVALUE 0
	MAXVALUE 999
	START WITH 1
	CACHE 1
	NO CYCLE
	OWNED BY NONE;
-- ddl-end --
ALTER SEQUENCE public."Cedentes_CedenteId_Seq" OWNER TO encontrocampis;
-- ddl-end --

-- object: public."Cedentes" | type: TABLE --
-- DROP TABLE IF EXISTS public."Cedentes" CASCADE;
CREATE TABLE public."Cedentes"(
	"CedenteId" integer NOT NULL DEFAULT nextval('public."Cedentes_CedenteId_Seq"'::regclass),
	"CPFCNPJ" character varying,
	"Codigo" character varying,
	"Nome" character varying,
	"Agencia" character varying,
	"Conta" character varying,
	"Instrucoes" character varying,
	"CodigoBanco" integer,
	"Carteira" integer,
	CONSTRAINT "PKCedentes" PRIMARY KEY ("CedenteId")

);
-- ddl-end --
ALTER TABLE public."Cedentes" OWNER TO encontrocampis;
-- ddl-end --

-- object: public."Boletos_BoletoId_Seq" | type: SEQUENCE --
-- DROP SEQUENCE IF EXISTS public."Boletos_BoletoId_Seq" CASCADE;
CREATE SEQUENCE public."Boletos_BoletoId_Seq"
	INCREMENT BY 1
	MINVALUE 0
	MAXVALUE 2147483647
	START WITH 1
	CACHE 1
	NO CYCLE
	OWNED BY NONE;
-- ddl-end --
ALTER SEQUENCE public."Boletos_BoletoId_Seq" OWNER TO encontrocampis;
-- ddl-end --

-- object: public."Boletos" | type: TABLE --
-- DROP TABLE IF EXISTS public."Boletos" CASCADE;
CREATE TABLE public."Boletos"(
	"BoletoId" integer NOT NULL DEFAULT nextval('public."Boletos_BoletoId_Seq"'::regclass),
	"Vencimento" date NOT NULL,
	"Valor" double precision NOT NULL,
	"ValorPago" double precision,
	"NossoNumero" character varying,
	"NumeroDocumento" character varying,
	"CedenteId" integer NOT NULL,
	"DataPagamento" date,
	CONSTRAINT "PKBoletos" PRIMARY KEY ("BoletoId")

);
-- ddl-end --
ALTER TABLE public."Boletos" OWNER TO encontrocampis;
-- ddl-end --

-- object: public."BoletosCampistas" | type: TABLE --
-- DROP TABLE IF EXISTS public."BoletosCampistas" CASCADE;
CREATE TABLE public."BoletosCampistas"(
	"CampistaId_Campistas" integer,
	"BoletoId_Boletos" integer,
	CONSTRAINT "BoletosCampistas_pk" PRIMARY KEY ("CampistaId_Campistas","BoletoId_Boletos")

);
-- ddl-end --

-- object: "Campistas_fk" | type: CONSTRAINT --
-- ALTER TABLE public."BoletosCampistas" DROP CONSTRAINT IF EXISTS "Campistas_fk" CASCADE;
ALTER TABLE public."BoletosCampistas" ADD CONSTRAINT "Campistas_fk" FOREIGN KEY ("CampistaId_Campistas")
REFERENCES public."Campistas" ("CampistaId") MATCH FULL
ON DELETE CASCADE ON UPDATE CASCADE;
-- ddl-end --

-- object: "Boletos_fk" | type: CONSTRAINT --
-- ALTER TABLE public."BoletosCampistas" DROP CONSTRAINT IF EXISTS "Boletos_fk" CASCADE;
ALTER TABLE public."BoletosCampistas" ADD CONSTRAINT "Boletos_fk" FOREIGN KEY ("BoletoId_Boletos")
REFERENCES public."Boletos" ("BoletoId") MATCH FULL
ON DELETE CASCADE ON UPDATE CASCADE;
-- ddl-end --

-- object: public."Paroquias_ParoquiaId_Seq" | type: SEQUENCE --
-- DROP SEQUENCE IF EXISTS public."Paroquias_ParoquiaId_Seq" CASCADE;
CREATE SEQUENCE public."Paroquias_ParoquiaId_Seq"
	INCREMENT BY 1
	MINVALUE 0
	MAXVALUE 2147483647
	START WITH 1
	CACHE 1
	NO CYCLE
	OWNED BY NONE;
-- ddl-end --
ALTER SEQUENCE public."Paroquias_ParoquiaId_Seq" OWNER TO encontrocampis;
-- ddl-end --

-- object: public."Paroquias" | type: TABLE --
-- DROP TABLE IF EXISTS public."Paroquias" CASCADE;
CREATE TABLE public."Paroquias"(
	"ParoquiaId" integer NOT NULL DEFAULT nextval('public."Paroquias_ParoquiaId_Seq"'::regclass),
	"Nome" character varying,
	"Cidade" character varying,
	"Estado" character varying,
	"Diocese" character varying,
	CONSTRAINT "PKParoquias" PRIMARY KEY ("ParoquiaId")

);
-- ddl-end --
ALTER TABLE public."Paroquias" OWNER TO encontrocampis;
-- ddl-end --

-- object: public."UsuariosAcessoParoquias" | type: TABLE --
-- DROP TABLE IF EXISTS public."UsuariosAcessoParoquias" CASCADE;
CREATE TABLE public."UsuariosAcessoParoquias"(
	"login_Usuarios" character varying,
	"ParoquiaId_Paroquias" integer,
	CONSTRAINT "UsuariosAcessoParoquias_pk" PRIMARY KEY ("login_Usuarios","ParoquiaId_Paroquias")

);
-- ddl-end --

-- object: "Usuarios_fk" | type: CONSTRAINT --
-- ALTER TABLE public."UsuariosAcessoParoquias" DROP CONSTRAINT IF EXISTS "Usuarios_fk" CASCADE;
ALTER TABLE public."UsuariosAcessoParoquias" ADD CONSTRAINT "Usuarios_fk" FOREIGN KEY ("login_Usuarios")
REFERENCES public."Usuarios" (login) MATCH FULL
ON DELETE CASCADE ON UPDATE CASCADE;
-- ddl-end --

-- object: "Paroquias_fk" | type: CONSTRAINT --
-- ALTER TABLE public."UsuariosAcessoParoquias" DROP CONSTRAINT IF EXISTS "Paroquias_fk" CASCADE;
ALTER TABLE public."UsuariosAcessoParoquias" ADD CONSTRAINT "Paroquias_fk" FOREIGN KEY ("ParoquiaId_Paroquias")
REFERENCES public."Paroquias" ("ParoquiaId") MATCH FULL
ON DELETE CASCADE ON UPDATE CASCADE;
-- ddl-end --

-- object: "FKEventoxTipoEvento" | type: CONSTRAINT --
-- ALTER TABLE public."Eventos" DROP CONSTRAINT IF EXISTS "FKEventoxTipoEvento" CASCADE;
ALTER TABLE public."Eventos" ADD CONSTRAINT "FKEventoxTipoEvento" FOREIGN KEY ("TipoEvento")
REFERENCES public."TiposEventos" ("TipoEventoId") MATCH SIMPLE
ON DELETE NO ACTION ON UPDATE NO ACTION;
-- ddl-end --

-- object: "FKUsuariosxCampistas" | type: CONSTRAINT --
-- ALTER TABLE public."Usuarios" DROP CONSTRAINT IF EXISTS "FKUsuariosxCampistas" CASCADE;
ALTER TABLE public."Usuarios" ADD CONSTRAINT "FKUsuariosxCampistas" FOREIGN KEY ("CampistaId")
REFERENCES public."Campistas" ("CampistaId") MATCH FULL
ON DELETE NO ACTION ON UPDATE NO ACTION;
-- ddl-end --

-- object: "FKUsuariosGruposUsuariosxUsuarios" | type: CONSTRAINT --
-- ALTER TABLE public."UsuariosGruposUsuarios" DROP CONSTRAINT IF EXISTS "FKUsuariosGruposUsuariosxUsuarios" CASCADE;
ALTER TABLE public."UsuariosGruposUsuarios" ADD CONSTRAINT "FKUsuariosGruposUsuariosxUsuarios" FOREIGN KEY (login)
REFERENCES public."Usuarios" (login) MATCH FULL
ON DELETE NO ACTION ON UPDATE NO ACTION;
-- ddl-end --

-- object: "FKUsuariosGruposUsuariosxGruposUsuarios" | type: CONSTRAINT --
-- ALTER TABLE public."UsuariosGruposUsuarios" DROP CONSTRAINT IF EXISTS "FKUsuariosGruposUsuariosxGruposUsuarios" CASCADE;
ALTER TABLE public."UsuariosGruposUsuarios" ADD CONSTRAINT "FKUsuariosGruposUsuariosxGruposUsuarios" FOREIGN KEY ("GrupoUsuarioId")
REFERENCES public."GruposUsuarios" ("GrupoUsuarioId") MATCH FULL
ON DELETE NO ACTION ON UPDATE NO ACTION;
-- ddl-end --

-- object: "FKInscricoesxCampistas" | type: CONSTRAINT --
-- ALTER TABLE public."Inscricoes" DROP CONSTRAINT IF EXISTS "FKInscricoesxCampistas" CASCADE;
ALTER TABLE public."Inscricoes" ADD CONSTRAINT "FKInscricoesxCampistas" FOREIGN KEY ("CampistaId")
REFERENCES public."Campistas" ("CampistaId") MATCH FULL
ON DELETE NO ACTION ON UPDATE NO ACTION;
-- ddl-end --

-- object: "FKInscricoesxEventos" | type: CONSTRAINT --
-- ALTER TABLE public."Inscricoes" DROP CONSTRAINT IF EXISTS "FKInscricoesxEventos" CASCADE;
ALTER TABLE public."Inscricoes" ADD CONSTRAINT "FKInscricoesxEventos" FOREIGN KEY ("EventoId")
REFERENCES public."Eventos" ("EventoId") MATCH FULL
ON DELETE NO ACTION ON UPDATE NO ACTION;
-- ddl-end --

-- object: "FKBoletosxCedentes" | type: CONSTRAINT --
-- ALTER TABLE public."Boletos" DROP CONSTRAINT IF EXISTS "FKBoletosxCedentes" CASCADE;
ALTER TABLE public."Boletos" ADD CONSTRAINT "FKBoletosxCedentes" FOREIGN KEY ("CedenteId")
REFERENCES public."Cedentes" ("CedenteId") MATCH FULL
ON DELETE NO ACTION ON UPDATE NO ACTION;
-- ddl-end --


