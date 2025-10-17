using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public class DiscardPileModel
{
    private List<CardModel> discardPile;
    private GameModel game;

    public DiscardPileModel(GameModel game)
    {
        this.New(game);
    }

    public void New(GameModel game)
    {
        discardPile = new();
        this.game = game;
    }

    public List<CardModel> Reshuffle()
    {
        List<CardModel> shuffled = new();
        int size = discardPile.Count;
        for (int i = 0; i < size; i++)
        {
            int index = Random.Range(0, discardPile.Count);
            CardModel removed = discardPile[index];
            discardPile.RemoveAt(index); 
            shuffled.Add(removed);
        }
        return shuffled;
    }

    public void AddCard(CardModel card)
    {
        discardPile.Add(card);
    }

    public void AddCards(List<CardModel> cards)
    {
        for (int i = 0; i < cards.Count; i++)
        {
            CardModel card = cards[i];
            discardPile.Add(card);
        }
    }

    public int Size()
    {
        return discardPile.Count;
    }
}