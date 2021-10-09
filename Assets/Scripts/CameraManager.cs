using System;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;
using Utility;

[Serializable]
public class CameraState
{
    public string name;
    public Transform transform;
}

public class CameraManager : Singleton<CameraManager>
{
    [SerializeField] private CameraState[] states;
    [SerializeField] private CameraState defaultState;
    [SerializeField] private float duration = 1f;
    
    private readonly List<CameraState> allStates = new List<CameraState>();

    private void Start()
    {
        allStates.AddRange(states);
        allStates.Add(defaultState);
        SetCameraState(defaultState.name);
    }

    public void SetCameraState(string stateName)
    {
        foreach (var state in allStates.Where(state => state.name == stateName))
        {
            gameObject.transform.DOMove(state.transform.position, duration);
            gameObject.transform.DORotate(state.transform.rotation.eulerAngles, duration);
        }
    }
}
