using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class PlayerPreferences : MonoBehaviour
{
    public TMP_Dropdown locomotionDropdown;
    public Slider musicVolume;
    public Slider sfxVolume;


    public void SaveToJson()
    {
        PlayerData playerData = new PlayerData();
        playerData.locomotionSetting = locomotionDropdown.value;
        playerData.musicVolume = musicVolume.value;
        playerData.soundFxVolume = sfxVolume.value;
        
        string json = JsonUtility.ToJson(playerData, true);
        File.WriteAllText(Application.dataPath + "/Scripts/PlayerPrefs.json", json);
    }

    public void LoadFromJson()
    {
        string json = File.ReadAllText(Application.dataPath + "/Scripts/PlayerPrefs.json");
        PlayerData playerData = JsonUtility.FromJson<PlayerData>(json);

        locomotionDropdown.value = playerData.locomotionSetting;
        musicVolume.value = playerData.musicVolume;
        sfxVolume.value = playerData.soundFxVolume;

    }

    public void DeleteData()
    {
        PlayerPrefs.DeleteAll();
    }
}
