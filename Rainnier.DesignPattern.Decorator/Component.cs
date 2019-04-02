﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rainnier.DesignPattern.Decorator
{
    public abstract class Component : IComponent
    {
        public abstract void Display();
    }
}
