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
                if (obj.gameObject.tag.Equals("CardArt")) obj.gameObject.GetComponent<Image>().sprite = myCard.artwork;
            foreach (Transform obj in gameObject.GetComponentsInChildren<Transform>())
                if (obj.gameObject.tag.Equals("CardName")) obj.gameObject.GetComponent<Text>().text = myCard.cardName;
            foreach (Transform obj in gameObject.GetComponentsInChildren<Transform>())
                if (obj.gameObject.tag.Equals("CardDescription")) obj.gameObject.GetComponent<Text>().text = myCard.description;
            foreach (Transform obj in gameObject.GetComponentsInChildren<Transform>())
                if (obj.gameObject.tag.Equals("CardCostText")) obj.gameObject.GetComponent<Text>().text = ""+myCard.cost;
        }
    }
}
