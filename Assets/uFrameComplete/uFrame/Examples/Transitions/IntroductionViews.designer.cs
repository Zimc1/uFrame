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


public abstract class IntroductionMenuScreenViewBase : ViewBase {
    
    [UFToggleGroup("Title")]
    [UnityEngine.HideInInspector()]
    [UFRequireInstanceMethod("TitleChanged")]
    public bool _BindTitle;
    
    [UFGroup("Title")]
    [UnityEngine.HideInInspector()]
    [UFRequireInstanceMethod("GetTitleTwoWayValue")]
    public bool _TitleIsTwoWay;
    
    [UFGroup("View Model Properties")]
    [UnityEngine.HideInInspector()]
    public string _Title;
    
    public override System.Type ViewModelType {
        get {
            return typeof(IntroductionMenuScreenViewModel);
        }
    }
    
    public override bool IsMultiInstance {
        get {
            return false;
        }
    }
    
    public IntroductionMenuScreenViewModel IntroductionMenuScreen {
        get {
            return ((IntroductionMenuScreenViewModel)(this.ViewModelObject));
        }
        set {
            this.ViewModelObject = value;
        }
    }
    
    public virtual void TitleChanged(string value) {
    }
    
    public virtual string GetTitleTwoWayValue() {
        throw new System.NotImplementedException();
    }
    
    public override void Bind() {
        if (this._BindTitle) {
            if (this._TitleIsTwoWay) {
                this.BindProperty(()=>IntroductionMenuScreen._TitleProperty, this.TitleChanged, this.GetTitleTwoWayValue);
            }
            else {
                this.BindProperty(()=>IntroductionMenuScreen._TitleProperty, this.TitleChanged);
            }
        }
    }
    
    public override ViewModel CreateModel() {
        return this.RequestViewModel(GameManager.Container.Resolve<IntroductionMenuScreenController>());
    }
    
    public virtual void ExecutePlay() {
        this.ExecuteCommand(IntroductionMenuScreen.Play);
    }

    public override void InitializeViewModel(ViewModel viewModel) {
        IntroductionMenuScreenViewModel introductionMenuScreen = ((IntroductionMenuScreenViewModel)(viewModel));
        introductionMenuScreen.Title = this._Title;
    }
}

public abstract class IntroductionGameViewBase : ViewBase {
    
    public override System.Type ViewModelType {
        get {
            return typeof(IntroductionGameViewModel);
        }
    }
    
    public override bool IsMultiInstance {
        get {
            return false;
        }
    }
    
    public IntroductionGameViewModel IntroductionGame {
        get {
            return ((IntroductionGameViewModel)(this.ViewModelObject));
        }
        set {
            this.ViewModelObject = value;
        }
    }
    
    public override void Bind() {
    }
    
    public override ViewModel CreateModel() {
        return this.RequestViewModel(GameManager.Container.Resolve<IntroductionGameController>());
    }
    
    public virtual void ExecuteExit() {
        this.ExecuteCommand(IntroductionGame.Exit);
    }

    public override void InitializeViewModel(ViewModel viewModel) {
    }
}

public partial class IntroductionMenuView : IntroductionMenuScreenViewBase {
}
