using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HandView : MonoBehaviour
{
    public List<GameObject> cardViews;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Reload(HandModel hand)
    {
        for (int i = 0; i < hand.size; i++)
        {
            CardModel cardModel = hand.GetCard(i);

            CardView cardView = cardViews[i].GetComponent<CardView>();

            cardView.UpdateModel(cardModel);
        }
    }
}
