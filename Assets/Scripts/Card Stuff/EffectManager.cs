﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour {
    [SerializeField]
    Card c;
	void Update () {
        if (Input.GetKeyDown(KeyCode.E))
            DoEffect(c, 0, 0);
	}
    //0 = none, 1 = numerical damage, 2 = material damage, 3 = draw, 4 = heal
    void DoEffect(Card c, int x, int y)
    {
        //int[,] testEffect = { { 1, 2 }, { 2, 4 }, { 3, 1 } };
        for(int i = 0; i < c.effectTypeArr.GetLength(0); i++)
        {//NEEDS 2 MODS
            switch (c.effectTypeArr[i])
            {
                case 0:
                    break;
                case 1:
                    DoNumericalDamage(c.mod1Arr[i], x, y);
                    break;
                case 2:
                    DoMaterialBasedDamage(c.mod1Arr[i], x, y);
                    break;
                case 3:
                    DoDraw(c.mod1Arr[i], x, y);
                    break;
                case 4:
                    DoHeal(c.mod1Arr[i], x, y);
                    break;
            }
        }
    }

    void DoNumericalDamage(int mod, int x, int y)
    {
        Debug.Log("you dealt " + mod + " damage");
    }

    void DoMaterialBasedDamage(int mod, int x, int y)
    {
        Debug.Log("you dealt " + mod + " material damage");
    }

    void DoDraw(int mod, int x, int y)
    {
        Debug.Log("you drew " + mod + " card(s)");
    }

    void DoHeal(int mod, int x, int y)
    {
        Debug.Log("you healed " + mod + " health");
    }
}
