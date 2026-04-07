using UnityEngine;
using UnityEngine.UI;

public class Raid : MonoBehaviour
{
    [SerializeField]private Unit unit;
    [SerializeField]private float _inetvalRaid = 30f;
    [SerializeField]private int _initialRaidStrength = 2;
    [SerializeField]private int _raidIncreasePerWave = 2;
    [SerializeField]private Image _raidTimerImage;

    private float _currentRaidTimer;
    private int _currentWave = 0;
    private int _nextRaidStrength;


    public System.Action OnRaidHappened;


    void Start()
    {
        _currentRaidTimer = _inetvalRaid;
        _nextRaidStrength = _initialRaidStrength;
    }

    void Update()
    {
        _currentRaidTimer -= Time.deltaTime;
        _raidTimerImage.fillAmount = _currentRaidTimer/ _inetvalRaid;
        if (_currentRaidTimer <= 0)
        {
            ExecuteRaid();
        }
        
    }

    private void ExecuteRaid()
    {
        unit.RemoveWarrior(_nextRaidStrength);
        _currentWave++;
        _nextRaidStrength += _raidIncreasePerWave;
        _currentRaidTimer = _inetvalRaid + _currentWave*2;
        OnRaidHappened?.Invoke();
    }
    public int CurrentWave => _currentWave;
    public int NextRaid => _nextRaidStrength;
}
