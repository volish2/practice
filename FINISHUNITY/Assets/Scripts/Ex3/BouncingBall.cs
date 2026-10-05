using System.Collections;
using UnityEngine;

public class BouncingBall : MonoBehaviour
{
    [SerializeField] private float speedThreshold = 2f;
    [SerializeField] private Color slowColor;

    private Rigidbody rb;
    private Renderer render;
    private Color normalColor;
    private bool isSlow;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        render = GetComponent<Renderer>();
        normalColor = render.material.color;
    }

    private void Update()
    {
        if (!isSlow && Speed < speedThreshold)
            StartCoroutine(SlowPhase());
    }

    private float Speed => rb.linearVelocity.magnitude;

    private IEnumerator SlowPhase()
    {
        isSlow = true;
        render.material.color = slowColor;
        float timer = 0f;

        do 
        {
            yield return null;
            timer += Time.deltaTime;
        } while (Speed < speedThreshold);

        render.material.color = normalColor;
        Debug.Log($"Speed was below threshold for {timer:F3} seconds");
        isSlow = false;
    }
}
