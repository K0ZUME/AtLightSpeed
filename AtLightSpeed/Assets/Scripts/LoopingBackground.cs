using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopingBackground : MonoBehaviour
{
    public float backgroundSpeed;
    public Renderer backgroundRenderer;
    private float currentScore;
    private float previousScore;

    void Update()
    {
        backgroundRenderer.material.mainTextureOffset += new Vector2(backgroundSpeed * Time.deltaTime, 0f);
    }

    public void UpdateScore(float score)
    {
        currentScore = score;

        if (Mathf.Floor(previousScore) != Mathf.Floor(currentScore))
        {
            backgroundSpeed += currentScore / 520;
            previousScore = currentScore;
        }
    }
  
}
