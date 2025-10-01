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

    public Sprite grayBodyImage;

    public GameObject rune;
    public GameObject text;
    public GameObject body;

    private string letter;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.model = new(Type.Empty);
        this.UpdateModel(model);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateModel(CardModel model)
    {
        Image runeImg = rune.GetComponent<Image>();
        TextMeshProUGUI tmp = text.GetComponent<TMPro.TextMeshProUGUI>();
        Sprite img = arcaneImage;
        runeImg.enabled = true;
        letter = model.letter.ToString();
        if (model.type == Type.Hemo) img = hemoImage;
        else if (model.type == Type.Holy) img = holyImage;
        else if (model.type == Type.Unholy) img = unholyImage;
        else if (model.type == Type.Empty)
        {
            runeImg.enabled = false;
            runeImg.sprite = img;
            letter = "";
            Image bodyImg = body.GetComponent<Image>();
            bodyImg.sprite = grayBodyImage;
        }
        tmp.text = letter;
        runeImg.sprite = img;
    }

}
