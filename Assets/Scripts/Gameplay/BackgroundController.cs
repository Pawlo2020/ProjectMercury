using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    // Start is called before the first frame update


    public Transform back1;
    public Transform back2;
    public Transform back3;
    public Transform back4;
    public Transform surface;
    public Transform surface2;

    public Transform skyBackground;

    public bool selectY = true;

    public bool selectX = true;

    public Transform cam;

    float currentHeight = 69.41196f;
    float currentWidth = 58.98381f;

    float movebyY = 69.41196f;

    float movebyX = 58.98381f;

    Color skyColor;

    float H, S, V;

    void Start()
    {
        capsule = GameObject.Find("Capsule");

        skyColor = skyBackground.gameObject.GetComponent<SpriteRenderer>().color;

        Color.RGBToHSV(skyColor, out H, out S, out V);
        //H: 0,572671
        Debug.Log("V: " + V);

    }

    GameObject capsule;

    // Update is called once per frame
    void Update()
    {

        // if(((int)capsule.GetComponent<Transform>().position.y)%100==0 && capsule.GetComponent<Rigidbody2D>().velocity.y>0){
        //     V -= 0.01f;

        // }else if(((int)capsule.GetComponent<Transform>().position.y)%100==0 && capsule.GetComponent<Rigidbody2D>().velocity.y<0){
        //     V += 0.01f;
        // }



        if (capsule.GetComponent<Transform>().position.y > 0 && capsule.GetComponent<Transform>().position.y < 1000f)
        {
            V = 0.97f;

        }
        else if (capsule.GetComponent<Transform>().position.y > 1000 && capsule.GetComponent<Transform>().position.y < 2000f)
        {
            V = 0.76f;
        }
        else if (capsule.GetComponent<Transform>().position.y > 2000 && capsule.GetComponent<Transform>().position.y < 3000f)
        {
            V = 0.76f;
        }
        else if (capsule.GetComponent<Transform>().position.y > 3000 && capsule.GetComponent<Transform>().position.y < 4000f)
        {
            V = 0.67f;
        }
        else if (capsule.GetComponent<Transform>().position.y > 4000 && capsule.GetComponent<Transform>().position.y < 5000f)
        {
            V = 0.55f;

        }
        else if (capsule.GetComponent<Transform>().position.y > 6000 && capsule.GetComponent<Transform>().position.y < 7000f)
        {
            V = 0.42f;
        }
        else if (capsule.GetComponent<Transform>().position.y > 8000 && capsule.GetComponent<Transform>().position.y < 9000f)
        {
            V = 0.32f;
        }
        else if (capsule.GetComponent<Transform>().position.y > 10000 && capsule.GetComponent<Transform>().position.y < 11000f)
        {
            V = 0.22f;
        }



            skyColor = Color.HSVToRGB(H, S, V);

            Color.RGBToHSV(skyColor, out H, out S, out V);

            skyBackground.gameObject.GetComponent<SpriteRenderer>().color = skyColor;

            Debug.Log("V: " + V);

            if(back1.position.y > 8000){
                back1.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            }else{
                back1.gameObject.GetComponent<SpriteRenderer>().enabled = true;
            }

            if(back2.position.y > 8000){
                back2.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            }else{
                back2.gameObject.GetComponent<SpriteRenderer>().enabled = true;
            }

            if(back3.position.y > 8000){
                back3.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            }else{
                back3.gameObject.GetComponent<SpriteRenderer>().enabled = true;
            }

            if(back4.position.y > 8000){
                back4.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            }else{
                back4.gameObject.GetComponent<SpriteRenderer>().enabled = true;
            }

            // if(back1.position.y > 8000){
            //     back1.gameObject.GetComponent<SpriteRenderer>().sprite = space;
            // }else{
            //     back1.gameObject.GetComponent<SpriteRenderer>().sprite = sky;
            // }

            // if(back2.position.y > 8000){
            //     back2.gameObject.GetComponent<SpriteRenderer>().sprite = space;
            // }else{
            //     back2.gameObject.GetComponent<SpriteRenderer>().sprite = sky;
            // }

            // if(back3.position.y > 8000){
            //     back3.gameObject.GetComponent<SpriteRenderer>().sprite = space;
            // }else{
            //     back3.gameObject.GetComponent<SpriteRenderer>().sprite = sky;
            // }

            // if(back4.position.y > 8000){
            //     back4.gameObject.GetComponent<SpriteRenderer>().sprite = space;
            // }else{
            //     back4.gameObject.GetComponent<SpriteRenderer>().sprite = sky;
            // }

            //Move by Y

            //UP
            if (currentHeight < cam.position.y)
            {

                if (selectY)
                {
                    back1.localPosition = new Vector3(back1.localPosition.x, back1.localPosition.y + (movebyY * 2f), 0);
                }
                else
                {
                    back2.localPosition = new Vector3(back1.localPosition.x, back2.localPosition.y + (movebyY * 2f), 0);
                }

                currentHeight += movebyY;

                selectY = !selectY;

            }

            //Down
            if (currentHeight > cam.position.y + movebyY)
            {
                if (selectY)
                {
                    back2.localPosition = new Vector3(back1.localPosition.x, back2.localPosition.y - (movebyY * 2f), 0);


                }
                else
                {
                    back1.localPosition = new Vector3(back1.localPosition.x, back1.localPosition.y - (movebyY * 2f), 0);
                }

                currentHeight -= movebyY;

                selectY = !selectY;

            }


            //Move by X

            //Right
            if (currentWidth < cam.position.x)
            {
                if (selectX)
                {
                    back1.localPosition = new Vector3(back1.localPosition.x + (movebyX * 2f), back1.localPosition.y, 0);
                    surface.localPosition = new Vector3(back1.localPosition.x, surface.localPosition.y, surface.localPosition.z);
                    surface2.localPosition = new Vector3(back3.localPosition.x, surface2.localPosition.y,  surface2.localPosition.z);
                }
                else
                {
                    back3.localPosition = new Vector3(back3.localPosition.x + (movebyX * 2f), back3.localPosition.y, 0);
                    surface.localPosition = new Vector3(back3.localPosition.x, surface.localPosition.y, surface.localPosition.z);
                    surface2.localPosition = new Vector3(back1.localPosition.x, surface2.localPosition.y, surface2.localPosition.z);
                }

                currentWidth += movebyX;

                selectX = !selectX;


            }


            //Left
            if (currentWidth > cam.position.x + movebyX)
            {
                if (selectX)
                {
                    back3.localPosition = new Vector3(back3.localPosition.x - (movebyX * 2f), back3.localPosition.y, 0);
                    surface.localPosition = new Vector3(back3.localPosition.x, surface.localPosition.y, surface.localPosition.z);
                    surface2.localPosition = new Vector3(back1.localPosition.x, surface2.localPosition.y, surface2.localPosition.z);

                }
                else
                {
                    back1.localPosition = new Vector3(back1.localPosition.x - (movebyX * 2f), back1.localPosition.y, 0);
                    surface.localPosition = new Vector3(back1.localPosition.x, surface.localPosition.y, surface.localPosition.z);
                    surface2.localPosition = new Vector3(back3.localPosition.x, surface2.localPosition.y, surface2.localPosition.z);
                }

                currentWidth -= movebyX;

                selectX = !selectX;


            }


            //Realtime background support mode extension pro exclusive
            back3.localPosition = new Vector3(back3.localPosition.x, currentHeight - movebyY, 0);
            back2.localPosition = new Vector3(back1.localPosition.x, back2.localPosition.y, 0);

            back4.localPosition = new Vector3(back3.localPosition.x, currentHeight, 0);








        }
    }
