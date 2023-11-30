using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public enum ItemGradeType
{
    Normal,
    Magic,
    Rare,
    Epic,
    Legend,
    God,
    Size
}

public enum ItemType
{
    Weapon,
    Armor,
    Boots,
    Gloves,
    ETC,
    Size
}

public class ItemData
{
    public int enchantLevel = 0;
    public int level = 0;
    public ItemGradeType grade = ItemGradeType.Normal;
    public ItemType type;
}

public class ItemController : MonoBehaviour
{
    [SerializeField] private Item item;
    [SerializeField] private Transform parent;
    [SerializeField] private StateView sv;

    public Sprite[] weaponSprites;
    public Sprite[] armorSprites;
    public Sprite[] bootsSprites;
    public Sprite[] glovesSprites;
    public Sprite[] etcSprites;

    public Dictionary<ItemType, List<Sprite>> dicSprites = new Dictionary<ItemType, List<Sprite>>();

    public Sprite[] frame;

    List<Item> items = new List<Item>();
    int invenCnt = 20;
    int invenMaxCnt = 0;

    int createIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        dicSprites.Add(ItemType.Weapon, weaponSprites.ToList());
        dicSprites.Add(ItemType.Armor, armorSprites.ToList());
        dicSprites.Add(ItemType.Boots, bootsSprites.ToList());
        dicSprites.Add(ItemType.Gloves, glovesSprites.ToList());
        dicSprites.Add(ItemType.ETC, etcSprites.ToList());

        AddInventory(invenCnt);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            if (createIndex == invenMaxCnt)
                return;

            ItemData d = new ItemData();
            d.type = (ItemType)Random.Range((int)ItemType.Weapon, (int)ItemType.Size);
            d.enchantLevel = (d.type != ItemType.ETC) ? Random.Range(0, 10) : 0;
            d.level = (d.type != ItemType.ETC) ? Random.Range(1, 10) * 10 : 0;
            d.grade = (d.type != ItemType.ETC) ? (ItemGradeType)Random.Range((int)ItemGradeType.Normal, (int)ItemGradeType.Size) : ItemGradeType.Normal;

            if(d.type != ItemType.ETC)
            {
                items[createIndex].SetData(d, this);
                items[createIndex].SetStateView(sv);
            }
            else
            {
                d.grade = ItemGradeType.Normal;
                int spriteIndex = Random.Range(0, etcSprites.Length);
                bool itemFound = false;
                foreach (var item in items)
                {
                    if(item.icon.sprite == etcSprites[spriteIndex])
                    {
                        itemFound = true;
                        item.Count++;
                        break;
                    }
                }
                if (itemFound)
                    createIndex--;
                else
                {
                    items[createIndex].SetData(d, this, spriteIndex);
                    items[createIndex].SetStateView(sv);
                }
            }

            createIndex++;
        }

        if (Input.GetKeyDown(KeyCode.F2))
        {
            AddInventory(invenCnt);
        }
    }

    void AddInventory(int count)
    {
        for (int i = 0; i < count; i++)
        {
            Item it = Instantiate(item, parent);
            it.Empty();
            items.Add(it);

            invenMaxCnt++;
        }
    }
}
