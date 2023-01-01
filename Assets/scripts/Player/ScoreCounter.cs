using UnityEngine;
using UnityEngine.UI;
public class ScoreCounter : MonoBehaviour
{
    public int score;
    //setter that also shows the score on UI
    public int Score {
        get { return this.score; } 
        set {
            this.score = value; 
            GetComponent<Text>().text = this.score.ToString(); 
        } 
    }
    private void Start()
    {
        Score = 0;
    }

}
