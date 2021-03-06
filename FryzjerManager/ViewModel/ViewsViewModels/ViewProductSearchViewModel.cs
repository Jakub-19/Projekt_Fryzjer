﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Diagnostics;
using FryzjerManager.Model;
using System.Windows.Controls;

namespace FryzjerManager.ViewModel.ViewsViewModels
{
    //VM formularza wyszukiwania produktu
    public class ViewProductSearchViewModel : ViewModelBase.ViewModelBase
    {
        public bool IsSingleUsed { get; set; }
        public bool ShowOnlyAvailable { get; set; } = false;
        private ICommand _searchProduct = null;
        public ICommand SearchProduct
        {
            get
            {
                if (_searchProduct == null)
                    _searchProduct = new ViewModelBase.RelayCommand(
                        arg => {
                            if (IsSingleUsed)
                            {
                                if(ShowOnlyAvailable)
                                {
                                    inventory.GetSingleUseProducts(ProductName);
                                }
                                else
                                {
                                    inventory.GetAllSingleUseProducts(ProductName);
                                }
                            }
                            else
                            {
                                if (ShowOnlyAvailable)
                                {
                                    inventory.GetProducts(ProductName);
                                }
                                else
                                {
                                    inventory.GetAllProducts(ProductName);
                                }
                            }
                            OnPropertyChanged(nameof(Products));
                        },
                        arg => true);
                return _searchProduct;
            }
        }
        public event Action<SingleUseProduct> TransferData;//Przekazuje dane formularzowi-rodzicowi

        private ICommand _selectProduct = null;
        public ICommand SelectProduct
        {
            get
            {
                if (_selectProduct == null)
                    _selectProduct = new ViewModelBase.RelayCommand(
                        arg => {
                            TransferData?.Invoke(CurrentProduct);
                        },
                        arg => CurrentProduct != null);
                return _selectProduct;
            }
        }
        //Magazyn
        private Inventory inventory = new Inventory();

        //Obsługa formularza
        public string ProductName { get; set; }
        public SingleUseProduct CurrentProduct { get; set; }
        public ObservableCollection<SingleUseProduct> Products
        {
            get
            {
                ObservableCollection<SingleUseProduct> list = new ObservableCollection<SingleUseProduct>();
                if (!IsSingleUsed)
                {
                    foreach (var v in inventory.Products)
                        list.Add(v);
                }
                else
                {
                    foreach (var v in inventory.SingleUseProducts)
                        list.Add(v);
                }

                return list;
            }
        }

        //Nawigacja
        public event Action GoHomeAction;
        private ICommand _gotoMainMenu = null;
        public ICommand GotoMainMenu
        {
            get
            {
                if (_gotoMainMenu == null)
                    _gotoMainMenu = new ViewModelBase.RelayCommand(
                        arg => { GoHomeAction?.Invoke(); },
                        arg => true);
                return _gotoMainMenu;
            }
        }

        public event Action GoBackAction;
        private ICommand _goBack = null;
        public ICommand GoBack
        {
            get
            {
                if (_goBack == null)
                    _goBack = new ViewModelBase.RelayCommand(
                        arg => {
                            GoBackAction?.Invoke();
                        }, arg => true);
                return _goBack;
            }
        }

        public void Clear()
        {
            inventory.Clear();
            ProductName = "";
            CurrentProduct = null;
            OnPropertyChanged(nameof(ProductName));
            OnPropertyChanged(nameof(Products));
        }
    }
}
