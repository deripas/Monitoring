DELETE FROM public.ltr_device where device = 66 AND (field = 'motorDW' OR field = 'motorUP');
DELETE FROM public.ltr_device where device = 68 AND (field = 'motorDW' OR field = 'motorUP');

INSERT INTO public.ltr_device (sn, num, ch, device, field, cfg) VALUES ('2D551744', 2, 9, 68, 'motorDW', '{}');
INSERT INTO public.ltr_device (sn, num, ch, device, field, cfg) VALUES ('2D551744', 2, 10, 68, 'motorUP', '{}');
INSERT INTO public.ltr_device (sn, num, ch, device, field, cfg) VALUES ('2D551744', 2, 13, 66, 'motorDW', '{}');
INSERT INTO public.ltr_device (sn, num, ch, device, field, cfg) VALUES ('2D551744', 2, 14, 66, 'motorUP', '{}');