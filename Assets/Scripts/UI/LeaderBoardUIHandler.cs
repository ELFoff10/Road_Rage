using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderBoardUIHandler : MonoBehaviour
{
    [SerializeField] private GameObject _leaderBoardItemPrefab;

    private SetLeaderBoardItemInfo[] _setLeaderBoardItemInfo;

    private void Awake()
    {
        VerticalLayoutGroup leaderBoardLayoutGroup = GetComponentInChildren<VerticalLayoutGroup>();

        CarLapCounter[] carLapCounterArray = FindObjectsOfType<CarLapCounter>();

        _setLeaderBoardItemInfo = new SetLeaderBoardItemInfo[carLapCounterArray.Length];

        for (int i = 0; i < carLapCounterArray.Length; i++)
        {
            GameObject leaderBoardInfoGameObject = Instantiate(_leaderBoardItemPrefab, leaderBoardLayoutGroup.transform);

            _setLeaderBoardItemInfo[i] = leaderBoardInfoGameObject.GetComponent<SetLeaderBoardItemInfo>();

            _setLeaderBoardItemInfo[i].SetPositionText($"{i + 1}.");
        }
    }

    public void UpdateList(List<CarLapCounter> lapCounters)
    {
        for (int i = 0; i < lapCounters.Count; i++)
        {
            _setLeaderBoardItemInfo[i].SetDriverNameText(lapCounters[i].gameObject.name);
        }
    }
}


