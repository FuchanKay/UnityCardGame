using System.Collections.Generic;
using UnityEngine;

public abstract class Event
{
    protected GameModel game;
    public abstract void Execute();
}
//TODO: Enemy damage event (AOE, TARGET, RANDOM)
//TODO: Player damage event
//TODO: Target enemy event
//TODO: Force discard card(s) event (hard)
//TODO: 

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
        game.resourceCount.AddResource(type, count);
    }
}

public class DrawPileEvent : Event
{
    private CardModel? card;
    private List<CardModel>? cards;
    private bool top;

    public DrawPileEvent(GameModel game, CardModel card, bool top = true)
    {
        this.game = game;
        this.card = card;
        this.top = top;
    }

    public DrawPileEvent(GameModel game, List<CardModel> cards)
    {
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

    public DiscardPileEvent(GameModel game, CardModel card, bool top = true)
    {
        this.game = game;
        this.card = card;
    }

    public DiscardPileEvent(GameModel game, List<CardModel> cards, bool top = true)
    {
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
        this.count = count;
    }

    public override void Execute()
    {
        for (int i = 0; i < count; i++)
        {
            if (this.game.drawPile.Size() > 0)
            {
                CardModel card = this.game.drawPile.DrawCard();
            }
            else if (this.game.discardPile.Size() > 0)
            {
                List<CardModel> shuffled = this.game.discardPile.Reshuffle();
                this.game.drawPile.AddCards(shuffled);
            }
        }

    }
}

public class DiscardAllCardsEvent : Event
{
    
    public DiscardAllCardsEvent()
    {

    }
    public override void Execute()
    {
        for (int i = 0; i < game.hand.size; i++)
        {
            CardModel card = game.hand.removeCard(i);
            if (card.type != Type.Empty)
            {
                game.discardPile.AddCard(card);
            }
        }
    }
}