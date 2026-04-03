using Unity.VisualScripting;
using UnityEngine;
using Random = System.Random;

public class Resourse : MonoBehaviour
{
    public int _wheatCount{get;private set;}// количество пшеницы
    public System.Action OnWheatChanged; // событие для получения значений пшеницы


  //добовляем пшеницу
    public void AddWheat(int amount)
    {
        _wheatCount += amount;
        OnWheatChanged?.Invoke();
    }

    //уменьшаем количество пшеницы
    public bool SpendWheat(int amount)
    {
        if(_wheatCount >= amount)//если возможно уменьшим если нет то вернем false
        {
            _wheatCount -= amount;
            OnWheatChanged?.Invoke();
            return true;
        }
        return false;
    }
}
