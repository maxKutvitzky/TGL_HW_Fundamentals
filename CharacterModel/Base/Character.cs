using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CharacterModel.Util;

namespace CharacterModel
{
    public abstract class Character
    {
        protected static Random random = new Random();
        protected virtual int HealthLimit
        {
            get => 100;
        }
        public string Name { get; }
        private int _health;
        private bool _isDead = false;
        public bool IsDead { get => _isDead; private set => _isDead = value; }
        protected abstract event Action<string> characterActionEvent;
        private event Action<string> innerCharacterEvent;
        protected abstract int Damage { get; }
        public int Health
        {
            get => _health;

            protected set
            {
                if (value >= HealthLimit)
                {
                    _health = HealthLimit;
                }
                else if (value <= 0)
                {
                    _isDead = true;
                    _health = 0;
                    innerCharacterEvent.Invoke($"{Name} is dead!");
                }
                else
                {
                    _health = value;
                }
            }
        }

        protected Character()
        {
        }

        protected Character(int health, string name)
        {
            Health = health;
            Name = name;
            characterActionEvent += Logger.LogMessage;
            innerCharacterEvent = Logger.LogMessage;
        }
        public abstract void TakeDamage(int damage);


        public abstract void Attack(Character character);
    }
}
