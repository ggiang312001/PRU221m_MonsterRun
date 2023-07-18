using Assets.Scripts.ObjectSave;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.VersionControl;
using UnityEngine;

public class SaveGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Save()
    {
        List<GameObject> listFire = FirePool.Instance.listFireActive;
        List<Item> items = new List<Item>();
        foreach (var item in listFire)
        {
            items.Add(new Item { x = item.transform.position.x,y= item.transform.position.y });
        }
    }
}
