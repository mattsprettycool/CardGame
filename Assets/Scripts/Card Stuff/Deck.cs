﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour {

	public ArrayList deck = new ArrayList();
    private Random randy = new Random();

    public void shuffle()
    {
        ArrayList shuffled = new ArrayList();
        for(int i = deck.Count; i > 0; i--)
        {
            float rnd = Random.Range(0, deck.Count);
            shuffled.Add(deck[(int)rnd]);
            deck.Remove(rnd);
        }
        deck.Clear();
        for(int i = shuffled.Count; i > 0; i--)
        {
            deck.Add(shuffled[i]);
        }
        shuffled.Clear();
    }

    private void FixedUpdate()
    {
        
    }

}