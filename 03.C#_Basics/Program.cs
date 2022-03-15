using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System.Text;
using System.Threading.Tasks;

namespace Task_C_Diaconescu
{
    public class Program
    {
        static void Main(string[] args)
        {
            Soldier soldier_1 = new Soldier(23, 2.1f, 100f);
            Soldier soldier_2 = new Soldier(30, 1.7f, 100f);

            soldier_1.UpdateSoldier(militaryPowerPlus: 10, movementPlus: 12f);
            soldier_2.UpdateSoldier(15);

            Console.WriteLine(soldier_1.Movement);
            Console.WriteLine(soldier_2.MilitaryPower);

            BlueSoldier blue_1 = new BlueSoldier(23, 15f, 100f);
            blue_1.UpdateSoldier(30);
            Console.WriteLine(blue_1.MilitaryPower);

            var classEnumerable = new ClassEnumerable();
            classEnumerable.soldiers = new Soldier[] { new RedSoldier(10,11f,10), new BlueSoldier(12,12f,13), new GreenSoldier(13,14,10) };

            var enumerator = classEnumerable.GetEnumerator();

            while(enumerator.MoveNext())
            {
                Console.WriteLine($"Total soldier power: {enumerator.Current.ToString()}");
            }

            var soldier_4 = classEnumerable.soldiers[2].Clone();
            Console.WriteLine("Total power of soldier 4: " + soldier_4.ToString());
        }
    }



    // Enumerable 
    public class ClassEnumerable : IEnumerable<Soldier>
    {
        public Soldier[] soldiers { get; set; }

        public IEnumerator GetEnumerator()
        {
            return new ClassEnumerator(soldiers);
        }

        IEnumerator<Soldier> IEnumerable<Soldier>.GetEnumerator()
        {
            return new ClassEnumerator(soldiers);
        }
    }
    public class ClassEnumerator : IEnumerator<Soldier>
    {
        private Soldier[] _soldiers;
        private int mIndex = -1;

        public Soldier Current => _soldiers[mIndex];

        object IEnumerator.Current => Current;


        public ClassEnumerator(Soldier[] soldiers)
        {
            this._soldiers = soldiers;
        }


        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public bool MoveNext()
        {
            mIndex++;

            return mIndex < _soldiers.Length;
        }

        public void Reset()
        {
            mIndex = -1;
        }
    }


    // Other tasks with classes + ICloneable
    public class Soldier : ICloneable
    {
        // Fields
        private int _militaryPower;
        private float _movement;
        private float _health;


        // Ctor
        public Soldier(int militaryPower, float movement, float health) 
        {
            this._militaryPower = militaryPower;
            this._movement = movement;

            if (health > 100f)
                this._health = 100;
            else
                this._health = health;
        }


        public override string ToString()
        {
            return  (_militaryPower + _movement + _health).ToString();
        }

        // Properties 
        public int MilitaryPower 
        { 
            get { return _militaryPower; }
        }
        public float Movement
        {
            get { return _movement; }
        }
        public float Health
        {
            get { return _health; }
            set { _health = value; }
        }

        

        // Overriding 
        public virtual void UpdateSoldier(int militaryPowerPlus)
        {
            if (militaryPowerPlus > 0)
                this._militaryPower += militaryPowerPlus;
            else
                Console.WriteLine("Please use positive values!");
        }
        public virtual void UpdateSoldier(float movementPlus)
        {
            if (movementPlus > 0f)
                this._movement += movementPlus;
            else
                Console.WriteLine("Please use positive values!");
        }
        public virtual void UpdateSoldier(int militaryPowerPlus, float movementPlus)
        {
            this.UpdateSoldier(militaryPowerPlus);
            this.UpdateSoldier(movementPlus);
        }

        
        // Clone
        public object Clone()
        {
           return this.MemberwiseClone();
        }
    }

    public class BlueSoldier : Soldier, ITakeDamage, IHeal
    {
        public BlueSoldier(int militaryPower, float movement, float health) : base(militaryPower, movement, health)
        {
            Console.WriteLine("The blue soldier was created!");
        }

        public override void UpdateSoldier(float movementPlus)
        {
            base.UpdateSoldier(movementPlus);
            Console.WriteLine("Blue soldier override for movement upgrade!");
        }

        public void TakeDamage(float damageAmount)
        {
            this.Health -= damageAmount;
        }
        public void Heal(float healAmount)
        {
            this.Health += healAmount;
        }
    }
    public class RedSoldier : Soldier, ITakeDamage, IHeal
    {
        public RedSoldier(int militaryPower, float movement, float health) : base(militaryPower, movement, health)
        {
            Console.WriteLine("The red soldier was created!");
        }

        public override void UpdateSoldier(int militaryPower, float movementPlus)
        {
            base.UpdateSoldier(militaryPower, movementPlus);
            Console.WriteLine("Red soldier override for military power & movement upgrade!");
        }

        public void TakeDamage(float damageAmount)
        {
            this.Health -= damageAmount;
        }
        public void Heal(float healAmount)
        {
            this.Health += healAmount;
        }
    }
    public class GreenSoldier : Soldier, ITakeDamage, IHeal
    {
        public GreenSoldier(int militaryPower, float movement, float health) : base(militaryPower, movement, health)
        {
            Console.WriteLine("The green soldier was created!");
        }

        public override void UpdateSoldier(int militaryPower)
        {
            base.UpdateSoldier(militaryPower);
            Console.WriteLine("Green soldier override for militaryPower upgrade!");
        }

        public void TakeDamage(float damageAmount)
        {
            this.Health -= damageAmount;
        }
        public void Heal(float healAmount)
        {
            this.Health += healAmount;
        }
    }

    public interface ITakeDamage
    {
        void TakeDamage(float damageAmount);
    }
    public interface IHeal
    {
        void Heal(float healAmount);
    }
    


}
