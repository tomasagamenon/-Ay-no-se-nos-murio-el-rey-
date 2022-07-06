using System;
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

    public TextMeshProUGUI messager;

    public void UpdateResources(string resource, int newQuantity)
    {
        TextMeshProUGUI _resource;
        switch (resource)
        {
            case "Gold":
                _resource = goldValue;
                break;
            case "Food":
                _resource = foodValue;
                break;
            case "Faith":
                _resource = faithValue;
                break;
            case "People":
                _resource = peopleValue;
                break;
            case "Army":
                _resource = armyValue;
                break;
            case "Influence":
                _resource = influenceValue;
                break;
            default:
                _resource = null;
                break;
        }
        _resource.text = Convert.ToString(newQuantity);
    }
    public void UpdateSalary(int freeSalary, int totalSalary)
    {
        salaryValue.text = freeSalary.ToString() + "/" + totalSalary.ToString();
    }
    public void UpdateCycle(int cycle)
    {
        cycleValue.text = cycle.ToString();
    }
    public void Messager(string message)
    {
        messager.text = message;
    }
}
