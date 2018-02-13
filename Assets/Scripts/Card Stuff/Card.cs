using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class Card : ScriptableObject {

    public string cardName;
    public string description;

    public Sprite artwork;

    public int cost;

    public enum CostType {Default, Test}

    public CostType myCardCost;

    public int CostTypeToEnum()
    {
        return (int)myCardCost;
    }
}
