using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeScript : MonoBehaviour
{
    [SerializeField]
    private Tile[] woodTiles;
    [SerializeField]
    private SpriteRenderer spriteChild, spriteHalo;
    [SerializeField]
    private WoodCollect woodCollect;
    public static TreeScript[] All;
    // Start is called before the first frame update
    void Start()
    {
        if (All == null)
        {
            GameObject[] objs =  GameObject.FindGameObjectsWithTag("Tree");
            All = new TreeScript[objs.Length];
            for (int i = 0; i < objs.Length; i++)
            {
                All[i] = objs[i].GetComponent<TreeScript>();
            }
        }

        woodCollect = GameObject.Find("UI").GetComponent<WoodCollect>();
    }

    // Update is called once per frame
    void Update()
    {
        spriteHalo.enabled = false;
    }

    public void ShowHalo()
    {
        spriteHalo.enabled = spriteChild.enabled;
    }

    public void Timber()
    {
        foreach (Tile tile in woodTiles) { tile.Timber(); }
        spriteChild.enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;

        woodCollect.SetIncrement(gameObject.GetComponent<Transform>());
    }
}
