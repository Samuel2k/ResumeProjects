USE Hotel
GO

--1. Write a query that returns a list of reservations that end in July 2023, 
--	 including the name of the guest, the room number(s), and the reservation dates.
SELECT GuestName, RoomNumber, StartDate, EndDate
FROM Reservations
JOIN RoomsReservations
ON Reservations.ReservationId = RoomsReservations.ReservationId
JOIN Guests
ON Guests.GuestId = Reservations.GuestId
AND EndDate LIKE '2023-07-%';
/*Results:
GuestName		RoomNumber	StartDate	EndDate
Sam Krinhop		205			2023-06-28	2023-07-02
Walter Holaway	204			2023-07-13	2023-07-14
Wilfred Vise	401			2023-07-18	2023-07-21
Bettyann Seery	303			2023-07-28	2023-07-29
*/


--2. Write a query that returns a list of all reservations for rooms with a jacuzzi,
--	 displaying the guest's name, the room number, and the dates of the reservation.
SELECT GuestName, RoomsReservations.RoomNumber, StartDate, EndDate
FROM Reservations
JOIN RoomsReservations
ON Reservations.ReservationId = RoomsReservations.ReservationId
JOIN Rooms
ON Rooms.RoomNumber = RoomsReservations.RoomNumber
JOIN Guests
ON Guests.GuestId = Reservations.GuestId
AND Amenities LIKE '%jacuzzi%';
/*Results:
GuestName		RoomNumber	StartDate	EndDate
Bettyann Seery	203			2023-02-05	2023-02-10
Duane Cullison	305			2023-02-22	2023-02-24
Karie Yang		201			2023-03-06	2023-03-07
Sam Krinhop		307			2023-03-17	2023-03-20
Walter Holaway	301			2023-04-09	2023-04-13
Wilfred Vise	207			2023-04-23	2023-04-24
Sam Krinhop		205			2023-06-28	2023-07-02
Bettyann Seery	303			2023-07-28	2023-07-29
Bettyann Seery	305			2023-08-30	2023-09-01
Karie Yang		203			2023-09-13	2023-09-15
Mack Simmer		301			2023-11-22	2023-11-25
*/


--3. Write a query that returns all the rooms reserved for a specific guest,
--	 including the guest's name, the room(s) reserved, the starting date of the reservation, 
--	 and how many people were included in the reservation. (Choose a guest's name from the existing data.)
SELECT RoomNumber, GuestName, StartDate, Adults, Children
FROM Reservations
JOIN RoomsReservations
ON Reservations.ReservationId = RoomsReservations.ReservationId
JOIN Guests
ON Guests.GuestId = Reservations.GuestId
WHERE Guests.GuestId = '1'
/*Results:
RoomNumber	GuestName	StartDate	Adults	Children
307			Sam Krinhop	2023-03-17	1		1
205			Sam Krinhop	2023-06-28	2		0
*/


--4. Write a query that returns a list of rooms, reservation ID, and per-room cost for each reservation.
--	 The results should include all rooms, whether or not there is a reservation associated with the room.
SELECT Rooms.RoomNumber, Reservations.ReservationId, TotalRoomCost
FROM Reservations
JOIN RoomsReservations
ON Reservations.ReservationId = RoomsReservations.ReservationId
FULL OUTER JOIN Rooms
ON Rooms.RoomNumber = RoomsReservations.RoomNumber
ORDER BY RoomNumber
/*Results:
RoomNumber	ReservationId	TotalRoomCost
201			4				200
202			7				350
203			2				1000
203			21				400
204			16				185
205			15				700
206			23				450
206			12				600
207			10				175
208			13				600
208			20				150
301			24				600
301			9				800
302			6				925
302			25				700
303			18				200
304			14				185
305			19				350
305			3				350
306			NULL			NULL
307			5				525
308			1				300
401			17				1260
401			11				1200
401			22				1200
402			NULL			NULL
*/


--5. Write a query that returns all the rooms accommodating at least three guests and that are reserved on any date in April 2023.
SELECT Rooms.RoomNumber, MaxOccupancy
FROM Reservations
JOIN RoomsReservations
ON Reservations.ReservationId = RoomsReservations.ReservationId
JOIN Rooms
ON Rooms.RoomNumber = RoomsReservations.RoomNumber
WHERE MaxOccupancy >= 3 
AND (StartDate LIKE '2023-04-%')
/*Results:
RoomNumber	MaxOccupancy
301			4
*/

USE Hotel
GO

--6. Write a query that returns a list of all guest names and the number of reservations per guest, 
--	 sorted starting with the guest with the most reservations and then by the guest's last name.
SELECT GuestName, COUNT(Reservations.ReservationId)
FROM Reservations
JOIN Guests
ON Guests.GuestId = Reservations.GuestId
GROUP BY GuestName
ORDER BY COUNT(Reservations.ReservationId) DESC, SUBSTRING(GuestName, CHARINDEX(' ', GuestName),60)

/*Results:
GuestName			(No column name)
Mack Simmer			4
Bettyann Seery		3
Duane Cullison		2
Walter Holaway		2
Sam Krinhop			2
Aurore Lipton		2
Maritza Tilton		2
Joleen Tison		2
Wilfred Vise		2
Karie Yang			2
Zachery Luechtefeld	1
*/



--7. Write a query that displays the name, address, and phone number of a guest based on their phone number.
--	 (Choose a phone number from the existing data.)
SELECT GuestName, Address, Phone
FROM Guests
WHERE Phone = '(291) 553-0508'
/*Results:
GuestName	Address					Phone
Mack Simmer	379 Old Shore Street	(291) 553-0508
*/
