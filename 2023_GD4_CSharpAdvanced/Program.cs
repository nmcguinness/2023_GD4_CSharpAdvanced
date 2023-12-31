﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
            //Console.WriteLine("\n********** DemoEvents **********");
            //DemoEvents();

            //Console.WriteLine("\n********** DemoBlockingWait **********");
            //DemoBlockingWait();

            //Console.WriteLine("\n********** DemoAsync **********");
            //DemoAsync();

            //Console.WriteLine("\n********** DemoAsyncAwaitReturn **********");
            //DemoAsyncAwaitReturn();

            //Console.WriteLine("\n********** DemoAsyncAwaitAll **********");
            DemoAsyncAwaitAllAsync();
        }

        private void DemoBlockingWait()
        {
            Console.WriteLine("doing some work...");

            DoSomethingBlocking();

            Console.WriteLine("doing more work...");
        }

        private void DoSomethingBlocking()
        {
            Console.WriteLine("in...");

            System.Threading.Thread.Sleep(2000);

            Console.WriteLine("out...");
        }

        private async void DemoAsyncAwaitReturn()
        {
            Console.WriteLine("DemoAsyncAwaitReturn::doing some work...");
            Task<int> queryTask = ExecuteDBQueryNonBlocking();

            await queryTask;

            Console.WriteLine("DemoAsyncAwaitReturn::doing more work...");
            Console.WriteLine($"DB says: {queryTask.Result}");
        }

        public async Task<int> ExecuteDBQueryNonBlocking()
        {
            Console.WriteLine("ExecuteDBQueryNonBlocking::in...");
            await Task.Delay(5000);
            Console.WriteLine("ExecuteDBQueryNonBlocking::out...");
            return 100;
        }

        private void DemoAsync()
        {
            Console.WriteLine("DemoAsync::doing some work...");
            DoSomethingNonBlocking();
            Console.WriteLine("DemoAsync::doing more work...");
        }

        private async void DoSomethingNonBlocking()
        {
            Console.WriteLine("DoSomethingNonBlocking::in...");
            await Task.Delay(2000);
            Console.WriteLine("DoSomethingNonBlocking::out...");
        }

        /*
        Exercise:
        - Generate 3 async methods (with random Delay()) where each method does NOT return a value
        - Wait for all methods to complete before printing out a string ("ALL COMPLETE")
        */

        private async void DemoAsyncAwaitAllAsync()
        {
            Console.WriteLine("All tasks are starting...");
            await TaskOne(1000);
            await TaskTwo(3000);
            Console.WriteLine("All tasks are done...");
        }

        public async Task TaskOne(int delay)
        {
            await Task.Delay(delay);
            Console.WriteLine("TaskOne::out...");
        }

        public async Task TaskTwo(int delay)
        {
            await Task.Delay(delay);
            Console.WriteLine("TaskOne::out...");
        }

        /*
        Exercise:
        - Generate 3 async methods (with random Delay()) where each method returns a value
        - Wait for all methods to complete before printing out the sum
         */

        public async void FindNextTarget(List<Task> tasks)
        {
            Console.WriteLine("All tasks are starting...");
            Task<string> t1 = FindWeakestEnemy();
            Task<string> t2 = FindWeakestVehicle();
            // List<Task> myTasks = new List<Task> { t1, t2 };
            await Task.WaitAny(t1, t2);
            Console.WriteLine("All tasks are done...");
        }

        public async Task<string> FindWeakestEnemy() //List<GameObject> objects, Comparator<GameObject> sortComparator
        {
            await Task.Delay(2500);
            Console.WriteLine("FindWeakestEnemy::out...");
            return "enemy 14";
        }

        public async Task<string> FindWeakestVehicle()
        {
            await Task.Delay(1500);
            Console.WriteLine("FindWeakestVehicle::out...");
            return "Tank 5";
        }

        #region Events

        private void DemoEvents()
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

            /*********************************************************/
            p.OnLevelComplete.Register(HandleLevelComplete);

            p.HandleLevelComplete();

            p.OnLevelComplete.Deregister(HandleLevelComplete);
        }

        private void HandleLevelComplete(int completionTimeSecs)
        {
            Console.WriteLine($"HandleLevelComplete...{completionTimeSecs}");
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

        #endregion Events
    }
}