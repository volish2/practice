using TMPro;
using UnityEngine;

public class EnemyChanger : MonoBehaviour
{
    [SerializeField] private TMP_InputField input;
    private Enemy[] enemies;

    private void Start()
    {
        enemies = FindObjectsByType<Enemy>();
    }

    public void FilterByHealth()
    {
        if (!int.TryParse(input.text, out int n)) return;
        foreach (Enemy e in enemies)
            e.gameObject.SetActive(e.Health > n);
    }

    public void FilterByLevel()
    {
        if (!int.TryParse(input.text, out int lvl)) return;
        foreach (Enemy e in enemies)
            e.gameObject.SetActive(e.Level == lvl);
    }

    public void ResetAll()
    {
        foreach (Enemy e in enemies)
            e.gameObject.SetActive(true);
    }

    public void MakeBoss()
    {
        foreach (Enemy e in enemies)
        {
            if (e.Name.Trim().ToLower() != input.text.Trim().ToLower()) 
                continue;

            e.Name = "Boss";
            e.Level += 1;
            e.Health *= 3;
        }
    }
}
