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

    public void AddDeck(Deck deck)
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
    public void AddCard(Card card)
    {
        drawPile.Insert(Random.Range(0, drawPile.Count), card);
    }

    public void AddCardTop(Card card)
    {
        drawPile.Insert(0, card);
    }
    public void AddCards(List<Card> cards)
    {
        for (int i = cards.Count - 1; i >= 0; i--)
        {
            drawPile.Insert(0, cards[i]);
        }
    }

    public int Size()
    {
        return drawPile.Count;
    }

    public Card DrawCard()
    {
        if (drawPile.Count >= 0)
        {
            Card firstCard = drawPile[0];
            drawPile.RemoveAt(0);
            return firstCard;
        }
        return null;
        //I think this else statement is unnecessary? as long as DrawCard is only executed within the DrawEvent class
        //else
        //{
        //    return null;
        //}

    }
}