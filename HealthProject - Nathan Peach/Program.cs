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
        static int totalHP;
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
            health = 100 ;
            shield = 100;
            totalHP = health + shield;
            lives = 3;
            xp = 0;
            maxxp = 100;
            level = 1;
            healthStatus = "perfect";
            //initialization

            //game start
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
            Console.ReadKey(true);
            
        
        
        
        
        }
    static void TakeDamage(int damage)
        {
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

        }
    static void RegenerateShield(int regen)
        {

        }
    static void IncreaseXP(int gain)
        {
            xp += gain;
            if (xp >= maxxp)  
            {
                xp = 0;
                level += 1;
                maxxp *= 1.25f;
                //every time you level up, the xp required to level up increases exponentially -> 100 -> 125 -> 156.25 -> 195.3125
                //it doesn't result in nice numbers for max hp but i don't really mind it.
                Console.WriteLine("You Leveled Up!");
                //if you have 90 xp and gain 20, 10 xp is lost. You also can't level up multiple times by gaining 200 xp at once.
            }
        }
    }
}
