using MyMauiApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlazorHybridApp.Services
{
    // ProductState.cs
    public class StateService
    {
        public Product? SelectedProduct { get; private set; }

        public void SetSelectedProduct(Product product)
        {
            SelectedProduct = product;
        }

        public void ClearSelectedProduct()
        {
            SelectedProduct = null;
        }
    }

}
