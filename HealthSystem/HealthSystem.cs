using System.Collections;
using System.Collections.Generic;
using unityEngine;


public class HealthSystem : MonoBehaviour
{
    public GameObject() heart;
    public int life;

    void Update()
    {
        if (life < 1)
        {
            Shatter(heart[0].gameObject);
        }
        else if (life < 2)
        {
            Shatter(heart[1].gameObject);
        }
        else if (life < 3)
        {
            Shatter(heart[3].gameObject);
        }
    }

    public void CriticalHit(int z)
    {
        life -= z

    }
}
