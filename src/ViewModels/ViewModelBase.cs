﻿using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Runtime.CompilerServices;

namespace AppTime.ViewModels
{
    public class ViewModelBase : ObservableObject, IDisposable
    {
        protected bool Set<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        public virtual void Dispose() { }
    }
}