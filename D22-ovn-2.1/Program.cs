using System.Diagnostics.CodeAnalysis;
using System.Reflection.PortableExecutable;

namespace D22_ovn_2._1
{
    internal class Program
    {
        //34:
        class Weapon
        {
            public string Name { get; private set; }
            public int Times { get; private set; }
            public int Die { get; private set; }
            public Weapon(string name, int times, int die)
            {
                this.Name = name == null ? "unkown" : name;
                this.Times = times;
                this.Die = die;
            }
            public Weapon() { Name = "unknown"; Die = 1; Times = 0; }
        }
        class Armor
        {
            public string Name { get; private set; }
            public int Block { get; private set; }
            public Armor(string name, int block)
            {
                this.Name = name != null ? name : "unknown";
                this.Block = block;
            }
            public Armor() { Name = "unknown"; Block = 0; }
        }
        class NPC
        {
            private string name;
            private int maxHP = 20;
            private int HP = 20;
            Weapon weapon;
            private int parrying = 0;
            Armor armor;
            public void SetName(string n) { this.name = n; }
            public void EquipWeapon(Weapon w)
            {
                weapon = w;
            }
            public void Attack(NPC target, bool quiet = false)
            {
                if(!quiet) Console.Write(name + " attacks " + target.name + " with a " + weapon.Name.ToLower() + "! ");
                target.Attacked(Dice(weapon.Die, weapon.Times), quiet);
            }
            public void SetParrying(int m)
            {
                this.parrying = m;
            }
            public int Parry()
            {
                if (parrying == 0) return 0;
                else return Die(parrying);
            }
            public void EquipArmor(Armor a) { armor = a; }
            public int ArmorBlock() { return armor.Block; }
            public int GetHP() { return HP; }
            public void SetHP(int hp) { HP = hp; }
            public void AddHP(int hp) { HP += hp; }
            public void SubHP(int hp, bool quiet = false)
            {
                HP -= hp;
                if (HP <= 0)
                {
                    Console.WriteLine(name + " has died in battle!");
                }
            }
            public void SetMaxHP(int hp) { maxHP = hp; }
            public void FullHeal() { HP = maxHP; }

            public void Attacked(int m, bool quiet = false)
            {
                int p = Parry(), b = ArmorBlock();
                m = m - p - b;
                if(!quiet)
                {
                    if (p > 0) Console.Write(name + " parries " + p + " points of damage! ");
                    if (b > 0) Console.Write(name + "'s " + armor.Name.ToLower() + " absorbes " + b + " points of damage! ");
                    if (m > 0) Console.WriteLine(name + " takes " + m + " points of damage!");
                    else Console.WriteLine("The attack did no damage!");
                }
                SubHP(m, quiet);
            }
            public NPC(string name, Weapon w, Armor a, int p, int HP)
            {
                SetName((name != null) ? name : "Unknown");
                EquipWeapon(w);
                SetParrying(p);
                EquipArmor(a);
                SetMaxHP(HP);
                FullHeal();
            }
        }

        static void Main(string[] args)
        {
            //34:
            NPC player = new("Player", new Weapon("Longsword", 6, 2), new Armor("Mail armor", 4), 6, 20);
            NPC monster = new("Monster", new Weapon("Claw", 6, 3), new Armor("Scaly hide", 3), 0, 30);
            int monster_wins = 0, player_wins = 0;
            for (int i = 0; i < 100; i++)
            {
                int r = Die6();
                while (player.GetHP() > 0 && monster.GetHP() > 0)
                {
                    if (r++ % 2 == 0) monster.Attack(player, true);
                    else player.Attack(monster, true);
                }
                if (player.GetHP() <= 0) monster_wins++;
                else if (monster.GetHP() <= 0) player_wins++;
                player.FullHeal();
                monster.FullHeal();
            }
            Console.WriteLine("Monster wins: {0}  Player wins: {1}", monster_wins, player_wins);
            //35:
            Console.WriteLine(Fibonacci(0));
            Console.WriteLine(Fibonacci(1));
            Console.WriteLine(Fibonacci(2));
            Console.WriteLine(Fibonacci(3));
            Console.WriteLine(Fibonacci(11));
            Console.WriteLine(Fibonacci(19));
            Console.WriteLine(Fibonacci(144));
        }

        //31:
        static int Die6()
        {
            return new Random().Next(1, 7);
        }
        //32:
        static int Dice6(int n)
        {
            int sum = 0;
            while (0 < n--) sum += Die6();
            return sum;
        }
        static int Die(int n)
        {
            return new Random().Next(1, n);
        }
        static int Dice(int m, int n)
        {
            int sum = 0;
            while (0 < m--) sum += Die(n);
            return sum;
        }
        //35:
        static ulong Fibonacci(int n)
        //Fibonacci(n) - Returns the n:th number in the Fibonacci sequence by recursively creating each number.
        {
            if(n == 0) return 0;
            return Fibonacci_Recurse((ulong)0, (ulong)1, n);
        }
        static ulong Fibonacci_Recurse(ulong a, ulong b, int n)
        {
            return n == 1 ? b : Fibonacci_Recurse(b, a + b, n - 1);
        }

    }
}