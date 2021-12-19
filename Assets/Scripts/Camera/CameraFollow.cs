using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //we need the camera follow the player
    public Transform target;
    public float smoothing = 5f;
    //we need know the distance between the player and camera
    Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - target.position;

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position = target.position + offset;
        Vector3.Lerp (pos , transform.position, smoothing * Time.deltaTime);
    }
}
