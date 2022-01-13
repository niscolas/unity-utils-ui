using niscolas.UnityUtils.Core;
using TMPro;
using UnityAtoms;
using UnityEngine;

namespace niscolas.UnityUtils.UI
{
    public abstract class BaseBindTextMB<T, P, V, E1, E2, EI, ER, F, VI> : CachedMB,
        IAtomListener<T>
        where P : struct, IPair<T>
        where V : AtomVariable<T, P, E1, E2, F>
        where E1 : AtomEvent<T>
        where E2 : AtomEvent<P>
        where EI : AtomEventInstancer<T, E1>
        where ER : AtomEventReference<T, V, E1, VI, EI>, new()
        where F : AtomFunction<T, T>
        where VI : AtomVariableInstancer<V, P, T, E1, E2, F>
    {
        [SerializeField]
        private TMP_Text _text;

        [SerializeField]
        private ER _eventReference;

        [SerializeField]
        private bool _replayEventBuffer;

        private void OnEnable()
        {
            RegisterSelf();
        }

        private void OnDisable()
        {
            Unregister();
        }

        public void OnEventRaised(T item)
        {
            UpdateText(item);
        }

        public void UpdateText(T dynamicValue)
        {
            string text = FormatText(dynamicValue);
            SetText(text);
        }

        protected abstract string FormatText(T value);

        private void RegisterSelf()
        {
            if (_eventReference == null || _eventReference.Event == null)
            {
                return;
            }

            _eventReference.Event.RegisterListener(this, _replayEventBuffer);
        }

        private void SetText(string text)
        {
            if (!_text)
            {
                return;
            }

            _text.SetText(text);
        }

        private void Unregister()
        {
            if (_eventReference == null || _eventReference.Event == null)
            {
                return;
            }

            _eventReference.Event.UnregisterListener(this);
        }
    }
}