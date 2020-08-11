alter table device
	add description text;

UPDATE device SET description = name;