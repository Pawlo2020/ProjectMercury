using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Xml;
using System;

public class DefeatScreenController : MonoBehaviour
{
    public Text collectedMoney, missionTime;
    int colMoney;

    public void init(int colMon, string misTime){
        collectedMoney.text = "Collected Money: " + colMon;
        missionTime.text = "Mission Time: " + misTime;
        colMoney = colMon;
    }
    
    public void continueButOnClick(){
        XmlNode moneyNode = ProfileManager.profileDataHandler.SelectSingleNode(@"/Profile");

        moneyNode.Attributes["money"].Value = (Convert.ToInt32(moneyNode.Attributes["money"].Value) + colMoney).ToString();

        ProfileManager.profileDataHandler.Save(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/Project Mercury/PlayerProfile.xml");

        ProfileManager.loadData();
        SceneManager.LoadScene("ShipConstructor");
        Time.timeScale = 1f;
    }
}
