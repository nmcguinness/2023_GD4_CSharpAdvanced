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
            //made by adding to scene hierarchy, get access to player
            Player p = new Player(5);

            //in a manager (or entity) will register interest
            p.OnAbilityUpdate += HandlePlayerAbilityChange;

            //happens inside Player based on some change (OnCollisionEnter)
            p.IncreaseAbility();

            //in a manager when the manager is destroyed
            p.OnAbilityUpdate -= HandlePlayerAbilityChange;
        }

        private void HandlePlayerAbilityChange()
        {
            Console.Beep(1000, 2000);
            Console.WriteLine("HandlePlayerAbilityChange...");
        }
    }
}