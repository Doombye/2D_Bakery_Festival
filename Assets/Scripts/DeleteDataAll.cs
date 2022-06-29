using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif


public class DeleteDataAll : MonoBehaviour
{

#if UNITY_EDITOR

    [MenuItem("PlayerPrefs/Delete All")]
    static void DeletePlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("All PlayerPrefs deleted");
    }

    [MenuItem("PlayerPrefs/Save All")]
    static void SavePlayerPrefs()
    {
        PlayerPrefs.Save();
        Debug.Log("PlayerPrefs saved");
    }
#endif

}
