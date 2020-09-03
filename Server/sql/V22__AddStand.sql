create table stand
(
	id text not null,
	name text
);

create unique index stand_id_uindex
	on stand (id);

alter table stand
	add constraint stand_pk
		primary key (id);


INSERT INTO public.stand (id, name) VALUES ('bks', 'БКС');
INSERT INTO public.stand (id, name) VALUES ('kes', 'КЭС');
INSERT INTO public.stand (id, name) VALUES ('mks', 'МКС');
INSERT INTO public.stand (id, name) VALUES ('ory', 'ОРУ');
INSERT INTO public.stand (id, name) VALUES ('flor1', '1 этаж');
INSERT INTO public.stand (id, name) VALUES ('snim', 'СНИМ');

alter table camera
	add stand_id text;


alter table device
	add stand_id text;

update camera set stand_id = s.id from stand s where stand = s.name;
update device set stand_id = s.id from stand s, camera c where camera = c.id AND c.stand = s.name;
