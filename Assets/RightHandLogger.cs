using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightHandLogger : MonoBehaviour
{
    // StreamWriter sw;
    // // Start is called before the first frame update
    // void Start()
    // {
    //     //Create a CSV file called "RightHandData.csv" in the Assets folder
    //     sw = new StreamWriter("Assets/RightHandData.csv");

    // }

    // // Update is called once per frame
    // void Update()
    // {
    //     // On each update write the position of the write wrist and relevant children to the CSV file


    //     GameObject rightHandWrist = GameObject.Find("b_r_wrist");
    //     // needed children b_r_index1 b_r_index2 b_r_index3 b_r_index_null
    //     // b_r_middle1 b_r_middle2 b_r_middle3 b_r_middle_null
    //     // b_r_pinky0 b_r_pinky1 b_r_pinky2 b_r_pinky3 b_r_pinky_null
    //     // b_r_ring0 b_r_ring1 b_r_ring2 b_r_ring3 b_r_ring_null
    //     // b_r_thumb0 b_r_thumb1 b_r_thumb2 b_r_thumb3 b_r_thumb_null
    //     // list of all children of right hand wrist

    //     List<GameObject> rightHandWristChildren = new List<GameObject>();
    //     List <string> neededChildrenNames = new List<string>();
    //     neededChildrenNames.Add("b_r_index1");
    //     neededChildrenNames.Add("b_r_middle1");
    //     neededChildrenNames.Add("b_r_pinky0");
    //     neededChildrenNames.Add("b_r_ring0");
    //     neededChildrenNames.Add("b_r_thumb0");
    //     // fill the list of all children of right hand wrist

        
    //     List<GameObject> rightHandWristChildren = new List<GameObject>();
        
    //     // fill the list of all children of right hand wrist
    //     foreach (Transform child in rightHandWrist.transform)
    //     {
    //         rightHandWristChildren.Add(child.gameObject);
    //     }
    //     // print names and positions of all children of right hand wrist
    //     foreach (GameObject child in rightHandWristChildren)
    //     {
    //         Debug.Log(child.name + " " + child.transform.position);
    //     }

    // }
}
