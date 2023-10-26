using System;

namespace _2023_GD4_CSharpAdvanced
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            new Program().Start();
        }

        private void Start()
        {
            Player p = new Player(5);

            p.OnAbilityUpdate += HandlePlayerAbilityChange;

            p.IncreaseAbility();

            p.OnAbilityUpdate -= HandlePlayerAbilityChange;
        }

        private void HandlePlayerAbilityChange()s

        {
            Console.Beep(1000, 2000);
            Console.WriteLine("HandlePlayerAbilityChange...");
        }
}
}