UPDATE public.camera SET name = '(БКС) ОН 2', description = 'ОН 2' WHERE id = 4;
UPDATE public.camera SET name = '(БКС) ОН 1', description = 'ОН 1' WHERE id = 6;

UPDATE public.device SET camera = 14 WHERE id = 10;
UPDATE public.device SET camera = 6 WHERE id = 18;
UPDATE public.device SET camera = 4 WHERE id = 19;
UPDATE public.device SET camera = 6 WHERE id = 36;

UPDATE public.device SET name = '(КЭС) Оптоствор 2', enable = true, camera = 28, type = 'hurble', description = 'КЭС2', config = '{"alarm": {"count": 3, "delay": 1000, "period": 2000, "timeout": 1000}, "counter": {"threshold": 10}}', version = 0, stand_id = 'kes', siren = -4, removed = false WHERE id = 60;
UPDATE public.device SET name = '(МКС) Оптоствор', enable = true, camera = 29, type = 'hurble', description = 'МКС', config = '{"alarm": {"count": 3, "delay": 1000, "period": 2000, "timeout": 1000}, "counter": {"threshold": 10}}', version = 0, stand_id = 'mks', siren = -3, removed = false WHERE id = 61;

DELETE FROM public.ltr_device where device = 60;
DELETE FROM public.ltr_device where device = 61;

INSERT INTO public.ltr_device (sn, num, ch, device, field, cfg) VALUES ('2D551737', 2, 3, 61, 'remote', '{}');
INSERT INTO public.ltr_device (sn, num, ch, device, field, cfg) VALUES ('2D551737', 2, 7, 61, 'sensor', '{}');
INSERT INTO public.ltr_device (sn, num, ch, device, field, cfg) VALUES ('2D551737', 2, 11, 61, 'encoder', '{}');
INSERT INTO public.ltr_device (sn, num, ch, device, field, cfg) VALUES ('2D551744', 1, 2, 60, 'sensor', '{}');
INSERT INTO public.ltr_device (sn, num, ch, device, field, cfg) VALUES ('2D551744', 1, 13, 60, 'remote', '{}');
INSERT INTO public.ltr_device (sn, num, ch, device, field, cfg) VALUES ('2D551737', 2, 10, 60, 'encoder', '{}');