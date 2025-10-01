/*
 * Access to GameModel allows access to any component of the game.
 */
using System.Collections.Generic;
using UnityEngine;

public class GameModel
{
    public Deck deck;
    public EventQueue eventQueue;
    public ResourceCountModel resourceCount;
    public DrawPile drawPile;
    public DiscardPile discardPile;
    public HandModel hand;


    public GameModel()
    {
        this.New();
    }

    public void New()
    {
        deck = new Deck();
        eventQueue = new EventQueue();
        resourceCount = new ResourceCountModel();
        drawPile = new DrawPile();
        discardPile = new DiscardPile();
        hand = new HandModel();

        deck.AddCard(new CardModel(Type.Arcane, Letter.A, 1, new ResourceEvent(this, Type.Arcane, 1), "When Drawn, gain 1 Arcane"));
        deck.AddCard(new CardModel(Type.Hemo, Letter.A, 1, new ResourceEvent(this, Type.Hemo, 1), "When Drawn, gain 1 Hemo"));
        deck.AddCard(new CardModel(Type.Holy, Letter.A, 1, new ResourceEvent(this, Type.Holy, 1), "When Drawn, gain 1 Holy"));
        deck.AddCard(new CardModel(Type.Unholy, Letter.A, 1, new ResourceEvent(this, Type.Unholy, 1), "When Drawn, gain 1 Unholy"));
        deck.AddCard(new CardModel(Type.Arcane, Letter.A, 1, new ResourceEvent(this, Type.Arcane, 1), "When Drawn, gain 1 Arcane"));
        deck.AddCard(new CardModel(Type.Hemo, Letter.A, 1, new ResourceEvent(this, Type.Hemo, 1), "When Drawn, gain 1 Hemo"));
        deck.AddCard(new CardModel(Type.Holy, Letter.A, 1, new ResourceEvent(this, Type.Holy, 1), "When Drawn, gain 1 Holy"));
        deck.AddCard(new CardModel(Type.Unholy, Letter.A, 1, new ResourceEvent(this, Type.Unholy, 1), "When Drawn, gain 1 Unholy"));

        drawPile.AddDeck(deck);

        Debug.Log("draw pile size: " + drawPile.Size());

        resourceCount.AddResource(Type.Arcane, 11);
        resourceCount.AddResource(Type.Hemo, 12);
        resourceCount.AddResource(Type.Holy, 13);
        resourceCount.AddResource(Type.Unholy, 14);

    }

    public void QueueEvent(Event e)
    {
        eventQueue.QueueEvent(e);
    }

    public void ExecuteEvent(int num = 1)
    {
        eventQueue.Execute(num);
    }

    public void AddResource(Type type, int count)
    {
        Event addResourceEvent = new ResourceEvent(this, type, count);
        this.QueueEvent(addResourceEvent);
    }

    public void AddCardToTopOfDrawPile(CardModel card)
    {
        Event addCardToTopOfDrawPile = new DrawPileEvent(this, card);
        this.QueueEvent(addCardToTopOfDrawPile);
    }

    public void AddCardToDrawPile(CardModel card)
    {
        Event addCardToDrawPile = new DrawPileEvent(this, card, false);
        this.QueueEvent(addCardToDrawPile);
    }

    public void AddCardsToDrawPile(List<CardModel> cards)
    {
        Event addCardsToDrawPile = new DrawPileEvent(this, cards);
        this.QueueEvent(addCardsToDrawPile);
    }

    public void AddCardToDiscardPile(CardModel card)
    {
        Event addCardToDiscardPile = new DiscardPileEvent(this, card);
        this.QueueEvent(addCardToDiscardPile);
    }

    public void AddCardsToDiscardPile(List<CardModel> cards)
    {
        Event addCardsToDiscardPile = new DiscardPileEvent(this, cards);
        this.QueueEvent(addCardsToDiscardPile);
    }
    public void DrawCard(int num = 1)
    {
        Event drawCard = new DrawCardEvent(this, num);
        this.QueueEvent(drawCard);
    }

    public void DiscardHand()
    {
        Event discardHand = new DiscardHandEvent();
        this.QueueEvent(discardHand);
    }
}
