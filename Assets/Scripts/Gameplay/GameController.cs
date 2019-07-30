using UnityEngine;
using UnityEngine.SceneManagement;
using System;

//GameController class - operate gameplay
public class GameController : MonoBehaviour
{
    //Capsule texture renderer
    public SpriteRenderer capsuleImg;

    //Middle texture renderer
    public SpriteRenderer middleImg;

    //Engine texture renderer
    public SpriteRenderer engineImg;

    //Wings texture renderer
    public SpriteRenderer wingsImg;

    //Pause status var
    public bool isPaused = false;

    //Pause menu handlers
    public GameObject pauseMenu;
    public GameObject pauseObject;

    public GameObject moneyPrefab;

    public GameObject defeatPrefab;
    public GameObject victoryPrefab;
    //Canvas for pause menu
    public Transform Canvas;

    // Start is called before the first frame update
    void Start()
    {
        //Load current ship for gameplay
        loadShip(ProfileManager.curShip);
    }

    //Loading textures for current ship
    void loadShip(int nr)
    {
        capsuleImg.sprite = TextureLoader.GetTexture(ProfileManager.getPart(nr, 0).Id);
        capsuleImg.gameObject.GetComponent<Module>().fuel = PartsManager.getCapsule(ProfileManager.getPart(nr, 0).Id).Fuel;
        capsuleImg.gameObject.GetComponent<Module>().startingFuel = PartsManager.getCapsule(ProfileManager.getPart(nr, 0).Id).Fuel;
        capsuleImg.gameObject.GetComponent<Module>().force = PartsManager.getCapsule(ProfileManager.getPart(nr, 0).Id).Force;



        middleImg.sprite = TextureLoader.GetTexture(ProfileManager.getPart(nr, 1).Id);
        middleImg.gameObject.GetComponent<Module>().fuel = PartsManager.getMiddle(ProfileManager.getPart(nr, 1).Id).Fuel;
        middleImg.gameObject.GetComponent<Module>().startingFuel = PartsManager.getMiddle(ProfileManager.getPart(nr, 1).Id).Fuel;
        middleImg.gameObject.GetComponent<Module>().force = PartsManager.getMiddle(ProfileManager.getPart(nr, 1).Id).Force;


        engineImg.sprite = TextureLoader.GetTexture(ProfileManager.getPart(nr, 2).Id);
        engineImg.gameObject.GetComponent<Module>().fuel = PartsManager.getEngine(ProfileManager.getPart(nr, 2).Id).Fuel;
        engineImg.gameObject.GetComponent<Module>().startingFuel = PartsManager.getEngine(ProfileManager.getPart(nr, 2).Id).Fuel;
        engineImg.gameObject.GetComponent<Module>().force = PartsManager.getEngine(ProfileManager.getPart(nr, 2).Id).Force;


        wingsImg.sprite = TextureLoader.GetTexture(ProfileManager.getPart(nr, 3).Id);
        engineImg.gameObject.GetComponent<Module>().rotation = PartsManager.getWing(ProfileManager.getPart(nr, 3).Id).Rotation;

        ProfileManager.curShip = nr;
    }

    int lastHeight = 0;
    bool victorious = false;
    bool defeated = false;
    // Update is called once per frame
    void Update()
    {

        if (((int)capsuleImg.gameObject.transform.position.y % 10) == 0 && lastHeight != (int)capsuleImg.gameObject.transform.position.y)
        {
            lastHeight = (int)capsuleImg.gameObject.transform.position.y;
            spawnMoney();
        }

        if (capsuleImg.gameObject.transform.position.y > 12000 && !victorious)
            showVictory();

        //spawnMoney();

        if (!isPaused)
        {
            //Pressed Esc key - invoke Pause menu
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (!victorious && !defeated)
                {
                    isPaused = true;
                    Time.timeScale = 0f;
                    pauseObject = (GameObject)Instantiate(pauseMenu, Canvas);
                }

            }

            //Pressed R key - Reload gamescene
            if (Input.GetKey(KeyCode.R))
            {
                SceneManager.LoadScene("GameScene");
            }

        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (!victorious && !defeated)
                {
                    Time.timeScale = 1f;
                    isPaused = false;
                    Destroy(pauseObject);
                }
            }
        }
    }

    public void showDefeat()
    {
        if (!victorious && !defeated)
        {
            defeated = true;
            CurrentParameters canvas = GameObject.Find("Canvas").GetComponent<CurrentParameters>();
            GameObject defeat = (GameObject)Instantiate(defeatPrefab, Canvas);
            defeat.GetComponent<DefeatScreenController>().init(canvas.collectedMoney, canvas.missionValueStr);
        }

    }

    public void showVictory()
    {
        if (!victorious && !defeated)
        {
            victorious = true;
            Time.timeScale = 0f;
            CurrentParameters canvas = GameObject.Find("Canvas").GetComponent<CurrentParameters>();
            GameObject victory = (GameObject)Instantiate(victoryPrefab, Canvas);
            victory.GetComponent<DefeatScreenController>().init(canvas.collectedMoney, canvas.missionValueStr);

        }
    }

    public void spawnMoney()
    {
        GameObject money = (GameObject)Instantiate(moneyPrefab, new Vector3(UnityEngine.Random.Range(capsuleImg.gameObject.transform.position.x - 30f, capsuleImg.gameObject.transform.position.x + 30f), capsuleImg.gameObject.transform.position.y + 25f, capsuleImg.gameObject.transform.position.z), moneyPrefab.transform.rotation);
        money.GetComponent<MoneyElement>().init();
    }
}

