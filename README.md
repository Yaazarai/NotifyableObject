# NotifyableObject
Implements INotifyPropertyChanged for View Models with MVVM.

I was getting bothered by the fact that everytime I wanted INotify for a control in WPF I had to re-implement it.. which is the epitome of ridiculousness. Why should I have to rewrite the INotify interface for everything? Or track it down and copy-paste? Inherit the class and pass your viewmodel to your control as it's DataContext either in the control's XAML or in the backend code and voila. You cannot inherit from multiple classes, so the easiest way to provide a portable INotify interface is via MVVM. I've added a Dispatcher for updating on the UI thread as an added bonus.

I've dropped it under the same namespace as INotify for simplicity.
```C#
using System.ComponentModel;
```

### How to properly implement NotifyableObject

For proeprties to properly update on the UI thread in WPF you need to implement an INotifyProperty interface, which is generally easy enough. Add the interface to your userControl or Window in your class declaration and start implementing the OnPropertyChanged event. However maybe we want to use MVVM and separate out the property handling as a view model, which makes life extremely easy.

Create a new ViewModel class (say for your MainWindow.xaml, call it MainWindowViewModel) and add in the ComponentModel namespace, then inherit the NotifyableObject:
```C#
using System.ComponentModel;
namespace MyApplication {
    public class MainWindowViewModel : NotifyableObject {}
}
```
The notifyable object class uses CompilerServices to get `CallerMemberName` so that when you call `OnPropertychanged` you won't have to manually type out the property name strin, fancy:
```C#
using System.ComponentModel;
namespace MyApplication {
    public class MainWindowViewModel : NotifyableObject {
        private bool someProperty = false;
        public bool SomeProperty {
            get => someProperty;
            set {
                if (someProperty != value) {
                    someProeprty = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}
```
Voila a properly implemented property on the INotifyProperty interface. The final step is to go into your UserControl or Window that's hosting this ViewModel and apply the ViewModel to that control's data context--this overrides the control's DataContext from itself to the ViewModel for WPF/XAML to recognize the new ViewModel.
```C#
...
namespace MyApplication {
    private readonly MainWindowViewModel viewModel;
    
    public class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            
            viewModel = new MainWindowViewModel();
            DataContext = viewModel;
        }
    }
}
``
