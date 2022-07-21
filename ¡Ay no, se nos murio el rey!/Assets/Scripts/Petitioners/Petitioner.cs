using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Petitioner : MonoBehaviour
{
    public Vector3 nextPosition;
    public float speed;
    public PetitionerManager _petitionerManager;
    private EventUI _eventUI;
    // los peticionarios tienen que crearse, moverse hasta su lugar y esperar
    // una vez creados, esperan a la señal de moverse
    // cuando se mueven, deben parar frente al administrador o frente al proximo peticionario
    // cuando el siguiente peticionario avanza, avanzan al siguiente lugar.
    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, nextPosition, speed * Time.deltaTime);
        //while (transform.position != nextPosition)
        //{
        //}
    }
    public void GiveNextPosition(Vector3 position)
    {
        nextPosition = position;
    }
    private void OnMouseDown()
    {
        Debug.Log("Ah, me tocaste wey");
    }
}
