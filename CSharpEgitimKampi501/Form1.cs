using CSharpEgitimKampi501.Dtos;
using Dapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpEgitimKampi501
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection connection = new SqlConnection("Server=DESKTOP-L7QGU59;initial Catalog=EgitimKampi501Db;integrated security=true;");
        
        private async void btnList_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM TblProduct";
            var values = await connection.QueryAsync<ResultProductDto>(query);
            //var values = await connection.QueryAsync(query);
            dataGridView1.DataSource = values;
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            string query = "insert into TblProduct (ProductName,ProductStock,ProductPrice,ProductCategory) values (@productName,@productStock,@productPrice,@productCategory)";
            var parameters = new DynamicParameters();
            parameters.Add("@productName",txtProductName.Text);
            parameters.Add("@productStock", txtProductStock.Text);
            parameters.Add("@productPrice",txtProductPrice.Text);
            parameters.Add("@productCategory",txtProductCategory.Text);
            await connection.ExecuteAsync(query, parameters);
            MessageBox.Show("Kitap kaydı yapıldı");
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            string query = "Delete From TblProduct Where ProductId=@productId";
            var parameters = new DynamicParameters();
            parameters.Add("@productId", txtProductId.Text);
            await connection.ExecuteAsync(query,parameters);
            MessageBox.Show("Kitap silme yapıldı");

        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            string quesy = "Update TblProduct Set ProductName=@productName,ProductPrice=@productPrice,ProductStock=@productStock,ProductCategory=@productCategory where ProductId=@productId";
            var parameters =new DynamicParameters();
            parameters.Add("@productName", txtProductName.Text);
            parameters.Add("@productPrice", txtProductPrice.Text);
            parameters.Add("@productStock", txtProductStock.Text);
            parameters.Add("@productCategory",txtProductCategory.Text);
            parameters.Add("@productId",txtProductId.Text);
            await connection.ExecuteAsync(quesy, parameters);
            MessageBox.Show("Kitap bilgileri güncellendi"); 
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            string query1 = "Select Count (*) From TblProduct";
            var productTotalCount=await connection.QueryFirstOrDefaultAsync <int>(query1);
            lblProductCount.Text = productTotalCount.ToString();

            string query2 = "Select ProductName From TblProduct Where ProductPrice=(Select Max(ProductPrice) From TblProduct)";
            var maxPriceProductName= await connection.QueryFirstOrDefaultAsync<string>(query2);
            lblMaxPriceProductName.Text = maxPriceProductName.ToString();

            string query3 = "Select Count(Distinct(ProductCategory)) From TblProduct";
            var distinctProductCount = await connection.QueryFirstOrDefaultAsync<int>(query3);
            lblDistinctCategoryCount.Text = distinctProductCount.ToString();
        }

        //private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{

        //}
    }
}
