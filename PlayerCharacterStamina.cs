
using UnityEngine;

public class PlayerCharaterStamina : MonoBehaviour
{
    [SerializeField]
    private CharacterMovement _CharacterMovement;
    [SerializeField]
    private float _maxstamina = 100;
    [SerializeField]
    private float _sprintStaminaCost = 20;
    [SerializeField]
    private float _staminaRegenValue = 20;

    private float _currentStamina;

    private void Awake()
    {
        _currentStamina = _maxstamina;
    }

    private void update()
    {
        CalculateStamina();
    }

    public void CalculateStamina()
    {
        if (_CharacterMovement.IsSprint)
        {
            if (_currentStamina > 0)
            {
                _currentStamina = _currentStamina - _sprintStaminaCost * Time.deltaTime;
            }
            else
            {
                _CharacterMovement.SetSprint(false);
            }
        }
        else
        {
            _currentStamina = _currentStamina + _staminaRegenValue * Time.deltaTime;
        }

        _currentStamina = Mathf.Clamp(_currentStamina, 0, _maxstamina);
    }

    private void Update()
    {
        CalculateStamina();
    }
}
