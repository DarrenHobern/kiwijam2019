using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Controls", menuName = "Controls", order = 1)]
public class Controls : ScriptableObject
{
    [SerializeField] private string horizontal = "horizontal"; // change to h1
    [SerializeField] private string vertical = "vertical"; //TODO change to v1
    [SerializeField] private string throwAction = "t1";
    [SerializeField] private string pickupAction = "p1";

    public string Horizontal { get {return this.horizontal; } }
    public string Vertical { get {return this.vertical; } }
    public string ThrowAction { get {return this.throwAction; } }
    public string PickupAction { get {return this.pickupAction; } }
}
