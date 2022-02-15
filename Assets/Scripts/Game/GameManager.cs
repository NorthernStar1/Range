using System.Collections.Generic;
using UIManager;
using UnityEngine;
namespace Game
{
    public class GameManager : MonoBehaviour
    {
        public List<UIWindowType> MenuWindows;
        public List<UIWindowType> LevelWindows;

        public static GameManager Singleton;

        public  async void LoadLevel(int index)
        {
            var ui = GameUI.Singleton;
            MenuWindows.ForEach(x => ui.Unload(x));
            LevelWindows.ForEach(x => ui.Load(x));
            await LevelLoaderWindow.instance.Show();
            LevelLoaderWindow.SwitchToScene(index);
        }
        public async void LoadMenu(bool isFirsStart = false)
        {
            var ui = GameUI.Singleton;
            LevelWindows.ForEach(x => ui.Unload(x));
            MenuWindows.ForEach(x => ui.Load(x));
            ui.Load(UIWindowType.LevelLoaderWindow);           
            if (isFirsStart == false)
            {
                await LevelLoaderWindow.instance.Show();
                LevelLoaderWindow.SwitchToScene(1);
            }
            await ui.Show(UIWindowType.MainMenu);
        }

        private void Awake()
        {
            Singleton = this;
            DontDestroyOnLoad(this);
        }

        private void Start()
        {
            LoadMenu(true);
        }
    }
}
