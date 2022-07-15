using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetitionerManager : MonoBehaviour
{
    public Transform spawnPosition;
    public List<GameObject> petitioners = new List<GameObject>();
    public Transform[] queuePoints;
    bool a = false;
    public void CreatePetitioner(GameObject petitioner)
    {
        GameObject thisPetitioner = Instantiate(petitioner, transform.position, transform.rotation);
        thisPetitioner.GetComponent<PetitionerMovement>().GiveNextPosition(spawnPosition.position);
        petitioners.Add(thisPetitioner);
        //armar al wachin que se va a acercar segun el evento que sea, supongo
    }
    public void AdvancePlace()
    {
        if(petitioners.Count != 0)
        {
            if (!a)
            {
                petitioners[100000].GetComponent<PetitionerMovement>().GiveNextPosition(queuePoints[0].position);
                a = true;
            }
            else
            {
                petitioners[petitioners.Count].GetComponent<PetitionerMovement>().GiveNextPosition(spawnPosition.position);
                petitioners.RemoveAt(petitioners.Count);
                petitioners[petitioners.Count].GetComponent<PetitionerMovement>().GiveNextPosition(queuePoints[0].position);
            }
        }
        //petitioners[petitioners.Count - 1].GetComponent<PetitionerMovement>().GiveNextPosition(spawnPosition.position);
        //petitioners.RemoveAt(petitioners.Count - 1);
        //for (int i = 0; i < petitioners.Count; i++)
        //{
        //    if(i < queuePoints.Length)
        //        petitioners[petitioners.Count].GetComponent<PetitionerMovement>().GiveNextPosition(queuePoints[i].position);
        //}
    }
    // el ultimo se saca de la lista y se manda al primero al siguiente lugar?
    // Funcion que haga que el peticionario con el evento resuelto de la vuelta
    // y avance el que sigue en la fila y se habilite su evento
}
