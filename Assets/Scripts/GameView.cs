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
        //this allows for the events to happen in sequential order, but each event happens instantly which should be changed
        if (game.eventQueue.HasEvent() && !game.eventQueue.isPaused)
        {
            game.ExecuteEvent();
            //when an event is executed, view is automatically reloaded
            this.Reload();
        }
        if (game.mode == Mode.Regular)
        {
            confirmButton.SetActive(false);
            enemyScreen.darken.SetActive(false);
            enemyScreen.SetScreenText("");
        }
        else if (game.mode == Mode.ForceDiscard)
        {
            string text = string.Concat("Discard ", game.hand.selectionCount, " Cards");
            enemyScreen.SetScreenText(text);
            enemyScreen.darken.SetActive(true);
            confirmButton.SetActive(true);
            Reload();
        }
    }
    public void Reload()
    {
        hand.Reload(game);
        resourceCount.Reload(game);
        drawPile.Reload(game);
        discardPile.Reload(game);
        enemyScreen.Reload(game);
    }

    public void ForceDiscard(int i)
    {
        game.ForceDiscardQ(i);
    }

    public void AddEnemy()
    {
        game.AddEnemyQ();
    }

    public void DrawCardInput()
    {
        game.DrawCardQ();
    }
    
    public void DiscardHandInput()
    {
        game.DiscardHandQ();
    }

    public void SelectEnemy()
    {
        game.SelectEnemyQ();
    }

    public void DeselectAll()
    {
        game.DeselectAllCards();
        Reload();
    }
    public void Confirm()
    {
        //TODO: add a visual warning that not all cards are selected
        game.Confirm();
        Reload();
    }


    public void SelectCard(int index)
    {
        game.SelectCard(index);
        Reload();
    }
    public static GameObject CreateCardView(CardModel model)
    {
        var cardObj = Instantiate(cardPrefab);
        var cardView = cardObj.GetComponent<CardView>();
        cardView.model = model;
        //cardObj.transform.position = new(200, 200, 0);
        return cardObj;
    }
}
