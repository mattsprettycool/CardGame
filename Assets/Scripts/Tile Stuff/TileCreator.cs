using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileCreator : MonoBehaviour {
    [SerializeField]
    GameObject tile;
    int xOffset = 208;
    int yOffset = 89;
    int yIterXOffset = 69;
    [SerializeField]
    int collumns;
    [SerializeField]
    int rows;

	void Start () {
        Vector3 startPoint = gameObject.transform.position;
        foreach (Transform obj in gameObject.GetComponentsInChildren<Transform>())
        {
            if(obj.gameObject.tag.Equals("start"))
                startPoint = obj.position;
        }
		for(int x = 0; x < collumns; x++)
        {
            for(int y = 0; y < rows; y++)
            {
                Debug.Log("a");
                Instantiate(tile, new Vector3(startPoint.x+(xOffset*x)+(yIterXOffset*y), startPoint.y+(yOffset*y), 0), transform.rotation);
            }
        }
	}
}
