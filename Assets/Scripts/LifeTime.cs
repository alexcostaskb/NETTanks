using UnityEngine;

public class LifeTime : MonoBehaviour
{
    [SerializeField] private float lifeTime = 1f;

    private void Start()
    {
        Invoke("DestroyAfterTime", lifeTime);
    }

    private void DestroyAfterTime()
    {
        Destroy(gameObject);
    }
}