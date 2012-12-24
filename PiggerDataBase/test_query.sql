--select * from Users where user_name = 'shoumu'
--select * from Users
--delete from Users where user_id = 11

--update Users set user_group = 0 where user_name = 'shoumu'

--insert into Users(user_name,user_group) values('jafk',0)

--select * from AccountType
--delete from AccountType where type_id = 8
--select * from Users
--select * from Account
--insert into Account(user_id,type_id,in_out,account_money,content,account_date) values (4,1,1,300,'faflajflaj','1991-08-29')

--select Account.account_date,Account.in_out,AccountType.type_name,Account.account_money,Account.content from Account,AccountType
--where Account.type_id = AccountType.type_id and Account.user_id = 28


--select Account.account_date,Account.in_out,AccountType.type_name,Account.account_money,Account.content from Account,AccountType where Account.type_id = AccountType.type_id and Account.user_id = 28
--select * from Account
--select * from Users

--select type_id,type_name from AccountType where type_id in (select type_id from Account where user_id = (select user_id from Users where user_name = 'liling'));

--select * from Budget
--alter table Budget add (user_id int foreign key references Users)

select * from Budget
--insert into Budget(user_id,year,month,in_out,type_id,budget_money) values()

select budget_id,year,month,in_out,type_name,budget_money from Budget,AccountType where Budget.type_id = AccountType.type_id and Budget.user_id = 6