using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeSpike : MonoBehaviour
{
    float speed;

    private void Start()
    {
        speed = gameObject.GetComponent<Wood_Spike>().speed;
    }
    // Update is called once per frame
    void Update()
    {
        //jak osiagnie konkretna pozycje to
        if (transform.position.x < 3)
        {
            //bierzemy pierwsze dziecko i przesuwamy w dó³ (dó³ pnia)
            transform.GetChild(0).transform.localPosition = Vector3.MoveTowards(transform.GetChild(0).transform.localPosition,
                new Vector3(0, -2, 0), speed * Time.deltaTime);
            //drugie i przesuwamy w góre (góra pnia)
            transform.GetChild(1).transform.localPosition = Vector3.MoveTowards(transform.GetChild(1).transform.localPosition,
               new Vector3(0, 2, 0), speed * Time.deltaTime);
        }
    }
}
