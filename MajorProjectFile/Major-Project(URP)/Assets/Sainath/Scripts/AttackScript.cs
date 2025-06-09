using UnityEngine;

public class AttackScript : MonoBehaviour
{
    public float attackRadius = 1.5f;
    public int attackDamage = 20;
    public LayerMask targetLayers;
    public Transform attackPoint; // Set this to a position like hand/sword tip

    // This function will be triggered by an animation event
    public void PerformAttack()
    {
        Collider[] hitColliders = Physics.OverlapSphere(attackPoint.position, attackRadius, targetLayers);

        foreach (Collider collider in hitColliders)
        {
            if (collider.transform.TryGetComponent(out HealthSystem healthSystem))
            {
                healthSystem.TakeDamage(attackDamage);
            }
        }
    }

    // Optional: Gizmos to see the attack area in editor
    void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRadius);
    }
}

