using UnityEngine;
using UnityEngine.SceneManagement;

//PauseController class register pause induced by user
public class PauseController : MonoBehaviour
{
    //Current game scene provided by GameController var
    GameController GC;

    // Start is called before the first frame update
    void Start()
    {
        GC = GameObject.Find("Game").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update() { }

    //Resume game
    public void Resume()
    {
        Time.timeScale = 1f;
        GC.isPaused = false;
        Destroy(GC.pauseObject);
    }

    public void Restart(){
        SceneManager.LoadScene("GameScene");
        Time.timeScale = 1f;
    }

    //Quit from game scene
    public void Quit()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;

    }
}
