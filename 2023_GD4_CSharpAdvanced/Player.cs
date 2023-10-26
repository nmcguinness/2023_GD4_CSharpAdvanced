namespace _2023_GD4_CSharpAdvanced
{
    public class Player
    {
        //list storing function references
        public delegate void AbilityUpdateHandler(string id, int level);

        //a flag attached to a list that stores references to subscribed functions
        public event AbilityUpdateHandler OnAbilityUpdate;

        private int abilityLevel;
        private string id;

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
    }
}