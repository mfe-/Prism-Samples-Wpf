First commit init

1.)	Project Setup (Bootstrapper und DI mit MEF)
2.)	View und ViewModel erstellen
3.)	DataContext setzen mit ViewModelLocator
4.)	Commands
5.)	Interaction (“Popup Window”)
6.)	Regions & Navigation
7.)	EventAggregator (Kommunikation unter ViewModels)

Setup Prism
1.) Install Prism.WPF, Prism.MEF NugetPackage
2.) Create new Bootstrapper derived MefBootstrapper
3.) App.xaml öffnen StartupUri="MainWindow.xaml" löschen
4.) Override OnStartup and initalize MyBootstrapper class and call Run();
5.) Compile & Run -> nothing happens
6.) Override in Bootstrapper CreateShell() which returns MainWindow, Override InitailizeShell which calls Show() of Shell.

Setup MEF and ViewModel
1.) Create ViewModel for MainWindow derived from BindableBase
2.) Name Convention $"{UserControl}ViewModel"
3.) Import namespace and add AP prism:ViewModelLocator.AutoWireViewModel="True" to autowire ViewModels
4.) Compile and Run -> Exception -> {"Activation error occurred while trying to get instance of type MainWindowViewModel, key \"\""} -> ViewModelLocator can't find with ServiceLocator instance of ViewModel Typ MainWindowViewModel
5.) Add System.ComponentModel.Composition for MEF
6.) Override ConfigureAggregateCatalog() and Add this.AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(MainWindow).Assembly));
7.) Add Export attribute to ViewModel
8.) Compile and Run


Setup a "Service" class with MEF
1.) Create a interface for the Service like IWebService {         String Name { get; set; } }
2.) Add Export attribute
3.) Create a class which implements IWebService
4.) Add using to Bootstrapper using System.ComponentModel.Composition; so that you can use MEF Extensions
5.) Override ConfigureContainer and export Service by this.Container.ComposeExportedValue<IWebService>(new WebService());
6.) Go to MainViewModel and add your IWebSerivce Interface to the constructor and save it to a member in the vm
7.) Add        [ImportingConstructor] to Constructor of vm
8.) Add if you want an additonal dependency to your vm constructor like prism.logging.Iloggerface
9.) Compile and Run