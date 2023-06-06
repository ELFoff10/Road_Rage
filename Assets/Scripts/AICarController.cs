using UnityEngine;

public class AICarController : MonoBehaviour
{
    private enum AiCarBehaviour
    {
        Race, MoveForward, Points
    }

    [SerializeField] private AiCarBehaviour _CarAiBehaviour;

    private void Update()
    {
        if (_CarAiBehaviour == AiCarBehaviour.MoveForward)
        {
            transform.position -= new Vector3(0, 0.1f, 0);
        }
    }
}
