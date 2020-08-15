alter table device
	add version bigint default 0 not null;

alter table camera
	add version bigint default 0 not null;
