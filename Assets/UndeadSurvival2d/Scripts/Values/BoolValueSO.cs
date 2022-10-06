using System;
using UnityEngine;

[CreateAssetMenu(fileName = "BoolValueSO", menuName = "Values/Bool Value")]
public class BoolValueSO : ScriptableObject, ISerializationCallbackReceiver
{
    [SerializeField]
    private bool _initialValue;

    [NonSerialized]
    public bool RuntimeValue;

    public bool InitialValue => _initialValue;

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

