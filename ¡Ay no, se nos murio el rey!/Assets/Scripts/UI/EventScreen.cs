using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventScreen : MonoBehaviour
{
    public Button[] buttons;
    public Decisions[] decisions;
    public GameObject check;
    [HideInInspector]
    public EventManager _eventManager;

    public void CheckDecisions()
    {
        for (int i = 0; i < decisions.Length; i++)
        {
            buttons[i].interactable = _eventManager.DecisionAvaiable(decisions[i]);
        }
    }
    // Una vez se toma UNA decision, todas las demas chau
    public void DisableButtons()
    {
        foreach(Button button in buttons)
        {
            button.interactable = false;
        }
        check.SetActive(true);
    }
}
