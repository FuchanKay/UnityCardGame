namespace EventQueue;
using System.Collections.Generic;
using Event;

public class EventQueue : MonoBehaviour
{
    private Queue<Event> queue;
   
    public EventQueue()
    {
        this.queue = new Queue<Event>();
    }

    public void clear()
    {
        this.queue.Clear();
    }

    public void enqueue(Event e) {
        this.queue.Enqueue(e);
    }
    
    public void execute(int num = 1)
    {
        for (int i =0 ; i < num; i++)
        {
            Event e = this.queue.Dequeue();
            e.execute();
        }
    }
}
