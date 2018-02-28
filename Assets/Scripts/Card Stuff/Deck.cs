
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour {

	public Card[] deck = new Card[100];
    public Card[] discard = new Card[100];
    private Random randy = new Random();
    //Maybe this shuffles the deck? Maybe it doesnt
    public void shuffle()
    {
        Card[] shuffled = new Card[100];
        for(int i = deck.Length; i > 0; i--)
        {
            float rnd = Random.Range(0, deck.Length);
            shuffled[i] = deck[(int)rnd];
            deck[(int)rnd] = null;
        }
        for(int i = shuffled.Length; i > 0; i--)
        {
            deck[i] = shuffled[i];
        }
    }

    public void Start()
    {
        //i need help is this how i do it
        shuffle();
    }

    public void FixedUpdate()
    {
        
    }

}
