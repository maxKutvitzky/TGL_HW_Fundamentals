using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CharacterModel.Collection;
using CharacterModel.Model;

namespace CharacterModel.Battle
{
    public class BattleManager
    {
        private Random _random = new Random();
        public CharacterCollection _characters = new CharacterCollection();

        public void RandomFillBattle(int quantity)
        {
            for (int i = 0; i < quantity; i++)
            {
                int classIdx = _random.Next(1, 3);
                switch (classIdx)
                {
                    case 1:
                        _characters.Add(new Warrior(100, $"Warrior{i}"));
                        break;
                    case 2:
                        _characters.Add(new Archer(100, $"Archer{i}"));
                        break;
                    case 3:
                        _characters.Add(new Mage(100, $"Mage{i}"));
                        break;
                }
            }
        }

        public Character Fight()
        {
            while (_characters.Count > 1)
            {
                Character character1 = _characters.GetRandom();
                Character character2 = _characters.GetRandom();
                character1.Attack(character2);
                character2.Attack(character1);
                _characters.RemoveDeathCharacters();
            }
            return _characters.GetWinner();
        }
    }
}
