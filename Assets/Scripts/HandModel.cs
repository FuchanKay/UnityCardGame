using System.Collections.Generic;
public class HandModel
{
    public int size = 7;
    public int selectionNum = 1;
    private CardModel descriptionCard;
    private List<CardModel> hand;
    public List<CardModel> selectedCards;
    public HandModel()
    {
        this.New();
    }

    public void New()
    {
        hand = new List<CardModel>();
        selectedCards = new List<CardModel>();
        descriptionCard = new CardModel(Type.Empty);
        for (int i = 0; i < size; i++)
        {
            //hand will never not be empty. It will always contain 7 cards of type Empty. Empty is not a real card type, it just signifies that there is no card within that hand slot
            hand.Insert(0, new CardModel(Type.Empty));
        }
    }

    public void DeselectAllCards()
    {
        for (int i = 0; i < hand.Count; i++)
        {
            hand[i].selected = false;
        }
        descriptionCard = new CardModel(Type.Empty);
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
        if (card.selected && selectedCards.Count < selectionNum)
        {
            selectedCards.Insert(0, card);
            descriptionCard = card;
        }
        else if (card.selected && selectedCards.Count == selectionNum)
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
            descriptionCard = new CardModel(Type.Empty);
        }
        return card.selected;
    }

    public CardModel getDescriptionCard()
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
        hand[index] = new CardModel(Type.Empty);
        return removed;
    }

    public CardModel RemoveCard(CardModel card)
    {
        var removed  = new CardModel(Type.Empty);
        for (int i = 0; i < hand.Count; i++)
        {
            if (hand[i] == card)
            {
                hand[i] = new CardModel(Type.Empty);
                removed = card;
            }
        }
        return removed;
    }

    public void Discard(CardModel card)
    {
        //TODO: idk
        return;
    }

    public int numOfSelectedCards()
    {
        return selectedCards.Count;
    }

    public void setSelectionNum(int selectionNum)
    {
        this.selectionNum = selectionNum;
    }
}