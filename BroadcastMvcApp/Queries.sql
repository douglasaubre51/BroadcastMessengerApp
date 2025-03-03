create database BroadcastDb;

use BroadcastDb;

select *
from sys.tables;

select*
from Accounts;

exec sp_help Accounts;

exec sp_help Channels;

exec sp_help Messages;

SELECT *
from __EFMigrationsHistory;

select *
from Channels;

select *
from Messages;

drop table Channels;
drop table Accounts;
drop table Messages;

delete from __EFMigrationsHistory;
drop table __EFMigrationsHistory;