
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
        if (IsEmpty())
        {
            Card[] shuffled = new Card[100];
            for (int i = discard.Length; i > 0; i--)
            {
                float rnd = Random.Range(0, discard.Length);
                shuffled[i] = discard[(int)rnd];
                discard[(int)rnd] = null;
            }
            for (int i = shuffled.Length; i > 0; i--)
            {
                deck[i] = shuffled[i];
            }
        }//else if(Effect == shuffle) then run the same code, probably just use an or at the top but tell me about effects matt
    }

    public bool IsEmpty()
    {
        bool me = false;
        for(int i = 0; i < deck.Length; i++)
        {
            if(deck[i] == null && deck[i+1] == null)
            {
                me = true;
            }
            else
            {
                me = false;
            }
        }
        return me;
    }

    public Card AddAndRemoveCard(int indx)
    {
        Card draw;
        draw = deck[indx];
                for(int j = indx; j < deck.Length; j++)
                {
                    deck[j] = deck[j + 1];
                    if(deck[j+2] == null)
                    {
                        deck[j + 1] = null;
                    }
                }
        return draw;
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
