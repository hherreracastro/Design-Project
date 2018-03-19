CREATE ROLE "usrNLine" LOGIN
  ENCRYPTED PASSWORD 'md52a67115b4c7f15f629bbba08ecde1eb7'
  SUPERUSER INHERIT NOCREATEDB NOCREATEROLE NOREPLICATION;

ALTER ROLE "usrNLine"
  SET search_path = public;
  
  
CREATE DATABASE "dbNLine"
  WITH OWNER = "usrNLine"
       ENCODING = 'UTF8'
       TABLESPACE = pg_default
       LC_COLLATE = 'Spanish_Costa Rica.1252'
       LC_CTYPE = 'Spanish_Costa Rica.1252'
       CONNECTION LIMIT = -1;
	   
	   
CREATE TABLE public."user"
(
  email character varying(500) NOT NULL,
  name character varying(2000) NOT NULL,
  CONSTRAINT pk_user PRIMARY KEY (email)
)
WITH (
  OIDS=FALSE
);
ALTER TABLE public."user"
  OWNER TO "usrNLine";
  
  ALTER TABLE public."user"
  ADD COLUMN "photoUrl" text;