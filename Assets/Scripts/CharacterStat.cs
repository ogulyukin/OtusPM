using System;
//using Sirenix.OdinInspector;

namespace Lessons.Architecture.PM
{
    public sealed class CharacterStat
    {
        public event Action<int> OnValueChanged;

        public CharacterStat(string statName, int statvalue)
        {
            Name = statName;
            Value = statvalue;
        }

        //[ShowInInspector, ReadOnly]
        public string Name { get; private set; }

        //[ShowInInspector, ReadOnly]
        public int Value { get; private set; }

        //[Button]
        public void ChangeValue(int value)
        {
            this.Value = value;
            this.OnValueChanged?.Invoke(value);
        }
    }
}