using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] private float loadDelay = 1f;
    [SerializeField] ParticleSystem finishEffect;
    bool finished = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (!finished)
            {
                finished = true;
                finishEffect.Play();
                GetComponent<AudioSource>().Play();
                Invoke(nameof(NextScene), loadDelay);
            }
        }
    }

    private void NextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int sceneCount = SceneManager.sceneCountInBuildSettings;
        if (currentSceneIndex  < sceneCount - 1)
        {
            int nextScene = currentSceneIndex+ 1;
            SceneManager.LoadScene(nextScene);
        }
        
    }
}
