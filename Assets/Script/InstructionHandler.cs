using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject InstructionCanvas = null;
    void Start()
    {
        if(PlayerPrefs.GetInt("NotFirstTime") == 0 || PlayerPrefs.GetInt("NotFirstTime") == null)
        {
            if(InstructionCanvas != null)
            {
                InstructionCanvas.SetActive(true);
            }
            PlayerPrefs.SetInt("NotFirstTime", 1);
            Invoke("closeInstructions", 3f);
        }
        else
        {
            if(InstructionCanvas != null)
            {
                InstructionCanvas.SetActive(false);
            }
        }
    }

    public void resetInstuctions()
    {
        PlayerPrefs.SetInt("NotFirstTime", 0);
        InstructionCanvas.SetActive(true);
    }

    void closeInstructions()
    {
        if(InstructionCanvas != null){
            InstructionCanvas.SetActive(false);
        }
    }
}
