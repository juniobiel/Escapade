using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Hide : MonoBehaviour
{

    public Camera mainCamera;
    public Camera hidingCamera;

    public Boolean isHiding = false;
    private Boolean guiShow = false;

    public float rayLength = 10;

    //Vector3 meu1 = GameObject.Find("FPSController").transform.position;
    //Vector3 meu2 = GameObject.Find("CameraHide").transform.position;


    // Start is called before the first frame update
    void Start()
    {
        mainCamera.enabled = true;
        hidingCamera.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        var fwd = transform.TransformDirection(Vector3.forward);

        /*(transform.position, fwd, hit, rayLength)*/

        if (Physics.Raycast(transform.position, fwd, out hit, rayLength))
        {

            if (hit.collider.gameObject.tag == "Hide" && isHiding == false)
            {
                guiShow = true;

                if (Input.GetKeyDown("e"))
                {

                    //Disabled Player
                    GameObject.Find("FPSController").GetComponent<FirstPersonController>().enabled = false;
                    //GameObject.Find("FirstPersonCharacter").GetComponent<MeshRenderer>().enabled = false;

                    //Change Camera
                    mainCamera.enabled = false;
                    hidingCamera.enabled = true;

                    StartCoroutine(Wait());
                }
            }
        }

        else
        {
            guiShow = false;
        }

        if (isHiding == true)
        {
            if (Input.GetKeyDown("e"))
            {
                //Disabled Player
                GameObject.Find("FPSController").GetComponent<FirstPersonController>().enabled = true;
                //GameObject.Find("FirstPersonCharacter").GetComponent<MeshRenderer>().enabled = true;

                //Change Camera
                mainCamera.enabled = true;
                hidingCamera.enabled = false;

                isHiding = false;
            }
        }

    }

    IEnumerator Wait()
    {
        /*const double V = 0.5;
        WaitForSeconds yield = V;*/

        yield return new WaitForSeconds(0.2f);

        isHiding = true;
        //guiShow = false;

    }

    /*private void OnGUI()
    {
        if (guiShow == true)
        {
            GUI.Box(Rect(Screen.width / 2, Screen.height / 2, 100, 25), "Hide Inside?");
        }
    }*/
}
