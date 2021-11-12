using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwerveSystem : MonoBehaviour
{
    private float lasFingerPosition;
    private float moveFactor;
    public float MoveFactorX => moveFactor;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            lasFingerPosition = Input.mousePosition.x;
        }
        else if (Input.GetMouseButton(0))
        {
            moveFactor = Input.mousePosition.x - lasFingerPosition;
            lasFingerPosition = Input.mousePosition.x;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            moveFactor = 0f;
        }
    }
}
