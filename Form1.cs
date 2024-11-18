using Azure;
using Azure.Data.Tables;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace laba3
{
    public partial class Form1 : Form
    {
        private const string connectionString = "DefaultEndpointsProtocol=https;AccountName=pm311;AccountKey=2SSxhr/g88moksYllwdHMDis85lqF3FBXPoOTxgIrBbeYJd0nZO+dLl4smU74Os6GLyGHGgGE2rb+ASt9L/KAA==;EndpointSuffix=core.windows.net";
        private const string tableName = "pm311";
        private const string blobConnectionString = "DefaultEndpointsProtocol=https;AccountName=pm311;AccountKey=2SSxhr/g88moksYllwdHMDis85lqF3FBXPoOTxgIrBbeYJd0nZO+dLl4smU74Os6GLyGHGgGE2rb+ASt9L/KAA==;EndpointSuffix=core.windows.net";
        private const string containerName = "photoscontainer";
        private BlobServiceClient blobServiceClient;
        private BlobContainerClient containerClient;

        private TableClient tableClient;
        public Form1()
        {
            InitializeComponent();
            InitializeAzureTableClient();
            blobServiceClient = new BlobServiceClient(blobConnectionString);

        }
        private void InitializeAzureTableClient()
        {
            var serviceClient = new TableServiceClient(connectionString);
            tableClient = serviceClient.GetTableClient(tableName);
            tableClient.CreateIfNotExists();
        }
        private async void Form1_Load(object sender, EventArgs e)
        {
            _ = LoadContactsToGrid();
            InitializeDataGridView(); // Ініціалізуємо стовпці DataGridView
            await LoadContactsToGrid();
            TableGrid.CellClick += TableGrid_CellClick;
        }

        private void FirstName_Click(object sender, EventArgs e)
        {

        }

        private void FirstNameBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void Fatherly_Click(object sender, EventArgs e)
        {

        }

        private void FatherlyBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void LastNameBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void Address_Click(object sender, EventArgs e)
        {

        }

        private void AddressBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void PhoneNumber_Click(object sender, EventArgs e)
        {

        }

        private void NumBox_TextChanged(object sender, EventArgs e)
        {

        }

        private async void AddContact_Click(object sender, EventArgs e)
        {
            string firstName = FirstNameBox.Text;
            string fatherlyName = FatherlyBox.Text;
            string lastName = LastNameBox.Text;
            string address = AddressBox.Text;
            string phoneNumber = NumBox.Text;

            if (string.IsNullOrWhiteSpace(firstName) ||
                string.IsNullOrWhiteSpace(lastName) ||
                string.IsNullOrWhiteSpace(phoneNumber))
            {
                MessageBox.Show("Будь ласка, заповніть всі обов'язкові поля!");
                return;
            }

            try
            {
                // Вибір та завантаження фото
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                if (openFileDialog.ShowDialog() != DialogResult.OK) return;

                string filePath = openFileDialog.FileName;
                string fileName = Path.GetFileName(filePath);

                BlobClient blobClient = containerClient.GetBlobClient(fileName);
                await blobClient.UploadAsync(filePath, overwrite: true);

                // Отримання URL-адреси завантаженого фото
                string photoUrl = blobClient.Uri.ToString();

                // Отримання загальної кількості записів у таблиці для визначення наступного RowKey
                int totalEntities = tableClient.Query<ContactEntity>().Count();
                string newRowKey = (totalEntities + 1).ToString();

                // Додавання нового контакту з URL-адресою фото
                var contact = new ContactEntity(firstName, newRowKey)
                {
                    FirstName = firstName,
                    FatherlyName = fatherlyName,
                    LastName = lastName,
                    Address = address,
                    PhoneNumber = phoneNumber,
                    PhotoUrl = photoUrl  // Додаємо URL-адресу фото
                };

                await AddContactToTableStorage(contact);

                // Очищення текстових полів
                FirstNameBox.Clear();
                FatherlyBox.Clear();
                LastNameBox.Clear();
                AddressBox.Clear();
                NumBox.Clear();

                // Оновлення таблиці на формі
                await LoadContactsToGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка додавання контакту: {ex.Message}");
            }
        }


        private void InitializeDataGridView()
        {
            TableGrid.Columns.Clear(); // Очищуємо стовпці перед додаванням

            // Додаємо стовпці
            TableGrid.Columns.Add("FirstName", "First Name");
            TableGrid.Columns.Add("FatherlyName", "Fatherly Name");
            TableGrid.Columns.Add("LastName", "Last Name");
            TableGrid.Columns.Add("Address", "Address");
            TableGrid.Columns.Add("PhoneNumber", "Phone Number");
            TableGrid.Columns.Add("PhotoUrl", "Photo URL");
            TableGrid.Columns["PhotoUrl"].Visible = false; // Робимо цей стовпець невидимим для користувача

        }
        private async Task LoadContactsToGrid()
        {
            TableGrid.Rows.Clear(); // Очищуємо попередні рядки

            try
            {
                var entities = tableClient.Query<ContactEntity>().ToList();
                foreach (var entity in entities)
                {
                    TableGrid.Rows.Add(entity.FirstName, entity.FatherlyName, entity.LastName,
                                       entity.Address, entity.PhoneNumber, entity.PhotoUrl);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка завантаження даних: {ex.Message}");
            }
        }

        private async Task AddContactToTableStorage(ContactEntity contact)
        {
            try
            {
                await tableClient.AddEntityAsync(contact);
                MessageBox.Show("Контакт успішно додано в Azure Table Storage");
            }
            catch (RequestFailedException ex)
            {
                MessageBox.Show($"Помилка збереження даних: {ex.Message}");
            }
        }

        private void TableGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private async void Update_Click(object sender, EventArgs e)
        {
            if (TableGrid.SelectedRows.Count == 0)
            {
                MessageBox.Show("Будь ласка, виберіть контакт для редагування.");
                return;
            }

            // Отримуємо вибраний рядок
            var selectedRow = TableGrid.SelectedRows[0];

            // Отримуємо оригінальні ключі PartitionKey та RowKey
            string originalFirstName = selectedRow.Cells["FirstName"].Value?.ToString();
            string originalRowKey = selectedRow.Cells["PhoneNumber"].Value?.ToString();

            try
            {
                // Шукаємо контакт в Azure Table Storage за старими ключами
                var contact = tableClient.Query<ContactEntity>(entity =>
                    entity.PartitionKey == originalFirstName && entity.PhoneNumber == originalRowKey).FirstOrDefault();

                if (contact != null)
                {
                    // Отримуємо нові значення з текстових полів або використовуємо старі значення з вибраного рядка
                    string newFirstName = !string.IsNullOrWhiteSpace(FirstNameBox.Text)
                        ? FirstNameBox.Text
                        : selectedRow.Cells["FirstName"].Value.ToString();

                    string newFatherlyName = !string.IsNullOrWhiteSpace(FatherlyBox.Text)
                        ? FatherlyBox.Text
                        : selectedRow.Cells["FatherlyName"].Value.ToString();

                    string newLastName = !string.IsNullOrWhiteSpace(LastNameBox.Text)
                        ? LastNameBox.Text
                        : selectedRow.Cells["LastName"].Value.ToString();

                    string newAddress = !string.IsNullOrWhiteSpace(AddressBox.Text)
                        ? AddressBox.Text
                        : selectedRow.Cells["Address"].Value.ToString();

                    string newPhoneNumber = !string.IsNullOrWhiteSpace(NumBox.Text)
                        ? NumBox.Text
                        : selectedRow.Cells["PhoneNumber"].Value.ToString();

                    // Перевірка, чи дані були змінені
                    bool isChanged = newFirstName != contact.FirstName ||
                                     newFatherlyName != contact.FatherlyName ||
                                     newLastName != contact.LastName ||
                                     newAddress != contact.Address ||
                                     newPhoneNumber != contact.PhoneNumber;

                    if (!isChanged)
                    {
                        MessageBox.Show("Немає змін для збереження.");
                        return;
                    }

                    // Оновлюємо значення контакту
                    contact.FirstName = newFirstName;
                    contact.FatherlyName = newFatherlyName;
                    contact.LastName = newLastName;
                    contact.Address = newAddress;
                    contact.PhoneNumber = newPhoneNumber;

                    // Зберігаємо оновлений контакт в Azure Table Storage
                    await tableClient.UpsertEntityAsync(contact);

                    // Оновлюємо контакт у DataGridView
                    selectedRow.Cells["FirstName"].Value = newFirstName;
                    selectedRow.Cells["FatherlyName"].Value = newFatherlyName;
                    selectedRow.Cells["LastName"].Value = newLastName;
                    selectedRow.Cells["Address"].Value = newAddress;
                    selectedRow.Cells["PhoneNumber"].Value = newPhoneNumber;

                    MessageBox.Show("Контакт успішно оновлено.");
                }
                else
                {
                    MessageBox.Show("Контакт не знайдено в Azure Table Storage.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка оновлення контакту: {ex.Message}");
            }
        }



        private async void DeleteContact_Click(object sender, EventArgs e)
        {
            if (TableGrid.SelectedRows.Count == 0)
            {
                MessageBox.Show("Будь ласка, виберіть контакт для видалення.");
                return;
            }

            var selectedRow = TableGrid.SelectedRows[0];
            string partitionKey = selectedRow.Cells["FirstName"].Value.ToString();
            string phoneNumber = selectedRow.Cells["PhoneNumber"].Value.ToString();

            try
            {
                // Знайти контакт в таблиці Azure Table Storage
                var contact = tableClient.Query<ContactEntity>(entity => entity.PartitionKey == partitionKey && entity.PhoneNumber == phoneNumber).FirstOrDefault();

                if (contact != null)
                {
                    // Видалення фото з Azure Blob Storage, якщо є PhotoUrl
                    if (!string.IsNullOrEmpty(contact.PhotoUrl))
                    {
                        // Отримуємо ім'я блобу з URL
                        Uri photoUri = new Uri(contact.PhotoUrl);
                        string blobName = Path.GetFileName(photoUri.LocalPath);

                        BlobClient blobClient = containerClient.GetBlobClient(blobName);
                        await blobClient.DeleteIfExistsAsync();
                    }

                    // Видалення контакту з Azure Table Storage
                    await tableClient.DeleteEntityAsync(contact.PartitionKey, contact.RowKey);

                    // Видалення контакту з DataGridView
                    TableGrid.Rows.Remove(selectedRow);

                    MessageBox.Show("Контакт та відповідне фото успішно видалено.");
                }
                else
                {
                    MessageBox.Show("Контакт не знайдено в Azure Table Storage.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка видалення контакту: {ex.Message}");
            }
        }

        public class ContactEntity : ITableEntity
        {
            public ContactEntity() { }

            public ContactEntity(string firstName, string rowKey)
            {
                PartitionKey = firstName;
                RowKey = rowKey;
                FirstName = firstName;
            }

            public string PartitionKey { get; set; }
            public string RowKey { get; set; }
            public ETag ETag { get; set; }
            public DateTimeOffset? Timestamp { get; set; }

            public string FirstName { get; set; }
            public string FatherlyName { get; set; }
            public string LastName { get; set; }
            public string Address { get; set; }
            public string PhoneNumber { get; set; }
            public string PhotoUrl { get; set; }  // Додаємо URL фото
        }


        private async void CreateContainer_Click(object sender, EventArgs e)
        {
            try
            {
                containerClient = blobServiceClient.GetBlobContainerClient(containerName);
                await containerClient.CreateIfNotExistsAsync(PublicAccessType.Blob);
                MessageBox.Show("Контейнер успішно створено або вже існує.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка при створенні контейнера: {ex.Message}");
            }
        }

        private async void UpdatePhoto_Click(object sender, EventArgs e)
        {
            try
            {
                // Вибираємо файл для завантаження
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                if (openFileDialog.ShowDialog() != DialogResult.OK) return;

                string filePath = openFileDialog.FileName;
                string fileName = Path.GetFileName(filePath);

                // Завантажуємо файл у контейнер
                BlobClient blobClient = containerClient.GetBlobClient(fileName);
                await blobClient.UploadAsync(filePath, overwrite: true);
                MessageBox.Show("Фото успішно завантажено.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка при завантаженні фото: {ex.Message}");
            }
        }

        private async void Download_Click(object sender, EventArgs e)
        {
            try
            {
                // Отримуємо список усіх файлів (блобів) у контейнері
                var blobs = containerClient.GetBlobs().ToList();
                List<string> blobNames = blobs.Select(b => b.Name).ToList();

                if (blobNames.Count == 0)
                {
                    MessageBox.Show("Немає доступних фото для завантаження.");
                    return;
                }

                // Відображення списку доступних фото для вибору
                using (Form selectForm = new Form())
                {
                    selectForm.Text = "Виберіть фото для завантаження";
                    ListBox listBox = new ListBox { Dock = DockStyle.Fill };
                    listBox.Items.AddRange(blobNames.ToArray());
                    listBox.DoubleClick += (s, ev) => selectForm.Close();
                    selectForm.Controls.Add(listBox);
                    selectForm.ShowDialog();

                    if (listBox.SelectedItem == null)
                    {
                        MessageBox.Show("Фото не вибрано.");
                        return;
                    }

                    string selectedBlobName = listBox.SelectedItem.ToString();

                    // Завантаження вибраного фото
                    BlobClient blobClient = containerClient.GetBlobClient(selectedBlobName);

                    // Відкриття діалогу для вибору місця збереження файлу
                    using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                    {
                        saveFileDialog.FileName = selectedBlobName;
                        saveFileDialog.Filter = "Image files (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png|All files (*.*)|*.*";

                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            // Завантаження файлу синхронним методом
                            using (var fileStream = File.OpenWrite(saveFileDialog.FileName))
                            {
                                blobClient.DownloadTo(fileStream);
                            }
                            MessageBox.Show("Фото успішно завантажено.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка завантаження фото: {ex.Message}");
            }
        }

        private async void Delete_Click(object sender, EventArgs e)
        {
            try
            {
                // Отримуємо список усіх файлів (блобів) у контейнері
                var blobs = containerClient.GetBlobs().ToList();
                List<string> blobNames = blobs.Select(b => b.Name).ToList();

                if (blobNames.Count == 0)
                {
                    MessageBox.Show("Немає доступних фото для видалення.");
                    return;
                }

                // Відображення списку доступних фото для вибору
                using (Form selectForm = new Form())
                {
                    selectForm.Text = "Виберіть фото для видалення";
                    ListBox listBox = new ListBox { Dock = DockStyle.Fill };
                    listBox.Items.AddRange(blobNames.ToArray());
                    listBox.DoubleClick += (s, ev) => selectForm.Close();
                    selectForm.Controls.Add(listBox);
                    selectForm.ShowDialog();

                    if (listBox.SelectedItem == null)
                    {
                        MessageBox.Show("Фото не вибрано.");
                        return;
                    }

                    string selectedBlobName = listBox.SelectedItem.ToString();

                    // Видалення вибраного фото
                    BlobClient blobClient = containerClient.GetBlobClient(selectedBlobName);
                    blobClient.Delete();

                    MessageBox.Show("Фото успішно видалено.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка видалення фото: {ex.Message}");
            }
        }
        private async void TableGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Перевірка, що вибрано коректний рядок (а не заголовок)
            if (e.RowIndex < 0) return;

            // Отримуємо URL-адресу фото з вибраного рядка
            string photoUrl = TableGrid.Rows[e.RowIndex].Cells["PhotoUrl"].Value?.ToString();

            // Якщо URL-адреса не пуста, завантажуємо фото
            if (!string.IsNullOrEmpty(photoUrl))
            {
                try
                {
                    Uri photoUri = new Uri(photoUrl);
                    BlobClient blobClient = new BlobClient(blobConnectionString, containerName, Path.GetFileName(photoUri.LocalPath));
                    BlobDownloadInfo download = await blobClient.DownloadAsync();

                    using (MemoryStream ms = new MemoryStream())
                    {
                        await download.Content.CopyToAsync(ms);
                        ms.Position = 0;
                        pictureBox1.Image = Image.FromStream(ms);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Помилка при завантаженні фото: {ex.Message}");
                }
            }
            else
            {
                pictureBox1.Image = null; // Якщо фото немає, очищуємо PictureBox
            }
        }

        private async void pictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                // Отримати список усіх доступних фото в контейнері
                var blobs = containerClient.GetBlobs().ToList();
                List<string> blobNames = blobs.Select(b => b.Name).ToList();

                if (blobNames.Count == 0)
                {
                    MessageBox.Show("Немає доступних фото для вибору.");
                    return;
                }

                // Створення форми для вибору фото
                using (Form selectForm = new Form())
                {
                    selectForm.Text = "Виберіть фото для відображення";
                    ListBox listBox = new ListBox { Dock = DockStyle.Fill };
                    listBox.Items.AddRange(blobNames.ToArray());
                    listBox.DoubleClick += (s, ev) => selectForm.Close();
                    selectForm.Controls.Add(listBox);
                    selectForm.ShowDialog();

                    if (listBox.SelectedItem == null)
                    {
                        MessageBox.Show("Фото не вибрано.");
                        return;
                    }

                    string selectedBlobName = listBox.SelectedItem.ToString();

                    // Завантаження фото з Blob Storage
                    BlobClient blobClient = containerClient.GetBlobClient(selectedBlobName);
                    BlobDownloadInfo download = await blobClient.DownloadAsync();

                    using (MemoryStream ms = new MemoryStream())
                    {
                        await download.Content.CopyToAsync(ms);
                        ms.Position = 0;
                        pictureBox1.Image = Image.FromStream(ms); // Відображення фото в PictureBox
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка при відображенні фото: {ex.Message}");
            }
        }
    }
}

