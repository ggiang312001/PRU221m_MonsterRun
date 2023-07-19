using Assets.Scripts.ObjectSave;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditorInternal.VersionControl;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        SaveHealthAndTimeAndSpeed();
        GameObject[] ground1 = GameObject.FindGameObjectsWithTag("Ground");
        GameObject[] ground2 = GameObject.FindGameObjectsWithTag("Ground1");
        GameObject[] ground3 = GameObject.FindGameObjectsWithTag("Ground2");
        GameObject[] listFire = GameObject.FindGameObjectsWithTag("FireTrap");
        GameObject[] listMine = GameObject.FindGameObjectsWithTag("MineTrap");
        GameObject[] listThorn = GameObject.FindGameObjectsWithTag("ThornTrap");
        GameObject[] listSnow = GameObject.FindGameObjectsWithTag("SnowItem");
        GameObject[] listHeart = GameObject.FindGameObjectsWithTag("HeartItem");
        GameObject[] listFighter = GameObject.FindGameObjectsWithTag("Fighter");
        GameObject[] listWizard = GameObject.FindGameObjectsWithTag("Wizard");

        List<Item> items = new List<Item>();
        foreach (var item in listFire)
        {
            items.Add(new Item {Type = "trap", Name = "fire", x = item.transform.position.x,y= item.transform.position.y });
        }
        foreach (var item in listMine)
        {
            items.Add(new Item { Type = "trap", Name = "mine", x = item.transform.position.x, y = item.transform.position.y });
        }
        foreach (var item in listThorn)
        {
            items.Add(new Item { Type = "trap", Name = "thorn", x = item.transform.position.x, y = item.transform.position.y });
        }
        foreach (var item in listHeart)
        {
            items.Add(new Item { Type = "item", Name = "heart", x = item.transform.position.x, y = item.transform.position.y });
        }
        foreach (var item in listSnow)
        {
            items.Add(new Item { Type = "item", Name = "snow", x = item.transform.position.x, y = item.transform.position.y });
        }
        foreach (var item in listWizard)
        {
            items.Add(new Item { Type = "monter", Name = "wizard", x = item.transform.position.x, y = item.transform.position.y });
        }
        foreach (var item in listFighter)
        {
            items.Add(new Item { Type = "monter", Name = "fighter", x = item.transform.position.x, y = item.transform.position.y });
        }
        foreach (var item in ground1)
        {
            items.Add(new Item { Type = "ground", Name = "mediumground", x = item.transform.position.x, y = item.transform.position.y });
        }
        foreach (var item in ground2)
        {
            items.Add(new Item { Type = "ground", Name = "longground", x = item.transform.position.x, y = item.transform.position.y });
        }
        foreach (var item in ground3)
        {
            items.Add(new Item { Type = "ground", Name = "shortground", x = item.transform.position.x, y = item.transform.position.y });
        }
        
        string path = Application.dataPath;
        var json = JsonConvert.SerializeObject(items, Formatting.Indented);
        File.WriteAllText($"{path}/Scripts/data.txt", json);

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Player playerSave = new Player { x = player.transform.position.x, y = player.transform.position.y };
        var json1 = JsonConvert.SerializeObject(playerSave, Formatting.Indented);
        File.WriteAllText($"{path}/Scripts/player.txt", json1);
        SceneManager.LoadScene("HomeScene");
    }

    public void SaveHealthAndTimeAndSpeed()
    {
        HUD hud = GameObject.FindGameObjectWithTag("HUD").GetComponent<HUD>();
        PlayerPrefs.SetInt("Health", hud.GetHealth());
        PlayerPrefs.SetFloat("Time", hud.GetTimer());
        if(GameManage.Instance.isSnow == true) { PlayerPrefs.SetFloat("Speed", SnowItem.speedBeforeSnow); }
        else
        {
            PlayerPrefs.SetFloat("Speed", GameManage.Instance.speed);
        }
        
    }
}
