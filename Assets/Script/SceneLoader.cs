using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadScene(string Main)
    {
        //Melakukan pengecekan jika name tidak null atau empty
        if (!string.IsNullOrEmpty(Main))
        {
            //membuka scene dengan nama sesuai dengan variable name
            SceneManager.LoadScene(Main);
        }
    }
}
