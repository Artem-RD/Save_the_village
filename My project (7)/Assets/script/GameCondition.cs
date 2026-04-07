using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameCondition : MonoBehaviour
{
     [SerializeField]private Unit unit;
     [SerializeField]private Raid raid;
     [SerializeField]private GameObject _gameOverScreen;
     [SerializeField]private GameObject _winScreen;
     [SerializeField]private Text _gameOverText;
     [SerializeField]private Text _gameWinText;
    void Start()
    {
        unit.OnUnitsChanged += GameOver;
        raid.OnRaidHappened += Win;
    }

    // Update is called once per frame
private void GameOver()
    {
        if(unit._warriorCount < 0)
        {
            Time.timeScale = 0;
            _gameOverScreen.SetActive(true);
            _gameOverText.text = $"Поражение!\nСоздано воинов: {unit.TotalWarriorsCreated}\nОчки: {unit.TotalWarriorsCreated * 30}";
        }
    } 
    private void Win()
    {
        if(raid.CurrentWave > 6)
        {
            Time.timeScale = 0;
            _winScreen.SetActive(true);
            _gameWinText.text = $"Победа!\nВыжито волн: {raid.CurrentWave}\nСоздано воинов: {unit.TotalWarriorsCreated}\nОчки: {unit.TotalWarriorsCreated * 30}";
        }
    }

}
