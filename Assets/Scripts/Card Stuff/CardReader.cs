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
                if(obj.gameObject.tag.Length==13)
                if (obj.gameObject.tag.Substring(0,12).Equals("CardCostText"))
                {
                    int arraySpot = int.Parse(obj.gameObject.tag.Substring(12,1))-1;
                    obj.gameObject.GetComponent<Text>().text = "" + myCard.costs[arraySpot];
                    if (myCard.costs[arraySpot] == 0) obj.gameObject.GetComponent<Text>().text = "";
                }
                if (obj.gameObject.tag.Length == 9)
                if (obj.gameObject.tag.Substring(0,8).Equals("CardCost"))
                {
                    int arraySpot = int.Parse(obj.gameObject.tag.Substring(8,1))-1;
                    obj.GetComponent<Image>().sprite = SetCostIcon((int)myCard.myCardCosts[arraySpot]);
                }
            }
        }
    }
    Sprite SetCostIcon(int costKey)
    {
        return GameObject.FindGameObjectWithTag("CardHandler").GetComponent<CardHandler>().GetCostImage(costKey);
    }
}
