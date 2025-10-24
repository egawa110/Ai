using UnityEngine;
using UnityEngine.UI;

public class Goal : MonoBehaviour
{
    public GameObject ClearUI;
    public GameObject Button;
    public GameObject Player;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("ÉSÅ[Éã");
            ClearUI.SetActive(true);
            Button.SetActive(true);
            Player.SetActive(false);

        }
    }
}
