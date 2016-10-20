First commit init

agenda / commits 

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

Commands
1.) Add in VM DelegateCommand Property and init in constructor
2.) OnExecute CallBack make MessageBox.Show()
3.) Add Button to View with proper Command Binding
4.) Check that you added System.Windows.Interactivity ( Add References -> Extensions )
5.) Add Dockpanel
6.) <i:Interaction.Triggers>
            <i:EventTrigger EventName="MouseEnter">
                <i:InvokeCommandAction Command="{Binding Path=MessageCommand}" />
            </i:EventTrigger>
        </i:Interaction.Triggers>

Interactions
1.) Add a new wpf project named Prism-Concepts-UserControl
2.) add prism nuget packages
3.) Add Export Attribute
4.) Add xmlns namespace to view: set Background red
5.) Go to Bootstrapper and create new assemblycatalog for new project
6.) Create a InteractionRequest Property   MessageControlInteraction = new InteractionRequest<IConfirmation>(); in MainViewModel
7.) create Raise and InteractionConformation Callback; Call in MessageButtonCommand Raise function
8.) create UserControl CustomerControl and viewmodel which derived from Bindablebase and implements IInteractionRequestAware 
9.) Add Button with Command which calls FinishInteraction on CustomerUserControl
10.) Add to MainWindow View  <i:Interaction.Triggers>
                <prism:InteractionRequestTrigger SourceObject="{Binding MessageControlInteraction,Mode=OneWay}">
                    <prism:PopupWindowAction>
                        <prism:PopupWindowAction.WindowContent>
                            <uc:CustomerControl />
                        </prism:PopupWindowAction.WindowContent>
                    </prism:PopupWindowAction>
                </prism:InteractionRequestTrigger>
            </i:Interaction.Triggers>

Regions & Navigation
1.) Create infrastructure project
2.) Add necessary files

