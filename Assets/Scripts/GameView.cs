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
        bool hasEvent = game.eventQueue.HasEvent();
        if (hasEvent)
        {
            game.ExecuteEvent();
            this.Reload();
        }
    }

    public void DrawCardInput()
    {
        game.DrawCard();
    }

    public void DiscardHandInput()
    {
        game.DiscardHand();
    }

    public void Reload()
    {
        hand.Reload(game.hand);
        resourceCount.Reload(game.resourceCount);
        drawPile.Reload(game.drawPile);
        discardPile.Reload(game.discardPile);
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
