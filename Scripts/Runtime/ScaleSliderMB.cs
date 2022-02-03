using niscolas.UnityUtils.Core;
using Sirenix.OdinInspector;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using UnityEngine.Animations;

namespace niscolas.UnityUtils.UI
{
    [AddComponentMenu(Constants.AddComponentMenuPrefix + "Scale Slider")]
    public class ScaleSliderMB : CachedMB
    {
        [SerializeField]
        private Transform _fill;

        [SerializeField]
        private FloatReference _minScale = new FloatReference(0);

        [SerializeField]
        private FloatReference _maxScale = new FloatReference(1f);

        [EnumToggleButtons]
        [SerializeField]
        private Axis _affectedAxes;

        private Transform Fill
        {
            get
            {
                if (!_fill)
                {
                    _fill = transform;
                }

                return _fill;
            }
        }

        [Title("Debug")]
        [Button]
        public void SetFill(float ratio)
        {
            float fill = (_maxScale.Value - _minScale.Value) * ratio + _minScale.Value;

            Vector3 localScale = Fill.localScale;
            if (_affectedAxes.HasFlag(Axis.X))
            {
                localScale.x = fill;
            }

            if (_affectedAxes.HasFlag(Axis.Y))
            {
                localScale.y = fill;
            }

            if (_affectedAxes.HasFlag(Axis.Z))
            {
                localScale.z = fill;
            }

            Fill.localScale = localScale;
        }
    }
}