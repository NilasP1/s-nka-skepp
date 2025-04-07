﻿



Console.BackgroundColor = ConsoleColor.DarkMagenta;
Console.ForegroundColor = ConsoleColor.Black;
Console.Clear();

//The users playingfireld where they place ships
string[,] PlayingfieldUser = new string[10, 10];

for (int y = 0; y < 10; y++)
{
    for (int x = 0; x < 10; x++)
    {
        PlayingfieldUser[y, x] = "  #";
    }
}


//The computers playingfireld where it places it's ships
string[,] Playingfieldcomputer = new string[10, 10];

for (int y = 0; y < 10; y++)
{
    for (int x = 0; x < 10; x++)
    {
        Playingfieldcomputer[y, x] = "  #";
    }
}


//The playingfield that the user uses to attack
string[,] Playingfielduserattack = new string[10, 10];

for (int y = 0; y < 10; y++)
{
    for (int x = 0; x < 10; x++)
    {
        Playingfielduserattack[y, x] = "  #";
    }
}


//Computers attack playingfield
string[,] PlayingfieldCompAttack = new string[10, 10];

for (int y = 0; y < 10; y++)
{
    for (int x = 0; x < 10; x++)
    {
        PlayingfieldCompAttack[y, x] = "  #";
    }
}


//ForbiddenNumbers array
bool[,] ForbiddenNumbers = new bool[10, 10]; // false by default


for (int a = 0; a < 5; a++)
{
    Console.Clear();
    //Writes the user playingfield
    WriteField(PlayingfieldUser);

    //takes ship cords from user
    Console.WriteLine("Where do you want to place your ship?");
    Console.WriteLine("Coordinate Y:");
    int Ycord;
    if (int.TryParse(Console.ReadLine(), out Ycord))
    {
        // Successfully parsed the input
    }
    else
    {
        // Handle invalid input
        InvalidShipPlacement();
        a--;
        continue;
    }
    Ycord--;

    //Checks if they are valid
    if(Ycord < 0 || Ycord >= 10)
    {
        InvalidShipPlacement();
        a--;
        continue;
    }

    Console.WriteLine("And now the X coordinate:");
    int Xcord;
    if (int.TryParse(Console.ReadLine(), out Xcord))
    {
        // Successfully parsed the input
    }
    else
    {
        // Handle invalid input
        InvalidShipPlacement();
        a--;
        continue;
    }
    Xcord--;

    if (Xcord < 0 || Xcord >= 10)
    {
        InvalidShipPlacement();
        a--;
        continue;
    }

    // Check if the coordinates are already forbidden

    if (ForbiddenNumbers[Ycord, Xcord])
    {
        Console.WriteLine("There is already a ship in this spot");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
        a--;
        continue;
    }

    string ShipDirection = "";
    while (ShipDirection != "h" && ShipDirection != "v")
    {
        Console.WriteLine("Do you want to place it vertically (V) or horizontally (H)?");
        string input = Console.ReadLine();
        ShipDirection = (input ?? "").ToLower();

        if (ShipDirection != "h" && ShipDirection != "v")
        {
            Console.WriteLine("Invalid input. Please enter 'H' or 'V'.");
            Console.WriteLine("Press any key to try again...");
            Console.ReadKey();
            Console.Clear();
            WriteField(PlayingfieldUser); // reprint the field so it doesn't disappear
        }
    }

    if (ShipDirection == "h") 
    {
        // Make sure it's within bounds first
        if (Xcord + 1 >= 10)
        {
            InvalidShipPlacement();
            a--;
            continue;
        }

        if (ForbiddenNumbers[Ycord, Xcord + 1])
        {
            Console.WriteLine("There is already a ship in this spot");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            a--;
            continue;
        }

        PlayingfieldUser[Ycord, Xcord] = "  O";
        PlayingfieldUser[Ycord, Xcord + 1] = "  O";

        // Mark as forbidden
        ForbiddenNumbers[Ycord, Xcord] = true;
        ForbiddenNumbers[Ycord, Xcord + 1] = true;
    }

    if (ShipDirection == "v") 
    {
        // Make sure it's within bounds first
        if (Xcord + 1 >= 10)
        {
            InvalidShipPlacement();
            a--;
            continue;
        }

        if (ForbiddenNumbers[Ycord + 1, Xcord])
        {
            Console.WriteLine("There is already a ship in this spot");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            a--;
            continue;
        }

        PlayingfieldUser[Ycord, Xcord] = "  O";
        PlayingfieldUser[Ycord + 1, Xcord] = "  O";

        // Mark as forbidden
        ForbiddenNumbers[Ycord, Xcord] = true;
        ForbiddenNumbers[Ycord + 1, Xcord] = true;
    }

    Console.Clear();
    Console.WriteLine("Next ship");
    Console.WriteLine(" ");
}

Console.Clear();
Console.WriteLine("    1   2   3   4   5   6   7   8   9   10");
Random random = new Random();

//The forbidden numbers for when the computer is choosing
bool[,] ForbiddenNumbersComp = new bool[10, 10];

for (int a = 0; a < 5; a++) // Only place 5 ships
{
    bool placed = false;

    while (!placed)
    {
        int Ycordcomp = random.Next(0, 10);
        int Xcordcomp = random.Next(0, 10);

        bool isHorizontal = random.Next(2) == 0; // 0 = horizontal, 1 = vertical

        if (isHorizontal)
        {
            if (Xcordcomp + 1 >= 10) continue; // Prevent out-of-bounds

            if (ForbiddenNumbersComp[Ycordcomp, Xcordcomp] || ForbiddenNumbersComp[Ycordcomp, Xcordcomp + 1])
                continue;

            // Place horizontal ship
            Playingfieldcomputer[Ycordcomp, Xcordcomp] = "  O";
            Playingfieldcomputer[Ycordcomp, Xcordcomp + 1] = "  O";

            ForbiddenNumbersComp[Ycordcomp, Xcordcomp] = true;
            ForbiddenNumbersComp[Ycordcomp, Xcordcomp + 1] = true;
            placed = true;
        }
        else
        {
            if (Ycordcomp + 1 >= 10) continue; // Prevent out-of-bounds

            if (ForbiddenNumbersComp[Ycordcomp, Xcordcomp] || ForbiddenNumbersComp[Ycordcomp + 1, Xcordcomp])
                continue;

            // Place vertical ship
            Playingfieldcomputer[Ycordcomp, Xcordcomp] = "  O";
            Playingfieldcomputer[Ycordcomp + 1, Xcordcomp] = "  O";

            ForbiddenNumbersComp[Ycordcomp, Xcordcomp] = true;
            ForbiddenNumbersComp[Ycordcomp + 1, Xcordcomp] = true;
            placed = true;
        }
    }
}

bool cont = true;
int hit = 0;
int compHit = 0;

while (cont)
{
    Console.Clear();

    WriteField(PlayingfieldUser);
    WriteField(Playingfielduserattack);
    Console.WriteLine(" ");
    Console.WriteLine("You have hit: " + hit + " of the computers ships");
    Console.WriteLine(" ");

    //Asks the user for attack cords and checks if they are valid
    Console.WriteLine("where do you want to attack?");
    Console.WriteLine("Y-cordinate:");

    int attackY;
    if (int.TryParse(Console.ReadLine(), out attackY))
    {
        // Successfully parsed the input
    }
    else
    {
        // Handle invalid input
        InvalidShipPlacement();
        continue;
    }

    attackY--;

    if(attackY <= 0 || attackY >= 10)
    {
        InvalidShipPlacement();
        continue;
    }

    //Clears and writes everything again
    Console.Clear();

    Console.WriteLine(" ");
    WriteField(PlayingfieldUser);
    WriteField(Playingfielduserattack);
    Console.WriteLine(" ");
    Console.WriteLine("You have hit: " + hit + " of the computers ships");
    Console.WriteLine(" ");

    //asks for x cords and saves. then checks if they are invalid.
    Console.WriteLine("X-cordinate:");

    int attackX;
    if (int.TryParse(Console.ReadLine(), out attackX))
    {
        // Successfully parsed the input
    }
    else
    {
        // Handle invalid input
        InvalidShipPlacement();
        continue;
    }

    attackX--;

    if (attackX <= 0 || attackX >= 10)
    {
        InvalidShipPlacement();
        continue;
    }

    if (Playingfielduserattack[attackY, attackX] == "  X" || Playingfielduserattack[attackY, attackX] == "  O" )
    {
        InvalidShipPlacement();
        continue;
    }

    //Clears everything and writes it again
    Console.Clear();
    Console.WriteLine(" ");
    WriteField(PlayingfieldUser);

    WriteField(Playingfielduserattack);
    Console.WriteLine(" ");
    Console.WriteLine("You have hit: " + hit + " of the computers ships");
    Console.WriteLine(" ");

    //Checks if you hit and marks it in the users attack playingfield
    if (Playingfieldcomputer[attackY, attackX] == "  O")
    {
        hit++;
        Console.WriteLine("HIT!");
        Console.WriteLine(" ");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();

        Playingfielduserattack[attackY, attackX] = "  X";
    }
    else
    {
        Playingfielduserattack[attackY, attackX] = "  X";
        Console.WriteLine(" ");
    }

    //Checks if you hit 10 times and won

    if (hit == 10)
    {
        cont = false;
        Console.WriteLine("You Won!");
        break;
    }

    int compAttackCordY2 = 0;
    int compAttackCordX2 = 0;

    while (true)
    {
        int compAttackCordX = random.Next(0, 10);
        int compAttackCordY = random.Next(0, 10);

        // cheack if it is already attacked
        if (PlayingfieldCompAttack[compAttackCordY, compAttackCordX] == "  X")
        {
            continue; // find new attack position
        }
        // Found attack position
        compAttackCordY2 = compAttackCordY;
        compAttackCordX2 = compAttackCordX;
        break;
    }

    // check if attack hit ship
    if (PlayingfieldUser[compAttackCordY2, compAttackCordX2] == "  O")
    {
        Console.WriteLine($"Computer hit your ship on Y: {compAttackCordY2 + 1}, X: {compAttackCordX2 + 1}");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();

        PlayingfieldUser[compAttackCordY2, compAttackCordX2] = "  X";
        compHit++;
    }
    else
    {
        Console.WriteLine("Computer missed.");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();

        PlayingfieldUser[compAttackCordY2, compAttackCordX2] = "  X";
    }

    // Save attack position in PlayingfieldCompAttack
    PlayingfieldCompAttack[compAttackCordY2, compAttackCordX2] = "  X";

    if (compHit == 10)
    {
        Console.WriteLine("Computer won!");
        cont = false;
    }
}

//Method for drawing the playingfields
void WriteField(string[,] field)
{
    Console.WriteLine(" ");
    Console.WriteLine("   \t  1   2   3   4   5   6   7   8   9   10");

    for (int i = 0; i < 10; i++)
    {
        Console.Write((i + 1) + "\t");
        Console.BackgroundColor = ConsoleColor.Blue;
        Console.ForegroundColor = ConsoleColor.DarkBlue;

        for (int o = 0; o < 10; o++)
        {
            if (field[i, o] == "  O")
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            Console.Write(field[i, o] + " ");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
        }

        Console.WriteLine();
        Console.BackgroundColor = ConsoleColor.DarkMagenta;
        Console.ForegroundColor = ConsoleColor.Black;
    }
}
//Method for error in coordinate selection
void InvalidShipPlacement()
{
    Console.WriteLine("Invalid input, please enter a valid number.");
    Console.WriteLine("Press any key to continue...");
    Console.ReadKey();

    Console.Clear();
}