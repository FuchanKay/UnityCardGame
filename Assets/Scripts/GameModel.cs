/*
 * Access to GameModel allows access to any component of the game.
 */
public class GameModel
{
    private Deck deck;
    private EventQueue eventQueue;
    private ResourceCount resourceCount;


    public GameModel()
    {
        this.New();
    }

    public void New()
    {
        deck = new Deck();
        eventQueue = new EventQueue();
        resourceCount = new ResourceCount();
    }

    public void QueueEvent(Event e)
    {
        eventQueue.QueueEvent(e);
    }

    public void ExecuteEvent(int num)
    {
        eventQueue.Execute(num);
    }

    public void AddResource(Type type, int count)
    {
        resourceCount.AddResource(type, count); 
    }
}