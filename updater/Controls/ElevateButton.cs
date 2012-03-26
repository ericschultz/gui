﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CoApp.Updater.Controls
{
    /// <summary>
    /// Follow steps 1a or 1b and then 2 to use this custom control in a XAML file.
    ///
    /// Step 1a) Using this custom control in a XAML file that exists in the current project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:CoApp.Updater.Controls"
    ///
    ///
    /// Step 1b) Using this custom control in a XAML file that exists in a different project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:CoApp.Updater.Controls;assembly=CoApp.Updater.Controls"
    ///
    /// You will also need to add a project reference from the project where the XAML file lives
    /// to this project and Rebuild to avoid compilation errors:
    ///
    ///     Right click on the target project in the Solution Explorer and
    ///     "Add Reference"->"Projects"->[Browse to and select this project]
    ///
    ///
    /// Step 2)
    /// Go ahead and use your control in the XAML file.
    ///
    ///     <MyNamespace:ElevateButton/>
    ///
    /// </summary>
    public class ElevateButton : Button
    {
        static ElevateButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ElevateButton), new FrameworkPropertyMetadata(typeof(ElevateButton)));
        }

        public static readonly DependencyProperty UnelevatedCommandProperty =
            DependencyProperty.Register("UnelevatedCommand", typeof (ICommand), typeof (ElevateButton), new PropertyMetadata(default(ICommand)));

        public ICommand UnelevatedCommand
        {
            get { return (ICommand) GetValue(UnelevatedCommandProperty); }
            set { SetValue(UnelevatedCommandProperty, value);

            }
        }

        public static readonly DependencyProperty ElevatedCommandProperty =
            DependencyProperty.Register("ElevatedCommand", typeof (ICommand), typeof (ElevateButton), new PropertyMetadata(default(ICommand)));

        public ICommand ElevatedCommand
        {
            get { return (ICommand) GetValue(ElevatedCommandProperty); }
            set { SetValue(ElevatedCommandProperty, value);
     
            }
        }



        public static readonly DependencyProperty MustElevateProperty =
            DependencyProperty.Register("MustElevate", typeof (bool), typeof (ElevateButton), new PropertyMetadata(default(bool)));

        public bool MustElevate
        {
            get { return (bool) GetValue(MustElevateProperty); }
            set
            {
                SetValue(MustElevateProperty, value);
              
            }

        }

       
    }
}
