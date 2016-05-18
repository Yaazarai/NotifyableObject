# NotifyableViewModel
Implements INotifyPropertyChanged for View Models with MVVM.

I was getting bothered by the fact that everytime I wanted INotify for a control in WPF I had to re-implement it.. which is the epitome of ridiculousness. Why should I have to rewrite the INotify interface for everything? Or track it down and copy-paste? Inherit the class and pass your viewmodel to your control as it's DataContext either in WPF or in the backend code and voila. You cannot inherit from multiple classes, so the easiest way to provide a portable INotify interface is via MVVM. I've added a Dispatcher for updating on the UI thread as an added bonus.

I've dropped it under the same namespace as INotify for simplicity.
```C#
using System.ComponentModel;
```
