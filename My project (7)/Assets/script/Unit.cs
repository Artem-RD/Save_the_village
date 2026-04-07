using UnityEngine;

public class Unit : MonoBehaviour
{
   [SerializeField] private int _startPeasantCount = 3;
   [SerializeField] private int _startWarriorCount = 0;
   public int _pesantCount{get;private set;}
   public int _warriorCount{get;private set;}
   public int TotalWarriorsCreated { get; private set; }

   public System.Action OnUnitsChanged;//события для того чтобы передовать информацию о юнитах

    void Start()
    {
        _pesantCount = _startPeasantCount;
        _warriorCount = _startWarriorCount;
        OnUnitsChanged?.Invoke();
    }
    public void AddPesant()
    {
        _pesantCount++;
        OnUnitsChanged?.Invoke();
    }
    public void AddWarrior()
    {
        _warriorCount++;
        TotalWarriorsCreated++;
        OnUnitsChanged?.Invoke();
    }
    public void RemoveWarrior(int amount)
    {

        _warriorCount -=amount;
         OnUnitsChanged?.Invoke();


    }

}
