using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuPrincipal : MonoBehaviour
{
    public Text startText;

    string texto1, texto2, texto3;

    float contador, contadorAnim;
    // Start is called before the first frame update
    void Start()
    {
        contador = 0;
        contadorAnim = 0;
        texto1 = startText.text;
        texto2 = "Pressione para iniciar..";
        texto3 = "Pressione para iniciar.";
    }

    // Update is called once per frame
    void Update()
    {
        contadorAnim += Time.deltaTime;
        contador += Time.deltaTime;
        if (contador >= 3f && Input.anyKeyDown)
        {
            SceneManager.LoadScene("Escola", LoadSceneMode.Single);
        }
        AnimarTexto();
    }

    void AnimarTexto()
    {
        if (contadorAnim >= 0.5f)
        {
            if(startText.text.Equals(texto3))
                startText.text = texto1;
            else if(startText.text.Equals(texto1))
                startText.text = texto2;
            else if(startText.text.Equals(texto2))
                startText.text = texto3;
            contadorAnim -= contadorAnim;
        }
    }
}
