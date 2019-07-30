using UnityEngine;
using UnityEngine.UI;

//CurrentParameters class - operate GUI rocket attributes
public class CurrentParameters : MonoBehaviour
{
    //Rocket attributes
    public Text altitudeValue, velocityValue, missionValue, collectedMoneyValue;

    public int collectedMoney = 0;
    public string missionValueStr;

    //Rocket body handler
    Rigidbody2D _rocketBody;
    // Start is called before the first frame update
    void Start()
    {
        _rocketBody = GameObject.Find("Capsule").GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Update velocity
        velocityValue.text = System.Math.Round(_rocketBody.velocity.y,3).ToString();

        //Update altitude
        altitudeValue.text = System.Math.Round(_rocketBody.position.y + 30).ToString();

         if(!GameObject.Find("Capsule").GetComponent<Rocket>().destroyed){
        //Update mission time
        missionValue.text = "Mission Time: " + ((int)System.Math.Round(Time.timeSinceLevelLoad) / 60) + ":" + ((int)System.Math.Round(Time.timeSinceLevelLoad)) % 60;
        missionValueStr = ((int)System.Math.Round(Time.timeSinceLevelLoad) / 60) + ":" + ((int)System.Math.Round(Time.timeSinceLevelLoad)) % 60;
        }

        collectedMoneyValue.text = "Money: " + collectedMoney;
    }
}
