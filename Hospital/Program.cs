using System;
using System.Collections.Generic;
using System.Linq;

namespace Hospital
{
    internal class Program
    {
        static void Main()
        {
            Hospital hospital = new Hospital();
            ConsoleKey exitButton = ConsoleKey.Enter;
            bool isWork = true;

            while (isWork)
            {
                Console.WriteLine("Для начало работы нажмите на любую клавишу");
                Console.ReadKey();
                Console.Clear();
                hospital.CortPatients();
                Console.WriteLine($"\nВы хотите выйти из программы?Нажмите {exitButton}.\nДля продолжение работы нажмите любую другую клавишу");

                if (Console.ReadKey().Key == exitButton)
                {
                    Console.WriteLine("Вы вышли из программы");
                    isWork = false;
                }

                Console.Clear();
            }
        }
    }

    class Hospital
    {
        private List<Patient> _patients;

        public Hospital() 
        {
            _patients = new List<Patient>
            {
                new Patient(18,"Petrov Alexand Vladimirovich ", "Ожог"),
                new Patient(10, "Vladimir Nicolai Antonovich", "Перелом"),
                new Patient(15, "Antonov Vladislav Petrovich", "Механические"),
                new Patient(25, "Dmitrov Valeri Alexandrovich", "Химические"),
                new Patient(60, "Ivanov Ivan Gvozdikov", "Психологические"),
                new Patient(54, "Valeri Valeri Ahmadeev", "Раны"),
                new Patient(34, "Victor Antonov Ivanov", "Кариес"),
                new Patient(14, "Michail Georg Nicolaev", "Аллергия"),
                new Patient(28, "Victoriy Irina Sholoxova", "Ангина"),
                new Patient(8, "Anastaciy Zina Dambaeva", "Лейкемия"),
            };
        }

        public void CortPatients()
        {
            const int NumberCortFullNamePatients = 1;
            const int NumberCortAgePatients = 2;
            const int NumberCortDiseasePatients = 3;

            Console.WriteLine($"Для сортировки пациентов по ФИО {NumberCortFullNamePatients} ,для сортировки пациентов по возрасту {NumberCortAgePatients},для сортировки пациентов по болезни {NumberCortDiseasePatients}");
            int.TryParse(Console.ReadLine(), out int result);

            switch (result) 
            { 
                case NumberCortFullNamePatients:
                    CortFullNamePatients();
                    break;
                case NumberCortAgePatients:
                    CortAgePatients();
                    break;
                case NumberCortDiseasePatients:
                    CortDiseasePatients();
                    break;
                default:Console.WriteLine("Вы выбрали не существующий вариант");
                    break;
            }
        }

        private void CortFullNamePatients()
        {
            var filterFuillNamePatient = _patients.OrderBy(patient => patient.FullName);
            ShowInfo(filterFuillNamePatient);
        }

        private void CortAgePatients()
        {
            var filterAgePatient = _patients.OrderBy(patient => patient.Age);
            ShowInfo(filterAgePatient);
        }

        private void CortDiseasePatients()
        {
            bool isCorrectDisease = false;

            while (isCorrectDisease == false)
            {
                Console.WriteLine("Введите название болезни");
                string nameDisease = Console.ReadLine();
                var filterDiseasePatient = _patients.Where(patient => patient.Disease.Contains(nameDisease)).OrderBy(patient => patient);

                if(filterDiseasePatient.Count() != 0)
                {
                    ShowInfo(filterDiseasePatient);
                    isCorrectDisease = true;
                }
                else
                {
                    Console.WriteLine("Вы ввелм не существующую болезнь");
                }
            }
        }

        private void ShowInfo(IOrderedEnumerable<Patient> filteredPatient)
        {
            foreach(var patient in filteredPatient) 
            {
                Console.WriteLine($"Имя пациента {patient.FullName},Возраст - {patient.Age},Болезнь - {patient.Disease}");
            }
        }
    }

    class Patient 
    {
        public Patient(int age,string fullName,string disease) 
        {
            Age = age;
            FullName = fullName;
            Disease = disease;
        }

        public int Age { get; private set; }
        public string FullName { get;private set; }
        public string Disease { get; private set; }
    }
}
