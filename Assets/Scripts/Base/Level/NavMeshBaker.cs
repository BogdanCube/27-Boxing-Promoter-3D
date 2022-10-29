using System;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

namespace Base.Level
{
    public class NavMeshBaker : MonoBehaviour
    {
        [SerializeField] private NavMeshSurface _navMeshSurface;

        private void Start()
        {
            UpdateBake();
        }

        [Button]
        public void UpdateBake()
        {
            _navMeshSurface.BuildNavMesh();
        }

        public void ReloadScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}