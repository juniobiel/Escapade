using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portaSala1 : MonoBehaviour
{
    public bool chave = false;
    public bool abrir = false;

    private GameObject userInterface;
    // Start is called before the first frame update
    void Start()
    {
        chave = true;
        userInterface = GameObject.FindGameObjectWithTag("GUI");
        this.gameObject.tag = "PortaSala2";
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerStay(Collider other)
    {

        if(chave == true)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                abrir = true;
                userInterface.GetComponent<GUIManager>().MudarObjetivo(2);
                Debug.Log("Abriu");
            }

        }
        
    }
}
