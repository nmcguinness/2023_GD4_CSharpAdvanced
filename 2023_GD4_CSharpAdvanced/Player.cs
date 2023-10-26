namespace _2023_GD4_CSharpAdvanced
{
    public class Player
    {
        //list storing function references
        public delegate void AbilityUpdateHandler();

        //a flag attached to a list that stores references to subscribed functions
        public event AbilityUpdateHandler OnAbilityUpdate;

        private int abilityLevel;

        public Player(int abilityLevel)
        {
            this.abilityLevel = abilityLevel;
        }

        public void IncreaseAbility()
        {
            abilityLevel++;
            OnAbilityUpdate?.Invoke();
        }
    }
}