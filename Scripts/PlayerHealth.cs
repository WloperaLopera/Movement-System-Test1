using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public int fallDamageThreshold = 10;
    public int fallDamageMultiplier = 2;
    private Rigidbody _rigidbody;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        currentHealth = maxHealth;
    }

    void Update()
    {
        if (_rigidbody.velocity.y < 0)
        {
            int fallSpeed = (int)_rigidbody.velocity.y;
            if (fallSpeed < -fallDamageThreshold)
            {
                int damage = fallDamageMultiplier * ((-fallSpeed) / fallDamageThreshold);
                currentHealth = Mathf.Max(0, currentHealth - damage);
                // Handle player death if necessary
            }
        }
    }
}
