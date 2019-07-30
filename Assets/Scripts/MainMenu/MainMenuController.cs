using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System;
using System.Xml;
using System.Xml.Linq;

//Class responsible for main menu operations
public class MainMenuController : MonoBehaviour
{




    // Start is called before the first frame update
    void Start()
    {
        CreateProfileDb();

        if (!ProfileManager.initialised)
        {
            //Loads parts from database and assigns attrubutes
            PartsManager.init();

            //Loads textures from resources
            TextureLoader.init();

            //Manages user's profile attributes and all three ships
            ProfileManager.init();
        }
    }

    // Update is called once per frame
    void Update() { }

    //Sandbox mode transition
    public void goSandbox()
    {
        SceneManager.LoadScene("GameScene");
    }

    //Career mode transition
    public void goCareer()
    {
        SceneManager.LoadScene("ShipConstructor");
    }

    //Exit transition
    public void goExit()
    {
        Application.Quit();
    }

    public void goSettings()
    {
        SceneManager.LoadScene("Options");
    }

    public void goCredits(){
        SceneManager.LoadScene("Credits");


    }

    public void goMenu(){
        SceneManager.LoadScene("MainMenu");
    }


    public void CreateProfileDb()
    {
        if (!(Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Project Mercury")))
        {
            DirectoryInfo workspace = Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Project Mercury");
        }

        if(!File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/Project Mercury/PlayerProfile.xml")){

            


            XDocument docNew = new XDocument(new XElement("Profile", new XAttribute("money", 0), new XAttribute("prestige", 0), new XAttribute("sound", 1), new XAttribute("music", 1),
                                   new XElement("Rockets", new XElement("R1"), new XElement("R2"), new XElement("R3"))
                                   ,new XElement("UnlockedParts")));

            docNew.Save(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/Project Mercury/PlayerProfile.xml");

            // XAttribute money = new XAttribute("money", 0);
            // XAttribute money = new XAttribute("prestige", 0);
            // XNode profile = docNew.FirstNode;
            // docNew.Root.FirstAttribute.
            // profile.Attributes["money"].Value = "0";
            // profile.Attributes["prestige"].Value = "0";


            unlockStartingParts("Basic-Mk1Cap",0, "UnlockedParts");
            unlockStartingParts("Basic-Mk1Cap",0, "Rockets/R1");
            unlockStartingParts("Basic-Mk1Cap",0, "Rockets/R2");
            unlockStartingParts("Basic-Mk1Cap",0, "Rockets/R3");

            unlockStartingParts("Basic-Mk1Mid", 1, "UnlockedParts");
            unlockStartingParts("Basic-Mk1Mid",1, "Rockets/R1");
            unlockStartingParts("Basic-Mk1Mid",1, "Rockets/R2");
            unlockStartingParts("Basic-Mk1Mid",1, "Rockets/R3");

            unlockStartingParts("Basic-Mk1Eng", 2, "UnlockedParts");
            unlockStartingParts("Basic-Mk1Eng",2, "Rockets/R1");
            unlockStartingParts("Basic-Mk1Eng",2, "Rockets/R2");
            unlockStartingParts("Basic-Mk1Eng",2, "Rockets/R3");

            unlockStartingParts("Basic-Mk1Wing", 3, "UnlockedParts");
            unlockStartingParts("Basic-Mk1Wing", 3, "Rockets/R1");
            unlockStartingParts("Basic-Mk1Wing", 3, "Rockets/R2");
            unlockStartingParts("Basic-Mk1Wing", 3, "Rockets/R3");
            }


    }

    public static void unlockStartingParts(string id, int type, string location)
    {
        XmlDocument doc = new XmlDocument();

        doc.Load(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/Project Mercury/PlayerProfile.xml");

        //Go where we want to go
        XmlNode unlockedPartNodes = doc.DocumentElement.SelectSingleNode("/Profile/" + location);
        XmlAttribute idAttr = doc.CreateAttribute("id");
        idAttr.Value = id;

        switch (type)
        {
            case 0:
                XmlElement part1 = doc.CreateElement("Capsule");
                part1.Attributes.Append(idAttr);

                unlockedPartNodes.InsertAfter(part1, unlockedPartNodes.LastChild);

                doc.Save(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/Project Mercury/PlayerProfile.xml");
                break;
            case 1:
                XmlElement part2 = doc.CreateElement("Middle");

                part2.Attributes.Append(idAttr);

                unlockedPartNodes.InsertAfter(part2, unlockedPartNodes.LastChild);

                doc.Save(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/Project Mercury/PlayerProfile.xml");
                break;

            case 2:
                XmlElement part3 = doc.CreateElement("Engine");

                part3.Attributes.Append(idAttr);

                unlockedPartNodes.InsertAfter(part3, unlockedPartNodes.LastChild);

                doc.Save(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/Project Mercury/PlayerProfile.xml");
                break;

            case 3:

                XmlElement part4 = doc.CreateElement("Wings");


                part4.Attributes.Append(idAttr);

                unlockedPartNodes.InsertAfter(part4, unlockedPartNodes.LastChild);

                doc.Save(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/Project Mercury/PlayerProfile.xml");
                break;
        }
    }









}
