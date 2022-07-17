using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterModel.Model
{
    public class Mage : Character
    {
        public override string ClassName { get; } = "Mage";
        protected override event Action<string> characterActionEvent;
        private int _mana = 60;
        protected override int Damage { get => random.Next(20, 40); }
        public Mage(int health, string name) : base(health, name) { }
        public override void TakeDamage(int damage)
        {
            Health -= damage;
            if (IsDead)
            {
                return;
            }
            characterActionEvent?.Invoke($"{Name}: Taking damage {damage}, Health {Health}");
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
            characterActionEvent?.Invoke($"{Name}: Attacking with magic {character.Name}");
            base.Attack(character);
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
