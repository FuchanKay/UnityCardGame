using UnityEngine;

public abstract class Event
{
    protected GameModel game;
    public abstract void Execute();
}

public class ResourceEvent : Event
{
    private Type type;
    private int count;

    //count can be negative
    public ResourceEvent(GameModel game, Type type, int count)
    {
        this.game = game;
        this.type = type;
        this.count = count;
    }

    public override void Execute()
    {
        game.AddResource(type, count);
    }
}