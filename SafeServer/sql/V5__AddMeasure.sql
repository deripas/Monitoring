create table measure
(
	time timestamp,
	device int,
	val double precision
);

SELECT create_hypertable('measure', 'time');