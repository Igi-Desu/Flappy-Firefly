using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField][Range(0,10)]private float jumpforce = 5f;
    private Rigidbody2D rb;
    public Score_Counter sc;
    private Light2D light;
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
        light = GetComponent<Light2D>();
        setrb(false);
    }

    // Update is called once per frame
    //Prócz movementu jest tu tak¿e zawarty efekt migania
    void Update()
    {
        if (!manager.gamestart) return;
        if (Input.GetButton("Jump"))
        {
            rb.velocity= new Vector2(0, jumpforce);
            //to by bylo potrzebne gdybym uzywa³ add force bo spamujac spacje velocity.y by bylo zbyt wysokie
            //rb.velocity = new Vector2(0, Mathf.Clamp(rb.velocity.y, -5, 5));
        }
        //U¿ywam moveTowards zeby zmienic intensywnosc swiatla 
        //mam tablice dwoch intensywnosci miedzy ktorymi swietlik przechodzi na zmianê
        light.intensity = Mathf.MoveTowards(light.intensity, intesities[iter], Time.deltaTime * 5);
        //jesli juz dojdzie do konkretnej intensywnosci
        if (light.intensity == intesities[iter]) {
            //to zwiekszam iter ktory okresla do ktorej idzie
            iter++;
            //jesli wychodzi za granice tablicy intensywnosci to go resetuje
            if (iter == intesities.Length)
            {
                iter = 0;
            }
        }
    }
    public void setrb(bool value)
    { 
        rb.bodyType = (value) ? RigidbodyType2D.Dynamic : RigidbodyType2D.Static;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //pomiedzy "pniami" mamy collider ustawiony na ontrigger z tagiem ScoreInc
        //Jak wlecimy w niego to oznacza ze powinnismy dostac punkt wiec inkrementuje wynik
        if (collision.tag == "ScoreInc")
        {
            //Wykorzystalem get i set aby prócz zwiekszenia wyniku zmieni³a siê wartoœæ w UI
            sc.Score++;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //jak trafimy na jakas kolizjê to koniec gry
        GameManager.deathanim(gameObject);
        Animator an = GetComponent<Animator>();
        //ustawiamy updatemode animatora tak aby juz swietlik nie lecial
        an.updateMode = AnimatorUpdateMode.Normal;
        gameOverCanvas.enabled = true;
        Time.timeScale = 0;
    }
}
