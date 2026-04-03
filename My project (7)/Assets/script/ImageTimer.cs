using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageTimer : MonoBehaviour
{
    [SerializeField]private float MaxTime;
    public bool Tick;
    private Image Img;
    private float CurrentTime;

    // Start is called before the first frame update
    void Start()
    {
        Img = GetComponent<Image>();
        CurrentTime = MaxTime;
    }

    // Update is called once per frame
    void Update()
    {
        Tick= false;
        CurrentTime -= Time.deltaTime;
        if(CurrentTime <= 0 )
        {
            Tick = true;
            CurrentTime = MaxTime;
        }
        Img.fillAmount = CurrentTime/ MaxTime;
    }
}
