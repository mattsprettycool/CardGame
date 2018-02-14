using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class Card : ScriptableObject {

    public string cardName;
    public string description;

    public Sprite artwork;

    public int[] costs = new int[6];

    public enum CostType {None, Default, Test, DefaultTab, Energy, Munitions}

    public CostType[] myCardCosts = new CostType[6];
    
}

[CustomEditor(typeof(Card))]
public class CardEditor : Editor
{
    public override void OnInspectorGUI()
    {
        var card = target as Card;
        EditorUtility.SetDirty(card);

        GUILayout.BeginHorizontal();
        GUILayout.Label("Card Name:", GUILayout.Width(75));
        card.cardName = GUILayout.TextField(card.cardName);
        GUILayout.EndHorizontal();

        GUILayout.Label("Card Description:");
        card.description = GUILayout.TextArea(card.description);
        
        card.artwork = EditorGUILayout.ObjectField("Card Artwork:",card.artwork, typeof(Sprite), false) as Sprite;

        for(int i = 0; i < 6; i++)
        {
            GUILayout.BeginHorizontal();
            GUILayout.Label("Card Cost #"+i+":", GUILayout.Width(100));
            card.costs[i] = EditorGUILayout.IntField(card.costs[i]);
            GUILayout.EndHorizontal();
            GUILayout.BeginHorizontal();
            GUILayout.Label("Card Cost Type #" + i + ":", GUILayout.Width(150));
            card.myCardCosts[i] = (Card.CostType)EditorGUILayout.EnumPopup(card.myCardCosts[i]);
            GUILayout.EndHorizontal();
        }
    }
}
