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
        /// <summary>
        /// Name of character class
        /// </summary>
        public abstract string ClassName { get;}
        /// <summary>
        /// Represent character`s max health
        /// </summary>
        protected virtual int HealthLimit
        {
            get => 100;
        }
        /// <summary>
        /// Represents character`s name
        /// </summary>
        public string Name { get; }
        private int _health;
        private bool _isDead = false;
        /// <summary>
        /// 
        /// </summary>
        public bool IsDead { get => _isDead; }
        /// <summary>
        /// Event for derived classes
        /// </summary>
        protected abstract event Action<string> characterActionEvent;
        /// <summary>
        /// Event for base class only
        /// </summary>
        private event Action<string> innerCharacterEvent;
        /// <summary>
        /// Character`s damage.
        /// </summary>
        protected abstract int Damage { get; }
        /// <summary>
        /// Represent character`s health. Can't be more than HealthLimit property. If health <= 0 then character is dead
        /// </summary>
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
            Name = "NoNameCharacter";
            characterActionEvent += FileLogger.LogMessage;
            innerCharacterEvent = FileLogger.LogMessage;
        }

        protected Character(int health, string name)
        {
            Health = health;
            Name = name;
            characterActionEvent += FileLogger.LogMessage;
            innerCharacterEvent = FileLogger.LogMessage;
        }
        /// <summary>
        /// Applying damage to character 
        /// </summary>
        /// <param name="damage">Damage taken</param>
        public abstract void TakeDamage(int damage);

        /// <summary>
        /// Attacking specific character
        /// </summary>
        /// <param name="character">Character to attack</param>
        public virtual void Attack(Character character)
        {
            character.TakeDamage(Damage);
        }
    }
}
