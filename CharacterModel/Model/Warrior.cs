using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterModel.Model
{
    public class Warrior : Character
    {
        private int Armor
        {
            get => _armor;
            init => _armor = value >= 40 ? 40 : value;
        }
        protected override int Damage { get => random.Next(30, 60); }
        private readonly int _armor;
        protected override event Action<string> characterActionEvent;
        public Warrior(int health, string name, int armor) : base(health, name)
        {
            Armor = armor;
        }
        public override void TakeDamage(int damage)
        {
            int damageTaken = damage - Armor;
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
            characterActionEvent?.Invoke($"{Name}: Attacking {character.Name}");
            character.TakeDamage(Damage);
        }
    }
}
