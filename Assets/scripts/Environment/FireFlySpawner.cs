using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireFlySpawner : MonoBehaviour
{
    //prosty timer i objekt swietlika 
    //timer spadnie do zera to tworze swietlika i od nowa timer
    [SerializeField]float timerbase;
    float timer;
    [SerializeField]GameObject firefly;
    private void Start()
    {
        timer = timerbase;
    }
    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            timer = timerbase;
            Instantiate(firefly);
        }
    }
}
