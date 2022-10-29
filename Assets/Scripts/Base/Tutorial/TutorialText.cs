using TMPro;
using Toolkit.Extensions;
using UnityEngine;

namespace Base.Tutorial
{
    public class TutorialText : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;
        
        public void SetText(string text)
        {
            transform.Activate();
            _text.text = text;
        }
    }
}