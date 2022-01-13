using niscolas.UnityUtils.Core;
using TMPro;
using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace niscolas.UnityUtils.UI
{
    [AddComponentMenu(Constants.AddComponentMenuPrefix + "Rich Text Updater")]
    public class SimpleTextInsertMB : CachedMB
    {
        [SerializeField]
        private TMP_Text _text;

        [SerializeField]
        private StringReference _prefix;

        [SerializeField]
        private StringReference _suffix;

        protected override void Awake()
        {
            base.Awake();
            if (!_text)
            {
                _text = GetComponentInChildren<TMP_Text>();
            }
        }

        public void UpdateText(string newText)
        {
            string text = _prefix + newText + _suffix;
            _text.SetText(text);
        }
    }
}