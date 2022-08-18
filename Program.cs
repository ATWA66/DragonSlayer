Console.WriteLine("Welcome to the doungeon hero\nhere you will find an enormously big dragon inside the cave\n if you want glory & gold, try to defeat him!\n Prepare for fight!");
Console.WriteLine("you are mage and you can use 1 of the 2 great elementes of magic: water, fire; also you can use bow for the small range enemis\nBe careful, the dragon always adapting to the elements, so be smart in using them properly");
Console.WriteLine("/////////////////");
string[] dragons = { "Western Dragon", "Oriental Dragon", "Wyvern", "Cockatrice", "Hydra", "Wyrm" };
Random rand = new Random();
int heroArrows=7;
int heroMana =6;
int heroHP = 100;
int heroDMG = 25;
int monsterHP = 100;
int coins = 10;
int i = 0;
string check=dragons[3] ;
int lvl = 1;
bool monsterRangeLong = Convert.ToBoolean(rand.Next(0, 2));
while (heroHP > 0)
{
    Console.WriteLine("Now your location is Town shop, here you can buy some ammunition and have a rest(restore HP & Mana)\n your coins: {0}", coins);
    Console.WriteLine("1 - Take a nap(restore HP {0}/100 & Mana{1}/6) ( 8c.)", heroHP, heroMana);
    Console.WriteLine("2 - gain an arrow {0}(7 - max) (1c. for 1)", heroArrows);
    Console.WriteLine("3 - start the run");
    while (check != "3")
    {
        check = Console.ReadLine();
        switch (check) 
        {
            case "1":
                {
                    heroHP = 100;
                    heroMana = 6;
                    coins -= 8;
                    Console.WriteLine("your health and mana was restored to full");
                    Console.Write("||your coins:" + coins + "\n");
                    break;
                }
            case "2":
                {
                    if (heroArrows > 7)
                        Console.WriteLine("you already have maximum");
                    else
                    { 
                        heroArrows++;
                        coins--;
                        Console.WriteLine("your Arrows: "+ heroArrows);
                        Console.Write("||your coins:" + coins+"\n");
                    }
                    break;
                }
            case "3":
                {
                    break;
                }
            default:
                {
                    Console.WriteLine("there is no item like that");
                    break;
                }
        }
    }
    Console.Clear();
    Console.Write("lvl: "+ lvl);
    int dragonDMG = rand.Next(17, 20);
    int WaterRes = rand.Next(5, 15) + i;
    int FireRes = rand.Next(5, 15) + i;
    Console.Write(@"{0}
░░░░░░▀█▄░░░░░░░░░░░░░░░░░░░░░░░░░░░░░  dragon HP: {1}                                        
▀▄▄░░░░░▀▀███▄▄▄░░░░░░░░░░░░░░░░░░░░░░  water resist: {2}
░░▀▀██▄▄▄▄░░░▀▀▀██▄▄░░░░░░░░░░░░░░░░░░  fire resist: {3}
░░░░░░▀▀▀███▄▄░░░▀▀░▄▄▄▄░░░░░░░░░░░░░░  long attack range: {4}
░░░░░░░░░░▄█████████▀░░▀█░░░░░░░░░░░░░
░░░░░░░░░▀█░░▀███▀░░░░░░▀█▄▄░░░░░░░░░░
░░░░░▄█████░░░░░░░░░░░░░░░▀▀█░░░░░░░░░
░░░░░░██▄░░░▀▀██░░░░░░░░░░░░██░░░░░░░░
░░▄▄█▀▀▀▀░░░░▄░░░░░░░░▀▀██░░▀█▄░░░░░░░
░░▄▄██░░░░░▀▀▀▀░░░░░░░░░░░░░░░▀█▄░░▄░░
░██▀▀▀░░░░░░░▄░░░░░░░██▀▀█▄▄░░░▀████░░
░█▀░░░░░░░░▄▀▀░░░░░░░▀█▄░░▀██▄░░░▀▀█▄░
░█▄░░░░░░░░░░░░░░░░░░░░█▄░░▀▀██▄░░░░██
░░█▄░░░░░░░░░░░░██▀█▄░░▀██░░░░▄██▄░░█▀
░░░█▄░░░░░░░░░▄█▀░░░▀█▄░▀██▄▄░░░▄███▀░
░░░░▀█▄░░░░░░░█▀░░░░░░▀█▄░▀▀█▄░░░░░░░░
░░░░░░▀██▄▄▄░▄█░░░░░░░░░████▀░░░░░░░░░
░░░░░░░░░░▀▀▀▀▀░░░░░░░░░░░░░░░░░░░░░░░
", dragons[Convert.ToInt32(check)], monsterHP, WaterRes, FireRes, monsterRangeLong);
    Console.WriteLine("Yours HP: {0}||your coins: {1}||your mana: {2}||your arrows {3}", heroHP, coins, heroMana, heroArrows);
    Console.WriteLine("choose the attack:\n1 - water blast;\n2 - fireball;\n3 - shot the arrow;");
    switch (Console.ReadLine())
    {
        case "1":
            {
                waterBlast(ref monsterHP, heroDMG, WaterRes, ref heroMana);
                break;
            }
        case "2":
            {
                fireBall(ref monsterHP, heroDMG, FireRes, ref heroMana);
                break;
            }
        case "3":
            {
                if (monsterRangeLong == true)
                {
                    shotArrow(ref monsterHP, heroDMG, ref heroArrows);
                }
                else
                {
                    monsterRangeLong = true;
                    shotArrow(ref monsterHP, heroDMG, ref heroArrows);
                    Console.WriteLine("the creature step up closer to you!");
                    dragonDMG = 0;
                }
                break;
            }
        default:
            {
                Console.WriteLine("you missed the attack");
                break;
            }
    }
    if (monsterHP > 0)
    {
        dragonAttack(ref heroHP, dragonDMG);
    }
    Console.Clear();
    if (heroHP <= 0)
    {
        Console.WriteLine("Not this time buddy( \nif you want to try again enter - 1");
        i = 0;
        lvl = 1;
        heroMana = 6;
        heroArrows = 7;
        coins = 10;
        string restart = Console.ReadLine();
        if (restart == "1")
        {
            check = dragons[rand.Next(0, 6)];
            heroHP = 100;
            monsterHP = 100;
            Console.Clear();
        }
        else
            Console.WriteLine("goodbye then <3");
    }
    else if( monsterHP <=0)
    {
        int rMana = rand.Next(0, 4);
        int rArrows = rand.Next(0, 4);
        int rHP = rand.Next(0, 15);
        int rCoins = rand.Next(0, 10);
        heroMana += rMana;
        heroArrows += rArrows;
        heroHP += rHP;
        coins += rCoins;
        Console.WriteLine("YOU DEFITED THE DRAGON!!!\n BE PROUD BECOUSE OF THAT!\n Thats what you gain from the creature:\nMana-{0}\nArrows-{1}\nHP-{2}\nCoins-{3}", rMana,rArrows,rHP, rCoins);
        Console.WriteLine("if you want to continue the run enter - 1 and you will be in the town to buy new things\n Be aware, each time you continue, creatures are becaming strong");
        string restart = Console.ReadLine();
        if (restart == "1")
        {
            check = dragons[rand.Next(0, 6)];
            i+=2;
            lvl++;
            monsterHP = 100;
            Console.Clear();
        }
        else
            Console.WriteLine("goodbye then <3");
    }
}
static void dragonAttack (ref int heroHP, int dragonDMG)
{
    if (dragonDMG > 0)
    {
        Random rand = new Random();
        int rnd = rand.Next(0, 4);
        heroHP -= (dragonDMG - rnd);
        Console.WriteLine("Dragon deal {0} DMG to you \npress a button to get into the next turn", dragonDMG - rnd);
    }
        Console.ReadLine();
}
static void waterBlast (ref int monsterHP, int heroDMG, int dragonWaterRes,ref int heroMana)
{
    if (heroMana > 0)
    {
        heroMana--;
        monsterHP -= (heroDMG - dragonWaterRes);
        Console.WriteLine("you deal {0} damage to dragon", heroDMG - dragonWaterRes);
    }
    else
    {
        Console.WriteLine("Not enough mana to make a good spell");
    }
}
static void fireBall(ref int monsterHP, int heroDMG, int dragonfireRes, ref int heroMana)
{
    if (heroMana > 0)
    {
        heroMana--;
        monsterHP -= (heroDMG - dragonfireRes);
        Console.WriteLine("you deal {0} damage to dragon", heroDMG - dragonfireRes);
    }
    else
    {
        Console.WriteLine("Not enough mana to make a good spell");
    }
}
static void shotArrow(ref int monsterHP, int heroDMG, ref int heroarrows)
{
    if (heroarrows > 0)
    {
        heroarrows--;
        Random rand = new Random();
        int rnd = rand.Next(10, 16);
        monsterHP -= (heroDMG - rnd);
        Console.WriteLine("you deal {0} damage to dragon", heroDMG - rnd);
    }
    else
    {
        Console.WriteLine("Not enough mana to make a good spell");
    }
}
