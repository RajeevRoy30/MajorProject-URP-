using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public Transform player;
    public float chaseRange = 10f;
    public float attackRange = 2f;
    public float attackCooldown = 1.5f;
    public int attackDamage = 10;

    private NavMeshAgent agent;
    private Animator animator;
    private float lastAttackTime;
    private bool isDead = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        if (player == null)
        {
            GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
            if (playerObj != null)
                player = playerObj.transform;
        }
    }

    void Update()
    {
        if (isDead || player == null) return;

        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= attackRange)
        {
            agent.isStopped = true;
            animator.SetBool("IsMoving", false);

            if (Time.time - lastAttackTime >= attackCooldown)
            {
                lastAttackTime = Time.time;
                animator.SetTrigger("Attack");
            }
        }
        else if (distance <= chaseRange)
        {
            agent.isStopped = false;
            agent.SetDestination(player.position);
            animator.SetBool("IsMoving", true);
        }
        else
        {
            agent.isStopped = true;
            animator.SetBool("IsMoving", false);
        }
    }

    // Call this from the attack animation using an animation event
    public void DealDamage()
    {
        float distance = Vector3.Distance(transform.position, player.position);
        if (distance <= attackRange + 0.5f) // extra buffer
        {
            PlayerHealth health = player.GetComponent<PlayerHealth>();
            if (health != null)
                health.TakeDamage(attackDamage);
        }
    }

    public void OnDeath()
    {
        isDead = true;
        agent.isStopped = true;
        this.enabled = false;
    }
}
