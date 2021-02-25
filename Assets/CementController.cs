using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CementController : MonoBehaviour
{
    public float heightOffset = 1.65f;
    //degress per second
    public float speed;
    public Transform target;
    //distance or offset from the camera to the player or "target"
    public float distance = 4;
    // Start is called before the first frame update
    float currentDistance = 0;
    void Start()
    {
        currentDistance = distance;
    }
    Vector3 GetTargetPosition()
    {
        return target.position + heightOffset * Vector3.up;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            Vector3 angles = transform.eulerAngles;
            float dx = Input.GetAxis("Mouse Y");
            float dy = Input.GetAxis("Mouse X");
            angles.x = Mathf.Clamp(angles.x + dx * speed * Time.deltaTime, 0, 70);

            angles.y += dy * speed * Time.deltaTime;
            transform.eulerAngles = angles;
        }
        RaycastHit hit;
        if (Physics.Raycast(GetTargetPosition(), -transform.forward, out hit, distance))
        {
            currentDistance = hit.distance;
        }
        else
        {
            currentDistance = Mathf.MoveTowards(currentDistance, distance, Time.deltaTime);
        }


        transform.position = GetTargetPosition() - currentDistance * transform.forward;
    }
}
