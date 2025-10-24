using UnityEngine;
using TMPro;
using System.Collections;



public class SkillCooldown : MonoBehaviour
{
    public TextMeshProUGUI countdownText;
    public float time = 5f;

    public GamePauseController GP;

    void Update()
    {
        if(GP.isPaused)
        {
            StartCoroutine(StartCountdown());
        }
    }

    IEnumerator StartCountdown()
    {

    }
}


