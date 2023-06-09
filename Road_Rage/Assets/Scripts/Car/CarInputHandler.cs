using UnityEngine;

[RequireComponent (typeof(CarController))]
public class CarInputHandler : MonoBehaviour
{
    public bool IsUIInput = false;

    private CarController _carController;

    private Vector2 _inputVector = Vector2.zero;

    private void Awake()
    {
        _carController = GetComponent<CarController>();
    }

    private void Update()
    {
        if (IsUIInput)
        {

        }
        else
        {
            _inputVector = Vector2.zero;

            _inputVector.x = Input.GetAxis("Horizontal");
            //inputVector.y = Input.GetAxis("Vertical");
        }

        _carController.SetInputVector(_inputVector);
    }

    public void SetInput(Vector2 newInput)
    {
        _inputVector = newInput;
    }
}
