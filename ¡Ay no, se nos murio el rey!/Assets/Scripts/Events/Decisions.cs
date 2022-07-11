using UnityEngine;
using System;

[Serializable]
public class Decisions
{
    public string decisionName;
    public Resource[] resources;
    [HideInInspector]
    public bool isAffordable;
}
