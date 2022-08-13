using Ejercicio35.Data;
using Ejercicio35.Models;
using Ejercicio35.ViewModels.VMEmpleados;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ejercicio35.Views.Empleados
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistroEmpleados : ContentPage
    {
        MediaFile file;
        DEmpleados datosempleados = new DEmpleados();
        public RegistroEmpleados()
        {
            InitializeComponent();
            //BindingContext = new VMRegistroEmpleados(Navigation);
        }

        private async void Button_ClickedAsync(object sender, EventArgs e)
        {
          
        }

        private async void guardar_Clicked(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            string apellidos = txtApellidos.Text;
            string edad = txtEdad.Text;
            string direccion = txtDireccion.Text;
            string puesto = txtPuesto.Text;
            if (string.IsNullOrEmpty(nombre))
            {
                DisplayAlert("Advertencia", "Por Favor ingrese un nombre", "OK");
            }
            if (string.IsNullOrEmpty(apellidos))
            {
                DisplayAlert("Advertencia", "Por Favor ingrese un apellido", "OK");
            }
            if (string.IsNullOrEmpty(edad))
            {
                DisplayAlert("Advertencia", "Por Favor ingrese una edad", "OK");
            }
            if (string.IsNullOrEmpty(direccion))
            {
                DisplayAlert("Advertencia", "Por Favor ingrese una direccion", "OK");
            }
            if (string.IsNullOrEmpty(puesto))
            {
                DisplayAlert("Advertencia", "Por Favor ingrese un puesto", "OK");
            }

            MEpleados empleado = new MEpleados();
            empleado.Nombre = nombre;
            empleado.Apellidos = apellidos;
            empleado.Edad = edad;
            empleado.Direccion = direccion;
            empleado.Puesto = puesto;

            if (file !=null)
            {
                string image = await datosempleados.Upload(file.GetStream(),Path.GetFileName(file.Path));
                empleado.Foto = image;
            }

            var isSaved = await datosempleados.Save(empleado);
            if (isSaved)
            {
                await DisplayAlert("Informacion", "Datos Guardados correctamente", "OK");
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("Error", "No se guardaron los datos", "OK");
            }

        }

      

        private async void ImageTap_Tapped_1(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();
            try
            {
                file = await CrossMedia.Current.PickPhotoAsync(new PickMediaOptions
                {
                    PhotoSize = PhotoSize.Medium
                }); 

                if(file == null)
                {
                    return;
                }
                ImgEmpleado.Source = ImageSource.FromStream(() =>
                {
                    return file.GetStream();
                });
                

            }
            catch(Exception ex)
            {
               
            }

        }
    }
}