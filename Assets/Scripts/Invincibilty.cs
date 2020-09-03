using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invincibilty : MonoBehaviour
{
    public float invincibilityDuration;

    public float lastHitTime;

    public bool CanTakeDamage()
    {
        return Time.time > lastHitTime + invincibilityDuration;
    }
}
