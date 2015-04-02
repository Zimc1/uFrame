﻿using System.CodeDom;
using UnityEngine;
using System.Collections;
using System.Linq;
using System.Runtime.InteropServices;
using Invert.Core;
using Invert.Core.GraphDesigner;
using Invert.uFrame.MVVM;
using uFrame.Graphs;


[TemplateClass(MemberGeneratorLocation.Both, "{0}")]
public partial class SceneTemplate : IClassTemplate<SceneManagerNode>
{
    public void TemplateSetup()
    {
        if (Ctx.IsDesignerFile)
        {
            Ctx.CurrentDecleration.BaseTypes.Add(typeof(MonoBehaviour).ToCodeReference());
            Ctx.SetBaseType(typeof(Scene));
        }
    }

    public string OutputPath
    {
        get { return Path2.Combine(Ctx.Data.Graph.Name, "Scenes"); }
    }

    public bool CanGenerate
    {
        get { return true; }
    }
    public TemplateContext<SceneManagerNode> Ctx { get; set; }
}

[TemplateClass(MemberGeneratorLocation.Both, "{0}Loader")]
public partial class SceneLoaderTemplate : IClassTemplate<SceneManagerNode>
{
    public void TemplateSetup()
    {
        if (Ctx.IsDesignerFile)
        {
            //Ctx.SetBaseType("SceneLoader<{0}>",Ctx.Data.Name)
            Ctx.CurrentDecleration.BaseTypes.Clear();
            Ctx.CurrentDecleration.BaseTypes.Add(string.Format("SceneLoader<{0}>", Ctx.Data.Name));
        } 
    }

    [TemplateMethod(MemberGeneratorLocation.Both, CallBase = false)]
    protected virtual void LoadScene(object scene, object progressDelegate)
    {
        Ctx.CurrentMethod.Parameters[0].Type = new CodeTypeReference(Ctx.Data.Name);
        Ctx.CurrentMethod.Parameters[1].Type = new CodeTypeReference("Action<float, string>");
        Ctx.CurrentMethod.Attributes |= MemberAttributes.Override;        
        Ctx.CurrentMethod.ReturnType = "IEnumerator".ToCodeReference();
        Ctx._("yield break");
    }
    
    [TemplateMethod(MemberGeneratorLocation.Both,CallBase = false)]
    protected virtual void UnloadScene(object scene, object progressDelegate)
    {
        Ctx.CurrentMethod.Parameters[0].Type = new CodeTypeReference(Ctx.Data.Name);
        Ctx.CurrentMethod.Parameters[1].Type = new CodeTypeReference("Action<float, string>");
        Ctx.CurrentMethod.Attributes |= MemberAttributes.Override;
        Ctx.CurrentMethod.ReturnType = "IEnumerator".ToCodeReference();
        

        Ctx._("yield break");
    }

    public string OutputPath
    {
        get { return Path2.Combine(Ctx.Data.Graph.Name, "Scenes"); }
    }

    public bool CanGenerate
    {
        get { return true; }
    }
    public TemplateContext<SceneManagerNode> Ctx { get; set; }
}

[TemplateClass(MemberGeneratorLocation.Both, "{0}Loader")]
public partial class SystemLoaderTemplate : IClassTemplate<SubsystemNode>
{
    public void TemplateSetup()
    {
        foreach (var property in Ctx.Data.PersistedItems.OfType<ITypedItem>())
        {
            var type = InvertApplication.FindTypeByName(property.RelatedTypeName);
            if (type == null) continue;

            Ctx.TryAddNamespace(type.Namespace);
        }
        
        if (Ctx.IsDesignerFile)
        {
            Ctx.CurrentDecleration.BaseTypes.Add(typeof(MonoBehaviour).ToCodeReference());
            Ctx.SetBaseType(typeof (SystemLoader));
        }

        Ctx.AddIterator("InstanceProperty", node => node.Instances);
        Ctx.AddIterator("ControllerProperty", node => node.GetContainingNodes(Ctx.Data.Project).OfType<ElementNode>());
    }

    [TemplateMethod(MemberGeneratorLocation.Both,CallBase = true)]
    public void Load()
    {
        Ctx.CurrentMethod.Attributes |= MemberAttributes.Override;

        if (!Ctx.IsDesignerFile)
            Ctx.CurrentMethod.invoke_base();

        if (Ctx.IsDesignerFile)
        {
            foreach (var item in Ctx.Data.Instances)
            {
                Ctx._("Container.RegisterViewModel<{0}>({1}, \"{1}\")", item.SourceItem.Name.AsViewModel(), item.Name, item.Name);
            }

            foreach (var item in Ctx.Data.GetContainingNodes(Ctx.Data.Project).OfType<ElementNode>())
            {
                Ctx._("Container.RegisterViewModelManager<{0}>(new ViewModelManager<{0}>())", item.Name.AsViewModel());
                Ctx._("Container.RegisterController<{0}>({0})", item.Name.AsController());
            }
        }
        
    }


    //[Inject("LocalPlayer")]
    [TemplateProperty("{0}", AutoFillType.NameOnly)]
    public virtual ViewModel InstanceProperty
    {
        get
        {
            var instance = Ctx.ItemAs<InstancesReference>();
            Ctx.SetType(instance.SourceItem.Name.AsViewModel());

            Ctx.AddAttribute(typeof(InjectAttribute))
                .Arguments.Add(new CodeAttributeArgument(new CodePrimitiveExpression(instance.Name)));

            Ctx._if("this.{0} == null", instance.Name.AsField())
                .TrueStatements._("this.{0} = CreateInstanceViewModel<{1}>( \"{2}\")", instance.Name.AsField(), instance.SourceItem.Name.AsViewModel(), instance.Name);

            Ctx.CurrentDecleration._private_(Ctx.CurrentProperty.Type, instance.Name.AsField());
            Ctx._("return {0}", instance.Name.AsField());

            //if ((this._LocalPlayer == null)) {
            //    this._LocalPlayer = CreateInstanceViewModel<FPSPlayerViewModel>(FPSPlayerController, "LocalPlayer");
            //}
            //return this._LocalPlayer;
            return null;
        }
        set
        {
            //_LocalPlayer = value;
        }
    }

    //[Inject()]
    [TemplateProperty(uFrameFormats.CONTROLLER_FORMAT, AutoFillType.NameOnly)]
    public virtual Controller ControllerProperty
    {
        get
        {
            Ctx.SetType(Ctx.Item.Name.AsController());
            Ctx.AddAttribute(typeof(InjectAttribute));
            Ctx.CurrentDecleration._private_(Ctx.CurrentProperty.Type, Ctx.Item.Name.AsController().AsField());
            Ctx.LazyGet(Ctx.Item.Name.AsController().AsField(), "Container.CreateInstance(typeof({0})) as {0};", Ctx.Item.Name.AsController());
            return null;
        }
        set
        {
            Ctx._("{0} = value", Ctx.Item.Name.AsController().AsField());
        }
    }

    public string OutputPath
    {
        get { return Path2.Combine(Ctx.Data.Graph.Name, "SystemLoaders"); }
    }

    public bool CanGenerate
    {
        get { return true; }
    }
    public TemplateContext<SubsystemNode> Ctx { get; set; }
}