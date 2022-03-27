using UnityEngine;

public class Obstacle_Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    //bazowy czas spawnu 
    [SerializeField]float spawn_speed_base = 5;
    //timer
    float spawn_speed;
    //tablica przeszkód
    public GameObject[] Obstacles= new GameObject[2];
    void Start()
    {

        spawn_speed = spawn_speed_base;
    }

    // Update is called once per frame
    void Update()
    {
        //zmniejszam timer o delta time
        spawn_speed -= Time.deltaTime;
        if (spawn_speed <= 0)
        {
            //jak mamy zero to losuje ktory obstacle ma sie pojawic
            int i = Random.Range(0, Obstacles.Length);
            //resetuje timer
            spawn_speed = spawn_speed_base;
            //losuje pewna liczbe z konkretnego przedzialu
            float randy = 0 + 0.5f * Random.Range(-4, 5);
            //ta liczba reprezentuje jak wysoko ma sie pojawic przeszkoda
            Instantiate(Obstacles[i],
                new Vector3(Obstacles[i].transform.position.x,randy,Obstacles[i].transform.position.z)
                ,Obstacles[i].transform.rotation);
        }
    }
}
