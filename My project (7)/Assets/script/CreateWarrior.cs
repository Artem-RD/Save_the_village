using UnityEngine;
using UnityEngine.UI;

public class CreateWarrior : MonoBehaviour
{    
    [SerializeField]private Unit unit;
    [SerializeField]private Resourse resources;
    [SerializeField]private int _warriorCost;
    [SerializeField]private float _createTimer;
    [SerializeField]private Image _createTimerImage;
    [SerializeField]private Button _btnCreate;

    private float _currentTimer = -1f;
    private bool _isProducing = false;

    // Update is called once per frame
    void Update()
    {
        if (_isProducing)
        {
            _currentTimer -= Time.deltaTime;
            _createTimerImage.fillAmount = _currentTimer/_createTimer;
            if (_currentTimer<=0f)
            {
                FinishCreate();
            }
        }
        //обновляем кнопку
        bool canAfford = resources._wheatCount >= _warriorCost && !_isProducing;
        if (_btnCreate.interactable != canAfford)
            _btnCreate.interactable = canAfford;
        
    }

    public void StartCreate()
    {
        if (resources.SpendWheat(_warriorCost))
        {
            _isProducing = true;
            _currentTimer = _createTimer;
            _createTimerImage.fillAmount = 1f;
            _btnCreate.interactable = false; 

        }
    }
    private void FinishCreate()
    {
        _isProducing = false;
        unit.AddWarrior();
        _currentTimer = -1f;
        _createTimerImage.fillAmount = 0f;

    }
}
