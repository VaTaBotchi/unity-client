using UnityEngine;
using DG.Tweening;

public class SetPosOnStart : MonoBehaviour
{
    [SerializeField] private Transform transform;
    [SerializeField] private float duration = 0f;

    private void Start()
    {
        gameObject.transform.DOMove(transform.position, duration);
        gameObject.transform.DORotate(transform.rotation.eulerAngles, duration);
    }
}
