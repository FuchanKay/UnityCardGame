using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using Unity.VisualScripting;
using UnityEngine;
public class Hand
{
    public int size = 7;
    List<Card> hand;
    public Hand()
    {
        this.New();
    }

    public void New()
    {
        hand = new List<Card>();
        for (int i = 0; i < size; i++)
        {
            //hand will never not be empty. It will always contain 7 cards of type Empty. Empty is not a real card type, it just signifies that there is no card within that hand slot
            hand.Insert(0, new Card(Type.Empty));
        }
    }

    public void DeselectAllCards()
    {
        for (int i = 0; i < hand.Count; i++)
        {
            hand[i].selected = false;
        }
    }

    public bool addCard(Card card)
    {
        int emptyIndex = 0;
        bool found = false;
        for (int i = 0; i < hand.Count && !found; i++)
        {
            Card c = hand[i];
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

    public Card getCard(int index)
    {
        return hand[index];
    }

    public Card removeCard(int index)
    {
        Card card = hand[index];
        hand[index] = new Card(Type.Empty);
        return card;
    }

    public void discard(Card card)
    {
        //TODO: idk
        return;
    }

}