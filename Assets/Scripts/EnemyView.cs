using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

public class EnemyView : MonoBehaviour
{
    public GameObject select;
    public GameObject nameText;
    public GameView game;

    public GameObject hpRemaining;
    public GameObject hpText;

    public int index = 0;

    private const float HP_BAR_WIDTH = 90.0f;

    private const float HP_BAR_HEIGHT = 10.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //suspicious about this function but we'll let it slide
        game = GameObject.Find("Game").GetComponent<GameView>();
        select.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateView(EnemyModel model)
    {
        var hpTMP = hpText.GetComponent<TMPro.TextMeshProUGUI>();
        hpTMP.text = string.Concat(model.hp, "/", model.maxHp);
        var nameTMP = nameText.GetComponent<TMPro.TextMeshProUGUI>();
        nameTMP.text = model.name;

        float fraction = (float) model.hp / (float) model.maxHp;

        var hpSlider = hpRemaining.GetComponent<Slider>();
        hpSlider.value = fraction;

        select.SetActive(model.selected);
    }

    public void Select()
    {
        game.SelectEnemy(index);
    }

}
