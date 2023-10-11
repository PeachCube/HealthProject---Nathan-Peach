using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            //initialization
            //"ResetGame" is basically just "SetGame", since both methods would serve the same purpose of setting the value of variables either after a restart, or at the start of the game.
            void ResetGame()
            {
                health = 100;
                shield = 100;
                lives = 3;
                xp = 0;
                maxxp = 100;
                level = 1;
                healthStatus = "perfect";
            }
            //ResetGame also needs to be called before the first ShowHUD, in order to display correctly
            //initialization

            //game start
            ResetGame();
            Console.WriteLine();
            ShowHUD();
            TakeDamage(50);
            ShowHUD();
            TakeDamage(75);
            ShowHUD();
            TakeDamage(10);
            ShowHUD();
            TakeDamage(75);
            ShowHUD();
            TakeDamage(175);
            ShowHUD();
            TakeDamage(200);
            ShowHUD();
            TakeDamage(200);
            ShowHUD();
            TakeDamage(200);
            ShowHUD();
        
        }
        static void ShowHUD()
        {
            //turn starts
            Console.WriteLine("Health: "+health+" Shield: "+shield+" Lives: "+lives);
            Console.WriteLine("");
            Console.WriteLine("XP: "+xp+"/"+maxxp+" Level: "+level);
            Console.ReadKey(true);
            
        
        
        
        
        }
    static void TakeDamage(int damage)
        {
            if (damage < 0)
            {
                Console.WriteLine("ERROR: ","TakeDamage"," does not accept negative values");
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
            //if enough damage is dealt to lower health to zero or lower, take away one life and reset hp and shield values
            if (health <= 0)
            {
                lives -= 1;
                health = 100;
                shield = 100;
                //then, if lives are also equal to zero, end the game after pressing any key
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
            health += healing;
            //checks to make sure health never stays over 100 (the hard-coded maximum hp value).
            if (health >= 100)
            {
                health = 100;
            }
        }
    static void RegenerateShield(int regen)
        {
            shield += regen;
            //checks to make sure shield never stays over 100 (the hard-coded maximum shield value).
            if (shield >= 100)
            {
                shield = 100;
            }
        }
    static void IncreaseXP(int gain)
        {
            xp += gain;
            if (xp >= maxxp)  
            {
                xp -= maxxp;
                level += 1;
                maxxp += 100;
                //when xp is equal to maxxp, reset xp count (lowers the xp count by the maxxp so gaining 50 xp and 90 xp while at level 1 doesn't waste 40 xp) and increase level by 1.
                //every time you level up, the xp required to level up increases -> 100 -> 200 -> 300, etcetera.
                Console.WriteLine("You Leveled Up!");
            }
        }
    }
}
