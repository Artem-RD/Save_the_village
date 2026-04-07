using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class imgChange : MonoBehaviour
{
    public GameObject Panel;
    public Sprite pic1;
    public Sprite pic2;
    public Sprite pic3;
    public Sprite pic4;
    public Image im;
    public Image im1;
    private bool Clik;
    void Start()
    {
         
        im.GetComponent<Image>().sprite = pic1;
        im1.GetComponent<Image>().sprite = pic3;
    }
    public void Swap()
    {
        if (im.sprite == pic1)
        {
            im.sprite = pic2;
            Panel.SetActive(true);
            return;
            
        }

        if (im.sprite == pic2)
        {
            im.sprite = pic1;
            Panel.SetActive(false);
            return;
        }
    }
    public void Swap2()
    {
        if (im1.sprite == pic3)
        {
            im1.sprite = pic4;
            Panel.SetActive(true);
            return;

        }

        if (im1.sprite == pic4)
        {
            im1.sprite = pic3;
            Panel.SetActive(false);
            return;
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

}
