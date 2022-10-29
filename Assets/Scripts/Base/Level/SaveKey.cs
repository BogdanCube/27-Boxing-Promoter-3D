using UnityEngine;

namespace Base.Level
{
    public class SaveKey : MonoBehaviour
    {
        [SerializeField] private int _levelId;
        public int Id => _levelId;
    }
}