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

    private int objetivo, writeObjetivo;
    private float count;
    // Start is called before the first frame update
    void Start()
    {
        missionText.text = "";
        writeObjetivo = 0;
        objetivo = 1;
        count = 0;
        
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
            WriteMission(objetivo);
        }
    }

    void WriteMission(int idMission)
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
}
