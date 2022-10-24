using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ReminingCoins : MonoBehaviour
{
    public GameSession gameSession;
    [SerializeField] int rCoinNumber = 22;
    [SerializeField] TextMeshProUGUI remindText;


    void Start()
    {
        remindText.text = rCoinNumber.ToString();
    }

    void Update()
    {
        remindText.text = (rCoinNumber - gameSession.score).ToString();
    }
}
