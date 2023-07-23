using Assets.Scripts.ObjectSave;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
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
    private static string GetFilePath(string FolderName, string FileName = "")
    {
        string filePath;
        filePath = Path.Combine(Application.persistentDataPath,"data" ,FolderName);
        if (FileName != "")
            filePath = Path.Combine(filePath, FileName + ".json");
        return filePath;
    }
    public void Save()
    {
        SaveHealthAndTimeAndSpeed();
        GameObject[] ground1 = GameObject.FindGameObjectsWithTag("Ground");
        GameObject[] ground2 = GameObject.FindGameObjectsWithTag("Ground2");
        GameObject[] ground3 = GameObject.FindGameObjectsWithTag("Ground3");
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
        //string filePath = Path.Combine(Application.persistentDataPath, "data.json");

        //string path = Application.dataPath + "/Scripts/data/data.json";
        string filePath = "";
        filePath = GetFilePath("data", "data");
        if (!Directory.Exists(Path.GetDirectoryName(filePath)))
        {
            Directory.CreateDirectory(Path.GetDirectoryName(filePath));
        }
        var json = JsonConvert.SerializeObject(items, Formatting.Indented);

        File.WriteAllText(filePath, json);

        //GameObject player = GameObject.FindGameObjectWithTag("Player");
        //Player playerSave = new Player { x = player.transform.position.x, y = player.transform.position.y };
        //var json1 = JsonConvert.SerializeObject(playerSave, Formatting.Indented);
        //File.WriteAllText($"{path}/Scripts/data/player.json", json1);
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
