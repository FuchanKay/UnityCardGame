using System.Collections.Generic;
using UnityEngine;


public enum EventType
{
    Resource,
    DrawPile,
    DiscardPile,
    DrawCard,
    DiscardHand,
    ForceDiscard,
    Swap,
    SelectEnemy,
    AddEnemy,
    AOEDamage,
    SelectedDamage,
    RandomDamage,
}

public abstract class Event
{
    protected GameModel game;
    public EventType type;
    public abstract void Execute();
}

//TODO: Temp data event group
/*
 * event that changes parameters based on events that happened right before need to have temporary data to make sure to avoid bugs
 * for example, damage event that changes damage based on the cards previously discarded
 * dunno how we're going to implement this
 * 
 */


//TODO: Enemy damage event (AOE, TARGET, RANDOM)
//TODO: Player damage event
//TODO: Target enemy event
//TODO: 

public class ResourceEvent : Event
{
    private Type resType;
    private int count;

    //count can be negative
    public ResourceEvent(GameModel game, Type resType, int count)
    {
        type = EventType.Resource;
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
        type = EventType.DrawPile;
        this.game = game;
        this.card = card;
        this.top = top;
    }

    public DrawPileEvent(GameModel game, List<CardModel> cards, bool top)
    {
        type = EventType.DrawPile;
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
        type = EventType.DiscardPile;
        this.game = game;
        this.card = card;
    }

    public DiscardPileEvent(GameModel game, List<CardModel> cards)
    {
        type = EventType.DiscardPile;
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
        type = EventType.DrawCard;
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
        type = EventType.DiscardHand;
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
        type = EventType.ForceDiscard;
        this.count = count;
    }
    public override void Execute()
    {
        game.ForceDiscard(count);
    }
}

public class SwapEvent : Event
{
    public SwapEvent(GameModel game)
    {
        this.game = game;
        type = EventType.Swap;
    }

    public override void Execute()
    {
        game.SwapCards();
    }
}

public class AddEnemyEvent : Event
{
    public EnemyModel enemy;
    public AddEnemyEvent(GameModel game, EnemyModel enemy)
    {
        this.game = game;
        this.enemy = enemy;
        type = EventType.AddEnemy;
    }

    public override void Execute()
    {
        game.AddEnemy(enemy);
    }

}

public class AOEDamageEvent : Event
{
    public int dmg;

    public AOEDamageEvent(GameModel game, int dmg)
    {
        this.game = game;
        this.dmg = dmg;
        type = EventType.AOEDamage;
    }

    public override void Execute()
    {
        game.AOEDamage(this.dmg);
    }
}

public class SelectedDamageEvent : Event
{
    public int dmg;

    public SelectedDamageEvent(GameModel game, int dmg)
    {
        this.game = game;
        this.dmg = dmg;
        type = EventType.SelectedDamage;
    }

    public override void Execute()
    {
        game.SelectedDamage(this.dmg);
    }
}

public class RandomDamageEvent : Event
{
    public int dmg;
    public RandomDamageEvent(GameModel game, int dmg)
    {
        this.game = game;
        this.dmg = dmg;
        type = EventType.RandomDamage;
    }

    public override void Execute()
    {
        game.RandomDamage(this.dmg);
    }
}

