using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Scriptable/ItemData", fileName = "Item Data")]
public class ItemData : ScriptableObject
{
    public float damage = 10;
    public float attackSpeed = 2;
}
