using System;
using System.Collections.Generic;
using UIManager;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game
{
    public class GameManager : MonoBehaviour
    {
        public List<UIWindowType> MenuWindows;
        public List<UIWindowType> LevelWindows;

        public static GameManager Singleton;

        public void LoadLevel(int index)
        {
            var ui = GameUI.Singleton;
            MenuWindows.ForEach(x => ui.Unload(x));
            LevelWindows.ForEach(x => ui.Load(x));
            SceneManager.LoadScene(index);
            //await ui.Show(UIWindowType.MainMenu);
        }
        public async void LoadMenu(bool isFirsStart = false)
        {
            var ui = GameUI.Singleton;
            LevelWindows.ForEach(x => ui.Unload(x));
            MenuWindows.ForEach(x => ui.Load(x));
            if(isFirsStart == false) SceneManager.LoadScene(1);
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
