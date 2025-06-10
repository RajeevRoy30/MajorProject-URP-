using DG.Tweening;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    public float attackRadius = 1.5f;
    public int attackDamage = 20;
    public LayerMask targetLayers;
    public Transform attackPoint; // Set this to a position like hand/sword tip

    [SerializeField] private AudioClip attackClip;

    // This function will be triggered by an animation event
    public void PerformAttack()
    {

        Collider[] hitColliders = Physics.OverlapSphere(attackPoint.position, attackRadius, targetLayers);

        foreach (Collider collider in hitColliders)
        {
            if (collider.transform.TryGetComponent(out HealthSystem healthSystem))
            {
                if (attackClip!=null)
                {
                    AudioSource.PlayClipAtPoint(attackClip, transform.position);
                }
                healthSystem.TakeDamage(attackDamage);
            }
        }
        if(this.transform!=MovementInput.playerTransform && MovementInput.playerTransform.position!=null)
        {
            FaceThis(MovementInput.playerTransform.position);
        }
    }

    // Optional: Gizmos to see the attack area in editor
    void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRadius);
    }

    public void FaceThis(Vector3 target)
    {
        Quaternion lookAtRotation = Quaternion.LookRotation(target - transform.position);
        lookAtRotation.x = 0;
        lookAtRotation.z = 0;
        transform.DOLocalRotateQuaternion(lookAtRotation, .5f);
    }
}

