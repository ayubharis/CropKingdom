using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 1f;
    public float deathDuration = 1f;
    public Sprite deadSprite;
    public Sprite attackSprite;
    public float spriteChangeDuration = 0.5f;
    public Vector2 target = Vector2.zero;


    public delegate void EnemyEvent(Enemy enemy);
    public event EnemyEvent OnClick;
    public event EnemyEvent OnDeath;

    private bool isDead = false;

    void Update()
    {
        if (!isDead)
        {
            // Move the enemy towards the center of the screen
            float moveSpeed = 5f;
            Vector2 direction = (target - (Vector2)transform.position).normalized;
            GetComponent<Rigidbody2D>().velocity = direction * moveSpeed;

            BoxCollider2D collider = GetComponent<BoxCollider2D>();
            if (collider.bounds.Contains(target))
            {
                explode();
            }

        }
        else
        {
            // Stop the enemy's movement
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }

    void OnMouseDown()
    {
        if (!isDead && OnClick != null)
        {
            OnClick(this);
        }
    }

    public void Kill()
    {
        if (!isDead)
        {
            isDead = true;

            if (OnDeath != null)
            {
                OnDeath(this);
            }
        }
    }

    public void ChangeSprite()
    {
        if (deadSprite != null)
        {
            // Change the sprite to the dead sprite
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                spriteRenderer.sprite = deadSprite;
            }
        }

        // Hide the sprite after a short delay
        Invoke("DestroyGameObject", spriteChangeDuration);
    }

    public void explode()
    {

        if (attackSprite != null)
        {
            // Change the sprite to the dead sprite
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

            if (spriteRenderer.sprite != attackSprite) {
                Player.cash -= 10;
            }

            if (spriteRenderer != null)
            {
                spriteRenderer.sprite = attackSprite;
            }

        }



        // Hide the sprite after a short delay
        Invoke("DestroyGameObject", spriteChangeDuration);
    }

    void DestroyGameObject()
    {
        Destroy(gameObject);
    }
}
