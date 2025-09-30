using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardView : MonoBehaviour
{
    public CardModel model;

    public Sprite arcaneImage;
    public Sprite hemoImage;
    public Sprite holyImage;
    public Sprite unholyImage;

    public GameObject rune;
    public GameObject text;

    public bool loaded = false;

    private string letter;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        letter = model.letter.ToString();

        Image sr = rune.GetComponent<Image>();
        TextMeshProUGUI tmp = text.GetComponent<TMPro.TextMeshProUGUI>();
        tmp.text = letter;

        if (model.type == Type.Arcane)
        {
            sr.sprite = arcaneImage;
        }
        else if (model.type == Type.Hemo)
        {
            sr.sprite = hemoImage;
        }
        else if (model.type == Type.Holy)
        {
            sr.sprite = holyImage;
        }
        else if (model.type == Type.Unholy)
        {
            sr.sprite = unholyImage;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
