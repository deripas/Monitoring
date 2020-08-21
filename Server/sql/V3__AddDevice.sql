create table device
(
	id serial not null,
	name text,
	enable bool default true,
	camera int
		constraint device_camera_id_fk
			references camera (id),
	type text
);

create unique index device_id_uindex
	on device (id);

alter table device
	add constraint device_pk
		primary key (id);


INSERT INTO public.device (id, name, enable, camera, type) VALUES (1, 'Давление ОРУ1', true, 16, 'pressure');
INSERT INTO public.device (id, name, enable, camera, type) VALUES (2, 'Давление ОРУ2', true, 16, 'pressure');
INSERT INTO public.device (id, name, enable, camera, type) VALUES (3, 'Давление ОРУ3', true, 16, 'pressure');
INSERT INTO public.device (id, name, enable, camera, type) VALUES (4, 'Давление ОРУ4', true, 16, 'pressure');
INSERT INTO public.device (id, name, enable, camera, type) VALUES (5, 'Давление ОРУ5', true, 16, 'pressure');
INSERT INTO public.device (id, name, enable, camera, type) VALUES (6, '(БКС)Давление ВВН', true, 2, 'pressure');
INSERT INTO public.device (id, name, enable, camera, type) VALUES (7, '(БКС) Давление МВН', true, 1, 'pressure');
INSERT INTO public.device (id, name, enable, camera, type) VALUES (8, '(КЭС) Давление ВВН', true, 5, 'pressure');
INSERT INTO public.device (id, name, enable, camera, type) VALUES (9, '(КЭС) Давление МВН', true, 11, 'pressure');
INSERT INTO public.device (id, name, enable, camera, type) VALUES (10, '(МКС)Давление ВВН №1', true, 15, 'pressure');
INSERT INTO public.device (id, name, enable, camera, type) VALUES (11, '(МКС) Давление ВВН №2', true, 13, 'pressure');
INSERT INTO public.device (id, name, enable, camera, type) VALUES (12, '(КЭС) Давление подачи в бак ГСТ', true, 10, 'pressure');
INSERT INTO public.device (id, name, enable, camera, type) VALUES (13, '(БКС) Давление подачи в бак ГСТ', true, 3, 'pressure');
INSERT INTO public.device (id, name, enable, camera, type) VALUES (14, '(МКС) Давление подачи в бак ГСТ', true, 15, 'pressure');
INSERT INTO public.device (id, name, enable, camera, type) VALUES (15, '(КЭС) Давление в магистрали питания ГСТ', true, 10, 'pressure');
INSERT INTO public.device (id, name, enable, camera, type) VALUES (16, '(БКС) Давление в магистрали питания ГСТ', true, 3, 'pressure');
INSERT INTO public.device (id, name, enable, camera, type) VALUES (17, '(МКС) Давление в магистрали питания ГСТ', true, 15, 'pressure');
INSERT INTO public.device (id, name, enable, camera, type) VALUES (18, '(БКС) Дым двигатель №1', true, 31, 'smoke');
INSERT INTO public.device (id, name, enable, camera, type) VALUES (19, '(БКС) Дым двигатель №2', true, 6, 'smoke');
INSERT INTO public.device (id, name, enable, camera, type) VALUES (20, '(БКС) Дым маслостанция', true, 31, 'smoke');
INSERT INTO public.device (id, name, enable, camera, type) VALUES (21, '(КЭС) Дым двигатель №1', true, 9, 'smoke');
INSERT INTO public.device (id, name, enable, camera, type) VALUES (22, '(КЭС) Дым двигатель №2', true, 8, 'smoke');
INSERT INTO public.device (id, name, enable, camera, type) VALUES (23, '(КЭС) Дым двигатель №3', true, 7, 'smoke');
INSERT INTO public.device (id, name, enable, camera, type) VALUES (24, '(КЭС) МВН', true, 11, null);
INSERT INTO public.device (id, name, enable, camera, type) VALUES (25, '(МКС) Дым двигатель', true, 12, 'smoke');
INSERT INTO public.device (id, name, enable, camera, type) VALUES (26, '(МКС) Дым маслостанция', true, 29, 'smoke');
INSERT INTO public.device (id, name, enable, camera, type) VALUES (27, '(ОРУ) Дым ОРУ', true, 16, 'smoke');
INSERT INTO public.device (id, name, enable, camera, type) VALUES (28, '(БКС) Гром - 12', true, 31, null);
INSERT INTO public.device (id, name, enable, camera, type) VALUES (29, '(МКС) Гром - 12', true, 29, null);
INSERT INTO public.device (id, name, enable, camera, type) VALUES (30, '(КЭС) Гром - 12', true, 28, null);
INSERT INTO public.device (id, name, enable, camera, type) VALUES (31, '(ОРУ) Гром - 12', true, 16, null);
INSERT INTO public.device (id, name, enable, camera, type) VALUES (32, '(СНИиМ) Гром - 12', true, 20, null);
INSERT INTO public.device (id, name, enable, camera, type) VALUES (33, '(БКС) Вибрация', true, 31, 'vibration');
INSERT INTO public.device (id, name, enable, camera, type) VALUES (34, '(КЭС) Вибрация', true, 28, 'vibration');
INSERT INTO public.device (id, name, enable, camera, type) VALUES (35, '(МКС) Вибрация', true, 29, 'vibration');
INSERT INTO public.device (id, name, enable, camera, type) VALUES (36, '(БКС) Протечка основная задвижка', true, 6, 'water');
INSERT INTO public.device (id, name, enable, camera, type) VALUES (37, '(БКС) Протечка подвал', true, 2, 'water');
INSERT INTO public.device (id, name, enable, camera, type) VALUES (38, '(БКС) Протечка стенд', true, 31, 'water');
INSERT INTO public.device (id, name, enable, camera, type) VALUES (39, '(КЭС) Протечка основная задвижка №2', true, 7, 'water');
INSERT INTO public.device (id, name, enable, camera, type) VALUES (40, '(КЭС) Протечка подвал', true, 9, 'water');
INSERT INTO public.device (id, name, enable, camera, type) VALUES (41, '(КЭС) Протечка стенд', true, 28, 'water');
INSERT INTO public.device (id, name, enable, camera, type) VALUES (42, '(МКС) Протечка ВВН1', true, 14, 'water');
INSERT INTO public.device (id, name, enable, camera, type) VALUES (43, '(МКС) Протечка подвал', true, 13, 'water');
INSERT INTO public.device (id, name, enable, camera, type) VALUES (44, '(МКС) Протечка стенд', true, 29, 'water');
INSERT INTO public.device (id, name, enable, camera, type) VALUES (45, '(ОРУ) Протечка насос СЗВО', true, 16, 'water');
INSERT INTO public.device (id, name, enable, camera, type) VALUES (46, '(ОРУ) Протечка перелив шахты ', true, 16, 'water');
INSERT INTO public.device (id, name, enable, camera, type) VALUES (47, '(СНИиМ) Протечка стенды', true, 20, 'water');
INSERT INTO public.device (id, name, enable, camera, type) VALUES (48, '(БКС)Температура ВВН', true, 2, 'temperature');
INSERT INTO public.device (id, name, enable, camera, type) VALUES (49, '(БКС)Температура Гидростатика', true, 3, 'temperature');
INSERT INTO public.device (id, name, enable, camera, type) VALUES (50, '(БКС)Температура МВН', true, 1, 'temperature');
INSERT INTO public.device (id, name, enable, camera, type) VALUES (51, '(КЭС)Температура ВВН', true, 5, 'temperature');
INSERT INTO public.device (id, name, enable, camera, type) VALUES (52, '(КЭС)Температура Гидростатика', true, 10, 'temperature');
INSERT INTO public.device (id, name, enable, camera, type) VALUES (53, '(КЭС)Температура МВН', true, 11, 'temperature');
INSERT INTO public.device (id, name, enable, camera, type) VALUES (54, '(МКС)Температура ВВН №1', true, 14, 'temperature');
INSERT INTO public.device (id, name, enable, camera, type) VALUES (55, '(МКС)Температура ВВН №2', true, 13, 'temperature');
INSERT INTO public.device (id, name, enable, camera, type) VALUES (56, '(МКС)Температура Гидростатика', true, 15, 'temperature');
INSERT INTO public.device (id, name, enable, camera, type) VALUES (57, 'Оптоствор ОРУ', true, 16, 'hurble');
INSERT INTO public.device (id, name, enable, camera, type) VALUES (58, 'Оптоствор БКС', true, 31, 'hurble');
INSERT INTO public.device (id, name, enable, camera, type) VALUES (59, 'Оптоствор КЭС1', true, 28, 'hurble');
INSERT INTO public.device (id, name, enable, camera, type) VALUES (60, 'Оптоствор КЭС2', true, 28, 'hurble');
INSERT INTO public.device (id, name, enable, camera, type) VALUES (61, 'Оптоствор МКС', true, 29, 'hurble');
INSERT INTO public.device (id, name, enable, camera, type) VALUES (62, 'Энкодер БКС', default, null, null);
INSERT INTO public.device (id, name, enable, camera, type) VALUES (63, 'Энкодер МКС', default, null, null);
INSERT INTO public.device (id, name, enable, camera, type) VALUES (64, 'Энкодер КЭС', default, null, 'rollet');
INSERT INTO public.device (id, name, enable, camera, type) VALUES (65, 'Роллеты МКС', default, null, 'rollet');
INSERT INTO public.device (id, name, enable, camera, type) VALUES (66, 'Роллеты БКС', default, null, 'rollet');
INSERT INTO public.device (id, name, enable, camera, type) VALUES (67, 'Роллеты КЭС1', default, null, 'rollet');
INSERT INTO public.device (id, name, enable, camera, type) VALUES (68, 'Роллеты КЭС2', default, null, 'rollet');

drop table sensor cascade;

