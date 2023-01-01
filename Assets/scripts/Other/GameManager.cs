using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public bool gamestart = false;
    [SerializeField] Player player;

    private void Start()
    {
        gamestart = false;
        Time.timeScale = 0;
    }
    void Update()
    {
        //start game when we are jumping
        if (Input.GetButton("Jump")&&!gamestart)
        {
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
}
