using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recipe : ScriptableObject
{
    [SerializeField] private Item[] items;
    public Item[] Items { get; }

}
