using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterModel.Model
{
    public class Archer : Character
    {
        public override string ClassName { get; } = "Archer";
        protected override event Action<string> characterActionEvent;
        protected override int Damage { get => random.Next(20, 40); }
        private const double _dodgeAttackChance = 0.50;
        public Archer(int health, string name) : base(health, name) { }
        public override void TakeDamage(int damage)
        {
            if (IsDead)
            {
                return;
            }
            if (isDodgeAttack())
            {
                characterActionEvent?.Invoke($"{Name}: Dodged the attack");
            }
            else
            {
                Health -= damage;
                if (IsDead)
                {
                    return;
                }
                characterActionEvent?.Invoke($"{Name}: Taking damage {damage}, Health {Health}");
            }
        }

        public override void Attack(Character character)
        {
            if (IsDead)
            {
                return;
            }
            characterActionEvent?.Invoke($"{Name}: Shooting at {character.Name}");
            base.Attack(character);
        }

        private bool isDodgeAttack() => random.NextDouble() <= _dodgeAttackChance;
    }
}
