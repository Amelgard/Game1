using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Item : ScriptableObject
{
    public bool stackable;
    public float weight;
    public int id;
    public Sprite icon;
}
