using Unity.VisualScripting;
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
        cardView.model = new CardModel(Type.Holy, Letter.B, 1, new ResourceEvent(game, Type.Holy, 1), "When Drawn, gain 1 Holy");
        cardObj.transform.position = new Vector3(100, 100, 0);
        cardObj.transform.SetParent(canvas.transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
