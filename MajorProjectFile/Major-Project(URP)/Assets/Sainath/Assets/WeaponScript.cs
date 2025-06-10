using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    public bool activated;
    public float rotationSpeed;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private AudioClip audioClip;

    void Update()
    {
        if (activated)
        {
            transform.localEulerAngles += Vector3.forward * rotationSpeed * Time.deltaTime;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (((1 << collision.gameObject.layer) & layerMask) != 0)
        {
            print(collision.gameObject.name);
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.Sleep();
            rb.collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
            rb.isKinematic = true;
            activated = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<EnemyHealth>(out EnemyHealth component))
        {
            component.TakeDamage(20);
            if(audioClip != null)
            {
                AudioSource.PlayClipAtPoint(audioClip,transform.position);
            }
        }

        if (other.CompareTag("Breakable"))
        {
            BreakBoxScript breakScript = other.GetComponent<BreakBoxScript>();
            if (breakScript != null)
            {
                breakScript.Break();
            }
        }
    }
}