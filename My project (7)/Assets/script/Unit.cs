using UnityEngine;

public class Unit : MonoBehaviour
{
   public int _pesantCount{get;private set;}
   public int _warriorCount{get;private set;}

   public System.Action OnUnitsChanged;//события для того чтобы передовать информацию о юнитах

   public void AddPesant()
    {
        _pesantCount++;
        OnUnitsChanged?.Invoke();
    }
    public void AddWarrior()
    {
        _warriorCount++;
        OnUnitsChanged?.Invoke();
    }
    public bool RemoveWarrior(int amount)
    {
        if(_warriorCount >= amount)
        {
            _warriorCount -=amount;
            OnUnitsChanged?.Invoke();
            return true;
        }
        return false;
    }

}
