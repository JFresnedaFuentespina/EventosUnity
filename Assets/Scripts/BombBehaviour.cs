using System.Collections.Generic;
using UnityEngine;

public class BombBehaviour : MonoBehaviour
{
    [SerializeField] private float detectionRadius = 2f;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            var enemies = FindEnemiesInRange();
            foreach (var enemy in enemies)
            {
                Destroy(enemy);
            }
        }
    }

    public List<GameObject> FindEnemiesInRange()
    {
        var enemies = new List<GameObject>();
        var ogres = FindObjectsByType<OgreBehaviour>(FindObjectsSortMode.None);
        var zombies = FindObjectsByType<ZombieBehaviour>(FindObjectsSortMode.None);
        foreach (var ogre in ogres)
        {
            enemies.Add(ogre.gameObject);
        }
        foreach (var zombie in zombies)
        {
            enemies.Add(zombie.gameObject);
        }
        var enemiesInRange = new List<GameObject>();
        foreach (var enemy in enemies)
        {
            if (Vector3.Distance(transform.position, enemy.transform.position) < detectionRadius)
            {
                enemiesInRange.Add(enemy.gameObject);
            }
        }

        return enemiesInRange;
    }
}