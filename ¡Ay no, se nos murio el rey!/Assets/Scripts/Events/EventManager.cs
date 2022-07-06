using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public Event[] events;
    public EventUI eventUI;
    private void Awake()
    {
        eventUI = GameObject.Find("Canvas").GetComponent<EventUI>();
    }
    public void SendEvent()
    {
        eventUI.CreateEvent(events[0].eventName, events[0].eventDescription, events[0].decisions);
    }
}
