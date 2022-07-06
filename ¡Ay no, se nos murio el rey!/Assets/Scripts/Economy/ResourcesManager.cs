using UnityEngine;

public class ResourcesManager : MonoBehaviour
{
    private MainUI _resourcesUI;
    public GameObject perdiste;
    public int Gold
    {
        get { return _gold; }
        set
        {
            _gold = value;
            if (_gold <= 0) Perdiste();
            _resourcesUI.UpdateResources(nameof(Gold), _gold);
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
            _resourcesUI.UpdateResources(nameof(Food), _food);
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
            _resourcesUI.UpdateResources(nameof(Faith), _faith);
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
            _resourcesUI.UpdateResources(nameof(People), _people);
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
            _resourcesUI.UpdateResources(nameof(Army), _army);
        }
    }
    private int _army;
    public int Influence
    {
        get { return _influence; }
        set
        {
            _influence = value;

            _resourcesUI.UpdateResources(nameof(Influence), _influence);
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
        Gold = 200;
        Food = 200;
        Faith = 200;
        People = 200;
        Army = 200;
        Influence = 25;
        TotalSalary = 22;
        FreeSalary = TotalSalary;
    }
    public void ModifyGold(int quantity)
    {
        Gold += quantity;
    }
    public void ModifyFood(int quantity)
    {
        Food += quantity;
    }
    public void ModifyFaith(int quantity)
    {
        Faith += quantity;
    }
    public void ModifyPeople(int quantity)
    {
        People += quantity;
    }
    public void ModifyArmy(int quantity)
    {
        Army += quantity;
    }
    public void ModifyInfluence(int quantity)
    {
        Influence += quantity;
    }
    public void ModifySalary(int quantity)
    {
        if(quantity < 0 && FreeSalary < -quantity)
        {
            _resourcesUI.Messager("No tenes guita para eso flaco.");
        }
        else
        {
            FreeSalary += quantity;
        }
    }
    private void Perdiste()
    {
        perdiste.SetActive(true);
    }
}
