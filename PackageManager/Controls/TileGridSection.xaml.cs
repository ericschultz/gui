﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CoApp.PackageManager.Controls
{
    /// <summary>
    /// Interaction logic for TileGridSection.xaml
    /// </summary>
    public partial class TileGridSection : UserControl
    {
        public TileGridSection()
        {
            this.InitializeComponent();
            
            
        }

        public static readonly DependencyProperty SectionTitleProperty =
            DependencyProperty.Register("SectionTitle", typeof (string), typeof (TileGridSection), new PropertyMetadata(default(string)));

        public string SectionTitle
        {
            get { return (string) GetValue(SectionTitleProperty); }
            set { SetValue(SectionTitleProperty, value); }
        }

        public static readonly DependencyProperty SectionTitleCommandProperty =
            DependencyProperty.Register("SectionTitleCommand", typeof (ICommand), typeof (TileGridSection), new PropertyMetadata(default(ICommand)));

        public ICommand SectionTitleCommand
        {
            get { return (ICommand) GetValue(SectionTitleCommandProperty); }
            set { SetValue(SectionTitleCommandProperty, value); }
        }

        /// <summary>
        /// this changes the display based on the number of Items
        /// </summary>
        public static readonly DependencyProperty NumberOfItemsProperty =
            DependencyProperty.Register("NumberOfItems", typeof (int), typeof (TileGridSection), new PropertyMetadata(default(int)));

        public int NumberOfItems
        {
            get { return (int) GetValue(NumberOfItemsProperty); }
            set { SetValue(NumberOfItemsProperty, value); }
        }


        #region TopLeft
        

        public static readonly DependencyProperty TopLeftBrushProperty =
            DependencyProperty.Register("TopLeftBrush", typeof (Brush), typeof (TileGridSection), new PropertyMetadata(default(Brush)));

        public Brush TopLeftBrush
        {
            get { return (Brush) GetValue(TopLeftBrushProperty); }
            set { SetValue(TopLeftBrushProperty, value); }
        }

        public static readonly DependencyProperty TopLeftClickCommandProperty =
            DependencyProperty.Register("TopLeftClickCommand", typeof (ICommand), typeof (TileGridSection), new PropertyMetadata(default(ICommand)));

        public ICommand TopLeftClickCommand
        {
            get { return (ICommand) GetValue(TopLeftClickCommandProperty); }
            set { SetValue(TopLeftClickCommandProperty, value); }
        }

        public static readonly DependencyProperty TopLeftClickCommandParameterProperty =
            DependencyProperty.Register("TopLeftClickCommandParameter", typeof (object), typeof (TileGridSection), new PropertyMetadata(default(object)));

        public object TopLeftClickCommandParameter
        {
            get { return (object) GetValue(TopLeftClickCommandParameterProperty); }
            set { SetValue(TopLeftClickCommandParameterProperty, value); }
        }

        public static readonly DependencyProperty TopLeftIconProperty =
            DependencyProperty.Register("TopLeftIcon", typeof (ImageSource), typeof (TileGridSection), new PropertyMetadata(default(ImageSource)));

        public ImageSource TopLeftIcon
        {
            get { return (ImageSource) GetValue(TopLeftIconProperty); }
            set { SetValue(TopLeftIconProperty, value); }
        }

        public static readonly DependencyProperty TopLeftForegroundProperty =
            DependencyProperty.Register("TopLeftForeground", typeof (Brush), typeof (TileGridSection), new PropertyMetadata(default(Brush)));

        public Brush TopLeftForeground
        {
            get { return (Brush) GetValue(TopLeftForegroundProperty); }
            set { SetValue(TopLeftForegroundProperty, value); }
        }

        public static readonly DependencyProperty TopLeftTitleProperty =
            DependencyProperty.Register("TopLeftTitle", typeof (string), typeof (TileGridSection), new PropertyMetadata(default(string)));

        public string TopLeftTitle
        {
            get { return (string) GetValue(TopLeftTitleProperty); }
            set { SetValue(TopLeftTitleProperty, value); }
        }

        public static readonly DependencyProperty TopLeftSummaryProperty =
            DependencyProperty.Register("TopLeftSummary", typeof (string), typeof (TileGridSection), new PropertyMetadata(default(string)));

        public string TopLeftSummary
        {
            get { return (string) GetValue(TopLeftSummaryProperty); }
            set { SetValue(TopLeftSummaryProperty, value); }
        }

        public static readonly DependencyProperty TopLeftRatingProperty =
            DependencyProperty.Register("TopLeftRating", typeof (double?), typeof (TileGridSection), new PropertyMetadata(default(double?)));

        public double? TopLeftRating
        {
            get { return (double?) GetValue(TopLeftRatingProperty); }
            set { SetValue(TopLeftRatingProperty, value); }
        }

        #endregion


        #region BottomLeft

        public static readonly DependencyProperty BottomLeftBrushProperty =
            DependencyProperty.Register("BottomLeftBrush", typeof (Brush), typeof (TileGridSection), new PropertyMetadata(default(Brush)));

        public Brush BottomLeftBrush
        {
            get { return (Brush) GetValue(BottomLeftBrushProperty); }
            set { SetValue(BottomLeftBrushProperty, value); }
        }

        public static readonly DependencyProperty BottomLeftClickCommandProperty =
            DependencyProperty.Register("BottomLeftClickCommand", typeof (ICommand), typeof (TileGridSection), new PropertyMetadata(default(ICommand)));

        public ICommand BottomLeftClickCommand
        {
            get { return (ICommand) GetValue(BottomLeftClickCommandProperty); }
            set { SetValue(BottomLeftClickCommandProperty, value); }
        }

        public static readonly DependencyProperty BottomLeftClickCommandParameterProperty =
            DependencyProperty.Register("BottomLeftClickCommandParameter", typeof (object), typeof (TileGridSection), new PropertyMetadata(default(object)));

        public object BottomLeftClickCommandParameter
        {
            get { return (object) GetValue(BottomLeftClickCommandParameterProperty); }
            set { SetValue(BottomLeftClickCommandParameterProperty, value); }
        }

        public static readonly DependencyProperty BottomLeftIconProperty =
            DependencyProperty.Register("BottomLeftIcon", typeof (ImageSource), typeof (TileGridSection), new PropertyMetadata(default(ImageSource)));

        public ImageSource BottomLeftIcon
        {
            get { return (ImageSource) GetValue(BottomLeftIconProperty); }
            set { SetValue(BottomLeftIconProperty, value); }
        }

        public static readonly DependencyProperty BottomLeftForegroundProperty =
            DependencyProperty.Register("BottomLeftForeground", typeof (Brush), typeof (TileGridSection), new PropertyMetadata(default(Brush)));

        public Brush BottomLeftForeground
        {
            get { return (Brush) GetValue(BottomLeftForegroundProperty); }
            set { SetValue(BottomLeftForegroundProperty, value); }
        }

        public static readonly DependencyProperty BottomLeftTitleProperty =
            DependencyProperty.Register("BottomLeftTitle", typeof (string), typeof (TileGridSection), new PropertyMetadata(default(string)));

        public string BottomLeftTitle
        {
            get { return (string) GetValue(BottomLeftTitleProperty); }
            set { SetValue(BottomLeftTitleProperty, value); }
        }

        public static readonly DependencyProperty BottomLeftSummaryProperty =
            DependencyProperty.Register("BottomLeftSummary", typeof (string), typeof (TileGridSection), new PropertyMetadata(default(string)));

        public string BottomLeftSummary
        {
            get { return (string) GetValue(BottomLeftSummaryProperty); }
            set { SetValue(BottomLeftSummaryProperty, value); }
        }

        public static readonly DependencyProperty BottomLeftRatingProperty =
            DependencyProperty.Register("BottomLeftRating", typeof (double?), typeof (TileGridSection), new PropertyMetadata(default(double?)));

        public double? BottomLeftRating
        {
            get { return (double?) GetValue(BottomLeftRatingProperty); }
            set { SetValue(BottomLeftRatingProperty, value); }
        }

        #endregion

        #region BottomCenter

        public static readonly DependencyProperty BottomCenterBrushProperty =
            DependencyProperty.Register("BottomCenterBrush", typeof (Brush), typeof (TileGridSection), new PropertyMetadata(default(Brush)));

        public Brush BottomCenterBrush
        {
            get { return (Brush) GetValue(BottomCenterBrushProperty); }
            set { SetValue(BottomCenterBrushProperty, value); }
        }

        public static readonly DependencyProperty BottomCenterClickCommandProperty =
            DependencyProperty.Register("BottomCenterClickCommand", typeof (ICommand), typeof (TileGridSection), new PropertyMetadata(default(ICommand)));

        public ICommand BottomCenterClickCommand
        {
            get { return (ICommand) GetValue(BottomCenterClickCommandProperty); }
            set { SetValue(BottomCenterClickCommandProperty, value); }
        }

        public static readonly DependencyProperty BottomCenterClickCommandParameterProperty =
            DependencyProperty.Register("BottomCenterClickCommandParameter", typeof (object), typeof (TileGridSection), new PropertyMetadata(default(object)));

        public object BottomCenterClickCommandParameter
        {
            get { return (object) GetValue(BottomCenterClickCommandParameterProperty); }
            set { SetValue(BottomCenterClickCommandParameterProperty, value); }
        }

        public static readonly DependencyProperty BottomCenterIconProperty =
            DependencyProperty.Register("BottomCenterIcon", typeof (ImageSource), typeof (TileGridSection), new PropertyMetadata(default(ImageSource)));

        public ImageSource BottomCenterIcon
        {
            get { return (ImageSource) GetValue(BottomCenterIconProperty); }
            set { SetValue(BottomCenterIconProperty, value); }
        }

        public static readonly DependencyProperty BottomCenterForegroundProperty =
            DependencyProperty.Register("BottomCenterForeground", typeof (Brush), typeof (TileGridSection), new PropertyMetadata(default(Brush)));

        public Brush BottomCenterForeground
        {
            get { return (Brush) GetValue(BottomCenterForegroundProperty); }
            set { SetValue(BottomCenterForegroundProperty, value); }
        }

        public static readonly DependencyProperty BottomCenterTitleProperty =
            DependencyProperty.Register("BottomCenterTitle", typeof (string), typeof (TileGridSection), new PropertyMetadata(default(string)));

        public string BottomCenterTitle
        {
            get { return (string) GetValue(BottomCenterTitleProperty); }
            set { SetValue(BottomCenterTitleProperty, value); }
        }

        public static readonly DependencyProperty BottomCenterSummaryProperty =
            DependencyProperty.Register("BottomCenterSummary", typeof (string), typeof (TileGridSection), new PropertyMetadata(default(string)));

        public string BottomCenterSummary
        {
            get { return (string) GetValue(BottomCenterSummaryProperty); }
            set { SetValue(BottomCenterSummaryProperty, value); }
        }

        public static readonly DependencyProperty BottomCenterRatingProperty =
            DependencyProperty.Register("BottomCenterRating", typeof (double?), typeof (TileGridSection), new PropertyMetadata(default(double?)));

        public double? BottomCenterRating
        {
            get { return (double?) GetValue(BottomCenterRatingProperty); }
            set { SetValue(BottomCenterRatingProperty, value); }
        }
        #endregion

        #region BottomRight

        public static readonly DependencyProperty BottomRightBrushProperty =
            DependencyProperty.Register("BottomRightBrush", typeof (Brush), typeof (TileGridSection), new PropertyMetadata(default(Brush)));

        public Brush BottomRightBrush
        {
            get { return (Brush) GetValue(BottomRightBrushProperty); }
            set { SetValue(BottomRightBrushProperty, value); }
        }

        public static readonly DependencyProperty BottomRightClickCommandProperty =
            DependencyProperty.Register("BottomRightClickCommand", typeof (ICommand), typeof (TileGridSection), new PropertyMetadata(default(ICommand)));

        public ICommand BottomRightClickCommand
        {
            get { return (ICommand) GetValue(BottomRightClickCommandProperty); }
            set { SetValue(BottomRightClickCommandProperty, value); }
        }

        public static readonly DependencyProperty BottomRightClickCommandParameterProperty =
            DependencyProperty.Register("BottomRightClickCommandParameter", typeof (object), typeof (TileGridSection), new PropertyMetadata(default(object)));

        public object BottomRightClickCommandParameter
        {
            get { return (object) GetValue(BottomRightClickCommandParameterProperty); }
            set { SetValue(BottomRightClickCommandParameterProperty, value); }
        }

        public static readonly DependencyProperty BottomRightIconProperty =
            DependencyProperty.Register("BottomRightIcon", typeof (ImageSource), typeof (TileGridSection), new PropertyMetadata(default(ImageSource)));

        public ImageSource BottomRightIcon
        {
            get { return (ImageSource) GetValue(BottomRightIconProperty); }
            set { SetValue(BottomRightIconProperty, value); }
        }


        public static readonly DependencyProperty BottomRightForegroundProperty =
            DependencyProperty.Register("BottomRightForeground", typeof (Brush), typeof (TileGridSection), new PropertyMetadata(default(Brush)));

        public Brush BottomRightForeground
        {
            get { return (Brush) GetValue(BottomRightForegroundProperty); }
            set { SetValue(BottomRightForegroundProperty, value); }
        }

        public static readonly DependencyProperty BottomRightTitleProperty =
            DependencyProperty.Register("BottomRightTitle", typeof (string), typeof (TileGridSection), new PropertyMetadata(default(string)));

        public string BottomRightTitle
        {
            get { return (string) GetValue(BottomRightTitleProperty); }
            set { SetValue(BottomRightTitleProperty, value); }
        }

        public static readonly DependencyProperty BottomRightSummaryProperty =
            DependencyProperty.Register("BottomRightSummary", typeof (string), typeof (TileGridSection), new PropertyMetadata(default(string)));

        public string BottomRightSummary
        {
            get { return (string) GetValue(BottomRightSummaryProperty); }
            set { SetValue(BottomRightSummaryProperty, value); }
        }

        public static readonly DependencyProperty BottomRightRatingProperty =
            DependencyProperty.Register("BottomRightRating", typeof (double?), typeof (TileGridSection), new PropertyMetadata(default(double?)));

        public double? BottomRightRating
        {
            get { return (double?) GetValue(BottomRightRatingProperty); }
            set { SetValue(BottomRightRatingProperty, value); }
        }




        #endregion

        
        #region TopRight

        public static readonly DependencyProperty TopRightBrushProperty =
            DependencyProperty.Register("TopRightBrush", typeof (Brush), typeof (TileGridSection), new PropertyMetadata(default(Brush)));

        public Brush TopRightBrush
        {
            get { return (Brush) GetValue(TopRightBrushProperty); }
            set { SetValue(TopRightBrushProperty, value); }
        }

        public static readonly DependencyProperty TopRightClickCommandProperty =
            DependencyProperty.Register("TopRightClickCommand", typeof (ICommand), typeof (TileGridSection), new PropertyMetadata(default(ICommand)));

        public ICommand TopRightClickCommand
        {
            get { return (ICommand) GetValue(TopRightClickCommandProperty); }
            set { SetValue(TopRightClickCommandProperty, value); }
        }

        public static readonly DependencyProperty TopRightClickCommandParameterProperty =
            DependencyProperty.Register("TopRightClickCommandParameter", typeof (object), typeof (TileGridSection), new PropertyMetadata(default(object)));

        public object TopRightClickCommandParameter
        {
            get { return (object) GetValue(TopRightClickCommandParameterProperty); }
            set { SetValue(TopRightClickCommandParameterProperty, value); }
        }

        public static readonly DependencyProperty TopRightTitleProperty =
            DependencyProperty.Register("TopRightTitle", typeof (string), typeof (TileGridSection), new PropertyMetadata(default(string)));

        public string TopRightTitle
        {
            get { return (string) GetValue(TopRightTitleProperty); }
            set { SetValue(TopRightTitleProperty, value); }
        }

        public static readonly DependencyProperty TopRightForegroundProperty =
            DependencyProperty.Register("TopRightForeground", typeof (Brush), typeof (TileGridSection), new PropertyMetadata(default(Brush)));

        public Brush TopRightForeground
        {
            get { return (Brush) GetValue(TopRightForegroundProperty); }
            set { SetValue(TopRightForegroundProperty, value); }
        }




        #endregion





      
    }

    
}