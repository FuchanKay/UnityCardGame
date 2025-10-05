/*
 * Access to GameModel allows access to any component of the game.
 */
using System.Collections.Generic;
using UnityEngine;


public enum Mode
{
    Regular,
    ForceDiscard,
    Swap,
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

    public EnemyScreenModel enemyScreen;

    public string description = "";
    public Event currentEvent;
    public GameModel()
    {
        this.New();
    }

    public void New()
    {
        // just in case
        mode = Mode.Regular;
        deck = new DeckModel();
        eventQueue = new EventQueue();
        resourceCount = new ResourceCountModel();
        drawPile = new DrawPileModel();
        discardPile = new DiscardPileModel();
        hand = new HandModel();
        enemyScreen = new EnemyScreenModel();
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

        enemyScreen.AddEnemy(new SkellyEnemy(1));
        enemyScreen.AddEnemy(new SkellyEnemy(2));
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
        hand.Discard(hand.selectedCards);
        discardPile.AddCards(hand.selectedCards);
        for (int i = 0; i < hand.selectedCards.Count; i++)
        {
            //TODO: i feel like this bug is really prone to bugs. if there is a problem with hand good chance its here
            CardModel discarded = hand.selectedCards[i];

            if (discarded.discard)
            {
                //TODO: add when discarded effect
            }
        }
        Debug.Log(hand.discardedCards.Count);
    }
    public void Confirm()
    {
        if (currentEvent.type == EventType.ForceDiscard)
        {
            var forceDiscardEvent = (ForceDiscardEvent) currentEvent;
            if (hand.NumOfSelectedCards() == forceDiscardEvent.count)
            {
                ForceDiscardAllSelected();
                DeselectAllCards();
                SwitchMode(Mode.Regular);
                hand.SetSelectionCount(1);
                description = "";
            }
        }
    }
    //Methods ending with Q will queue the event into event queue
    //Methods not ending with Q will execute instantly
    public void AddResourceQ(Type type, int count)
    {
        Event addResourceEvent = new ResourceEvent(this, type, count);
        this.QueueEvent(addResourceEvent);
    }
    public void AddResource(Type type, int count)
    {
        resourceCount.AddResource(type, count);
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

    public void AddEnemyQ()
    {
        //TODO: make this actually Q
        enemyScreen.AddEnemy(new SkellyEnemy(enemyScreen.NumberOfEnemies() + 1));
    }

    public void AddEnemy(EnemyModel enemy)
    {
        enemyScreen.AddEnemy(enemy);
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
                hand.AddCard(card);
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

        if (count < hand.NonEmptyCount())
        {
            SwitchMode(Mode.ForceDiscard);
            SetSelectionNum(count);
        }
        else
        {
            List<CardModel> cardsToDiscard = new();
            for (int i = 0; i < hand.size; i++)
            {
                if (hand.GetCard(i).type != Type.Empty) cardsToDiscard.Add(hand.GetCard(i));
            }
            hand.Discard(cardsToDiscard);
        }
    }
    public void SelectEnemyQ()
    {
        //Event selectEnemy = new SelectEnemyEvent(this);
        //this.QueueEvent(selectEnemy);
    }

    public void SelectEnemy(int i = 0)
    {

    }

    public void SwapCardsQ()
    {
        Event swap = new SwapEvent(this);
        this.QueueEvent(swap);
    }

    public void SwapCards()
    {
        //TODO: SWAP
    }
}
