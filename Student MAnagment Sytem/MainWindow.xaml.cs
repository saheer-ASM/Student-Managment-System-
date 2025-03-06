using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Student_Managment_Sytem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private StudentDBContext _context;  // Reference to the database context
        private Student _selectedStudent;  // Reference to the currently selected student

        public MainWindow()
        {
            InitializeComponent();
            _context = new StudentDBContext();  // Initialize the database context
            LoadStudents();  // Load students from database initially
        }

        // Add Student button click event
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            // Collect data from input fields
            var name = NameTextBox.Text;
            var age = int.TryParse(AgeTextBox.Text, out int ageParsed) ? ageParsed : 0;
            var address = AddressTextBox.Text;
            var email = EmailTextBox.Text;
            var phoneNumber = PhoneNumberTextBox.Text;
            var batch = BatchTextBox.Text;
            var stream = StreamTextBox.Text;
            var dateOfBirth = DateOfBirthDatePicker.SelectedDate;
            var gender = GenderComboBox.SelectedItem.ToString();
            var guardianName = GuardianNameTextBox.Text;
            var guardianContact = GuardianContactTextBox.Text;
            var enrollmentDate = EnrollmentDatePicker.SelectedDate;

            // Create a new Student object
            var newStudent = new Student
            {
                Name = name,
                Age = age,
                Address = address,
                Email = email,
                PhoneNumber = phoneNumber,
                Batch = batch,
                Stream = stream,
                DateOfBirth = dateOfBirth ?? DateTime.Now,  // Default to current date if not selected
                Gender = gender,
                GuardianName = guardianName,
                GuardianContact = guardianContact,
                EnrollmentDate = enrollmentDate ?? DateTime.Now  // Default to current date if not selected
            };

            // Add new student to the database
            _context.Students.Add(newStudent);
            _context.SaveChanges();  // Save changes to the database

            // Optionally, clear the input fields after saving
            ClearInputFields();

            // Notify the user that the student has been added
            MessageBox.Show("Student has been added successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

            // Refresh the DataGrid with latest data
            LoadStudents();
        }

        // Update Student button click event
        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedStudent != null)
            {
                // Update selected student data with input fields
                _selectedStudent.Name = NameTextBox.Text;
                _selectedStudent.Age = int.TryParse(AgeTextBox.Text, out int ageParsed) ? ageParsed : _selectedStudent.Age;
                _selectedStudent.Address = AddressTextBox.Text;
                _selectedStudent.Email = EmailTextBox.Text;
                _selectedStudent.PhoneNumber = PhoneNumberTextBox.Text;
                _selectedStudent.Batch = BatchTextBox.Text;
                _selectedStudent.Stream = StreamTextBox.Text;
                _selectedStudent.DateOfBirth = DateOfBirthDatePicker.SelectedDate ?? _selectedStudent.DateOfBirth;
                _selectedStudent.Gender = GenderComboBox.SelectedItem.ToString();
                _selectedStudent.GuardianName = GuardianNameTextBox.Text;
                _selectedStudent.GuardianContact = GuardianContactTextBox.Text;
                _selectedStudent.EnrollmentDate = EnrollmentDatePicker.SelectedDate ?? _selectedStudent.EnrollmentDate;

                // Update student in the database
                _context.Students.Update(_selectedStudent);
                _context.SaveChanges();  // Save changes to the database

                // Notify the user that the student has been updated
                MessageBox.Show("Student has been updated successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                // Refresh the DataGrid
                LoadStudents();
            }
            else
            {
                MessageBox.Show("Please select a student to update.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        // Delete Student button click event
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedStudent != null)
            {
                // Remove the selected student from the database
                _context.Students.Remove(_selectedStudent);
                _context.SaveChanges();  // Save changes to the database

                // Notify the user that the student has been deleted
                MessageBox.Show("Student has been deleted successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                // Refresh the DataGrid
                LoadStudents();

                // Clear the input fields after deletion
                ClearInputFields();
            }
            else
            {
                MessageBox.Show("Please select a student to delete.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        // Method to load students from the database into the DataGrid
        private void LoadStudents()
        {
            var students = _context.Students.ToList();
            StudentDataGrid.ItemsSource = students;  // Bind the DataGrid to the list of students
        }

        // Method to clear input fields after adding or deleting a student
        private void ClearInputFields()
        {
            NameTextBox.Clear();
            AgeTextBox.Clear();
            AddressTextBox.Clear();
            EmailTextBox.Clear();
            PhoneNumberTextBox.Clear();
            BatchTextBox.Clear();
            StreamTextBox.Clear();
            DateOfBirthDatePicker.SelectedDate = null;
            GenderComboBox.SelectedIndex = -1;
            GuardianNameTextBox.Clear();
            GuardianContactTextBox.Clear();
            EnrollmentDatePicker.SelectedDate = null;
        }

        // SelectionChanged event for DataGrid (called when selecting a student)
        private void StudentDataGrid_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            // Get the selected student from the DataGrid
            _selectedStudent = (Student)StudentDataGrid.SelectedItem;

            if (_selectedStudent != null)
            {
                // Fill input fields with selected student data
                NameTextBox.Text = _selectedStudent.Name;
                AgeTextBox.Text = _selectedStudent.Age.ToString();
                AddressTextBox.Text = _selectedStudent.Address;
                EmailTextBox.Text = _selectedStudent.Email;
                PhoneNumberTextBox.Text = _selectedStudent.PhoneNumber;
                BatchTextBox.Text = _selectedStudent.Batch;
                StreamTextBox.Text = _selectedStudent.Stream;
                DateOfBirthDatePicker.SelectedDate = _selectedStudent.DateOfBirth;
                GenderComboBox.SelectedItem = _selectedStudent.Gender;
                GuardianNameTextBox.Text = _selectedStudent.GuardianName;
                GuardianContactTextBox.Text = _selectedStudent.GuardianContact;
                EnrollmentDatePicker.SelectedDate = _selectedStudent.EnrollmentDate;
            }
        }
    }




}
