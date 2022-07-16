using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterModel.Model
{
    public class Mage : Character
    {
        protected override event Action<string> characterActionEvent;
        private int _mana = 60;
        protected override int Damage { get => random.Next(20, 40); }
        public Mage(int health, string name) : base(health, name) { }
        public override void TakeDamage(int damage)
        {
            int damageTaken = damage;
            Health -= damageTaken;
            if (IsDead)
            {
                return;
            }
            characterActionEvent?.Invoke($"{Name}: Taking damage {damageTaken}, Health {Health}");
            if (Health <= 50)
            {
                Heal();
            }
        }

        public override void Attack(Character character)
        {
            if (IsDead)
            {
                return;
            }
            base.Attack(character);
            characterActionEvent?.Invoke($"{Name}: Attacking with magic {character.Name}");
            
        }

        private void Heal()
        {
            if (_mana == 0)
            {
                return;
            }

            Health += 30;
            _mana -= 20;
            characterActionEvent?.Invoke($"{Name}: Healing for 30 hp, Health {Health}");
        }
    }
}
