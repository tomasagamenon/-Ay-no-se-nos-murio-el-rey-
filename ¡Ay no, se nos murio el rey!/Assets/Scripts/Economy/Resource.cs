using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Resource 
{
    [HideInInspector]
    public string name;
    [HideInInspector]
    public GameObject resourcePrefab;
    public enum ResourceType { Gold, Food, Faith, People, Army, Influence, Salary}
    public ResourceType resource;
    public int quantity;
}
