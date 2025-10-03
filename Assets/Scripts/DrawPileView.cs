using TMPro;
using UnityEngine;

public class DrawPileView : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Reload(GameModel game)
    {
        DrawPileModel drawPile = game.drawPile;
        var tmp = this.GetComponent<TMPro.TextMeshProUGUI>();
        tmp.text = string.Concat(drawPile.Size(), " Cards in the Draw Pile"); 
    }

}
