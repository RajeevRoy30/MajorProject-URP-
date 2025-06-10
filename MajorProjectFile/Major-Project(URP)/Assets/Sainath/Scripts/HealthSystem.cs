using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    private Animator animator;

    public UnityEvent OnDeathEvent;
    [SerializeField] private Image healthImage;

    void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
    }

    // Call this via Animation Event
    public void TakeDamage(int damage)
    {
        if (currentHealth <= 0) return;

        PlayerHitAnimation();

        currentHealth -= damage;

        if (healthImage != null)
        {
            healthImage.fillAmount =(float)currentHealth / maxHealth;
        }

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            OnDeathEvent?.Invoke();
            Die();
        }
    }

    private void PlayerHitAnimation()
    {
        animator.CrossFade("Damage",.1f);
    }

    public virtual void Die()
    {
        if (animator != null)
        {
            animator.enabled = false;  // Disables further animations
        }

        if (transform.TryGetComponent<NavMeshAgent>(out NavMeshAgent agent))
        {
            agent.enabled = false;
        }

        if(transform.TryGetComponent<EnemyAI>(out EnemyAI enemy))
        {
            enemy.enabled = false;
        }

        // Optional: disable other components (AI, movement, etc.)
        // Destroy(this); // If you want to remove this script
    }
}