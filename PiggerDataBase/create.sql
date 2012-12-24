create table Users(
	user_id int identity(1,1) primary key,
	user_name varchar(20) unique,
	real_name varchar(20),
	passwd varchar(128),
	job varchar(20),
	user_group smallint not null,
	constraint CK_GROUP check(user_group = 0 or user_group = 1)
)

create table AccountType (
	type_id int identity(1,1) primary key,
	type_name varchar(50) not null unique
)

create table Budget(
	budget_id int identity(1,1) primary key,
	user_id int foreign key references Users(user_id),
	year int not null,
	month int not null,
	in_out smallint not null,
	type_id int foreign key references AccountType(type_id),
	budget_money float not null,
	constraint CK_INOUT check(in_out = 0 or in_out = 1),
	constraint CK_MONEY check(budget_money > 0),
	constraint CK_YEAR check(year > 2010 and year < 2050),
	constraint CK_MONTH check(month >= 1 and month <= 12)
)

create table Account (
	account_id int identity(1,1) primary key,
	user_id int foreign key references Users(user_id),
	type_id int foreign key references AccountType(type_id),
	in_out smallint not null,
	account_money float not null,
	content varchar(1000) not null,
	account_date datetime not null,
	constraint CK_ACCMONEY check(account_money > 0)
)