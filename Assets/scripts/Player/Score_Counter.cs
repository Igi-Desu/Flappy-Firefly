using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Score_Counter : MonoBehaviour
{
    //nasz wynik
    public int score;
   //i tutaj getter i setter wlasny
    public int Score {
        get { return this.score; } 
        set {
            //ustawiam score na now¹ wartoœæ
            this.score = value; 
            //zmieniam tekst
            GetComponent<Text>().text = this.score.ToString(); 
        } 
    }
    private void Start()
    {
        Score = 0;
    }

}
