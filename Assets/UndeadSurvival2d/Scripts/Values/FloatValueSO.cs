using System;
using UnityEngine;

[CreateAssetMenu(fileName = "FloatValueSO", menuName = "Values/Float Value")]
public class FloatValueSO : ScriptableObject, ISerializationCallbackReceiver
{
    [SerializeField]
    private float _initialValue;

    [NonSerialized]
    public float RuntimeValue;

    public float InitialValue => _initialValue;

    public void ResetValue()
    {
        RuntimeValue = InitialValue;
    }

    public void OnBeforeSerialize() { }

    public void OnAfterDeserialize()
    {
        ResetValue();
    }
}

