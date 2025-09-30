using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class Hand
{
    private const int maxHandSize = 7;
    List<Card> hand;
    DrawPile drawPile;
    DiscardPile discardPile
    public Hand(DrawPile drawPile, DiscardPile discardPile)
    {
        this.New();
        //not sure if i want this in the new function or in here idk well see
        drawPile = drawPile;
        discardPile = discardPile;
    }

    public void New()
    {
        hand = new List<Card>();
        for (int i = 0; i < maxHandSize; i++)
        {
            hand.Insert(0, new Card(Type.Empty));
        }
    }

}