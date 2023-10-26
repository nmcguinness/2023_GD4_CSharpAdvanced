using System;

namespace _2023_GD4_CSharpAdvanced
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            new Program().Start();
            Console.ReadKey();
        }

        private void Start()
        {
            //made by adding to scene hierarchy, get access to player
            Player p = new Player("max", 5);

            //in a manager (or entity) will register interest
            p.OnAbilityUpdate += HandlePlayerAbilityChange;
            p.OnAbilityUpdate += AnotherHandlePlayerAbilityChange;

            p.OnTriggerEnter += HandleTriggerAnimation;

            //to register for new improved GDEvent
            p.OnPlayerDie.Register(HandlePlayerDie);

            //happens inside Player based on some change (OnCollisionEnter)
            p.IncreaseAbility();

            //happens inside Player based on colliding with trigger
            p.HandleTriggerCollision();

            //call the die event
            p.MakePlayerDie();

            //in a manager when the manager is destroyed
            p.OnAbilityUpdate -= HandlePlayerAbilityChange;
            p.OnTriggerEnter -= HandleTriggerAnimation;
            p.OnPlayerDie.Deregister(HandlePlayerDie);
        }

        private void HandlePlayerDie()
        {
            Console.WriteLine("HandlePlayerDie...");
        }

        private void HandleTriggerAnimation(object sender, int triggerID)
        {
            Player p = sender as Player; //as will set to null on fail
            //Player p1 = (Player)sender; //old-style typecast that throws exception on fail

            if (p != null)
            {
                //if this was e.g. WeaponManager lets access player weapons layout and upgrade a weapon
                p.AbilityLevel += 100;
                Console.WriteLine("Upgraded player level +100");
            }
        }

        private void AnotherHandlePlayerAbilityChange(string id, int level)
        {
            Console.WriteLine("AnotherHandlePlayerAbilityChange");
        }

        private void HandlePlayerAbilityChange(string a, int b)
        {
            // Console.Beep(1000, 2000);
            Console.WriteLine($"HandlePlayerAbilityChange...({a},{b})");
        }
    }
}