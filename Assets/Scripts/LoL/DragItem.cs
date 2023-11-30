using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragItem : MonoBehaviour
{
    [SerializeField] Transform item;
    [SerializeField] Transform dragitem;

    Vector2 startPos;
    Transform target;
    bool isDrag = false;

    // Start is called before the first frame update
    void Start()
    {
        dragitem.GetComponent<SpriteRenderer>().enabled = false;
        dragitem.position = item.position;
        dragitem.GetComponent<SpriteRenderer>().sprite = item.GetComponent<UnityEngine.UI.Image>().sprite;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDrag)
        {
            RaycastHit2D[] hit = Physics2D.RaycastAll(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector3.forward);
            target = null;
            foreach (var item in hit)
            {
                if (item.collider.gameObject.name.Equals("ItemBG"))
                {
                    target = item.collider.transform;
                    break;
                }
            }
        }
    }

    public void OnPointDown()
    {
        isDrag = false;
        startPos = transform.position;
        dragitem.GetComponent<SpriteRenderer>().enabled = true;
        item.GetComponent<UnityEngine.UI.Image>().enabled = false;
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0;
        dragitem.position = pos;
    }

    public void OnPointUp()
    {
        if (target != null)
        {
            target.GetChild(0).GetComponent<SpriteRenderer>().sprite = dragitem.GetComponent<SpriteRenderer>().sprite;
            target.GetChild(0).GetComponent<SpriteRenderer>().enabled = true;
        }
        else
            item.GetComponent<UnityEngine.UI.Image>().enabled = true;
        dragitem.GetComponent<SpriteRenderer>().enabled = false;
        //item.position = startPos;
        //dragitem.position = startPos;
        isDrag = false;
    }

    public void OnDrag()
    {
        isDrag = true;
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - dragitem.position;
        pos.z = 0;
        dragitem.Translate(pos);
    }
}
