using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public Event[] totalEvents;
    public int eventsBagCapacity;
    private List<int> uniqueNumbers = new List<int>();
    private List<Event> _eventsBag = new List<Event>();
    private EventUI _eventUI;
    private ResourcesManager _resourcesManager;
    private PetitionerManager _petitionerManager;
    private void Awake()
    {
        _eventUI = GameObject.Find("EventUI").GetComponent<EventUI>();
        _resourcesManager = GameObject.Find("EconomyManager").GetComponent<ResourcesManager>();
        _petitionerManager = GameObject.Find("PetitionManager").GetComponent<PetitionerManager>();
        CreateEventBag();
    }
    private void Start()
    {
        SendEvent();
    }
    public void CreateEventBag()
    {
        for (int i = 0; i < totalEvents.Length; i++)
        {
            uniqueNumbers.Add(i);
        }
        for (int i = 0; i < eventsBagCapacity; i++)
        {
            int randNum = uniqueNumbers[Random.Range(0, uniqueNumbers.Count)];
            _eventsBag.Add(totalEvents[randNum]);
            //_petitionerManager.CreatePetitioner(_eventsBag[_eventsBag.Count - 1].petitioner);
            uniqueNumbers.Remove(randNum);
        }
    }
    //Hace que la UI haga el evento visualmente
    public void SendEvent()
    {
        // Despues el manejo de que eventos van a llegar cada turno va a manejarlo la ia especifica
        if(_eventsBag.Count != 0)
        {
            Event thisEvent = _eventsBag[Random.Range(0, _eventsBag.Count)];
            _eventsBag.Remove(thisEvent);
            _eventUI.CreateEvent(thisEvent.eventName, thisEvent.eventDescription, thisEvent.decisions);
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
    // Basicamente, intermediario entre ui y manager de recursos, para que no este
    // todo enchufado con todo y sea un lio
    public void TakeDecision(Decisions decision)
    {
        foreach (Resource resource in decision.resources)
        {
            _resourcesManager.ModifyResource(resource.resource, resource.quantity);
        }
        // Mandar al peticionario de vuelta y habilitar la peticion del siguiente
        //_petitionerManager.AdvancePlace();
        SendEvent();
    }
}
