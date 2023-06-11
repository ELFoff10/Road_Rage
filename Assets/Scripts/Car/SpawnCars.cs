using SpaceShooter;
using UnityEngine;

public class SpawnCars : MonoBehaviour
{
    [SerializeField] private CameraController m_CameraController;

    private void Start()
    {
        GameObject[] spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");

        CarData[] carDatas = Resources.LoadAll<CarData>("CarData/");

        for (int i = 0; i < spawnPoints.Length; i++)
        {
            Transform spawnPoint = spawnPoints[i].transform;

            int playerSelectedCarID = PlayerPrefs.GetInt($"P{i + 1}SelectedCarID");

            foreach (CarData carData in carDatas)
            {
                if (carData.CarUniqueID == playerSelectedCarID)
                {
                    GameObject car = Instantiate(carData.CarPrefab, spawnPoint.position, spawnPoint.rotation);

                    int playerNumber = i + 1;

                    //car.GetComponent<CarInputHandler>()._playerNumber = i + 1;

                    if (PlayerPrefs.GetInt($"P{playerNumber}_IsAI") == 1) 
                    {
                        car.GetComponent<CarSFXHandler>().enabled = false;
                        car.name = "AI";
                        car.tag = "AI";
                    }
                    else
                    {
                        car.name = "Player";
                        car.tag = "Player";
                        m_CameraController.SetTarget(car.transform);
                    }

                    break;
                }
            }
        }
    }
}
