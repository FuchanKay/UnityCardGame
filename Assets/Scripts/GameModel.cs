/*
 * Access to GameModel allows access to any component of the game.
 */
using System.Collections.Generic;

public class GameModel
{
    public Deck deck;
    public EventQueue eventQueue;
    public ResourceCount resourceCount;
    public DrawPile drawPile;
    public DiscardPile discardPile;
    public Hand hand;


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
        Event addResourceEvent = new ResourceEvent(this, type, count);
        this.QueueEvent(addResourceEvent);
    }

    public void AddCardToTopOfDrawPile(Card card)
    {
        Event addCardToTopOfDrawPile = new DrawPileEvent(this, card);
        this.QueueEvent(addCardToTopOfDrawPile);
    }

    public void AddCardToDrawPile(Card card)
    {
        Event addCardToDrawPile = new DrawPileEvent(this, card, false);
        this.QueueEvent(addCardToDrawPile);
    }

    public void AddCardsToDrawPile(List<Card> cards)
    {
        Event addCardsToDrawPile = new DrawPileEvent(this, cards);
        this.QueueEvent(addCardsToDrawPile);
    }

    public void AddCardToDiscardPile(Card card)
    {
        Event addCardToDiscardPile = new DiscardPileEvent(this, card);
        this.QueueEvent(addCardToDiscardPile);
    }

    public void AddCardsToDiscardPile(List<Card> cards)
    {
        Event addCardsToDiscardPile = new DiscardPileEvent(this, cards);
        this.QueueEvent(addCardsToDiscardPile);
    }
}
