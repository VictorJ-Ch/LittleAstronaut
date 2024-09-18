using System;
using UnityEngine;

[Serializable]
public class HeroClass : MonoBehaviour
{

    public string name;
    public int life, mana, speed;

    public HeroClass(string name, int life, int mana, int speed)
    {
        this.name =  name;
        this.life = life;
        this.mana = mana;
        this.speed = speed;
    }
}
