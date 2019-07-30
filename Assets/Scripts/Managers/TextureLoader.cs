using System.Collections.Generic;
using UnityEngine;

//TextureLoader class = getting all textures from resources
public static class TextureLoader
{
    //All textures of parts
    static Dictionary<string, Sprite> textures = new Dictionary<string, Sprite>();

    //Instantiates textures in dictioraries and loads from Resources
    public static void init()
    {
        //Capsules textures
        foreach (Sprite texture in Resources.LoadAll("Capsules", typeof(Sprite)))
        {
            textures.Add(texture.name, texture);
        }

        //Engines textures
        foreach (Sprite texture in Resources.LoadAll("Engines", typeof(Sprite)))
        {
            textures.Add(texture.name, texture);
        }

        //Middles textures
        foreach (Sprite texture in Resources.LoadAll("Middles", typeof(Sprite)))
        {
            textures.Add(texture.name, texture);
        }

        //Wings textures
        foreach (Sprite texture in Resources.LoadAll("Wings", typeof(Sprite)))
        {
            textures.Add(texture.name, texture);
        }
    }

    //Getting specific texture from dictionary (as a Sprite object)
    public static Sprite GetTexture(string id){
        return textures[id];
    }
}
