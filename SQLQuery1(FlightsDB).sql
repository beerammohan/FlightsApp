create database FlightsDB;
use FlightsDB;

create table Airlines (
AirlinesID int primary key,
AirlinesName varchar(20),
);

create table Flights(
FlightsID int identity(1,1) primary key,
Source varchar(20),
Destination varchar(20),
AirlinesID int foreign key references Airlines(AirlinesID),
D_Date date,
D_Time varchar(10),
A_Date date,
A_Time varchar(10),
Price decimal(10,2)
);

Alter table Flights

insert into Airlines values
(1001, 'INDIGO'),
(1002, 'AIR INDIA'),
(1003, 'SPICE JET'),
(1004, 'AIR ASIA'),
(1005, 'ALLIANCE AIR'),
(1006, 'GOFIRST');

insert into Flights values
( 'Jaipur', 'Banglore', 1001, '2022-04-29','4:30hrs', '2022-04-29', '13:00hrs', 4840.00),
( 'New Delhi', 'Mumbai', 1002, '2022-05-04','6:30hrs', '2022-05-04', '9:00hrs', 4637.00),
( 'Mumbai', 'Jaipur', 1003, '2022-05-10','19:00hrs', '2022-05-11', '4:00hrs', 10342.00),
( 'Banglore', 'New Delhi', 1006, '2022-04-29','10:00hrs', '2022-04-29', '13:00hrs', 6739.00);

select * from Airlines ;
select * from Flights;

delete Airlines;
delete Flights;

drop table Airlines;
drop table Flights;

--stored procedure
create procedure USP_ADD_FLIGHTS_DATA11
@Source varchar(20),
@Destination varchar(20),
@AirlinesID int,
@D_Date date,
@D_Time varchar(10),
@A_Date date,
@A_Time varchar(10),
@Price decimal(10,2),
@FlightsID int  output
as
begin
     begin try
	        --To check AirlinesID exists
			declare @airlines_id_exist int
			select @airlines_id_exist=count(*) from dbo.Airlines where AirlinesID=@AirlinesID
			if @airlines_id_exist=0
			begin
			      --AirlinesID doesn't exist
				  set @FlightsID=-1
				  return
			end

			--To check Departure date is valid
			if @D_Date<GETDATE()
			begin
			     --departure date is in the past
				 set @FlightsID=-2
				 return
			end

			--To check Arrival date is valid
			if @A_Date<@D_Date
			begin
			      --Arrival date is before departure date
				  set @FlightsID=-3
				  return
			end

			  

			  --Insert data into flights table
			  insert into dbo.Flights values
			  
			  (@Source,@Destination,@AirlinesID,@D_Date,@D_Time,@A_Date,@A_Time,@Price)

			  --Get the generated flights id
			  set @FlightsID=SCOPE_IDENTITY()
	 end try
	 begin catch
	             --Handle any exceptions
			set @FlightsID=-999 --set a custom error code if needed	 
		Select ERROR_NUMBER() AS ErrorNumber,
    ERROR_STATE() AS ErrorState,
    ERROR_SEVERITY() AS ErrorSeverity,
    ERROR_PROCEDURE() AS ErrorProcedure,
    ERROR_LINE() AS ErrorLine,
    ERROR_MESSAGE() AS ErrorMessage;
     end catch
end

declare @Flights_ID int 
exec USP_ADD_FLIGHTS_DATA11 @Source='Hyderabad', @Destination='Jaipur', @AirlinesID=1007, @D_Date='2023-09-11', @D_Time='10:00hrs', 
@A_Date='2023-09-12', @A_Time='13:00hrs', @Price=4807.00, @FlightsID=@Flights_ID output;

--check the result 
select @Flights_ID as FlightsID