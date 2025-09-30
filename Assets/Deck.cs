using Card;
using System.Collections.Generic;

public class Deck {
    private List<Card> deck;


    public Deck()
    {
        this.deck = new List<Card>();
    }

    public void addCard(Card card)
    {
        this.deck.Add(card);
    }

    public void removeCard(Card card)
    {
        this.deck.Remove(card);
    }
}