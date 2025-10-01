using Unity.VisualScripting;
using UnityEngine;

public class GameView : MonoBehaviour
{
    public static GameObject cardPrefab;
    public Canvas canvas;
    public GameModel game;

    public HandView hand;
    public ResourceCountView resourceCount;


    void Start()
    {
        game = new();
        this.Reload();
    }

    // Update is called once per frame
    void Update()
    {
        bool hasEvent = game.eventQueue.HasEvent();
        if (hasEvent)
        {
            Debug.Log("executed");
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
    }

    public static GameObject CreateCardView(CardModel model)
    {
        GameObject cardObj = Instantiate(cardPrefab);
        cardObj.name = model.type.ToString() + " " + model.letter.ToString();
        CardView cardView = cardObj.GetComponent<CardView>();
        cardView.model = model;
        //cardObj.transform.position = new(200, 200, 0);
        return cardObj;
    }
}
