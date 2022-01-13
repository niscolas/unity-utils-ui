using System.Globalization;
using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace niscolas.UnityUtils.UI
{
    [AddComponentMenu(Constants.AddComponentMenuPrefix + "Bind Float Text")]
    public class BindFloatTextMB : BaseBindTextMB<
        float,
        FloatPair,
        FloatVariable,
        FloatEvent,
        FloatPairEvent,
        FloatEventInstancer,
        FloatEventReference,
        FloatFloatFunction,
        FloatVariableInstancer>
    {
        protected override string FormatText(float value)
        {
            return value.ToString(CultureInfo.InvariantCulture);
        }
    }
}