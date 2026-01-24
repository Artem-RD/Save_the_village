using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audiotimer : MonoBehaviour
{
    [SerializeField] private float raidMaxTimer;
    private float raidTimer;
    private AudioSource War;
    // Start is called before the first frame update
    void Start()
    {
        raidTimer = raidMaxTimer;
        War = GetComponent<AudioSource>();
        War.Pause();
    }
    private void raidtimer()
    {
        raidTimer -= Time.deltaTime;
    }
    public void chengeSoundPlay()
    {
        if (War.isPlaying)
        {
            War.Pause();
        }
        else
        {
            War.Play();
        }
    }
    private void stoptimer()
    {
        if (raidTimer <= 0)
        {
            raidMaxTimer += 10.5f;
            raidTimer = raidMaxTimer;
            chengeSoundPlay();
        }
    }
    // Update is called once per frame
    void Update()
    {
        stoptimer();
        raidtimer();
    }
}
