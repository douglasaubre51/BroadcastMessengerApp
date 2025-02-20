create database BroadcastDb;

use BroadcastDb;

select *
from sys.tables;

select*
from Accounts;

exec sp_help Accounts;

truncate table Accounts;

exec sp_help Channels;

exec sp_help Messages;

delete from Accounts where Id=3;

select * from Channels;

select * from Messages;