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
        private StudentDBContext _context;  
        private Student _selectedStudent;  

        public MainWindow()
        {
            InitializeComponent();
            _context = new StudentDBContext();  
            LoadStudents();  
        }

        
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            
            var name = NameTextBox.Text;
            var age = int.TryParse(AgeTextBox.Text, out int ageParsed) ? ageParsed : 0;
            var address = AddressTextBox.Text;
            var email = EmailTextBox.Text;
            var phoneNumber = PhoneNumberTextBox.Text;
            var batch = BatchTextBox.Text;
            var stream = StreamTextBox.Text;
            var dateOfBirth = DateOfBirthDatePicker.SelectedDate;
            var gender =GenderComboBox.Text;
            var guardianName = GuardianNameTextBox.Text;
            var guardianContact = GuardianContactTextBox.Text;
            var enrollmentDate = EnrollmentDatePicker.SelectedDate;

            
            var newStudent = new Student
            {
                Name = name,
                Age = age,
                Address = address,
                Email = email,
                PhoneNumber = phoneNumber,
                Batch = batch,
                Stream = stream,
                DateOfBirth = dateOfBirth ?? DateTime.Now,  
                Gender = gender,
                GuardianName = guardianName,
                GuardianContact = guardianContact,
                EnrollmentDate = enrollmentDate ?? DateTime.Now  
            };

           
            _context.Students.Add(newStudent);
            _context.SaveChanges();  

            
            ClearInputFields();

    
            MessageBox.Show("Student has been added successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

            
            LoadStudents();
        }

       
        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedStudent != null)
            {
                
                _selectedStudent.Name = NameTextBox.Text;
                _selectedStudent.Age = int.TryParse(AgeTextBox.Text, out int ageParsed) ? ageParsed : _selectedStudent.Age;
                _selectedStudent.Address = AddressTextBox.Text;
                _selectedStudent.Email = EmailTextBox.Text;
                _selectedStudent.PhoneNumber = PhoneNumberTextBox.Text;
                _selectedStudent.Batch = BatchTextBox.Text;
                _selectedStudent.Stream = StreamTextBox.Text;
                _selectedStudent.DateOfBirth = DateOfBirthDatePicker.SelectedDate ?? _selectedStudent.DateOfBirth;
                _selectedStudent.Gender = GenderComboBox.Text;
                _selectedStudent.GuardianName = GuardianNameTextBox.Text;
                _selectedStudent.GuardianContact = GuardianContactTextBox.Text;
                _selectedStudent.EnrollmentDate = EnrollmentDatePicker.SelectedDate ?? _selectedStudent.EnrollmentDate;

                
                _context.Students.Update(_selectedStudent);
                _context.SaveChanges();  

                
                MessageBox.Show("Student has been updated successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                ClearInputFields();
                
                LoadStudents();
            }
            else
            {
                MessageBox.Show("Please select a student to update.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedStudent != null)
            {
                
                _context.Students.Remove(_selectedStudent);
                _context.SaveChanges();  

                
                MessageBox.Show("Student has been deleted successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

               
                LoadStudents();

                
                ClearInputFields();
            }
            else
            {
                MessageBox.Show("Please select a student to delete.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        
        private void LoadStudents()
        {
            var students = _context.Students.ToList();
            StudentDataGrid.ItemsSource = students; 
        }

        
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
            GenderComboBox.Clear();
            GuardianNameTextBox.Clear();
            GuardianContactTextBox.Clear();
            EnrollmentDatePicker.SelectedDate = null;
        }

        
        private void StudentDataGrid_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            
            _selectedStudent = (Student)StudentDataGrid.SelectedItem;

            if (_selectedStudent != null)
            {
               
                NameTextBox.Text = _selectedStudent.Name;
                AgeTextBox.Text = _selectedStudent.Age.ToString();
                AddressTextBox.Text = _selectedStudent.Address;
                EmailTextBox.Text = _selectedStudent.Email;
                PhoneNumberTextBox.Text = _selectedStudent.PhoneNumber;
                BatchTextBox.Text = _selectedStudent.Batch;
                StreamTextBox.Text = _selectedStudent.Stream;
                DateOfBirthDatePicker.SelectedDate = _selectedStudent.DateOfBirth;
                GenderComboBox.Text = _selectedStudent.Gender;
                GuardianNameTextBox.Text = _selectedStudent.GuardianName;
                GuardianContactTextBox.Text = _selectedStudent.GuardianContact;
                EnrollmentDatePicker.SelectedDate = _selectedStudent.EnrollmentDate;
            }
        }
    }




}
