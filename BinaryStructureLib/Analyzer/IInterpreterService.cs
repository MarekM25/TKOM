﻿using BinaryStructureLib.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryStructureLib.Analyzer
{
    public interface IInterpreterService
    {
        int ReadValue(int size);
    }
}
