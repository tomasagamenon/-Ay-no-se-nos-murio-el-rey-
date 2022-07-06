using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EventUI : MonoBehaviour
{
    public TextMeshProUGUI eventName;
    public TextMeshProUGUI eventDescription;
    public GameObject layout;
    public GameObject decisionBlock;
    //tiene que crear el bloque con la decision, buscar el texto para darle nombre y
    //despues ir al siguiente para lo mismo
    public void CreateEvent(string name, string description, Decisions[] decisions)
    {
        eventName.text = name;
        eventDescription.text = description;
        foreach(Decisions theDesicion in decisions)
        {
            GameObject block = Instantiate(decisionBlock, layout.transform);
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
        }
    }
}
