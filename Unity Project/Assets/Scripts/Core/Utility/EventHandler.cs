using Events;
using UnityEngine;

// All code by Kevin
public class EventHandler // DO NOT FUCKING TOUCH THIS UNLESS YOU ARE KEVIN
{
    public static Pickup Pickup;
    public static Enemy Enemy;
    public static Player Player;
    public static Game Game = new Game();
    public static Level Level = new Level();
    public static Denial Denial = new Denial();
    public static Anger Anger = new Anger();

    public static void Init()
    {
        Pickup = new Pickup();
        Enemy = new Enemy();
        Player = new Player();
    }
}