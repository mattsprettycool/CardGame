using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardReader : MonoBehaviour {
    [SerializeField]
    Card myCard;
    void Start () {
        if (myCard != null)
        {
            foreach (Transform obj in gameObject.GetComponentsInChildren<Transform>())
            {
                if (obj.gameObject.tag.Equals("CardArt")) obj.gameObject.GetComponent<Image>().sprite = myCard.artwork;
                if (obj.gameObject.tag.Equals("CardName")) obj.gameObject.GetComponent<Text>().text = myCard.cardName;
                if (obj.gameObject.tag.Equals("CardDescription")) obj.gameObject.GetComponent<Text>().text = myCard.description;
                if (obj.gameObject.tag.Equals("CardCostText")) obj.gameObject.GetComponent<Text>().text = "" + myCard.cost;
                if (obj.gameObject.tag.Equals("CardCost")) obj.GetComponent<Image>().sprite = SetCostIcon(myCard.CostTypeToEnum());
            }
        }
    }
    Sprite SetCostIcon(int costKey)
    {
        return GameObject.FindGameObjectWithTag("CardHandler").GetComponent<CardHandler>().GetCostImage(costKey);
    }
}
