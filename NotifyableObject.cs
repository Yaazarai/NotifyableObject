using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Threading;

namespace System.ComponentModel {
    /// <summary>Implementation of the INotifyProperty Changed / Changing interfaces.</summary>
    public abstract class NotifyableObject : DispatcherObject, INotifyPropertyChanged, INotifyPropertyChanging {
        #region Event Handling
        /// <summary>Event that is called when a property has changed.</summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>Event that is called when a property is changing.</summary>
        public event PropertyChangingEventHandler PropertyChanging;
        #endregion

        #region INotify Implementation
        /// <summary>Calls the PropertyChanged event.</summary>
        /// <param name="property">Name of the property that changed.</param>
        protected void OnPropertyChanged([CallerMemberName] string property = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));

        /// <summary>Calls the PropertyChanging event.</summary>
        /// <param name="property">Name of the property that is changing.</param>
        protected void OnPropertyChanging([CallerMemberName] string property = null) =>
            PropertyChanging?.Invoke(this, new PropertyChangingEventArgs(property));
        #endregion
    }
}
