using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float cameraSpeed;
    private float currentScore;
    private float previousScore;

    void Update()
    {
        transform.position += new Vector3(cameraSpeed * Time.deltaTime, 0, 0);
    }

    public void UpdateScore(float score)
    {
        currentScore = score;

        if (Mathf.Floor(previousScore) != Mathf.Floor(currentScore)) 
        { 
            cameraSpeed += currentScore / 22;
            previousScore = currentScore;
        }
    }
}
