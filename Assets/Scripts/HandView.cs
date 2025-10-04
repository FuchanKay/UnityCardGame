using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HandView : MonoBehaviour
{
    private const float selectedScale = 0.24f;
    private const float defaultScale = 0.2f;
    public List<GameObject> cardViews;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Reload(GameModel game)
    {
        HandModel hand = game.hand;
        for (int i = 0; i < hand.size; i++)
        {
            CardModel cardModel = hand.GetCard(i);

            CardView cardView = cardViews[i].GetComponent<CardView>();

            if (cardModel.selected)
            {
                RectTransform rectangle = cardView.GetComponent<RectTransform>();
                rectangle.localScale = new Vector3(selectedScale, selectedScale, selectedScale);
            }
            else
            {
                RectTransform rectangle = cardView.GetComponent<RectTransform>();
                rectangle.localScale = new Vector3(defaultScale, defaultScale, defaultScale);
            }

            cardView.UpdateView(cardModel);
        }
    }
} 
