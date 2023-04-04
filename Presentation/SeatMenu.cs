class SeatMenu
    {
        private int selectedSeatIndex = 0; // Initially select the first seat
        private string[,] seats = new string[5, 5]; // 5x5 array of seats
        
        public void Show_Seats()
        {
            InitializeSeats(); // Initialize seats with "[ ]"
            DrawSeats(); // Draw initial seats
            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        MoveSelectionUp();
                        break;
                    case ConsoleKey.DownArrow:
                        MoveSelectionDown();
                        break;
                    case ConsoleKey.LeftArrow:
                        MoveSelectionLeft();
                        break;
                    case ConsoleKey.RightArrow:
                        MoveSelectionRight();
                        break;
                    case ConsoleKey.Enter:
                        SelectSeat();
                        break;
                }
            }
        }

        private void InitializeSeats()
        {
            for (int i = 0; i < seats.GetLength(0); i++)
            {
                for (int j = 0; j < seats.GetLength(1); j++)
                {
                    seats[i, j] = "[ ]";
                }
            }
        }

        public void DrawSeats()
        {
            Console.Clear();
            Console.WriteLine("Select a seat:");
            for (int i = 0; i < seats.GetLength(0); i++)
            {
                for (int j = 0; j < seats.GetLength(1); j++)
                {
                    if (i == selectedSeatIndex / seats.GetLength(1) && j == selectedSeatIndex % seats.GetLength(1))
                    {
                        Console.BackgroundColor = ConsoleColor.Green; // Highlight selected seat
                    }
                    Console.Write(seats[i, j] + " ");
                    Console.ResetColor();
                }
                Console.WriteLine();
            }
        }

        private void MoveSelectionUp()
        {
            if (selectedSeatIndex >= seats.GetLength(1))
            {
                selectedSeatIndex -= seats.GetLength(1);
                DrawSeats();
            }
        }

        private void MoveSelectionDown()
        {
            if (selectedSeatIndex < seats.GetLength(0) * seats.GetLength(1) - seats.GetLength(1))
            {
                selectedSeatIndex += seats.GetLength(1);
                DrawSeats();
            }
        }

        private void MoveSelectionLeft()
        {
            if (selectedSeatIndex % seats.GetLength(1) > 0)
            {
                selectedSeatIndex--;
                DrawSeats();
            }
        }

        private void MoveSelectionRight()
        {
            if (selectedSeatIndex % seats.GetLength(1) < seats.GetLength(1) - 1)
            {
                selectedSeatIndex++;
                DrawSeats();
            }
        }

        private void SelectSeat()
        {
            int row = selectedSeatIndex / seats.GetLength(1);
            int col = selectedSeatIndex % seats.GetLength(1);
            if (seats[row, col] == "[ ]")
            {
                seats[row, col] = "[X]"; // Mark the seat as taken
                DrawSeats();
                Console.WriteLine("Seat selected!");
                Console.WriteLine("Want to select more? ");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "y":
                        DrawSeats();
                        break;
                    case "n":
                        Program.Main();
                        break;
                }
                DrawSeats();
            }
            else
            {
                Console.WriteLine("Seat already taken. Please select another seat.");
                
            }
        }
    }