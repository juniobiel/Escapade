using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sala1 : MonoBehaviour
{
    public AudioSource trovao;

    public GameObject energia;
    public GameObject lampada;
    public GameObject chave;
    public GameObject porta;
    //public GameObject raioLuz;

    Transform chaveX;
    public bool temChave = false;
    public bool luz = false;
    public int cont;
    Vector3 chavePos = new Vector3(18, 0, 0);


    portaSala1 sala;

    // Start is called before the first frame update
    void Start()
    {

        trovao = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        chaveX = chave.GetComponent<Transform>();

        /*if(luz == true)
        {
            cont++;

            if(cont >= 5)
            {
                raioLuz.SetActive(false);
            }

            if (cont >= 9)
            {
                raioLuz.SetActive(true);
            }

            if (cont >= 19)
            {
                raioLuz.SetActive(false);
            }

        }*/

    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Entrou");


        if (Input.GetKeyDown(KeyCode.E))
        {
            lampada.SetActive(false);

            trovao.Play();

            porta.GetComponent<portaSala1>().enabled = true;

            energia.GetComponent<energiaCai>().enabled = true;

            chaveX.transform.position = chavePos;

            temChave = true;

            //raioLuz.SetActive(true);
            luz = true;
        }

    }

}
