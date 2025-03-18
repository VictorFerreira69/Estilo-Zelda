using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyStatus : CharactesStatus
{
    [SerializeField] float damage;
    protected override void Teste()
    {
        throw new System.NotImplementedException();
    }
    // Start is called before the first frame update
    void Start()

    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out IDamageable player))
        {
            player.TakeDamage(damage);
        }
    }

}