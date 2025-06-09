using UnityEngine;

public class PlayerHealth : HealthSystem
{
    public override void Die()
    {
        transform.GetComponent<Animator>().CrossFadeInFixedTime("Death",.1f);
    }
}