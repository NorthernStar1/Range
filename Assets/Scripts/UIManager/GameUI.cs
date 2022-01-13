using System.Collections;
using System.Collections.Generic;
using UIManager;
using UnityEngine;
using System.Linq;
using System.Threading.Tasks;

public class GameUI : MonoBehaviour
{
    public Transform WindowsRoot;
    public List<UIWindowContainer> WindowsContainers;
    private bool IsBusy;
    public UIWindowType StartWindow;
    public List<UIWindowType> StartLoadWindows;
    public static GameUI Singleton;
    private void Awake()
    {
        Singleton = this;
        DontDestroyOnLoad(this);
        StartLoadWindows.ForEach(x => Load(x));
        Show(StartWindow);
    }
    
    public void Load(UIWindowType type)
    {
        var container = GetContainerWithType(type);
        var go = Instantiate(container.Prefab, WindowsRoot);
        container.WindowInstance = go.GetComponent<IUIWindow>();
        container.WindowInstance.Initialize();

    }
    public void Unload(UIWindowType type)
    {
        var container = GetContainerWithType(type);
        Destroy(container.WindowInstance.Root);
    }
    public async void Show(UIWindowType type)
    {
        if (IsBusy)
            return;
        IsBusy = true;
        var window = GetContainerWithType(type).WindowInstance;
        await window.Show();
        IsBusy = false;
    }public async void ShowOnly(UIWindowType type)
    {
        if (IsBusy)
            return;
        IsBusy = true;
        await HideAllWindows();
        var window = GetContainerWithType(type).WindowInstance;
        await window.Show();
        IsBusy = false;
    }
    public async void Hide(UIWindowType type)
    {
        if (IsBusy)
            return;
        IsBusy = true;
        var window = GetContainerWithType(type).WindowInstance;
        await window.Hide();
        IsBusy = false;
    }

    private UIWindowContainer GetContainerWithType(UIWindowType type)
    {
       var container = WindowsContainers.FirstOrDefault(x => x.Type == type);
       if (container == default)
       {
            Debug.LogError($"Window of {type} not exist");
            return null;
       }
        return container;
    }

    public async Task HideAllWindows()
    {
        foreach (var x in WindowsContainers)
        {
            if (x.WindowInstance != null && x.WindowInstance.IsShow)
                await x.WindowInstance.Hide();
        }
    }
}
