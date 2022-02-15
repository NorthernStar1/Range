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
    
    public static GameUI Singleton;
    private void Awake()
    {
        Singleton = this;
        DontDestroyOnLoad(this);
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
        if(container.WindowInstance != null)
            Destroy(container.WindowInstance.Root); 
    }
    public async Task Show(UIWindowType type)
    {
        if (IsBusy) return;
        IsBusy = true;
        var window = GetContainerWithType(type).WindowInstance;
        await window.Show();
        IsBusy = false;
    }public async Task ShowOnly(UIWindowType type)
    {
        if (IsBusy) return;
        IsBusy = true;
        await HideAllWindows();
        var window = GetContainerWithType(type).WindowInstance;
        await window.Show();
        IsBusy = false;
    }
    public async Task Hide(UIWindowType type)
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
