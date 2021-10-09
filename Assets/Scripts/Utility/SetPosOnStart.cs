using UnityEngine;

public class SetPosOnStart : MonoBehaviour
{
    [SerializeField] private Transform transform;

    private void Start()
    {
        gameObject.transform.position = transform.position;
        gameObject.transform.rotation = transform.rotation;
    }
}
