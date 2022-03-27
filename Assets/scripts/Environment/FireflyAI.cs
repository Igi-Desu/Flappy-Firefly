using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class FireflyAI : MonoBehaviour
{
    //AI swietlika
    float speed = 2;
    float amplitude = 2;
    float period = 1;
    void Start()
    {
        //losuje jego parametry zeby by³a wiêksza ró¿norodnoœæ
        speed = Random.Range(3, 5);
        amplitude = Random.Range(1,3);
        transform.position = new Vector3(12, Random.Range(-5, 5));
        period = Random.Range(0.2f, 0.6f); 
        Light2D l = GetComponent<Light2D>();
        switch (Random.Range(0, 5))
        {
            case 0:
                l.color = Color.red;
                break;
            case 1:
                l.color = Color.yellow;
                break;
            case 2:
                l.color = Color.blue;
                break;
            case 3:
                l.color = Color.green;
                break;
            case 4:
                break;
        }
       
    }


    // Update is called once per frame
    void Update()
    {
        //przesuwam swietlika o jakis x
        transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
        //nastepnie jego y ustalam przez funkcje sinusa tak aby lata³ podobnie do wykresu tej funkcji 
        //daje to ciekawy faluj¹cy efekt
        //wszystkie parametry takie amplituda czy okres sa losowo wybierane na samym pocz¹tku
        transform.position = new Vector3(transform.position.x,amplitude*Mathf.Sin( transform.position.x*period), transform.position.z);
        if (transform.position.x < -11)
        {
            Destroy(gameObject);
        }
    }
}
