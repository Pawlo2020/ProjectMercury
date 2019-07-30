using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

public class Rocket : MonoBehaviour
{
    //Rocket body handler
    public Rigidbody2D rocketBody;

    //Fuel meter
    public Image fuelMeter;

    public bool destroyed = false;

    public GameController GC;

    public Transform skyBackground;
    List<GameObject> modules = new List<GameObject>();


    // Start is called before the first frame update
    void Start()
    {
        GameObject[] moduleList = GameObject.FindGameObjectsWithTag("Module");

        foreach (GameObject module in moduleList)
        {
            modules.Add(module);
        }

        if (!Application.isEditor)
        {
            modules = Swap(modules, 0, 2);
            modules = Swap(modules, 1, 0);
        }

        foreach(AudioSource audio in gameObject.GetComponents<AudioSource>()){
            audio.volume = ProfileManager.soundVol;
        }
    }

    public List<GameObject> Swap(List<GameObject> list, int indexA, int indexB)
    {
        GameObject tmp = list[indexA];
        list[indexA] = list[indexB];
        list[indexB] = tmp;
        return list;
    }

    public void Destruct()
    {
        if (!destroyed)
        {
            for (int i = 0; i < modules.Count; i++)
            {
                if (modules.Count > 1)
                {
                    modules[modules.Count - 2].GetComponent<Joint2D>().enabled = false;
                    var em = modules[modules.Count - 1].GetComponent<Module>().partSystem.emission;
                    em.enabled = false;

                    modules[modules.Count - 1].GetComponent<AudioSource>().mute = true;
                    modules[modules.Count - 1].GetComponent<Module>().addDestructForce();

                    modules[modules.Count - 1].GetComponent<Rigidbody2D>().velocity = new Vector2(rocketBody.velocity.x, rocketBody.velocity.y);
                    modules[modules.Count - 1].transform.parent = null;

                    modules.RemoveAt(modules.Count - 1);
                }
            }

            var emission = GetComponent<Module>().partSystem.emission;
            emission.enabled = false;

            GetComponent<Module>().addDestructForce();

            destroyed = true;

            gameObject.GetComponents<AudioSource>()[1].mute = true;
            gameObject.GetComponent<AudioSource>().mute = true;
            gameObject.GetComponents<AudioSource>()[4].Play();

            GC.showDefeat();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (rocketBody.velocity.y < -20f && rocketBody.transform.position.y <= 3)
            Destruct();

        fuelMeter.fillAmount = modules[modules.Count - 1].GetComponent<Module>().fuel / modules[modules.Count - 1].GetComponent<Module>().startingFuel;
        if (!GC.isPaused)
        {
            if (!destroyed)
            {
                //Go UP
                if (Input.GetKey(KeyCode.W))
                {
                    if (!speedLimit)
                    {
                        modules[modules.Count - 1].GetComponent<Module>().addForce();
                    }
                        var em = modules[modules.Count - 1].GetComponent<Module>().partSystem.emission;


                        if (modules[modules.Count - 1].GetComponent<Module>().fuel > 0)
                        {
                            em.enabled = true;
                            gameObject.GetComponents<AudioSource>()[1].mute = false;
                        }
                        else
                        {
                            em.enabled = false;
                            gameObject.GetComponents<AudioSource>()[1].mute = true;
                        }
                    }
                

                if (Input.GetKeyUp(KeyCode.W))
                {
                    var em = modules[modules.Count - 1].GetComponent<Module>().partSystem.emission;

                    em.enabled = false;

                    gameObject.GetComponents<AudioSource>()[1].mute = true;
                }

                //Rotate Left
                if (Input.GetKey(KeyCode.A))
                {
                    if (modules[modules.Count - 1].GetComponent<Module>().hasWings == true)
                    {
                        transform.Rotate(0f, 0f, modules[modules.Count - 1].GetComponent<Module>().rotation, Space.Self);

                    }
                    else
                    {
                        transform.Rotate(0f, 0f, 0.2f, Space.Self);
                    }
                }

                //Rotate Right
                if (Input.GetKey(KeyCode.D))
                {
                    if (modules[modules.Count - 1].GetComponent<Module>().hasWings == true)
                    {
                        transform.Rotate(0f, 0f, -modules[modules.Count - 1].GetComponent<Module>().rotation, Space.Self);
                    }
                    else
                    {
                        transform.Rotate(0f, 0f, -0.2f, Space.Self);
                    }
                }

                if (Input.GetKeyDown(KeyCode.F))
                {
                    if (modules.Count > 1)
                    {
                         gameObject.GetComponents<AudioSource>()[2].Play();
                        modules[modules.Count - 2].GetComponent<Joint2D>().enabled = false;
                        var em = modules[modules.Count - 1].GetComponent<Module>().partSystem.emission;
                        em.enabled = false;

                        modules[modules.Count - 1].GetComponent<AudioSource>().mute = true;

                        modules[modules.Count - 1].GetComponent<Rigidbody2D>().velocity = new Vector2(rocketBody.velocity.x, rocketBody.velocity.y);
                        modules[modules.Count - 1].transform.parent = null;

                        modules.RemoveAt(modules.Count - 1);


                    }
                }

                if (rocketBody.velocity.y > 100)
                {
                    // rocketBody.velocity = new Vector2(rocketBody.velocity.x, 100f);
                    // rocketBody.velocity = Vector2.zero;
                    speedLimit = true;
                }
                else
                {
                    speedLimit = false;
                }




            }

            skyBackground.position = new Vector3(rocketBody.transform.position.x, rocketBody.transform.position.y + 3, skyBackground.position.z);


        }

    }

    public void playCollected(){
        gameObject.GetComponents<AudioSource>()[3].Play();
    }

    bool speedLimit = false;
}
