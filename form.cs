using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DistributorManagementSystem
{
    public partial class MainForm : Form
    {
        private List<Product> productList;
        private List<Order> orderList;
        private List<Reseller> resellerList;

        public MainForm()
        {
            InitializeComponent();

            // Initialize the product, order, and reseller lists
            productList = new List<Product>();
            orderList = new List<Order>();
            resellerList = new List<Reseller>();
        }

        // Product Management Functions

        private void addProductButton_Click(object sender, EventArgs e)
        {
            // Create a new product and add it to the list
            Product newProduct = new Product(productNameTextBox.Text, decimal.Parse(productPriceTextBox.Text), int.Parse(productQuantityTextBox.Text));
            productList.Add(newProduct);

            // Clear the input fields
            productNameTextBox.Text = "";
            productPriceTextBox.Text = "";
            productQuantityTextBox.Text = "";

            // Update the product list view
            UpdateProductListView();
        }

        private void editProductButton_Click(object sender, EventArgs e)
        {
            // Make sure a product is selected
            if (productListView.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a product to edit.");
                return;
            }

            // Get the selected product
            Product selectedProduct = productList[productListView.SelectedIndices[0]];

            // Update the product's properties
            selectedProduct.Name = productNameTextBox.Text;
            selectedProduct.Price = decimal.Parse(productPriceTextBox.Text);
            selectedProduct.Quantity = int.Parse(productQuantityTextBox.Text);

            // Clear the input fields
            productNameTextBox.Text = "";
            productPriceTextBox.Text = "";
            productQuantityTextBox.Text = "";

            // Update the product list view
            UpdateProductListView();
        }

        private void deleteProductButton_Click(object sender, EventArgs e)
        {
            // Make sure a product is selected
            if (productListView.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a product to delete.");
                return;
            }

            // Remove the selected product from the list
            productList.RemoveAt(productListView.SelectedIndices[0]);

            // Clear the input fields
            productNameTextBox.Text = "";
            productPriceTextBox.Text = "";
            productQuantityTextBox.Text = "";

            // Update the product list view
            UpdateProductListView();
        }

        private void productListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Make sure a product is selected
            if (productListView.SelectedItems.Count == 0)
            {
                return;
            }

            // Get the selected product
            Product selectedProduct = productList[productListView.SelectedIndices[0]];

            // Update the input fields with the selected product's properties
            productNameTextBox.Text = selectedProduct.Name;
            productPriceTextBox.Text = selectedProduct.Price.ToString();
            productQuantityTextBox.Text = selectedProduct.Quantity.ToString();
        }

        private void UpdateProductListView()
        {
            // Clear the list view
            productListView.Items.Clear();

