using UnityEngine;


public class FireflyAI : MonoBehaviour
{
    float speed = 2;
    float amplitude = 2;
    float period = 1;
    void Start()
    {
        //Random parameteres to have more diversity
        speed = Random.Range(3, 5);
        amplitude = Random.Range(1,3);
        transform.position = new Vector3(12, Random.Range(-5, 5));
        period = Random.Range(0.2f, 0.6f); 
        UnityEngine.Rendering.Universal.Light2D l = GetComponent<UnityEngine.Rendering.Universal.Light2D>();
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
    void Update()
    {
        //move firefly by some x
        // (-1,0,0) 
        transform.position += Vector3.left * speed * Time.deltaTime;
       // transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
        //then calculate y position based on that x 
        //using sin function with eariler generated parameters
        transform.position = new Vector3(transform.position.x,amplitude*Mathf.Sin( transform.position.x*period), transform.position.z);
        if (transform.position.x < -11)
        {
            Destroy(gameObject);
        }
    }
}
