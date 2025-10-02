/*
 * Access to GameModel allows access to any component of the game.
 */
using System.Collections.Generic;
using UnityEngine;

public class GameModel
{
    public DeckModel deck;
    public EventQueue eventQueue;
    public ResourceCountModel resourceCount;
    public DrawPileModel drawPile;
    public DiscardPileModel discardPile;
    public HandModel hand;

    public Event currentEvent;
    public GameModel()
    {
        this.New();
    }

    public void New()
    {
        deck = new DeckModel();
        eventQueue = new EventQueue();
        resourceCount = new ResourceCountModel();
        drawPile = new DrawPileModel();
        discardPile = new DiscardPileModel();
        hand = new HandModel();

        //original deck for now
        deck.AddCard(new CardModel(Type.Arcane, Letter.A, 1, new ResourceEvent(this, Type.Arcane, 1), "When Drawn, gain 1 Arcane"));
        deck.AddCard(new CardModel(Type.Hemo, Letter.B, 1, new ResourceEvent(this, Type.Hemo, 1), "When Drawn, gain 1 Hemo"));
        deck.AddCard(new CardModel(Type.Holy, Letter.C, 1, new ResourceEvent(this, Type.Holy, 1), "When Drawn, gain 1 Holy"));
        deck.AddCard(new CardModel(Type.Unholy, Letter.D, 1, new ResourceEvent(this, Type.Unholy, 1), "When Drawn, gain 1 Unholy"));
        deck.AddCard(new CardModel(Type.Arcane, Letter.E, 1, new ResourceEvent(this, Type.Arcane, 1), "When Drawn, gain 1 Arcane"));
        deck.AddCard(new CardModel(Type.Hemo, Letter.F, 1, new ResourceEvent(this, Type.Hemo, 1), "When Drawn, gain 1 Hemo"));
        deck.AddCard(new CardModel(Type.Holy, Letter.G, 1, new ResourceEvent(this, Type.Holy, 1), "When Drawn, gain 1 Holy"));
        deck.AddCard(new CardModel(Type.Unholy, Letter.H, 1, new ResourceEvent(this, Type.Unholy, 1), "When Drawn, gain 1 Unholy"));
        deck.AddCard(new CardModel(Type.Arcane, Letter.A, 1, new ResourceEvent(this, Type.Arcane, 1), "When Drawn, gain 1 Arcane"));
        deck.AddCard(new CardModel(Type.Hemo, Letter.B, 1, new ResourceEvent(this, Type.Hemo, 1), "When Drawn, gain 1 Hemo"));
        deck.AddCard(new CardModel(Type.Holy, Letter.C, 1, new ResourceEvent(this, Type.Holy, 1), "When Drawn, gain 1 Holy"));
        deck.AddCard(new CardModel(Type.Unholy, Letter.D, 1, new ResourceEvent(this, Type.Unholy, 1), "When Drawn, gain 1 Unholy"));
        deck.AddCard(new CardModel(Type.Arcane, Letter.E, 1, new ResourceEvent(this, Type.Arcane, 1), "When Drawn, gain 1 Arcane"));
        deck.AddCard(new CardModel(Type.Hemo, Letter.F, 1, new ResourceEvent(this, Type.Hemo, 1), "When Drawn, gain 1 Hemo"));
        deck.AddCard(new CardModel(Type.Holy, Letter.G, 1, new ResourceEvent(this, Type.Holy, 1), "When Drawn, gain 1 Holy"));
        deck.AddCard(new CardModel(Type.Unholy, Letter.H, 1, new ResourceEvent(this, Type.Unholy, 1), "When Drawn, gain 1 Unholy"));

        //adds deck to draw pile
        drawPile.AddDeck(deck);

        //test resource count for now
        resourceCount.AddResource(Type.Arcane, 11);
        resourceCount.AddResource(Type.Hemo, 12);
        resourceCount.AddResource(Type.Holy, 13);
        resourceCount.AddResource(Type.Unholy, 14);

    }

    public bool SelectCard(int index)
    {
        bool selected = hand.SelectCard(index);
        return selected;
    }

    public void DeselectAllCards()
    {
        hand.DeselectAllCards();
    }

    public void QueueEvent(Event e)
    {
        eventQueue.QueueEvent(e);
    }

    public void ExecuteEvent()
    {
        currentEvent = eventQueue.Execute();
        //if (currentEvent.type == EventTypes.ForceDiscard)
        //{

        //}
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
        Event discardHand = new DiscardHandEvent(this);
        //TODO: idk if this is necessary but putting this here jic
        hand.DeselectAllCards();
        this.QueueEvent(discardHand);
    }
}
