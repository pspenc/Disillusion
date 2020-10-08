using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class centralRotateOverTime : MonoBehaviour
{

    Transform trans;
    float totalAngle = 0;
    // Start is called before the first frame update
    void Start()
    {
        trans = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        totalAngle++;
        trans.Rotate(new Vector3(0, 1, 0), .005f);

    }
}
