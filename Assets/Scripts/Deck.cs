using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Deck
{
    private List<Card> deck;

    public Deck()
    {
        this.New();
    }

    public void New()
    {
        deck = new List<Card>();
    }

    public void AddCard(Card card)
    {
        deck.Add(card);
    }

    //questionable if this will ever be used
    public Card RemoveAny()
    {
        int index = Random.Range(0, deck.Count);
        Card card = deck[index];
        deck.RemoveAt(index);
        return card;
        
    }
    public int Size()
    {
        return deck.Count;
    }
    public void RemoveCard(Card card)
    {
        deck.Remove(card);
    }

    public Card Get(int index)
    {
        return deck[index];
    }
}
