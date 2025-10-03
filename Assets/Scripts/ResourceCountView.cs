using TMPro;
using UnityEngine;

public class ResourceCountView : MonoBehaviour
{
    public GameObject arcaneCount, hemoCount, holyCount, unholyCount;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Reload(GameModel game)
    {
        ResourceCountModel RC = game.resourceCount;
        var arcaneTMP = arcaneCount.GetComponent<TMPro.TextMeshProUGUI>();
        var hemoTMP = hemoCount.GetComponent<TMPro.TextMeshProUGUI>();
        var holyTMP = holyCount.GetComponent<TMPro.TextMeshProUGUI>();
        var unholyTMP = unholyCount.GetComponent<TMPro.TextMeshProUGUI>();

        arcaneTMP.text = RC.arcaneCount.ToString();
        hemoTMP.text = RC.hemoCount.ToString();
        holyTMP.text = RC.holyCount.ToString();
        unholyTMP.text = RC.unholyCount.ToString();
    }
}
