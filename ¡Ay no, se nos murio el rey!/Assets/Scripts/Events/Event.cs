using UnityEngine;

[CreateAssetMenu(menuName = "Objects/Event")]
public class Event : ScriptableObject
{
    public string eventName;
    [TextArea(1, 4)]
    public string eventDescription;
    public Decisions[] decisions;
}
