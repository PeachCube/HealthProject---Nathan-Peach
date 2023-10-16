using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace HealthProject___Nathan_Peach
{
    internal class Program
    {
        //declaration
        static int health;
        static int shield;
        static string healthStatus;
        static int lives;
        static float xp;
        static float maxxp;
        static int level;
        //declaration
        
        static void Main(string[] args)
        {
            
            UnitTestHealthSystem();
            UnitTestXPSystem();

            //initialization
            //"ResetGame" is really just "SetGame", since both methods would serve the same purpose of setting the value of variables either after a restart, or at the start of the game.
            void ResetGame()
            {
                health = 100;
                shield = 100;
                lives = 3;
                xp = 0;
                maxxp = 100;
                level = 1;
                healthStatus = "Perfect Health";
            }
            //ResetGame also needs to be called before the first ShowHUD, in order to display correctly
            //initialization

           


            //game start
            ResetGame();
            //I wanted to put Revive, StatusCheck, and ShowHUD all into a single method to save time, but I'm not sure if I'm allowed to do that.
            Revive();
            StatusCheck();
            ShowHUD();
            
            TakeDamage(50);
            
            Revive();
            StatusCheck();
            ShowHUD();
            
            TakeDamage(75);
            
            Revive();
            StatusCheck();
            ShowHUD();

            RegenerateShield(50);

            Revive();
            StatusCheck();
            ShowHUD();

            TakeDamage(75);

            Revive();
            StatusCheck();
            ShowHUD();

            IncreaseXP(75);

            Revive();
            StatusCheck();
            ShowHUD();

            Heal(50);
            
            Revive();
            StatusCheck();
            ShowHUD();

            TakeDamage(100);
            
            Revive();
            StatusCheck();
            ShowHUD();

            IncreaseXP(75);
            
            Revive();
            StatusCheck();
            ShowHUD();

            IncreaseXP(75);
            
            Revive();
            StatusCheck();
            ShowHUD();

            IncreaseXP(-25);

            Revive();
            StatusCheck();
            ShowHUD();

        }
        static void ShowHUD()
        {
            Console.WriteLine("");
            Console.WriteLine("Health: "+health+" Shield: "+shield+" Lives: "+lives);
            Console.WriteLine("");
            Console.WriteLine("XP: "+xp+"/"+maxxp+" Level: "+level);
            Console.WriteLine("");
            Console.WriteLine("Current Health Status: " + healthStatus);
            Console.WriteLine("");
            Console.ReadKey(true);
        }
        static void TakeDamage(int damage)
        {
            if (damage < 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("ERROR: "+"TakeDamage"+" does not accept negative values");
                Console.ForegroundColor = ConsoleColor.White;
                damage = 0;
            }
            //if the shield was depleted in a previous turn, set shield to zero
            //damage will then deplete health
            if (shield <= 0)
            {
                shield = 0;
                health -= damage;
            }
            //if the shield is still above zero, deal damage to the shield
            //if the shield falls below zero as a result, add the negative value of the shield to health, then set shield to zero
            if (shield >= 1)
            {
                shield -= damage;
                if (shield <= 0)
                {
                    health += shield;
                    shield = 0;
                }
            }
            if (health <= 0) 
            {
                health = 0;
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("You took "+damage+" damage");
            Console.ForegroundColor = ConsoleColor.White;
        }
        static void StatusCheck()
        {
            if ((health <= 100) && (health >= 90))
            {
                healthStatus = "Perfect Health";
            }
            if ((health < 90) && (health >= 75))
            {
                healthStatus = "Healthy";
            }
            if ((health < 75) && (health >= 50))
            {
                healthStatus = "Hurt";
            }
            if ((health < 50) && (health >= 10))
            {
                healthStatus = "Badly Hurt";
            }
            if (health < 10)
            {
                healthStatus = "Imminent Danger";
            }
        }
        static void Revive()
        {
            //if health is at zero, reset health and shield to default values and take away one life.
            if (health <= 0)
            {
                lives -= 1;
                health = 100;
                shield = 100;
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("You lost a life!");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadKey(true);
                //if lives are also equal to zero, end the game after pressing any key
                if (lives <= 0)
                {
                    Console.WriteLine("");
                    Console.WriteLine("GAME OVER");
                    Console.WriteLine("PRESS ANY KEY TO EXIT");
                    Console.WriteLine("");
                    Console.ReadKey(true);
                    Environment.Exit(0);
                }
            }
        }
        static void Heal(int healing)
        {
            if (healing < 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("ERROR: "+"Heal"+" does not accept negative values");
                Console.ForegroundColor = ConsoleColor.White;
                healing = 0;
            }
            health += healing;
            //checks to make sure health never stays over 100 (the hard-coded maximum hp value).
            if (health >= 100)
            {
                health = 100;
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("You healed " + healing + " health points");
            Console.ForegroundColor = ConsoleColor.White;
        }
    static void RegenerateShield(int regen)
        {
            if (regen < 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("ERROR: "+"RegenerateShield"+" does not accept negative values");
                Console.ForegroundColor = ConsoleColor.White;
                regen = 0;
            }
            shield += regen;
            //checks to make sure shield never stays over 100 (the hard-coded maximum shield value).
            if (shield >= 100)
            {
                shield = 100;
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("You regenerated " + regen + " shield points");
            Console.ForegroundColor = ConsoleColor.White;
        }
    static void IncreaseXP(int gain)
        {
            maxxp = level * 100;
            if (gain < 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("ERROR: "+"IncreaseXP"+" does not accept negative values");
                Console.ForegroundColor = ConsoleColor.White;
                gain = 0;
            }
            xp += gain;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("You gained "+gain+" experience points");
            Console.ForegroundColor = ConsoleColor.White;
            if (xp >= maxxp)  
            {
                xp -= maxxp;
                level += 1;
                //I tried to fix xp overflow by myself in a similar way to TakeDamage, but it doesn't really work.
                //It seems like it would work if I used some kind of loop like you said, but I didn't think of that beforehand.
                //It would probably be something like: while xp >= maxxp, execute this piece of code, and it should do that until xp is less than maxxp.
                //every time you level up, the xp required to level up increases -> 100 -> 200 -> 300, etcetera.
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("You Leveled Up!");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        static void UnitTestHealthSystem()
        {         
            Debug.WriteLine("Unit testing Health System started...");

            // TakeDamage()

            // TakeDamage() - only shield
            shield = 100;
            health = 100;
            lives = 3;
            TakeDamage(10);
            Debug.Assert(shield == 90);
            Debug.Assert(health == 100);
            Debug.Assert(lives == 3);

            // TakeDamage() - shield and health
            shield = 10;
            health = 100;
            lives = 3;
            TakeDamage(50);
            Debug.Assert(shield == 0);
            Debug.Assert(health == 60);
            Debug.Assert(lives == 3);

            // TakeDamage() - only health
            shield = 0;
            health = 50;
            lives = 3;
            TakeDamage(10);
            Debug.Assert(shield == 0);
            Debug.Assert(health == 40);
            Debug.Assert(lives == 3);

            // TakeDamage() - health and lives
            shield = 0;
            health = 10;
            lives = 3;
            TakeDamage(25);
            Debug.Assert(shield == 0);
            Debug.Assert(health == 0);
            Debug.Assert(lives == 3);

            // TakeDamage() - shield, health, and lives
            shield = 5;
            health = 100;
            lives = 3;
            TakeDamage(110);
            Debug.Assert(shield == 0);
            Debug.Assert(health == 0);
            Debug.Assert(lives == 3);

            // TakeDamage() - negative input
            shield = 50;
            health = 50;
            lives = 3;
            TakeDamage(-10);
            Debug.Assert(shield == 50);                
            Debug.Assert(health == 50);
            Debug.Assert(lives == 3);

            // Heal()

            // Heal() - normal
            shield = 0;
            health = 90;
            lives = 3;
            Heal(5);
            Debug.Assert(shield == 0);
            Debug.Assert(health == 95);
            Debug.Assert(lives == 3);

            // Heal() - already max health
            shield = 90;
            health = 100;
            lives = 3;
            Heal(5);
            Debug.Assert(shield == 90);
            Debug.Assert(health == 100);
            Debug.Assert(lives == 3);

            // Heal() - negative input
            shield = 50;
            health = 50;
            lives = 3;
            Heal(-10);
            Debug.Assert(shield == 50);
            Debug.Assert(health == 50);                 
            Debug.Assert(lives == 3);

            // RegenerateShield()

            // RegenerateShield() - normal
            shield = 50;
            health = 100;
            lives = 3;
            RegenerateShield(10);
            Debug.Assert(shield == 60);
            Debug.Assert(health == 100);
            Debug.Assert(lives == 3);

            // RegenerateShield() - already max shield
            shield = 100;
            health = 100;
            lives = 3;
            RegenerateShield(10);
            Debug.Assert(shield == 100);
            Debug.Assert(health == 100);
            Debug.Assert(lives == 3);

            // RegenerateShield() - negative input
            shield = 50;
            health = 50;
            lives = 3;
            RegenerateShield(-10);
            Debug.Assert(shield == 50);                  
            Debug.Assert(health == 50);
            Debug.Assert(lives == 3);

            // Revive()

            // Revive()
            shield = 0;
            health = 0;
            lives = 2;
            Revive();
            Debug.Assert(shield == 100);
            Debug.Assert(health == 100);
            Debug.Assert(lives == 1);

            Debug.WriteLine("Unit testing Health System completed.");
            Console.Clear();
        }

        static void UnitTestXPSystem()
        {
            Debug.WriteLine("Unit testing XP / Level Up System started...");

            // IncreaseXP()

            // IncreaseXP() - no level up; remain at level 1
            xp = 0;
            level = 1;
            IncreaseXP(10);
            Debug.Assert(xp == 10);
            Debug.Assert(level == 1);                              //error here

            // IncreaseXP() - level up to level 2 (costs 100 xp)
            xp = 0;
            level = 1;
            IncreaseXP(105);
            Debug.Assert(xp == 5);
            Debug.Assert(level == 2);

            // IncreaseXP() - level up to level 3 (costs 200 xp)
            xp = 0;
            level = 2;
            IncreaseXP(210);
            Debug.Assert(xp == 10);
            Debug.Assert(level == 3);

            // IncreaseXP() - level up to level 4 (costs 300 xp)
            xp = 0;
            level = 3;
            IncreaseXP(315);
            Debug.Assert(xp == 15);
            Debug.Assert(level == 4);

            // IncreaseXP() - level up to level 5 (costs 400 xp)
            xp = 0;
            level = 4;
            IncreaseXP(499);
            Debug.Assert(xp == 99);
            Debug.Assert(level == 5);

            Debug.WriteLine("Unit testing XP / Level Up System completed.");
            Console.Clear();
        }
    }
}
