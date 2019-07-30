using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    // Start is called before the first frame update


    public Transform back1;
    public Transform back2;

    public bool select = true;

    public Transform cam;

    float currentHeight = 16.97114f;

    float moveby = 16.97114f;



    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHeight<cam.position.y){

            if(select){
                back1.localPosition = new Vector3(1.102f,back1.localPosition.y+ (moveby * 2f),0);
            }else{
                back2.localPosition = new Vector3(1.102f,back2.localPosition.y+ (moveby * 2f),0);
            }

            currentHeight += moveby;

            select=!select;

        }
        if(currentHeight>cam.position.y + 23.19314){
            if(select){
                back2.localPosition = new Vector3(1.102f,back2.localPosition.y- (moveby*2f),0);
            }else{
                back1.localPosition = new Vector3(1.102f,back1.localPosition.y- (moveby*2f),0);
            }

            currentHeight -= moveby;

            select=!select;

        }






    }
}
