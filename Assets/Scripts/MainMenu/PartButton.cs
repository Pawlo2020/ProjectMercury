using UnityEngine;
using UnityEngine.UI;

//PartButton class define a button in content panel in construction mode
public class PartButton : MonoBehaviour
{
    //Current part
    Part curPart;

    //Part image var
    public Image partImage;

    //Text for part price
    public Text price;
    public Text ACTUALprice;

    //Init button as capsule button
    public void initCapsule(string id, bool status)
    {
        curPart = PartsManager.getCapsule(id);
        //Check status of part
        if (status is true)
        {
            //Get part from parts manager and texture
            partImage.sprite = TextureLoader.GetTexture(id);

            ACTUALprice.text = "Unlocked";
            ACTUALprice.color = new Color32(46, 204, 113, 255);

            //Add listener delegate for button in case of click
            gameObject.GetComponent<Button>().onClick.AddListener(delegate
            {
                //Change capsule in construction view
                GameObject.Find("Canvas").GetComponent<ConstructorController>().changeCapsule(curPart.Id);

                //Set current part for ship in database
                ProfileManager.setPart(ProfileManager.curShip, 0, id);

                //Reload profile manager data
                ProfileManager.loadData();
            });

        }
        else
        {
            //Disable button
            partImage.enabled = false;

            //Set confidential status for part
            price.text = "Classified!";
            ACTUALprice.text = curPart.Price + "$";


            gameObject.GetComponent<Button>().onClick.AddListener(delegate
            {


                if (ProfileManager.Money >= curPart.Price)
                {
                    //buy
                    ProfileManager.updateMoney(curPart.Price);

                    ProfileManager.unlockPart(curPart.Id, 0);

                    GameObject.Find("Canvas").GetComponent<ConstructorController>().showCapsules();
                }
                else
                {
                    //beep
                }
            });
        }
    }

    public void initMiddles(string id, bool status)
    {
        curPart = PartsManager.getMiddle(id);
        //Check status of part
        if (status is true)
        {
            //Get part from parts manager and texture
            partImage.sprite = TextureLoader.GetTexture(id);

            ACTUALprice.text = "Unlocked";
            ACTUALprice.color = new Color32(46, 204, 113, 255);

            //Add listener delegate for button in case of click
            gameObject.GetComponent<Button>().onClick.AddListener(delegate
            {
                //Change capsule in construction view
                GameObject.Find("Canvas").GetComponent<ConstructorController>().changeMiddle(curPart.Id);

                //Set current part for ship in database
                ProfileManager.setPart(ProfileManager.curShip, 1, id);

                //Reload profile manager data
                ProfileManager.loadData();
            });

        }
        else
        {
            //Disable button
            partImage.enabled = false;

            //Set confidential status for part
            price.text = "Classified!";
            ACTUALprice.text = curPart.Price + "$";


            gameObject.GetComponent<Button>().onClick.AddListener(delegate
            {


                if (ProfileManager.Money >= curPart.Price)
                {
                    //buy
                    ProfileManager.updateMoney(curPart.Price);

                    ProfileManager.unlockPart(curPart.Id, 1);

                    GameObject.Find("Canvas").GetComponent<ConstructorController>().showMiddles();
                }
                else
                {
                    //beep
                }
            });
        }
    }

    public void initEngines(string id, bool status)
    {
        curPart = PartsManager.getEngine(id);
        //Check status of part
        if (status is true)
        {
            //Get part from parts manager and texture
            partImage.sprite = TextureLoader.GetTexture(id);

            ACTUALprice.text = "Unlocked";
            ACTUALprice.color = new Color32(46, 204, 113, 255);

            //Add listener delegate for button in case of click
            gameObject.GetComponent<Button>().onClick.AddListener(delegate
            {
                //Change capsule in construction view
                GameObject.Find("Canvas").GetComponent<ConstructorController>().changeEngine(curPart.Id);

                //Set current part for ship in database
                ProfileManager.setPart(ProfileManager.curShip, 2, id);

                //Reload profile manager data
                ProfileManager.loadData();
            });

        }
        else
        {
            //Disable button
            partImage.enabled = false;

            //Set confidential status for part
            price.text = "Classified!";
            ACTUALprice.text = curPart.Price + "$";


            gameObject.GetComponent<Button>().onClick.AddListener(delegate
            {


                if (ProfileManager.Money >= curPart.Price)
                {
                    //buy
                    ProfileManager.updateMoney(curPart.Price);

                    ProfileManager.unlockPart(curPart.Id, 2);

                    GameObject.Find("Canvas").GetComponent<ConstructorController>().showEngines();
                }
                else
                {
                    //beep
                }
            });
        }
    }

    public void initWings(string id, bool status)
    {
        curPart = PartsManager.getWing(id);
        //Check status of part
        if (status is true)
        {
            //Get part from parts manager and texture
            partImage.sprite = TextureLoader.GetTexture(id);

            ACTUALprice.text = "Unlocked";
            ACTUALprice.color = new Color32(46, 204, 113, 255);

            //Add listener delegate for button in case of click
            gameObject.GetComponent<Button>().onClick.AddListener(delegate
            {
                //Change capsule in construction view
                GameObject.Find("Canvas").GetComponent<ConstructorController>().changeWings(curPart.Id);

                //Set current part for ship in database
                ProfileManager.setPart(ProfileManager.curShip, 3, id);

                //Reload profile manager data
                ProfileManager.loadData();
            });

        }
        else
        {
            //Disable button
            partImage.enabled = false;

            //Set confidential status for part
            price.text = "Classified!";
            ACTUALprice.text = curPart.Price + "$";


            gameObject.GetComponent<Button>().onClick.AddListener(delegate
            {


                if (ProfileManager.Money >= curPart.Price)
                {
                    //buy
                    ProfileManager.updateMoney(curPart.Price);

                    ProfileManager.unlockPart(curPart.Id, 3);

                    GameObject.Find("Canvas").GetComponent<ConstructorController>().showWings();
                }
                else
                {
                    //beep
                }
            });
        }


    }
}
