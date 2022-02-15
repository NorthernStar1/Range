using System.Threading.Tasks;
using UnityEngine;
using System;


namespace UIManager
{
    public interface IUIWindow
    {
        GameObject Root { get; set; }
        Task Initialize();
        Task Show();
        Task Hide();

        bool IsShow { get; set; }
    }

    public enum UIWindowType
    {
        MainMenu,
        LevelList,
        PausedMenu,
        GUI,
        LevelLoaderWindow
    }

    [Serializable]
    public class UIWindowContainer
    {
        public UIWindowType Type;
        public GameObject Prefab;
        public IUIWindow WindowInstance;
    }
}
