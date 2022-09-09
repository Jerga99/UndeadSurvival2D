using System;
using UnityEngine;

[CreateAssetMenu(
    fileName = "CharacterHealth",
    menuName = "Values/Character's Health"
)]
public class HealthSO : ScriptableObject
{
    [SerializeField]
    private int _maxHealth;

    [SerializeField]
    private int _currentHealth;

    public int MaxHealth { get => _maxHealth; set { _maxHealth = value; } }
    public int CurrentHealth { get => _currentHealth; set { _currentHealth = value; } }

    public void InflictDamage(int damage)
    {
        if (_currentHealth > 0)
        {
            _currentHealth -= damage;
        }
        else
        {
            _currentHealth = 0;
        }
    }
}

