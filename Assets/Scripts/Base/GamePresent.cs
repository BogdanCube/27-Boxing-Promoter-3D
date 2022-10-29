using System;
using UnityEngine;

namespace Base
{
    public class GamePresent : MonoBehaviour
    {
        [SerializeField] private bool _isDeleteSave;
        private void OnValidate()
        {
            if (_isDeleteSave)
            {
                PlayerPrefs.DeleteAll();
            }
        }
    }
}