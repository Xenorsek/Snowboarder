using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAvalanche : MonoBehaviour
{

    [SerializeField] GameObject Snowballs;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            var snowballsBodies = Snowballs.GetComponentsInChildren<Rigidbody2D>();
            foreach (var snowball in snowballsBodies)
            {
                snowball.WakeUp();
            }
        }
    }
}
