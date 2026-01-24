using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;
public class GameManager : MonoBehaviour
{
    [SerializeField]private ImageTimer HarvestTimer;
    [SerializeField]private ImageTimer EatingTimer;
    [SerializeField]private Image RaidTimerImg;
    [SerializeField]private Image PeasantTimerImg;
    [SerializeField]private Image WarriorTimerImg;
    [SerializeField]private Button peasantButton;
    [SerializeField]private Button warriorButton;
    [SerializeField]private Text resurseText;
    [SerializeField]private Text RaidCountText;
    [SerializeField]private Text GameoverText;
    [SerializeField] private Text GamewinText;
    [SerializeField]private int peasantCount;
    [SerializeField]private int warriorsCount;
    [SerializeField]private int wheatCount;
    [SerializeField]private int wheatPerPeasant;
    [SerializeField]private int wheatToWarriors;
    [SerializeField]private int wheatToPeasant;
    [SerializeField]private int peasantCost;
    [SerializeField]private int warriorCost;
    [SerializeField]private float peasantCreateTime;
    [SerializeField]private float warriorCreateTime;
    [SerializeField]private float raidMaxTimer;
    [SerializeField]private int raidIncrease;
    [SerializeField]private int nextRaid;
    [SerializeField]private GameObject GameOverScreen;
    [SerializeField] private GameObject GameWinScreen;
    private float peasantTimer = -2;
    private float warriorTimer = -2;
    private float raidTimer;
    private int Wave;
    private bool Clik;
    private bool flag = true;
    private bool flag1 = true;
    private bool flag2 = true;
    private bool flag3 = true;
    private int warr;
    private int a = 0;
   // private int wheatCount = 0;


    // Start is called before the first frame update
    void Start()
    {
        UpdateText();
        raidTimer = raidMaxTimer;
        Time.timeScale = 1f;

    }

    private void Update()
    {
 
        harvest();
        peasent();
        warriors();
        eat();
        UpdateText();
        gameover();
        GameOverText();
        when();
        when1();
        raidtimer();
        GameWinText();
        gamewin();

    }
    private void warriors()
    {

        if (warriorTimer > 0)
        {
            warriorTimer -= Time.deltaTime;
            WarriorTimerImg.fillAmount = warriorTimer / warriorCreateTime;
            flag1 = false;
        }
        else if (warriorTimer > -1)
        {     
            WarriorTimerImg.fillAmount = 1;
            warriorsCount += 1;
            warr++;
            warriorTimer = -2;
            flag1 = true;
            
        }
        fla();
    }
    private void peasent()
    {
        if (peasantTimer > 0)
        {
            peasantTimer -= Time.deltaTime;
            PeasantTimerImg.fillAmount = peasantTimer / peasantCreateTime;
            flag3 = false;
        }
        else if (peasantTimer > -1)
        {
            
            PeasantTimerImg.fillAmount = 1;
            peasantCount += 1;
            peasantTimer = -2;
            flag3 = true;
        }
        fla();
    }

    private void fla()
    {
        if(flag == false || flag1 == false)
        {
            warriorButton.interactable = false;
        }
        else
        {
            warriorButton.interactable = true;
        }
        if(flag2 == false || flag3 == false)
        {
            peasantButton.interactable = false;
        }
        else
        {
            peasantButton.interactable = true;
        }
    }

    private void when1()
    {
        if (wheatCount > peasantCost)
        {
            flag2 = true;
           
        }
        else
        {
            flag2 = false;
            
        }
    }
    private void when()
    {
         if(wheatCount > warriorCost )
        {
            flag = true;
        }
        else
        {
            flag = false;
        }

    }
    private void harvest()
    {
        Random rdn = new Random();
        wheatPerPeasant = rdn.Next(1, 4);
        if (HarvestTimer.Tick)
        {
            wheatCount += peasantCount * wheatPerPeasant;
        }

    }
    private void eat()
     {
        Random rdn = new Random();
        wheatToWarriors = rdn.Next(1, 5);
        wheatToPeasant = rdn.Next(1, 3);
        if (EatingTimer.Tick)
        {
            wheatCount -= warriorsCount * wheatToWarriors;
            wheatCount -= peasantCost * wheatToPeasant;
        }
    }
    private void raidtimer()
    {
        raidTimer -= Time.deltaTime;
        RaidTimerImg.fillAmount = raidTimer / raidMaxTimer;
    }

    private void gameover()
    {


              if (warriorsCount < 0)
              {
                  Time.timeScale = 0;
                  GameOverScreen.SetActive(true);
              }
              if (raidTimer <= 0)
              {
                    raidMaxTimer += 10;
                    raidTimer = raidMaxTimer;
                  warriorsCount -= nextRaid;
                  nextRaid += raidIncrease;
                  Wave++;
                  a = warr * 30;

              }


              
    }
    private void gamewin()
    {
        if(Wave == 6)
        {
            Time.timeScale = 0;
            GameOverScreen.SetActive(true);
        }
    }

    public void Pause()
    {
        if (!Clik)
        {
            Time.timeScale = 0f;
            Clik = true;
        }
        else
        {
            Time.timeScale = 1f;
            Clik = false;
        }
    }

    public void CreatePeasant()
    {
        wheatCount -= peasantCost;
        peasantTimer = peasantCreateTime;
        peasantButton.interactable = false;
    }
   
    public void CreateWarrior()
    {
        wheatCount -= warriorCost;
        warriorTimer = warriorCreateTime;
        warriorButton.interactable= false;
    }
     private void GameOverText()
    {
        GameoverText.text = "Количество полученых очков:" + a + "\n" + "Количество убитых врагов:" + warr;
    }
    private void GameWinText()
    {
        GamewinText.text ="Отлично ты смог пройти игру"+ "\n" + "Количество полученых очков:" + a + "\n" + "Количество убитых врагов:" + warr;
    }
    private void UpdateText()
    {
        resurseText.text = peasantCount + "\n" + warriorsCount + "\n"  + wheatCount;
        RaidCountText.text = Wave + "\n" + nextRaid;
    }
}
