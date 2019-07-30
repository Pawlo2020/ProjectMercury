using UnityEngine;
using System;

//Module class - determinates behaviour for module 
public class Module : MonoBehaviour
{
    public AudioSource noFuelAlarm; 
    //Wings avaibility
    public bool hasWings;

    //Particle system handler
    public ParticleSystem partSystem;

    //Body module handler
    public Rigidbody2D moduleBody;

    //Amount of current fuel
    public float fuel = 100f;

    //Amount of starting fuel
    public float startingFuel;

    //Rotation ability value
    public float rotation = 1f;

    public float force;

    // Start is called before the first frame update
    void Start() {
        foreach(AudioSource audio in gameObject.GetComponents<AudioSource>()){
            audio.volume = ProfileManager.soundVol;
        }
     }

    //Add force for module
    public void addForce()
    {
        //Check if module has fuel
        if (fuel > 0)
        {
            //Fuel consumption
            fuel -= 0.5f;

            //Add force value and transform module
            moduleBody.AddForce(transform.up * force);
        }else{
            noFuelAlarm.mute = false;

        }
    }

    public void addDestructForce(){
        int dir;
        dir = (int)UnityEngine.Random.Range(0f,2f);


        System.Random ran = new System.Random();
        Vector3 position = new Vector3(UnityEngine.Random.Range(-10.0f, 10.0f), 0, UnityEngine.Random.Range(-10.0f, 10.0f));

        moduleBody.AddForce(position * 200f);

        Debug.Log(position);
    }

    // Update is called once per frame
    void Update() {}


     

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Money"))
        {
            GameObject.Find("Canvas").GetComponent<CurrentParameters>().collectedMoney += 10;
            GameObject.Destroy(other.gameObject);
            GameObject.Find("Capsule").GetComponent<Rocket>().playCollected();
            Debug.Log(ProfileManager.Money);
        }
    }
}
