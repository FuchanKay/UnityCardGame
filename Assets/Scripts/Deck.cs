using System.Collections.Generic;

public class Deck
{
    private List<Card> deck;

    public Deck()
    {
        deck = new List<Card>();
    }

    public void AddCard(Card card)
    {
        deck.Add(card);
    }

    public void RemoveCard(Card card)
    {
        deck.Remove(card);
    }
}
