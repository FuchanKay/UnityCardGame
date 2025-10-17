using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DeckModel
{
    private List<CardModel> deck;
    private GameModel game;

    public DeckModel(GameModel game)
    {
        this.New(game);
    }

    public void New(GameModel game)
    {
        deck = new List<CardModel>();
        this.game = game;
    }

    public void AddCard(CardModel card)
    {
        deck.Add(card);
    }

    //questionable if this will ever be used
    public CardModel RemoveAny()
    {
        int index = Random.Range(0, deck.Count);
        var cardModel = deck[index];
        deck.RemoveAt(index);
        return cardModel;
        
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
