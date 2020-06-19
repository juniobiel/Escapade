using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class energiaCai : MonoBehaviour
{

    public AudioSource energia;
    // Start is called before the first frame update
    void Start()
    {
        energia = GetComponent<AudioSource>();

        StartCoroutine(ExampleCoroutine());

        
    }

    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(1);
        energia.Play();
    }



        // Update is called once per frame
        void Update()
    {

    }
}
