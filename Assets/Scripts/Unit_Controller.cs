using UnityEngine;


public class Unit_Controller : MonoBehaviour
{
    SpriteRenderer spriteRender;

    int hp = 10;
    void Start()
    {
        spriteRender = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DetectedorNot(int _order)
    {
        spriteRender.sortingOrder = _order;
    }

    public void TakeDamage(int _damage)
    {
        Debug.Log("Take Damage");
        hp = hp - _damage;
        Debug.Log($"HP: {hp}");
        if (hp <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
