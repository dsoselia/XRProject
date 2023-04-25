using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandFollowCamera : MonoBehaviour
{
    public GameObject targetObject;
    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - targetObject.transform.position;
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = targetObject.transform.position + offset;
        
    }
}
