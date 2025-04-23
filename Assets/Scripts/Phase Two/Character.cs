using UnityEngine;

public abstract class Character : MonoBehaviour
{
    //Common element to all players
    protected Rigidbody2D rigidbody2d;
    protected Animator animator;
    protected SpriteRenderer spriteRenderer;

    protected struct Health
    {
        int maxHealth;
        int currentHealth;
        bool IsVulnerable;
        float cooldown;
    }

    protected abstract void Movement();
    protected abstract void PerformAction();
}
