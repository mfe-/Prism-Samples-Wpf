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


