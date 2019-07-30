﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    // Start is called before the first frame update


    public Transform back1;
    public Transform back2;

    public bool select = true;

    public Transform cam;

    float currentHeight = 26.4811f;



    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHeight<cam.position.y){

            if(select){
                back1.localPosition = new Vector3(1.102f,back1.localPosition.y+ 3.754676f+3.754676f,0);
            }else{
                back2.localPosition = new Vector3(1.102f,back2.localPosition.y+ 23.19314f+23.19314f,0);
            }

            currentHeight += 23.19314f;

            select=!select;

        }
        if(currentHeight>cam.position.y + 23.19314){
            if(select){
                back2.localPosition = new Vector3(1.102f,back2.localPosition.y- (23.19314f*2f),0);
            }else{
                back1.localPosition = new Vector3(1.102f,back1.localPosition.y- (23.19314f*2f),0);
            }

            currentHeight -= 23.19314f;

            select=!select;

        }






    }
}
