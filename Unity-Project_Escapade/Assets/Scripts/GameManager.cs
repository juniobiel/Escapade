using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    Dictionary<int, string> missoes;


    [Header("Objetos do jogo")]
    public GameObject portaSala1;

    private void Start()
    {
        

        //Set de missões
        missoes = new Dictionary<int, string>();
        missoes.Add(1, "Saia da sala de limpeza");
        missoes.Add(2, "Encontre as peças para ligar o gerador");
        missoes.Add(3, "Encontre a saída");

        Debug.Log(GetMission(1));
    }

    private void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(SceneManager.GetActiveScene().name == "Menu")
            {
                Application.Quit();
            }
            else
                SceneManager.LoadScene("Menu", LoadSceneMode.Single);
        }*/
            

    }

    void LoadEscolaScene()
    {
        SceneManager.LoadScene("Jogo", LoadSceneMode.Single);
    }

    public string GetMission(int id)
    {
        
        return missoes[id];
    }

    public void BtnAgain()
    {
        SceneManager.LoadScene("Jogo", LoadSceneMode.Single);
    }

    public void BtnMenu()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }

    public void BtnExit()
    {
        Application.Quit();
    }
}
