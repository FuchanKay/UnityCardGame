using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using Unity.VisualScripting;
using UnityEngine;
public class HandModel
{
    public int size = 7;
    List<CardModel> hand;
    public HandModel()
    {
        this.New();
    }

    public void New()
    {
        hand = new List<CardModel>();
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


    public CardModel GetCard(int index)
    {
        return hand[index];
    }

    public CardModel RemoveCard(int index)
    {
        CardModel card = hand[index];
        hand[index] = new CardModel(Type.Empty);
        return card;
    }

    public void Discard(CardModel card)
    {
        //TODO: idk
        return;
    }

}