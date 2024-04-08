﻿#if UNITY_EDITOR
using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using YNL.Editor.Utilities;

public class EWindowTag : VisualElement
{
    private const string USS_StyleSheet = "Assets/Plugins/Yunasawa の Library/YのL - Editor/Elements/E Window Tag/EWindowTag.uss";

    private static readonly string USS_Background = "background";
    private static readonly string USS_BackgroundHover = "background__hover";
    private static readonly string USS_Icon = "icon";
    private static readonly string USS_Title = "title";
    private static readonly string USS_Subtitle = "subtitle";

    public Button Background;
    public Image Icon;
    public Label Title;
    public Label Subtitle;

    private Color _color;
    private float _maxWidth;
    private Action _action;

    public Action OnClick;

    public bool IsSelected = false;

    public EWindowTag(Texture2D icon, string title, string subtitle, Color color, float maxWidth, Action action) : base()
    {
        this.AddStyle(USS_StyleSheet, EAddress.USSFont);

        Background = new Button();
        Background.AddClass(USS_Background);

        Icon = new();
        Icon.style.backgroundImage = icon;
        Icon.AddClass(USS_Icon);

        Title = new Label(title).AddClass(USS_Title);
        if (subtitle.IsNullOrEmpty()) Title.SetTop(10);
        Subtitle = new Label(subtitle).AddClass(USS_Subtitle);

        Background.AddElements(Icon, Title, Subtitle);

        this.AddElements(Background);

        RegisterCallback<PointerDownEvent>(evt => OnPointerDown(evt), TrickleDown.TrickleDown);
        RegisterCallback<PointerEnterEvent>(evt => OnPointerEnter(evt));
        RegisterCallback<PointerLeaveEvent>(evt => OnPointerLeave(evt));

        _color = color;
        _action = action;
        _maxWidth = maxWidth;

        OnClick += _action;
    }

    ~EWindowTag()
    {
        OnClick -= _action;
    }

    private static void OnPointerDown(PointerDownEvent evt)
    {
        var image = evt.currentTarget as EWindowTag;

        image.OnClick?.Invoke();

        evt.StopPropagation();
    }
    private static void OnPointerEnter(PointerEnterEvent evt)
    {
        var image = evt.currentTarget as EWindowTag;

        image.PointerEnter();

        evt.StopPropagation();
    }
    private static void OnPointerLeave(PointerLeaveEvent evt)
    {
        var image = evt.currentTarget as EWindowTag;

        image.PointerExit();

        evt.StopPropagation();
    }

    public void PointerEnter()
    {
        Background.EnableClass(USS_BackgroundHover);
        Icon.EnableClass(USS_Icon.Hover());
        Title.EnableClass(USS_Title.Hover());
        Subtitle.EnableClass(USS_Subtitle.Hover());

        if (!IsSelected)
        {
            Background.SetBackgroundColor("#242424");
            SetSelectStyle();
        }
    }
    public void PointerExit()
    {
        Background.DisableClass(USS_BackgroundHover);
        Icon.DisableClass(USS_Icon.Hover());
        Title.DisableClass(USS_Title.Hover());
        Subtitle.DisableClass(USS_Subtitle.Hover());

        if (!IsSelected) SetDeselectStyle();
    }

    public void OnExpand()
    {
        Background.SetWidth(_maxWidth);
        if (!IsSelected) Title.SetColor("#5E5E5E");
        else Title.SetColor(_color);
        Subtitle.SetColor("#5E5E5E");
    }
    public void OnCollape()
    {
        Background.SetWidth(35);
        Title.SetColor(Color.clear);
        Subtitle.SetColor(Color.clear);
    }
    public void OnSelect()
    {
        Background.SetBackgroundColor("#1F1F1F");
        SetSelectStyle();

        IsSelected = true;
    }
    public void OnDeselect()
    {
        SetDeselectStyle();

        IsSelected = false;
    }

    private void SetSelectStyle()
    {
        Icon.SetBackgroundImageTintColor(_color);
        Title.SetColor(_color);
    }
    private void SetDeselectStyle()
    {
        Background.SetBackgroundColor(Color.clear);
        Icon.SetBackgroundImageTintColor("#5E5E5E".ToColor());
        Title.SetColor("#5E5E5E");
    }
}
#endif
