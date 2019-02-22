using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Disposables;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using OrderManagement.Domain;
using ReactiveUI;

namespace OrderManagementUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ReactiveWindow<AppViewModel>
    {
        public MainWindow()
        {
            InitializeComponent();
            ViewModel = new AppViewModel();
            this.WhenActivated(disposableRegistration =>
            {
                // Notice we don't have to provide a converter, on WPF a global converter is
                // registered which knows how to convert a boolean into visibility.
                this.Bind(ViewModel,
                        viewModel => viewModel.Action,
                        view => view.action.Text)
                    .DisposeWith(disposableRegistration);

                this.Bind(ViewModel,
                        viewModel => viewModel.Quantity,
                        view => view.quantity.Text)
                    .DisposeWith(disposableRegistration);

                this.Bind(ViewModel,
                        viewModel => viewModel.Asset,
                        view => view.asset.Text)
                    .DisposeWith(disposableRegistration);

                this.Bind(ViewModel,
                        viewModel => viewModel.Price,
                        view => view.price.Text)
                    .DisposeWith(disposableRegistration);

                this.OneWayBind(ViewModel,
                        viewModel => viewModel.OrderList,
                        view => view.orderList.ItemsSource)
                    .DisposeWith(disposableRegistration);
            });
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var app = new ApplicationService();
            app.Bootstrap();
            app.repo.Save(new OrderAggregate(Guid.NewGuid(), ViewModel.Action, ViewModel.Quantity, ViewModel.Asset, ViewModel.Price));
            ViewModel.OrderList = app._readModel.Orders;
        }
    }
}
