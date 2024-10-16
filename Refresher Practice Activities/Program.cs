//Create a text-based game that has multiple endings and bad punishments

using System.Security.Cryptography.X509Certificates;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

public class Game
{
    static bool skipRequested = false;
    static void Characters()
    {

        while (true)
        {
            Console.WriteLine("Choose your Character");
            Console.WriteLine("1->Barbarian<-");
            Console.WriteLine("2->Knight<-");
            Console.WriteLine("3->Archer<-");
            Console.WriteLine("4->Mage<-");
            Console.WriteLine("5->Back to main menu<-");

            string choice2 = "";
            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                switch (choice)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Are you sure you want to choose Barbarian?");
                        Console.WriteLine("Health: 200; Damage:20-30");
                        Console.WriteLine("Press 1 if = yes\n");
                        Console.WriteLine("Press 2 if = no\n");
                         // Read the user input as a string
                         choice2 = Console.ReadLine();
                        if (choice2 == "1")  // Check if they pressed 1 for yes
                        {
                            gameplayBarb();
                        }
                        else if (choice2 == "2")  // Check if they pressed 2 for no
                        {
                            Characters();  // Return to character selection
                        }
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("\nAre you sure you want to choose Knight?");
                        Console.WriteLine("Health: 180; Damage:18-28");
                        Console.WriteLine("Press 1 if ->yes<-\n");
                        Console.WriteLine("Press 2 if ->no<-\n");
                        choice2 = Console.ReadLine();
                        if (choice2 == "1")
                        {
                            gameplayknight();
                        }
                        else if (choice2 == "2")
                        {
                            Characters();
                        }

                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("\nAre you sure you want to choose Archer?");
                        Console.WriteLine("Health: 200; Damage:20-30");
                        Console.WriteLine("Press 1 if ->yes<-\n");
                        Console.WriteLine("Press 2 if ->no<-\n");
                        choice2 = Console.ReadLine();
                        if (choice2 == "1")
                        {
                            gameplayArcher();
                        }
                        else if (choice2 == "2")
                        {
                            Characters();
                        }
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("\nAre you sure you want to choose Mage?");
                        Console.WriteLine("Press 1 if ->yes<-\n");
                        Console.WriteLine("Press 2 if ->no<-\n");
                        choice2 = Console.ReadLine();
                        if (choice2 == "1")
                        {
                             gameplayMage();
                        }
                        else if (choice2 == "2")
                        {
                            Characters();
                        }
                        break;
                    case 5:
                        Console.Clear();
                        MainMenu();
                        break;

                }
            }
            else {
                Console.WriteLine("Invalid inpute, try again!");
                    }

            
        }
    }



    static void Introdcution()
    {
        int choice = 1;
        Console.Clear();
        string message1 = "Long ago there lived 4 kingdoms in the place called Sonaria. the 4 kingdoms are, Hunnic the kingdom of barbarians, Durmstrang the kingdom of mages , Edhellond the kingdom of elves, and The Valors the kingdom of knights." +
            "A Demon that has been lurking in the abbyss have been released by a witch who was desperate for chaos and wants to unleash a war against the 4 kingdoms. " +
            "The 4 kingdoms have no choice but to unite together despite their differences in order to stop the demon from destroying Sonaria. Thus, the journey begins... ";
             
        int screenWidth = Console.WindowWidth;
        int screenHeight = Console.WindowHeight;

        int x = Math.Max(0, Math.Min(screenWidth - message1.Length / 2, Console.BufferWidth - 1));
        int y = Math.Max(0, Math.Min(screenHeight / 2, Console.BufferHeight - 1));


        Console.SetCursorPosition(x, y);

        Thread inputThread = new Thread(HandleSkipInput);
        inputThread.Start();
        foreach (char c in message1)
        {
            if (skipRequested)
            {
                Console.Write(message1.Substring(message1.IndexOf(c)));
                break;
            }

            Console.Write(c);
            Thread.Sleep(30); // Adjust the delay to control typing speed

            if (choice == 1)
            {
                Thread.Sleep(5);
            }
        }

        Console.SetCursorPosition(0, screenHeight - 1);
        Console.WriteLine();
        Thread.Sleep(2000); // Display the message for 2 seconds


        skipRequested = true; // Signal the input thread to end
        inputThread.Join();    // Wait for the input thread to finish

        Console.SetCursorPosition(0, screenHeight - 1);
        Console.WriteLine();
        Thread.Sleep(1000); // Display the message for 2 seconds
    }

    static void HandleSkipInput()
    {
        while (!skipRequested)
        {
            if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Spacebar)
            {
                skipRequested = true; // Set skip flag if the spacebar is pressed
            }
            Thread.Sleep(100); // Check for input every 100 milliseconds
        }
    }

    static void MainMenu()
    {
        Console.WriteLine("Welcome To Dungeon Quest Text Game!");
        Console.WriteLine(" 1->Play<-");
        Console.WriteLine(" 2->Exit<-");

        if (int.TryParse(Console.ReadLine(), out int choice))
        {
            switch (choice)
            {
                case 1:
                    Console.Clear();
                    Introdcution();
                    Characters();
                    break;
                case 2:
                    Environment.Exit(0);
                    break;
            }
        }
    }

    static void LoadingScreen(string message)
    {
        Console.Clear();

        int screenWidth = Console.WindowWidth;
        int screenHeight = Console.WindowHeight;

        int x = (screenWidth - message.Length) / 2;
        int y = screenHeight / 2;

        Console.SetCursorPosition(x, y);

        foreach (char c in message)
        {
            Console.Write(c);
            Thread.Sleep(70); // Adjust the delay to control typing speed
        }

        Console.SetCursorPosition(0, screenHeight - 1);
        Console.WriteLine();
        Thread.Sleep(2000); // Display the message for 2 seconds
    }

    static void gameplayBarb()
    {
        
        Console.Clear();
        string message2 = "As the council finished giving you a quest, you departed from Sonaria and your journey began. You are now in a forest, and as you walk in the forest, you heard a rustle in the bush" +
            "Would you like to check it out? \n\n Select 1 if You wish to proceed. Select 2 to ignore\n";


        int screenWidth = Console.WindowWidth;
        int screenHeight = Console.WindowHeight;

        int x = Math.Max(0, Math.Min(screenWidth - message2.Length / 2, Console.BufferWidth - 1));
        int y = Math.Max(0, Math.Min(screenHeight / 2, Console.BufferHeight - 1));


        Console.SetCursorPosition(x, y);

        foreach (char c in message2)
        {
            Console.Write(c);
            Thread.Sleep(30); // Adjust the delay to control typing speed
        }

        Console.SetCursorPosition(0, screenHeight - 1);
        Console.WriteLine();
        Thread.Sleep(4000); // Display the message for 4 seconds

        Console.SetCursorPosition(0, screenHeight - 1);

        Game game = new Game();

        
        if (int.TryParse(Console.ReadLine(), out int choice1))
        {
            switch (choice1)
            {
                case 1:
                    Console.Clear();
                    Lvl1barb();
                    break;
                case 2:
                    Environment.Exit(0);
                    break;
            }
        }

 

 

        
    }


    static void gameplayknight()
    {

        Console.Clear();
        string message2 = "As the council finished giving you a quest, you departed from Sonaria and your journey began. You are now in a forest, and as you walk in the forest, you heard a rustle in the bush" +
            "Would you like to check it out? \n\n Select 1 if You wish to proceed. Select 2 to ignore\n";


        int screenWidth = Console.WindowWidth;
        int screenHeight = Console.WindowHeight;

        int x = Math.Max(0, Math.Min(screenWidth - message2.Length / 2, Console.BufferWidth - 1));
        int y = Math.Max(0, Math.Min(screenHeight / 2, Console.BufferHeight - 1));


        Console.SetCursorPosition(x, y);

        foreach (char c in message2)
        {
            Console.Write(c);
            Thread.Sleep(30); // Adjust the delay to control typing speed
        }

        Console.SetCursorPosition(0, screenHeight - 1);
        Console.WriteLine();
        Thread.Sleep(4000); // Display the message for 4 seconds

        Console.SetCursorPosition(0, screenHeight - 1);

        Game game = new Game();


        if (int.TryParse(Console.ReadLine(), out int choice1))
        {
            switch (choice1)
            {
                case 1:
                    Console.Clear();
                    Lvl1knight();
                    break;
                case 2:
                    Environment.Exit(0);
                    break;
            }
        }






    }

    static void gameplayArcher()
    {

        Console.Clear();
        string message2 = "As the council finished giving you a quest, you departed from Sonaria and your journey began. You are now in a forest, and as you walk in the forest, you heard a rustle in the bush" +
            "Would you like to check it out? \n\n Select 1 if You wish to proceed. Select 2 to ignore\n";


        int screenWidth = Console.WindowWidth;
        int screenHeight = Console.WindowHeight;

        int x = Math.Max(0, Math.Min(screenWidth - message2.Length / 2, Console.BufferWidth - 1));
        int y = Math.Max(0, Math.Min(screenHeight / 2, Console.BufferHeight - 1));


        Console.SetCursorPosition(x, y);

        foreach (char c in message2)
        {
            Console.Write(c);
            Thread.Sleep(30); // Adjust the delay to control typing speed
        }

        Console.SetCursorPosition(0, screenHeight - 1);
        Console.WriteLine();
        Thread.Sleep(4000); // Display the message for 4 seconds

        Console.SetCursorPosition(0, screenHeight - 1);

        Game game = new Game();


        if (int.TryParse(Console.ReadLine(), out int choice1))
        {
            switch (choice1)
            {
                case 1:
                    Console.Clear();
                    Lvl1archer();
                    break;
                case 2:
                    Environment.Exit(0);
                    break;
            }
        }






    }

    static void gameplayMage()
    {

        Console.Clear();
        string message2 = "As the council finished giving you a quest, you departed from Sonaria and your journey began. You are now in a forest, and as you walk in the forest, you heard a rustle in the bush" +
            "Would you like to check it out? \n\n Select 1 if You wish to proceed. Select 2 to ignore\n";


        int screenWidth = Console.WindowWidth;
        int screenHeight = Console.WindowHeight;

        int x = Math.Max(0, Math.Min(screenWidth - message2.Length / 2, Console.BufferWidth - 1));
        int y = Math.Max(0, Math.Min(screenHeight / 2, Console.BufferHeight - 1));


        Console.SetCursorPosition(x, y);

        foreach (char c in message2)
        {
            Console.Write(c);
            Thread.Sleep(30); // Adjust the delay to control typing speed
        }

        Console.SetCursorPosition(0, screenHeight - 1);
        Console.WriteLine();
        Thread.Sleep(4000); // Display the message for 4 seconds

        Console.SetCursorPosition(0, screenHeight - 1);

        Game game = new Game();


        if (int.TryParse(Console.ReadLine(), out int choice1))
        {
            switch (choice1)
            {
                case 1:
                    Console.Clear();
                    Lvl1mage();
                    break;
                case 2:
                    Environment.Exit(0);
                    break;
            }
        }






    }


    static void Lvl1barb()
    {
        Console.WriteLine("You found a GOBLIN! with 20 hp and a small dagger that deals 20 damage! What do you do?");
        Console.WriteLine("->1<- Fight, your battle axe deals 100 damage");
        Console.WriteLine("->2<- Runaway");

        string fight = "";
        fight = Console.ReadLine();
        if (fight == "1")
        {
            Console.WriteLine("You raised your battle axe and splitted the goblin in two leaving him in two pieces in the ground and died\n");
            Lvl2barb();
        }
        else if (fight == "2")
        {
            Console.WriteLine("You continued walking on your path but raised your alertness for danger\n");
        }
    }

    static void Lvl1knight()
    {
        Console.WriteLine("You found a GOBLIN! with 20 hp and a small dagger that deals 20 damage! What do you do?");
        Console.WriteLine("->1<- Fight, your sword deals 30 damage");
        Console.WriteLine("->2<- Runaway");

        string fight = "";
        fight = Console.ReadLine();
        if (fight == "1")
        {
            Console.WriteLine("You raise your sword and slashed the goblin leaving him bleeding in the ground and died\n");
            Lvl2knight();
        }
        else if (fight == "2")
        {
            Console.WriteLine("You continued walking on your path but raised your alertness for danger\n");
        }
    }

    static void Lvl1archer()
    {
        Console.WriteLine("You found a GOBLIN! with 20 hp and a small dagger that deals 20 damage! What do you do?");
        Console.WriteLine("->1<- Fight, your bow deals 30 damage");
        Console.WriteLine("->2<- Runaway");

        string fight = "";
        fight = Console.ReadLine();
        if (fight == "1")
        {
            Console.WriteLine("You raise your bow at the goblin leaving him bleeding in the ground pierced with arrows and died\n");
            Lvl2archer();
        }
        else if (fight == "2")
        {
            Console.WriteLine("You continued walking on your path but raised your alertness for danger\n");
        }
    }

    static void Lvl1mage()
    {
        Console.WriteLine("You found a GOBLIN! with 20 hp and a small dagger that deals 20 damage! What do you do?");
        Console.WriteLine("->1<- Fight, your magic deals 10 damage");
        Console.WriteLine("->2<- Runaway");

        string fight = "";
        fight = Console.ReadLine();
        if (fight == "1")
        {
            Console.WriteLine("You raise your staff and burst the goblin, obliterating him to dust\n");
            Lvl2mage();
        }
        else if (fight == "2")
        {
            Console.WriteLine("You continued walking on your path but raised your alertness for danger\n");
        }
    }
    static void Lvl2barb()
    {
        string artifact = "As you finished slaying the Goblin, you found an artifact that increased your stats " +
            "A crude amulet fashioned from the fragmented bones of a long-dead troll, crudely held together by strips of worn leather and rusted wire." +
            " The trinket pulses with a faint green glow, emanating a primal power that surges through its wearer." +
            " Though small in size, it holds the remnants of the troll's monstrous strength, granting a temporary but significant boost to physical power. " +
            "The wearer feels an unrelenting urge to crush and conquer, but beware—the trinket’s savage magic can overwhelm those unworthy of its might, feeding on their own strength if used recklessly.\n" +
            "Do you want to equip it?(1) or store it?(2)";

        int screenWidth = Console.WindowWidth;
        int screenHeight = Console.WindowHeight;

        int x = Math.Max(0, Math.Min(screenWidth - artifact.Length / 2, Console.BufferWidth - 1));
        int y = Math.Max(0, Math.Min(screenHeight / 2, Console.BufferHeight - 1));


        Console.SetCursorPosition(x, y);

        foreach (char c in artifact)
        {
            Console.Write(c);
            Thread.Sleep(20); // Adjust the delay to control typing speed
        }

        Console.SetCursorPosition(0, screenHeight - 1);
        Console.WriteLine();
        Thread.Sleep(4000); // Display the message for 4 seconds

        Continuation contine = new Continuation();

       


      
        if (int.TryParse(Console.ReadLine(), out int choice1))
        {
            switch (choice1)
            {
                case 1:
                    Console.WriteLine("Your strength has increased! You deal 30+ damage but lost 30 health. As your strenght increases, your aura has been increased attracting stronger monsters. Just as you were about to take your first step, the ground rumbled and it's coming\" +\r\n\"in your direction! \n Hide(1) Face it like a man(2)\n");
                    string choice2 = Console.ReadLine();
                    if (choice2 == "1")
                    {
                        Console.WriteLine("You hid in a bush! The enemy seems to be strong-one eyed giant! A CYCLOPS. But while you stayed hidden, the cyclops detected your presence and was too strong for you" +
                            "The Cyclops was in fact the 2nd in command for the witch! The Cyclops attacked you and you fainted! The Cyclops want you alive because you possessed an artifact" +
                            "that can make the demon stronger!\n");
                        finallvl();
                    }
                    else if (choice2 == "2")
                    {
                        Console.WriteLine("You faced the enemy! with your new strenght and here it comes! The enemy seems to be strong-one eyed giant! A CYCLOPS with 400 health! deals 170 damage with his giant club!");
                        finallvl();
                    }
                    break;
                case 2:
                    Console.WriteLine("You stored the item in your inventory!");
                    break;
            }
        }


    }




    static void Lvl2mage()
    {
        string artifact = "As you finished slaying the Goblin, you found an artifact that increased your stats " +
            "Crystal of Cunning Sparks, A small, cracked crystal that hums with erratic energy. Goblins who wield this relic gain a sharp boost to their spellcasting abilities, " +
            "enabling them to cast spells quicker and with greater destructive force. " +
            "The artifact channels chaotic magic, but is unstable." +
            "Do you want to equip it?(1) or store it?(2)";

        int screenWidth = Console.WindowWidth;
        int screenHeight = Console.WindowHeight;

        int x = Math.Max(0, Math.Min(screenWidth - artifact.Length / 2, Console.BufferWidth - 1));
        int y = Math.Max(0, Math.Min(screenHeight / 2, Console.BufferHeight - 1));


        Console.SetCursorPosition(x, y);

        foreach (char c in artifact)
        {
            Console.Write(c);
            Thread.Sleep(20); // Adjust the delay to control typing speed
        }

        Console.SetCursorPosition(0, screenHeight - 1);
        Console.WriteLine();
        Thread.Sleep(4000); // Display the message for 4 seconds

        Continuation contine = new Continuation();





        if (int.TryParse(Console.ReadLine(), out int choice1))
        {
            switch (choice1)
            {
                case 1:
                    Console.WriteLine("Your strength has increased! You deal 30+ damage but lost 30 health. As your strenght increases, your aura has been increased attracting stronger monsters. Just as you were about to take your first step, the ground rumbled and it's coming\" +\r\n\"in your direction! \n Hide(1) Face it like a man(2)\n");
                    string choice2 = Console.ReadLine();
                    if (choice2 == "1")
                    {
                        Console.WriteLine("You hid in a bush! The enemy seems to be strong-one eyed giant! A CYCLOPS. But while you stayed hidden, the cyclops detected your presence and was too strong for you" +
                            "The Cyclops was in fact the 2nd in command for the witch! The Cyclops attacked you and you fainted! The Cyclops want you alive because you possessed an artifact" +
                            "that can make the demon stronger!\n");
                        finallvl();
                    }
                    else if (choice2 == "2")
                    {
                        Console.WriteLine("You faced the enemy! with your new strenght and here it comes! The enemy seems to be strong-one eyed giant! A CYCLOPS with 400 health! deals 170 damage with his giant club!");
                        finallvl();
                    }
                    break;
                case 2:
                    Console.WriteLine("You stored the item in your inventory!");
                    break;
            }
        }


    }


    static void Lvl2knight()
    {
        string artifact = "As you finished slaying the Goblin, you found an artifact that increased your stats " +
            "Shard of Iron Will, This jagged, rusted charm glows with a faint green hue. When worn, it enhances the goblin's toughness, increasing physical strength and resilience in battle. " +
            "The user feels an unnatural fortitude course through their body, allowing them to endure heavy blows." +
            "Do you want to equip it?(1) or store it?(2)";

        int screenWidth = Console.WindowWidth;
        int screenHeight = Console.WindowHeight;

        int x = Math.Max(0, Math.Min(screenWidth - artifact.Length / 2, Console.BufferWidth - 1));
        int y = Math.Max(0, Math.Min(screenHeight / 2, Console.BufferHeight - 1));


        Console.SetCursorPosition(x, y);

        foreach (char c in artifact)
        {
            Console.Write(c);
            Thread.Sleep(20); // Adjust the delay to control typing speed
        }

        Console.SetCursorPosition(0, screenHeight - 1);
        Console.WriteLine();
        Thread.Sleep(4000); // Display the message for 4 seconds

        Continuation contine = new Continuation();





        if (int.TryParse(Console.ReadLine(), out int choice1))
        {
            switch (choice1)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("Your strength has increased! You deal 30+ damage but lost 30 health. As your strenght increases, your aura has been increased attracting stronger monsters." +
                        " Just as you were about to take your first step, the ground rumbled and it's coming\" +\r\n\"in your direction! \n Hide(1) Face it like a man(2)\n");
                    string choice2 = Console.ReadLine();
                    if (choice2 == "1")
                    {
                        Console.WriteLine("You hid in a bush! The enemy seems to be strong-one eyed giant! A CYCLOPS. But while you stayed hidden, the cyclops detected your presence and was too strong for you" +
                            "The Cyclops was in fact the 2nd in command for the witch! The Cyclops attacked you and you fainted! The Cyclops want you alive because you possessed an artifact" +
                            "that can make the demon stronger!\n");
                        finallvl();
                    }
                    else if (choice2 == "2")
                    {
                        Console.WriteLine("You faced the enemy! with your new strenght and here it comes! The enemy seems to be strong-one eyed giant! A CYCLOPS with 400 health! deals 170 damage with his giant club!");
                        finallvl();
                    }
                    break;
                case 2:
                    Console.WriteLine("You stored the item in your inventory!");
                    break;
            }
        }


    }

    static void Lvl2archer()
    {
        string artifact = "As you finished slaying the Goblin, you found an artifact that increased your stats " +
            "Whispering Wind Feather, A delicate feather etched with faint runes. When attached to a bow or worn as a talisman, it grants goblins enhanced agility and precision. " +
            "Their arrows fly truer, and their movements become swift, allowing them to evade enemies and strike from the shadows." +
            "Do you want to equip it?(1) or store it?(2)";

        int screenWidth = Console.WindowWidth;
        int screenHeight = Console.WindowHeight;

        int x = Math.Max(0, Math.Min(screenWidth - artifact.Length / 2, Console.BufferWidth - 1));
        int y = Math.Max(0, Math.Min(screenHeight / 2, Console.BufferHeight - 1));


        Console.SetCursorPosition(x, y);

        foreach (char c in artifact)
        {
            Console.Write(c);
            Thread.Sleep(20); // Adjust the delay to control typing speed
        }

        Console.SetCursorPosition(0, screenHeight - 1);
        Console.WriteLine();
        Thread.Sleep(4000); // Display the message for 4 seconds

        Continuation contine = new Continuation();





        if (int.TryParse(Console.ReadLine(), out int choice1))
        {
            switch (choice1)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("Your strength has increased! You deal 30+ damage but lost 30 health. As your strenght increases, your aura has been increased attracting stronger monsters. Just as you were about to take your first step, the ground rumbled and it's coming\n in your direction! \n Hide(1) Face it like a man(2)\n");
                    string choice2 = Console.ReadLine();
                    if (choice2 == "1")
                    {
                        Console.WriteLine("You hid in a bush! The enemy seems to be strong-one eyed giant! A CYCLOPS!  But while you stayed hidden, the cyclops detected your presence and was too strong for you\" +\r\n                            \"The Cyclops was in fact the 2nd in command for the witch! The Cyclops attacked you and you fainted! The Cyclops want you alive because you possessed an artifact\" +\r\n                            \"that can make the demon stronger!\\n\n");
                        finallvl();
                    }
                    else if (choice2 == "2")
                    {
                        Console.WriteLine("You faced the enemy! with your new strenght and here it comes! The enemy seems to be strong-one eyed giant! A CYCLOPS with 400 health! deals 170 damage with his giant club!");
                        finallvl();
                    }
                    break;
                case 2:
                    Console.WriteLine("You stored the item in your inventory!");
                    break;
            }
        }


    }


    static void FinalLevelscene()
    {
        string final = "You awaken in a dimly lit chamber, bound by glowing magical chains. You realize you're deep in the witch’s lair. " +
            "The air is thick with dark energy, and you can hear distant whispers echoing through the room. " +
            "The artifact lies on the floor nearby, humming with power.";

        int screenWidth = Console.WindowWidth;
        int screenHeight = Console.WindowHeight;

        int x = Math.Max(0, Math.Min(screenWidth - final.Length / 2, Console.BufferWidth - 1));
        int y = Math.Max(0, Math.Min(screenHeight / 2, Console.BufferHeight - 1));


        Console.SetCursorPosition(x, y);

        foreach (char c in final)
        {
            Console.Write(c);
            Thread.Sleep(20); // Adjust the delay to control typing speed
        }

        Console.SetCursorPosition(0, screenHeight - 1);
        Console.WriteLine();
        Thread.Sleep(4000); // Display the message for 4 seconds
    }




    static void finallvl()
    {
        FinalLevelscene();
        string choices = "[Look for a way to escape]\r\n(You examine your surroundings, hoping to find something useful.) (1) or [Attempt to break free from the chains]\r\n(You summon your strength or consider using the artifact's power to break free.)";
        int screenWidth = Console.WindowWidth;
        int screenHeight = Console.WindowHeight;

        int x = (screenWidth - choices.Length) / 2;
        int y = screenHeight / 2;

        Console.SetCursorPosition(x, y);

        foreach (char c in choices)
        {
            Console.Write(c);
            Thread.Sleep(40); // Adjust the delay to control typing speed
        }

        Console.SetCursorPosition(0, screenHeight - 1);
        Console.WriteLine();
        Thread.Sleep(3000); // Display the message for 6 seconds

        if (int.TryParse(Console.ReadLine(), out int choice1))
        {
            switch (choice1)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("(1)[Investigate the glowing rune]" +
                        "(2)Investigate the mirror]\r\n");
                    string choice2 = Console.ReadLine();

                    if (choice2 == "1")
                    {
                        Console.WriteLine("\n(You approach the glowing rune on the floor. It pulses with ancient power, and you can feel its energy humming beneath your feet. " +
                            "The rune seems tied to the magic binding you, but tampering with it could be dangerous.(1)[Attempt to disrupt the rune’s magic] or (2)[Absorb the rune’s power]");
                        string choice4 = Console.ReadLine();
                        if (choice4 == "1")
                        {
                            Console.WriteLine("(You focus on the rune, trying to weaken or break its hold on you.)\r\n\r\n");
                            finalbattle();
                        }else if(choice4 == "2")
                        {
                            Console.WriteLine("(You try to tap into the rune’s energy, hoping to use its power for your own escape.)\r\n\r\n");
                            finalbattle();
                        }
                    }else if (choice2 == "2")
                    {
                        Console.WriteLine("\nYou wipe away the dust from the old mirror. As your reflection becomes clear, you notice something odd—your image flickers, and the reflection shows a version of you without chains, " +
                            "standing free. The mirror is clearly enchanted, but its purpose is unclear.\n (1)[Step into the mirror] or (2)[Break the mirror]");
                        string choice5 = Console.ReadLine();
                        if(choice5 == "1")
                        {
                            Console.WriteLine("(You reach out, tempted to cross into the reflection, hoping it will release you from your chains.)");
                            finalbattle();
                        }else if (choice5 == "2")
                        {
                            Console.WriteLine("(You raise your hand, ready to shatter the mirror and see what happens if you destroy its enchantment.)");
                            finalbattle();
                        }
                    }
                    break;
                case 2:
                    Console.WriteLine("(1)[Use brute force]\n(2)[Use the artifact’s power]\r\n");
                    string choices3 = Console.ReadLine();  

                   if (choices3 == "1")
                    {
                        Console.WriteLine("(Try to shatter the chains with raw strength.)");
                        finalbattle();
                    }else if (choices3 == "2")
                    {
                        Console.WriteLine("(Channel the artifact’s power to disrupt the magic binding you.)\r\n\r\n");
                        finalbattle();
                    }
                    break;
            }
        }

    }




    static void finalbattle()
    {
         string final = "The air grows colder as you step into the heart of the lair, a vast, shadowy chamber." +
            " The walls are adorned with arcane symbols that pulse with a sickly green light. At the center, you see her— the witch —sitting upon a throne of twisted roots and bones." +
            " Her eyes glow with malice, and a twisted smile curls across her face.\r\n\r\n\"Ah, so you’ve survived my Cyclops.\" Her voice drips with venom. " +
            "\"I expected you to be more broken, but no matter. You’ve brought the artifact, and now, I will take what is mine.\"\r\n\r\nHer hand stretches out toward the artifact in your possession, " +
            "and the power radiating from it seems to respond to her command. The ground beneath you trembles as dark energy swirls around the chamber.\r\n\r\nYou can feel the weight of the artifact, " +
            "the dark power within it calling to you, tempting you to use it. But you know what’s at stake—this is your moment to act. \n[Destroy the artifact](1) or [Accept the witch’s offer](2)";

        int screenWidth = Console.WindowWidth;
        int screenHeight = Console.WindowHeight;

        int x = Math.Max(0, Math.Min(screenWidth - final.Length / 2, Console.BufferWidth - 1));
        int y = Math.Max(0, Math.Min(screenHeight / 2, Console.BufferHeight - 1));


        Console.SetCursorPosition(x, y);

        foreach (char c in final)
        {
            Console.Write(c);
            Thread.Sleep(20); // Adjust the delay to control typing speed
        }

        Console.SetCursorPosition(0, screenHeight - 1);
        Console.WriteLine();
        Thread.Sleep(4000); // Display the message for 4 seconds


        if (int.TryParse(Console.ReadLine(), out int choice1))
        {
            switch (choice1)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("(You raise the artifact high, preparing to destroy it and weaken the witch forever.)");
                    goodend();

                    break;
                case 2:
                    Console.WriteLine("(You lower the artifact, tempted by the witch’s power and promises of greatness.)");
                   badend();
                    break;
            }
        }

    }

    static void goodend()
    {
        string good = "With a decisive swing, you slam the artifact against the ground. A brilliant flash of light erupts as the artifact shatters, " +
            "releasing a torrent of energy. The witch screams in agony as the dark magic that binds her begins to unravel." +
            " Her body crumbles to dust, and the chamber starts to collapse. You rush toward the exit as the lair crumbles behind you, " +
            "leaving the witch’s reign of terror buried forever.\r\n\r\n";
        int screenWidth = Console.WindowWidth;
        int screenHeight = Console.WindowHeight;

        int x = (screenWidth - good.Length) / 2;
        int y = screenHeight / 2;

        Console.SetCursorPosition(x, y);

        foreach (char c in good)
        {
            Console.Write(c);
            Thread.Sleep(40); // Adjust the delay to control typing speed
        }

        Console.SetCursorPosition(0, screenHeight - 1);
        Console.WriteLine();
        Thread.Sleep(3000); // Display the message for 6 seconds
    }


    static void badend()
    {
        string bad = "The dark magic swirls around you as you step toward the witch, lowering the artifact." +
            " Her smile broadens as she rises from her throne, placing a cold hand on your shoulder." +
            " Instantly, the power of the artifact floods into both of you, binding your fate to hers.\r\n\r\n\"Wise choice, my new apprentice,\" she whispers, " +
            "her voice like a dagger in the dark.\r\n\r\nBut as the power merges, you feel your will slipping away, consumed by the artifact’s darkness. " +
            "You’ve gained immense strength, but at the cost of your soul. The witch now controls both the artifact and you, and together, " +
            "you plunge the world into an age of darkness and tyranny.\r\n\r\n";
        int screenWidth = Console.WindowWidth;
        int screenHeight = Console.WindowHeight;

        int x = (screenWidth - bad.Length) / 2;
        int y = screenHeight / 2;

        Console.SetCursorPosition(x, y);

        foreach (char c in bad)
        {
            Console.Write(c);
            Thread.Sleep(40); // Adjust the delay to control typing speed
        }

        Console.SetCursorPosition(0, screenHeight - 1);
        Console.WriteLine();
        Thread.Sleep(3000); // Display the message for 6 seconds

    }
    public class Continuation
    {
        public string Equipped(string message)
        {
            return message;
        }

        public string Stored(string message1)
        {
            return message1;
        }
    }

    public static void Main(string[] args)
    {
        LoadingScreen("DUNGEON QUEST");
       
        string kindof = "......kind of";
        int screenWidth = Console.WindowWidth;
        int screenHeight = Console.WindowHeight;

        int x = (screenWidth - kindof.Length) / 2;
        int y = screenHeight / 2;

        Console.SetCursorPosition(x, y);

        foreach (char c in kindof)
        {
            Console.Write(c);
            Thread.Sleep(40); // Adjust the delay to control typing speed
        }

        Console.SetCursorPosition(0, screenHeight - 1);
        Console.WriteLine();
        Thread.Sleep(3000); // Display the message for 6 seconds

        MainMenu();
    }
}
