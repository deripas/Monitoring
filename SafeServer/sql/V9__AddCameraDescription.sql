alter table camera
    add description text;

UPDATE camera SET description = name;
UPDATE camera SET name = CONCAT('(', stand, ')', ' ', description);