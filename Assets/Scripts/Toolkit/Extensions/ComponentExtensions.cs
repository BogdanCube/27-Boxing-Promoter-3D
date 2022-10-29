using UnityEngine;

namespace Toolkit.Extensions
{
    public static class ComponentExtensions
    {
        public static bool IsActive(this Component component)
        {
            return component.gameObject.activeSelf;
        }
        
        public static void Activate(this Component component)
        {
            if (IsActive(component)) return;
            component.gameObject.SetActive(true);
        }
        public static void Deactivate(this Component component)
        {
            if (IsActive(component) == false) return;
            component.gameObject.SetActive(false);
        }
    }
}