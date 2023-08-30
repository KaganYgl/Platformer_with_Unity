using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image healthBar;
    [SerializeField] private Health playerHealth;

    void Update()
    {
        healthBar.fillAmount = playerHealth.GetHealth() / 10;
        if (playerHealth.IsDead()){
            GetComponent<PlayerMovement>().enabled = false;
        }
    }
}
