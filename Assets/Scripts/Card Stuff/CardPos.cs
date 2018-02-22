using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardPos : MonoBehaviour {
	public Card[] cards;
	public GameObject cardTemplate;
	// Use this for initialization
	void Start () {
		cardTemplate.GetComponent<CardReader> ().SetCard (cards [Random.Range(0, cards.Length)]);
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