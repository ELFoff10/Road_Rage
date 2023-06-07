using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PolygonCollider2D))]
public abstract class Powerup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        CarController car = collision.transform.root.GetComponent<CarController>();

        OnPickedUp(car);        

        Destroy(gameObject);
    }

    protected abstract void OnPickedUp(CarController car);
}
