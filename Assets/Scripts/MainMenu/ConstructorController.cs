using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//ConstructorController class - responsible for construction mode operations
public class ConstructorController : MonoBehaviour
{
    //Parts images needed for updating construction view
    public Image capsuleImg;
    public Image middleImg;
    public Image engineImg;
    public Image wingsImg;

    //Parts tabs
    public Button capsulesBtn;
    public Button middlesBtn;
    public Button enginesBtn;
    public Button wingsBtn;

    public Button ship1Btn;
    public Button ship2Btn;
    public Button ship3Btn;
    //Parts content panel
    public Transform ContentPanel;

    public Text MoneyText;
    public Text PrestigeText;
    public GameObject Button;

    //Variables for buttons colors
    ColorBlock enabledColor;
    ColorBlock disabledColor;
    // Update is called once per frame
    void Update() { 
        MoneyText.text = "Money: " + ProfileManager.Money.ToString();
        PrestigeText.text = "Prestige: " + ProfileManager.PrestigePoints.ToString();
         }

    //In case of capsulesBtn onClick event - change tab color and load capsules images for dynamically generated buttons
    public void showCapsules()
    {
        //Change appriopriate colors for tabs
        capsulesBtn.colors = enabledColor;
        setBtnTextColor(capsulesBtn, new Color32(255, 255, 255, 255));

        middlesBtn.colors = disabledColor;
        setBtnTextColor(middlesBtn, new Color32(50, 50, 50, 255));

        enginesBtn.colors = disabledColor;
        setBtnTextColor(enginesBtn, new Color32(50, 50, 50, 255));

        wingsBtn.colors = disabledColor;
        setBtnTextColor(wingsBtn, new Color32(50, 50, 50, 255));

        //Clear content panel
        clearContentPanel();

         ProfileManager.loadData();

        //Load all capsules parts from main parts database
        foreach (Part part in PartsManager.Capsules.Values)
        {
            //Create GameObject as original button for ContentPanel
            GameObject btn = (GameObject)Instantiate(Button, ContentPanel);
            
            //Define button as PartButton object for capsule from xml database
            btn.GetComponent<PartButton>().initCapsule(part.Id, ProfileManager.checkPart(part.Id));
        }

    }

    //In case of middlesBtn onClick event - change tab color and load middles images for dynamically generated buttons
    public void showMiddles()
    {
        //Change appriopriate colors for tabs
        capsulesBtn.colors = disabledColor;
        setBtnTextColor(capsulesBtn, new Color32(50, 50, 50, 255));

        middlesBtn.colors = enabledColor;
        setBtnTextColor(middlesBtn, new Color32(255, 255, 255, 255));

        enginesBtn.colors = disabledColor;
        setBtnTextColor(enginesBtn, new Color32(50, 50, 50, 255));

        wingsBtn.colors = disabledColor;
        setBtnTextColor(wingsBtn, new Color32(50, 50, 50, 255));

        //Clear content panel
        clearContentPanel();

         ProfileManager.loadData();

        //Load all middles parts from main parts database
        foreach (Part part in PartsManager.Middles.Values)
        {
            //Create GameObject as original button for ContentPanel
            GameObject btn = (GameObject)Instantiate(Button, ContentPanel);

            Debug.Log(ProfileManager.checkPart(part.Id));
            //Define button as PartButton object for middle from xml database
            btn.GetComponent<PartButton>().initMiddles(part.Id, ProfileManager.checkPart(part.Id));
        }
    }

    //Setting appriopriate color for button
    void setBtnTextColor(Button btn, Color32 clr)
    {
        btn.gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().color = clr;
    }

    //In case of enginesBtn onClick event - change tab color and load middles images for dynamically generated buttons
    public void showEngines()
    {
        //Change appriopriate colors for tabs
        capsulesBtn.colors = disabledColor;
        setBtnTextColor(capsulesBtn, new Color32(50, 50, 50, 255));

        middlesBtn.colors = disabledColor;
        setBtnTextColor(middlesBtn, new Color32(50, 50, 50, 255));

        enginesBtn.colors = enabledColor;
        setBtnTextColor(enginesBtn, new Color32(255, 255, 255, 255));

        wingsBtn.colors = disabledColor;
        setBtnTextColor(wingsBtn, new Color32(50, 50, 50, 255));

        //Clear content panel
        clearContentPanel();

         ProfileManager.loadData();

        //Load all engines parts from main parts database
        foreach (Part part in PartsManager.Engines.Values)
        {
            //Create GameObject as original button for ContentPanel
            GameObject btn = (GameObject)Instantiate(Button, ContentPanel);


            //Define button as PartButton object for middle from xml database
            btn.GetComponent<PartButton>().initEngines(part.Id, ProfileManager.checkPart(part.Id));
        }
    }

    //In case of wingsBtn onClick event - change tab color and load middles images for dynamically generated buttons
    public void showWings()
    {
        //Change appriopriate colors for tabs
        capsulesBtn.colors = disabledColor;
        setBtnTextColor(capsulesBtn, new Color32(50, 50, 50, 255));

        middlesBtn.colors = disabledColor;
        setBtnTextColor(middlesBtn, new Color32(50, 50, 50, 255));

        enginesBtn.colors = disabledColor;
        setBtnTextColor(enginesBtn, new Color32(50, 50, 50, 255));

        wingsBtn.colors = enabledColor;
        setBtnTextColor(wingsBtn, new Color32(255, 255, 255, 255));

        //Clear content panel
        clearContentPanel();

         ProfileManager.loadData();

        //Load all wings parts from main parts database
        foreach (Part part in PartsManager.Wings.Values)
        {
            //Create GameObject as original button for ContentPanel
            GameObject btn = (GameObject)Instantiate(Button, ContentPanel);

            //Define button as PartButton object for middle from xml database
            btn.GetComponent<PartButton>().initWings(part.Id, ProfileManager.checkPart(part.Id));
        }
    }

    //Clearing content panel
    void clearContentPanel()
    {
        for (int i = 0; i < ContentPanel.childCount; i++)
        {
            //Destroy GameObject
            GameObject.Destroy(ContentPanel.GetChild(i).gameObject);
        }
    }

    //Ship 1 onClick event
    public void selectShip1()
    {
        loadShip(1);

        ship1Btn.colors = enabledColor;
        setBtnTextColor(ship1Btn, new Color32(255, 255, 255, 255));

        ship2Btn.colors = disabledColor;
        setBtnTextColor(ship2Btn, new Color32(50, 50, 50, 255));

        ship3Btn.colors = disabledColor;
        setBtnTextColor(ship3Btn, new Color32(50, 50, 50, 255));
    }

    //Ship 2 onClick event
    public void selectShip2()
    {
        //Load ship 2
        loadShip(2);

        ship1Btn.colors = disabledColor;
        setBtnTextColor(ship1Btn, new Color32(50, 50, 50, 255));

        ship2Btn.colors = enabledColor;
        setBtnTextColor(ship2Btn, new Color32(255, 255, 255, 255));

        ship3Btn.colors = disabledColor;
        setBtnTextColor(ship3Btn, new Color32(50, 50, 50, 255));
    }

    //Ship 3 onClick event
    public void selectShip3()
    {
        loadShip(3);

        ship1Btn.colors = disabledColor;
        setBtnTextColor(ship1Btn, new Color32(50, 50, 50, 255));

        ship2Btn.colors = disabledColor;
        setBtnTextColor(ship2Btn, new Color32(50, 50, 50, 255));

        ship3Btn.colors = enabledColor;
        setBtnTextColor(ship3Btn, new Color32(255, 255, 255, 255));
    }

    //Load specific ship parts - get texture of saved parts of rocket and change selected ship
    void loadShip(int nr)
    {
        capsuleImg.sprite = TextureLoader.GetTexture(ProfileManager.getPart(nr, 0).Id);
        middleImg.sprite = TextureLoader.GetTexture(ProfileManager.getPart(nr, 1).Id);
        engineImg.sprite = TextureLoader.GetTexture(ProfileManager.getPart(nr, 2).Id);
        wingsImg.sprite = TextureLoader.GetTexture(ProfileManager.getPart(nr, 3).Id);

        ProfileManager.curShip = nr;
    }

    //Starting scene method
    void Start()
    {
        //Change colors of tab buttons
        enabledColor = capsulesBtn.colors;
        disabledColor = capsulesBtn.colors;

        disabledColor.normalColor = new Color32(255, 255, 255, 255);

        enabledColor.normalColor = new Color32(108, 92, 231, 255);
        enabledColor.pressedColor = new Color32(108, 92, 231, 255);
        enabledColor.highlightedColor = new Color32(108, 92, 231, 255);

        //Load ship 1 by default
        selectShip1(); 

        showCapsules();
    }



    //Return to main menu
    public void goReturn()
    {
        SceneManager.LoadScene("MainMenu");
    }

    //Change capsule in ship
    public void changeCapsule(string id)
    {
        capsuleImg.sprite = TextureLoader.GetTexture(id);
    }

    //Go to the fly scene
    public void fly()
    {
        SceneManager.LoadScene("GameScene");
    }

    //Change middle in ship
    public void changeMiddle(string id)
    {
        middleImg.sprite = TextureLoader.GetTexture(id);
    }

    //Change engine in ship
    public void changeEngine(string id)
    {
        engineImg.sprite = TextureLoader.GetTexture(id);
    }

    //Change wings in ship
    public void changeWings(string id)
    {
        wingsImg.sprite = TextureLoader.GetTexture(id);
    }
}

