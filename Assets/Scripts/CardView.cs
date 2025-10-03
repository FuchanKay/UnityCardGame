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

    public Sprite normalBodyImage;
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
        this.model = model;
        var runeImg = rune.GetComponent<Image>();
        var tmp = text.GetComponent<TMPro.TextMeshProUGUI>();
        var sprite = arcaneImage;
        runeImg.enabled = true;
        letter = model.letter.ToString();
        var bodyImg = body.GetComponent<Image>();
        bodyImg.sprite = normalBodyImage;
        if (model.type == Type.Hemo) sprite = hemoImage;
        else if (model.type == Type.Holy) sprite = holyImage;
        else if (model.type == Type.Unholy) sprite = unholyImage;
        else if (model.type == Type.Empty)
        {
            runeImg.enabled = false;
            runeImg.sprite = sprite;
            letter = "";
            bodyImg.sprite = grayBodyImage;
        }
        tmp.text = letter;
        runeImg.sprite = sprite;
    }

}
