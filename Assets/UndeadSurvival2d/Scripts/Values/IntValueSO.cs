using System;
using UnityEngine;

[CreateAssetMenu(fileName = "IntValue", menuName = "Values/Int Value")]
public class IntValueSO : ScriptableObject, ISerializationCallbackReceiver
{
    [SerializeField]
    private int _initialValue;

    [NonSerialized]
    public int RuntimeValue;

    public int InitialValue => _initialValue;

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

