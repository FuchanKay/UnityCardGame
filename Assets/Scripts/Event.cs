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
        game.resourceCount.AddResource(resType, count);
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

    public DrawPileEvent(GameModel game, List<CardModel> cards)
    {
        type = EventTypes.DrawPile;
        this.game = game;
        this.cards = cards;
        this.top = false;
    }

    public override void Execute()
    {
        if (card != null && top)
        {
            this.game.drawPile.AddCardTop(card);
        }
        else if (card != null && !top)
        {
            this.game.drawPile.AddCard(card);
        }
        else if (cards != null)
        {
            this.game.drawPile.AddCards(cards);
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
            this.game.discardPile.AddCard(card);
        }
        else if (cards != null)
        {
            this.game.discardPile.AddCards(cards);
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
        for (int i = 0; i < count; i++)
        {
            if (this.game.drawPile.Size() > 0 && !this.game.hand.IsFull())
            {
                CardModel card = this.game.drawPile.DrawCard();
                bool found = this.game.hand.AddCard(card);
                game.QueueEvent(card.whenDrawn);
                //TODO: add a visual indicator that hand is full if found is true
            }
            else if (this.game.discardPile.Size() > 0 && !this.game.hand.IsFull())
            {
                List<CardModel> shuffled = this.game.discardPile.Reshuffle();
                this.game.drawPile.AddCards(shuffled);
                CardModel card = this.game.drawPile.DrawCard();
                bool found = this.game.hand.AddCard(card);
                game.QueueEvent(card.whenDrawn);
                //TODO: add a visual indicator that hand is full if found is true
            }
        }

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
        for (int i = 0; i < game.hand.size; i++)
        {
            CardModel card = game.hand.RemoveCard(i);
            if (card.type != Type.Empty)
            {
                game.discardPile.AddCard(card);
            }
        }
        game.hand.DeselectAllCards();
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
        for (int i = 0; count <= game.hand.NonEmptyCount() && game.hand.NonEmptyCount() > 0; i++)
        {
            var discarded = game.hand.RemoveCard(game.hand.GetFirstNonEmptyIndex());
            game.discardPile.AddCard(discarded);
            //TODO: add when discarded event to this
        }
    }
}

