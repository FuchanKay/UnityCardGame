namespace ResourceEvent
using Event;
using Card;

public class ResourceEvent : Event
{
    private Game game;
    private Type Type;
    private int count;
    public ResourceEvent(Game game, Type type, int count)
    {

    }

    public override void execute()
    {

    }
}