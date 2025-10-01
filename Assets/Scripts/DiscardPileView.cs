using TMPro;
using UnityEngine;

public class DiscardPileView : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Reload(DiscardPileModel discardPile)
    {
        TextMeshProUGUI tmp = this.GetComponent<TMPro.TextMeshProUGUI>();
        tmp.text = string.Concat(discardPile.Size(), " Cards in the Discard Pile");
    }

}
