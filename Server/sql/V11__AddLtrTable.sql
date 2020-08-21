create table ltr
(
	id serial not null,
	sn text,
	num int,
	type text
);

create unique index ltr_id_uindex
	on ltr (id);

alter table ltr
	add constraint ltr_pk
		primary key (id);

