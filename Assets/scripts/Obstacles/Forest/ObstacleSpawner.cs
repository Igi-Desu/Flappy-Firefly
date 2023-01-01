using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{

    [SerializeField]float spawn_speed_base = 2;
    float spawn_speed;
    //all obstacles that can be instantiated
    public GameObject[] Obstacles= new GameObject[2];
    void Start()
    {
        spawn_speed = spawn_speed_base;
    }

    void Update()
    {
        spawn_speed -= Time.deltaTime;
        if (spawn_speed <= 0)
        {
            //get a random number spawn obstacle do again 
            int i = Random.Range(0, Obstacles.Length);
            spawn_speed =  Random.Range(spawn_speed_base/2, spawn_speed_base);
            float randy = 0 + 0.5f * Random.Range(-4, 5);
            Instantiate(Obstacles[i],
                new Vector3(Obstacles[i].transform.position.x,randy,Obstacles[i].transform.position.z)
                ,Obstacles[i].transform.rotation);
        }
    }
}
