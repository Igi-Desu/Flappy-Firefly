using UnityEngine;

public class WoodSpike : MonoBehaviour
{
    
    public float speed = 1;

    protected void Update()
    {
        //just move the spike and destroy it once it's far offscreen 
        transform.position += new Vector3(-speed * Time.deltaTime, 0,0);
        if (transform.position.x < -11)
        {
            Destroy(gameObject);
        }
    }
}
