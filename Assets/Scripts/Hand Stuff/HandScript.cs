using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandScript : MonoBehaviour {
	public GameObject posToPutCard;
	// Use this for initialization
	void Start () {
		for (int i = 0; i < 6; i++) {
			Instantiate (posToPutCard, new Vector2 (transform.localPosition.x - 640 + (gameObject.GetComponent<RectTransform>().rect.width), 0), transform.localRotation);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}