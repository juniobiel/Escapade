using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIManager : MonoBehaviour
{
    [Header("Mission Fields")]
    public Text missionText;
    public Image missionPanel;


    [Header("Game Manager")]
    public GameManager GMObject;

    [Header("Item Field")]
    public GameObject itemReport;

    private int objetivo, writeObjetivo, qtdPecas;
    private float count;
    // Start is called before the first frame update
    void Start()
    {
        missionText.text = "";
        itemReport.SetActive(false);        
        writeObjetivo = 0;
        objetivo = 1;
        count = 0;
        qtdPecas = 5;

    }

    // Update is called once per frame
    void Update()
    {
        count += Time.deltaTime;

    }

    private void FixedUpdate()
    {
        if (WriteMissionField())
        {
            WriteMission();
        }
            
    }


    void WriteMission()
    {
        if (!missionText.text.Equals(GMObject.GetMission(objetivo)) && count >= 0.1f)
        {
            missionText.text += GMObject.GetMission(objetivo)[writeObjetivo].ToString();
            writeObjetivo += 1;
            count -= count;
        }
        else if (missionText.text.Equals(GMObject.GetMission(objetivo)))
        {
            writeObjetivo = 0;
        }
    }

    bool WriteMissionField()
    {
        if (missionPanel.fillAmount < 1f)
        {
            missionPanel.fillAmount += 0.025f;
            return false;
        }
        else return true;
    }

    public void MudarObjetivo(int id)
    {
        this.objetivo = id;
        missionPanel.fillAmount = 0;
        missionText.text = "";

        WriteMissionField();
    }

    public void PegarItem(string item)
    {
        switch (item)
        {
            case "chave":
                itemReport.GetComponent<Text>().text = "Você encontrou uma chave";
                itemReport.SetActive(true);

                StartCoroutine("Piscar");

                
                break;

            case "bateria":
                itemReport.GetComponent<Text>().text = "Você encontrou uma bateria";
                itemReport.SetActive(true);

                StartCoroutine("Piscar");

                break;

            case "lanterna":
                itemReport.GetComponent<Text>().text = "Você pegou a lanterna";
                itemReport.SetActive(true);

                StartCoroutine("Piscar");

                break;

            case "peca":
                qtdPecas--;

                if(qtdPecas > 1)
                    itemReport.GetComponent<Text>().text = "Você pegou uma peca do gerador, restam " + qtdPecas.ToString();
                else
                    itemReport.GetComponent<Text>().text = "Você pegou todas as peças, ligue o gerador para fugir da escola";

                itemReport.SetActive(true);

                StartCoroutine("Piscar");

                break;
        }
        
    }


    public void Report(string acao)
    {
        itemReport.GetComponent<Text>().text = acao;
        
        itemReport.SetActive(true);

        StartCoroutine("Piscar");

    }
    IEnumerator Piscar()
    {
        yield return new WaitForSeconds(2);
        itemReport.SetActive(false);
    }
}
