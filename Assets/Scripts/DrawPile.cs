using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
public class DrawPile
{
    private List<Card> drawPile;

    public DrawPile()
    {
        this.New();
    }

    public void New()
    {
        drawPile = new List<Card>();
    }

    public void addDeck(Deck deck)
    {
        List<Card> deckCopy = new List<Card>();
        for (int i = 0; i < deck.Size(); i++)
        {
            deckCopy.Add(deck.Get(i));
        }
        int size = deckCopy.Count;
        for (int i = 0; i < size; i++)
        {
            int index = Random.Range(0, deckCopy.Count);
            Card card = deckCopy[index];
            deckCopy.RemoveAt(index);
            drawPile.Add(card);
        }
    }
    public void addCards(List<Card> cards)
    {
        List<Card> deckCopy = new List<Card>();
        for (int i = 0; i < cards.Count; i++)
        {
            deckCopy.Add(cards[i]);
        }
        int size = deckCopy.Count;
        for (int i = 0; i < size; i++)
        {
            int index = Random.Range(0, deckCopy.Count);
            Card card = deckCopy[index];
            deckCopy.RemoveAt(index);
            drawPile.Add(card);
        }
    }
    public void addCard(Card card)
    {
        drawPile.Insert(Random.Range(0, drawPile.Count), card);
    }

    public Card drawCard()
    {
        Card firstCard = drawPile[0];
        drawPile.RemoveAt(0);
        return firstCard;
    }
}