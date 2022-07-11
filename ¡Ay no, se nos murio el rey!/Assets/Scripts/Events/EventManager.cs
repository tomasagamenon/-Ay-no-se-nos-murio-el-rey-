using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public Event[] events;
    private EventUI _eventUI;
    private ResourcesManager _resourcesManager;
    private void Awake()
    {
        _eventUI = GameObject.Find("EventUI").GetComponent<EventUI>();
        _resourcesManager = GameObject.Find("EconomyManager").GetComponent<ResourcesManager>();
    }
    //Hace que la UI haga el evento visualmente
    public void SendEvent()
    {
        // Hacer que pueda manejar varios eventos, al menos para empezar hacerlo al azar,
        // o mandar todos los eventos que tenga en la lista.
        //despues el manejo de que eventos van a llegar cada turno va a manejarlo la ia especifica
        foreach (Event _event in events)
        {
            _eventUI.CreateEvent(_event.eventName, _event.eventDescription, _event.decisions);
        }
    }
    public bool DecisionAvaiable(Decisions decision)
    {
        foreach (Resource resource in decision.resources)
        {
            if (resource.quantity < 0)
            {
                if (!_resourcesManager.ResourceAvaiability(resource.resource, resource.quantity))
                    return false;
            }
        }
        return true;
    }
    //basicamente, intermediario entre ui y manager de recursos, para que no este
    //todo enchufado con todo y sea un lio
    public void TakeDecision(Decisions decision)
    {
        foreach (Resource resource in decision.resources)
        {
            _resourcesManager.ModifyResource(resource.resource, resource.quantity);
        }
    }
}
