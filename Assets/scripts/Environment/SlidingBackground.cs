using UnityEngine;

public class SlidingBackground : MonoBehaviour
{
    private float size;
    //use speed to make parallax effect
    [SerializeField]private float speed=2;

    private void Start()
    {
        //Background in my project is just two backgrounds joined while one is child
        //size of that background will be position of child on x  
        size = transform.GetChild(0).transform.localPosition.x;
    }
    void Update()
    {
        //if main background gets behind that size just reset position to make infinite background effect
        transform.position += new Vector3(-speed * Time.deltaTime, 0,0);
        if (transform.position.x <= -size)
        {
            transform.position = new Vector3(0, transform.position.y, transform.position.z);
        }
    }
}
