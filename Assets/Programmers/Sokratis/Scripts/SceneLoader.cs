using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private NavMeshSurface surface;

    private void Awake()
    {
        SceneManager.LoadSceneAsync("Sokratis Scene02", LoadSceneMode.Additive);
    }

    private void Start()
    {
        //surface.BuildNavMesh();
    }
}
