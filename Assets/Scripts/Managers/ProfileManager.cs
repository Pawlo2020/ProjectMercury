using System.Collections.Generic;
using System.Xml;
using System;
using System.Linq;
using UnityEngine;

//ProfileManager - class user profile operations
public static class ProfileManager
{
    public static float soundVol = 1;
    public static float musicVol = 1;
    public static bool initialised = false;

    //Selected current ship (default: ship 1)
    public static int curShip = 1;

    //User's money value
    public static int Money { get; set; }

    //User's prestige points value
    public static int PrestigePoints { get; set; }

    //Dictionaries store all current selected parts for all ships 
    static Dictionary<string, Part> R1Parts = new Dictionary<string, Part>();
    static Dictionary<string, Part> R2Parts = new Dictionary<string, Part>();
    static Dictionary<string, Part> R3Parts = new Dictionary<string, Part>();

    //Dictionary stores unlocked and bought parts by user
    static Dictionary<string, Part> UnlockedParts = new Dictionary<string, Part>();

    //Profile xml database handler
    public static XmlDocument profileDataHandler = new XmlDocument();

    //Instantiates parts for all ships and loads unlocked
    public static void init()
    {
        //Loading profile xml database file
        profileDataHandler.Load(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/Project Mercury/PlayerProfile.xml");

        //Get nodes of all three ships
        XmlNodeList R1Nodes = profileDataHandler.SelectNodes(@"/Profile/Rockets/R1/*");
        XmlNodeList R2Nodes = profileDataHandler.SelectNodes(@"/Profile/Rockets/R2/*");
        XmlNodeList R3Nodes = profileDataHandler.SelectNodes(@"/Profile/Rockets/R3/*");

        //Load current parts into dictionaries for all three ships
        loadData();

        initialised = true;
    }

    //Check if part is unlocked
    public static bool checkPart(string id)
    {   
        //Checking in UnlockedParts dictionary
        foreach (KeyValuePair<string, Part> item in UnlockedParts)
        {
            if (item.Value.Id == id)
            {
                return true;
            }
        }
        return false;
    }

    public static void loadUnlocked()
    {
        XmlNodeList UnlockedNodes = profileDataHandler.SelectNodes(@"Profile/UnlockedParts/*");

        UnlockedParts.Clear();

        //Store unlocked parts in dictionary. Get part by node id value from specific group in database
        foreach (XmlNode node in UnlockedNodes)
        {
            if (node.Name == "Capsule")
                UnlockedParts.Add(node.Attributes["id"].Value, PartsManager.getCapsule(node.Attributes["id"].Value));

            if (node.Name == "Middle")
                UnlockedParts.Add(node.Attributes["id"].Value, PartsManager.getMiddle(node.Attributes["id"].Value));

            if (node.Name == "Engine")
                UnlockedParts.Add(node.Attributes["id"].Value, PartsManager.getEngine(node.Attributes["id"].Value));

            if (node.Name == "Wings")
                UnlockedParts.Add(node.Attributes["id"].Value, PartsManager.getWing(node.Attributes["id"].Value));
        }
    }



    //Get current part from ship (as a Part object)
    public static Part getPart(int RN, string id)
    {
        switch (RN)
        {
            case 1:
                return R1Parts[id];

            case 2:
                return R2Parts[id];

            case 3:
                return R3Parts[id];

            default:
                return null;
        }
    }


    //Get current part from ship (as a Part object)
    public static Part getPart(int RN, int index)
    {
        switch (RN)
        {
            case 1:
                return R1Parts.ElementAt(index).Value;

            case 2:
                return R2Parts.ElementAt(index).Value;

            case 3:
                return R3Parts.ElementAt(index).Value;

            default:
                return null;
        }
    }

    //Load current parts into dictionaries for all three ships
    public static void loadData()
    {
        profileDataHandler.Load(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/Project Mercury/PlayerProfile.xml");

        XmlNode profileNode = profileDataHandler.SelectSingleNode(@"/Profile");
        Money = Convert.ToInt32(profileNode.Attributes["money"].Value);
        PrestigePoints = Convert.ToInt32(profileNode.Attributes["prestige"].Value);

        musicVol = float.Parse(profileNode.Attributes["music"].Value);
        soundVol = float.Parse(profileNode.Attributes["sound"].Value);

        R1Parts = loadParts("R1");
        R2Parts = loadParts("R2");
        R3Parts = loadParts("R3");

        loadUnlocked();
    }

    static string profilePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/Project Mercury/PlayerProfile.xml";

    //Set current part for ship
    public static void setPart(int RN, int index, string id)
    {
        switch (RN)
        {
            //Ship 1
            case 1:
                XmlNodeList part = profileDataHandler.SelectNodes(@"/Profile/Rockets/R" + RN + "/*");

                //Set new id attribute
                part[index].Attributes["id"].Value = id;

                profileDataHandler.Save(profilePath);
                break;

            //Ship 2
            case 2:
                XmlNodeList part2 = profileDataHandler.SelectNodes(@"/Profile/Rockets/R" + RN + "/*");

                //Set new id attribute
                part2[index].Attributes["id"].Value = id;

                profileDataHandler.Save(profilePath);
                break;

            //Ship 3
            case 3:
                XmlNodeList part3 = profileDataHandler.SelectNodes(@"/Profile/Rockets/R" + RN + "/*");

                //Set new id attribute
                part3[index].Attributes["id"].Value = id;

                profileDataHandler.Save(profilePath);

                break;
        }
    }

    public static void updateMoney(int amount){
        Money -= amount;

        XmlNode profileNode = profileDataHandler.SelectSingleNode("/Profile");
        profileNode.Attributes["money"].Value = Money.ToString();

        profileDataHandler.Save(profilePath);
    }

    public static void updateVolume(float musicVol, float soundVol){
        XmlNode profileNode = profileDataHandler.SelectSingleNode("/Profile");
        profileNode.Attributes["music"].Value = musicVol.ToString();
        profileNode.Attributes["sound"].Value = soundVol.ToString();

        profileDataHandler.Save(profilePath);
        loadData();
    }

    public static void unlockPart(string id, int type)
    {
        //Go where we want to go
        XmlNode unlockedPartNodes = profileDataHandler.DocumentElement.SelectSingleNode("/Profile/UnlockedParts");
        XmlAttribute idAttr = profileDataHandler.CreateAttribute("id");
        idAttr.Value = id;

        switch (type)
        {
            case 0:
                XmlElement part1 = profileDataHandler.CreateElement("Capsule");
                part1.Attributes.Append(idAttr);

                unlockedPartNodes.InsertAfter(part1, unlockedPartNodes.LastChild);

                profileDataHandler.Save(profilePath);
                break;
            case 1:
                XmlElement part2 = profileDataHandler.CreateElement("Middle");

                part2.Attributes.Append(idAttr);

                unlockedPartNodes.InsertAfter(part2, unlockedPartNodes.LastChild);

                profileDataHandler.Save(profilePath);
                break;

            case 2:
                XmlElement part3 = profileDataHandler.CreateElement("Engine");

                part3.Attributes.Append(idAttr);

                unlockedPartNodes.InsertAfter(part3, unlockedPartNodes.LastChild);

                profileDataHandler.Save(profilePath);
                break;

            case 3:

                XmlElement part4 = profileDataHandler.CreateElement("Wings");


                part4.Attributes.Append(idAttr);

                unlockedPartNodes.InsertAfter(part4, unlockedPartNodes.LastChild);

                profileDataHandler.Save(profilePath);
                break;
        }

        loadData();
    }


    //Load set of parts for ship
    static Dictionary<string, Part> loadParts(string ID)
    {
        //Get specific node by ship id
        XmlNodeList RNodes = profileDataHandler.SelectNodes($"Profile/Rockets/{ID}/*");

        //Only for temporary use
        Dictionary<string, Part> temp = new Dictionary<string, Part>();

        //Load part by id
        foreach (XmlNode node in RNodes)
        {

            if (node.Name == "Capsule")
                temp.Add(node.Attributes["id"].Value, PartsManager.getCapsule(node.Attributes["id"].Value));

            if (node.Name == "Middle")
                temp.Add(node.Attributes["id"].Value, PartsManager.getMiddle(node.Attributes["id"].Value));

            if (node.Name == "Engine")
                temp.Add(node.Attributes["id"].Value, PartsManager.getEngine(node.Attributes["id"].Value));

            if (node.Name == "Wings")
                temp.Add(node.Attributes["id"].Value, PartsManager.getWing(node.Attributes["id"].Value));
        }
        return temp;
    }
}
