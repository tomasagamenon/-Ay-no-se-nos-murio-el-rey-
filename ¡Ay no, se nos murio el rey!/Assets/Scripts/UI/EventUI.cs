using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EventUI : MonoBehaviour
{
    private EventManager _eventManager;
    public TextMeshProUGUI eventName;
    public TextMeshProUGUI eventDescription;
    public Transform eventWindow;
    private Transform _eventLayout;
    public Transform previewWindow;
    public GameObject decisionBlock;
    public GameObject eventPrefab;
    public GameObject eventPreview;
    private GameObject _activeEvent;

    private void Awake()
    {
        _eventManager = GameObject.Find("EventManager").GetComponent<EventManager>();
    }
    //Da nombre y descripcion a la ui, crea los "bloques" de decisiones, cada uno con su nombre
    // y sus recursos especificos, ademas de asignarle la funcion al boton directamente
    public void CreateEvent(string name, string description, Decisions[] decisions)
    {
        //Hacer que los botones de la preview no solo activen la ventana de eventos, sino 
        //tambien la pantalla de eventos correspondiente a cada boton
        GameObject eventScreen = Instantiate(eventPrefab, eventWindow);
        GameObject _eventPreview = Instantiate(eventPreview, previewWindow);
        EventScreen _eventScreenScript = eventScreen.GetComponent<EventScreen>();
        List<Button> buttons = new List<Button>();

        _eventPreview.GetComponentInChildren<TextMeshProUGUI>().text = name;
        _eventPreview.GetComponent<Button>().onClick.AddListener(delegate { ToggleEventWindow(eventScreen); });
        eventScreen.transform.Find("Name").GetComponent<TextMeshProUGUI>().text = name;
        _eventLayout = eventScreen.transform.GetComponentInChildren<VerticalLayoutGroup>().transform;
        _eventLayout.Find("Description").GetComponent<TextMeshProUGUI>().text = description;

        foreach (Decisions theDesicion in decisions)
        {
            GameObject block = Instantiate(decisionBlock, _eventLayout);
            block.GetComponentInChildren<TextMeshProUGUI>().text = theDesicion.decisionName;
            foreach (Resource resource in theDesicion.resources)
            {
                GameObject _resource = Instantiate(resource.resourcePrefab,
                    block.GetComponentInChildren<HorizontalLayoutGroup>().transform);
                string value = "";
                if (resource.quantity > 0)
                    value = "+" + resource.quantity.ToString();
                else
                    value = resource.quantity.ToString();
                _resource.transform.Find("Value").GetComponent<TextMeshProUGUI>().text = value;
            }
            block.GetComponent<Button>().onClick.AddListener(delegate { _eventManager.TakeDecision(theDesicion); });
            block.GetComponent<Button>().onClick.AddListener(delegate { _eventScreenScript.DisableButtons(); });
            buttons.Add(block.GetComponent<Button>());
            if (!_eventManager.DecisionAvaiable(theDesicion))
            {
                block.GetComponent<Button>().interactable = false;
            }
        }
        _eventScreenScript._eventManager = _eventManager;
        _eventScreenScript.decisions = decisions;
        _eventScreenScript.buttons = buttons.ToArray();
        eventScreen.gameObject.SetActive(false);
    }
    public void ToggleEventWindow(GameObject eventTab)
    {
        if (!eventWindow.gameObject.activeSelf)
        {
            eventWindow.gameObject.SetActive(true);
            eventTab.SetActive(true);
            _activeEvent = eventTab;
        }
        else if (eventTab != _activeEvent)
        {
            if(_activeEvent)
                _activeEvent.SetActive(false);
            eventTab.SetActive(true);
            _activeEvent = eventTab;
        }
        else
        {
            _activeEvent.SetActive(false);
            eventWindow.gameObject.SetActive(false);
            _activeEvent = null;
        }
    }
}
