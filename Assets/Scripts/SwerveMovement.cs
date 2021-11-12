using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwerveMovement : MonoBehaviour
{
    private SwerveSystem swerveSystem;
    [SerializeField] private float swerveSpeed = 0.5f;
    [SerializeField] private float maxSwerveMovement = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        swerveSystem = GetComponent<SwerveSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        float swerveAmount = swerveSystem.MoveFactorX * swerveSpeed * Time.deltaTime;
        swerveAmount = Mathf.Clamp(swerveAmount, -maxSwerveMovement, maxSwerveMovement);
        transform.Translate(swerveAmount, 0, 0);
    }
}
