using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour {

	public ArrayList deck = new ArrayList();
    private Random randy = new Random();

    public void shuffle()
    {
        ArrayList shuffled = new ArrayList();
        int count = 0;
        for(int i = deck.Count; i > 0; i--)
        {
            float rnd = Random.Range(0, deck.Count);
            shuffled.Add(deck[(int)rnd]);
            deck.Remove(rnd);
        }
    }

    public ArrayList createDeck(ArrayList d)
    {
        foreach(Card obj in d)
        {
            deck.Add(d);
        }
        return deck;
    }

}
