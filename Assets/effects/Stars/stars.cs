using UnityEngine;


public class stars : MonoBehaviour
{
    // Start is called before the first frame updat
    UnityEngine.Rendering.Universal.Light2D light;
    Vector3[] colors= new Vector3[4];
    int tableit = 0;
    //dwie funkcje rzutuj�ce wektor na color i na odwr�t
    Color vecttocol(Vector3 v)
    {
        return new Color(v.x, v.y, v.z);
       
    }
    Vector3 coltovect(Color v)
    {
        return new Vector3(v.r, v.g, v.b);
       
    }
    void Start()
    {
        //tablica kolor�w gwiazd miedzy ktorymi b�d� przechodzi�
        colors[0] = new Vector3(1, 0, 0);
        colors[1] = new Vector3(0, 1, 0);
        colors[2] = new Vector3(0, 0, 1);
        colors[3] = new Vector3(1, 1, 1);
        light = GetComponent<UnityEngine.Rendering.Universal.Light2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //dokladnie tak samo jak w skrypcie gracza przy miganiu
        //tylko zamiast mathf move towards wykorzystuje vector3.movetowards
        Vector3 actcolor = coltovect(light.color);
       actcolor= Vector3.MoveTowards(actcolor, colors[tableit], 1 * Time.deltaTime);
        if (actcolor == colors[tableit])
        {
            tableit++;
            if (tableit == colors.Length)
            {
                tableit = 0;
            }
        }
        light.color = vecttocol(actcolor);
    }
}
