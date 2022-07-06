using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event : ScriptableObject
{
    public string eventName;
    public string eventDescription;
    public Decisions[] decisions;
}
