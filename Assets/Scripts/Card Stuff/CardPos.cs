using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardPos : MonoBehaviour {
	public Card[] cards;
	public GameObject cardTemplate;
	public HandScript hand;
	public Deck d;
	// Use this for initialization
	void Start () { 
		d = GameObject.FindGameObjectWithTag ("CardHandler").GetComponent<Deck> ();
		hand = GameObject.FindGameObjectWithTag ("Hand").GetComponent<HandScript> ();
		GameObject cardo = Instantiate (cardTemplate, gameObject.transform);
		cardo.GetComponent<CardReader> ().SetCard (hand.handArray [hand.numCards-1]);
		cardo.GetComponent<CardReader> ().SetScale (.5f, .5f, .5f);
	}
	
	// Update is called once per frame
	void Update () {
		if (this.gameObject.GetComponentInChildren<CardReader>().gameObject == null) {
			GameObject.Destroy (gameObject);
		}
	}
}