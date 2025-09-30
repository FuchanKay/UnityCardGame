using System.Collections.Generic;
public class EventQueue
{
    private Queue<Event> queue;
    
    public EventQueue()
    {
        queue = new Queue<Event>();
    }

    public void Clear()
    {
        queue.Clear();
    }

    public void QueueEvent(Event e) {
        queue.Enqueue(e);
    }
        
    public void Execute(int num = 1)
    {
        for (int i = 0 ; i < num; i++)
        {
            Event e = queue.Dequeue();
            e.Execute();
        }
    }
}
