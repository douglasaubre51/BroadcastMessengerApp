create database BroadcastDb;

use BroadcastDb;

select *
from sys.tables;


exec sp_help Accounts;

exec sp_help Channels;

exec sp_help Messages;

SELECT *
from __EFMigrationsHistory;

select*
from Accounts;

select *
from Channels;

select *
from Messages;

update Accounts set ProfilePhotoURL='/images/reze.jpeg]' where AccountId=2;

update Accounts set ProfilePhotoURL='/images/boruto.jpg' where AccountId=2;

drop table Channels;
drop table Accounts;
drop table Messages;

truncate table Accounts;

delete from __EFMigrationsHistory;
drop table __EFMigrationsHistory;
