using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Event))]
public class EditorEvent : Editor
{
    public GameObject goldPrefab;
    public GameObject foodPrefab;
    public GameObject faithPrefab;
    public GameObject peoplePrefab;
    public GameObject armyPrefab;
    public GameObject salaryPrefab;
    public GameObject influencePrefab;

    public GameObject defaultPetitioner;
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        Event _event = (Event)target;
        foreach(Decisions decision in _event.decisions)
        {
            foreach(Resource resource in decision.resources)
            {
                resource.name = resource.resource.ToString();
                switch (resource.resource)
                {
                    case Resource.ResourceType.Gold:
                        resource.resourcePrefab = goldPrefab;
                        break;
                    case Resource.ResourceType.Food:
                        resource.resourcePrefab = foodPrefab;
                        break;
                    case Resource.ResourceType.Faith:
                        resource.resourcePrefab = faithPrefab;
                        break;
                    case Resource.ResourceType.People:
                        resource.resourcePrefab = peoplePrefab;
                        break;
                    case Resource.ResourceType.Army:
                        resource.resourcePrefab = armyPrefab;
                        break;
                    case Resource.ResourceType.Influence:
                        resource.resourcePrefab = influencePrefab;
                        break;
                    case Resource.ResourceType.Salary:
                        resource.resourcePrefab = salaryPrefab;
                        break;
                    default:
                        break;
                }
            }
        }
        if(_event.petitioner == null)
        {
            _event.petitioner = defaultPetitioner;
        }
    }
}
