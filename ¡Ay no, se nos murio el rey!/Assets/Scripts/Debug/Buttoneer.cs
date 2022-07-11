using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Buttoneer : MonoBehaviour
{
    public ResourcesManager resourcesManager;
    public int resourceQuantity;
    public Resource.ResourceType resourceType;
    public TMP_Dropdown dropdown;
    public TMP_InputField inputField;

    public void ChangeResource()
    {
        resourcesManager.ModifyResource(resourceType, resourceQuantity);
    }
    public void ChangeQuantity()
    {
        if (inputField.text != "" && inputField.text != "-")
            resourceQuantity = Convert.ToInt32(inputField.text);
    }
    public void ChangeType()
    {
        switch (dropdown.captionText.text)
        {
            case ("Gold"):
                resourceType = Resource.ResourceType.Gold;
                break;
            case ("Food"):
                resourceType = Resource.ResourceType.Food;
                break;
            case ("Faith"):
                resourceType = Resource.ResourceType.Faith;
                break;
            case ("People"):
                resourceType = Resource.ResourceType.People;
                break;
            case ("Army"):
                resourceType = Resource.ResourceType.Army;
                break;
            case ("Salary"):
                resourceType = Resource.ResourceType.Salary;
                break;
            case ("Influence"):
                resourceType = Resource.ResourceType.Influence;
                break;
            default:
                break;
        }
    }
}
