using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    public AudioClip collectedClip;
    Rigidbody2D rigidbody2D;

    public ParticleSystem pickupSparkle;

    void OnTriggerEnter2D(Collider2D other)
    {
        RubyController controller = other.GetComponent<RubyController>();

        if (controller != null)
        {
            if (controller.health < controller.maxHealth)
            {
                controller.ChangeHealth(1);
                controller.PlaySound(collectedClip);
                if(!pickupSparkle.isPlaying)
                    pickupSparkle.Play();
                Destroy(gameObject, pickupSparkle.main.duration);
            }
        }
    }
}
