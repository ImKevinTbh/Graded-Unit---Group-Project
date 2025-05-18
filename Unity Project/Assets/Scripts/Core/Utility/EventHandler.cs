using Events;
using UnityEngine;

public class EventHandler // DO NOT FUCKING TOUCH THIS UNLESS YOU ARE KEVIN
{
    public static Pickup Pickup;
    public static Enemy Enemy;
    public static Player Player;
    public static Level Level = new Level();
    public static Denial Denial = new Denial();

    public static void Init()
    {
        Pickup = new Pickup();
        Enemy = new Enemy();
        Player = new Player();
    }
}