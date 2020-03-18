﻿using SquidexDataLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CMSDataLayer
{
    public interface ICMSDataHelper
    {
        Task<LedColorsSeq> GetLedColors();
        void ConnectToCMS(AppOptions appOptions);
    }
}