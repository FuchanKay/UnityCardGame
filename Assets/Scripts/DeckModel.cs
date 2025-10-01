using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DeckModel
{
    private List<CardModel> deck;

    public DeckModel()
    {
        this.New();
    }

    public void New()
    {
        deck = new List<CardModel>();
    }

    public void AddCard(CardModel card)
    {
        deck.Add(card);
    }

    //questionable if this will ever be used
    public CardModel RemoveAny()
    {
        int index = Random.Range(0, deck.Count);
        CardModel card = deck[index];
        deck.RemoveAt(index);
        return card;
        
    }
    public int Size()
    {
        return deck.Count;
    }
    public void RemoveCard(CardModel card)
    {
        deck.Remove(card);
    }

    public CardModel Get(int index)
    {
        return deck[index];
    }
}
