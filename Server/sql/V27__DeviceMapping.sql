create table ltr_device
(
	sn text,
	num int,
	ch int,
	device int,
	field text,
	constraint ltr_device_pk
		unique (sn, num, ch)
);

create index ltr_device_device_index
	on ltr_device (device);
	
INSERT INTO public.ltr_device (sn, num, ch, device, field) VALUES ('2D551745', 1, 1, 7, 'sensor');
INSERT INTO public.ltr_device (sn, num, ch, device, field) VALUES ('2D551745', 1, 2, 13, 'sensor');
INSERT INTO public.ltr_device (sn, num, ch, device, field) VALUES ('2D551745', 1, 3, 6, 'sensor');
INSERT INTO public.ltr_device (sn, num, ch, device, field) VALUES ('2D551745', 1, 4, 15, 'sensor');
INSERT INTO public.ltr_device (sn, num, ch, device, field) VALUES ('2D551745', 1, 5, 8, 'sensor');
INSERT INTO public.ltr_device (sn, num, ch, device, field) VALUES ('2D551745', 1, 6, 9, 'sensor');
INSERT INTO public.ltr_device (sn, num, ch, device, field) VALUES ('2D551745', 1, 7, 48, 'sensor');
INSERT INTO public.ltr_device (sn, num, ch, device, field) VALUES ('2D551745', 1, 8, 49, 'sensor');
INSERT INTO public.ltr_device (sn, num, ch, device, field) VALUES ('2D551745', 1, 9, 50, 'sensor');
INSERT INTO public.ltr_device (sn, num, ch, device, field) VALUES ('2D551745', 1, 10, 51, 'sensor');
INSERT INTO public.ltr_device (sn, num, ch, device, field) VALUES ('2D551745', 1, 11, 52, 'sensor');
INSERT INTO public.ltr_device (sn, num, ch, device, field) VALUES ('2D551745', 1, 12, 53, 'sensor');
INSERT INTO public.ltr_device (sn, num, ch, device, field) VALUES ('2D551745', 1, 13, 54, 'sensor');
INSERT INTO public.ltr_device (sn, num, ch, device, field) VALUES ('2D551745', 1, 14, 55, 'sensor');
INSERT INTO public.ltr_device (sn, num, ch, device, field) VALUES ('2D551745', 1, 15, 56, 'sensor');
INSERT INTO public.ltr_device (sn, num, ch, device, field) VALUES ('2D551745', 1, 16, 16, 'sensor');
INSERT INTO public.ltr_device (sn, num, ch, device, field) VALUES ('2D551745', 2, 1, 36, 'sensor');
INSERT INTO public.ltr_device (sn, num, ch, device, field) VALUES ('2D551745', 2, 2, 37, 'sensor');
INSERT INTO public.ltr_device (sn, num, ch, device, field) VALUES ('2D551745', 2, 3, 38, 'sensor');
INSERT INTO public.ltr_device (sn, num, ch, device, field) VALUES ('2D551745', 2, 4, 57, 'sensor');
INSERT INTO public.ltr_device (sn, num, ch, device, field) VALUES ('2D551745', 2, 5, 57, 'remote');
INSERT INTO public.ltr_device (sn, num, ch, device, field) VALUES ('2D551745', 2, 6, 58, 'sensor');
INSERT INTO public.ltr_device (sn, num, ch, device, field) VALUES ('2D551745', 2, 7, 18, 'sensor');
INSERT INTO public.ltr_device (sn, num, ch, device, field) VALUES ('2D551745', 2, 8, 19, 'sensor');
INSERT INTO public.ltr_device (sn, num, ch, device, field) VALUES ('2D551745', 2, 9, 20, 'sensor');
INSERT INTO public.ltr_device (sn, num, ch, device, field) VALUES ('2D551745', 2, 10, 21, 'sensor');
INSERT INTO public.ltr_device (sn, num, ch, device, field) VALUES ('2D551745', 2, 11, 22, 'sensor');
INSERT INTO public.ltr_device (sn, num, ch, device, field) VALUES ('2D551745', 2, 12, 23, 'sensor');
INSERT INTO public.ltr_device (sn, num, ch, device, field) VALUES ('2D551745', 2, 13, 24, 'sensor');
INSERT INTO public.ltr_device (sn, num, ch, device, field) VALUES ('2D551745', 2, 14, 25, 'sensor');
INSERT INTO public.ltr_device (sn, num, ch, device, field) VALUES ('2D551745', 2, 15, 39, 'sensor');
INSERT INTO public.ltr_device (sn, num, ch, device, field) VALUES ('2D551745', 2, 16, 40, 'sensor');
INSERT INTO public.ltr_device (sn, num, ch, device, field) VALUES ('2D551743', 1, 1, 1, 'sensor');
INSERT INTO public.ltr_device (sn, num, ch, device, field) VALUES ('2D551743', 1, 2, 2, 'sensor');
INSERT INTO public.ltr_device (sn, num, ch, device, field) VALUES ('2D551743', 1, 3, 3, 'sensor');
INSERT INTO public.ltr_device (sn, num, ch, device, field) VALUES ('2D551743', 1, 4, 4, 'sensor');
INSERT INTO public.ltr_device (sn, num, ch, device, field) VALUES ('2D551743', 1, 5, 5, 'sensor');
INSERT INTO public.ltr_device (sn, num, ch, device, field) VALUES ('2D551743', 1, 6, 12, 'sensor');
INSERT INTO public.ltr_device (sn, num, ch, device, field) VALUES ('2D551743', 1, 7, 17, 'sensor');
INSERT INTO public.ltr_device (sn, num, ch, device, field) VALUES ('2D551743', 1, 8, 11, 'sensor');
INSERT INTO public.ltr_device (sn, num, ch, device, field) VALUES ('2D551743', 1, 9, 14, 'sensor');
INSERT INTO public.ltr_device (sn, num, ch, device, field) VALUES ('2D551743', 1, 10, 10, 'sensor');
INSERT INTO public.ltr_device (sn, num, ch, device, field) VALUES ('2D551743', 1, 11, null, null);
INSERT INTO public.ltr_device (sn, num, ch, device, field) VALUES ('2D551743', 1, 12, null, null);
INSERT INTO public.ltr_device (sn, num, ch, device, field) VALUES ('2D551743', 1, 13, null, null);
INSERT INTO public.ltr_device (sn, num, ch, device, field) VALUES ('2D551743', 1, 14, null, null);
INSERT INTO public.ltr_device (sn, num, ch, device, field) VALUES ('2D551743', 1, 15, null, null);
INSERT INTO public.ltr_device (sn, num, ch, device, field) VALUES ('2D551743', 1, 16, null, null);
INSERT INTO public.ltr_device (sn, num, ch, device, field) VALUES ('2D551743', 2, 1, -1, 'siren');
INSERT INTO public.ltr_device (sn, num, ch, device, field) VALUES ('2D551743', 2, 2, -2, 'siren');
INSERT INTO public.ltr_device (sn, num, ch, device, field) VALUES ('2D551743', 2, 3, 18, 'power');
INSERT INTO public.ltr_device (sn, num, ch, device, field) VALUES ('2D551743', 2, 4, 19, 'power');
INSERT INTO public.ltr_device (sn, num, ch, device, field) VALUES ('2D551743', 2, 5, 20, 'power');
INSERT INTO public.ltr_device (sn, num, ch, device, field) VALUES ('2D551743', 2, 6, 21, 'power');
INSERT INTO public.ltr_device (sn, num, ch, device, field) VALUES ('2D551743', 2, 7, 22, 'power');
INSERT INTO public.ltr_device (sn, num, ch, device, field) VALUES ('2D551743', 2, 8, 23, 'power');
INSERT INTO public.ltr_device (sn, num, ch, device, field) VALUES ('2D551743', 2, 9, 24, 'power');
INSERT INTO public.ltr_device (sn, num, ch, device, field) VALUES ('2D551743', 2, 10, 25, 'power');
INSERT INTO public.ltr_device (sn, num, ch, device, field) VALUES ('2D551743', 2, 11, null, null);
INSERT INTO public.ltr_device (sn, num, ch, device, field) VALUES ('2D551743', 2, 12, null, null);
INSERT INTO public.ltr_device (sn, num, ch, device, field) VALUES ('2D551743', 2, 13, null, null);
INSERT INTO public.ltr_device (sn, num, ch, device, field) VALUES ('2D551743', 2, 14, null, null);
INSERT INTO public.ltr_device (sn, num, ch, device, field) VALUES ('2D551743', 2, 15, null, null);
INSERT INTO public.ltr_device (sn, num, ch, device, field) VALUES ('2D551743', 2, 16, null, null);
INSERT INTO public.ltr_device (sn, num, ch, device, field) VALUES ('2D551744', 1, 1, 59, 'sensor');
INSERT INTO public.ltr_device (sn, num, ch, device, field) VALUES ('2D551744', 1, 2, 60, 'sensor');
INSERT INTO public.ltr_device (sn, num, ch, device, field) VALUES ('2D551744', 1, 3, 41, 'sensor');
INSERT INTO public.ltr_device (sn, num, ch, device, field) VALUES ('2D551744', 1, 4, 58, 'remote');
INSERT INTO public.ltr_device (sn, num, ch, device, field) VALUES ('2D551744', 1, 5, 42, 'sensor');
INSERT INTO public.ltr_device (sn, num, ch, device, field) VALUES ('2D551744', 1, 6, 66, 'sensorDW');
INSERT INTO public.ltr_device (sn, num, ch, device, field) VALUES ('2D551744', 1, 7, 67, 'sensorDW');
INSERT INTO public.ltr_device (sn, num, ch, device, field) VALUES ('2D551744', 1, 8, 43, 'sensor');
INSERT INTO public.ltr_device (sn, num, ch, device, field) VALUES ('2D551744', 1, 9, 66, 'sensorUP');
INSERT INTO public.ltr_device (sn, num, ch, device, field) VALUES ('2D551744', 1, 10, 67, 'sensorUP');
INSERT INTO public.ltr_device (sn, num, ch, device, field) VALUES ('2D551744', 1, 11, 26, 'sensor');
INSERT INTO public.ltr_device (sn, num, ch, device, field) VALUES ('2D551744', 1, 12, 27, 'sensor');
INSERT INTO public.ltr_device (sn, num, ch, device, field) VALUES ('2D551744', 1, 13, 44, 'sensor');
INSERT INTO public.ltr_device (sn, num, ch, device, field) VALUES ('2D551744', 1, 14, 45, 'sensor');
INSERT INTO public.ltr_device (sn, num, ch, device, field) VALUES ('2D551744', 1, 15, null, null);
INSERT INTO public.ltr_device (sn, num, ch, device, field) VALUES ('2D551744', 1, 16, null, null);
INSERT INTO public.ltr_device (sn, num, ch, device, field) VALUES ('2D551744', 2, 1, -3, 'siren');
INSERT INTO public.ltr_device (sn, num, ch, device, field) VALUES ('2D551744', 2, 2, 66, 'motorDW');
INSERT INTO public.ltr_device (sn, num, ch, device, field) VALUES ('2D551744', 2, 3, 67, 'motorDW');
INSERT INTO public.ltr_device (sn, num, ch, device, field) VALUES ('2D551744', 2, 4, -4, 'siren');
INSERT INTO public.ltr_device (sn, num, ch, device, field) VALUES ('2D551744', 2, 5, null, null);
INSERT INTO public.ltr_device (sn, num, ch, device, field) VALUES ('2D551744', 2, 6, -5, 'siren');
INSERT INTO public.ltr_device (sn, num, ch, device, field) VALUES ('2D551744', 2, 7, null, null);
INSERT INTO public.ltr_device (sn, num, ch, device, field) VALUES ('2D551744', 2, 8, 68, 'motorDW');
INSERT INTO public.ltr_device (sn, num, ch, device, field) VALUES ('2D551744', 2, 9, 65, 'motorDW');
INSERT INTO public.ltr_device (sn, num, ch, device, field) VALUES ('2D551744', 2, 10, null, null);
INSERT INTO public.ltr_device (sn, num, ch, device, field) VALUES ('2D551744', 2, 11, 26, 'power');
INSERT INTO public.ltr_device (sn, num, ch, device, field) VALUES ('2D551744', 2, 12, 27, 'power');
INSERT INTO public.ltr_device (sn, num, ch, device, field) VALUES ('2D551744', 2, 13, 66, 'motorUP');
INSERT INTO public.ltr_device (sn, num, ch, device, field) VALUES ('2D551744', 2, 14, 67, 'motorUP');
INSERT INTO public.ltr_device (sn, num, ch, device, field) VALUES ('2D551744', 2, 15, 68, 'motorUP');
INSERT INTO public.ltr_device (sn, num, ch, device, field) VALUES ('2D551744', 2, 16, 65, 'motorUP');
INSERT INTO public.ltr_device (sn, num, ch, device, field) VALUES ('2D551737', 1, 1, 33, 'sensorX');
INSERT INTO public.ltr_device (sn, num, ch, device, field) VALUES ('2D551737', 1, 2, 34, 'sensorX');
INSERT INTO public.ltr_device (sn, num, ch, device, field) VALUES ('2D551737', 1, 3, 35, 'sensorX');
INSERT INTO public.ltr_device (sn, num, ch, device, field) VALUES ('2D551737', 1, 4, 33, 'sensorY');
INSERT INTO public.ltr_device (sn, num, ch, device, field) VALUES ('2D551737', 1, 5, 34, 'sensorY');
INSERT INTO public.ltr_device (sn, num, ch, device, field) VALUES ('2D551737', 1, 6, 35, 'sensorY');
INSERT INTO public.ltr_device (sn, num, ch, device, field) VALUES ('2D551737', 1, 7, null, null);
INSERT INTO public.ltr_device (sn, num, ch, device, field) VALUES ('2D551737', 1, 8, null, null);
INSERT INTO public.ltr_device (sn, num, ch, device, field) VALUES ('2D551737', 1, 9, null, null);
INSERT INTO public.ltr_device (sn, num, ch, device, field) VALUES ('2D551737', 1, 10, null, null);
INSERT INTO public.ltr_device (sn, num, ch, device, field) VALUES ('2D551737', 1, 11, null, null);
INSERT INTO public.ltr_device (sn, num, ch, device, field) VALUES ('2D551737', 1, 12, null, null);
INSERT INTO public.ltr_device (sn, num, ch, device, field) VALUES ('2D551737', 1, 13, null, null);
INSERT INTO public.ltr_device (sn, num, ch, device, field) VALUES ('2D551737', 1, 14, null, null);
INSERT INTO public.ltr_device (sn, num, ch, device, field) VALUES ('2D551737', 1, 15, null, null);
INSERT INTO public.ltr_device (sn, num, ch, device, field) VALUES ('2D551737', 1, 16, null, null);
INSERT INTO public.ltr_device (sn, num, ch, device, field) VALUES ('2D551737', 2, 1, 68, 'sensorDW');
INSERT INTO public.ltr_device (sn, num, ch, device, field) VALUES ('2D551737', 2, 2, 65, 'sensorDW');
INSERT INTO public.ltr_device (sn, num, ch, device, field) VALUES ('2D551737', 2, 3, 59, 'remote');
INSERT INTO public.ltr_device (sn, num, ch, device, field) VALUES ('2D551737', 2, 4, 60, 'remote');
INSERT INTO public.ltr_device (sn, num, ch, device, field) VALUES ('2D551737', 2, 5, 46, 'sensor');
INSERT INTO public.ltr_device (sn, num, ch, device, field) VALUES ('2D551737', 2, 6, 47, 'sensor');
INSERT INTO public.ltr_device (sn, num, ch, device, field) VALUES ('2D551737', 2, 7, null, '?');
INSERT INTO public.ltr_device (sn, num, ch, device, field) VALUES ('2D551737', 2, 10, 57, 'encoder');
INSERT INTO public.ltr_device (sn, num, ch, device, field) VALUES ('2D551737', 2, 11, 58, 'encoder');
INSERT INTO public.ltr_device (sn, num, ch, device, field) VALUES ('2D551737', 2, 12, 59, 'encoder');
INSERT INTO public.ltr_device (sn, num, ch, device, field) VALUES ('2D551737', 2, 13, 68, 'sensorUP');
INSERT INTO public.ltr_device (sn, num, ch, device, field) VALUES ('2D551737', 2, 14, 65, 'sensorUP');
INSERT INTO public.ltr_device (sn, num, ch, device, field) VALUES ('2D551737', 2, 15, null, null);
INSERT INTO public.ltr_device (sn, num, ch, device, field) VALUES ('2D551737', 2, 8, null, '?');
INSERT INTO public.ltr_device (sn, num, ch, device, field) VALUES ('2D551737', 2, 16, null, null);
INSERT INTO public.ltr_device (sn, num, ch, device, field) VALUES ('2D551737', 2, 9, null, null);

alter table device
	add siren int default -1;

create index device_siren_index
	on device (siren);