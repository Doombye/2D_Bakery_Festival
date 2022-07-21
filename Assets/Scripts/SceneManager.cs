using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : Singleton<SceneManager>
{
    int ClickCount = 0;         // 뒤로가기 버튼 클릭 횟수

    private void Update()
    {
        CloseGame();
        //Debug.Log("CloseGame");

    }
    public void LoadScene(string sceneName)
    {
        // 지정된 씬을 로드한다.
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }
    public void ReloadScene()
    {
        // 현재의 씬을 취득
        var scene = UnityEngine.SceneManagement.SceneManager.GetActiveScene();

        // 현재 씬을 다시 로드 한다.
        UnityEngine.SceneManagement.SceneManager.LoadScene(scene.name);
    }

    // 게임 종료
    public void CloseGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ClickCount++;
            if (!IsInvoking("DoubleClick"))     // 더블클릭 하지 않으면
            {
                Invoke("DoubleClick", 1.0f);    // 1초 딜레이
                //Debug.Log("더블클릭 하면 게임종료");
            }
            else if (ClickCount == 2)            // 더블클릭을 했다면
            {

                //Debug.Log("게임종료");
                CancelInvoke("DoubleClick");    // 더블클릭 함수 취소시키고
                Application.Quit();             // 앱 종료
            }
        }
    }
    void DoubleClick()
    {
        ClickCount = 0;
    }

    public void QuitGame()
    {
        // 애플리케이션 종료
        Application.Quit();
    }
}