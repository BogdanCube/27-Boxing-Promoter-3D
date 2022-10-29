using Base.Level;
using Unity.VisualScripting;
using UnityEngine;

namespace Core.Environment.Zone.PushZone
{
    public class PushZoneEnemy : PushZone
    {
        public void Init(int level)
        {
            Spawn(level + 1, addCount: 1);
        }
        public void SpawnMax(int level)
        {
            Clear();
            Spawn(level + 1, true);
            PushTo();
        }
    }
}