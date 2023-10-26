namespace _2023_GD4_CSharpAdvanced
{
    public class GDEvent
    {
        public delegate void EventHandler();

        public event EventHandler OnEvent;

        public void Invoke()
        {
            OnEvent?.Invoke();
        }

        public void Register(EventHandler handler)
        {
            OnEvent += handler;
        }

        public void Deregister(EventHandler handler)
        {
            OnEvent -= handler;
        }
    }
}