using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Create New Item", order = 1)]

public class ItemDefinition : ScriptableObject {

    public string itemname;

    public string affectedvariable;

    public int maxamount;

    public float relativepower;
}
