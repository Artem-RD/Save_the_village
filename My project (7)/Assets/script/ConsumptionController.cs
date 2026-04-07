using UnityEngine;

public class ConsumptionController : MonoBehaviour
{
    [SerializeField]private ImageTimer EatingTimer;
    [SerializeField]private Unit unit;
    [SerializeField]private Resourse resourse;
    [SerializeField]private int _wheatToWarriors;
    [SerializeField]private int _wheatToPeasant;

    void Update()
    {
        eat();
    }

    private void eat()
    {      
        

        if (EatingTimer.Tick)
        {
            _wheatToWarriors = Random.Range(1,5);
            _wheatToPeasant = Random.Range(1,3);
            resourse.SpendWheat(unit._warriorCount * _wheatToWarriors + unit._pesantCount * _wheatToPeasant);
        }
    }
}
