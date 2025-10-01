using System.Collections.Generic;
using UnityEngine;
public class DrawPileModel
{
    private List<CardModel> drawPile;

    public DrawPileModel()
    {
        this.New();
    }

    public void New()
    {
        drawPile = new List<CardModel>();
    }

    public void AddDeck(DeckModel deck)
    {
        List<CardModel> deckCopy = new List<CardModel>();
        for (int i = 0; i < deck.Size(); i++)
        {
            deckCopy.Add(deck.Get(i));
        }
        int size = deckCopy.Count;
        for (int i = 0; i < size; i++)
        {
            int index = Random.Range(0, deckCopy.Count);
            CardModel card = deckCopy[index];
            deckCopy.RemoveAt(index);
            drawPile.Add(card);
        }
    }
    public void AddCard(CardModel card)
    {
        drawPile.Insert(Random.Range(0, drawPile.Count), card);
    }

    public void AddCardTop(CardModel card)
    {
        drawPile.Insert(0, card);
    }
    public void AddCards(List<CardModel> cards)
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

    public CardModel DrawCard()
    {
        if (drawPile.Count >= 0)
        {
            CardModel firstCard = drawPile[0];
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