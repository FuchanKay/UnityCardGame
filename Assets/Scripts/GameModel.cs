/*
 * Access to GameModel allows access to any component of the game.
 */
using System.Collections.Generic;
using Unity.VisualScripting;


public enum Mode
{
    Regular,
    ForceDiscard,
    EnemySelection
}

public class GameModel
{
    public Mode mode = Mode.Regular;
    public DeckModel deck;
    public EventQueue eventQueue;
    public ResourceCountModel resourceCount;
    public DrawPileModel drawPile;
    public DiscardPileModel discardPile;
    public HandModel hand;
    public CardModel lastCardSelected;

    public string description = "";
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
    public void QueueEvent(Event e)
    {
        eventQueue.QueueEvent(e);
    }
    public void ExecuteEvent()
    {
        currentEvent = eventQueue.Execute();
    }

    public void SetSelectionNum(int count)
    {
        hand.SetSelectionCount(count);
    }

    public void SwitchMode(Mode mode)
    {
        this.mode = mode;
        if (mode == Mode.ForceDiscard)
        {
            eventQueue.Pause(true);
        }
        else if (mode == Mode.Regular)
        {
            eventQueue.Pause(false);
        }
    }
    public void SelectCard(int index)
    {
        hand.SelectCard(index);
        description = hand.GetDescriptionCard().generateDescription();
    }

    public void DeselectAllCards()
    {
        hand.DeselectAllCards();
        description = "";
    }

    public void ForceDiscardAllSelected()
    {
        for (int i = 0; i < hand.selectedCards.Count; i++)
        {
            var discarded = hand.RemoveCard(hand.selectedCards[i]);
            discardPile.AddCard(discarded);
            if (discarded.discard)
            {
                //TODO: add when discarded effect
            }
        }
    }
    public void Confirm()
    {
        if (currentEvent.type == EventTypes.ForceDiscard)
        {
            var forceDiscardEvent = (ForceDiscardEvent) currentEvent;
            if (hand.NumOfSelectedCards() == forceDiscardEvent.count)
            {
                ForceDiscardAllSelected();
                DeselectAllCards();
                SwitchMode(Mode.Regular);
                description = "";
            }
        }
    }
    //Methods ending with Q will queue the event into event queue
    public void AddResourceQ(Type type, int count)
    {
        Event addResourceEvent = new ResourceEvent(this, type, count);
        this.QueueEvent(addResourceEvent);
    }
    public void AddResource(Type type, int count)
    {

    }
    public void AddCardToDrawPileQ(CardModel card, bool top)
    {
        Event addCardToDrawPile = new DrawPileEvent(this, card, top);
        this.QueueEvent(addCardToDrawPile);
    }

    public void AddCardToDrawPile(CardModel card, bool top)
    {
        if (top)
        {
            drawPile.AddCardTop(card);
        }
        else
        {
            drawPile.AddCard(card);
        }
    }

    public void AddCardsToDrawPileQ(List<CardModel> cards)
    {
        Event addCardsToDrawPile = new DrawPileEvent(this, cards, true);
        this.QueueEvent(addCardsToDrawPile);
    }

    public void AddCardsToDrawPile(List<CardModel> cards, bool top)
    {
        if (top)
        {
            drawPile.AddCardsTop(cards);
        }
        else
        {
            drawPile.AddCards(cards);
        }
    }

    public void AddCardToDiscardPileQ(CardModel card)
    {
        Event addCardToDiscardPile = new DiscardPileEvent(this, card);
        this.QueueEvent(addCardToDiscardPile);
    }

    public void AddCardToDiscardPile(CardModel card)
    {
        discardPile.AddCard(card);
    }

    public void AddCardsToDiscardPileQ(List<CardModel> cards)
    {
        Event addCardsToDiscardPile = new DiscardPileEvent(this, cards);
        this.QueueEvent(addCardsToDiscardPile);
    }

    public void AddCardsToDiscardPile(List<CardModel> cards)
    {
        discardPile.AddCards(cards);
    }

    public void DrawCardQ(int num = 1)
    {
        Event drawCard = new DrawCardEvent(this, num);
        this.QueueEvent(drawCard);
    }

    public void DrawCard(int count = 1)
    {
        for (int i = 0; i < count; i++)
        {
            if (drawPile.Size() > 0 && !hand.IsFull())
            {
                CardModel card = this.drawPile.DrawCard();
                bool found = this.hand.AddCard(card);
                card.whenDrawn.Execute();
                //TODO: add a visual indicator that hand is full if found is true
            }
            else if (discardPile.Size() > 0 && !hand.IsFull())
            {
                List<CardModel> shuffled = discardPile.Reshuffle();
                drawPile.AddCards(shuffled);
                CardModel card = this.drawPile.DrawCard();
                bool found = this.hand.AddCard(card);
                card.whenDrawn.Execute();
                //TODO: add a visual indicator that hand is full if found is true
            }
        }
    }
    public void DiscardHandQ()
    {
        Event discardHand = new DiscardHandEvent(this);
        //TODO: idk if this is necessary but putting this here jic
        this.QueueEvent(discardHand);
    }

    public void DiscardHand()
    {
        for (int i = 0; i < hand.size; i++)
        {
            CardModel card = hand.RemoveCard(i);
            if (card.type != Type.Empty)
            {
                discardPile.AddCard(card);
            }
        }
        hand.DeselectAllCards();
    }


    public void ForceDiscardQ(int num = 1)
    {
        Event forceDiscard = new ForceDiscardEvent(this, num);
        this.QueueEvent(forceDiscard);
    }

    public void ForceDiscard(int count)
    {
        DeselectAllCards();
        for (int i = 0; count >= hand.NonEmptyCount() && hand.NonEmptyCount() > 0; i++)
        {
            var discarded = hand.RemoveCard(hand.GetFirstNonEmptyIndex());
            discardPile.AddCard(discarded);
            //TODO: add when discarded event to this
        }
        if (count < hand.NonEmptyCount())
        {
            SwitchMode(Mode.ForceDiscard);
            SetSelectionNum(count);
        }
    }
}
