using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandScript : MonoBehaviour {
	public Card [] handArray = new Card[100];
	public GameObject posToPutCard;
	public Deck d;
	float timer;
	int numCards;
	// Use this for initialization
	void Start () {
		d = GameObject.FindGameObjectWithTag ("CardHandler").GetComponent<Deck> ();
		numCards = 0;
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer > 2) {
			DrawCard ();
			timer = 0;
		}
	}
	public void DrawCard(){
		handArray [numCards] = d.deck [0];
		numCards++;
		Instantiate (posToPutCard, gameObject.transform);
	}
}