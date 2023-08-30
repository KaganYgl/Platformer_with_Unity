using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    private float currentHealth;
    private Animator animator;
    private bool isDead;

    private void Awake()
    {
        currentHealth = startingHealth;
        animator = GetComponent<Animator>();
        isDead = false;
    }

    private void Update()
    {
        if (isDead)
        {
            GameManager.Instance.UpdateGameState(GameState.GameOver);
        }
    }

    public float GetHealth()
    {
        return currentHealth;
    }

    public bool IsDead()
    {
        return isDead;
    }

    public void OnDamage(float damage)
    {
        currentHealth -= damage;

        if (currentHealth > 0)
        {
            animator.SetTrigger("Hurt");

        }
        else
        {
            animator.SetTrigger("Die");
            isDead = true;
        }
    }
}
