using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Serialization;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace H09T06
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        List<Employee> employees;
        public MainPage()
        {
            this.InitializeComponent();
            employees = new List<Employee>();
            pathTextBlock.Text = "Path to file: " + ApplicationData.Current.LocalFolder.Path;
        }
        private void GenerateEmployees(object o, RoutedEventArgs e)
        {
            employees.Add(new Employee { Firstname = "Joseph", Lastname = "Howard" });
            employees.Add(new Employee { Firstname = "Helen", Lastname = "Schmidt" });
            employees.Add(new Employee { Firstname = "Sean", Lastname = "White" });
            EmployeesTextBlock.Text = "Employees generated.";
        }
        private async void SaveEmployees(object o, RoutedEventArgs e)
        {
            try
            {
                // open/create a file
                StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
                StorageFile employeesFile = await storageFolder.CreateFileAsync("employees.dat", CreationCollisionOption.OpenIfExists);

                // Tallennetaan muodossa:
                // <ArrayOfEmployee xmlns="http://schemas.datacontract.org/2004/07/H09T06" xmlns:i="http://www.w3.org/2001/XMLSchema-instance"><Employee><Firstname>Joseph</Firstname><Lastname>Howard</Lastname></Employee><Employee><Firstname>Helen</Firstname><Lastname>Schmidt</Lastname></Employee><Employee><Firstname>Sean</Firstname><Lastname>White</Lastname></Employee><Employee><Firstname>Joseph</Firstname><Lastname>Howard</Lastname></Employee><Employee><Firstname>Helen</Firstname><Lastname>Schmidt</Lastname></Employee><Employee><Firstname>Sean</Firstname><Lastname>White</Lastname></Employee></ArrayOfEmployee>
                // ..

                // save employees to disk
                Stream stream = await employeesFile.OpenStreamForWriteAsync();
                DataContractSerializer serializer = new DataContractSerializer(typeof(List<Employee>));
                serializer.WriteObject(stream, employees);
                await stream.FlushAsync();
                stream.Dispose();
                EmployeesTextBlock.Text = "Employees saved.";
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Following exception has happend (writing): " + ex.ToString());
            }
        }
        private async void ReadEmployees(object o, RoutedEventArgs e)
        {
            try
            {
                // find a file
                StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
                Stream stream = await storageFolder.OpenStreamForReadAsync("employees.dat");

                // is it empty
                if (stream == null) employees = new List<Employee>();

                // read data
                DataContractSerializer serializer = new DataContractSerializer(typeof(List<Employee>));
                employees = (List<Employee>)serializer.ReadObject(stream);
                ShowEmployees();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Following exception has happend (reading): " + ex.ToString());
            }
        }
        private void ShowEmployees()
        {
            EmployeesTextBlock.Text = "Employees:" + Environment.NewLine;
            foreach (Employee employee in employees)
            {
                EmployeesTextBlock.Text += employee.Firstname + " " + employee.Lastname + Environment.NewLine;
            }
        }
    }
}
