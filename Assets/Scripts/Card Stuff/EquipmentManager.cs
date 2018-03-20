using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName = "Equipment")]
public class EquipmentManager : ScriptableObject {

    public string name;
    public string description;
    public int[] Effects = new int[100];
    
    

}

