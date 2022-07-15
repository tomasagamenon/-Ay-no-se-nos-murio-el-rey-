using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EventUI : MonoBehaviour
{
    private EventManager _eventManager;
    public Transform eventWindow;
    private Transform _eventLayout;
    public Transform previewWindow;
    public GameObject decisionBlock;
    public GameObject eventPrefab;
    public GameObject eventPreview;

    private GameObject _activeEvent;

    private List<EventScreen> _eventScreens = new List<EventScreen>();

    private void Awake()
    {
        _eventManager = GameObject.Find("EventManager").GetComponent<EventManager>();
    }
    //Da nombre y descripcion a la ui, crea los "bloques" de decisiones, cada uno con su nombre
    // y sus recursos especificos, ademas de asignarle la funcion al boton directamente
    // QUIZAS se pueda separar el contenido en mas funciones, para que este mas ordenado,
    // pero para eso lo tengo que leer xD
    public void CreateEvent(string name, string description, Decisions[] decisions)
    {
        // Crea la ventana de evento, su preview, se toma su script y su boton
        GameObject eventScreen = Instantiate(eventPrefab, eventWindow);
        GameObject _eventPreview = Instantiate(eventPreview, previewWindow);
        EventScreen _eventScreenScript = eventScreen.GetComponent<EventScreen>();
        _eventScreens.Add(_eventScreenScript);
        List<Button> buttons = new List<Button>();

        _eventPreview.GetComponentInChildren<TextMeshProUGUI>().text = name;
        _eventPreview.GetComponent<Button>().onClick.AddListener(delegate { ToggleEventWindow(eventScreen); });
        
        eventScreen.transform.Find("Name").GetComponent<TextMeshProUGUI>().text = name;
        _eventLayout = eventScreen.transform.GetComponentInChildren<VerticalLayoutGroup>().transform;
        _eventLayout.Find("Description").GetComponent<TextMeshProUGUI>().text = description;

        foreach (Decisions theDesicion in decisions)
        {
            // Crea el boton, le da su nombre y por cada recurso que tenga, le añade su imagen,
            // y le da valor al numero que aparece en cada uno
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
    // Manejo de abrir los eventos segun los botones del preview
    public void ToggleEventWindow()
    {
        if (_activeEvent)
            _activeEvent.SetActive(false);
        _activeEvent = null;
        eventWindow.gameObject.SetActive(false);
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
            _activeEvent = null;
            eventWindow.gameObject.SetActive(false);
        }
    }
    public void CheckResources()
    {
        foreach (EventScreen screen in _eventScreens)
        {
            screen.CheckDecisions();
        }
    }
}
