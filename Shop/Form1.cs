using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shop
{
    public partial class Form1 : Form
    {
        SqlConnection sqlConnection;

        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=DESKTOP-FRG71T8\SQLEXPRESS;Initial Catalog=Shop_of_computer_products_DB;Integrated Security=True";

            sqlConnection = new SqlConnection(connectionString);

            await sqlConnection.OpenAsync();
            SelectTableBox.DropDownStyle = ComboBoxStyle.DropDownList;
            SelectQueryBox.DropDownStyle = ComboBoxStyle.DropDownList;
            SqlDataReader sqlReader = null; //Получение таблицы в табличном представлении


        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sqlConnection != null && sqlConnection.State != ConnectionState.Closed)
                sqlConnection.Close();

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (sqlConnection != null && sqlConnection.State != ConnectionState.Closed)
                sqlConnection.Close();
        }

        //SELECT

        private async void SelectButton_Click(object sender, EventArgs e)
        {
            int counter = 0;
            if (SelectTableBox.SelectedIndex == 0)
            {
                SqlDataReader sqlReader = null;
                SqlCommand command = new SqlCommand("SELECT * FROM [Customers]", sqlConnection);

                try
                {
                    sqlReader = await command.ExecuteReaderAsync();
                    listBox1.Items.Clear();
                    listBox1.Items.Add(Convert.ToString("ID покупателя" + "  (|)  " + "Фамилия" + "  (|)  " + "Имя" + "  (|)  " + "Отчество" + "  (|)  " + "Адрес" + "  (|)  " + "Город" + "  (|)  " + "Телефон"));
                    listBox1.Items.Add(Convert.ToString("---------------------------------------------------------------------------------"));
                    while (await sqlReader.ReadAsync())
                    {
                        counter++;
                        listBox1.Items.Add(Convert.ToString(sqlReader["ID"]) + "  (|)  " + Convert.ToString(sqlReader["FName"]) + "  (|)  " + Convert.ToString(sqlReader["MName"]) + "  (|)  " + Convert.ToString(sqlReader["LName"]) + "  (|)  " + Convert.ToString(sqlReader["Address"]) + "  (|)  " + Convert.ToString(sqlReader["City"]) + "  (|)  " + Convert.ToString(sqlReader["Phone"]) + "  (|)  " + Convert.ToString(sqlReader["DateInSystem"]));
                    }
                    if (counter > 0)
                    {
                        MessageBox.Show(string.Format("В таблице было найдено и выведено на экран {0} строк(и)", counter), "Отчёт", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(string.Format("К сожалению, в таблице не было обнаружено записей"),"Отчёт", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                finally
                {
                    if (sqlReader != null)
                    {
                        sqlReader.Close();
                    }
                }

            }

            if (SelectTableBox.SelectedIndex == 1)
            {
                SqlDataReader sqlReader = null;
                SqlCommand command = new SqlCommand("SELECT * FROM [Products]", sqlConnection);
                listBox1.ClearSelected();
                try
                {
                    sqlReader = await command.ExecuteReaderAsync();
                    listBox1.Items.Clear();
                    listBox1.Items.Add(Convert.ToString("ID продукта" + "  (|)  " + "Наименование продукта"));
                    listBox1.Items.Add(Convert.ToString("---------------------------------------------------------------------------------"));
                    while (await sqlReader.ReadAsync())
                    {
                        counter++;
                        listBox1.Items.Add(Convert.ToString(sqlReader["ID"]) + "  (|)  " + Convert.ToString(sqlReader["Name"]));
                    }
                    if (counter > 0)
                    {
                        MessageBox.Show(string.Format("В таблице было найдено и выведено на экран {0} строк(и)", counter), "Отчёт", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(string.Format("К сожалению, в таблице не было обнаружено записей"), "Отчёт", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (sqlReader != null)
                    {
                        sqlReader.Close();
                    }
                }
            }

            if (SelectTableBox.SelectedIndex == 2)
            {
                SqlDataReader sqlReader = null;
                SqlCommand command = new SqlCommand("SELECT * FROM [ProductDetails]", sqlConnection);

                try
                {
                    sqlReader = await command.ExecuteReaderAsync();
                    listBox1.Items.Clear();
                    listBox1.Items.Add(Convert.ToString("ID продукта" + "  (|)  " + "Цвет" + "  (|)  " + "Описание"));
                    listBox1.Items.Add(Convert.ToString("---------------------------------------------------------------------------------"));
                    while (await sqlReader.ReadAsync())
                    {
                        counter++;
                        listBox1.Items.Add(Convert.ToString(sqlReader["ID"]) + "  (|)  " + Convert.ToString(sqlReader["Color"]) + "  (|)  " + Convert.ToString(sqlReader["Description"]));
                    }
                    if (counter > 0)
                    {
                        MessageBox.Show(string.Format("В таблице было найдено и выведено на экран {0} строк(и)", counter), "Отчёт", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(string.Format("К сожалению, в таблице не было обнаружено записей"), "Отчёт", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (sqlReader != null)
                    {
                        sqlReader.Close();
                    }
                }

            }
            if (SelectTableBox.SelectedIndex == 3)
            {
                SqlDataReader sqlReader = null;
                SqlCommand command = new SqlCommand("SELECT * FROM [Orders]", sqlConnection);

                try
                {
                    sqlReader = await command.ExecuteReaderAsync();
                    listBox1.Items.Clear();
                    listBox1.Items.Add(Convert.ToString("ID заказа" + "  (|)  " + "ID продавца" + "  (|)  " + "ID покупателя" + "  (|)  " + "Дата заказа"));
                    listBox1.Items.Add(Convert.ToString("---------------------------------------------------------------------------------"));
                    while (await sqlReader.ReadAsync())
                    {
                        counter++;
                        listBox1.Items.Add(Convert.ToString(sqlReader["ID"]) + "  (|)  " + Convert.ToString(sqlReader["CustomerID"]) + "  (|)  " + Convert.ToString(sqlReader["EmployeeID"] + "  (|)  " + Convert.ToString(sqlReader["OrderDate"])));
                    }
                    if (counter > 0)
                    {
                        MessageBox.Show(string.Format("В таблице было найдено и выведено на экран {0} строк(и)", counter), "Отчёт", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(string.Format("К сожалению, в таблице не было обнаружено записей"), "Отчёт", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (sqlReader != null)
                    {
                        sqlReader.Close();
                    }
                }
            }

            if (SelectTableBox.SelectedIndex == 4)
            {
                SqlDataReader sqlReader = null;
                SqlCommand command = new SqlCommand("SELECT * FROM [OrderDetails]", sqlConnection);

                try
                {
                    sqlReader = await command.ExecuteReaderAsync();
                    listBox1.Items.Clear();
                    listBox1.Items.Add(Convert.ToString("ID заказа" + "  (|)  " + "Приоритет" + "  (|)  " + "ID продукта" + "  (|)  " + "Количество" + "  (|)  " + "Цена" + "  (|)  " + "Общая цена"));
                    listBox1.Items.Add(Convert.ToString("---------------------------------------------------------------------------------"));
                    while (await sqlReader.ReadAsync())
                    {
                        counter++;
                        listBox1.Items.Add(Convert.ToString(sqlReader["OrderID"]) + "  (|)  " + Convert.ToString(sqlReader["LineItem"]) + "  (|)  " + Convert.ToString(sqlReader["ProductID"] + "  (|)  " + Convert.ToString(sqlReader["Qty"]) + "  (|)  " + Convert.ToString(sqlReader["Price"]) + "  (|)  " + Convert.ToString(sqlReader["TotalPrice"])));
                    }
                    if (counter > 0)
                    {
                        MessageBox.Show(string.Format("В таблице было найдено и выведено на экран {0} строк(и)", counter), "Отчёт :)", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(string.Format("К сожалению, в таблице не было обнаружено записей"), "Отчёт :(", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (sqlReader != null)
                    {
                        sqlReader.Close();
                    }
                }
            }

            if (SelectTableBox.SelectedIndex == 5)
            {
                SqlDataReader sqlReader = null;
                SqlCommand command = new SqlCommand("SELECT * FROM [Employees]", sqlConnection);

                try
                {
                    sqlReader = await command.ExecuteReaderAsync();
                    listBox1.Items.Clear();
                    listBox1.Items.Add(Convert.ToString("ID работника" + "  (|)  " + "Фамилия" + "  (|)  " + "Имя" + "  (|)  " + "Отчество" + "  (|)  " + "Должность" + "  (|)  " + "Зарплата" + "  (|)  " + "Премия"));
                    listBox1.Items.Add(Convert.ToString("---------------------------------------------------------------------------------"));
                    while (await sqlReader.ReadAsync())
                    {
                        counter++;
                        listBox1.Items.Add(Convert.ToString(sqlReader["ID"]) + "  (|)  " + Convert.ToString(sqlReader["FName"]) + "  (|)  " + Convert.ToString(sqlReader["MName"]) + "  (|)  " + Convert.ToString(sqlReader["LName"]) + "  (|)  " + Convert.ToString(sqlReader["Post"]) + "  (|)  " + Convert.ToString(sqlReader["Salary"]) + "  (|)  " + Convert.ToString(sqlReader["PriorSalary"]));
                    }
                    if (counter > 0)
                    {
                        MessageBox.Show(string.Format("В таблице было найдено и выведено на экран {0} строк(и)", counter), "Отчёт", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(string.Format("К сожалению, в таблице не было обнаружено записей"), "Отчёт", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (sqlReader != null)
                    {
                        sqlReader.Close();
                    }
                }
            }

            if (SelectTableBox.SelectedIndex == 6)
            {
                SqlDataReader sqlReader = null;
                SqlCommand command = new SqlCommand("SELECT * FROM [EmployeesInfo]", sqlConnection);

                try
                {
                    sqlReader = await command.ExecuteReaderAsync();
                    listBox1.Items.Clear();
                    listBox1.Items.Add(Convert.ToString("ID работника" + "  (|)  " + "Семейный статус" + "  (|)  " + "Дата рождения" + "  (|)  " + "Адрес" + "  (|)  " + "Телефон"));
                    listBox1.Items.Add(Convert.ToString("---------------------------------------------------------------------------------"));
                    while (await sqlReader.ReadAsync())
                    {
                        counter++;
                        listBox1.Items.Add(Convert.ToString(sqlReader["ID"]) + "  (|)  " + Convert.ToString(sqlReader["MaritalStatus"]) + "  (|)  " + Convert.ToString(sqlReader["BirthDate"]) + "  (|)  " + Convert.ToString(sqlReader["Address"]) + "  (|)  " + Convert.ToString(sqlReader["Phone"]));
                    }
                    if (counter > 0)
                    {
                        MessageBox.Show(string.Format("В таблице было найдено и выведено на экран {0} строк(и)", counter), "Отчёт", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(string.Format("К сожалению, в таблице не было обнаружено записей"), "Отчёт", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (sqlReader != null)
                    {
                        sqlReader.Close();
                    }
                }
            }

            if (SelectTableBox.SelectedIndex == 7)
            {
                SqlDataReader sqlReader = null;
                SqlCommand command = new SqlCommand("SELECT * FROM [Stocks]", sqlConnection);

                try
                {
                    sqlReader = await command.ExecuteReaderAsync();
                    listBox1.Items.Clear();
                    listBox1.Items.Add(Convert.ToString("ID продукта" + "  (|)  " + "Количество"));
                    listBox1.Items.Add(Convert.ToString("---------------------------------------------------------------------------------"));
                    while (await sqlReader.ReadAsync())
                    {
                        counter++;
                        listBox1.Items.Add(Convert.ToString(sqlReader["ProductID"]) + "  (|)  " + Convert.ToString(sqlReader["Qty"]));
                    }
                    if (counter > 0)
                    {
                        MessageBox.Show(string.Format("В таблице было найдено и выведено на экран {0} строк(и)", counter), "Отчёт", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(string.Format("К сожалению, в таблице не было обнаружено записей"), "Отчёт", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (sqlReader != null)
                    {
                        sqlReader.Close();
                    }
                }
            }
        }

        private async void SelectQueryButton_Click(object sender, EventArgs e)
        {
            int counter = 0;
            if (SelectQueryBox.SelectedIndex == 0)
            {
                
                SqlDataReader sqlReader = null;
                SqlCommand command = new SqlCommand("SELECT * FROM [Products] INNER JOIN [ProductDetails] ON Products.ID = ProductDetails.ID", sqlConnection);
                
                try
                {
                    sqlReader = await command.ExecuteReaderAsync();
                    listBox2.Items.Clear();
                    listBox2.Items.Add(Convert.ToString("Inner join - пересечение продуктов в базе и информации о них"));
                    listBox2.Items.Add(Convert.ToString("---------------------------------------------------------------------------------"));
                    listBox2.Items.Add(Convert.ToString("Наименование" + "  (|)  " + "Цвет" + "  (|)  " + "Описание"));
                    listBox2.Items.Add(Convert.ToString("---------------------------------------------------------------------------------"));
                    while (await sqlReader.ReadAsync())
                    {
                        counter++;
                        listBox2.Items.Add(Convert.ToString(sqlReader["Name"]) + "  (|)  " + Convert.ToString(sqlReader["Color"]) + "  (|)  " + Convert.ToString(sqlReader["Description"]));
                    }
                    if (counter > 0)
                    {
                        MessageBox.Show(string.Format("При сложном запросе было найдено и выведено на экран {0} строк(и)", counter), "Отчёт", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(string.Format("К сожалению, при сложном запросе не было обнаружено записей"), "Отчёт", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (sqlReader != null)
                    {
                        sqlReader.Close();
                    }
                }
            }
            if (SelectQueryBox.SelectedIndex == 1)
            {
                SqlDataReader sqlReader = null;
                SqlCommand command = new SqlCommand("SELECT * FROM [Products]  FULL OUTER JOIN [Stocks] ON Products.ID = Stocks.ProductID", sqlConnection);

                try
                {
                    sqlReader = await command.ExecuteReaderAsync();
                    listBox2.Items.Clear();
                    listBox2.Items.Add(Convert.ToString("Full join - выводится вся информация из таблиц товаров и наличия их на складе."));
                    listBox2.Items.Add(Convert.ToString("---------------------------------------------------------------------------------"));
                    listBox2.Items.Add(Convert.ToString("Наименование" + "  (|)  " + "Количество на складе"));
                    listBox2.Items.Add(Convert.ToString("---------------------------------------------------------------------------------"));
                    while (await sqlReader.ReadAsync())
                    {
                        counter++;
                        listBox2.Items.Add(Convert.ToString(sqlReader["Name"]) + "  (|)  " + Convert.ToString(sqlReader["Qty"]));
                    }
                    if (counter > 0)
                    {
                        MessageBox.Show(string.Format("При сложном запросе было найдено и выведено на экран {0} строк(и)", counter), "Отчёт", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(string.Format("К сожалению, при сложном запросе не было обнаружено записей"), "Отчёт", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (sqlReader != null)
                    {
                        sqlReader.Close();
                    }
                }
            }
            if (SelectQueryBox.SelectedIndex == 2)
            {
                SqlDataReader sqlReader = null;
                SqlCommand command = new SqlCommand("SELECT * FROM [Employees] RIGHT OUTER JOIN [EmployeesInfo] ON Employees.ID = EmployeesInfo.ID", sqlConnection);

                try
                {
                    sqlReader = await command.ExecuteReaderAsync();
                    listBox2.Items.Clear();
                    listBox2.Items.Add(Convert.ToString("Right join - выводятся те работники про которых есть информация"));
                    listBox2.Items.Add(Convert.ToString("---------------------------------------------------------------------------------"));
                    listBox2.Items.Add(Convert.ToString("ID" + "  (|)  " + "Фамилия" + "  (|)  " + "Имя" + "  (|)  " + "Отчество" + "  (|)  " + "Должность" + "  (|)  " + "Зарплата" + "  (|)  " + "Премия"));
                    listBox2.Items.Add(Convert.ToString("---------------------------------------------------------------------------------"));
                    while (await sqlReader.ReadAsync())
                    {
                        counter++;
                        listBox2.Items.Add(Convert.ToString(sqlReader["ID"]) + "  (|)  " + Convert.ToString(sqlReader["FName"]) + "  (|)  " + Convert.ToString(sqlReader["MName"]) + "  (|)  " + Convert.ToString(sqlReader["LName"]) + "  (|)  " + Convert.ToString(sqlReader["Post"]) + "  (|)  " + Convert.ToString(sqlReader["Salary"]) + "  (|)  " + Convert.ToString(sqlReader["PriorSalary"]));
                    }
                    if (counter > 0)
                    {
                        MessageBox.Show(string.Format("При сложном запросе было найдено и выведено на экран {0} строк(и)", counter), "Отчёт", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(string.Format("К сожалению, при сложном запросе не было обнаружено записей"), "Отчёт", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (sqlReader != null)
                    {
                        sqlReader.Close();
                    }
                }
            }
            if (SelectQueryBox.SelectedIndex == 3)
            {
                SqlDataReader sqlReader = null;
                SqlCommand command = new SqlCommand("SELECT * FROM [Products] LEFT OUTER JOIN [ProductDetails] ON Products.ID = ProductDetails.ID", sqlConnection);
                try
                {
                    sqlReader = await command.ExecuteReaderAsync();
                    listBox2.Items.Clear();
                    listBox2.Items.Add(Convert.ToString("Left join - выводится все продукты, даже те про которых нет информации."));
                    listBox2.Items.Add(Convert.ToString("---------------------------------------------------------------------------------"));
                    listBox2.Items.Add(Convert.ToString("Наименование" + "  (|)  " + "Цвет" + "  (|)  " + "Описание"));
                    listBox2.Items.Add(Convert.ToString("---------------------------------------------------------------------------------"));
                    while (await sqlReader.ReadAsync())
                    {
                        counter++;
                        listBox2.Items.Add(Convert.ToString(sqlReader["Name"]) + "  (|)  "  + Convert.ToString(sqlReader["Color"]) + "  (|)  " + Convert.ToString(sqlReader["Description"]));
                    }
                    if (counter > 0)
                    {
                        MessageBox.Show(string.Format("При сложном запросе было найдено и выведено на экран {0} строк(и)", counter), "Отчёт", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(string.Format("К сожалению, при сложном запросе не было обнаружено записей"), "Отчёт", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (sqlReader != null)
                    {
                        sqlReader.Close();
                    }
                }
            }
        }

        //INSERT

        private async void buttonCustInsert_Click(object sender, EventArgs e)
        {
            
            if (warningCustInsert.Visible)
                warningCustInsert.Visible = false;
            try
            {
                if (!string.IsNullOrEmpty(textBoxCustFNameInsert.Text) && !string.IsNullOrWhiteSpace(textBoxCustFNameInsert.Text) &&
                !string.IsNullOrEmpty(textBoxCustMNameInsert.Text) && !string.IsNullOrWhiteSpace(textBoxCustMNameInsert.Text) &&
                !string.IsNullOrEmpty(textBoxCustLNameInsert.Text) && !string.IsNullOrWhiteSpace(textBoxCustLNameInsert.Text) &&
                !string.IsNullOrEmpty(textBoxCustAddressInsert.Text) && !string.IsNullOrWhiteSpace(textBoxCustAddressInsert.Text) &&
                !string.IsNullOrEmpty(textBoxCustCityInsert.Text) && !string.IsNullOrWhiteSpace(textBoxCustCityInsert.Text) &&
                !string.IsNullOrEmpty(textBoxCustPhoneInsert.Text) && !string.IsNullOrWhiteSpace(textBoxCustPhoneInsert.Text) &&
                !string.IsNullOrEmpty(textBoxCustDateInsert.Text) && !string.IsNullOrWhiteSpace(textBoxCustDateInsert.Text))
                {

                    SqlCommand command = new SqlCommand("INSERT INTO [Customers] (FName, MName, LName, Address, City, Phone, DateInSystem)VALUES(@FName, @MName, @LName, @Address, @City, @Phone, @DateInSystem)", sqlConnection);

                    command.Parameters.AddWithValue("FName", textBoxCustFNameInsert.Text);
                    command.Parameters.AddWithValue("MName", textBoxCustMNameInsert.Text);
                    command.Parameters.AddWithValue("LName", textBoxCustLNameInsert.Text);
                    command.Parameters.AddWithValue("Address", textBoxCustAddressInsert.Text);
                    command.Parameters.AddWithValue("City", textBoxCustCityInsert.Text);
                    command.Parameters.AddWithValue("Phone", textBoxCustPhoneInsert.Text);
                    command.Parameters.AddWithValue("DateInSystem", textBoxCustDateInsert.Text);

                    await command.ExecuteNonQueryAsync();
                }
                else
                {
                    warningCustInsert.Visible = true;
                    warningCustInsert.Text = "Все поля должны быть заполнены!";
                }
                textBoxCustFNameInsert.Clear();
                textBoxCustMNameInsert.Clear();
                textBoxCustLNameInsert.Clear();
                textBoxCustAddressInsert.Clear();
                textBoxCustCityInsert.Clear();
                textBoxCustPhoneInsert.Clear();
                textBoxCustDateInsert.Clear();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void buttonProdInsert_Click_1(object sender, EventArgs e)
        {
                if (warningProdInsert.Visible)
                    warningProdInsert.Visible = false;
            try
            {
                if (!string.IsNullOrEmpty(textBoxProdNameInsert.Text) && !string.IsNullOrWhiteSpace(textBoxProdNameInsert.Text))
                {

                    SqlCommand command = new SqlCommand("INSERT INTO [Products] (Name)VALUES(@Name)", sqlConnection);

                    command.Parameters.AddWithValue("Name", textBoxProdNameInsert.Text);

                    await command.ExecuteNonQueryAsync();
                }
                else
                {
                    warningProdInsert.Visible = true;
                    warningProdInsert.Text = "Поле название должно быть заполнено!";
                }
                textBoxProdNameInsert.Clear();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void buttonProdDetInsert_Click(object sender, EventArgs e)
        {
            if (warningProdDetInsert.Visible)
                warningProdDetInsert.Visible = false;
            try
            {

                if (!string.IsNullOrEmpty(textBoxProdDetIDInsert.Text) && !string.IsNullOrWhiteSpace(textBoxProdDetIDInsert.Text) &&
                   !string.IsNullOrEmpty(textBoxProdDetColorInsert.Text) && !string.IsNullOrWhiteSpace(textBoxProdDetColorInsert.Text) &&
                   !string.IsNullOrEmpty(textBoxProdDetDescriptionInsert.Text) && !string.IsNullOrWhiteSpace(textBoxProdDetDescriptionInsert.Text))
                {

                    SqlCommand command = new SqlCommand("INSERT INTO [ProductDetails] (ID, Color, Description)VALUES(@ID, @Color, @Description)", sqlConnection);

                    command.Parameters.AddWithValue("ID", textBoxProdDetIDInsert.Text);
                    command.Parameters.AddWithValue("Color", textBoxProdDetColorInsert.Text);
                    command.Parameters.AddWithValue("Description", textBoxProdDetDescriptionInsert.Text);

                    await command.ExecuteNonQueryAsync();
                }
                else
                {
                    warningProdDetInsert.Visible = true;
                    warningProdDetInsert.Text = "Все поля должны быть заполнены!";
                }
                textBoxProdDetIDInsert.Clear();
                textBoxProdDetColorInsert.Clear();
                textBoxProdDetDescriptionInsert.Clear();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void buttonEmployeesInsert_Click(object sender, EventArgs e)
        {
            if (warningEmployeesInsert.Visible)
                warningEmployeesInsert.Visible = false;
            try
            {
                if (!string.IsNullOrEmpty(textBoxEmployeesFNameInsert.Text) && !string.IsNullOrWhiteSpace(textBoxEmployeesFNameInsert.Text) &&
                    !string.IsNullOrEmpty(textBoxEmployeesMNameInsert.Text) && !string.IsNullOrWhiteSpace(textBoxEmployeesMNameInsert.Text) &&
                    !string.IsNullOrEmpty(textBoxEmployeesLNameInsert.Text) && !string.IsNullOrWhiteSpace(textBoxEmployeesLNameInsert.Text) &&
                    !string.IsNullOrEmpty(textBoxEmployeesPostInsert.Text) && !string.IsNullOrWhiteSpace(textBoxEmployeesPostInsert.Text) &&
                    !string.IsNullOrEmpty(textBoxEmployeesSalaryInsert.Text) && !string.IsNullOrWhiteSpace(textBoxEmployeesSalaryInsert.Text) &&
                    !string.IsNullOrEmpty(textBoxEmployeesPriorSalaryInsert.Text) && !string.IsNullOrWhiteSpace(textBoxEmployeesPriorSalaryInsert.Text))
                {

                    SqlCommand command = new SqlCommand("INSERT INTO [Employees] (FName, MName, LName, Post, Salary, PriorSalary)VALUES(@FName, @MName, @LName, @Post, @Salary, @PriorSalary)", sqlConnection);

                    command.Parameters.AddWithValue("FName", textBoxEmployeesFNameInsert.Text);
                    command.Parameters.AddWithValue("MName", textBoxEmployeesMNameInsert.Text);
                    command.Parameters.AddWithValue("LName", textBoxEmployeesLNameInsert.Text);
                    command.Parameters.AddWithValue("Post", textBoxEmployeesPostInsert.Text);
                    command.Parameters.AddWithValue("Salary", textBoxEmployeesSalaryInsert.Text);
                    command.Parameters.AddWithValue("PriorSalary", textBoxEmployeesPriorSalaryInsert.Text);

                    await command.ExecuteNonQueryAsync();
                }
                else
                {
                    warningEmployeesInsert.Visible = true;
                    warningEmployeesInsert.Text = "Все поля должны быть заполнены!";
                }
                textBoxEmployeesFNameInsert.Clear();
                textBoxEmployeesMNameInsert.Clear();
                textBoxEmployeesLNameInsert.Clear();
                textBoxEmployeesPostInsert.Clear();
                textBoxEmployeesSalaryInsert.Clear();
                textBoxEmployeesPriorSalaryInsert.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void buttonEmployeesInfoInsert_Click(object sender, EventArgs e)
        {

            if (warningEmployeesInfoInsert.Visible)
                warningEmployeesInfoInsert.Visible = false;
            try
            {
                if (!string.IsNullOrEmpty(textBoxEmployeesInfoIDInsert.Text) && !string.IsNullOrWhiteSpace(textBoxEmployeesInfoIDInsert.Text) &&
                !string.IsNullOrEmpty(textBoxEmployeesInfoMaritalStatusInsert.Text) && !string.IsNullOrWhiteSpace(textBoxEmployeesInfoMaritalStatusInsert.Text) &&
                !string.IsNullOrEmpty(textBoxEmployeesInfoBirthDateInsert.Text) && !string.IsNullOrWhiteSpace(textBoxEmployeesInfoBirthDateInsert.Text) &&
                !string.IsNullOrEmpty(textBoxEmployeesInfoAddressInsert.Text) && !string.IsNullOrWhiteSpace(textBoxEmployeesInfoAddressInsert.Text) &&
                !string.IsNullOrEmpty(textBoxEmployeesInfoPhoneInsert.Text) && !string.IsNullOrWhiteSpace(textBoxEmployeesInfoPhoneInsert.Text))
                {

                    SqlCommand command = new SqlCommand("INSERT INTO [EmployeesInfo] (ID, MaritalStatus, BirthDate, Address, Phone)VALUES(@ID, @MaritalStatus, @BirthDate, @Address, @Phone)", sqlConnection);

                    command.Parameters.AddWithValue("ID", textBoxEmployeesInfoIDInsert.Text);
                    command.Parameters.AddWithValue("MaritalStatus", textBoxEmployeesInfoMaritalStatusInsert.Text);
                    command.Parameters.AddWithValue("BirthDate", textBoxEmployeesInfoBirthDateInsert.Text);
                    command.Parameters.AddWithValue("Address", textBoxEmployeesInfoAddressInsert.Text);
                    command.Parameters.AddWithValue("Phone", textBoxEmployeesInfoPhoneInsert.Text);

                    await command.ExecuteNonQueryAsync();
                }
                else
                {
                    warningEmployeesInfoInsert.Visible = true;
                    warningEmployeesInfoInsert.Text = "Все поля должны быть заполнены!";
                }
                textBoxEmployeesInfoIDInsert.Clear();
                textBoxEmployeesInfoMaritalStatusInsert.Clear();
                textBoxEmployeesInfoBirthDateInsert.Clear();
                textBoxEmployeesInfoAddressInsert.Clear();
                textBoxEmployeesInfoPhoneInsert.Clear();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void buttonOrdersInsert_Click(object sender, EventArgs e)
        {
                if (warningOrdersInsert.Visible)
                    warningOrdersInsert.Visible = false;
            try { 
                if (!string.IsNullOrEmpty(textBoxOrdersCustomerIDInsert.Text) && !string.IsNullOrWhiteSpace(textBoxOrdersCustomerIDInsert.Text) &&
                    !string.IsNullOrEmpty(textBoxOrdersEmployeeIDInsert.Text) && !string.IsNullOrWhiteSpace(textBoxOrdersEmployeeIDInsert.Text) &&
                    !string.IsNullOrEmpty(textBoxOrdersOrderDateInsert.Text) && !string.IsNullOrWhiteSpace(textBoxOrdersOrderDateInsert.Text))
                {

                    SqlCommand command = new SqlCommand("INSERT INTO [Orders] (CustomerID, EmployeeID, OrderDate)VALUES(@CustomerID, @EmployeeID, @OrderDate)", sqlConnection);

                    command.Parameters.AddWithValue("CustomerID", textBoxOrdersCustomerIDInsert.Text);
                    command.Parameters.AddWithValue("EmployeeID", textBoxOrdersEmployeeIDInsert.Text);
                    command.Parameters.AddWithValue("OrderDate", textBoxOrdersOrderDateInsert.Text);

                    await command.ExecuteNonQueryAsync();
                }
                else
                {
                    warningOrdersInsert.Visible = true;
                    warningOrdersInsert.Text = "Все поля должны быть заполнены!";
                }
                textBoxOrdersCustomerIDInsert.Clear();
                textBoxOrdersEmployeeIDInsert.Clear();
                textBoxOrdersOrderDateInsert.Clear();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void buttonOrderDetailsInsert_Click(object sender, EventArgs e)
        {
            try
            {
                if (warningOrderDetailsInsert.Visible)
                    warningOrderDetailsInsert.Visible = false;

                if (!string.IsNullOrEmpty(textBoxOrderDetailsOrderIDInsert.Text) && !string.IsNullOrWhiteSpace(textBoxOrderDetailsOrderIDInsert.Text) &&
                    !string.IsNullOrEmpty(textBoxOrderDetailsLineItemInsert.Text) && !string.IsNullOrWhiteSpace(textBoxOrderDetailsLineItemInsert.Text) &&
                    !string.IsNullOrEmpty(textBoxOrderDetailsProductIDInsert.Text) && !string.IsNullOrWhiteSpace(textBoxOrderDetailsProductIDInsert.Text) &&
                    !string.IsNullOrEmpty(textBoxOrderDetailsQtyInsert.Text) && !string.IsNullOrWhiteSpace(textBoxOrderDetailsQtyInsert.Text) &&
                    !string.IsNullOrEmpty(textBoxOrderDetailsPriceInsert.Text) && !string.IsNullOrWhiteSpace(textBoxOrderDetailsPriceInsert.Text))
                {

                    SqlCommand command = new SqlCommand("INSERT INTO [OrderDetails] (OrderID, LineItem, ProductID, Qty, Price)VALUES(@OrderID, @LineItem, @ProductID, @Qty, @Price)", sqlConnection);

                    command.Parameters.AddWithValue("OrderID", textBoxOrderDetailsOrderIDInsert.Text);
                    command.Parameters.AddWithValue("LineItem", textBoxOrderDetailsLineItemInsert.Text);
                    command.Parameters.AddWithValue("ProductID", textBoxOrderDetailsProductIDInsert.Text);
                    command.Parameters.AddWithValue("Qty", textBoxOrderDetailsQtyInsert.Text);
                    command.Parameters.AddWithValue("Price", textBoxOrderDetailsPriceInsert.Text);

                    await command.ExecuteNonQueryAsync();
                }
                else
                {
                    warningOrderDetailsInsert.Visible = true;
                    warningOrderDetailsInsert.Text = "Все поля должны быть заполнены!";
                }
                textBoxOrderDetailsOrderIDInsert.Clear();
                textBoxOrderDetailsLineItemInsert.Clear();
                textBoxOrderDetailsProductIDInsert.Clear();
                textBoxOrderDetailsQtyInsert.Clear();
                textBoxOrderDetailsPriceInsert.Clear();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void buttonStocksInsert_Click(object sender, EventArgs e)
        {
            if (warningStocksInsert.Visible)
                warningStocksInsert.Visible = false;
            try
            {

                if (!string.IsNullOrEmpty(textBoxStocksProductIDInsert.Text) && !string.IsNullOrWhiteSpace(textBoxStocksProductIDInsert.Text) &&
                   !string.IsNullOrEmpty(textBoxStocksQtyInsert.Text) && !string.IsNullOrWhiteSpace(textBoxStocksQtyInsert.Text))
                {

                    SqlCommand command = new SqlCommand("INSERT INTO [Stocks] (ProductID, Qty)VALUES(@ProductID, @Qty)", sqlConnection);

                    command.Parameters.AddWithValue("ProductID", textBoxStocksProductIDInsert.Text);
                    command.Parameters.AddWithValue("Qty", textBoxStocksQtyInsert.Text);

                    await command.ExecuteNonQueryAsync();
                }
                else
                {
                    warningStocksInsert.Visible = true;
                    warningStocksInsert.Text = "Все поля должны быть заполнены!";
                }
                textBoxStocksProductIDInsert.Clear();
                textBoxStocksQtyInsert.Clear();
            }

            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void buttonCustDelete_Click(object sender, EventArgs e)
        {
            if (warningCustDelete.Visible)
                warningCustDelete.Visible = false;
            try
            {
                if (!string.IsNullOrEmpty(textBoxCustIDDelete.Text) && !string.IsNullOrWhiteSpace(textBoxCustIDDelete.Text))
                {

                    SqlCommand command = new SqlCommand("DELETE FROM [Customers] WHERE [ID]=@ID", sqlConnection);

                    command.Parameters.AddWithValue("ID", textBoxCustIDDelete.Text);

                    await command.ExecuteNonQueryAsync();
                }
                else
                {
                    warningCustDelete.Visible = true;
                    warningCustDelete.Text = "Id должны быть заполнены!";
                }
                textBoxCustIDDelete.Clear();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //DELETE

        private async void buttonEmployeesDelete_Click(object sender, EventArgs e)
        {
            
                if (warningEmployeesDelete.Visible)
                    warningEmployeesDelete.Visible = false;
            try
            {
                if (!string.IsNullOrEmpty(textBoxEmployeesIDDelete.Text) && !string.IsNullOrWhiteSpace(textBoxEmployeesIDDelete.Text))
                {

                    SqlCommand command = new SqlCommand("DELETE FROM [Employees] WHERE [ID]=@ID", sqlConnection);

                    command.Parameters.AddWithValue("ID", textBoxEmployeesIDDelete.Text);

                    await command.ExecuteNonQueryAsync();
                }
                else
                {
                    warningEmployeesDelete.Visible = true;
                    warningEmployeesDelete.Text = "Id должны быть заполнены!";
                }
                textBoxEmployeesIDDelete.Clear();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void buttonEmployeesInfoDelete_Click(object sender, EventArgs e)
        {
            
                if (warningEmployeesInfoDelete.Visible)
                    warningEmployeesInfoDelete.Visible = false;
            try
            {
                if (!string.IsNullOrEmpty(textBoxEmployeesInfoIDDelete.Text) && !string.IsNullOrWhiteSpace(textBoxEmployeesInfoIDDelete.Text))
                {

                    SqlCommand command = new SqlCommand("DELETE FROM [EmployeesInfo] WHERE [ID]=@ID", sqlConnection);

                    command.Parameters.AddWithValue("ID", textBoxEmployeesInfoIDDelete.Text);

                    await command.ExecuteNonQueryAsync();
                }
                else
                {
                    warningEmployeesInfoDelete.Visible = true;
                    warningEmployeesInfoDelete.Text = "Id должны быть заполнены!";
                }
                textBoxEmployeesInfoIDDelete.Clear();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void buttonOrderDetailsDelete_Click(object sender, EventArgs e)
        {
            
                if (warningOrderDetailsDelete.Visible)
                    warningOrderDetailsDelete.Visible = false;
            try
            {
                if (!string.IsNullOrEmpty(textBoxOrderDetailsOrderIDDelete.Text) && !string.IsNullOrWhiteSpace(textBoxOrderDetailsOrderIDDelete.Text))
                {

                    SqlCommand command = new SqlCommand("DELETE FROM [OrderDetails] WHERE [OrderID]=@OrderID", sqlConnection);

                    command.Parameters.AddWithValue("OrderID", textBoxOrderDetailsOrderIDDelete.Text);

                    await command.ExecuteNonQueryAsync();
                }
                else
                {
                    warningOrderDetailsDelete.Visible = true;
                    warningOrderDetailsDelete.Text = "Id должны быть заполнены!";
                }
                textBoxOrderDetailsOrderIDDelete.Clear();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void buttonOrdersDelete_Click(object sender, EventArgs e)
        {
           
                if (warningOrdersDelete.Visible)
                    warningOrdersDelete.Visible = false;
            try
            {
                if (!string.IsNullOrEmpty(textBoxOrdersIDDelete.Text) && !string.IsNullOrWhiteSpace(textBoxOrdersIDDelete.Text))
                {

                    SqlCommand command = new SqlCommand("DELETE FROM [Orders] WHERE [ID]=@ID", sqlConnection);

                    command.Parameters.AddWithValue("ID", textBoxOrdersIDDelete.Text);

                    await command.ExecuteNonQueryAsync();
                }
                else
                {
                    warningOrdersDelete.Visible = true;
                    warningOrdersDelete.Text = "Id должны быть заполнены!";
                }
                textBoxOrdersIDDelete.Clear();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void buttonProductDetailsDelete_Click(object sender, EventArgs e)
        {
            
                if (warningProductDetailsDelete.Visible)
                    warningProductDetailsDelete.Visible = false;
            try
            {
                if (!string.IsNullOrEmpty(textBoxProductDetailsIDDelete.Text) && !string.IsNullOrWhiteSpace(textBoxProductDetailsIDDelete.Text))
                {

                    SqlCommand command = new SqlCommand("DELETE FROM [ProductDetails] WHERE [ID]=@ID", sqlConnection);

                    command.Parameters.AddWithValue("ID", textBoxProductDetailsIDDelete.Text);

                    await command.ExecuteNonQueryAsync();
                }
                else
                {
                    warningProductDetailsDelete.Visible = true;
                    warningProductDetailsDelete.Text = "Id должны быть заполнены!";
                }
                textBoxProductDetailsIDDelete.Clear();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void buttonProductsDelete_Click(object sender, EventArgs e)
        {
            
                if (warningProductsDelete.Visible)
                    warningProductsDelete.Visible = false;
            try
            {
                if (!string.IsNullOrEmpty(textBoxProductsIDDelete.Text) && !string.IsNullOrWhiteSpace(textBoxProductsIDDelete.Text))
                {

                    SqlCommand command = new SqlCommand("DELETE FROM [Products] WHERE [ID]=@ID", sqlConnection);

                    command.Parameters.AddWithValue("ID", textBoxProductsIDDelete.Text);

                    await command.ExecuteNonQueryAsync();
                }
                else
                {
                    warningProductsDelete.Visible = true;
                    warningProductsDelete.Text = "Id должны быть заполнены!";
                }
                textBoxProductsIDDelete.Clear();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void buttonStocksDelete_Click(object sender, EventArgs e)
        {
            
                if (warningStocksDelete.Visible)
                    warningStocksDelete.Visible = false;
            try
            {
                if (!string.IsNullOrEmpty(textBoxStocksProductIDDelete.Text) && !string.IsNullOrWhiteSpace(textBoxStocksProductIDDelete.Text))
                {

                    SqlCommand command = new SqlCommand("DELETE FROM [Stocks] WHERE [ProductID]=@ProductID", sqlConnection);

                    command.Parameters.AddWithValue("ProductID", textBoxStocksProductIDDelete.Text);
                    await command.ExecuteNonQueryAsync();
                }
                else
                {
                    warningStocksDelete.Visible = true;
                    warningStocksDelete.Text = "Id должны быть заполнены!";
                }
                textBoxStocksProductIDDelete.Clear();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void buttonOrdersDelete_Click_1(object sender, EventArgs e)
        {
          
                if (warningOrdersDelete.Visible)
                    warningOrdersDelete.Visible = false;
            try
            {
                if (!string.IsNullOrEmpty(textBoxOrdersIDDelete.Text) && !string.IsNullOrWhiteSpace(textBoxOrdersIDDelete.Text))
                {

                    SqlCommand command = new SqlCommand("DELETE FROM [Orders] WHERE [ID]=@ID", sqlConnection);

                    command.Parameters.AddWithValue("ID", textBoxOrdersIDDelete.Text);
                    await command.ExecuteNonQueryAsync();
                }
                else
                {
                    warningOrdersDelete.Visible = true;
                    warningOrdersDelete.Text = "Id должны быть заполнены!";
                }
                textBoxOrdersIDDelete.Clear();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //UPDATE

        private async void buttonCustUpdate_Click(object sender, EventArgs e)
        {
            if (warningCustUpdate.Visible)
                warningCustUpdate.Visible = false;
            try
            {
                if (!string.IsNullOrEmpty(textBoxCustIDUpdate.Text) && !string.IsNullOrWhiteSpace(textBoxCustIDUpdate.Text) &&
                    !string.IsNullOrEmpty(textBoxCustFNameUpdate.Text) && !string.IsNullOrWhiteSpace(textBoxCustFNameUpdate.Text) &&
                    !string.IsNullOrEmpty(textBoxCustMNameUpdate.Text) && !string.IsNullOrWhiteSpace(textBoxCustMNameUpdate.Text) &&
                    !string.IsNullOrEmpty(textBoxCustLNameUpdate.Text) && !string.IsNullOrWhiteSpace(textBoxCustLNameUpdate.Text) &&
                    !string.IsNullOrEmpty(textBoxCustAddressUpdate.Text) && !string.IsNullOrWhiteSpace(textBoxCustAddressUpdate.Text) &&
                    !string.IsNullOrEmpty(textBoxCustCityUpdate.Text) && !string.IsNullOrWhiteSpace(textBoxCustCityUpdate.Text) &&
                    !string.IsNullOrEmpty(textBoxCustPhoneUpdate.Text) && !string.IsNullOrWhiteSpace(textBoxCustPhoneUpdate.Text) &&
                    !string.IsNullOrEmpty(textBoxCustDateInSystemUpdate.Text) && !string.IsNullOrWhiteSpace(textBoxCustDateInSystemUpdate.Text))
                {

                    SqlCommand command = new SqlCommand("UPDATE [Customers] SET [FName]=@FName, [MName]=@MName, [LName]=@LName, [Address]=@Address, [City]=@City, [Phone]=@Phone, [DateInSystem]=@DateInSystem WHERE [ID]=@ID", sqlConnection);

                    command.Parameters.AddWithValue("ID", textBoxCustIDUpdate.Text);
                    command.Parameters.AddWithValue("FName", textBoxCustFNameUpdate.Text);
                    command.Parameters.AddWithValue("MName", textBoxCustMNameUpdate.Text);
                    command.Parameters.AddWithValue("LName", textBoxCustLNameUpdate.Text);
                    command.Parameters.AddWithValue("Address", textBoxCustAddressUpdate.Text);
                    command.Parameters.AddWithValue("City", textBoxCustCityUpdate.Text);
                    command.Parameters.AddWithValue("Phone", textBoxCustPhoneUpdate.Text);
                    command.Parameters.AddWithValue("DateInSystem", textBoxCustDateInSystemUpdate.Text);

                    await command.ExecuteNonQueryAsync();
                }
                else if (!string.IsNullOrEmpty(textBoxCustIDUpdate.Text) && !string.IsNullOrWhiteSpace(textBoxCustIDUpdate.Text))
                {
                    warningCustUpdate.Visible = true;
                    warningCustUpdate.Text = "Все поля должны быть заполнены!";
                }
                else
                {
                    warningCustUpdate.Visible = true;
                    warningCustUpdate.Text = "Все поля должны быть заполнены!";
                }
                textBoxCustIDUpdate.Clear();
                textBoxCustFNameUpdate.Clear();
                textBoxCustMNameUpdate.Clear();
                textBoxCustLNameUpdate.Clear();
                textBoxCustAddressUpdate.Clear();
                textBoxCustCityUpdate.Clear();
                textBoxCustPhoneUpdate.Clear();
                textBoxCustDateInSystemUpdate.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void buttonEmployeesUpdate_Click(object sender, EventArgs e)
        {
            if (warningEmployeesUpdate.Visible)
                warningEmployeesUpdate.Visible = false;
            try
            {
                if (!string.IsNullOrEmpty(textBoxEmployeesIDUpdate.Text) && !string.IsNullOrWhiteSpace(textBoxEmployeesIDUpdate.Text) &&
                    !string.IsNullOrEmpty(textBoxEmployeesFNameUpdate.Text) && !string.IsNullOrWhiteSpace(textBoxEmployeesFNameUpdate.Text) &&
                    !string.IsNullOrEmpty(textBoxEmployeesMNameUpdate.Text) && !string.IsNullOrWhiteSpace(textBoxEmployeesMNameUpdate.Text) &&
                    !string.IsNullOrEmpty(textBoxEmployeesLNameUpdate.Text) && !string.IsNullOrWhiteSpace(textBoxEmployeesLNameUpdate.Text) &&
                    !string.IsNullOrEmpty(textBoxEmployeesPostUpdate.Text) && !string.IsNullOrWhiteSpace(textBoxEmployeesPostUpdate.Text) &&
                    !string.IsNullOrEmpty(textBoxEmployeesSalaryUpdate.Text) && !string.IsNullOrWhiteSpace(textBoxEmployeesSalaryUpdate.Text) &&
                    !string.IsNullOrEmpty(textBoxEmployeesPriorSalaryUpdate.Text) && !string.IsNullOrWhiteSpace(textBoxEmployeesPriorSalaryUpdate.Text))
                {

                    SqlCommand command = new SqlCommand("UPDATE [Employees] SET [FName]=@FName, [MName]=@MName, [LName]=@LName, [Post]=@Post, [Salary]=@Salary, [PriorSalary]=@PriorSalary WHERE [ID]=@ID", sqlConnection);

                    command.Parameters.AddWithValue("ID", textBoxEmployeesIDUpdate.Text);
                    command.Parameters.AddWithValue("FName", textBoxEmployeesFNameUpdate.Text);
                    command.Parameters.AddWithValue("MName", textBoxEmployeesMNameUpdate.Text);
                    command.Parameters.AddWithValue("LName", textBoxEmployeesLNameUpdate.Text);
                    command.Parameters.AddWithValue("Post", textBoxEmployeesPostUpdate.Text);
                    command.Parameters.AddWithValue("Salary", textBoxEmployeesSalaryUpdate.Text);
                    command.Parameters.AddWithValue("PriorSalary", textBoxEmployeesPriorSalaryUpdate.Text);

                    await command.ExecuteNonQueryAsync();
                }
                else if (!string.IsNullOrEmpty(textBoxEmployeesIDUpdate.Text) && !string.IsNullOrWhiteSpace(textBoxEmployeesIDUpdate.Text))
                {
                    warningEmployeesUpdate.Visible = true;
                    warningEmployeesUpdate.Text = "Все поля должны быть заполнены!";
                }
                else
                {
                    warningEmployeesUpdate.Visible = true;
                    warningEmployeesUpdate.Text = "Все поля должны быть заполнены!";
                }
                textBoxEmployeesIDUpdate.Clear();
                textBoxEmployeesFNameUpdate.Clear();
                textBoxEmployeesMNameUpdate.Clear();
                textBoxEmployeesLNameUpdate.Clear();
                textBoxEmployeesPostUpdate.Clear();
                textBoxEmployeesSalaryUpdate.Clear();
                textBoxEmployeesPriorSalaryUpdate.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void buttonProductsUpdate_Click(object sender, EventArgs e)
        {
            if (warningProductsUpdate.Visible)
                warningProductsUpdate.Visible = false;
            try
            {
                if (!string.IsNullOrEmpty(textBoxProductsIDUpdate.Text) && !string.IsNullOrWhiteSpace(textBoxProductsIDUpdate.Text) &&
                    !string.IsNullOrEmpty(textBoxProductsNameUpdate.Text) && !string.IsNullOrWhiteSpace(textBoxProductsNameUpdate.Text))
                {

                    SqlCommand command = new SqlCommand("UPDATE [Products] SET [Name]=@Name WHERE [ID]=@ID", sqlConnection);

                    command.Parameters.AddWithValue("ID", textBoxProductsIDUpdate.Text);
                    command.Parameters.AddWithValue("Name", textBoxProductsNameUpdate.Text);

                    await command.ExecuteNonQueryAsync();
                }
                else if (!string.IsNullOrEmpty(textBoxProductsIDUpdate.Text) && !string.IsNullOrWhiteSpace(textBoxProductsIDUpdate.Text))
                {
                    warningProductsUpdate.Visible = true;
                    warningProductsUpdate.Text = "Все поля должны быть заполнены!";
                }
                else
                {
                    warningProductsUpdate.Visible = true;
                    warningProductsUpdate.Text = "Все поля должны быть заполнены!";
                }
                textBoxProductsIDUpdate.Clear();
                textBoxProductsNameUpdate.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void buttonProductDetailsUpdate_Click(object sender, EventArgs e)
        {
            if (warningProductDetailsUpdate.Visible)
                warningProductDetailsUpdate.Visible = false;
            try
            {
                if (!string.IsNullOrEmpty(textBoxProductDetailsIDUpdate.Text) && !string.IsNullOrWhiteSpace(textBoxProductDetailsIDUpdate.Text) &&
                    !string.IsNullOrEmpty(textBoxProductDetailsColorUpdate.Text) && !string.IsNullOrWhiteSpace(textBoxProductDetailsColorUpdate.Text) &&
                    !string.IsNullOrEmpty(textBoxProductDetailsDescriptionUpdate.Text) && !string.IsNullOrWhiteSpace(textBoxProductDetailsDescriptionUpdate.Text))
                {

                    SqlCommand command = new SqlCommand("UPDATE [ProductDetails] SET [Color]=@Color, [Description]=@Description WHERE [ID]=@ID", sqlConnection);

                    command.Parameters.AddWithValue("ID", textBoxProductDetailsIDUpdate.Text);
                    command.Parameters.AddWithValue("Color", textBoxProductDetailsColorUpdate.Text);
                    command.Parameters.AddWithValue("Description", textBoxProductDetailsDescriptionUpdate.Text);

                    await command.ExecuteNonQueryAsync();
                }
                else if (!string.IsNullOrEmpty(textBoxProductDetailsIDUpdate.Text) && !string.IsNullOrWhiteSpace(textBoxProductDetailsIDUpdate.Text))
                {
                    warningProductDetailsUpdate.Visible = true;
                    warningProductDetailsUpdate.Text = "Все поля должны быть заполнены!";
                }
                else
                {
                    warningProductDetailsUpdate.Visible = true;
                    warningProductDetailsUpdate.Text = "Все поля должны быть заполнены!";
                }
                textBoxProductDetailsIDUpdate.Clear();
                textBoxProductDetailsColorUpdate.Clear();
                textBoxProductDetailsDescriptionUpdate.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void buttonEmployeesInfoUpdate_Click(object sender, EventArgs e)
        {
            if (warningEmployeesInfoUpdate.Visible)
                warningEmployeesInfoUpdate.Visible = false;
            try
            {
                if (!string.IsNullOrEmpty(textBoxEmployeesInfoIDUpdate.Text) && !string.IsNullOrWhiteSpace(textBoxEmployeesInfoIDUpdate.Text) &&
                    !string.IsNullOrEmpty(textBoxEmployeesInfoMaritalStatusUpdate.Text) && !string.IsNullOrWhiteSpace(textBoxEmployeesInfoMaritalStatusUpdate.Text) &&
                    !string.IsNullOrEmpty(textBoxEmployeesInfoBirthDateUpdate.Text) && !string.IsNullOrWhiteSpace(textBoxEmployeesInfoBirthDateUpdate.Text) &&
                    !string.IsNullOrEmpty(textBoxEmployeesInfoAddressUpdate.Text) && !string.IsNullOrWhiteSpace(textBoxEmployeesInfoAddressUpdate.Text) &&
                    !string.IsNullOrEmpty(textBoxEmployeesInfoPhoneUpdate.Text) && !string.IsNullOrWhiteSpace(textBoxEmployeesInfoPhoneUpdate.Text))
                {

                    SqlCommand command = new SqlCommand("UPDATE [EmployeesInfo] SET [MaritalStatus]=@MaritalStatus, [BirthDate]=@BirthDate, [Address]=@Address, [Phone]=@Phone WHERE [ID]=@ID", sqlConnection);

                    command.Parameters.AddWithValue("ID", textBoxEmployeesInfoIDUpdate.Text);
                    command.Parameters.AddWithValue("MaritalStatus", textBoxEmployeesInfoMaritalStatusUpdate.Text);
                    command.Parameters.AddWithValue("BirthDate", textBoxEmployeesInfoBirthDateUpdate.Text);
                    command.Parameters.AddWithValue("Address", textBoxEmployeesInfoAddressUpdate.Text);
                    command.Parameters.AddWithValue("Phone", textBoxEmployeesInfoPhoneUpdate.Text);

                    await command.ExecuteNonQueryAsync();
                }
                else if (!string.IsNullOrEmpty(textBoxEmployeesInfoIDUpdate.Text) && !string.IsNullOrWhiteSpace(textBoxEmployeesInfoIDUpdate.Text))
                {
                    warningEmployeesInfoUpdate.Visible = true;
                    warningEmployeesInfoUpdate.Text = "Все поля должны быть заполнены!";
                }
                else
                {
                    warningEmployeesInfoUpdate.Visible = true;
                    warningEmployeesInfoUpdate.Text = "Все поля должны быть заполнены!";
                }
                textBoxEmployeesInfoIDUpdate.Clear();
                textBoxEmployeesInfoMaritalStatusUpdate.Clear();
                textBoxEmployeesInfoBirthDateUpdate.Clear();
                textBoxEmployeesInfoAddressUpdate.Clear();
                textBoxEmployeesInfoPhoneUpdate.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void buttonOrdersUpdate_Click(object sender, EventArgs e)
        {
            if (warningOrdersUpdate.Visible)
                warningOrdersUpdate.Visible = false;
            try
            {
                if (!string.IsNullOrEmpty(textBoxOrdersIDUpdate.Text) && !string.IsNullOrWhiteSpace(textBoxOrdersIDUpdate.Text) &&
                    !string.IsNullOrEmpty(textBoxOrdersCustomerIDUpdate.Text) && !string.IsNullOrWhiteSpace(textBoxOrdersCustomerIDUpdate.Text) &&
                    !string.IsNullOrEmpty(textBoxOrdersEmployeeIDUpdate.Text) && !string.IsNullOrWhiteSpace(textBoxOrdersEmployeeIDUpdate.Text) &&
                    !string.IsNullOrEmpty(textBoxOrdersOrderDateUpdate.Text) && !string.IsNullOrWhiteSpace(textBoxOrdersOrderDateUpdate.Text))
                {

                    SqlCommand command = new SqlCommand("UPDATE [Orders] SET [CustomerID]=@CustomerID, [EmployeeID]=@EmployeeID, [OrderDate]=@OrderDate WHERE [ID]=@ID", sqlConnection);

                    command.Parameters.AddWithValue("ID", textBoxOrdersIDUpdate.Text);
                    command.Parameters.AddWithValue("CustomerID", textBoxOrdersCustomerIDUpdate.Text);
                    command.Parameters.AddWithValue("EmployeeID", textBoxOrdersEmployeeIDUpdate.Text);
                    command.Parameters.AddWithValue("OrderDate", textBoxOrdersOrderDateUpdate.Text);

                    await command.ExecuteNonQueryAsync();
                }
                else if (!string.IsNullOrEmpty(textBoxOrdersIDUpdate.Text) && !string.IsNullOrWhiteSpace(textBoxOrdersIDUpdate.Text))
                {
                    warningOrdersUpdate.Visible = true;
                    warningOrdersUpdate.Text = "Все поля должны быть заполнены!";
                }
                else
                {
                    warningOrdersUpdate.Visible = true;
                    warningOrdersUpdate.Text = "Все поля должны быть заполнены!";
                }
                textBoxOrdersIDUpdate.Clear();
                textBoxOrdersCustomerIDUpdate.Clear();
                textBoxOrdersEmployeeIDUpdate.Clear();
                textBoxOrdersOrderDateUpdate.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void buttonStocksUpdate_Click(object sender, EventArgs e)
        {
            if (warningStocksUpdate.Visible)
                warningStocksUpdate.Visible = false;
            try
            {
                if (!string.IsNullOrEmpty(textBoxStocksProductIDUpdate.Text) && !string.IsNullOrWhiteSpace(textBoxStocksProductIDUpdate.Text) &&
                    !string.IsNullOrEmpty(textBoxStocksQtyUpdate.Text) && !string.IsNullOrWhiteSpace(textBoxStocksQtyUpdate.Text))
                {

                    SqlCommand command = new SqlCommand("UPDATE [Stocks] SET [Qty]=@Qty WHERE [ProductID]=@ProductID", sqlConnection);

                    command.Parameters.AddWithValue("ProductID", textBoxStocksProductIDUpdate.Text);
                    command.Parameters.AddWithValue("Qty", textBoxStocksQtyUpdate.Text);

                    await command.ExecuteNonQueryAsync();
                }
                else if (!string.IsNullOrEmpty(textBoxStocksProductIDUpdate.Text) && !string.IsNullOrWhiteSpace(textBoxStocksProductIDUpdate.Text))
                {
                    warningStocksUpdate.Visible = true;
                    warningStocksUpdate.Text = "Все поля должны быть заполнены!";
                }
                else
                {
                    warningStocksUpdate.Visible = true;
                    warningStocksUpdate.Text = "Все поля должны быть заполнены!";
                }
                textBoxStocksProductIDUpdate.Clear();
                textBoxStocksQtyUpdate.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void buttonOrderDetailsUpdate_Click(object sender, EventArgs e)
        {
            if (warningOrderDetailsUpdate.Visible)
                warningOrderDetailsUpdate.Visible = false;
            try
            {
                if (!string.IsNullOrEmpty(textBoxOrderDetailsOrderIDUpdate.Text) && !string.IsNullOrWhiteSpace(textBoxOrderDetailsOrderIDUpdate.Text) &&
                    !string.IsNullOrEmpty(textBoxOrderDetailsLineItemUpdate.Text) && !string.IsNullOrWhiteSpace(textBoxOrderDetailsLineItemUpdate.Text) &&
                    !string.IsNullOrEmpty(textBoxOrderDetailsProductIDUpdate.Text) && !string.IsNullOrWhiteSpace(textBoxOrderDetailsProductIDUpdate.Text) &&
                    !string.IsNullOrEmpty(textBoxOrderDetailsQtyUpdate.Text) && !string.IsNullOrWhiteSpace(textBoxOrderDetailsQtyUpdate.Text) &&
                    !string.IsNullOrEmpty(textBoxOrderDetailsPriceUpdate.Text) && !string.IsNullOrWhiteSpace(textBoxOrderDetailsPriceUpdate.Text))
                {

                    SqlCommand command = new SqlCommand("UPDATE [OrderDetails] SET [LineItem]=@LineItem, [ProductID]=@ProductID, [Qty]=@Qty, [Price]=@Price WHERE [OrderID]=@OrderID", sqlConnection);

                    command.Parameters.AddWithValue("OrderID", textBoxOrderDetailsOrderIDUpdate.Text);
                    command.Parameters.AddWithValue("LineItem", textBoxOrderDetailsLineItemUpdate.Text);
                    command.Parameters.AddWithValue("ProductID", textBoxOrderDetailsProductIDUpdate.Text);
                    command.Parameters.AddWithValue("Qty", textBoxOrderDetailsQtyUpdate.Text);
                    command.Parameters.AddWithValue("Price", textBoxOrderDetailsPriceUpdate.Text);

                    await command.ExecuteNonQueryAsync();
                }
                else if (!string.IsNullOrEmpty(textBoxOrderDetailsOrderIDUpdate.Text) && !string.IsNullOrWhiteSpace(textBoxOrderDetailsOrderIDUpdate.Text))
                {
                    warningOrderDetailsUpdate.Visible = true;
                    warningOrderDetailsUpdate.Text = "Все поля должны быть заполнены!";
                }
                else
                {
                    warningOrderDetailsUpdate.Visible = true;
                    warningOrderDetailsUpdate.Text = "Все поля должны быть заполнены!";
                }
                textBoxOrderDetailsOrderIDUpdate.Clear();
                textBoxOrderDetailsLineItemUpdate.Clear();
                textBoxOrderDetailsProductIDUpdate.Clear();
                textBoxOrderDetailsQtyUpdate.Clear();
                textBoxOrderDetailsPriceUpdate.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GroupBoxEmployeesInsert_Enter(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void GroupBoxEmployeesInfoUpdate_Enter(object sender, EventArgs e)
        {

        }

        private void GroupBoxOrderDetailsUpdate_Enter(object sender, EventArgs e)
        {

        }

        private void GroupBoxCustDelete_Enter(object sender, EventArgs e)
        {

        }

        private void GroupBoxEmployeesInfoDelete_Enter(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void labelStocksProductIDUpdate_Click(object sender, EventArgs e)
        {

        }

        private void SelectQueryBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
    
}
