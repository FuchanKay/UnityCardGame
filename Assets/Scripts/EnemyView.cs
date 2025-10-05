using UnityEngine;

public class EnemyView : MonoBehaviour
{
    public GameObject select;
    public GameObject nameText;
    public GameObject gameView;

    public GameObject hpRemaining;
    public GameObject hpText;

    private const float HP_BAR_WIDTH = 200.0f;
    private const float HP_BAR_HEIGHT = 20.0f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //suspicious about this function but we'll let it slide
        gameView = GameObject.Find("Game");
        GameView game = gameView.GetComponent<GameView>();
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

        float fraction = model.hp / model.maxHp;

        var hpRT = hpRemaining.GetComponent<RectTransform>();
        hpRT.sizeDelta = new Vector2(HP_BAR_WIDTH * fraction, HP_BAR_HEIGHT);
        Vector3 position = hpRemaining.transform.position;
        position = new Vector3(position.x - HP_BAR_WIDTH * fraction / 4, position.y, position.z);
    }



}
