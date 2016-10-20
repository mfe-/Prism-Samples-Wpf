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