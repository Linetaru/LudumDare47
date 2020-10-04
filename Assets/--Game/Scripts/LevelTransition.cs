using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTransition : MonoBehaviour
{
    public string levelToLoad;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 9)
            SceneManager.LoadScene(levelToLoad);
    }
}
