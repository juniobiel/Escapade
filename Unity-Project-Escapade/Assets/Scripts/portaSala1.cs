using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portaSala1 : MonoBehaviour
{
    public bool chave = false;
    public bool abrir = false;
    // Start is called before the first frame update
    void Start()
    {
        chave = true;   
    }

    // Update is called once per frame
    void Update()
    {
        if(abrir == true)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, -120, 0), 2 * Time.deltaTime);
        }
    }

    private void OnTriggerStay(Collider other)
    {

        if(chave == true)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                abrir = true;
                Debug.Log("Abriu");
            }

        }
        
    }
}
