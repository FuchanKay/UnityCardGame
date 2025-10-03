using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.XR;


public enum EventTypes
{
    Resource,
    DrawPile,
    DiscardPile,
    DrawCard,
    DiscardHand,
    ForceDiscard
}

public abstract class Event
{
    protected GameModel game;
    public EventTypes type;
    public abstract void Execute();
}
//TODO: Enemy damage event (AOE, TARGET, RANDOM)
//TODO: Player damage event
//TODO: Target enemy event
//TODO: Force discard card(s) event (hard)
//TODO: 

public class ResourceEvent : Event
{
    private Type resType;
    private int count;

    //count can be negative
    public ResourceEvent(GameModel game, Type resType, int count)
    {
        type = EventTypes.Resource;
        this.game = game;
        this.resType = resType;
        this.count = count;
    }

    public override void Execute()
    {
        game.AddResource(resType, count);
    }
}

public class DrawPileEvent : Event
{
    private CardModel? card;
    private List<CardModel>? cards;
    private bool top;

    public DrawPileEvent(GameModel game, CardModel card, bool top = true)
    {
        type = EventTypes.DrawPile;
        this.game = game;
        this.card = card;
        this.top = top;
    }

    public DrawPileEvent(GameModel game, List<CardModel> cards, bool top)
    {
        type = EventTypes.DrawPile;
        this.game = game;
        this.cards = cards;
        this.top = top;
    }

    public override void Execute()
    {
        if (card != null)
        {
            this.game.AddCardToDrawPile(card, top);
        }
        else if (cards != null)
        {
            this.game.AddCardsToDrawPile(cards, top);
        }
    }
}

public class DiscardPileEvent : Event
{
    private CardModel? card;
    private List<CardModel>? cards;

    public DiscardPileEvent(GameModel game, CardModel card)
    {
        type = EventTypes.DiscardPile;
        this.game = game;
        this.card = card;
    }

    public DiscardPileEvent(GameModel game, List<CardModel> cards)
    {
        type = EventTypes.DiscardPile;
        this.game = game;
        this.cards = cards;
    }

    public override void Execute()
    {
        if (card != null)
        {
            this.game.AddCardToDiscardPile(card);
        }
        else if (cards != null)
        {
            this.game.AddCardsToDiscardPile(cards);
        }
    }
}

public class DrawCardEvent : Event
{
    private int count;

    public DrawCardEvent(GameModel game, int count)
    {
        type = EventTypes.DrawCard;
        this.game = game;
        this.count = count;
    }

    public override void Execute()
    {
        game.DrawCard(count);
    }
}

public class DiscardHandEvent : Event
{
    
    public DiscardHandEvent(GameModel game)
    {
        type = EventTypes.DiscardHand;
        this.game = game;
    }
    public override void Execute()
    {
        game.DiscardHand();
    }
}

public class ForceDiscardEvent : Event
{
    public int count;
    public ForceDiscardEvent(GameModel game, int count)
    {
        this.game = game;
        type = EventTypes.ForceDiscard;
        this.count = count;
    }
    public override void Execute()
    {
        game.ForceDiscard(count);
    }
}

