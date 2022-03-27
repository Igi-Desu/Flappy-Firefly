using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoreinc : MonoBehaviour
{
    //Useless skrypt

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Shiet");
        if (collision.tag == "Player")
        {
            Movement m = collision.GetComponent<Movement>();
            m.sc.score++;
        }
    }
}
