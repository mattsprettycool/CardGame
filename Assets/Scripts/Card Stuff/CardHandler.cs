using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardHandler : MonoBehaviour {
    [SerializeField]
    Sprite[] cardCostImages;
    public Sprite GetCostImage(int costKey) {
        return cardCostImages[costKey];
    }
}