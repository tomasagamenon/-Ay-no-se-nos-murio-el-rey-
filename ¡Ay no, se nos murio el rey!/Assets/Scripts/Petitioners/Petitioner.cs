using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Petitioner : MonoBehaviour
{
    public Vector3 nextPosition;
    public float speed;
    [HideInInspector]
    public PetitionerManager _petitionerManager;
    //[HideInInspector]
    public GameObject eventScreen;
    private EventUI _eventUI;
    // los peticionarios tienen que crearse, moverse hasta su lugar y esperar
    // una vez creados, esperan a la señal de moverse
    // cuando se mueven, deben parar frente al administrador o frente al proximo peticionario
    // cuando el siguiente peticionario avanza, avanzan al siguiente lugar.
    private void Awake()
    {
        _eventUI = GameObject.Find("EventUI").GetComponent<EventUI>();
    }
    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, nextPosition, speed * Time.deltaTime);
    }
    public void GiveNextPosition(Vector3 position)
    {
        nextPosition = position;
    }
    private void OnMouseDown()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            if(eventScreen != null)
                _eventUI.ToggleEventWindow(eventScreen);
            Debug.Log("Ah, me tocaste wey");
        }
    }
}
