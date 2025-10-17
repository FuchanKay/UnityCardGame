using System.Collections.Generic;
public class HandModel
{
    public int size = Constants.handSize;
    public int selectionCount = 1;
    public CardModel descriptionCard;
    private List<CardModel> hand;

    private GameModel game;

    public List<CardModel> selectedCards;

    public List<CardModel> discardedCards;

    public HandModel(GameModel game)
    {
        this.New(game);
    }

    public void New(GameModel game)
    {
        this.game = game;
        hand = new List<CardModel>();
        selectedCards = new List<CardModel>();
        descriptionCard = new CardModelEmpty();
        for (int i = 0; i < size; i++)
        {
            //hand will never not be empty. It will always contain 7 cards of type Empty. Empty is not a real card type, it just signifies that there is no card within that hand slot
            hand.Insert(0, new CardModelEmpty());
        }
    }

    public void DeselectAllCards()
    {
        for (int i = 0; i < hand.Count; i++)
        {
            hand[i].selected = false;
        }
        for (int i = 0; i < selectedCards.Count; i++)
        {
            selectedCards.RemoveAt(i);
        }
        descriptionCard = new CardModelEmpty();
    }

    public bool AddCard(CardModel card)
    {
        int emptyIndex = 0;
        bool found = false;
        for (int i = 0; i < hand.Count && !found; i++)
        {
            CardModel c = hand[i];
            if (c.type == Type.Empty)
            {
                emptyIndex = i;
                found = true;
            }
        }
        if (found)
        {
            hand[emptyIndex] = card;
        }
        return found;
    }

    public int NonEmptyCount()
    {
        int count = 0;
        for (int i = 0; i < hand.Count; i++)
        {
            if (hand[i].type != Type.Empty)
            {
                count++;
            }
        }
        return count;
    }

    public bool IsFull()
    {
        bool isFull = true;
        for (int i = 0; i < hand.Count && isFull; i++)
        {
            CardModel c = hand[i];
            if (c.type == Type.Empty)
            {
                isFull = false;
            }
        }
        return isFull;
    }

    public bool SelectCard(int index)
    {
        CardModel card = hand[index];
        card.selected = !card.selected;
        if (card.type == Type.Empty)
        {
            card.selected = false;
        }
        if (card.selected && selectedCards.Count < selectionCount)
        {
            selectedCards.Insert(0, card);
            descriptionCard = card;
        }
        else if (card.selected && selectedCards.Count == selectionCount)
        {
            selectedCards.Insert(0, card);
            descriptionCard = card;
            CardModel removed = selectedCards[selectedCards.Count - 1];
            selectedCards.RemoveAt(selectedCards.Count - 1);
            removed.selected = false;
        }
        else if (!card.selected)
        {
            selectedCards.Remove(card);
        }
        if (!card.selected && descriptionCard == card)
        {
            descriptionCard = new CardModelEmpty();
        }
        return card.selected;
    }

    public CardModel GetDescriptionCard()
    {
        return descriptionCard;
    }

    public CardModel GetCard(int index)
    {
        return hand[index];
    }

    public int GetFirstNonEmptyIndex()
    {
        for (int i = 0; i < hand.Count; i++)
        {
            CardModel card = hand[i];
            if (card.type != Type.Empty)
            {
                return i;
            }
        }
        return -1;
    }

    public CardModel RemoveCard(int index)
    {
        CardModel removed = hand[index];
        hand[index] = new CardModelEmpty();
        for (int i = 0; i < selectedCards.Count; i++)
        {
            CardModel card = selectedCards[i];
            if (card == removed)
            {
                selectedCards.Remove(card);
                card.selected = false;
            }
        }
        return removed;
    }

    public CardModel RemoveCard(CardModel card)
    {
        CardModel removed  = new CardModelEmpty();
        for (int i = 0; i < hand.Count; i++)
        {
            if (hand[i] == card)
            {
                hand[i] = new CardModelEmpty();
                removed = card;
            }
        }
        return removed;
    }

    public void Discard(List<CardModel> cards)
    {
        discardedCards = cards;
        for (int i = 0; i < cards.Count; i++)
        {
            CardModel card = cards[i];
            card.selected = false;
            RemoveCard(card);
        }
    }

    public int NumOfSelectedCards()
    {
        return selectedCards.Count;
    }

    public void SetSelectionCount(int selectionCount)
    {
        this.selectionCount = selectionCount;
    }
}