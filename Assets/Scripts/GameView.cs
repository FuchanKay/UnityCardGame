using Unity.VisualScripting;
using UnityEngine;

public class GameView : MonoBehaviour
{
    public static GameObject cardPrefab;
    public Canvas canvas;
    public GameModel game;

    public HandView hand;
    public ResourceCountView resourceCount;
    public DrawPileView drawPile;
    public DiscardPileView discardPile;
    public EnemyScreenView enemyScreen;

    public GameObject confirmButton;
    //.setActive(bool);

    void Start()
    {
        Debug.Log("start");
        game = new();
        this.Reload();
    }

    // Update is called once per frame
    void Update()
    {
        //this allows for the events to happen in sequential order, but each event happens instantly which should be fixed
        if (game.eventQueue.HasEvent())
        {
            game.ExecuteEvent();
            //when an event is executed, view is automatically reloaded
            this.Reload();
        }
    }
    public void Reload()
    {
        hand.Reload(game);
        resourceCount.Reload(game);
        drawPile.Reload(game);
        discardPile.Reload(game);
    }

    public void DrawCardInput()
    {
        game.DrawCard();
    }
    
    public void DiscardHandInput()
    {
        game.DiscardHand();
    }
    //TODO: idk if i need 7 methods for this... i think theres a way to pass parameters through buttons but idk how to do it...

    public void DeselectAll()
    {
        game.DeselectAllCards();
        hand.DeselectAllCards();
        Reload();
    }
    public void Confirm()
    {
        Debug.Log("Confirm");
    }

    public void SelectCard1()
    {
        bool selected = game.SelectCard(0);
        hand.SelectCard(0, selected);
        Reload();
    }

    public void SelectCard2()
    {
        bool selected = game.SelectCard(1);
        hand.SelectCard(1, selected);
        Reload();
    }
    public void SelectCard3()
    {
        bool selected = game.SelectCard(2);
        hand.SelectCard(2, selected);
        Reload();
    }

    public void SelectCard4()
    {
        bool selected = game.SelectCard(3);
        hand.SelectCard(3, selected);
        Reload();
    }
    public void SelectCard5()
    {
        bool selected = game.SelectCard(4);
        hand.SelectCard(4, selected);
        Reload();
    }
    public void SelectCard6()
    {
        bool selected = game.SelectCard(5);
        hand.SelectCard(5, selected);
        Reload();
    }
    public void SelectCard7()
    {
        bool selected = game.SelectCard(6);
        hand.SelectCard(6, selected);
        Reload();
    }

    public static GameObject CreateCardView(CardModel model)
    {
        GameObject cardObj = Instantiate(cardPrefab);
        CardView cardView = cardObj.GetComponent<CardView>();
        cardView.model = model;
        //cardObj.transform.position = new(200, 200, 0);
        return cardObj;
    }
}
