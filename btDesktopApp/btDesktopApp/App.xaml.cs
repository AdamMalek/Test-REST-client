using Autofac;
using btDesktopApp.Repository;
using btDesktopApp.Services;
using btDesktopApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace btDesktopApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IContainer Container { get; set; }
        public App()
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterType<DataService>().As<Services.IDataService>();
            builder.RegisterType<JsonProvider>().As<Repository.IDataProvider>();
            builder.RegisterType<SerializeService>().As<ISerializer>();
            builder.RegisterType<MainWindow>();
            builder.RegisterType<MainWindowVM>();
            Container = builder.Build();
            var view = Container.Resolve<MainWindow>();
            view.Show();            
        }
    }
}
