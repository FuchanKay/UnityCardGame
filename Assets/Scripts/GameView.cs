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
        hand.Reload(game.hand);
        resourceCount.Reload(game.resourceCount);
        drawPile.Reload(game.drawPile);
        discardPile.Reload(game.discardPile);
    }

    public void DrawCardInput()
    {
        game.DrawCard();
    }

    public void DiscardHandInput()
    {
        game.DiscardHand();
    }

    public void SelectCard1()
    {
        Debug.Log("Card 1 Selected");
    }

    public void SelectCard2()
    {
        Debug.Log("Card 2 Selected");
    }
    public void SelectCard3()
    {

    }

    public void SelectCard4()
    {

    }
    public void SelectCard5()
    {

    }

    public void SelectCard6()
    {

    }
    public void SelectCard7()
    {

    }

    public static GameObject CreateCardView(CardModel model)
    {
        GameObject cardObj = Instantiate(cardPrefab);
        //cardObj.name = model.type.ToString() + " " + model.letter.ToString();
        CardView cardView = cardObj.GetComponent<CardView>();
        cardView.model = model;
        //cardObj.transform.position = new(200, 200, 0);
        return cardObj;
    }
}
