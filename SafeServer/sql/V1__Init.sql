CREATE EXTENSION timescaledb;

-- Create Table NVR
create table nvr
(
    id serial not null
        constraint dvr_pk
            primary key,
    ip text,
    port integer,
    login text,
    password text
);

create unique index dvr_id_uindex
    on nvr (id);


-- Create Table CAMERA
create table camera
(
    id serial not null
        constraint camera_pk
            primary key,
    name text,
    rate integer default 25,
    ratio double precision default 0.5625,
    dvr integer not null
        constraint camera_dvr_id_fk
            references nvr,
    channel integer not null,
    stand text,
    location text,
    enable boolean default true
);

create unique index camera_id_uindex
    on camera (id);


-- Create Table SENSOR
create table sensor
(
    id serial not null
        constraint sensor_pk
            primary key,
    name text,
    enable boolean default true
);

create unique index sensor_id_uindex
    on sensor (id);

-- Create Table ALERT
create table alert
(
    id bigserial not null
        constraint alert_pk
            primary key,
    camera integer
        constraint alert_camera_id_fk
            references camera,
    device integer,
    value double precision,
    processed boolean default false,
    time timestamp
);

create unique index alert_id_uindex
    on alert (id);

create index alert_time_index
    on alert (time desc);



