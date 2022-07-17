using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CharacterModel.Util;

namespace CharacterModel.Collection
{
    public class CharacterCollection:IEnumerable<Character>
    {
        private List<Character> _characters = new List<Character>();
        private readonly Random _random = new Random();
        private event Action<string> _ListActions = FileLogger.LogMessage;
        public int Count
        {
            get => _characters.Count;
        }

        public Character GetWinner()
        {
            if (Count < 1)
            {
                return null;
            }
            Character winner = _characters.FirstOrDefault();
            _ListActions.Invoke($"Winner is {winner.Name}");
            return winner;
        }
        public void RemoveDeathCharacters()
        {
            List<Character> deadCharacters = new List<Character>();
            foreach (Character character in _characters)
            {
                if (character.IsDead)
                {
                    deadCharacters.Add(character);
                }
            }
            foreach (Character character in deadCharacters)
            {
                _characters.Remove(character);
            }
        }

        public void AddRange(IEnumerable<Character> characters)
        {
            _characters.AddRange(characters);
            foreach (Character character in _characters)
            {
                _ListActions.Invoke($"{character.Name} is joining the battle");
            }
        }

        public void Clear()
        {
            _characters.Clear();
            _ListActions.Invoke($"The battle is cleared");
        }
        public void Remove(Character character)
        {
            _characters.Remove(character);
            _ListActions.Invoke($"{character.Name} is out of the battle");
        }
        public void Add(Character character)
        {
            _characters.Add(character);
            _ListActions.Invoke($"{character.Name} is joining the battle");
        }
        public Character GetRandom()
        {
            return _characters[_random.Next(_characters.Count)];
        }
        public IEnumerator<Character> GetEnumerator()
        {
            return _characters.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
