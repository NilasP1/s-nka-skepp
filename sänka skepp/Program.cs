


using static System.Net.Mime.MediaTypeNames;

//The users playingfireld where they place ships
string[,] PlayingfieldUser = { { "  #", "  #", "  #", "  #", "  #", "  #", "  #", "  #", "  #", "  #" },
                               { "  #", "  #", "  #", "  #", "  #", "  #", "  #", "  #", "  #", "  #" },
                               { "  #", "  #", "  #", "  #", "  #", "  #", "  #", "  #", "  #", "  #" },
                               { "  #", "  #", "  #", "  #", "  #", "  #", "  #", "  #", "  #", "  #" },
                               { "  #", "  #", "  #", "  #", "  #", "  #", "  #", "  #", "  #", "  #" },
                               { "  #", "  #", "  #", "  #", "  #", "  #", "  #", "  #", "  #", "  #" },
                               { "  #", "  #", "  #", "  #", "  #", "  #", "  #", "  #", "  #", "  #" },
                               { "  #", "  #", "  #", "  #", "  #", "  #", "  #", "  #", "  #", "  #" },
                               { "  #", "  #", "  #", "  #", "  #", "  #", "  #", "  #", "  #", "  #" },
                               { " #", "  #", "  #", "  #", "  #", "  #", "  #", "  #", "  #", "  #" } 
};

//The computers playingfireld where it places it's ships
string[,] Playingfieldcomputer = { { "  #", "  #", "  #", "  #", "  #", "  #", "  #", "  #", "  #", "  #" },
                               { "  #", "  #", "  #", "  #", "  #", "  #", "  #", "  #", "  #", "  #" },
                               { "  #", "  #", "  #", "  #", "  #", "  #", "  #", "  #", "  #", "  #" },
                               { "  #", "  #", "  #", "  #", "  #", "  #", "  #", "  #", "  #", "  #" },
                               { "  #", "  #", "  #", "  #", "  #", "  #", "  #", "  #", "  #", "  #" },
                               { "  #", "  #", "  #", "  #", "  #", "  #", "  #", "  #", "  #", "  #" },
                               { "  #", "  #", "  #", "  #", "  #", "  #", "  #", "  #", "  #", "  #" },
                               { "  #", "  #", "  #", "  #", "  #", "  #", "  #", "  #", "  #", "  #" },
                               { "  #", "  #", "  #", "  #", "  #", "  #", "  #", "  #", "  #", "  #" },
                               { " #", "  #", "  #", "  #", "  #", "  #", "  #", "  #", "  #", "  #" }
};

//The playingfield that the user uses to attack
string[,] Playingfielduserattack = { { "  #", "  #", "  #", "  #", "  #", "  #", "  #", "  #", "  #", "  #" },
                               { "  #", "  #", "  #", "  #", "  #", "  #", "  #", "  #", "  #", "  #" },
                               { "  #", "  #", "  #", "  #", "  #", "  #", "  #", "  #", "  #", "  #" },
                               { "  #", "  #", "  #", "  #", "  #", "  #", "  #", "  #", "  #", "  #" },
                               { "  #", "  #", "  #", "  #", "  #", "  #", "  #", "  #", "  #", "  #" },
                               { "  #", "  #", "  #", "  #", "  #", "  #", "  #", "  #", "  #", "  #" },
                               { "  #", "  #", "  #", "  #", "  #", "  #", "  #", "  #", "  #", "  #" },
                               { "  #", "  #", "  #", "  #", "  #", "  #", "  #", "  #", "  #", "  #" },
                               { "  #", "  #", "  #", "  #", "  #", "  #", "  #", "  #", "  #", "  #" },
                               { " #", "  #", "  #", "  #", "  #", "  #", "  #", "  #", "  #", "  #" }
};

//Computers attack playingfield
string[,] PlayingfieldCompAttack = {    
    { "  #", "  #", "  #", "  #", "  #", "  #", "  #", "  #", "  #", "  #" },
    { "  #", "  #", "  #", "  #", "  #", "  #", "  #", "  #", "  #", "  #" },
    { "  #", "  #", "  #", "  #", "  #", "  #", "  #", "  #", "  #", "  #" },
    { "  #", "  #", "  #", "  #", "  #", "  #", "  #", "  #", "  #", "  #" },
    { "  #", "  #", "  #", "  #", "  #", "  #", "  #", "  #", "  #", "  #" },
    { "  #", "  #", "  #", "  #", "  #", "  #", "  #", "  #", "  #", "  #" },
    { "  #", "  #", "  #", "  #", "  #", "  #", "  #", "  #", "  #", "  #" },
    { "  #", "  #", "  #", "  #", "  #", "  #", "  #", "  #", "  #", "  #" },
    { "  #", "  #", "  #", "  #", "  #", "  #", "  #", "  #", "  #", "  #" },
    { "  #", "  #", "  #", "  #", "  #", "  #", "  #", "  #", "  #", "  #" }
    };


//arrays for the numbers that are forbidden
int[] forbiddenNumbersY = { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1 };
int[] forbiddenNumbersX = { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1 };

for (int a = 0; a < 10; a++)
{
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
        Console.WriteLine("Invalid input, please enter a valid number.");
        Thread.Sleep(3000);
        Console.Clear();
        a--;
        continue;
    }
    Ycord--;

    //Checks if they are valid
    if(Ycord < 0 || Ycord >= 10)
    {
        Console.WriteLine("Invalid cordinates");
        Thread.Sleep(3000);
        a--;
        Console.Clear();
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
        Console.WriteLine("Invalid input, please enter a valid number.");
        Thread.Sleep(3000);
        Console.Clear();
        a--;
        continue;
    }
    Xcord--;

    if (Xcord < 0 || Xcord >= 10)
    {
        Console.WriteLine("Invalid cordinates");
        Thread.Sleep(3000);
        a--;
        Console.Clear();
        continue;
    }

    // Check if the coordinates are already forbidden
    
    for (int g = 0; g < 10; g++)
    {
        if (Ycord == forbiddenNumbersY[g] && Xcord == forbiddenNumbersX[g])
        {
            Console.WriteLine("There is already a ship in this spot");
            Thread.Sleep(3000);
            a--;
            break;
        }
    }

   

    // Place the ship and mark the coordinates as forbidden
    PlayingfieldUser[Ycord, Xcord] = "  O";

    forbiddenNumbersY[a] = Ycord;
    forbiddenNumbersX[a] = Xcord;

    Console.Clear();
    Console.WriteLine("Next ship");
    Console.WriteLine(" ");
}

Console.Clear();

Console.WriteLine("    1   2   3   4   5   6   7   8   9   10");

//Writes the playingfield to the user after thay are finished choosing
for (int i = 0; i < 10; i++)
{
    Console.Write((i + 1) + " ");

    for (int o = 0; o < 10; o++)
    {
        Console.Write(PlayingfieldUser[i, o] + " ");
    }

    Console.WriteLine();
}




Random random = new Random();

//The forbidden numbers for when the computer is choosing
int[] forbiddenNumbersYcomp = { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1 };
int[] forbiddenNumbersXcomp = { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1 };


for (int a = 0; a < 10; a++)
{

    //takes random ship cords
    int Ycordcomp = random.Next(1, 11);
    Ycordcomp--;


    int Xcordcomp = random.Next(1, 11);
    Xcordcomp--;

    // Check if the coordinates are already forbidden
    bool isForbiddencomp = false;
    for (int g = 0; g < 10; g++)
    {
        if (Ycordcomp == forbiddenNumbersYcomp[g] && Xcordcomp == forbiddenNumbersXcomp[g])
        {
            isForbiddencomp = true;
            break;
        }
    }

    // If forbidden, computer choose again
    if (isForbiddencomp)
    {
        a--; // Decrement `a` to retry this iteration

        continue; // Restart the loop
    }

    // Place the ship and mark the coordinates as forbidden
    Playingfieldcomputer[Ycordcomp, Xcordcomp] = "  O";

    forbiddenNumbersYcomp[a] = Ycordcomp;
    forbiddenNumbersXcomp[a] = Xcordcomp;

}



//Writes the attack playingfield
WriteField(Playingfielduserattack);

bool cont = true;
int hit = 0;
int compHit = 0;

while (cont)
{
    Console.Clear();

    WriteField(PlayingfieldUser);

    WriteField(Playingfielduserattack);

    //Asks the user for attack cords and checks if they are valid
    Console.WriteLine("where do you want to attack?");
    Console.WriteLine("Y-cordinate");

    int attackY;
    if (int.TryParse(Console.ReadLine(), out attackY))
    {
        // Successfully parsed the input
    }
    else
    {
        // Handle invalid input
        Console.WriteLine("Invalid input, please enter a valid number.");
        Thread.Sleep(3000);
        continue;
    }

    attackY--;

    if(attackY <= -1 || attackY >= 11)
    {
        Console.WriteLine("Invalid cordinates");
        Thread.Sleep(3000);
        continue;
    }

    //Clears and writes everything again
    Console.Clear();

    Console.WriteLine(" ");
    WriteField(PlayingfieldUser);

    WriteField(Playingfielduserattack);

    //asks for x cords and saves. then checks if they are invalid.
    Console.WriteLine("X-cordinate");

    int attackX;
    if (int.TryParse(Console.ReadLine(), out attackX))
    {
        // Successfully parsed the input
    }
    else
    {
        // Handle invalid input
        Console.WriteLine("Invalid input, please enter a valid number.");
        Thread.Sleep(3000);
        continue;
    }

    attackX--;

    if (attackX <= -1 || attackX >= 11)
    {
        Console.WriteLine("Invalid cordinates");
        Thread.Sleep(3000);
        continue;
    }

    if (Playingfielduserattack[attackX, attackY] == "  X" || Playingfielduserattack[attackX, attackY] == "  O" )
    {
        Console.WriteLine("You have already attacked that spot.");
        Thread.Sleep(3000);
        continue;
    }

    //Clears everything and writes it again
    Console.Clear();
    

    Console.WriteLine(" ");
    WriteField(PlayingfieldUser);

    WriteField(Playingfielduserattack);


    //Checks if you hit and marks it in the users attack playingfield
    if (Playingfieldcomputer[attackY, attackX] == "  O")
    {
      
        Playingfielduserattack[attackY, attackX] = "  O";
        hit++;

        Console.WriteLine("HIT!");
        Console.WriteLine(" ");
        Thread.Sleep(3000);
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
        Thread.Sleep(3000);
        PlayingfieldUser[compAttackCordY2, compAttackCordX2] = "  X";
        compHit++;
    }
    else
    {
        Console.WriteLine("Computer missed.");
        Thread.Sleep(2000);
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

void WriteField(string[,] field)
{
    Console.WriteLine(" ");
    Console.WriteLine("    1   2   3   4   5   6   7   8   9   10");

    for (int i = 0; i < 10; i++)
    {
        Console.Write((i + 1) + " ");

        for (int o = 0; o < 10; o++)
        {
            Console.Write(field[i, o] + " ");
        }

        Console.WriteLine();
    }
}
