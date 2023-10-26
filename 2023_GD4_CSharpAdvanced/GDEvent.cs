namespace _2023_GD4_CSharpAdvanced
{
    public class GDEventParams<P>
    {
        public delegate void EventHandler(P data);

        public event EventHandler OnEvent;

        public void Invoke(P data)
        {
            OnEvent?.Invoke(data);
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