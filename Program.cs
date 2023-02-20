using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.IO;
using System.Collections;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            const char DELIM = ',';
            const char DELIM1 = '#', DELIM3 = ' ';
            const string END = "!!!";

            passenger Passenger = new passenger();

            
            // File statement
            const string FILENAME = "Passenger.txt";

            FileStream outFile = new FileStream(FILENAME, FileMode.Create, FileAccess.Write); //start writing file
            StreamWriter writer = new StreamWriter(outFile);
            // End of file statement
            

            // Get access of current time and date
            DateTime date = DateTime.Now;
            Console.Write("System time: ");
            Console.Write(date);
            Console.WriteLine(DateTime.Now.ToString("dddd.,dd MMM yyyy"));
            // End of getting access of current time and date

            const string BookingSystem = "1";
            const string AvailableTicket = "2";

            WriteLine("\n※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※");
            WriteLine("\n                           Welcome to Flight Booking System!\n");
            WriteLine("※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※");
            WriteLine("\n1. Booking Tickets" +
                "\n2. Available Ticket");
            Write(" >>> ");

            string optionOne = Convert.ToString(ReadLine());
            Clear();

            while (optionOne != BookingSystem && optionOne != AvailableTicket)
            {
                WriteLine("Error! Please try again.");
                WriteLine("1. Booking Tickets" +
                "\n2. Available Ticket");
                Write(">>> ");
                optionOne = Convert.ToString(ReadLine());
                Clear();
            }

            // Give value to array
            string[] availableSeats = { "1","2","3","4","5","6","7","8","9","10",
                        "11","12","13","14","15","16","17","18","19","20",
                        "21","22","23","24","25","26","27","28","29","30",
                        "31","32","33","34","35","36","37","38","39","40"};
            ArrayList RestAvailableSeats = new ArrayList(availableSeats);
            // Change array to arraylist in order to delete or edit the content

            if (optionOne == BookingSystem)
            {
                // Show available Seats
                const string FlightNumber = "N10322795";
                WriteLine("\n※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※");
                WriteLine("\n                   Welcome to Flight CatAir! \n" +
                    "                   Flight Number: {0}\n", FlightNumber);
                WriteLine("※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※\n");

                WriteLine("Available Seats: ");
                availableSeats = (string[])RestAvailableSeats.ToArray(typeof(string));
                Clear();

                WriteLine("---------------------------------------------------------------------------------------------------");
                WriteLine("Available Seats: ");
                availableSeats = (string[])RestAvailableSeats.ToArray(typeof(string));
                foreach (string printSeat in availableSeats)
                {
                    Write(DELIM1 + printSeat + DELIM);
                }
                WriteLine("\n---------------------------------------------------------------------------------------------------");


                Write("Please enter the amount of ticket(s) you want to buy, or {0} to exit >>> ", END);
                string n1 = ReadLine();
                int n2 = 0;

                while (n1 != END)
                {
                    while (!int.TryParse(n1, out n2))
                    {
                        Write("Invalid! Please try again >>>");
                        n1 = ReadLine();
                    } // test whether input value is INT
                    int inputSeatAmount = Convert.ToInt32(n1);
                    while (inputSeatAmount > availableSeats.Length)
                    {
                        Write("Sorry, seats are not enough. Please try again >>> ");
                        n1 = ReadLine();
                        inputSeatAmount = Convert.ToInt32(n1);
                    } // test whether input value is less than available Seats amount

                    string[] firstName = new string[inputSeatAmount];
                    string[] lastName = new string[inputSeatAmount];
                    string[] seatNumber = new string[inputSeatAmount];

                    int passengerNo;

                    for (passengerNo = 0; passengerNo < seatNumber.Length; ++passengerNo)
                    {
                        // Generate Random Security Number
                        Random RandomSecurityNum = new Random();
                        Passenger.securityNumber = RandomSecurityNum.Next(30000, 1000000);
                        Console.WriteLine("Your security number is >>> {0}",
                            Passenger.securityNumber);
                        // End of Random Security Number

                        Write("First Name >>");
                        firstName[passengerNo] = Convert.ToString(ReadLine()).Substring(0, 3);
                        Write("Last Name >>");
                        lastName[passengerNo] = Convert.ToString(ReadLine()).Substring(0, 1);
                        Write("Seat Number >>");
                        seatNumber[passengerNo] = Convert.ToString(ReadLine());

                        bool F = false;

                        while (!int.TryParse(seatNumber[passengerNo], out n2) || RestAvailableSeats.Contains(seatNumber[passengerNo]) == F)
                        {
                            Write("Invalid input! Please retry >>>");
                            seatNumber[passengerNo] = Convert.ToString(ReadLine());
                        }// if input seatnumber can be transfer to integer/exist, then go to next step. If not, go back to loop until true

                        //if (RestAvailableSeats.Contains(seatNumber[passengerNo]) == F)

                        RestAvailableSeats.Remove(seatNumber[passengerNo]); // Remove the seats that user entered from arraylist 

                        //========================================================================
                        // Print airline ticket
                        WriteLine("\n{0,-20} {1,20} {2,20}\n", "Passenger Name", "Seats", "Flight");
                        WriteLine("---------------------------------------------------------------------------------------------------");
                        WriteLine("\n{0,-20} {1,20} {2, 20}\n",
                            firstName[passengerNo].ToString() + DELIM3 + lastName[passengerNo].ToString(),
                            seatNumber[passengerNo].ToString(), FlightNumber);
                        WriteLine("---------------------------------------------------------------------------------------------------");
                        // End of printing
                        //========================================================================

                        ReadKey();

                    }
                    Clear();

                    WriteLine("---------------------------------------------------------------------------------------------------");
                    WriteLine("Available Seats: ");
                    availableSeats = (string[])RestAvailableSeats.ToArray(typeof(string));
                    foreach (string printSeat in availableSeats)
                    {
                        Write(DELIM1 + printSeat + DELIM);
                    }
                    WriteLine("\n---------------------------------------------------------------------------------------------------");
                    
                    // Get Ticket amount
                    Write("Please enter the amount of ticket(s) you want to buy, or {0} to exit >>> ", END);
                    n1 = ReadLine();
                    n2 = 0;
                    
                }// end of while (n1 != END)

                Clear();



            }

            else if (optionOne == AvailableTicket)
            {
                WriteLine("---------------------------------------------------------------------------------------------------");
                WriteLine("Available Seats: ");
                availableSeats = (string[])RestAvailableSeats.ToArray(typeof(string));
                foreach (string printSeat in availableSeats)
                {
                    Write(DELIM1 + printSeat + DELIM);
                }
                WriteLine("\n---------------------------------------------------------------------------------------------------");

                ReadKey();
                Clear();
            }

            writer.Close();
            outFile.Close();
            // End of writing file

            /*
            // Start reading file
            FileStream inFile = new FileStream(FILENAME, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(inFile);

            string recordIn;
            string[] fields;

            WriteLine("\n{0,-5} {1,-15} {2,20} {3,20}\n", "First Name", "Last Name", "Security Number", "Seat Number");
            
            
            recordIn = reader.ReadLine();

            while (recordIn != null)
            {
                fields = recordIn.Split(DELIM);

                Passenger.firstName[Passenger.passengerNo] = Convert.ToString(fields[0]);
                Passenger.lastName[Passenger.passengerNo] = Convert.ToString(fields[1]);
                Passenger.securityNumber = Convert.ToInt32(fields[2]);
                Passenger.seatNumber[Passenger.passengerNo] = Convert.ToString(fields[3]);

                WriteLine("{0,-5} {1,-15} {2,20} {3,20}",
                    Passenger.firstName[Passenger.passengerNo], Passenger.lastName[Passenger.passengerNo], Passenger.securityNumber, Passenger.seatNumber[Passenger.passengerNo].ToString());
                recordIn = reader.ReadLine();
            }
            
            ReadKey();
            Clear();

            reader.Close();
            inFile.Close();
            // End of Reading file
            */
        }
    }
}

