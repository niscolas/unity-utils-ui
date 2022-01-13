using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace niscolas.UnityUtils.UI
{
    [AddComponentMenu(Constants.AddComponentMenuPrefix + "Bind Int Text")]
    public class BindIntTextMB : BaseBindTextMB<
        int,
        IntPair,
        IntVariable,
        IntEvent,
        IntPairEvent,
        IntEventInstancer,
        IntEventReference,
        IntIntFunction,
        IntVariableInstancer>
    {
        protected override string FormatText(int value)
        {
            return value.ToString();
        }
    }
}