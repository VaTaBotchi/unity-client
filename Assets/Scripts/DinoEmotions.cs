using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Utility;

[Serializable]
public class DinoEmotion
{
    public string name;
    public string faceName;
    public int animationState;
}

public class DinoEmotions : Singleton<DinoEmotions>
{
    [SerializeField] private DinoEmotion[] emotions;
    [SerializeField] private DinoEmotion defaultEmotion;

    private Animator animator;
    private readonly List<DinoEmotion> allEmotions = new List<DinoEmotion>();
    private static readonly int StateId = Animator.StringToHash("animation");

    private void Start()
    {
        allEmotions.AddRange(emotions);
        allEmotions.Add(defaultEmotion);
        
        animator = GetComponent<Animator>();
        SetAnimatorState(defaultEmotion.animationState);
        ItemsManager.Instance.SetItem(defaultEmotion.faceName, true);
    }

    public void SetDinoEmotion(string emotionName, bool emotionEnabled)
    {
        var newEmotion = defaultEmotion;
        if (emotionEnabled)
        {
            foreach (var emotion in allEmotions.Where(emotion => emotion.name == emotionName))
            {
                newEmotion = emotion;
            }
        }
        
        SetAnimatorState(newEmotion.animationState);
        ItemsManager.Instance.SetItem(newEmotion.faceName, true);
    }

    private void SetAnimatorState(int state)
    {
        animator.SetInteger(StateId, state);
    }
}