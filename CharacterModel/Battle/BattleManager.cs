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
        private CharacterCollection _characters = new CharacterCollection();

        public CharacterCollection GetCharacters()
        {
            return _characters;
        }

        public void AddWarrior(string name)
        {
            Warrior warrior = new Warrior(100, name);
            _characters.Add(warrior);
        }
        public void AddArcher(string name)
        {
            Archer archer = new Archer(100, name);
            _characters.Add(archer);
        }
        public void AddMage(string name)
        {
            Mage mage = new Mage(100, name);
            _characters.Add(mage);
        }

        public void ClearBattle()
        {
            _characters.Clear();
        }
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
                Character character1;
                Character character2;
                while (true)
                {
                    Character ch1 = _characters.GetRandom();
                    Character ch2 = _characters.GetRandom();
                    if (ch1 != ch2)
                    {
                        character1 = ch1;
                        character2 = ch2;
                        break;
                    }
                }
                character1.Attack(character2);
                character2.Attack(character1);
                _characters.RemoveDeathCharacters();
            }

            Character winner = _characters.GetWinner();
            ClearBattle();
            return winner;
        }
    }
}
