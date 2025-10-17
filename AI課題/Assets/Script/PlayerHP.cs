using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    public Image HPImage;
    public int maxHP          = 4; //最大HP
    private int currentHP;
    public float knockback    = 5f;//ノックバック
    public float invincible   = 2f;//無敵
    private bool isInvincible = false;

    Rigidbody2D rb;

    private void Start()
    {
        currentHP = maxHP;//ゲーム開始時にHPを初期化
        StartCoroutine(InvincibleTime());
        rb = GetComponent<Rigidbody2D>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //敵と衝突するとノックバック
        if (other.CompareTag("Enemy"))
        {
            rb.velocity = Vector2.zero;
            Vector2 direction = (transform.position - other.transform.position).normalized;
            rb.AddForce(direction * knockback, ForceMode2D.Impulse);
        }
        //敵と衝突するとダメージ
        if (other.CompareTag("Enemy") && !isInvincible)
        {
            Debug.Log("敵と衝突しました！");
            TakeDamege(1);
        }
        if (other.CompareTag("Trap"))
        {
            Debug.Log("罠と衝突しました");
            TakeDamege(maxHP);
        }
    }

    void TakeDamege(int damage)
    {
        currentHP -= damage;
        HPImage.fillAmount = (float)currentHP / maxHP;
        StartCoroutine(InvincibleTime());

        Debug.Log("残りHP：" + currentHP);

        if(currentHP <= 0)
        {
            Die();
        }
    }

    private IEnumerator InvincibleTime()
    {
        isInvincible = true;

        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        float blinkInterval = 0.3f;
        float elapsed = 0f;

        while (elapsed < invincible)
        {
            spriteRenderer.enabled = !spriteRenderer.enabled;
            yield return new WaitForSeconds(blinkInterval);
            elapsed += blinkInterval;
        }

        spriteRenderer.enabled = true;
        isInvincible = false;
        Debug.Log("無敵解除");

        //yield return new WaitForSeconds(invincible);

        //isInvincible = false;
        //Debug.Log("無敵解除");

    }



    void Die()
    {
        //死亡処理
        Debug.Log("プレイヤー死亡");

        gameObject.SetActive(false);
    }

}

