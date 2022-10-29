using Base.Level;
using Core.Environment.UpgraderPlayer;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Serialization;

namespace Core.Components.Base
{
    public abstract class SaveLoadComponent : MonoBehaviour
    {
        [FormerlySerializedAs("_currentLevel")] [SerializeField] private SaveKey _saveLevel;
        [ShowNativeProperty] public string Key => _saveLevel ? $"{name} {GetType()} {_saveLevel.Id}" : "No Save Key";
        protected int Level => _saveLevel ? _saveLevel.Id : -1;
        protected bool HasKey => PlayerPrefs.HasKey(Key);

        protected void Save(int value)
        {
            if (_saveLevel == null) return;
            PlayerPrefs.SetInt(Key,value);
        }

        protected int Load()
        {
            if (_saveLevel == null) return 0;
            return PlayerPrefs.HasKey(Key) ? PlayerPrefs.GetInt(Key) : 0;
        }
    }
}