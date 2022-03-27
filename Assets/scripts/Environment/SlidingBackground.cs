using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingBackground : MonoBehaviour
{
    //skrypt do przesuwaj¹cych siê te³
    private float size;
    [SerializeField]private float speed=2;
    private void Start()
    {
        //Ka¿de przesuwaj¹ce siê t³o powinno mieæ drugie takie same jakoœ dziecko 
        //jesli przesuniemy za te pole
        //           V
        //[ t³o1   ][  t³o2  ]
        //to cofamy spowrotem wtedy otrzymujemy wra¿enie ¿e jest nieskoñczone t³o
        size = transform.GetChild(0).transform.localPosition.x;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(-speed * Time.deltaTime, 0,0);
        if (transform.position.x <= -size)
        {
            transform.position = new Vector3(0, transform.position.y, transform.position.z);
        }
    }
}
