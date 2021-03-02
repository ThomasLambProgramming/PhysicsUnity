using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Animator animator = null;
    public List<Rigidbody> Rigidbodies = new List<Rigidbody>();
    [SerializeField] Rigidbody ChestBody;
    public bool ragdollOn
    {
        get
        {
            return !animator.enabled;
        }
        set
        {
            animator.enabled = !value;
            foreach (Rigidbody r in Rigidbodies)
            {
                r.isKinematic = !value;
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        foreach (Rigidbody r in Rigidbodies)
        {
            r.isKinematic = true;
        }
    }

    public void ApplyExplosion(Vector3 direction)
    {
        ChestBody.AddForce(direction);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
