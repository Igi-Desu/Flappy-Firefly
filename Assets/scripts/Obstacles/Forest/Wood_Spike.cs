using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood_Spike : MonoBehaviour
{
    //szybkosc przesuwania sie kolca
    public float speed = 1;

    void Update()
    {
        //zwykle przesuniecie
        transform.position += new Vector3(-speed * Time.deltaTime, 0,0);
        //usuwam obiekt jesli wyjdzie poza screen zeby nie bylo ich zbyt duzo
        if (transform.position.x < -11)
        {
            Destroy(gameObject);
        }
    }
}
