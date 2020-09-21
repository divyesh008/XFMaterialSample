using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Windows.Input;
using Prism.Commands;
using Prism.Navigation;
using Xamarin.Forms;
using XF.Material.Forms.Models;

namespace ChipsDemo.ViewModels
{
    public class ChipsPageViewModel : ViewModelBase
    {
        

        public ChipsPageViewModel(INavigationService navigationPage) : base(navigationPage)
        {
            ObservableCollection<MaterialMenuItem> data = new ObservableCollection<MaterialMenuItem>();
            data.Add(new MaterialMenuItem() { Text = "Mango" });
            data.Add(new MaterialMenuItem() { Text = "Orange" });
            data.Add(new MaterialMenuItem() { Text = "Other" });

            Actions = new ObservableCollection<MaterialMenuItem>(data);
        }

        private static ObservableCollection<MaterialMenuItem> _actions = new ObservableCollection<MaterialMenuItem>();

        private string _selectedValue;
        public string SelectedValue
        {
            get { return _selectedValue; }
            set { SetProperty(ref _selectedValue, value); }
        }

        public ObservableCollection<MaterialMenuItem> Actions
        {
            get { return _actions; }
            set { SetProperty(ref _actions, value); }
        }

        public ICommand ActionCommand => new Command<MaterialMenuResult>((s) => Action(s));

        private void Action(MaterialMenuResult item)
        {
            try
            {
                if (item.Index != -1)
                {
                    SelectedValue = Actions[item.Index].Text;
                    Debug.WriteLine(SelectedValue);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
    }
}
