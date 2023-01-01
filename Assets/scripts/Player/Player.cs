using UnityEngine;


public class Player : MonoBehaviour
{
    [SerializeField][Range(0,10)]private float jumpforce = 5f;
    private Rigidbody2D rb;
    public ScoreCounter sc;
    private UnityEngine.Rendering.Universal.Light2D light;
    float[] intesities = new float[2];
    int iter = 0;
    [SerializeField]Canvas gameOverCanvas;
    [SerializeField] GameManager manager;
    void Start()
    {
        gameOverCanvas.enabled = false;
        intesities[0] = 2.5f;
        intesities[1] = 3.5f;
        rb = GetComponent<Rigidbody2D>();
        light = GetComponent<UnityEngine.Rendering.Universal.Light2D>();
        setrb(false);
    }

    void Update()
    {
        if (!manager.gamestart) return;
        if (Input.GetButton("Jump"))
        {
            //velocity gives better feel than addforce
            rb.velocity= new Vector2(0, jumpforce);
        }
        light.intensity = Mathf.MoveTowards(light.intensity, intesities[iter], Time.deltaTime * 5);
        if (light.intensity == intesities[iter]) {
            iter++;
            if (iter == intesities.Length)
            {
                iter = 0;
            }
        }
    }
    //set rb dynamic or static to prevent movement
    public void setrb(bool value)
    { 
        rb.bodyType = (value) ? RigidbodyType2D.Dynamic : RigidbodyType2D.Static;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //between trunks there's collider to check if we should increase score 
        if (collision.tag == "ScoreInc")
        {
            sc.Score++;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //If we enter any collsion - game over
        //make animator update mode normal so player will stop flapping
        Animator an = GetComponent<Animator>();
        an.updateMode = AnimatorUpdateMode.Normal;
        gameOverCanvas.enabled = true;
        Time.timeScale = 0;
    }
}
