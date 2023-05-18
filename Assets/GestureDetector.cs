using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public struct Gesture {
    public string name;
    public List<Vector3> fingerDatas;
    public UnityEvent onRecognized;
}

public class GestureDetector : MonoBehaviour
{

    // public OVRSkeleton skeleton;
    // public List<Gesture> gestures;
    // private List<OVRBone> fingerBones;
    // // Start is called before the first frame update
    // void Start()
    // {
    //     fingerBones = new List<OVRBone>(skeleton.Bones); 
    //     Debug.Log(fingerBones.Count);
    //     Debug.Log(fingerBones);
    // }

    // // Update is called once per frame
    // void Update()
    // {
    //     Debug.Log(fingerBones.Count);
    //     Debug.Log(fingerBones);
    // }
}
