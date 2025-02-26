create database BroadcastDb;

use BroadcastDb;

select *
from sys.tables;

select*
from Accounts;

exec sp_help Accounts;


exec sp_help Channels;

exec sp_help Messages;


select *
from Channels;

select *
from Messages;

update Channels set AccountId=5 where ChannelId=4;