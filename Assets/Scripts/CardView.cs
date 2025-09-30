using UnityEngine;
using UnityEngine.UI;

public class CardView : MonoBehaviour
{
    private CardModel model;
    private Image arcaneImage;
    public GameObject x;

    private const string ALPHABET= "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    private string letter;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        letter = "" + ALPHABET[(int)model.letter];
        letterObj.getComponent
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
