using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardPos : MonoBehaviour {
	public Card[] cards;
	public GameObject cardTemplate;
	public Deck d;
	// Use this for initialization
	void Start () { 
		d = GameObject.FindGameObjectWithTag ("CardHandler").GetComponent<Deck> ();
		cardTemplate.GetComponent<CardReader> ().SetCard (d.deck[0]);
		cardTemplate.GetComponent<CardReader> ().SetScale (.5f, .5f, .5f);
		Instantiate (cardTemplate, gameObject.transform);
	}
	
	// Update is called once per frame
	void Update () {
		if (this.gameObject.GetComponentInChildren<CardReader>().gameObject == null) {
			GameObject.Destroy (gameObject);
		}
	}
}