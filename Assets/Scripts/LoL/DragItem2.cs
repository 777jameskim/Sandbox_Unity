using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragItem2 : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler

{
    [SerializeField] Transform item;

    Vector2 startPos;
    Transform target;
    bool isDrag = false;

    // Start is called before the first frame update
    void Start()
    {
        
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

    public void OnDrag(PointerEventData eventData)
    {
        isDrag = true;
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        pos.z = 0;
        transform.Translate(pos);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        isDrag = false;
        startPos = transform.position;
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0;
        transform.position = pos;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (target != null)
        {
            transform.position = target.position;
        }
        else
        isDrag = false;
    }
}
