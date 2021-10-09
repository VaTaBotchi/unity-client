using System;
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
    private static readonly int StateId = Animator.StringToHash("animation");

    private void Start()
    {
        animator = GetComponent<Animator>();
        SetAnimatorState(defaultEmotion.animationState);
        ItemsManager.Instance.SetItem(defaultEmotion.faceName, true);
    }

    public void SetDinoEmotion(string emotionName, bool enabled)
    {
        var newEmotion = defaultEmotion;
        if (enabled)
        {
            foreach (var emotion in emotions)
            {
                if (emotion.name == emotionName) newEmotion = emotion;
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