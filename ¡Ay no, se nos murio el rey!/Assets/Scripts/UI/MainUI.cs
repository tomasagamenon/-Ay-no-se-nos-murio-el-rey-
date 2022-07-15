using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainUI : MonoBehaviour
{
    public TextMeshProUGUI goldValue;
    public TextMeshProUGUI foodValue;
    public TextMeshProUGUI faithValue;
    public TextMeshProUGUI peopleValue;
    public TextMeshProUGUI armyValue;
    public TextMeshProUGUI salaryValue;
    public TextMeshProUGUI influenceValue;
    public TextMeshProUGUI cycleValue;

    public void UpdateResources(Resource.ResourceType resourceType, int newQuantity)
    {
        TextMeshProUGUI _resourceTMP;
        string value = newQuantity.ToString();
        switch (resourceType)
        {
            case Resource.ResourceType.Gold:
                _resourceTMP = goldValue;
                break;
            case Resource.ResourceType.Food:
                _resourceTMP = foodValue;
                break;
            case Resource.ResourceType.Faith:
                _resourceTMP = faithValue;
                break;
            case Resource.ResourceType.People:
                _resourceTMP = peopleValue;
                break;
            case Resource.ResourceType.Army:
                _resourceTMP = armyValue;
                break;
            case Resource.ResourceType.Influence:
                _resourceTMP = influenceValue;
                break;
            case Resource.ResourceType.Salary:
                _resourceTMP = salaryValue;
                break;
            default:
                _resourceTMP = null;
                break;
        }
        _resourceTMP.text = value;
    }
    public void UpdateSalary(int freeSalary, int totalSalary)
    {
        salaryValue.text = freeSalary.ToString() + "/" + totalSalary.ToString();
    }
    public void UpdateCycle(int cycle)
    {
        cycleValue.text = cycle.ToString();
    }
    public void ToggleMenuObject(GameObject gameObject)
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }
}
