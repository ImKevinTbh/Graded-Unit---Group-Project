using System;
using UnityEngine;

public class PickupEventArgs
{
    public PickupEventArgs(Collider2D collider) { Collider = collider; }
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