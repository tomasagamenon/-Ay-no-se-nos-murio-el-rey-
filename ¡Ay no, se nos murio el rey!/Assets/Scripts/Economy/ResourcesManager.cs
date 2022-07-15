using UnityEngine;

public class ResourcesManager : MonoBehaviour
{
    private MainUI _resourcesUI;
    private EventUI _eventUI;
    public GameObject perdiste;
    //Los siguientes recursos, al modificarlos, llaman al metodo que actualiza la Ui
    //quizas se pueda mejorar y probablemente tenga que cambiarse
    public int Gold
    {
        get { return _gold; }
        set
        {
            _gold = value;
            if (_gold <= 0) Perdiste();
            _resourcesUI.UpdateResources(Resource.ResourceType.Gold, _gold);
        }
    }
    private int _gold;
    public int Food
    {
        get { return _food; }
        set
        {
            _food = value;
            if (_food <= 0) Perdiste();
            _resourcesUI.UpdateResources(Resource.ResourceType.Food, _food);
        }
    }
    private int _food;
    public int Faith
    {
        get { return _faith; }
        set
        {
            _faith = value;
            if (_faith <= 0) Perdiste();
            _resourcesUI.UpdateResources(Resource.ResourceType.Faith, _faith);
        }
    }
    private int _faith;
    public int People
    {
        get { return _people; }
        set
        {
            _people = value;
            if (_people <= 0) Perdiste();
            _resourcesUI.UpdateResources(Resource.ResourceType.People, _people);
        }
    }
    private int _people;
    public int Army
    {
        get { return _army; }
        set
        {
            _army = value;
            if (_army <= 0) Perdiste();
            _resourcesUI.UpdateResources(Resource.ResourceType.Army, _army);
        }
    }
    private int _army;
    public int Influence
    {
        get { return _influence; }
        set
        {
            _influence = value;

            _resourcesUI.UpdateResources(Resource.ResourceType.Influence, _influence);
        }
    }
    private int _influence;
    public int FreeSalary
    {
        get { return _freeSalary; }
        set
        {
            _freeSalary = value;
            _resourcesUI.UpdateSalary(FreeSalary, TotalSalary);
        }
    }
    private int _freeSalary;
    public int TotalSalary
    {
        get { return _totalSalary; }
        set
        {
            _totalSalary = value;
            _resourcesUI.UpdateSalary(FreeSalary, TotalSalary);
        }
    }
    private int _totalSalary;
    private void Awake()
    {
        _resourcesUI = GameObject.Find("Canvas").GetComponent<MainUI>();
        _eventUI = GameObject.Find("EventUI").GetComponent<EventUI>();
        Gold = 50;
        Food = 50;
        Faith = 50;
        People = 50;
        Army = 50;
        Influence = 15;
        TotalSalary = 12;
        FreeSalary = TotalSalary;
    }
    public void ModifyResource(Resource.ResourceType resourceType, int quantity)
    {
        // Estoy seguro de que debe haber un metodo mejor que el switch
        // para determinar que recurso es, pero no lo se
        switch (resourceType)
        {
            case Resource.ResourceType.Gold:
                Gold += quantity;
                break;
            case Resource.ResourceType.Food:
                Food += quantity;
                break;
            case Resource.ResourceType.Faith:
                Faith += quantity;
                break;
            case Resource.ResourceType.People:
                People += quantity;
                break;
            case Resource.ResourceType.Army:
                Army += quantity;
                break;
            case Resource.ResourceType.Influence:
                Influence += quantity;
                break;
            case Resource.ResourceType.Salary:
                FreeSalary += quantity;
                break;
            default:
                break;
        }
        // Avisa a los eventos que revisen si ya no alcanzan los recursos
        _eventUI.CheckResources();
    }
    public bool ResourceAvaiability(Resource.ResourceType resourceType, int quantity)
    {
        // Aguante los switch vieja, no me importa nada B)
        switch (resourceType)
        {
            case Resource.ResourceType.Gold:
                if (Gold < -quantity)
                    return false;
                break;
            case Resource.ResourceType.Food:
                if (Food < -quantity)
                    return false;
                break;
            case Resource.ResourceType.Faith:
                if (Faith < -quantity)
                    return false;
                break;
            case Resource.ResourceType.People:
                if (People < -quantity)
                    return false;
                break;
            case Resource.ResourceType.Army:
                if (Army < -quantity)
                    return false;
                break;
            case Resource.ResourceType.Influence:
                if (Influence < -quantity)
                    return false;
                break;
            case Resource.ResourceType.Salary:
                if (FreeSalary < -quantity)
                    return false;
                break;
            default:
                break;
        }
        return true;
    }
    private void Perdiste()
    {
        perdiste.SetActive(true);
    }
}
