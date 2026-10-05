using TMPro;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nameText; 
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private string enemyName = "Enemy";
    [SerializeField] private int health = 100;
    [SerializeField] private int level = 1;

    public string Name
    {
        get
        {
            return enemyName;
        }
        set
        {
            enemyName = value;
            Refresh();
        }
    }

    public int Health
    {
        get
        {
            return health;
        }
        set
        {
            health = value;
            Refresh();
        }
    }

    public int Level
    {
        get
        {
            return level;
        }
        set
        {
            level = value;
            Refresh();
        }
    }

    private void Awake()
    {
        Refresh();
    }

    private void Refresh()
    {
        nameText.text = enemyName;
        healthText.text = $"HP: {health}";
        levelText.text = $"Lvl: {level}";
    }
}
