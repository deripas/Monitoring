DELETE FROM public.ltr_device where sn = '2D551744' AND num = 1 AND ch = 11;
DELETE FROM public.ltr_device where sn = '2D551744' AND num = 1 AND ch = 12;
DELETE FROM public.ltr_device where sn = '2D551744' AND num = 1 AND ch = 15;
DELETE FROM public.ltr_device where sn = '2D551744' AND num = 1 AND ch = 16;

INSERT INTO public.ltr_device (sn, num, ch, device, field, cfg) VALUES ('2D551744', 1, 11, null, null, '{}');
INSERT INTO public.ltr_device (sn, num, ch, device, field, cfg) VALUES ('2D551744', 1, 12, null, null, '{}');
INSERT INTO public.ltr_device (sn, num, ch, device, field, cfg) VALUES ('2D551744', 1, 15, 26, 'sensor', '{}');
INSERT INTO public.ltr_device (sn, num, ch, device, field, cfg) VALUES ('2D551744', 1, 16, 20, 'sensor', '{}');