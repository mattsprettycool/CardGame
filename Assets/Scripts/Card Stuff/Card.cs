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

    public int[,] encodedEffectArray;

    public enum Effects { None, NumericalDamage, MaterialBasedDamage, Draw, Heal }

    public enum Materials { None, Munitions, Energy }

    public enum DamageTypes { None, Gun, Explosive }

    public int effArrSize = 0;
    public int prevArrSize = 0;

    public Effects[] myEffects = new Effects[0];
    public int[] myValues = new int[0];
    public int[] myExtraValues = new int[0];

    //stuff to mostly ignore
    public Materials[] myMaterials = new Materials[0];
    public DamageTypes[] myDamageTypes = new DamageTypes[0];
    //end

    public int curCostCount = 0;
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

        GUILayout.BeginHorizontal();
        GUILayout.Label("Number of cost types:", GUILayout.Width(130));
        card.curCostCount = EditorGUILayout.IntSlider(card.curCostCount, 0, 6);
        GUILayout.EndHorizontal();
        if (card.curCostCount > 6) card.curCostCount = 6;
        for (int i = 0; i < card.curCostCount; i++)
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

        GUILayout.BeginHorizontal();
        GUILayout.Label("Number of effects:", GUILayout.Width(110));
        card.effArrSize = EditorGUILayout.IntSlider(card.effArrSize, 0, 20);
        GUILayout.EndHorizontal();

        if (card.prevArrSize != card.effArrSize)
        {
            UpdateEncodedArrays(card.effArrSize);
            card.prevArrSize = card.effArrSize;
        }
        card.encodedEffectArray = new int[card.effArrSize,3];
        for(int i = 0; i < card.effArrSize; i++)
        {
            GUILayout.BeginHorizontal();
            GUILayout.Label("Effect Type #" + i + ":", GUILayout.Width(100));
            card.myEffects[i] = (Card.Effects)EditorGUILayout.EnumPopup(card.myEffects[i]);
            GUILayout.EndHorizontal();
            if ((int)card.myEffects[i] == 1)
            {
                GUILayout.BeginHorizontal();
                GUILayout.Label("Damage Type #" + i + ":", GUILayout.Width(130));
                card.myDamageTypes[i] = (Card.DamageTypes)EditorGUILayout.EnumPopup(card.myDamageTypes[i]);
                GUILayout.EndHorizontal();
            }
            else
                card.myDamageTypes[i] = (Card.DamageTypes)0;
            if ((int)card.myEffects[i] == 2)
            {
                GUILayout.BeginHorizontal();
                GUILayout.Label("Material Type #" + i + ":", GUILayout.Width(100));
                card.myMaterials[i] = (Card.Materials)EditorGUILayout.EnumPopup(card.myMaterials[i]);
                GUILayout.EndHorizontal();
            }
            else
                card.myMaterials[i] = (Card.Materials)0;
            GUILayout.BeginHorizontal();
            GUILayout.Label("Effect Modifier #" + i + ":", GUILayout.Width(150));
            card.myValues[i] = EditorGUILayout.IntField(card.myValues[i]);
            GUILayout.EndHorizontal();
            card.encodedEffectArray[i, 0] = (int)card.myEffects[i];
            card.encodedEffectArray[i, 1] = card.myValues[i];
            card.encodedEffectArray[i, 2] = card.myExtraValues[i];
        }
    }

    void UpdateEncodedArrays(int arrSize)
    {
        var card = target as Card;
        EditorUtility.SetDirty(card);

        Card.Effects[] tempMyEffects = new Card.Effects[arrSize];
        int[] tempMyValues = new int[arrSize];
        int[] tempMyExtraValues = new int[arrSize];

        Card.Materials[] tempMyMaterials = new Card.Materials[arrSize];
        Card.DamageTypes[] tempMyDamageTypes = new Card.DamageTypes[arrSize];

        for (int i = 0; i < arrSize; i++)
        {
            if (card.myEffects.Length >= i+1)
            {
                tempMyEffects[i] = card.myEffects[i];
                tempMyValues[i] = card.myValues[i];
                tempMyExtraValues[i] = card.myExtraValues[i];

                tempMyMaterials[i] = card.myMaterials[i];
                tempMyDamageTypes[i] = card.myDamageTypes[i];

            }
            else
                break;
        }
        card.myEffects = new Card.Effects[arrSize];
        card.myValues = new int[arrSize];
        card.myExtraValues = new int[arrSize];

        card.myMaterials = new Card.Materials[arrSize];
        card.myDamageTypes = new Card.DamageTypes[arrSize];

        for (int i = 0; i < arrSize; i++)
        {
            card.myEffects[i] = tempMyEffects[i];
            card.myValues[i] = tempMyValues[i];
            card.myExtraValues[i] = tempMyExtraValues[i];

            card.myMaterials[i] = tempMyMaterials[i];
            card.myDamageTypes[i] = tempMyDamageTypes[i];
        }
    }
}
