
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour {

	public Card[] deck = new Card[100];
    public Card[] discard = new Card[100];
    public Card[] exhaust = new Card[25];
    public int exhaustIndex;
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
        }
    }
    //Checks if the deck has only null spots or not
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
    //Takes a card from the deck array and gets rid of it to the discard
    public Card AddAndRemoveCard(int indx)
    {
        Card draw;
        draw = deck[indx];
                for(int j = indx; j < deck.Length; j++)
                {
                    if(j > 97)
                    {
                        deck[98] = deck[99];
                        deck[99] = null;
                    }
                    else if(deck[j+2] == null)
                    {
                        deck[j + 1] = null;
                    }
                    else
                    {
                        deck[j] = deck[j + 1];
            }
                }
        return draw;
    }
    //tell me if you want this to be void or return a card or something
    public void Exhaust(Card ex)
    {
        Card dis = ex;
        exhaust[exhaustIndex] = dis;
        exhaustIndex++;
        //ill add something where if a new game is started then index is reset but not needed for now
    }

    public void Start()
    {
        
    }

    public void FixedUpdate()
    {
        AddAndRemoveCard(0);
    }

}
