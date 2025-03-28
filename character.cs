using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace battle
{


    public class character
    {

        public string Name { get; set; }
        public int Hp { get; set; }
        public int Mana { get; set; }
        public int Defense { get; set; }
        public int MinDamage { get; set; }
        public int MaxDamage { get; set; }
        public int SpecialMinDamage { get; set; }
        public int SpecialMaxDamage { get; set; }
        private Random rng = new Random();

        public character(string name, int hp, int mana, int defense, int minDamage, int maxDamage, int specialMinDamage, int specialMaxDamage)
        {
            Name = name;
            Hp = hp;
            Mana = mana;
            Defense = defense;
            MinDamage = minDamage;
            MaxDamage = maxDamage;
            SpecialMinDamage = specialMinDamage;
            SpecialMaxDamage = specialMaxDamage;
        }

        public int Attack()
        {
            return rng.Next(MinDamage, MaxDamage);
        }

        public int SpecialAttack()
        {
            if (Mana >= 20)
            {
                Mana -= 20;
                return rng.Next(SpecialMinDamage, SpecialMaxDamage);
            }
            return 0; // No mana, attack fails
        }

        public void Defend()
        {
            Defense += 5;
        }
    }
}

