using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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
using ZadanieFirma.Firma;
using ZadanieFirma.Firma.Contracts;

namespace ZadanieFirma
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Employee> Employers = new List<Employee>();

        public MainWindow()
        {
            InitializeComponent();
            List<Employee> Employers = new List<Employee>();
            DataContext = new ViewModel();
        }

        public void loadData()
        {
            string fileSource = "../../..Baza Danych/Employers.txt";

            //Load employee data from file/database etc.
            using (StreamReader file = new StreamReader(fileSource))
            {
                int counter = 0;
                string ln;

                while ((ln = file.ReadLine()) != null)
                {
                    var data = ln.Split(',');

                    var firstName = data[0];
                    var lastName = data[1];
                    var contractType = data[2];
                    int monthlySalary = Int32.Parse(data[3]);
                    int overtime = Int32.Parse(data[4]);
                    var employee = new Employee(firstName, lastName);

                    Contract contract;
                    switch (contractType)
                    {
                        case "fullTime":
                            contract = new FullTime(monthlySalary, overtime);
                            employee.ChangeContract(contract);
                            break;
                        case "intership":
                            contract = new Intership(monthlySalary);
                            employee.ChangeContract(contract);
                            break;
                        default:
                            // Do nothing, throw error
                            break;
                    }

                    Employers.Add(employee);
                    Console.WriteLine(ln);
                    counter++;
                }
                file.Close();
                Console.WriteLine($"File has {counter} lines.");
            }
        }

        public void saveData(object sender, RoutedEventArgs e)
        {
            string fileSource = @"../../Baza Danych/Employers.txt";
            //string fileSource = System.AppContext.BaseDirectory + @"Baza Danych\Employers.txt";
            File.WriteAllText(fileSource, string.Empty);

            foreach (var employee in Employers)
            {
                var firstName = employee.FirstName;
                var lastName = employee.LastName;
                var contract = employee.Contract.GetType().Name;
                var monthlySalary = employee.Contract.MonthlySalary;
                var overtime = employee.Contract.Overtime;

                using (StreamWriter file = new StreamWriter(@"C:\Users\Public\TestFolder\WriteLines2.txt", true))
                {
                    file.WriteLine($"{firstName}, {lastName}, {contract}, {monthlySalary}, {overtime}");
                    //file.WriteLine("{0}, {1}, {2}, {3}, {4}", employee.FirstName, employee.LastName, employee.Contract.GetType().Name, employee.Contract.MonthlySalary, employee.Contract.Overtime);
                }
            }
        }
        public void addEmployee()
        {

        }
    }
}
