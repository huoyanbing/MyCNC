﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HANS_CNC.LayerClass
{
    public class TodoView
    {
        ITodoListController Controller;

        public TodoView()
        {
            Controller = new TodoController();
        }

    }
}
