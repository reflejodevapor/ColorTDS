using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CameraMovement : MonoBehaviour
{
    int enemyCount = 0;

    public AnimationCurve anim;

    Transform furthestEnemy;

    private void Update()
    {

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        var newEnemies = enemies.ToList();
        enemyCount = newEnemies.Count();
        newEnemies.OrderBy(t => Vector2.Distance(GameObject.FindGameObjectWithTag("Player").transform.position, t.transform.position));
        furthestEnemy = newEnemies[0].transform;
        //Camera.main.orthographicSize += 2.5f;

        var Player = GameObject.FindGameObjectWithTag("Player");

        if (!furthestEnemy.GetComponent<Renderer>().isVisible)
        {
            Camera.main.orthographicSize += 2.5f;
        }


    }
}
