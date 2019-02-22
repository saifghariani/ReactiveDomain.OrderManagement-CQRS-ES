using OrderManagement.Domain;
using ReactiveUI;
using System;
using System.Collections.Generic;

namespace OrderManagementUI
{
    public class AppViewModel : ReactiveObject
    {
        private string _action;
        public string Action {
            get => _action;
            set => this.RaiseAndSetIfChanged(ref _action, value);
        }
        private int _quantity;
        public int Quantity {
            get => _quantity;
            set => this.RaiseAndSetIfChanged(ref _quantity, value);
        }
        private string _asset;
        public string Asset {
            get => _asset;
            set => this.RaiseAndSetIfChanged(ref _asset, value);
        }
        private float _price;
        public float Price {
            get => _price;
            set => this.RaiseAndSetIfChanged(ref _price, value);
        }


        private readonly ObservableAsPropertyHelper<IEnumerable<Order>> _orderList;
        public IEnumerable<Order> OrderList { get; set; }
    

        public AppViewModel()
        {
            var app = new ApplicationService();
            app.Bootstrap();
            OrderList = app._readModel.Orders;

        }
    }
}
