using UnityEngine;

public class SpawnCars : MonoBehaviour
{
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
                        car.GetComponent<CarInputHandler>().enabled = false;
                        car.tag = "AI";
                    }
                    else
                    {
                        car.gameObject.name = "Player";
                        car.tag = "Player";
                    }

                    break;
                }
            }
        }
    }
}
