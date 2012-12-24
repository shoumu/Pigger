drop table Budget

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