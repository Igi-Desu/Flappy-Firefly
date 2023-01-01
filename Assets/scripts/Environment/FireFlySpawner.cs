using UnityEngine;

public class FireFlySpawner : MonoBehaviour
{
    //simple script just spawn firefly when timer gets to 0
    [SerializeField]float timerbase;
    float timer;
    [SerializeField]GameObject firefly;
    private void Start()
    {
        timer = timerbase;
    }
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
