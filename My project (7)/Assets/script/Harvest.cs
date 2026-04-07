using System;
using Unity.VisualScripting;
using UnityEngine;

public class Harvest : MonoBehaviour
{
     [SerializeField]private ImageTimer HarvestTimer;
     [SerializeField]private Unit Unit;
     [SerializeField]private Resourse Resourse;
     private int _minWheatPerPeasant = 1;
     private int _maxWheatPerPeasant = 4;

    void Update()
    {
        if (HarvestTimer.Tick)
        {
            int randomPerPeasant = UnityEngine.Random.Range(_minWheatPerPeasant,_maxWheatPerPeasant);
            int totalHarvest = Unit._pesantCount * randomPerPeasant;
            Resourse.AddWheat(totalHarvest);
        }
        
    }
}
