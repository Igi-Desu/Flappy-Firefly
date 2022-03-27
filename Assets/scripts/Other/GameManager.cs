using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;
public class GameManager : MonoBehaviour
{
    public bool gamestart = false;
    [SerializeField] Movement player;

    private void Start()
    {
        gamestart = false;
        Time.timeScale = 0;
    }
    void Update()
    {
        if (Input.GetButton("Jump")&&!gamestart)
        {
            Debug.Log("ABC");
            player.setrb(true);
            gamestart = true;
            Time.timeScale = 1;
        }
    }
    public static void StartGame()
    {
        SceneManager.LoadScene(0,LoadSceneMode.Single);
    }
    public static void QuitGame()
    {
        Application.Quit();
    }
    public static void deathanim(GameObject player)
    {
      //  p.Play();
    }
}
