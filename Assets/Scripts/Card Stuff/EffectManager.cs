using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour {
    [SerializeField]
    Card c;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.E))
            DoEffect(c, 0, 0);
	}
    
    void DoEffect(Card c, int x, int y)
    {
        if (c.encodedEffectArray[0, 0] == 1)
            Debug.Log("you dealt damage");
    }
}
