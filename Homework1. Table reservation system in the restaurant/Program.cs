using Homework1._Table_reservation_system_in_the_restaurant;
using Homework1._Table_reservation_system_in_the_restaurant.Repositories;

////Table tableOne = new Table(1, 4);
////Table tableTwo = new Table(2, 2);
////Table tableThree = new Table(3, 6);
////Table tableFour = new Table(4, 10);

////Table tableFive = new Table(5, 2);

////Administrator administrator = new Administrator();

//////administrator.AddTable(tableOne);
//////administrator.AddTable(tableTwo);
//////administrator.AddTable(tableThree);
//////administrator.AddTable(tableFour);
//////administrator.AddTable(tableFive);

////administrator.RemoveTable(5);

//////Reservation reservationForTwo = new Reservation("Alex", "11111111", new DateTime(2023, 01, 01, 19, 00, 00), 2, tableTwo);

//////administrator.CreateReservation(reservationForTwo);
//////administrator.CreateReservation(reservationForTwo);



////Console.WriteLine();

//TableRepository tr = new TableRepository();
////tr.StreamWriterInFile();
////tr.StreamWriterInFile();

Table table = new Table(1, 4);
Table table1 = new Table(2, 8);
TableRepository tableRepository = new TableRepository(@"C:\Users\Кристина\Desktop\MakeUPro\Коды\");
//tableRepository.AddTable(table);
//tableRepository.AddTable(table1);

Reservation res = new Reservation();

ReservationRepository reservationRepository = new ReservationRepository(@"C:\Users\Кристина\Desktop\MakeUPro\Коды\");
reservationRepository.AddReservation(res);