using niscolas.UnityUtils.Core;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

namespace niscolas.UnityUtils.UI
{
    [AddComponentMenu(Constants.AddComponentMenuPrefix + "Advanced Button")]
    public class AdvancedButtonMB : CachedMB,
        IPointerClickHandler,
        IPointerDownHandler,
        IPointerUpHandler,
        IAdvancedButton
    {
        [SerializeField]
        private FloatReference _maxTapTime = new(0.5f);

        [SerializeField]
        private FloatReference _maxDoubleTapInterval = new(0.5f);

        [SerializeField]
        private FloatReference _minHoldTime = new(0.6f);

        [Header("Events")]
        [SerializeField]
        private UnityEvent _onPointerDown;

        [SerializeField]
        private UnityEvent _clickEvent;

        [SerializeField]
        private UnityEvent _onPointerUp;

        [SerializeField]
        private UnityEvent _doubleClickEvent;

        [FormerlySerializedAs("_holdEvent")]
        [SerializeField]
        private UnityEvent _holdStartEvent;

        [SerializeField]
        private UnityEvent _holdEndedEvent;

        private AdvancedButtonController _controller;

        protected override void Awake()
        {
            base.Awake();

            _controller = new AdvancedButtonController(
                this,
                _minHoldTime.Value,
                _maxTapTime.Value,
                _maxDoubleTapInterval.Value);

            _controller.OnDoubleTap += NotifyDoubleClick;
            _controller.OnHoldStarted += NotifyHoldStarted;
            _controller.OnHoldEnded += NotifyHoldEnded;
        }

        public float Time => UnityEngine.Time.time;

        public void OnPointerClick(PointerEventData eventData)
        {
            _clickEvent?.Invoke();
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            _controller.OnPointerDown();
            _onPointerDown?.Invoke();
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            _controller.OnPointerUp();
            _onPointerUp?.Invoke();
        }

        private void NotifyDoubleClick()
        {
            _doubleClickEvent?.Invoke();
        }

        private void NotifyHoldStarted()
        {
            _holdStartEvent?.Invoke();
        }

        private void NotifyHoldEnded()
        {
            _holdEndedEvent?.Invoke();
        }
    }
}