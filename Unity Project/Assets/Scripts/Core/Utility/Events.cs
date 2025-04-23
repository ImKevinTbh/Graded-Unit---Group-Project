using System;
using UnityEngine;

public class PickupEventArgs
{
    public PickupEventArgs(GameObject instance, Collider2D collider)
    {
        Instance = instance;
        Collider = collider;
    }
    public GameObject Instance { get; }
    public Collider2D Collider { get; }


}
public class Events
{
    public event EventHandler<PickupEventArgs> Pickup;
    public virtual void OnPickup(PickupEventArgs e)
    {
        Pickup?.Invoke(this, e);
    }
}