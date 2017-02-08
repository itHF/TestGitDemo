
using EncryptUnityDLL;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class desKeyCheck : MonoBehaviour
{
    public InputField inputstring;
    public InputField macString;
    public Text showText;

    // public string MainSceneName = "Main";
    void Start ()
    {
        macString.text = EncryptDLL.showLocalMac();
        Debug.Log(macString.text);

        Debug.Log(EncryptDLL.getRightPass());
        if (EncryptDLL.checkPassStart())
        {
            // SceneManager.LoadScene(MainSceneName);
            SceneManager.LoadScene(1);
        }

        showText.text = "请把此mac地址复制用于注册：";
        //showText.color = Color.red;
    }

    public void checkPass()
    {
        if (EncryptDLL.checkPass(inputstring.text))
        {
            // SceneManager.LoadScene(MainSceneName);
            SceneManager.LoadScene(1);
        }
    }
}
