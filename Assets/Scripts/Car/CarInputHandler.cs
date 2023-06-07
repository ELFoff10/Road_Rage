using UnityEngine;

[RequireComponent (typeof(CarController))]
public class CarInputHandler : MonoBehaviour
{
    private CarController _carController;

    private void Awake()
    {
        _carController = GetComponent<CarController>();
    }

    private void Update()
    {
        Vector2 inputVector = Vector2.zero;

        inputVector.x = Input.GetAxis("Horizontal");
        //inputVector.y = Input.GetAxis("Vertical");

        _carController.SetInputVector(inputVector);
    }
}
