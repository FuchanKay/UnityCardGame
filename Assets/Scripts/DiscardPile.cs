using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public class DiscardPile
{
    private List<Card> discardPile;
    public DiscardPile()
    {
        this.New();
    }

    public void New()
    {
        discardPile = new List<Card>();
    }

    public List<Card> Reshuffle()
    {
        List<Card> shuffled = new List<Card>();
        int size = discardPile.Count;
        for (int i = 0; i < size; i++)
        {
            int index = Random.Range(0, discardPile.Count);
            Card removed = discardPile[index];
            discardPile.RemoveAt(index); 
            shuffled.Add(removed);
        }
        return shuffled;
    }

    public void AddCard(Card card)
    {
        discardPile.Add(card);
    }

    public void AddCards(List<Card> cards)
    {
        for (int i = 0; i <= cards.Count; i++)
        {
            Card card = cards[i];
            discardPile.Add(card);
        }
    }

    public int Size()
    {
        return discardPile.Count;
    }
}