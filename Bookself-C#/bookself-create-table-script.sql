create table book
(
	isbn		int				not null,
	title		varchar(200)	not null,
	authors		varchar(300)	not null,

	constraint pk_book primary key (isbn) 
);

create table bookself_user
(
	id			int IDENTITY(1,1) not null,
	username	varchar(30)		not null,
	fname		varchar(50)		not null,
	lname		varchar(50)		not null,
	join_date	datetime		not null DEFAULT(GETDATE()),
	pasword		varchar(100)	not null,

	constraint pk_user primary key (id),
	constraint ux_user_username unique (username)
);

create table user_book
(
	[user_id]	int		not null,
	book_isbn	int		not null,

	constraint pk_user_book primary key ([user_id], book_isbn),
	constraint fk_userbook_userid foreign key ([user_id]) references bookself_user(id),
	constraint fk_userbook_bookisbn foreign key (book_isbn) references book(isbn)
);

create table tag
(
	id		int IDENTITY(1,1)	not null,
	tag_name	varchar(100)	not null,

	constraint pk_tag primary key (id),
	constraint ux_tag_name unique (tag_name)
);

create table book_tag
(
	tag_name	varchar(100)	not null,
	book_isbn	int				not null,

	constraint pk_booktag_tagisbn primary key (tag_name, book_isbn),
	constraint fk_booktag_tagname foreign key (tag_name) references tag(tag_name),
	constraint fk_booktag_bookisbn foreign key (book_isbn) references book(isbn)
);
