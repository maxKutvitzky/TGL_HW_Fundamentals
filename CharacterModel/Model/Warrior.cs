using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterModel.Model
{
    public class Warrior : Character
    {
        private const double _armor = 0.25;
        protected override int Damage { get => random.Next(30, 60); }
        public override string ClassName { get; } = "Warrior";
        protected override event Action<string> characterActionEvent;
        public Warrior(int health, string name) : base(health, name)
        {
        }
        /// <summary>
        /// Applying damage to warrior. Blocks 25% damage
        /// </summary>
        /// <param name="damage">Damage taken</param>
        public override void TakeDamage(int damage)
        {
            int damageBlocked = (int)(damage * _armor);
            int damageTaken = damage - damageBlocked;
            characterActionEvent?.Invoke($"{Name}: Blocking {damageBlocked} damage");
            if (damageTaken < 0)
            {
                damageTaken = 0;
            }
            Health -= damageTaken;
            if (IsDead)
            {
                return;
            }
            characterActionEvent?.Invoke($"{Name}: Taking damage {damageTaken}, Health {Health}");
        }
        public override void Attack(Character character)
        {
            if (IsDead)
            {
                return;
            }
            characterActionEvent?.Invoke($"{Name}: Attacking with sword {character.Name}");
            base.Attack(character);
            
        }
    }
}
