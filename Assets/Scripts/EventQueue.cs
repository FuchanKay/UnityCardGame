using System.Collections.Generic;
public class EventQueue
{
    private Queue<Event> queue;
    public bool isPaused = false;
    
    public EventQueue()
    {
        queue = new Queue<Event>();
    }

    public void Clear()
    {
        queue.Clear();
    }

    public void Pause(bool pause = true)
    {
        isPaused = pause;
    }

    public void QueueEvent(Event e) {
        queue.Enqueue(e);
    }
        
    public bool HasEvent()
    {
        return queue.Count > 0;
    }

    public Event Execute()
    {
        Event e = queue.Dequeue();
        e.Execute();
        return e;
    }
}
