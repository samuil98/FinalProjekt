﻿using System;
using DungeonGame.Helpers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonGame.Monsters;

namespace DungeonGame.Hero
{
    class Hero : Stats
    {
        internal int cooldownLB = 0;
        internal int cooldownFB = 0;
        public string Name { get; set; }
        public override double Attack { get; set; }
        public override double Defence { get; set; }
        public override int Level { get; set; }
        public override int XP { get; set ; }
        public int MaxXp { get; set; }
        public override double Health { get; set; }
        public override double MaxHealth { get; set; }

        public Hero()
        {
            Console.WriteLine("Enter Hero Name:");
            this.Name = Console.ReadLine();
            this.Attack = 10;
            this.Defence = 10;          
            this.Level = 1;
            this.MaxXp = 100;
            this.MaxHealth = 100;
            this.Health = MaxHealth;
        }


        internal void AttackAnEnemy(Monsters.Monster monster)
        {
            
            double damage = Attack - 0.7*monster.Defence;
            monster.Health -= damage;
            Console.WriteLine("You dealt {0} damage. ", damage.ToString("F"));    
        }

        internal void FireBall (Monsters.Monster monster)
        {
            cooldownFB = 3;
            double damage = Attack * 1.5 - 0.5 * monster.Defence;
            monster.Health -= damage;
            
            Console.WriteLine("You dealt {0} damage and apply burning effect for 3 rounds. ", damage.ToString("F"));
            ApplyBurning(monster); 
        }
        internal void LightningBolt(Monsters.Monster monster)
        {
            cooldownLB = 3;
            double damage = Attack * 1.5 - 0.5 * monster.Defence;
            monster.Health -= damage;
            Console.WriteLine("You dealt {0} damage, stunned the monster and lowered his defence.", damage.ToString("F"));            
            monster.Defence -= 1;
            ApplyBurning(monster);
            Console.WriteLine("\nPress ENTER to continue...");

        }
        internal void ApplyBurning(Monster monster)
        {
            if (cooldownFB > 0 & cooldownFB <= 3)
            {
                double burn = 0.1 * monster.MaxHealth;
                monster.Health -= burn;
                Console.WriteLine("Monster took {0} damage from burn effect.", burn);
            }
            
        }

        public void LevelUp()
        {
            Console.Clear();
            XP = 0;
            Level++;
            MaxHealth += 30;
            Health = MaxHealth;
            Attack += 5;
            MaxXp += 50;
            Defence += 2;


            Console.WriteLine("X────────────────────────────X");
            Console.WriteLine($"|   You are now level {Level}      |");
            Console.WriteLine("X────────────────────────────X");
            Console.ReadLine();
        }

    }

}

