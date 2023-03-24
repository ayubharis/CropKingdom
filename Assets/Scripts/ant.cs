using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ant : MonoBehaviour
{
    public float speed = 1f;
    private Vector3 target;
    private bool clicked = false;
    public SpriteRenderer spriteRenderer;
    public Sprite newSprite;
    public GameObject obj;


    void ChangeSprite()
    {
        spriteRenderer.sprite = newSprite;
        StartCoroutine(wait());

    }

    IEnumerator wait(){
      yield return new WaitForSeconds(1);
      obj.SetActive(false);
    }

    public void ButtonClicked() {
        clicked = true;
    }

    public void SpriteClick(){
       // if (transform.position != target) {
            Debug.Log("u got him");
       // }
    }

    private void Update(){
        if (clicked) {
            target =  new Vector3(0, 2, 0);
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target, step);
            if (transform.position == target){
                Debug.Log("Plant reached");
                clicked = false;
                ChangeSprite();
            }

        }
    }
}
