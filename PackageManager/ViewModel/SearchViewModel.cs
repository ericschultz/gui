﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;
using System.Windows.Input;
using CoApp.Gui.Toolkit.Model.Interfaces;
using CoApp.Gui.Toolkit.ViewModels;
using CoApp.PackageManager.Model;
using CoApp.PackageManager.ViewModel.Filter;
using CoApp.Packaging.Client;
using CoApp.Packaging.Common;
using CoApp.Toolkit.Linq;
using GalaSoft.MvvmLight.Command;
using SLE = System.Linq.Expressions;
using CTL = CoApp.Toolkit.Linq;
using CollectionFilter =
    CoApp.Toolkit.Collections.XList
        <
            System.Linq.Expressions.Expression
                <
                    System.Func
                        <System.Collections.Generic.IEnumerable<CoApp.Packaging.Common.IPackage>,
                            System.Collections.Generic.IEnumerable<CoApp.Packaging.Common.IPackage>>>>;
using LocalServiceLocator = CoApp.Gui.Toolkit.Model.LocalServiceLocator;

namespace CoApp.PackageManager.ViewModel
{
    /// <summary>
    /// 
    /// </summary>
    /// <from>http://stackoverflow.com/questions/3468866/tabcontrol-with-add-new-tab-button</from>
    public class SearchViewModel : ScreenViewModel
    {
        //the length of a page
/*
        private const int NUM_TO_PULL = 50;
*/
        internal ICoAppService CoApp;
        internal LocalServiceLocator Loc;
        internal ViewModelLocator Vm;

        private ObservableCollection<FrictionlessFilter> _appliedFilters;


        private FrictionlessSort<IPackage> _frictionlessSort;
        private bool _inMiddleOfSearch;


        private ObservableCollection<ProductInfo> _packages;

        private ObservableCollection<GUIFilterBase> _possibleFilters = new ObservableCollection<GUIFilterBase>
                                                                           {
                                                                               new FilterOnText
                                                                                   {
                                                                                       Category = CAT.DisplayName,
                                                                                       NiceName = "Name",
                                                                                       NumberOfFilter =
                                                                                           NumOfFilter.Multiple
                                                                                   },
                                                                               new FilterOnBoolean
                                                                                   {
                                                                                       Category = CAT.IsDependency,
                                                                                       NiceName = "Is a dependency",
                                                                                       NumberOfFilter =
                                                                                           NumOfFilter.Single
                                                                                   },
                                                                               new FilterOnBoolean
                                                                                   {
                                                                                       Category = CAT.IsBlocked,
                                                                                       NiceName = "Is blocked",
                                                                                       NumberOfFilter =
                                                                                           NumOfFilter.Single
                                                                                   },
                                                                               new FilterOnBoolean
                                                                                   {
                                                                                       Category = CAT.IsInstalled,
                                                                                       NumberOfFilter =
                                                                                           NumOfFilter.Single,
                                                                                       NiceName = "Is installed"
                                                                                   },
                                                                               new FilterOnBoolean
                                                                                   {
                                                                                       Category = CAT.IsWanted,
                                                                                       NumberOfFilter =
                                                                                           NumOfFilter.Single,
                                                                                       NiceName = "Is wanted"
                                                                                   }
                                                                           };

        private ObservableCollection<SortDescriptor> _possibleSorts = new ObservableCollection<SortDescriptor>
                                                                          {
                                                                              new SortDescriptor("Name",
                                                                                                 p => p.DisplayName),
                                                                              new SortDescriptor("Date Published",
                                                                                                 p =>
                                                                                                 p.PackageDetails.
                                                                                                     PublishDate),
                                                                              new SortDescriptor("Canonical Name",
                                                                                                 p => p.CanonicalName),
                                                                              new SortDescriptor("Formal Name",
                                                                                                 p => p.Name)
                                                                          };


        public SearchViewModel()
        {
            ScreenWidth = ScreenWidth.FullWidth;
            Loc = new LocalServiceLocator();

            CoApp = Loc.CoAppService;
            Vm = new ViewModelLocator();

            
            FrictionlessSort = PossibleSorts[0].Create(ListSortDirection.Ascending);

            AddFilter = new RelayCommand<GUIFilterBase>(i =>
                                                            {
                                                                AppliedFilters.Add(i.Create());
                                                                RaisePropertyChanged("FiltersToShow");

                                                                ApplyFilters();
                                                            });
            RemoveFilter = new RelayCommand<FrictionlessFilter>(i =>
                                                                    {
                                                                        AppliedFilters.Remove(i);
                                                                        RaisePropertyChanged("FiltersToShow");
                                                                        ApplyFilters();
                                                                    });

            Sort = new RelayCommand<SortDescriptor>(i =>
                                                        {
                                                            FrictionlessSort = i.Create(ListSortDirection.Ascending);
                                                            ApplyFilters();
                                                        });

            SortDescending = new RelayCommand<SortDescriptor>(i =>
                                                                  {
                                                                      FrictionlessSort =
                                                                          i.Create(ListSortDirection.Descending);
                                                                      ApplyFilters();
                                                                  });

            
            Loaded += OnLoaded;
            GoToProduct =
                new RelayCommand<ProductInfo>(p => Loc.NavigationService.GoTo(Vm.GetProductViewModel(p.CanonicalName)));
        }

        public ICommand GoToProduct { get; set; }

        public bool InMiddleOfSearch
        {
            get { return _inMiddleOfSearch; }
            set
            {
                _inMiddleOfSearch = value;
                RaisePropertyChanged("InMiddleOfSearch");
            }
        }


        public ObservableCollection<GUIFilterBase> PossibleFilters
        {
            get { return _possibleFilters; }
            set
            {
                _possibleFilters = value;
                RaisePropertyChanged("PossibleFilters");
            }
        }

        public ObservableCollection<SortDescriptor> PossibleSorts
        {
            get { return _possibleSorts; }
            set
            {
                _possibleSorts = value;
                RaisePropertyChanged("PossibleSorts");
            }
        }

        public ObservableCollection<FrictionlessFilter> AppliedFilters
        {
            get
            {
                if (_appliedFilters == null)
                {
                    _appliedFilters = new ObservableCollection<FrictionlessFilter>();
                    var itemsView = (IEditableCollectionView) CollectionViewSource.GetDefaultView(_appliedFilters);
                    itemsView.NewItemPlaceholderPosition = NewItemPlaceholderPosition.AtEnd;
                }

                return _appliedFilters;
            }
            set
            {
                _appliedFilters = value;
                RaisePropertyChanged("AppliedFilters");
            }
        }


        public ObservableCollection<GUIFilterBase> FiltersToShow
        {
            get
            {
                return
                    new ObservableCollection<GUIFilterBase>(
                        PossibleFilters.Where(
                            item =>
                            !(item.NumberOfFilter == NumOfFilter.Single &&
                              AppliedFilters.Any(f => f.Category == item.Category))));
            }
        }


        public ObservableCollection<ProductInfo> Packages
        {
            get { return _packages; }
            set
            {
                _packages = value;
                RaisePropertyChanged("Packages");
            }
        }


        public FrictionlessSort<IPackage> FrictionlessSort
        {
            get { return _frictionlessSort; }
            set
            {
                _frictionlessSort = value;
                RaisePropertyChanged("FrictionlessSort");
            }
        }

        public ICommand AddFilter { get; set; }
        public ICommand RemoveFilter { get; set; }
        public ICommand Sort { get; set; }
        public ICommand SortDescending { get; set; }

        private void ApplyFilters()
        {
            //create actual filter
            IEnumerable<IGrouping<CAT, FrictionlessFilter>> groups = AppliedFilters.GroupBy(f => f.Category);
            Filter<IPackage> fullFilter = null;
            foreach (var g in groups)
            {
                Filter<IPackage> groupF = null;
                foreach (FrictionlessFilter filter in g)
                {
                    if (groupF == null)
                        groupF = filter.Filter;
                    else
                        groupF |= filter.Filter;
                }

                if (fullFilter == null)
                    fullFilter = groupF;
                else
                    fullFilter &= groupF;
            }

            //get only highestpackages
            CollectionFilter collectionFilter = null;
            collectionFilter = collectionFilter.Then(p => p.HighestPackages());


            //create sort


            if (FrictionlessSort.Direction == ListSortDirection.Ascending)
            {
                GetPackages(fullFilter, collectionFilter, ListSortDirection.Ascending);
            }
            else
            {
                GetPackages(fullFilter, collectionFilter, ListSortDirection.Descending);
            }
        }

        private void GetPackages(Filter<IPackage> packageFilter, CollectionFilter collectionFilter,
                                 ListSortDirection direction)
        {
            UpdateOnUI(() => InMiddleOfSearch = true);
            CoApp.GetPackages(packageFilter, collectionFilter).ContinueWith(t =>
                                                                                {
/*
                                                                                    var packageTasks = t.Result.Select(
                                                                                        p =>
                                                                                        CoApp.GetPackageDetails(
                                                                                            p.CanonicalName)).ToArray();
                                                                                    Task.WaitAll(packageTasks);*/
                                                                                    IEnumerable<Package> packages =
                                                                                        t.Result;
                                                                                    /*
                                                                                        packageTasks.Select(
                                                                                            t1 => t1.Result);*/

                                                                                    ProductInfo[] ret;
                                                                                    if (direction ==
                                                                                        ListSortDirection.Ascending)
                                                                                    {
                                                                                        ret = packages.OrderBy(
                                                                                            FrictionlessSort.Property.
                                                                                                Compile()).
                                                                                            Select(
                                                                                                ProductInfo.FromIPackage)
                                                                                            .ToArray();
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        ret =
                                                                                            packages.OrderByDescending(
                                                                                                FrictionlessSort.
                                                                                                    Property.Compile()).
                                                                                                Select(
                                                                                                    ProductInfo.
                                                                                                        FromIPackage).
                                                                                                ToArray();
                                                                                    }

                                                                                    var coll = new ObservableCollection
                                                                                        <ProductInfo>(ret);

                                                                                    UpdateOnUI(() =>
                                                                                               Packages = coll);

                                                                                    UpdateOnUI(
                                                                                        () => InMiddleOfSearch = false);
                                                                                });
        }

        private void OnLoaded()
        {
            if (Packages == null)
            {
                ApplyFilters();
            }
        }
    }
}