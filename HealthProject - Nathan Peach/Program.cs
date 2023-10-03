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
        static string status;
        static int lives;
        static int xp;
        static int level;
        //declaration
        static void Main(string[] args)
        {
            //initialization
            health = 10;
            shield = 10;
            totalHP = health + shield;
            lives = 2;
            xp = 0;
            level = 1;
            //initialization

            //game start
            Console.WriteLine();
            Hud();

        }
    static void Hud()
        {
            //turn starts
            Console.WriteLine();
        
        
        
        
        
        
        }
    static void Damage(int damage)
        {
            
        }
    static void Heal(int healing)
        {

        }
    static void Regen(int regen)
        {

        }
    static void GainXP(int gain)
        {
            xp = xp + gain;
            if (xp >= 100)  
            {
                xp = 0;
                level = level + 1;
                Console.WriteLine("You Leveled Up!");
                //if you have 90 xp and gain 20, 10 xp is lost. You also can't level up multiple times by gaining 200 xp at once.
            }
        }
    }
}
