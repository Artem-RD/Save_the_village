using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]private Text _resurseText;
    [SerializeField]private Text _raidCountText;


    [SerializeField]private Unit unit;
    [SerializeField]private Resourse resourse;
    [SerializeField]private Raid raid;

    void Start()
    {
        unit.OnUnitsChanged += UpdateUI;
        resourse.OnWheatChanged += UpdateUI;
        raid.OnRaidHappened += UpdateUI;
        UpdateUI();
    }

    private void UpdateUI()
    {
        _resurseText.text = $"{unit._pesantCount}\n{unit._warriorCount}\n{resourse._wheatCount}";
        _raidCountText.text = $"{raid.CurrentWave}\n{raid.NextRaid}";
    }
}
