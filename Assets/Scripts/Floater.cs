using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floater : MonoBehaviour
{
    public Rigidbody _rb;
    public float depthBeforeSubmerged = 1f;
    public float displacementAmount = 3f;
    public float yOffset = 0.5f;
    public float floatiness = 0.08f;
    public float waterLevel = 0.4f;
    private void FixedUpdate()
    {
        _rb.AddForceAtPosition(Physics.gravity, transform.position, ForceMode.Acceleration);

        if (transform.position.y < waterLevel)
        {
            float displacementMultiplier = Mathf.Clamp01((waterLevel - transform.position.y) / depthBeforeSubmerged) * displacementAmount;
            _rb.AddForceAtPosition(new Vector3(0f, Mathf.Abs(Physics.gravity.y) * displacementMultiplier, 0f), transform.position, ForceMode.Acceleration);
        }
    }
}
