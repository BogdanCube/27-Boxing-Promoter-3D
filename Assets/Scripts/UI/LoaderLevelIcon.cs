using System;
using Base.Level;
using Core.Characters.Fighter.Level.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class LoaderLevelIcon : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private Image _background;
        [SerializeField] private TextMeshProUGUI _text;
        [SerializeField] private SaveKey _level;
        [SerializeField] private DataLevel _data;
        private void Start()
        {
            var id = _level.Id - 1 > 0 ? _level.Id - 1 : 0;
            var color = _data.Templates[id].Color;
            _image.color = color;
            _background.color = color;
            _text.text = id.ToString();
        }
    }
}