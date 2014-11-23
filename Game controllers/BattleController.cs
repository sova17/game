using System;
using System.Collections.Generic;
using UnityEngine;

class BattleController: MonoBehaviour
{
    public PlayerController[] playersInit; 
    private CircularList<PlayerController> players;
    private IEnumerator<PlayerController> enumerator;

    public BattleController(params PlayerController[] players)
    {
        playersInit = players;
        Awake();
    }

    public void Awake()
    {
        foreach (var player in playersInit)
            player.stepFinished += OnStepFinished;
        players = new CircularList<PlayerController>(playersInit);
        enumerator = players.GetEnumerator();
        enumerator.MoveNext();
    }

    private void OnStepFinished(PlayerController player)
    {
        enumerator.MoveNext();
    }

    public void Update()
    {
        enumerator.Current.Tick();
    }
}
