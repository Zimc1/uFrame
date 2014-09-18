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
using System.Collections.Generic;
using System.Linq;


[System.SerializableAttribute()]
public sealed partial class FPSMainMenuManagerSettings {
    
    public string[] _Scenes;
}

public class FPSMainMenuManagerBase : SceneManager {
    
    public WavesFPSGameManagerSettings _PlayTransition = new WavesFPSGameManagerSettings();
    
    private FPSMenuViewModel _FPSMenu;
    
    private FPSMenuController _FPSMenuController;
    
    public FPSMainMenuManagerSettings _FPSMainMenuManagerSettings = new FPSMainMenuManagerSettings();
    
    [Inject("FPSMenu")]
    public virtual FPSMenuViewModel FPSMenu {
        get {
            if ((this._FPSMenu == null)) {
                this._FPSMenu = SetupViewModel<FPSMenuViewModel>(FPSMenuController, "FPSMenu");
            }
            return this._FPSMenu;
        }
        set {
            _FPSMenu = value;
        }
    }
    
    [Inject()]
    public virtual FPSMenuController FPSMenuController {
        get {
            if ((this._FPSMenuController == null)) {
                this._FPSMenuController = new FPSMenuController() { Container = Container, Context = Context };
            }
            return this._FPSMenuController;
        }
        set {
            _FPSMenuController = value;
        }
    }
    
    public override void Setup() {
        base.Setup();
        Container.RegisterInstance<FPSMenuViewModel>(FPSMenu,"FPSMenu");
        Container.RegisterInstance(FPSMenuController,false);
        this.Container.InjectAll();
    }
    
    public virtual void Play() {
        GameManager.TransitionLevel<WavesFPSGameManager>((container) =>{container._WavesFPSGameManagerSettings = _PlayTransition; }, this._PlayTransition._Scenes);
    }
}

public enum FPSMainMenuManagerRegistry {
    
    FPSMenu,
}

[System.SerializableAttribute()]
public sealed partial class WavesFPSGameManagerSettings {
    
    public string[] _Scenes;
}

public class WavesFPSGameManagerBase : SceneManager {
    
    public FPSMainMenuManagerSettings _MainMenuTransition = new FPSMainMenuManagerSettings();
    
    public FPSMainMenuManagerSettings _QuitGameTransition = new FPSMainMenuManagerSettings();
    
    private WavesFPSGameViewModel _FPSGame;
    
    private FPSPlayerViewModel _LocalPlayer;
    
    private WavesFPSGameController _WavesFPSGameController;
    
    private DeathMatchGameController _DeathMatchGameController;
    
    private FPSDamageableController _FPSDamageableController;
    
    private FPSEnemyController _FPSEnemyController;
    
    private FPSGameController _FPSGameController;
    
    private FPSPlayerController _FPSPlayerController;
    
    private FPSWeaponController _FPSWeaponController;
    
    public WavesFPSGameManagerSettings _WavesFPSGameManagerSettings = new WavesFPSGameManagerSettings();
    
    [Inject("FPSGame")]
    public virtual WavesFPSGameViewModel FPSGame {
        get {
            if ((this._FPSGame == null)) {
                this._FPSGame = SetupViewModel<WavesFPSGameViewModel>(WavesFPSGameController, "FPSGame");
            }
            return this._FPSGame;
        }
        set {
            _FPSGame = value;
        }
    }
    
    [Inject("LocalPlayer")]
    public virtual FPSPlayerViewModel LocalPlayer {
        get {
            if ((this._LocalPlayer == null)) {
                this._LocalPlayer = SetupViewModel<FPSPlayerViewModel>(FPSPlayerController, "LocalPlayer");
            }
            return this._LocalPlayer;
        }
        set {
            _LocalPlayer = value;
        }
    }
    
    [Inject()]
    public virtual WavesFPSGameController WavesFPSGameController {
        get {
            if ((this._WavesFPSGameController == null)) {
                this._WavesFPSGameController = new WavesFPSGameController() { Container = Container, Context = Context };
            }
            return this._WavesFPSGameController;
        }
        set {
            _WavesFPSGameController = value;
        }
    }
    
    [Inject()]
    public virtual DeathMatchGameController DeathMatchGameController {
        get {
            if ((this._DeathMatchGameController == null)) {
                this._DeathMatchGameController = new DeathMatchGameController() { Container = Container, Context = Context };
            }
            return this._DeathMatchGameController;
        }
        set {
            _DeathMatchGameController = value;
        }
    }
    
    [Inject()]
    public virtual FPSDamageableController FPSDamageableController {
        get {
            if ((this._FPSDamageableController == null)) {
                this._FPSDamageableController = new FPSDamageableController() { Container = Container, Context = Context };
            }
            return this._FPSDamageableController;
        }
        set {
            _FPSDamageableController = value;
        }
    }
    
    [Inject()]
    public virtual FPSEnemyController FPSEnemyController {
        get {
            if ((this._FPSEnemyController == null)) {
                this._FPSEnemyController = new FPSEnemyController() { Container = Container, Context = Context };
            }
            return this._FPSEnemyController;
        }
        set {
            _FPSEnemyController = value;
        }
    }
    
    [Inject()]
    public virtual FPSGameController FPSGameController {
        get {
            if ((this._FPSGameController == null)) {
                this._FPSGameController = new FPSGameController() { Container = Container, Context = Context };
            }
            return this._FPSGameController;
        }
        set {
            _FPSGameController = value;
        }
    }
    
    [Inject()]
    public virtual FPSPlayerController FPSPlayerController {
        get {
            if ((this._FPSPlayerController == null)) {
                this._FPSPlayerController = new FPSPlayerController() { Container = Container, Context = Context };
            }
            return this._FPSPlayerController;
        }
        set {
            _FPSPlayerController = value;
        }
    }
    
    [Inject()]
    public virtual FPSWeaponController FPSWeaponController {
        get {
            if ((this._FPSWeaponController == null)) {
                this._FPSWeaponController = new FPSWeaponController() { Container = Container, Context = Context };
            }
            return this._FPSWeaponController;
        }
        set {
            _FPSWeaponController = value;
        }
    }
    
    public override void Setup() {
        base.Setup();
        Container.RegisterInstance<WavesFPSGameViewModel>(FPSGame,"FPSGame");
        Container.RegisterInstance<FPSGameViewModel>(FPSGame,"FPSGame");
        Container.RegisterInstance<FPSPlayerViewModel>(LocalPlayer,"LocalPlayer");
        Container.RegisterInstance(WavesFPSGameController,false);
        Container.RegisterInstance(DeathMatchGameController,false);
        Container.RegisterInstance(FPSDamageableController,false);
        Container.RegisterInstance(FPSEnemyController,false);
        Container.RegisterInstance(FPSGameController,false);
        Container.RegisterInstance(FPSPlayerController,false);
        Container.RegisterInstance(FPSWeaponController,false);
        this.Container.InjectAll();
    }
    
    public virtual void MainMenu() {
        GameManager.TransitionLevel<FPSMainMenuManager>((container) =>{container._FPSMainMenuManagerSettings = _MainMenuTransition; }, this._MainMenuTransition._Scenes);
    }
    
    public virtual void QuitGame() {
        GameManager.TransitionLevel<FPSMainMenuManager>((container) =>{container._FPSMainMenuManagerSettings = _QuitGameTransition; }, this._QuitGameTransition._Scenes);
    }
}

public enum WavesFPSGameManagerRegistry {
    
    FPSGame,
}
