alter table ltr_device drop constraint ltr_device_pk;

alter table ltr_device
	add constraint ltr_device_pk
		unique (sn, num, ch, device);

		
INSERT INTO public.device (id, name, enable, camera, type, description, config, version, stand_id, siren) VALUES (70, '(БКС) Вибрация', true, 31, 'vibration2', '(БКС) ', '{"alarm": {"count": 3, "delay": 1000, "period": 2000, "timeout": 5000}}', 0, 'bks', -1);
INSERT INTO public.device (id, name, enable, camera, type, description, config, version, stand_id, siren) VALUES (71, '(КЭС) Вибрация', true, 28, 'vibration2', '(КЭС) ', '{"alarm": {"count": 3, "delay": 1000, "period": 2000, "timeout": 5000}}', 0, 'kes', -1);
INSERT INTO public.device (id, name, enable, camera, type, description, config, version, stand_id, siren) VALUES (72, '(МКС) Вибрация', true, 29, 'vibration2', '(МКС) ', '{"alarm": {"count": 3, "delay": 1000, "period": 2000, "timeout": 5000}}', 0, 'mks', -1);

INSERT INTO public.ltr_device (sn, num, ch, device, field) VALUES ('2D551737', 1, 1, 70, 'sensorX');
INSERT INTO public.ltr_device (sn, num, ch, device, field) VALUES ('2D551737', 1, 2, 70, 'sensorY');
INSERT INTO public.ltr_device (sn, num, ch, device, field) VALUES ('2D551737', 1, 3, 71, 'sensorX');
INSERT INTO public.ltr_device (sn, num, ch, device, field) VALUES ('2D551737', 1, 4, 71, 'sensorY');
INSERT INTO public.ltr_device (sn, num, ch, device, field) VALUES ('2D551737', 1, 5, 72, 'sensorX');
INSERT INTO public.ltr_device (sn, num, ch, device, field) VALUES ('2D551737', 1, 6, 72, 'sensorY');