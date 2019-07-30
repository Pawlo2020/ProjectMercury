using System.Collections.Generic;
using System.Xml;
using System;
using UnityEngine;

//PartsManager class - getting all parts from main parts database
public static class PartsManager
{

    //All parts from databases divided into groups
    public static Dictionary<string, Part> Capsules = new Dictionary<string, Part>();
    public static Dictionary<string, Part> Middles = new Dictionary<string, Part>();
    public static Dictionary<string, Part> Engines = new Dictionary<string, Part>();
    public static Dictionary<string, Part> Wings = new Dictionary<string, Part>();

    //Parts database handler
    static XmlDocument databaseHandler;

    //Instantiates parts in dictioraries and loads attributes from xml files
    public static void init()
    {
        databaseHandler = new XmlDocument();

        TextAsset xmlData = (TextAsset)Resources.Load("PartsDB", typeof(TextAsset));

        //Load Parts database xml file
        databaseHandler.LoadXml(xmlData.text);

        //Selecting nodes from specific part's group
        XmlNodeList capsulenodes = databaseHandler.SelectNodes(@"/Database/CapsuleParts/*");
        XmlNodeList middlenodes = databaseHandler.SelectNodes(@"/Database/MiddleParts/*");
        XmlNodeList enginenodes = databaseHandler.SelectNodes(@"/Database/EngineParts/*");
        XmlNodeList wingnodes = databaseHandler.SelectNodes(@"/Database/Wings/*");


        //Capsule node
        foreach (XmlNode capnode in capsulenodes)
        {
            //Setting attributes for part object
            Part part = new Part();
            part.Id = capnode.Attributes["model"].Value;
            part.Fuel = float.Parse((capnode.Attributes["fuel"].Value));
            part.Price = Convert.ToInt32(capnode.Attributes["price"].Value);
            part.Force = float.Parse(capnode.Attributes["force"].Value);

            //Add to dictionary Capsules
            Capsules.Add(capnode.Attributes["model"].Value, part);
        }

        //Middle node
        foreach (XmlNode middlenode in middlenodes)
        {
            //Setting attributes for part object
            Part part = new Part();
            part.Id = middlenode.Attributes["model"].Value;
            part.Fuel = float.Parse((middlenode.Attributes["fuel"].Value));
            part.Price = Convert.ToInt32(middlenode.Attributes["price"].Value);
            part.Force = float.Parse(middlenode.Attributes["force"].Value);

            //Add to dictionary Middles
            Middles.Add(middlenode.Attributes["model"].Value, part);
        }


        //Engines node
        foreach (XmlNode engnode in enginenodes)
        {
            //Setting attributes for part object
            Part part = new Part();
            part.Id = engnode.Attributes["model"].Value;
            part.Fuel = float.Parse(engnode.Attributes["fuel"].Value);
            part.Price = Convert.ToInt32(engnode.Attributes["price"].Value);
            part.Force = float.Parse(engnode.Attributes["force"].Value);

            //Add to dictionary Engines
            Engines.Add(engnode.Attributes["model"].Value, part);
        }


        //Wings node
        foreach (XmlNode wingnode in wingnodes)
        {
            //Setting attributes for part object
            Part part = new Part();
            part.Id = wingnode.Attributes["model"].Value;
            part.Rotation = float.Parse(wingnode.Attributes["rotation"].Value);
            part.Price = Convert.ToInt32(wingnode.Attributes["price"].Value);

            //Add to dictionary Wings
            Wings.Add(wingnode.Attributes["model"].Value, part);
        }
    }

    //Getting specific capsule from Capsules dictionary (as a Part object)
    public static Part getCapsule(string id)
    {
        return Capsules[id];
    }

    //Getting specific middle from Middles dictionary (as a Part object)
    public static Part getMiddle(string id)
    {
        return Middles[id];
    }

    //Getting specific engine from Engines dictionary (as a Part object)
    public static Part getEngine(string id)
    {
        return Engines[id];
    }

    //Getting specific wings from Wings dictionary (as a Part object)
    public static Part getWing(string id)
    {
        return Wings[id];
    }
}
