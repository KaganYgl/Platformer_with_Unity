using UnityEngine;

public class ArrowTrap : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] arrows;
    private float previousAttackTime;
    private float nextAttackTime;

    private void Awake()
    {
        nextAttackTime = Time.time;
    }

    void Update()
    {
        
        if(Time.time >= nextAttackTime)
        {
            Attack();
            previousAttackTime = Time.time;
            nextAttackTime = previousAttackTime + attackCooldown;
        }
    }

    private int FindArrow()
    {
        for(int i = 0; i < arrows.Length; i++)
        {
            if (!arrows[i].activeInHierarchy)
            {
                return i;
            }
        }
        return 0;
    }

    private void Attack()
    {
        arrows[FindArrow()].transform.position = firePoint.position;
        arrows[FindArrow()].GetComponent<Projectile>().ActivateProjectile();
    }
}
