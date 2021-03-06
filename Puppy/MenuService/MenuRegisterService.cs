﻿#region usings

using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using PuppyFramework.Helpers;
using PuppyFramework.Interfaces;
using PuppyFramework.Services;

#endregion

namespace PuppyFramework.MenuService
{
    public class MenuRegisterService : IMenuRegisterService
    {
        #region Fields

        private readonly IComparer<MenuItemBase> _menuItemComparer;
#pragma warning disable 649
        [Import(AllowRecomposition = true)] private Lazy<IShell> _shell;
#pragma warning restore 649

        #endregion

        #region Properties

        public ObservableSortedList<MenuItemBase> MenuItems { get; private set; }

        #endregion

        #region Constructors

        public MenuRegisterService(IComparer<MenuItemBase> menuItemComparer)
        {
            _menuItemComparer = menuItemComparer;
            MenuItems = new ObservableSortedList<MenuItemBase>(4, _menuItemComparer);
        }

        #endregion

        #region Methods

        public bool Register(MenuItemBase menuItemToRegister, MenuItem attachToMenuItem, bool addToTopLevel = true)
        {
            menuItemToRegister.EnsureParameterNotNull("menuItemToRegister");
            attachToMenuItem.EnsureParameterNotNull("attachToMenuItem");
            attachToMenuItem.AddChild(menuItemToRegister, _menuItemComparer);
            HideHalfOrphanSeparators(attachToMenuItem);
            Register(attachToMenuItem, addToTopLevel);
            AddKeyBindingIfAny(menuItemToRegister);
            return true;
        }

        public bool Register(IEnumerable<MenuItemBase> menuItemsToRegister, MenuItem attachToMenuItem, bool addToTopLevel = true)
        {
            menuItemsToRegister.EnsureParameterNotNull("menuItemsToRegister");
            attachToMenuItem.EnsureParameterNotNull("attachToMenuItem");
            foreach (var menuItemToRegister in menuItemsToRegister)
            {
                attachToMenuItem.AddChild(menuItemToRegister, _menuItemComparer);
                AddKeyBindingIfAny(menuItemToRegister);
            }

            HideHalfOrphanSeparators(attachToMenuItem);
            Register(attachToMenuItem, addToTopLevel);
            return true;
        }

        public bool Register(MenuItemBase menuItemToRegister, bool addToTopLevel = true)
        {
            menuItemToRegister.EnsureParameterNotNull("menuItemToRegister");
            if (!addToTopLevel || MenuItems.Contains(menuItemToRegister)) return false;
            MenuItems.Add(menuItemToRegister);
            return true;
        }

        private void AddKeyBindingIfAny(MenuItemBase menuItemToRegister)
        {
            var menuItem = menuItemToRegister as MenuItem;
            if (_shell == null || menuItem == null || menuItem.CommandBinding == null) return;
            _shell.Value.AddCommandBinding(menuItem.CommandBinding);
        }

        public bool Deregister(MenuItemBase menuItemToDeregister, MenuItem detachFrommenuItem)
        {
            menuItemToDeregister.EnsureParameterNotNull("menuItemToDeregister");
            detachFrommenuItem.EnsureParameterNotNull("detachFrommenuItem");
            return detachFrommenuItem.Children.Remove(menuItemToDeregister);
        }

        private static void HideHalfOrphanSeparators(MenuItem parentMenuItem)
        {
            parentMenuItem.EnsureParameterNotNull("parentMenuItem");
            var separators = parentMenuItem.Children.OfType<SeparatorMenuItem>().ToList();
            // turn on the visibility and afterwards selectively turn it off
            separators.ForEach(sep => sep.IsHidden = true);

            // hide top separator
            var menuItem = separators.FirstOrDefault();
            if (menuItem == null)
                return;
            menuItem.IsHidden = false;

            // hide bottom separator
            menuItem = separators.LastOrDefault();
            if (menuItem == null)
                return;
            menuItem.IsHidden = false;
        }

        #endregion
    }
}