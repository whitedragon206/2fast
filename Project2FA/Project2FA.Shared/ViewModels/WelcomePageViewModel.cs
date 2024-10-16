﻿using Prism.Mvvm;
using System;
using Prism.Services.Dialogs;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Regions;
using Project2FA.Views;
using Microsoft.UI.Xaml.Controls;

namespace Project2FA.ViewModels
{
    public class WelcomePageViewModel : BindableBase
    {
        IDialogService _dialogService { get; }
        IRegionManager _regionManager { get; }
        public ICommand NewDatefileCommand { get; }
        public ICommand TutorialCommand { get; }
        public ICommand OpenTutorialCommand { get; }

        public ICommand UseExistDatefileCommand { get; }
        private bool _isTutorialOpen;

        private string _title;

        //private bool _canNavigate;

        public WelcomePageViewModel(IDialogService dialogService, IRegionManager regionManager)
        {
            _dialogService = dialogService;
            _regionManager = regionManager;
            // disable the navigation to other pages
            App.ShellPageInstance.NavigationIsAllowed = false;
            Title = Strings.Resources.WelcomePageTitle;

            NewDatefileCommand = new DelegateCommand(() =>
            {
                _regionManager.RequestNavigate("ContentRegion", nameof(NewDataFilePage));
            });

            UseExistDatefileCommand = new DelegateCommand(() =>
            {
                _regionManager.RequestNavigate("ContentRegion", nameof(UseDataFilePage));
            });

            TutorialCommand = new DelegateCommand(() =>
            {
                IsTutorialOpen = !IsTutorialOpen;
            });
        }

        private async Task NewDatafile()
        {
            //var dialog = new NewDatafileDialog();
            //var result = await _dialogService.ShowDialog(dialog, new DialogParameters());
            //if (result == ContentDialogResult.Primary)
            //{
            //    //_canNavigate = true;
            //    string navPath = "/" + nameof(AccountCodePage);
            //    _regionManager.RequestNavigate("ContentRegion", navPath);
            //}
        }

        public string Title { get => _title; set => SetProperty(ref _title, value); }
        public bool IsTutorialOpen { get => _isTutorialOpen; set => SetProperty(ref _isTutorialOpen, value); }
    }
}
