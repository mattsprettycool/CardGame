using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandScript : MonoBehaviour {
	public GameObject posToPutCard;
	float timer;
	int numCards;
	// Use this for initialization
	void Start () {
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
		numCards++;
		Instantiate (posToPutCard, gameObject.transform);
	}
}