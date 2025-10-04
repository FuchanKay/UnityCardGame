using TMPro;
using UnityEngine;

public class EnemyScreenView : MonoBehaviour
{
    public GameObject descriptionBox;
    public GameObject descriptionBoxBG;
    public GameObject screenText;
    public GameObject darken;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetScreenText(string text)
    {
        TextMeshProUGUI screenTextTMP = screenText.GetComponent<TMPro.TextMeshProUGUI>();
        screenTextTMP.text = text;

    }
    public void Reload(GameModel game)
    {
        TextMeshProUGUI descriptionTMP = descriptionBox.GetComponent<TMPro.TextMeshProUGUI>();
        if (game.description == "")
        {
            descriptionBoxBG.SetActive(false);
            descriptionTMP.text = "";
        }
        else
        {
            descriptionBoxBG.SetActive(true);
            descriptionTMP.text = game.description;
        }
    }
}
