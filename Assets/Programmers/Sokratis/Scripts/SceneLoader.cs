using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private string scene;

    private void Start()
    {
        SceneManager.LoadSceneAsync("Sokratis Scene02", LoadSceneMode.Additive);
    }
}
