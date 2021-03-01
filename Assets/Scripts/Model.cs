using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Model : MonoBehaviour
{
    private Animator animator = null;
    public List<Rigidbody> Rigidbodies = new List<Rigidbody>();

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

    // Update is called once per frame
    void Update()
    {
        
    }
}
