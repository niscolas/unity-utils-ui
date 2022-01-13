using System;
using niscolas.UnityUtils.Core;
using TMPro;
using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace niscolas.UnityUtils.UI
{
    [AddComponentMenu(Constants.AddComponentMenuPrefix + "Simple Timer")]
    public class SimpleTimerMB : CachedMonoBehaviour
    {
        [SerializeField]
        private TMP_Text _timeLeftText;

        [SerializeField]
        private StringReference _timePattern;

        public void UpdateText(int timeLeft)
        {
            TimeSpan timeSpan = TimeSpan.FromSeconds(timeLeft);
            string timeLeftText = timeSpan.ToString(_timePattern?.Value);
            _timeLeftText.SetText(timeLeftText);
        }
    }
}