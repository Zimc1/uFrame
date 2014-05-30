// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 2.0.50727.1433
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Linq;
using UnityEngine;


public abstract class GUIMainMenuScreenViewBase : ViewBase {
    
    [UFToggleGroup("PlayerName")]
    [UnityEngine.HideInInspector()]
    [UFRequireInstanceMethod("PlayerNameChanged")]
    public bool _BindPlayerName;
    
    [UFGroup("PlayerName")]
    [UnityEngine.HideInInspector()]
    [UFRequireInstanceMethod("GetPlayerNameTwoWayValue")]
    public bool _PlayerNameIsTwoWay;
    
    [UFGroup("View Model Properties")]
    [UnityEngine.HideInInspector()]
    public string _PlayerName;
    
    public override System.Type ViewModelType {
        get {
            return typeof(GUIMainMenuScreenViewModel);
        }
    }
    
    public override bool IsMultiInstance {
        get {
            return false;
        }
    }
    
    public GUIMainMenuScreenViewModel GUIMainMenuScreen {
        get {
            return ((GUIMainMenuScreenViewModel)(this.ViewModelObject));
        }
        set {
            this.ViewModelObject = value;
        }
    }
    
    public virtual void PlayerNameChanged(string value) {
    }
    
    public virtual string GetPlayerNameTwoWayValue() {
        throw new System.NotImplementedException();
    }
    
    public override void Bind() {
        if (this._BindPlayerName) {
            if (this._PlayerNameIsTwoWay) {
                this.BindProperty(()=>GUIMainMenuScreen._PlayerNameProperty, this.PlayerNameChanged, this.GetPlayerNameTwoWayValue);
            }
            else {
                this.BindProperty(()=>GUIMainMenuScreen._PlayerNameProperty, this.PlayerNameChanged);
            }
        }
    }
    
    public override ViewModel CreateModel() {
        return this.ResolveViewModel(GameManager.Container.Resolve<GUIMainMenuScreenController>());
    }
    
    public virtual void ExecuteRandomName() {
        this.ExecuteCommand(GUIMainMenuScreen.RandomName);
    }

    public override void InitializeViewModel(ViewModel viewModel) {
        GUIMainMenuScreenViewModel gUIMainMenuScreen = ((GUIMainMenuScreenViewModel)(viewModel));
        gUIMainMenuScreen.PlayerName = this._PlayerName;
    }
}

public abstract class GUIMainMenuViewBase : ViewBase {
    
    [UFToggleGroup("MainMenuScreen")]
    [UnityEngine.HideInInspector()]
    public bool _BindMainMenuScreen;
    
    [UFGroup("MainMenuScreen")]
    [UnityEngine.HideInInspector()]
    [UFRequireInstanceMethod("GetMainMenuScreenTwoWayValue")]
    public bool _MainMenuScreenIsTwoWay;
    
    [UFGroup("MainMenuScreen")]
    [UnityEngine.HideInInspector()]
    public UnityEngine.GameObject _MainMenuScreenPrefab;
    
    [UFGroup("View Model Properties")]
    [UnityEngine.HideInInspector()]
    public GUIMainMenuScreenViewBase _MainMenuScreen;
    
    public override System.Type ViewModelType {
        get {
            return typeof(GUIMainMenuViewModel);
        }
    }
    
    public override bool IsMultiInstance {
        get {
            return false;
        }
    }
    
    public GUIMainMenuViewModel GUIMainMenu {
        get {
            return ((GUIMainMenuViewModel)(this.ViewModelObject));
        }
        set {
            this.ViewModelObject = value;
        }
    }
    
    public virtual void MainMenuScreenChanged(GUIMainMenuScreenViewModel value) {
        if (value == null) {
            Destroy(_MainMenuScreen.gameObject);
        }
        if (_MainMenuScreenPrefab == null) {
            this._MainMenuScreen = ((GUIMainMenuScreenViewBase)(this.InstantiateView(value)));
        }
        else {
            this._MainMenuScreen = ((GUIMainMenuScreenViewBase)(this.InstantiateView(this._MainMenuScreenPrefab, value)));
        }
    }
    
    public virtual GUIMainMenuScreenViewModel GetMainMenuScreenTwoWayValue() {
        if (this._MainMenuScreen == null || this._MainMenuScreen.ViewModelObject == null) {
            return null;
        }
        return ((GUIMainMenuScreenViewModel)(this._MainMenuScreen.ViewModelObject));
    }
    
    public override void Bind() {
        if (this._BindMainMenuScreen) {
            if (this._MainMenuScreenIsTwoWay) {
                this.BindProperty(()=>GUIMainMenu._MainMenuScreenProperty, this.MainMenuScreenChanged, this.GetMainMenuScreenTwoWayValue);
            }
            else {
                this.BindProperty(()=>GUIMainMenu._MainMenuScreenProperty, this.MainMenuScreenChanged);
            }
        }
    }
    
    public override ViewModel CreateModel() {
        return this.ResolveViewModel(GameManager.Container.Resolve<GUIMainMenuController>());
    }
    
    public virtual void ExecutePlay() {
        this.ExecuteCommand(GUIMainMenu.Play);
    }

    public override void InitializeViewModel(ViewModel viewModel) {
        GUIMainMenuViewModel gUIMainMenu = ((GUIMainMenuViewModel)(viewModel));
        gUIMainMenu.MainMenuScreen = this._MainMenuScreen == null ? null : this._MainMenuScreen.ViewModelObject as GUIMainMenuScreenViewModel;
    }
}

public abstract class GUIGameViewBase : ViewBase {
    
    [UFToggleGroup("CurrentPlayerName")]
    [UnityEngine.HideInInspector()]
    [UFRequireInstanceMethod("CurrentPlayerNameChanged")]
    public bool _BindCurrentPlayerName;
    
    [UFGroup("CurrentPlayerName")]
    [UnityEngine.HideInInspector()]
    [UFRequireInstanceMethod("GetCurrentPlayerNameTwoWayValue")]
    public bool _CurrentPlayerNameIsTwoWay;
    
    [UFGroup("View Model Properties")]
    [UnityEngine.HideInInspector()]
    public string _CurrentPlayerName;
    
    public override System.Type ViewModelType {
        get {
            return typeof(GUIGameViewModel);
        }
    }
    
    public override bool IsMultiInstance {
        get {
            return false;
        }
    }
    
    public GUIGameViewModel GUIGame {
        get {
            return ((GUIGameViewModel)(this.ViewModelObject));
        }
        set {
            this.ViewModelObject = value;
        }
    }
    
    public virtual void CurrentPlayerNameChanged(string value) {
    }
    
    public virtual string GetCurrentPlayerNameTwoWayValue() {
        throw new System.NotImplementedException();
    }
    
    public override void Bind() {
        if (this._BindCurrentPlayerName) {
            if (this._CurrentPlayerNameIsTwoWay) {
                this.BindProperty(()=>GUIGame._CurrentPlayerNameProperty, this.CurrentPlayerNameChanged, this.GetCurrentPlayerNameTwoWayValue);
            }
            else {
                this.BindProperty(()=>GUIGame._CurrentPlayerNameProperty, this.CurrentPlayerNameChanged);
            }
        }
    }
    
    public override ViewModel CreateModel() {
        return this.ResolveViewModel(GameManager.Container.Resolve<GUIGameController>());
    }
    
    public virtual void ExecuteQuitGame() {
        this.ExecuteCommand(GUIGame.QuitGame);
    }

    public override void InitializeViewModel(ViewModel viewModel) {
        GUIGameViewModel gUIGame = ((GUIGameViewModel)(viewModel));
        gUIGame.CurrentPlayerName = this._CurrentPlayerName;
    }
}

public partial class GUIMainMenuScreenView : GUIMainMenuScreenViewBase {
}

public partial class GUIMainMenuView : GUIMainMenuViewBase {
}
