using UnityEngine;

public class GameView : MonoBehaviour
{
    public GameObject card;
    public Canvas canvas;
    private GameModel game;

    void Start()
    {
        game = new GameModel();
        GameObject cardObj = Instantiate(card);
        CardView cardView = cardObj.GetComponent<CardView>();
        cardView.model = new CardModel(Type.Arcane, Letter.A, 1, new ResourceEvent(game, Type.Arcane, 1), "When Drawn, gain 1 Arcane");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
