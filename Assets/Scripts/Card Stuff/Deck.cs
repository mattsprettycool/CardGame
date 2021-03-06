﻿
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour {

	public Card[] deck = new Card[100];
    public Card[] discard = new Card[100];
    public Card[] exhaust = new Card[25];
    public int exhaustIndex;
    public int lastCardSpot;
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
        lastCardSpot = deck.Length - 1;
    }

    public bool IsEmpty()
    {
            if(deck[0] == null)
            {
            return true;
            }
            else
            {
            return false;
            }
    }
    
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
                    else
                    {
                        deck[j] = deck[j + 1];
			            if(deck[j+2] == null)
                    	{
                        	deck[j + 1] = null;
                    	}
            	    }
                }
        lastCardSpot--;
        return draw;
    }

    public void AddCard(Card c)
    {
        deck[lastCardSpot] = c;
        if(lastCardSpot < 100)
        {
            lastCardSpot++;
        }
    }

    /*public void RemoveCard(Card c)
    {
        for(int i = 0; i < deck.Length; i++)
        {
            if(c = deck[i])
            {
                AddAndRemoveCard(i);
                break;
            }
        }
    }*/

    public void Exhaust(Card ex)
    {
        exhaust[exhaustIndex] = ex;
        //RemoveCard(ex);
        exhaustIndex++;
    }

}
