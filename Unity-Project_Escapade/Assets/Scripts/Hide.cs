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

    public GameObject lixeira1;
    public GameObject lixeira2;
    public GameObject lixeira3;
    public GameObject lixeira4;


    public Boolean isHiding = false;
    private Boolean guiShow = false;

    public float rayLength = 10;

    void Start()
    {
        mainCamera.enabled = true;
        hidingCamera.enabled = false;
    }

    void Update()
    {
        RaycastHit hit;
        var fwd = transform.TransformDirection(Vector3.forward);

        if (Physics.Raycast(transform.position, fwd, out hit, rayLength))
        {

            if (hit.collider.gameObject.tag == "Hide" && isHiding == false)
            {
                //guiShow = true;

                if (Input.GetKeyDown("e"))
                {

                    //Disabled Player
                    GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().enabled = false;
                    GameObject.FindGameObjectWithTag("Player").GetComponent<MeshRenderer>().enabled = false;

                    StartCoroutine(Wait());

                    //Change Camera
                    mainCamera.enabled = false;
                    hidingCamera.enabled = true;

                    
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
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().enabled = true;
                GameObject.FindGameObjectWithTag("Player").GetComponent<MeshRenderer>().enabled = true;

                //Change Camera
                mainCamera.enabled = true;
                hidingCamera.enabled = false;

                isHiding = false;
            }
        }

    }

    IEnumerator Wait()
    {

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
