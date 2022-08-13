﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ejercicio35.ViewModels.VMEmpleados;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ejercicio35.Views.Empleados
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaEmpleados : ContentPage
    {
        
        public ListaEmpleados()
        {
            InitializeComponent();
            
            BindingContext =new VMListaEmpleados(Navigation);

        }

       
    }
}