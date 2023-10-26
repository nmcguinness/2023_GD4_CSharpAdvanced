namespace _2023_GD4_CSharpAdvanced
{
    public class Player
    {
        //list storing function references
        public delegate void AbilityUpdateHandler(string id, int level);

        //a flag attached to a list that stores references to subscribed functions
        public event AbilityUpdateHandler OnAbilityUpdate;

        //totally separate event with its own delegate (a list of function refs)
        public delegate void TriggerEnterHandler(object sender, int triggerID);

        public event TriggerEnterHandler OnTriggerEnter;

        //its much simpler and faster to add an event using GDEvent
        public GDEvent OnPlayerDie = new GDEvent();

        //an example of multi-param event
        public GDEventParams<int> OnLevelComplete = new GDEventParams<int>();

        private int abilityLevel;
        private string id;

        public int AbilityLevel { get => abilityLevel; set => abilityLevel = value; }
        public string Id { get => id; set => id = value; }

        public Player(string id, int abilityLevel)
        {
            this.id = id;
            this.abilityLevel = abilityLevel;
        }

        public void IncreaseAbility()
        {
            abilityLevel++;
            OnAbilityUpdate?.Invoke(id, abilityLevel); //abilityLevel, id
        }

        public void HandleTriggerCollision()
        {
            OnTriggerEnter?.Invoke(this, 1001);
        }

        public void MakePlayerDie()
        {
            OnPlayerDie?.Invoke();
        }

        public void HandleLevelComplete()
        {
            OnLevelComplete?.Invoke(60000); //60 secs to complete
        }
    }
}