using UnityEngine;

public class BubbleSorter : MonoBehaviour
{
    [SerializeField] private Transform[] cubes;
    [SerializeField] private Vector3 startPoint = Vector3.zero;
    [SerializeField] private float gap = 0.5f;

    private void Start()
    {
        BubbleSort();
        PlaceInLine();
    }

    private void BubbleSort()
    {
        for (int i = 0; i < cubes.Length - 1; i++)
        {
            bool swapped = false;
            for (int j = 0; j < cubes.Length - 1 - i; j++)
            {
                if (cubes[j].localScale.x < cubes[j + 1].localScale.x)
                {
                    (cubes[j], cubes[j + 1]) = (cubes[j + 1], cubes[j]);
                    swapped = true;
                }
            }
            if (!swapped) break;
        }
    }

    private void PlaceInLine()
    {
        float x = startPoint.x;
        foreach (Transform cube in cubes)
        {
            float size = cube.localScale.x;
            x += size / 2f;
            cube.position = new Vector3(x, startPoint.y + size / 2f, startPoint.z);
            x += size / 2f + gap;
        }
    }
}
