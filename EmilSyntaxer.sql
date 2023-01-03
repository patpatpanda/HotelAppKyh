select max(DateEnd), LastName
from Guests a
join
Reservations b
on a.GuestId = b.GuestId 
group by LastName

select * 
from Reservations
where DateStart > (select min(DateEnd)
                   from Reservations)


Select * from Guests  order by FirstName	
select * from Rooms where RoomSize > 40
