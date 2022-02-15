using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UIManager;
using DG.Tweening;


public class LevelLoaderWindow : BaseUIWindow
{
    public CanvasGroup ContinueText;
    public Text LoadingPercent;
    public Image LoadingImage;
    public static LevelLoaderWindow instance;
    private AsyncOperation loadingSceneOperaion;
    public static void SwitchToScene(int SceneIndex)
    {
        instance.loadingSceneOperaion = SceneManager.LoadSceneAsync(SceneIndex);
    }
    private async void Update()
    {
       
        if (loadingSceneOperaion == null)
            return;
        Debug.Log($"Operation is: {loadingSceneOperaion.GetType()}");
        LoadingImage.transform.Rotate(Vector3.up, 20f * Time.deltaTime);
        if (loadingSceneOperaion.progress == 1)
        {
            ContinueText.alpha = 1f;
            if (Input.anyKey)
            {
                await Hide();
                await GameUI.Singleton.Show(UIWindowType.GUI);
                loadingSceneOperaion = null;
            }


            else
            {
                LoadingPercent.text = Mathf.RoundToInt(loadingSceneOperaion.progress * 100) + "%";
                LoadingImage.fillAmount = loadingSceneOperaion.progress;
                Debug.Log($"Load progress: {loadingSceneOperaion.progress * 100}");
            }
        }
    }
    public override async Task Initialize()
    {
        await base.Initialize();
        instance = this;
    }
    
    public override async Task Show()
    {
        Debug.Log("Show LevelLoaderWindow");
        await base.Show();
    }
    public override async Task Hide()
    {
        await base.Hide();
        Debug.Log("Hide LevelLoaderWindow");
    }

}
