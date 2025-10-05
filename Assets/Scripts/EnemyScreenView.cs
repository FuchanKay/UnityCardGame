using JetBrains.Annotations;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyScreenView : MonoBehaviour
{
    public GameObject descriptionBox;
    public GameObject descriptionBoxBG;
    public GameObject screenText;
    public GameObject darken;

    public GameObject enemyPrefab;

    private List<GameObject> enemies = new();

    private const float yCoordinate = 20.0f;

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
        float width = GetComponent<RectTransform>().sizeDelta.x;
        EnemyScreenModel model = game.enemyScreen;
        float fraction = 1.0f / ((float)model.NumberOfEnemies() + 1);
        for (int i = enemies.Count; i < model.NumberOfEnemies(); i++)
        {
            GameObject enemyObj = Instantiate(enemyPrefab);
            enemies.Add(enemyObj);
            enemyObj.transform.SetParent(this.transform);
        }
        for (int i = 0; i < enemies.Count; i++)
        {
            GameObject enemyObj = enemies[i];
            EnemyModel enemyModel = model.GetEnemy(i);
            enemyObj.transform.position = new Vector3((this.transform.position.x - width / 2) + (width * (i + 1) * fraction), this.transform.position.y + yCoordinate, 0);
            EnemyView enemyView = enemyObj.GetComponent<EnemyView>();
            enemyView.UpdateView(enemyModel);
        }
        //for (int i = 0; i < model.NumberOfEnemies(); i++)
        //{

        //}
    }
}
