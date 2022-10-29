using System;
using System.Collections.Generic;
using Core.Characters.Player;
using Core.Characters.Player.Wallet;
using Core.Components.Detachment;
using Core.Components.Wallet;
using NTC.Global.Cache;
using Toolkit.Extensions;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

namespace Base.Level
{
    public class AdminMode : NightCache, INightRun
    {
        [SerializeField] private WalletPlayer _wallet;
        [SerializeField] private Detachment _detachment;
        [SerializeField] private Button _buttonMoney;
        [SerializeField] private Button _buttonDetachment;
        [SerializeField] private TMP_InputField _inputLevel;
        [SerializeField] private Transform _panel;
        [SerializeField] private LoaderLevel _loaderLevel;
        [SerializeField] private int _spawnLevel = 1;
        #region Enable / Disable
        private void OnEnable()
        {
            _buttonMoney.onClick.AddListener(AddMoney);
            _buttonDetachment.onClick.AddListener(AddFighter);
        }

        private void OnDisable()
        {
            _buttonMoney.onClick.RemoveListener(AddMoney);
            _buttonDetachment.onClick.RemoveListener(AddFighter);
        }
        #endregion
        

        private void Start()
        {
            _loaderLevel.AllOpen();
            _panel.Activate();
            _inputLevel.text = _spawnLevel.ToString();
        }

        private void AddMoney()
        {
            _wallet.Add(5000);
        } 
        private void AddFighter()
        {
            var level = Convert.ToInt32(_inputLevel.text);
            _detachment.Spawn(level);
        }
        public void Run()
        {
            if (Input.GetKey(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
}