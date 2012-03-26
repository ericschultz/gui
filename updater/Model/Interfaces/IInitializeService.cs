﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoApp.Updater.Model.Interfaces
{
    public interface IInitializeService
    {
        bool Initialized { get; }
        void RunInitializationAction();
        void SetInitializeAction(Action action);
    }
}
