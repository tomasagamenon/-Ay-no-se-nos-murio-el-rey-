using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetitionerManager : MonoBehaviour
{
    public Transform spawnPosition;
    public List<GameObject> petitioners = new List<GameObject>();
    public Transform[] queuePoints;

    public void CreatePetitioner(GameObject petitioner)
    {
        GameObject thisPetitioner = Instantiate(petitioner, spawnPosition.position, transform.rotation);
        petitioners.Add(thisPetitioner);
        if(petitioners.Count <= queuePoints.Length)
        {
            thisPetitioner.GetComponent<Petitioner>().GiveNextPosition(queuePoints[petitioners.Count - 1].position);
        }
        thisPetitioner.GetComponent<Petitioner>()._petitionerManager = this;
        //armar al wachin que se va a acercar segun el evento que sea, supongo
    }
    public void AdvancePlace()
    {
        petitioners[0].GetComponent<Petitioner>().GiveNextPosition(spawnPosition.position);
        petitioners.Remove(petitioners[0]);
        if (petitioners.Count > 0)
        {
            for (int i = 0; i < queuePoints.Length && i < petitioners.Count; i++)
            {
                petitioners[i].GetComponent<Petitioner>().GiveNextPosition(queuePoints[i].position);
            }
        }
    }
    public void GiveEventTab(GameObject eventTab)
    {
        petitioners[0].GetComponent<Petitioner>().eventScreen = eventTab;
    }
    // el ultimo se saca de la lista y se manda al primero al siguiente lugar?
    // Funcion que haga que el peticionario con el evento resuelto de la vuelta
    // y avance el que sigue en la fila y se habilite su evento
}
